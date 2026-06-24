using UnityEngine;

public class BlockLanding : MonoBehaviour
{
    private bool landed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (landed)
            return;

        if (!collision.gameObject.CompareTag("Building"))
            return;

        landed = true;

        SpriteRenderer currentRenderer =
            GetComponent<SpriteRenderer>();

        SpriteRenderer belowRenderer =
            collision.gameObject.GetComponent<SpriteRenderer>();

        float currentWidth =
            currentRenderer.bounds.size.x;

        float belowWidth =
            belowRenderer.bounds.size.x;

        float left =
            Mathf.Max(
                transform.position.x - currentWidth / 2,
                collision.transform.position.x - belowWidth / 2
            );

        float right =
            Mathf.Min(
                transform.position.x + currentWidth / 2,
                collision.transform.position.x + belowWidth / 2
            );

        float overlap = right - left;

        float overlapPercent =
            overlap / currentWidth;

        Debug.Log("Overlap %: " + overlapPercent);

        // Perfect
        if (overlapPercent >= 0.8f)
        {
            Debug.Log("Perfect!");

            GameManager.Instance.AddScore(100);

            PlaceBlock();

            GameManager.Instance.SpawnNextBlock();
        }
        // Good
        else if (overlapPercent >= 0.5f)
        {
            Debug.Log("Good!");

            GameManager.Instance.AddScore(50);

            PlaceBlock();

            GameManager.Instance.SpawnNextBlock();
        }
        // Miss
        else
        {
            Debug.Log("Miss!");

            GameManager.Instance.LoseLife();

            Destroy(gameObject);

            if (GameManager.Instance.lives > 0)
            {
                GameManager.Instance.SpawnNextBlock();
            }
        }
    }

   private void PlaceBlock()
{
    Rigidbody2D rb = GetComponent<Rigidbody2D>();

    rb.linearVelocity = Vector2.zero;
    rb.gravityScale = 0;

    // Don't make it Static
    rb.bodyType = RigidbodyType2D.Kinematic;

    GameManager.Instance.SetLastPlacedBlock(gameObject);
}
}