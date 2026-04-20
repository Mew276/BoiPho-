using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10f;
    public static float forwardSpeed = 10f;

    void Update()
    {
        if (!GameManager.gameStart)
            return;

        // Di chuyển tiến
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // Di chuyển trái
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }

        // Di chuyển phải
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }
    }
}