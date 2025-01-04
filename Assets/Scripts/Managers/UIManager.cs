using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance) Destroy(gameObject);
        else _instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion

    [Header("Boolean Check")]
    public bool isMoveRightActivated = false;
    
    public void toggleMoveRight()
    {
        GameManager.Instance.playerController.handleMoveRight(isMoveRightActivated);
        isMoveRightActivated = true;
    }
}