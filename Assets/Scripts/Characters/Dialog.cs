using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour
{
    [SerializeField] TextMesh dialogText;
    [SerializeField] DialogScriptable dialogScript;
    public float typingSpeed = 0.05f;
    public bool isPlaying;

    int currentLineIndex = -1;

    private void OnEnable()
    {
        dialogText = GetComponent<TextMesh>();
        playDialog();
    }

    private void playDialog()
    {
        currentLineIndex = -1;
        playNextLine();
    }

    public void playNextLine()
    {
        GameManager.Instance.dialogCoroutine = StartCoroutine(TypeText(dialogScript.getLines()[++currentLineIndex]));
    }

    public void FinishSentence()
    {
        if (GameManager.Instance.dialogCoroutine != null)
        {
            StopCoroutine(GameManager.Instance.dialogCoroutine);
            GameManager.Instance.dialogCoroutine = null;
        }

        dialogText.text = dialogScript.getLines()[currentLineIndex];
        isPlaying = false;
    }
    public bool isLastSentence()
    {
        return currentLineIndex + 1 == dialogScript.getLines().Count;
    }

    private IEnumerator TypeText(string text)
    {
        dialogText.text = "";
        isPlaying = true;
        int wordIndex = 0;

        while (isPlaying)
        {
            dialogText.text += text[wordIndex];
            yield return new WaitForSeconds(typingSpeed);
            if (++wordIndex == text.Length)
            {
                isPlaying = false;
                break;
            }
        }
    }
}
