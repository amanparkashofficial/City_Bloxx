using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI References")]
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text gameOverText;

    [Header("Panels")]
    public GameObject gameOverPanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateScore(0);
        UpdateLives(3);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void UpdateLives(int lives)
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives;
        }
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}