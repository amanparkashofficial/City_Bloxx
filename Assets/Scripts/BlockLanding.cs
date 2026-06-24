using UnityEngine;

public class BlockLanding : MonoBehaviour
{
    private bool landed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (landed)
            return;

        if (
            collision.gameObject.CompareTag("Building")
        )
        {
            landed = true;

            Debug.Log("Block Landed!");

            GameManager.Instance.SpawnNextBlock();
        }
    }
}