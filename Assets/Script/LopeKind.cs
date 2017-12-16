using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LopeKind : MonoBehaviour
{
    public List<Lope> S_LopeList = new List<Lope>();
    private int maxLopes;
    public int randomLope;

    void Start()
    {
        maxLopes = 2;
        randomLope = Random.Range(0, maxLopes);
    }
}
