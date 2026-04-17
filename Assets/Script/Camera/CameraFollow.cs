using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("===== TARGET =====")]

    // object mà camera sẽ theo dõi (thường là Player)
    public Transform player;


    [Header("===== OFFSET =====")]

    // khoảng cách giữa camera và player
    // (0,5,-10) nghĩa là camera ở trên cao và phía sau player
    public Vector3 offset = new Vector3(0, 5, -10);


    [Header("===== SMOOTH FOLLOW =====")]

    // tốc độ camera di chuyển theo player
    // càng lớn → camera càng bám sát nhanh
    public float followSpeed = 5f;


    void LateUpdate()
    {
        // LateUpdate chạy sau Update()
        // => giúp camera update sau khi player đã di chuyển xong
        // => tránh rung giật camera

        // tính vị trí camera mong muốn = vị trí player + offset
        Vector3 targetPosition = player.position + offset;

        // ===== SMOOTH FOLLOW =====
        // nội suy từ vị trí hiện tại → vị trí target
        // giúp camera di chuyển mượt thay vì teleport
        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            followSpeed * Time.deltaTime
        );

        // ===== LOOK AT PLAYER =====
        // camera luôn xoay mặt về phía player
        transform.LookAt(player);
    }
}