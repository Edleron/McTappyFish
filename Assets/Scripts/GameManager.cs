using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver;

    public UIManager _uiManager;

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }

    private void Start()
    {
        _uiManager.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameOver = false;
    }

    public void GameOver()
    {
        _uiManager.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        _uiManager.panelToScore();
        gameOver = true;
    }
}
