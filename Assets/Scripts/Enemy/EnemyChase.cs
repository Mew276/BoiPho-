using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    public static float speed = 21f;
    void Start()
    {
        if (player != null)
        {
            transform.position = player.position - new Vector3(0, 0, 10);
        }
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
}