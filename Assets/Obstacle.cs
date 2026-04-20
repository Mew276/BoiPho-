using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // chỉ xử lý khi là Player
        if (!other.CompareTag("Player")) return;

        PlayerShield shield = other.GetComponent<PlayerShield>();

        // 🛡 có shield → phá obstacle
        if (shield != null && shield.isShieldActive)
        {
            Destroy(gameObject);
            return;
        }

        // ❌ không có shield → player bị hit
        Debug.Log("Player hit obstacle!");
        // TODO: game over / trừ máu / restart
    }
}