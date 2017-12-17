using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMuchTalker : MonoBehaviour
{
    public GameObject[] talking;
    private float maxTime;
    private float tempTime;
    private int maxCount;
    private int count;

    void Start()
    {
        maxTime = 0.8f;
        tempTime = 0;
        maxCount = 8;
        count = 0;
    }

    void Update()
    {
        tempTime += Time.deltaTime;
        if (tempTime >= maxTime && count < maxCount)
        {
            talking[count].SetActive(true);
            if (maxCount > count)
                count += 1;
            tempTime = 0;
        }
    }
}
