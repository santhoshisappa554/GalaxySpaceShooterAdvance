using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] livesimages;
    public Image displaylivesImage;
    public int score;
    public Text scoreText;
    public GameObject GameoverScreen;
    public void UpdateLives(int currentLives)
    {
        displaylivesImage.sprite = livesimages[currentLives];
    }
    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
    public void ShowGameOverScreen()
    {
        GameoverScreen.SetActive(true);
    }
    public void HideGameOverScreen()
    {
        GameoverScreen.SetActive(false);
    }
}
