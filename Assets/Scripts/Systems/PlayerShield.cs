using System.Collections;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public bool isShieldActive = false;
    public float shieldDuration = 5f;

    public GameObject shieldEffect;

    public void ActivateShield()
    {
        StartCoroutine(ShieldRoutine());
    }

    IEnumerator ShieldRoutine()
    {
        isShieldActive = true;

        if (shieldEffect != null)
            shieldEffect.SetActive(true);

        yield return new WaitForSeconds(shieldDuration);

        isShieldActive = false;

        if (shieldEffect != null)
            shieldEffect.SetActive(false);
    }
}