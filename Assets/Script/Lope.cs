using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lope : MonoBehaviour
{
    public int ID;
    public string Name;

    public Lope(int id, string name)
    {
        ID = id;
        Name = name;
    }

    public GameObject lope;
    public bool isMoving = false;
    public int pos; // 0이면 화면에 보이는 위치, 1이면 화면에 안보이는 위치

    void Update()
    {
        if (isMoving)
            MoveBackGround();
    }

    private void MoveBackGround()
    {
        switch (pos)
        {
            case 0:
                if (lope.transform.position.y <= -15.8f)
                {
                    lope.transform.position = new Vector2(lope.transform.position.x, 28.6f);
                    pos = 1;
                    isMoving = false;
                }
                lope.transform.Translate(Vector2.down * 4 * Time.deltaTime);
                break;
            case 1:
                if (lope.transform.position.y <= 7.0f)
                {
                    lope.transform.position = new Vector2(lope.transform.position.x, 7.0f);
                    pos = 0;
                    isMoving = false;
                }
                lope.transform.Translate(Vector2.down * 4 * Time.deltaTime);
                break;
        }
    }
}
