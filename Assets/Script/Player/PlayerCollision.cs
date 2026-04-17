using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // lưu lại vị trí ban đầu của player để respawn
    Vector3 startPosition;

    void Start()
    {
        // lấy vị trí hiện tại của player khi game bắt đầu
        startPosition = transform.position; // lưu vị trí ban đầu
    }

    void OnCollisionEnter(Collision collision)
    {
        // log ra console khi có va chạm (để debug)
        Debug.Log("Va chạm!");

        // kiểm tra object va chạm có tag là "Enemy" không
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // nếu đúng là Enemy thì gọi hàm respawn
            Respawn();
        }
    }

    void Respawn()
    {
        // đưa player quay lại vị trí ban đầu
        transform.position = startPosition; // quay về chỗ cũ
    }
}