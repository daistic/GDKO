using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] float transformHeight = 3f;
    [SerializeField] float transformSpeed = 0.5f;

    private void Start()
    {
        transformHeight += door.transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aks");
        if (collision.CompareTag("Player"))
        {
            Debug.Log("aijs");
            door.transform.TransformDirection(door.transform.position.x, 4, 0);
        }
    }

    private void FixedUpdate()
    {
        
    }
}
