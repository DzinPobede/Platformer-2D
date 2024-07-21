using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public float playerScore;

    public void Setup(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString() + "Points";
    }
    public void Score()
    {

    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
