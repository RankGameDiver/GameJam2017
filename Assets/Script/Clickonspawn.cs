using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// © 2017 TheFlyingKeyboard
// theflyingkeyboard.net
public class Clickonspawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    private float maxTime;
    private float tempTime;
    // Use this for initialization
    void Start()
    {
        maxTime = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        tempTime += Time.deltaTime;
        if (tempTime >= maxTime)
        {
            GameObject objectInstance = Instantiate(objectToSpawn, new Vector3(Random.Range(-8, 8), 6, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            tempTime = 0;
        }

    }
}