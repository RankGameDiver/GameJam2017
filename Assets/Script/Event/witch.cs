using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witch : MonoBehaviour {

    public GameObject[] witchs;
    private float maxTime;
    private float tempTime;
    public bool isMoving;

    void Start()
    {
        
    }

    void Update ()
    {
        StartCoroutine(Move());
    }

    public void Act()
    {
        Debug.Log("Act");
        witchs[0].SetActive(false);
        witchs[1].SetActive(true);
        isMoving = true; 
    }

    IEnumerator Move()
    {
        while (isMoving)
        {
            if (witchs[1].transform.position.y <= 7.0f)
            {
                witchs[1].transform.Translate(Vector2.up * 0.2f);
            }
            Destroy(gameObject);
            yield break;
        }
    }
}
