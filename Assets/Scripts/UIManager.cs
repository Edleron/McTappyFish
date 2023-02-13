using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private int scorePonit = 10;
    private int highPonit = 0;
    public GameObject scorePanel;
    public GameObject readyPanel;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI panelScore;
    public TextMeshProUGUI panelHigh;
    public GameObject newHighImage;
    public List<Sprite> medalSprite = new List<Sprite>();
    public Image medalImage;

    void Start()
    {
        scorePonit = 0;
        newHighImage.SetActive(false);
        scoreText.text = scorePonit.ToString();
        panelScore.text = scorePonit.ToString();
        panelHigh.text = highPonit.ToString();
        highPonit = PlayerPrefs.GetInt("highScore");
    }

    public void addToScore()
    {
        if (GameManager.gameOver == false)
        {
            scorePonit++;
            scoreText.text = scorePonit.ToString();
            panelScore.text = scorePonit.ToString();
            setMadelState();
        }
    }

    public void panelToScore()
    {
        Debug.Log(scorePonit + " : " + highPonit);
        if (scorePonit > highPonit)
        {
            newHighImage.SetActive(true);
            highPonit = scorePonit;
            PlayerPrefs.SetInt("highScore", highPonit);
        }
        panelHigh.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void readyPanelState(bool value)
    {
        readyPanel.SetActive(value);
    }

    private void setMadelState()
    {
        if (scorePonit > 0 && scorePonit <= 2)
        {
            medalImage.sprite = medalSprite[0];
        }

        if (scorePonit > 2 && scorePonit <= 4)
        {
            medalImage.sprite = medalSprite[1];
        }

        if (scorePonit > 4 && scorePonit <= 6)
        {
            medalImage.sprite = medalSprite[2];
        }

        if (scorePonit > 6)
        {
            medalImage.sprite = medalSprite[3];
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
