using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] Oleg;
    private int ceurretTarget;

    void Start()
    {
        ceurretTarget = -1;
        if (Oleg.Length >0)
        {
            ceurretTarget = 0;
        }
    }

    void Update()
    {
        if (ceurretTarget > -1)
        {
            transform.position += (Oleg[ceurretTarget].position - transform.position).normalized * speed * Time.deltaTime;
        }
        if ((transform.position - Oleg[ceurretTarget].position).magnitude <= .2f)
        {
            ceurretTarget++;
        }
        if(ceurretTarget >= Oleg.Length)
        {
            ceurretTarget = 0;
        }
    }
}
