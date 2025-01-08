using Unity.Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance {  get { return _instance; } }

    private void Awake()
    {
        if (_instance) Destroy(gameObject);
        else _instance = this;
        DontDestroyOnLoad(this);

        findStuff();
    }
    #endregion

    [Header("Player")]
    public GameObject player;
    public PlayerController playerController;
    public Vector3 lastSpawnPoint;

    [Header("Characters")]
    public Coroutine dialogCoroutine;

    [Header("Logic Check")]
    public int currentMemSlot = 2;
    public int maxMemSlot = 2;

    [Header("Virtual Cameras")]
    [SerializeField] CinemachineCamera followCamera;
    [SerializeField] CinemachineCamera jcCamera;

    private void findStuff()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        lastSpawnPoint = player.transform.position;
    }
}
