using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10f;
    public static float forwardSpeed = 10f;
    public float maxSpeed = 30f;
    public float speedIncearebyTime = 0.1f;
    void Update()
    {
        if (!GameManager.gameStart)
            return;

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }

        StartCoroutine("SpeedIncearse");
    }

    IEnumerator SpeedIncearse()
    {
        yield return new WaitForSeconds(60);
        if (forwardSpeed < maxSpeed)
        {
            Debug.Log("Da cong them speed cho player");
            forwardSpeed += speedIncearebyTime * Time.deltaTime;
        }
    }
}