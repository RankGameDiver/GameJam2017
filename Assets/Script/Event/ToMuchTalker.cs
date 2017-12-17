using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMuchTalker : MonoBehaviour
{
    public GameObject[] talking;
    public GameObject toMuchTalker;
    private float maxTime;
    private float tempTime;
    private int maxCount;
    private int count;
    public int delCount;

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
        if (tempTime >= maxTime)
        {
            talking[count].SetActive(true);
            if (maxCount > count)
                count += 1;
            else { }
            tempTime = 0;
        }

        if (delCount >= 5)
            Destroy(gameObject);
    }

    public void DelCount()
    {
        delCount++;
    }
}
