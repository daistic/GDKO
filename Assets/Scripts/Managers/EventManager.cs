using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    #region Singleton
    private static EventManager _instance;
    public static EventManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance) Destroy(gameObject);
        else _instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion

    [Header("Dialog Events")]
    [SerializeField] UnityEvent godEvent;

    public void invokeEvent(string eventName)
    {
        if (eventName == "godEvent") godEvent?.Invoke();
    }
}
