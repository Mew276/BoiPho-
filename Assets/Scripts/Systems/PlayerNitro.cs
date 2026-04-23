using System.Collections;
using UnityEngine;

public class Nitro : MonoBehaviour
{
    public float boostMultiplier = 2f;
    public float boostDuration = 5f;

    float baseSpeed;
    Coroutine boostRoutine;

    public void ActivateBoost()
    {
        if (boostRoutine != null) StopCoroutine(boostRoutine);
        boostRoutine = StartCoroutine(Boost());
    }

    IEnumerator Boost()
    {
        baseSpeed = PlayerMovement.forwardSpeed;
        PlayerMovement.forwardSpeed = baseSpeed * boostMultiplier;

        yield return new WaitForSeconds(boostDuration);

        PlayerMovement.forwardSpeed = baseSpeed;
        boostRoutine = null;
    }
}