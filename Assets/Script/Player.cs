using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject player;
    public GameObject playerImg;
    public BackGround[] backGround;
    public LopeManager lopeManager;
    public Lope[] lope;
    private Touch touch;
    private bool isMoving; // 움직이는 중이면 true
    private bool startPos; // 시작 위치에 있으면 true
    private bool direct; // true = 왼쪽, false = 오른쪽
    private float rotate; // 상어 회전
    private int hp;
    
    void Start()
    {
        startPos = true;
        isMoving = false;
    }

    void Update()
    {
        StartCoroutine(Move());
        StartCoroutine(RotatePlayer());
        if (!isMoving)
            StartCoroutine(SetStart());
    }

    public void LeftButton()
    {
        direct = true;
        isMoving = true;
        startPos = false;
    }

    public void RightButton()
    {
        direct = false;
        isMoving = true;
        startPos = false;
    }

    IEnumerator Move()
    {
        while (isMoving)
        {
            lopeManager.SelectLope();
            if (direct)
            {
                if (player.transform.position.x >= -3.0f)
                    player.transform.Translate(Vector2.left * 0.1f);

                if (player.transform.position.y <= 1.0f)
                    player.transform.Translate(Vector2.up * 0.1f);
                else
                {
                    isMoving = false;
                    //Debug.Log("StopMoving");
                    backGround[0].isMoving = true;
                    backGround[1].isMoving = true;
                    lope[0].isMoving = true;
                    lope[1].isMoving = true;
                    lope[2].isMoving = true;
                    lope[3].isMoving = true;
                }
            }
            else if (!direct)
            {
                if (player.transform.position.x <= 3.0f)
                    player.transform.Translate(Vector2.right * 0.1f);

                if (player.transform.position.y <= 1.0f)
                    player.transform.Translate(Vector2.up * 0.1f);
                else
                {
                    isMoving = false;
                    //Debug.Log("StopMoving");
                    backGround[0].isMoving = true;
                    backGround[1].isMoving = true;
                    lope[0].isMoving = true;
                    lope[1].isMoving = true;
                    lope[2].isMoving = true;
                    lope[3].isMoving = true;
                }
            }

            yield break;
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
                playerImg.transform.rotation = new Quaternion(0, 0, 0, 0);
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
