using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    private Vector3 _position = new Vector3(-7, 0, 0);
    public static int maxCount = 50;
    [SerializeField] private int minDinsatnce;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    private List<GameObject> currentTerrains = new List<GameObject>();

    [SerializeField] private Transform terrainHolder;
    void Start()
    {
        for (int i = 0; i < maxCount; i++)
            SpawnTerrain(true, new Vector3(-7, 0, 0));
        maxCount = currentTerrains.Count;
    }

    public void SpawnTerrain(bool isStart, Vector3 playerPos)
    {
        if (_position.x - playerPos.x < minDinsatnce || (isStart))
        {

            int typeTerrain;
            if (_position.x <= 0)
                typeTerrain = 0;
            else
                typeTerrain = Random.Range(0, terrainDatas.Count);
            int terrainCount = Random.Range(0, terrainDatas[typeTerrain].maxCount);

            for (int i = 0; i < terrainCount; i++)
            {
                GameObject terrain = Instantiate(terrainDatas[typeTerrain].prefab[Random.Range(0,terrainDatas[typeTerrain].prefab.Count)], _position, Quaternion.identity,
                    terrainHolder);
                currentTerrains.Add(terrain);
                if (!isStart)
                {
                    if (currentTerrains.Count > maxCount)
                    {
                        Destroy(currentTerrains[0]);
                        currentTerrains.RemoveAt(0);
                    }
                }
                _position.x++;
            }
        }
    }
}

