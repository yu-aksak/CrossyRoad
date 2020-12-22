using System;
using System.Numerics;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class MovePlayer : MonoBehaviour
{
   private Vector3 _position;
    [SerializeField] private TerrainGeneration _terrainGeneration;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text coinsText;
    [SerializeField] private GameManager _GameManager;
    [SerializeField] private LayerMask treeLayerMask;
    [SerializeField] private Camera _camera;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip deadSound;
    public static int _score;
    public static int _coins;
    public static bool isAlive;
    public bool isGrounded;
    public bool godMode;

    public bool IsGrounded
    {
        get
        {
            return isGrounded;
        }
        set
        {
            isGrounded = value;
        }
    }
    void Start()
    {
        _position = transform.position;
        _score = 0;
        isAlive = true;
        godMode = false;
    }

    void Update()
    {
        scoreText.text = "Score: " + _score;
        coinsText.text = "Coins: " + _coins;
        _score = PlayerPrefs.GetInt("Score", _score);
        _position = transform.position;
        if (isAlive)
        {
            if (IsGrounded && Input.GetKeyDown(KeyCode.W))
            {
                Collider[] trees = Physics.OverlapSphere((_position + Vector3.right), 0.1f, treeLayerMask);
                if (trees.Length == 0)
                {
                    PlayerMove(new Vector3(_position.x + 1, 1.0f, _position.z));
                    RotatePlayer(new Vector3(0.0f, 0.0f, 0.0f));
                    _position.x += 1;
                    _score++;
                }
            }

            if (IsGrounded && Input.GetKeyDown(KeyCode.S))
            {
                Collider[] trees = Physics.OverlapSphere((_position + Vector3.left), 0.1f, treeLayerMask);
                if (trees.Length == 0)
                {
                    PlayerMove(new Vector3(_position.x - 1, 1.0f, _position.z));
                    RotatePlayer(new Vector3(0.0f, 180.0f, 0.0f));
                    _position.x -= 1;
                    _score--;
                }
            }

            if (IsGrounded && Input.GetKeyDown(KeyCode.A))
            {
                Collider[] trees = Physics.OverlapSphere((_position + Vector3.forward), 0.1f, treeLayerMask);
                if (trees.Length == 0)
                {
                    PlayerMove(new Vector3(_position.x, 1.0f, _position.z + 1));
                    RotatePlayer(new Vector3(0.0f, -90.0f, 0.0f));
                    _position.z += 1;
                }
            }

            if (IsGrounded && Input.GetKeyDown(KeyCode.D))
            {
                Collider[] trees = Physics.OverlapSphere((_position + Vector3.back), 0.1f, treeLayerMask);
                if (trees.Length == 0)
                {
                    PlayerMove(new Vector3(_position.x, 1.0f, _position.z - 1));
                    RotatePlayer(new Vector3(0.0f, 90.0f, 0.0f));
                    _position.z -= 1;
                }
            }
        }
        else
        {
            _GameManager.GameOver();
            AudioSource.PlayClipAtPoint(deadSound, transform.position);
            gameObject.SetActive(false);
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.GetComponent<ObjectMove>() != null)
        {
            if (other.collider.GetComponent<ObjectMove>().isLog)
            {
                transform.SetParent(other.transform);
            }
        }
        else
        {
            transform.parent = null;
        }
    }

    private void PlayerMove(Vector3 pos)
    {
        transform.DOJump(pos, 0.5f, 1, 0.1f, true);
        _terrainGeneration.SpawnTerrain(false, _position);
        AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        
    }

    private void RotatePlayer(Vector3 rotation)
    {
        transform.DORotate(rotation, 0.1f, RotateMode.Fast);
    }
}
