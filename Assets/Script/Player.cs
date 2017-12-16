﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject player;
    public GameObject playerImg;
    public BackGround[] backGround;
    public Lope[] lope;
    private GameObject touchLope;
    private Vector2 playerPos;
    private Touch touch;
    private bool isMoving; // 움직이는 중이면 true
    private bool startPos; // 시작 위치에 있으면 true
    private float rotate; // 상어 회전
    private int hp;

    public List<Lope> lopeList = new List<Lope>();
    
    void Start()
    {
        startPos = true;
        isMoving = false;
        touchLope = null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭시 실행
        {
            playerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (startPos)
                CheckLope(playerPos);
        }

        if (Input.touchCount > 0) // 터치시 실행
        {
            touch = Input.GetTouch(0);
            playerPos = Camera.main.ScreenToViewportPoint(touch.position);
            if (startPos)
                CheckLope(playerPos);
        }

        StartCoroutine(Move());
        StartCoroutine(RotatePlayer());
        if (!isMoving)
            StartCoroutine(SetStart());
    }

    IEnumerator Move()
    {
        while (isMoving)
        {
            if (player.transform.position.x >= playerPos.x - 0.05f && player.transform.position.x <= playerPos.x + 0.05f)
            {
                if (player.transform.position.y <= 1.0f)
                    player.transform.Translate(Vector2.up * 0.1f);
                else
                {
                    isMoving = false;
                    Debug.Log("StopMoving");
                    backGround[0].isMoving = true;
                    backGround[1].isMoving = true;
                    lope[0].isMoving = true;
                    lope[1].isMoving = true;
                    lope[2].isMoving = true;
                    lope[3].isMoving = true;
                }
            }
            else if (player.transform.position.x > playerPos.x)
            {
                if (player.transform.position.x >= -3.0f)
                    player.transform.Translate(Vector2.left * 0.1f);
            }
            else if (player.transform.position.x < playerPos.x)
            {
                if (player.transform.position.x <= 3.0f)
                    player.transform.Translate(Vector2.right * 0.1f);
            }

            yield break;
        }
    }

    private void CheckLope(Vector2 pos)
    {
        Ray2D ray = new Ray2D(pos, Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Lope")
            {
                touchLope = hit.collider.gameObject;
                Debug.Log(touchLope);
                isMoving = true;
                startPos = false;
            }
        }
        else
        {
            touchLope = null;
        }
    }

    IEnumerator SetStart()
    {
        for (int i = 0; i < 2; i++)
        {
            if (backGround[i].transform.position.y > 5.8f && backGround[i].transform.position.y <= 11)
            {
                if (player.transform.position.x >= 0.0f)
                    player.transform.Translate(Vector2.left * 0.1f);
                if (player.transform.position.x <= 0.0f)
                    player.transform.Translate(Vector2.right * 0.1f);
                player.transform.position = new Vector2(player.transform.position.x, backGround[i].transform.position.y - 9.6f);
            }
        }
        startPos = true;
        yield break;
    }

    IEnumerator RotatePlayer()
    {
        while (player.transform.position.x <= -0.6f || player.transform.position.x >= 0.5f)
        {
            playerImg.transform.Rotate(Vector3.forward * Time.deltaTime * 5 * 25);
            yield break;
        }
    }

}
