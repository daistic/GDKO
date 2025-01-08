using System.Collections;
using UnityEngine;

public class BadBlock : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float deathTime;
    [SerializeField] float revealTime = 1;
    bool startMoving = false;

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
        if (startMoving)
        {
            this.transform.position += Vector3.down * moveSpeed;
        }
    }

    private IEnumerator DeathCountdown()
    {
        yield return new WaitForSeconds(revealTime);
        startMoving = true;
        yield return new WaitForSeconds(deathTime);
        Destroy(this.gameObject);
    }
}
