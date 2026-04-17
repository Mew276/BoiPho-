using UnityEngine;

public class TapBoostController : MonoBehaviour
{
    [Header("===== SPEED CONFIG =====")]

    // tốc độ chạy bình thường (không boost)
    public float normalSpeed = 5f;

    // tốc độ tối đa khi spam tap
    public float maxSpeed = 12f;

    // lượng tăng speed mỗi lần tap
    public float tapBoostAmount = 2f;

    // tốc độ giảm khi không tap (decay)
    public float decaySpeed = 3f;


    [Header("===== TAP CONTROL =====")]

    // khoảng thời gian giữa 2 lần tap để coi là "spam liên tục"
    public float tapResetWindow = 0.3f;


    // tốc độ hiện tại của nhân vật
    private float currentSpeed;

    // thời điểm lần tap gần nhất
    private float lastTapTime;


    void Start()
    {
        // khởi tạo speed ban đầu = speed thường
        currentSpeed = normalSpeed;
    }


    void Update()
    {
        // xử lý input tap
        HandleInput();

        // xử lý giảm tốc khi không tap
        HandleDecay();

        // di chuyển nhân vật
        Move();
    }


    void HandleInput()
    {
        bool tapped = false;

        // ===== MOBILE INPUT =====
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            // chỉ lấy lúc bắt đầu chạm màn hình
            if (t.phase == TouchPhase.Began)
                tapped = true;
        }

        // ===== PC TEST INPUT =====
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Da bam");
            tapped = true;
        }

        // nếu có tap → xử lý tăng tốc
        if (tapped)
        {
            OnTap();
        }
    }


    void OnTap()
    {
        // kiểm tra khoảng cách giữa 2 lần tap
        // nếu tap liên tục trong thời gian ngắn → coi là spam
        if (Time.time - lastTapTime <= tapResetWindow)
        {
            // spam tap → tăng speed mạnh hơn
            currentSpeed += tapBoostAmount;
        }
        else
        {
            // tap chậm → vẫn tăng nhưng yếu hơn
            currentSpeed += tapBoostAmount * 0.5f;
        }

        // giới hạn speed không vượt quá maxSpeed
        currentSpeed = Mathf.Clamp(currentSpeed, normalSpeed, maxSpeed);

        // cập nhật thời gian tap gần nhất
        lastTapTime = Time.time;
    }


    void HandleDecay()
    {
        // nếu không tap trong một khoảng thời gian
        if (Time.time - lastTapTime > tapResetWindow)
        {
            // giảm tốc dần theo thời gian
            currentSpeed -= decaySpeed * Time.deltaTime;
        }

        // không cho speed xuống thấp hơn normalSpeed
        if (currentSpeed < normalSpeed)
        {
            currentSpeed = normalSpeed;
        }
    }


    void Move()
    {
        // di chuyển nhân vật về phía trước theo speed hiện tại
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}