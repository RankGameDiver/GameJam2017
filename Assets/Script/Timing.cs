using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timing : MonoBehaviour
{
    public GameObject back;
    public GameObject box;
    public GameObject bar;
    private bool isMoving;
    private bool direct; // true : 왼쪽, false : 오른쪽

    void Start()
    {
        direct = true;
        isMoving = false;
        StartCoroutine(MoveBar());
    }

    IEnumerator MoveBar()
    {
        isMoving = true;
        while (isMoving)
        {
            if (direct)
            {
                if (bar.transform.position.x <= 3.0f)
                { isMoving = false;
                    Debug.Log(isMoving); }
                else
                    bar.transform.Translate(Vector2.left * 0.01f);
            }
            else if (!direct)
            {
                if (bar.transform.position.x >= 3.0f)
                { isMoving = false;
                    Debug.Log(isMoving);
                }
                else
                    bar.transform.Translate(Vector2.right * 0.01f);
            }
            yield break;
        }
    }
}
