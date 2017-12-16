using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelect : MonoBehaviour {
    public GameObject[] characters;
    public int kind;
    private int maxChar; // 최대 캐릭터 수

    void Start()
    {
        kind = 0;
        maxChar = 9;
    }

    public void Game()
    {
        for (int i = 0; i < maxChar; i++)
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

    public void rightButton()
    {
        if (kind >= maxChar)
        { }
        else
            kind++;
        Game();
    }

    public void leftButton()
    {
        if (kind <= 0)
        { }
        else
            kind--;
        Game();
    }
}
