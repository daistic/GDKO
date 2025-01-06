using UnityEngine;

public class SpawnPointTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.lastSpawnPoint = this.transform.position;
        }
    }
}
