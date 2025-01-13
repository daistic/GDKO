using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    [SerializeField] GameObject winScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            winScreen.SetActive(true);
        }
    }
}
