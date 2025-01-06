using System.Collections;
using UnityEngine;

public class BadBlockSpawner : MonoBehaviour
{
    [SerializeField] GameObject badBlockPrefab;
    public float spawnDelay;
    public float blockMoveSpeed;

    private void Start()
    {
        Coroutine spawnTimer = StartCoroutine(spawnCountDown());
    }

    private IEnumerator spawnCountDown()
    {
        Instantiate(badBlockPrefab, this.gameObject.transform);

        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(badBlockPrefab, this.gameObject.transform);
        }
    }
}
