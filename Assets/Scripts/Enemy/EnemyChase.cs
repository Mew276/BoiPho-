using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    void Start()
    {
        transform.position = (player.position - new Vector3(0, 0, 10));
    }
    void Update()
    {
        if (!GameManager.gameStart)
        return;
        
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
    }
}