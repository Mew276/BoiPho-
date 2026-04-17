using UnityEngine;
using System.Collections.Generic;

public class MapSpawn : MonoBehaviour
{
    [Header("===== TILE SETTINGS =====")]

    // danh sách các prefab tile (đoạn map)
    public GameObject[] tiles;

    // vị trí Z để spawn tile tiếp theo
    public float zSpawn = 0;

    // độ dài mỗi tile (khoảng cách giữa các đoạn map)
    public float tileLength = 25;

    // số lượng tile luôn tồn tại trên map
    public int numberOfTiles = 5;


    [Header("===== PLAYER =====")]

    // tham chiếu tới player để theo dõi vị trí
    public Transform playerTransform;


    [Header("===== ACTIVE TILE LIST =====")]

    // danh sách tile đang tồn tại trong scene
    private List<GameObject> activeTiles = new List<GameObject>();


    void Start()
    {
        // tạo map ban đầu khi game bắt đầu

        for (int i = 0; i < numberOfTiles; i++)
        {
            // tile đầu tiên luôn là 0 (map khởi đầu cố định)
            // các tile sau random
            SpawnTile(i == 0 ? 0 : Random.Range(0, tiles.Length));
        }
    }


    void Update()
    {
        // kiểm tra xem player đã đi đủ xa để spawn tile mới chưa

        if (playerTransform.position.z - 30 > zSpawn - (numberOfTiles * tileLength))
        {
            // spawn tile mới ngẫu nhiên
            SpawnTile(Random.Range(0, tiles.Length));

            // xóa tile cũ nhất để tiết kiệm memory
            DeleteTile();
        }
    }


    void SpawnTile(int tileIndex)
    {
        // tạo tile mới ở vị trí zSpawn hiện tại
        GameObject go = Instantiate(
            tiles[tileIndex],
            transform.forward * zSpawn,
            transform.rotation
        );

        // thêm tile vào danh sách đang active
        activeTiles.Add(go);

        // tăng vị trí spawn cho tile tiếp theo
        zSpawn += tileLength;
    }


    void DeleteTile()
    {
        // xóa tile cũ nhất (tile đầu list)
        Destroy(activeTiles[0]);

        // bỏ nó khỏi danh sách
        activeTiles.RemoveAt(0);
    }
}