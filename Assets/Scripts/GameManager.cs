using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 camArea;
    public static bool isGameStarted;
    public static bool isGameOver;
    private bool isInitialized = false;
    private UIManager _uiManager;

    private void Awake()
    {
        camArea = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        _uiManager = _uiManager == null ? GameObject.FindGameObjectWithTag("UICanvas").GetComponent<UIManager>() : null;
    }

    private void Start()
    {
        isGameOver = false;
        isInitialized = true;
        isGameStarted = false;
        _uiManager.startedViewer(true);
        FishMovement.scoreState += AddToScore;
        FishMovement.gameStarted += GameStarted;
        FishMovement.gameFinished += GameFinished;
    }

    private void OnEnable()
    {
        if (isInitialized)
        {
            FishMovement.scoreState += AddToScore;
            FishMovement.gameStarted += GameStarted;
            FishMovement.gameFinished += GameFinished;
        }
    }


    private void OnDisable()
    {
        FishMovement.scoreState -= AddToScore;
        FishMovement.gameStarted -= GameStarted;
        FishMovement.gameFinished -= GameFinished;
    }

    private void AddToScore()
    {
        _uiManager.scoreViewer();
        Debug.Log("Event - Delegate Score Test");
    }

    public void GameStarted()
    {
        isGameStarted = true;
        _uiManager.startedViewer(false);
        Debug.Log("Event - Delegate Game Started");
    }

    public void GameFinished()
    {
        isGameOver = true;
        _uiManager.finishedViewer();
        Debug.Log("Event - Delegate Game Finished");
    }
}
