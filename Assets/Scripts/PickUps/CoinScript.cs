using UnityEngine;

public class CoinScript : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 50 * Time.deltaTime, 0), Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.NumbersOfCoin += 1;
            Destroy(gameObject);
        }
    }
}
