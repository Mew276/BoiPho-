using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static bool gameStart = false;
    public static bool gameOver = false;
    public float enemyBaseSpeed = 21f;
    public float playerBaseSpeed = 10f;

    public TextMeshProUGUI GameOverText;
    public GameObject StartingText;
    public TextMeshProUGUI CoinsText;
    public TextMeshProUGUI ScoreNumbers;
    public TextMeshProUGUI playerSpeed;

    public static int NumbersOfCoin = 0;
    public float score;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameStart = false;
        gameOver = false;

        NumbersOfCoin = 0;
        score = 0;

        GameOverText.gameObject.SetActive(false);
        StartingText.SetActive(true);

        // 🧠 reset player speed
        PlayerMovement.forwardSpeed = 10f;
    }

    void Update()
    {
        CoinsText.text = "Coins : " + NumbersOfCoin;
        playerSpeed.text = "Speed : " + PlayerMovement.forwardSpeed;

        if (gameStart && !gameOver)
        {
            score += PlayerMovement.forwardSpeed * Time.deltaTime;
            ScoreNumbers.text = "Score: " + Mathf.FloorToInt(score / 2) + "m";
        }

        // ▶ start game
        if (Input.GetKeyDown(KeyCode.Space) && !gameStart)
        {
            gameStart = true;
            StartingText.SetActive(false);
        }

        // 💀 game over
        if (gameOver)
        {
            GameOverText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                RestartGame();
            }
        }
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}