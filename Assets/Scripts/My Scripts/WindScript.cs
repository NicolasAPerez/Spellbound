using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    List<Rigidbody2D> objectsInside = new List<Rigidbody2D>();

    public float endTime;

    public float windForce;

    private void Awake()
    {
        endTime = Time.time + 5;
    }

    private void Update()
    {
        if (Time.time >= endTime)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        foreach (Rigidbody2D obj in objectsInside)
        {
            if (obj != null)
            {
                obj.AddForce(windForce * Vector2.up);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D temp = collision.gameObject.GetComponent<Rigidbody2D>();


        if (!objectsInside.Contains(temp))
        {
            objectsInside.Add(temp);
            temp.gravityScale = 0;
            temp.velocity = new Vector2(temp.velocity.x, Mathf.Clamp(temp.velocity.y, -1, 1));
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {

        Rigidbody2D temp = collision.gameObject.GetComponent<Rigidbody2D>();

        
        objectsInside.Remove(temp);
        temp.gravityScale = 1.5f;
        
    }
}
