using System.Collections;
using UnityEngine;

public class Nitro : MonoBehaviour
{
    public float boostMultiplier = 2f;
    public float boostDuration = 5f;

    public static bool isBoosting = false;

    private static float baseSpeed;
    private static bool hasBaseSpeed = false;

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

        // lưu speed gốc 1 lần
        if (!hasBaseSpeed)
        {
            baseSpeed = PlayerMovement.forwardSpeed;
            hasBaseSpeed = true;
        }

        PlayerMovement.forwardSpeed = baseSpeed * boostMultiplier;

        yield return new WaitForSeconds(boostDuration);

        PlayerMovement.forwardSpeed = baseSpeed;

        isBoosting = false;
    }
}