using UnityEngine;

public class Boss : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = GameManager.Instance.lastSpawnPoint;
        }
    }
}
