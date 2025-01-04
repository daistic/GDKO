using System;
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

    [Header("Characters")]
    public Coroutine dialogCoroutine;

    private void findStuff()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }


}
