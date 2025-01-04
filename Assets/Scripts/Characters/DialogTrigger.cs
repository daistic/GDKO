using UnityEngine;
using UnityEngine.InputSystem;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] GameObject dialogObject;
    [SerializeField] Dialog dialog;

    private void OnEnable()
    {
        dialog = dialogObject.GetComponent<Dialog>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.playerController.playerInput.Player.SpaceButton.performed += Talk;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.playerController.playerInput.Player.SpaceButton.performed -= Talk;
            if (GameManager.Instance.dialogCoroutine != null) StopCoroutine(GameManager.Instance.dialogCoroutine);
            dialogObject.SetActive(false);
        }
    }

    private void Talk(InputAction.CallbackContext ctx)
    {
        if (!dialogObject.activeSelf)
        {
            dialogObject.SetActive(true);
        }

        else
        {
            Debug.Log(dialog.isPlaying);

            if (!dialog.isPlaying)
            {
                if (dialog.isLastSentence())
                {
                    dialogObject.SetActive(false);

                    if (dialog.isEventDialog())
                    {
                        string eventName = dialog.eventName();
                        EventManager.Instance.invokeEvent(eventName);
                    }
                }

                else
                {
                    dialog.playNextLine();
                }
            }

            else
            {
                Debug.Log("hah2");
                dialog.FinishSentence();
            }
        }
    }
}
