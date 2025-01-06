using System.Collections;
using UnityEngine;

public class BadBlock : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    public float deathTime = 3;

    private void OnEnable()
    {
        GameObject spawner = this.transform.parent.gameObject;
        BadBlockSpawner spawnerScript = spawner.GetComponent<BadBlockSpawner>();
        moveSpeed = spawnerScript.blockMoveSpeed;
        deathTime = spawnerScript.spawnDelay;

        Coroutine deathTimer = StartCoroutine(DeathCountdown());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = GameManager.Instance.lastSpawnPoint;
        }
    }

    private void FixedUpdate()
    {
        this.transform.position += Vector3.down * moveSpeed;
    }

    private IEnumerator DeathCountdown()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(this.gameObject);
    }
}
