using UnityEngine;

public class NitroPickUp : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        var nitro = other.GetComponent<Nitro>();
        if (nitro != null) nitro.ActivateBoost();

        Destroy(gameObject);
    }
}