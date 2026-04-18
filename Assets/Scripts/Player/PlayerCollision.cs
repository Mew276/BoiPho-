using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Va chạm!");

        if (collision.gameObject.CompareTag("Enemy"))
        {
            StopGame();
        }
    }

    void StopGame()
    {
        GameManager.gameOver = true;
        Time.timeScale = 0f;
        Debug.Log("Die!!!");
    }
}