using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamaManager : MonoBehaviour
{
    public GameObject pauseScreen;
    // add score keeping here

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
	}
}
