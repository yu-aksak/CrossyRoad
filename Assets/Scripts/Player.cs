using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector3 _position;
    [SerializeField] private TerrainGeneration _terrainGeneration;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text coinsText;
    [SerializeField] private GameManager _GameManager;
    public static int _score;
    public static int _coins;
    public static bool isAlive;

    void Start()
    {
        _position = transform.position;
        _score = 0;
        isAlive = true;
    }

    void Update()
    {
        scoreText.text = "Score: " + _score;
        coinsText.text = "Coins: " + _coins;
        _score = PlayerPrefs.GetInt("Score", _score);
        _position = transform.position;
        if (isAlive)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                MovePlayer(new Vector3(_position.x + 1, _position.y, _position.z));
                RotatePlayer(new Vector3(0, 0, 0));
                _position.x += 1;
                _score++;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                MovePlayer(new Vector3(_position.x - 1, _position.y, _position.z));
                RotatePlayer(new Vector3(0, 180, 0));
                _position.x -= 1;
                _score--;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                MovePlayer(new Vector3(_position.x, _position.y, _position.z + 1));
                RotatePlayer(new Vector3(0, -90, 0));
                _position.z += 1;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                MovePlayer(new Vector3(_position.x, _position.y, _position.z - 1));
                RotatePlayer(new Vector3(0, 90, 0));
                _position.z -= 1;
            }
        }
        else
        {
            _GameManager.GameOver();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.GetComponent<ObjectMove>() != null)
        {
            if (other.collider.GetComponent<ObjectMove>().isLog)
            {
                transform.parent = other.collider.transform;
            }
        }
        else
        {
            transform.parent = null;
        }
    }

    private void MovePlayer(Vector3 pos)
    {
        transform.DOJump(pos, 0.5f, 1, 0.5f, false);
        _terrainGeneration.SpawnTerrain(false, _position);
    }

    private void RotatePlayer(Vector3 rotation)
    {
        transform.DORotate(rotation, 0.5f, RotateMode.Fast);
    }


}
