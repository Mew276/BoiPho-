using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }
}