using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    // tốc độ di chuyển sang trái/phải
    public float playerSpeed = 5;

    // tốc độ di chuyển tiến về phía trước (auto-run)
    public float forwardSpeed = 5;

    void Update()
    {
        // ===== AUTO RUN =====
        // luôn di chuyển nhân vật về phía trước mỗi frame
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // ===== MOVE LEFT =====
        // nếu nhấn phím A hoặc mũi tên trái
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            // di chuyển sang trái theo tốc độ playerSpeed
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }
        // di chuyển sang trái

        // ===== MOVE RIGHT =====
        // nếu nhấn phím D hoặc mũi tên phải
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            // di chuyển sang phải theo tốc độ playerSpeed
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }
        // di chuyển sang phải
    }
}