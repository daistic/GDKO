using UnityEngine;
using UnityEngine.Events;

public class ItemTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent itemGetEvents;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            itemGetEvents?.Invoke();
        }
    }
}
