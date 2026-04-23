using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public static float forwardSpeed = 10f;
    public float maxSpeed = 30f;
    GameManager gm;
    public float percentIncreasePerMinute = 0.8f;
    void Start()
    {
        gm = GameManager.Instance;
    }
    void Update()
    {
        if (!GameManager.gameStart)
            return;

        if (forwardSpeed < maxSpeed)
        {
            float increasePerSecond = percentIncreasePerMinute / 60f;
            forwardSpeed *= (1 + increasePerSecond * Time.deltaTime);
            forwardSpeed = Mathf.Min(forwardSpeed, maxSpeed);
        }

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * gm.playerBaseSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * gm.playerBaseSpeed * Time.deltaTime);
        }
    }
}