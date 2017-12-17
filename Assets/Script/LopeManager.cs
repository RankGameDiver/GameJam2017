using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LopeManager : MonoBehaviour
{
    public GameObject[] lopeArr;
    public GameObject[] eventObj;
    public Sprite[] lopeImg;
    public BackGround[] backGround;
    private int maxLopes;
    private int maxEvent;
    private bool isMoving;

    void Start()
    {
        maxLopes = 9;
        maxEvent = 3;
        isMoving = false;
    }

    void Update()
    {

    }

    public void SelectLope()
    {
        int rTemp = Random.Range(0, maxLopes);
        for (int i = 0; i < 4; i++)
        {
            if (lopeArr[i].GetComponent<Lope>().pos == 1)
            {
                if (rTemp <= 1)
                {
                    lopeArr[i].GetComponent<SpriteRenderer>().sprite = lopeImg[0];
                    lopeArr[i].GetComponent<Lope>().kind = 0;
                    lopeArr[i + 1].GetComponent<SpriteRenderer>().sprite = lopeImg[1];
                    lopeArr[i + 1].GetComponent<Lope>().kind = 1;
                    i += 4;
                }
                else
                {
                    int temp = Random.Range(0, maxLopes);
                    if (temp <= 1)
                        temp += 2;

                    if (temp <= 8 && temp >= 6)
                    {
                        lopeArr[i].GetComponent<SpriteRenderer>().sprite = lopeImg[6];
                        lopeArr[i].tag = "activeObj";
                        lopeArr[i].GetComponent<Lope>().kind = 6;
                    }
                    else
                    {
                        lopeArr[i].GetComponent<SpriteRenderer>().sprite = lopeImg[temp];
                        lopeArr[i].GetComponent<Lope>().kind = temp;
                    }
                }
            }
        }
        EventNPC();
    }

    public void EventNPC()
    {
        int randomTemp = Random.Range(0, maxEvent);
        switch (randomTemp)
        {
            case 0:
                Instantiate(eventObj[0]);
                break;
            case 1:
                Instantiate(eventObj[1]);
                break;
            case 2:
                Instantiate(eventObj[2]);
                break;
        }
    }
}
