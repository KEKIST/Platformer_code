using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private MoveDirection dir;
    [SerializeField] private float moveOffset;
    private Vector3 pos1, pos2;


    private void Start()
    {
        pos1 = transform.position;
        pos2 = transform.position;
        switch (dir)
        {
            case MoveDirection.Right:
                pos1.x -= moveOffset;
                pos2.x += moveOffset;
                break;
            case MoveDirection.Top:
                pos1.y -= moveOffset;
                pos2.y += moveOffset;
                break;
        }
    }

    private void FixedUpdate()
    {
        Vector3 newpos = transform.position;
        switch (dir)
        {
            case MoveDirection.Right:
                newpos.x += speed * Time.deltaTime;
                break;
            case MoveDirection.Top:
                newpos.y += speed * Time.deltaTime;
                break;

        }
        transform.position = newpos;
        switch (dir)
        {
            case MoveDirection.Right:
                if (transform.position.x <= pos1.x || transform.position.x >= pos2.x)
                {
                    speed *= -1;
                }
                break;
            case MoveDirection.Top:
                if (transform.position.y <= pos1.y || transform.position.y >= pos2.y)
                {
                    speed *= -1;
                }
                break;

        }

    }

    
}
public enum MoveDirection
{
    Right, 
    Top
}