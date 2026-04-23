using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShield shield = other.GetComponent<PlayerShield>();

            if (shield != null)
            {
                shield.ActivateShield();
            }

            Destroy(gameObject);
        }
    }
}