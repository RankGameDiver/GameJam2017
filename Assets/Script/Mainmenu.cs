using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour {

    public AudioClip touchSound;

	public void PlayGame()
    {
        AudioSource.PlayClipAtPoint(touchSound, new Vector3(0, 0, 0));
        SceneManager.LoadScene("characters");

    }

    public void MainmenuGame()
    {
        AudioSource.PlayClipAtPoint(touchSound, new Vector3(0, 0, 0));
        SceneManager.LoadScene("Menu");
    }
    public void StartGame()
    {
        AudioSource.PlayClipAtPoint(touchSound, new Vector3(0, 0, 0));
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        AudioSource.PlayClipAtPoint(touchSound, new Vector3(0, 0, 0));
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
