using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    [SerializeField] int scorePonit = 10;

    public GameObject scorePanel;

    void Start()
    {
        scorePonit = 0;
        scoreText.text = "0";
    }

    public void addToScore()
    {
        if (GameManager.gameOver == false)
        {
            scorePonit++;
            scoreText.text = scorePonit.ToString();
        }

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
