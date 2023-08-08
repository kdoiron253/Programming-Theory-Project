using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamaManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    // add score keeping here
    public TextMeshProUGUI scoreText;
    private int scoreCounter;
    private int counter = 0;

	private void Start()
	{
		gameOverScreen.gameObject.SetActive(false);
        scoreCounter = 0;
	}

	private void Update()
	{
		if (ObstacleRegularWall.isHit) {
            GameOver();
        }
	}

	public void ResumeGame()
    {
        // hide the pause screen and set game back to active
        pauseScreen.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall")) {
            other.gameObject.SetActive(false);
        }

        scoreCounter ++;
        scoreText.SetText("Score: " + scoreCounter);
        
    }

	// ABSTRACTION
	private void GameOver()
    {
		gameOverScreen.gameObject.SetActive(true);
	}

    public void RestartGame()
    {
        ObstacleRegularWall.RestartGame();
		SceneManager.LoadScene(1, LoadSceneMode.Single);
	}

    public void MainMenu()
    {
		SceneManager.LoadScene(0);
	}
}
