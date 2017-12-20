using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharSelect : MonoBehaviour {
    public GameObject[] characters;
    public int kind;
    private int maxChar; // 최대 캐릭터 수




    void Start()
    {
        kind = 0;
        maxChar = 1;
    }

    public void Game()
    {

        for (int i=0 ; i < maxChar; i++)
        {
            if (i == kind)
                characters[kind].SetActive(true);
            else
            {
                if(characters[i].activeInHierarchy)
                characters[i].SetActive(false);
            }
        }
         
    }

    public void charButton()
    {
        if (kind >= maxChar -1)
        {
            kind = 0;
        }
        else
        {
            kind++;
        }
        Game();
    }
    
}


