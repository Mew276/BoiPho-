using UnityEngine;

public class TapBoostController : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float maxSpeed = 12f;
    public float tapBoostAmount = 2f;
    public float decaySpeed = 3f;
    public float tapResetWindow = 0.3f;
    private float currentSpeed;
    private float lastTapTime;

    void Start()
    {
        currentSpeed = normalSpeed;
    }

    void Update()
    {
        HandleInput();
        HandleDecay();
        Move();
    }

    void HandleInput()
    {
        bool tapped = false;

        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
                tapped = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Da bam");
            tapped = true;
        }

        if (tapped)
        {
            OnTap();
        }
    }

    void OnTap()
    {
        if (Time.time - lastTapTime <= tapResetWindow)
        {
            currentSpeed += tapBoostAmount;
        }
        else
        {
            currentSpeed += tapBoostAmount * 0.5f;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, normalSpeed, maxSpeed);
        lastTapTime = Time.time;
    }

    void HandleDecay()
    {
        if (Time.time - lastTapTime > tapResetWindow)
        {
            currentSpeed -= decaySpeed * Time.deltaTime;
        }

        if (currentSpeed < normalSpeed)
        {
            currentSpeed = normalSpeed;
        }
    }

    void Move()
    {
        if (!GameManager.gameStart)
            return;

        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}