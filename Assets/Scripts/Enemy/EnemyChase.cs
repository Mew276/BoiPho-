using System.Collections;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;

    public static float speed = 21f;
    public float maxSpeed = 35f;

    [Range(0f, 1f)]
    public float percentIncrease = 0.1f; // 10% mỗi 60s

    void Start()
    {
        if (player != null)
        {
            transform.position = player.position - new Vector3(0, 0, 10);
        }

        StartCoroutine(IncreaseSpeedOverTime());
    }

    void Update()
    {
        if (!GameManager.gameStart || player == null)
            return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }

    IEnumerator IncreaseSpeedOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f);

            if (GameManager.gameStart && speed < maxSpeed)
            {
                speed *= (1 + percentIncrease);

                // Clamp không vượt max
                speed = Mathf.Min(speed, maxSpeed);

                Debug.Log("Enemy speed increased to: " + speed);
            }
        }
    }
}