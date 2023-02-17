using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private int scorePonit = 10;
    private int highPonit = 0;
    public List<TextMeshProUGUI> textList = new List<TextMeshProUGUI>();
    public List<Sprite> medalSprite = new List<Sprite>();
    public List<Image> imageSprite = new List<Image>();

    void Start()
    {
        scorePonit = 0;
        imageSprite[0].gameObject.SetActive(false);
        textList[0].text = scorePonit.ToString();
        textList[1].text = scorePonit.ToString();
        textList[2].text = highPonit.ToString();
        highPonit = PlayerPrefs.GetInt("highScore");
        this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    public void scoreViewer()
    {
        if (GameManager.isGameOver == false)
        {
            scorePonit++;
            madelViewer();
            textList[0].text = scorePonit.ToString();
            textList[1].text = scorePonit.ToString();
        }
    }

    public void startedViewer(bool value)
    {
        this.gameObject.transform.GetChild(2).gameObject.SetActive(value);
    }

    public void finishedViewer()
    {
        //Debug.Log(scorePonit + " : " + highPonit);
        if (scorePonit > highPonit)
        {
            imageSprite[0].gameObject.SetActive(true);
            highPonit = scorePonit;
            PlayerPrefs.SetInt("highScore", highPonit);
        }
        textList[2].text = PlayerPrefs.GetInt("highScore").ToString();
        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    private void madelViewer()
    {
        if (scorePonit > 0 && scorePonit <= 2)
        {
            imageSprite[1].sprite = medalSprite[0];
        }

        if (scorePonit > 2 && scorePonit <= 4)
        {
            imageSprite[1].sprite = medalSprite[1];
        }

        if (scorePonit > 4 && scorePonit <= 6)
        {
            imageSprite[1].sprite = medalSprite[2];
        }

        if (scorePonit > 6)
        {
            imageSprite[1].sprite = medalSprite[3];
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
