using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] Animator doorAnimator;
    [SerializeField] float buttonPressedDistance = 1f;

    private void Start()
    {
        doorAnimator = door.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            doorAnimator.enabled = true;
            this.transform.position -= new Vector3(0, buttonPressedDistance, 0);
        }
    }
}
