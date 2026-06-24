using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("References")]
    public GameObject blockPrefab;

    [Header("Game Settings")]
    public int lives = 3;
    public int score = 0;

    [HideInInspector]
    public bool isGameOver = false;

    private GameObject lastPlacedBlock;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        lastPlacedBlock = GameObject.Find("Foundation");
    }

    public void SpawnNextBlock()
    {
        if (isGameOver)
            return;

        float spawnY = lastPlacedBlock.transform.position.y + 3f;

        GameObject newBlock = Instantiate(
            blockPrefab,
            new Vector3(0, spawnY, 0),
            Quaternion.identity
        );

        Rigidbody2D rb = newBlock.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 0;
            rb.linearVelocity = Vector2.zero;
        }

        BlockSwing swing = newBlock.GetComponent<BlockSwing>();

        if (swing != null)
        {
            swing.enabled = true;
        }
    }

    public void SetLastPlacedBlock(GameObject block)
    {
        lastPlacedBlock = block;
    }

    public void AddScore(int points)
{
    score += points;

    UIManager.Instance.UpdateScore(score);

    Debug.Log("Score: " + score);
}

    public void LoseLife()
    {
        if (isGameOver)
            return;

        lives--;
        UIManager.Instance.UpdateLives(lives);

        Debug.Log("Lives Remaining: " + lives);

        if (lives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;

        Debug.Log("GAME OVER");
        UIManager.Instance.ShowGameOver();

        Time.timeScale = 0f;
    }
}