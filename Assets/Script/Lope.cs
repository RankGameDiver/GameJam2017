using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lope : MonoBehaviour
{
    public GameObject lope;
    public bool isMoving = false;
    public int pos; // 0이면 화면에 보이는 위치, 1이면 화면에 안보이는 위치
    public int kind;
    public bool lopeAct = false;

    void Update()
    {
        if (isMoving && !lopeAct)
            MoveBackGround();
    }

    private void MoveBackGround()
    {
        switch (pos)
        {
            case 0:
                if (lope.transform.position.y <= -15.8f)
                {
                    lope.transform.position = new Vector3(lope.transform.position.x, 28.6f, 0);
                    pos = 1;
                    isMoving = false;
                }

                if (lopeAct)
                {
                    if (lope.transform.position.y <= -7.97f)
                        lope.transform.Translate(Vector2.down * 4 * Time.deltaTime);
                }
                else
                    lope.transform.Translate(Vector2.down * 4 * Time.deltaTime);
                break;
            case 1:
                if (lope.transform.position.y <= 7.0f)
                {
                    lope.transform.position = new Vector3(lope.transform.position.x, 7.0f, -1);
                    pos = 0;
                    isMoving = false;
                }

                if (lopeAct)
                {
                    if (lope.transform.position.y <= 13.56f)
                        lope.transform.Translate(Vector2.down * 4 * Time.deltaTime);
                }
                else
                    lope.transform.Translate(Vector2.down * 4 * Time.deltaTime);
                break;
        }
    }
}
