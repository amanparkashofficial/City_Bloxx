using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject blockPrefab;

    private float nextY = 5f;

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnNextBlock()
    {
        GameObject newBlock =
            Instantiate(
                blockPrefab,
                new Vector3(0, nextY, 0),
                Quaternion.identity
            );

        nextY += 1.2f;

        Rigidbody2D rb =
            newBlock.GetComponent<Rigidbody2D>();

        rb.gravityScale = 0;

        newBlock.GetComponent<BlockSwing>().enabled = true;
    }
}