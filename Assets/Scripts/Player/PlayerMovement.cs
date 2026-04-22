using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10f;
    public static float forwardSpeed = 10f;
    public float maxSpeed = 30f;

    [Range(0f, 1f)]
    public float percentIncreasePerMinute = 0.8f;

    void Update()
    {
        if (!GameManager.gameStart)
            return;

        // Tăng tốc mượt theo thời gian
        if (forwardSpeed < maxSpeed)
        {
            float increasePerSecond = percentIncreasePerMinute / 60f;
            forwardSpeed *= (1 + increasePerSecond * Time.deltaTime);
            forwardSpeed = Mathf.Min(forwardSpeed, maxSpeed);
        }

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }
    }
}