using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DuckDialoogTrigger : MonoBehaviour
{
    [SerializeField] GameObject dialogObject;
    DuckDialog dialog;

    public GameObject speechBubble;
    [SerializeField] GameObject promptObject;

    public UnityEvent dialogEvent;

    private void OnEnable()
    {
        dialog = dialogObject.GetComponent<DuckDialog>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.playerController.playerInput.Player.SpaceButton.performed += Talk;
            promptObject?.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.playerController.playerInput.Player.SpaceButton.performed -= Talk;
            if (GameManager.Instance.dialogCoroutine != null) StopCoroutine(GameManager.Instance.dialogCoroutine);
            dialogObject.SetActive(false);
            promptObject?.SetActive(false);
            if (speechBubble != null) speechBubble.SetActive(false);
        }
    }

    private void Talk(InputAction.CallbackContext ctx)
    {
        if (!dialogObject.activeSelf)
        {
            if (speechBubble != null) speechBubble.SetActive(true);
            dialogObject.SetActive(true);
        }

        else
        {

            if (!dialog.isPlaying)
            {
                if (dialog.isLastSentence())
                {
                    if (dialog.isEventDialog())
                    {
                        dialogEvent?.Invoke();
                    }

                    dialogObject.SetActive(false);
                    if (speechBubble != null) speechBubble.SetActive(false);
                }

                else
                {
                    dialog.playNextLine();
                }
            }

            else
            {
                dialog.FinishSentence();
            }
        }
    }
}
