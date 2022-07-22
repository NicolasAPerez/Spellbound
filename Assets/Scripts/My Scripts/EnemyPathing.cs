using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    public Vector2[] patrolPoints;
    public float speed;
    private int currentPoint;
    private SpriteRenderer spriteRenderer;
    private bool travelling;
    public float timeStoppedAtPoint;
    private float timeSaved;
    private int patrolPointsSize;


    private void Start()
    {
        patrolPointsSize = patrolPoints.Length;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
       if (travelling)
       {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(patrolPoints[currentPoint].x, patrolPoints[currentPoint].y, transform.position.z), speed);
            if (transform.position == new Vector3(patrolPoints[currentPoint].x, patrolPoints[currentPoint].y, transform.position.z))
            {
                travelling = false;
                timeSaved = Time.time + timeStoppedAtPoint;
                incrementCurrentPoint();
                setFacing();
            }
       }
       else
       {
            if (Time.time > timeSaved)
            {
                travelling = true;
            }
       }

    }

    private void incrementCurrentPoint()
    {
        currentPoint = (currentPoint >= patrolPointsSize - 1) ? 0 : currentPoint + 1;
    }

    private void setFacing()
    {
        if (transform.position.x < patrolPoints[currentPoint].x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
