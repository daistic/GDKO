using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] GameObject dialogObject;
    Dialog dialog;

    [SerializeField] GameObject speechBubble;
    [SerializeField] GameObject promptObject;

    [SerializeField] UnityEvent dialogEvent;

    private void OnEnable()
    {
        dialog = dialogObject.GetComponent<Dialog>();
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
                    dialogObject.SetActive(false);
                    if (speechBubble != null) speechBubble.SetActive(false);

                    if (dialog.isEventDialog())
                    {
                        dialogEvent?.Invoke();
                    }
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
