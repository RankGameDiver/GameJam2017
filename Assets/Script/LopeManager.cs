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
    private int kind;
    private bool isMoving;

    void Start()
    {
        maxLopes = 9;
        kind = -1;
        isMoving = false;
    }

    void Update()
    {

    }

    public void SelectLope()
    {
        //int rTemp = Random.Range(0, maxLopes);
        int rTemp = 1;
        Debug.Log("rTemp = " + rTemp);
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
                    kind = 0;
                    i += 4;
                }
                else
                {
                    int temp = Random.Range(0, maxLopes);
                    Debug.Log("temp = " + temp);
                    if (temp <= 1)
                        temp += 2;

                    if (temp <= 8 && temp >= 6)
                    {
                        lopeArr[i].GetComponent<SpriteRenderer>().sprite = lopeImg[6];
                        lopeArr[i].GetComponent<Lope>().kind = 6;
                        kind = 6;
                    }
                    else
                    {
                        lopeArr[i].GetComponent<SpriteRenderer>().sprite = lopeImg[temp];
                        lopeArr[i].GetComponent<Lope>().kind = temp;
                        kind = temp;
                    }
                }
            }
        }
        StartCoroutine(LopeEvent());
    }

    IEnumerator LopeEvent()
    {
        isMoving = true;
        while (isMoving)
        {

            switch (kind)
            {
                case 0: // 할머니
                    eventObj[0].transform.position = new Vector2(10.0f, -3.0f);
                    if (eventObj[0].transform.position.x <= 3.0f)
                    {
                        if (eventObj[0].transform.position.y >= 7.0f)
                        {
                            eventObj[0].transform.position = new Vector2(10.0f, -3.0f);
                            isMoving = false;
                        }
                        else
                            eventObj[0].transform.Translate(Vector2.up * 0.2f);
                    }
                    else
                        eventObj[0].transform.Translate(Vector2.left * 0.05f);
                    break;
                case 1:
                    isMoving = false;
                    break;
                case 2:
                    isMoving = false;
                    break;
                case 3:
                    isMoving = false;
                    break;
                case 4:
                    isMoving = false;
                    break;
                case 5:
                    isMoving = false;
                    break;
                case 6:
                    isMoving = false;
                    break;
                case 7:
                    isMoving = false;
                    break;
                case 8:
                    isMoving = false;
                    break;
                case 9:
                    isMoving = false;
                    break;
            }
        }
        yield break;
    }


}
