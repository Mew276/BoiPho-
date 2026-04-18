using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static bool gameStart = false;
    public static bool gameOver = false;
    public TextMeshProUGUI GameOverText;
    public GameObject StartingText;
    public TextMeshProUGUI CoinsText;
    public static int NumbersOfCoin = 0;
    void Start()
    {
        gameStart = false;
        gameOver = false;
        NumbersOfCoin = 0;
        GameOverText.gameObject.SetActive(false);
    }
    void Update()
    {
        CoinsText.text = "Coins : " + NumbersOfCoin;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameStart = true;
            Destroy(StartingText);
        }

        if (gameOver)
        {
            GameOverText.gameObject.SetActive(true);
        }
    }
}
