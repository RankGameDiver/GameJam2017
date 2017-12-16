using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public GameObject prefabsObj;
    public GameObject balls;
    private float yPos;
    private float rotate;
    private float tempTime;
    private float maxTime;

    void Start()
    {
        maxTime = 3.0f;
    }

    void Update()
    {
        yPos = balls.transform.position.y;
        balls.transform.position = new Vector2(balls.transform.position.x, yPos - 0.1f);
        rotate = balls.transform.rotation.z;
        balls.transform.Rotate(0, 0, rotate + 1.5f, 0);

        tempTime += Time.deltaTime;
        if (tempTime > maxTime)
        {
            Destroy(prefabsObj);
        }
    }
}
