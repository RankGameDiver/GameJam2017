using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene("characters");

    }

    public void MainmenuGame()
    {
        SceneManager.LoadScene("Menu");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
