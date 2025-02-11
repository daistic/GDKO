using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 0.2f;

    private void FixedUpdate()
    {
        transform.position += Vector3.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
