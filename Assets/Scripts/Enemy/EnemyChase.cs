using System.Collections;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public float maxSpeed = 35f;
    GameManager gm;
    public float percentIncrease = 0.1f;
    void Start()
    {
        gm = GameManager.Instance;
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
            gm.enemyBaseSpeed * Time.deltaTime
        );
    }

    IEnumerator IncreaseSpeedOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f);

            if (GameManager.gameStart && gm.enemyBaseSpeed < maxSpeed)
            {
                gm.enemyBaseSpeed *= (1 + percentIncrease);

                gm.enemyBaseSpeed = Mathf.Min(gm.enemyBaseSpeed, maxSpeed);

                Debug.Log("Enemy speed increased to: " + gm.enemyBaseSpeed);
            }
        }
    }
}