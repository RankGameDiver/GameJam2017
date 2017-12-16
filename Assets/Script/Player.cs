using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Vector2 playerPos;
    private Touch touch;

    void Start()
    {
        playerPos = new Vector2(0,0);
    } 

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭시 실행
        {
            Debug.Log("mouse Click");
        }
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                touch = Input.GetTouch(i);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        Debug.Log("touch Began");
                        break;
                    case TouchPhase.Ended:
                        Debug.Log("touch End");
                        break;
                    case TouchPhase.Canceled:
                        Debug.Log("touch Cancel");
                        break;
                    case TouchPhase.Moved:
                        Debug.Log("touch Move");
                        break;
                    case TouchPhase.Stationary:
                        Debug.Log("touch Stationary");
                        break;
                }
            }
        }

	}
}
