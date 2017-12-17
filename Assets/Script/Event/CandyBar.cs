using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyBar : MonoBehaviour
{
    public Sprite[] candys;
    public BoxCollider2D col;
    public int health;

    void Start()
    {
        health = 15;
    }

    void Update()
    {
        if (health > 10)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = candys[0];
        }
        else if (health > 5)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = candys[1];
        }
        else if (health > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = candys[2];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
    }

    public void Act()
    {
        col.isTrigger = false;
    }
}
