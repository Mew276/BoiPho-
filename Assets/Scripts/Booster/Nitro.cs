using System.Collections;
using UnityEngine;

public class Nitro : MonoBehaviour
{
    public float boostMultiplier = 2f;
    public float boostDuration = 5f;

    public static bool isBoosting = false;

    void Start()
    {
        StopAllCoroutines();
    }
    public void ActivateBoost()
    {
        if (!isBoosting)
        {
            StartCoroutine(Boost());
        }
    }

    IEnumerator Boost()
    {
        isBoosting = true;

        float originalSpeed = PlayerMovement.forwardSpeed;

        PlayerMovement.forwardSpeed = originalSpeed * boostMultiplier;

        yield return new WaitForSeconds(boostDuration);

        PlayerMovement.forwardSpeed = originalSpeed;

        isBoosting = false;
    }
}