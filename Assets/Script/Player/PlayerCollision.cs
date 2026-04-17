using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // luu vi tri ban dau
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Va chạm!");

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = startPosition; // quay ve cho cu
    }
}