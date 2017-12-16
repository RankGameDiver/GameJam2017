using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject player;
    [SerializeField]
    private GameObject touchLope;
    private Vector2 playerPos;
    private Touch touch;
    private bool isMoving;

    public List<Lope> lopeList = new List<Lope>();
    
    void Start()
    {
        isMoving = false;
        touchLope = null;
    }

	void Update ()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭시 실행
        {
            Debug.Log("mouse Click");
            playerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CheckLope(playerPos);
        }

        if (Input.touchCount > 0) // 터치시 실행
        {
            touch = Input.GetTouch(0);
            playerPos = Camera.main.ScreenToViewportPoint(touch.position);
            CheckLope(playerPos);
        }

        if (isMoving)
        {
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        while (isMoving)
        {
            if (player.transform.position.x >= playerPos.x - 0.05f && player.transform.position.x <= playerPos.x + 0.05f)
            {
                if (player.transform.position.y >= playerPos.y - 0.05f && player.transform.position.y <= playerPos.y + 0.05f)
                {
                    isMoving = false;
                }
                else if (player.transform.position.y > playerPos.y)
                {
                    player.transform.Translate(Vector2.down * 0.1f);
                }
                else if (player.transform.position.y < playerPos.y)
                {
                    player.transform.Translate(Vector2.up * 0.1f);
                }
            }
            else if (player.transform.position.x > playerPos.x)
            {
                player.transform.Translate(Vector2.left * 0.1f);
            }
            else if (player.transform.position.x < playerPos.x)
            {
                player.transform.Translate(Vector2.right * 0.1f);
            }

            yield break;
        }
    }

    public void CheckLope(Vector2 pos)
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
            }
        }
        else
        {
            touchLope = null;
        }
    }

}
