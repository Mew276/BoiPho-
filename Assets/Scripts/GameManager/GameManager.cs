using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameStart = false;
    public static bool gameOver = false;

    public TextMeshProUGUI GameOverText;
    public GameObject StartingText;
    public TextMeshProUGUI CoinsText;

    public static int NumbersOfCoin = 0;

    public static bool reStart = false;

    void Start()
    {
        gameStart = false;
        gameOver = false;
        reStart = false;
        NumbersOfCoin = 0;

        GameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        CoinsText.text = "Coins : " + NumbersOfCoin;

        // Start game
        if (Input.GetKeyDown(KeyCode.Space) && !gameStart)
        {
            gameStart = true;
            Destroy(StartingText);
        }

        // Game over
        if (gameOver)
        {
            GameOverText.gameObject.SetActive(true);
            RestartGame();
        }
    }

    void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}