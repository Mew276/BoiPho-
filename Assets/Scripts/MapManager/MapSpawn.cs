using UnityEngine;
using System.Collections.Generic;

public class MapSpawn : MonoBehaviour
{
    public GameObject[] tiles;
    public float zSpawn = 0;
    public float tileLength = 25;
    public int numberOfTiles = 5;

    public Transform playerTransform;

    private List<GameObject> activeTiles = new List<GameObject>();

    void Start()
    {
        SpawnTile(0);
        
        for (int i = 0; i < numberOfTiles - 1; i++)
        {
            SpawnTile(i == 0 ? 0 : Random.Range(0, tiles.Length));
        }
    }

    void Update()
    {
        if (playerTransform.position.z - 30 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tiles.Length));
            DeleteTile();
        }
    }

    void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(
            tiles[tileIndex],
            transform.forward * zSpawn,
            transform.rotation
        );

        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}