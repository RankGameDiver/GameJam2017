﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    public GameObject backGround;
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
                if (backGround.transform.position.y <= -17.0f)
                {
                    backGround.transform.position = new Vector2(0, 27.4f);
                    pos = 1;
                    isMoving = false;
                }
                backGround.transform.Translate(Vector2.down * 4 * Time.deltaTime);
                break;
            case 1:
                if (backGround.transform.position.y <= 5.8f)
                {
                    backGround.transform.position = new Vector2(0, 5.8f);
                    pos = 0;
                    isMoving = false;
                }
                backGround.transform.Translate(Vector2.down * 4 * Time.deltaTime);
                break;
        }
    }
}
