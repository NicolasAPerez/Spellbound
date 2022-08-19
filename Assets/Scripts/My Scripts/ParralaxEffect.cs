using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxEffect : MonoBehaviour
{
    public bool xParralax, yParralax;
    public Vector2 multipliers;
    public GameObject relativeTo;

    private Rigidbody2D rigidbody;

    private bool hasRigidBody;
    private Rigidbody2D relativeRigidbody;
    private Vector3 previousRelativeBodyPos, tempPosHolder;
    private bool relativeBodyIsMovingX, relativeBodyIsMovingY;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        relativeRigidbody = relativeTo.GetComponent<Rigidbody2D>();
        hasRigidBody = relativeRigidbody != null;
        
    }
    private void Update()
    {
        
    }
    


    void FixedUpdate()
    {
        
        if (hasRigidBody)
        {
            
            float xVel = (xParralax && relativeBodyIsMovingX) ? relativeRigidbody.velocity.x * -multipliers.x : 0;
            float yVel = (yParralax && relativeBodyIsMovingY) ? relativeRigidbody.velocity.y * -multipliers.y : 0;
            rigidbody.velocity = new Vector2(xVel, yVel);

            if (!xParralax || !yParralax)
            {
                float xPos = (!xParralax) ? relativeRigidbody.position.x : rigidbody.position.x;
                float yPos = (!yParralax) ? relativeRigidbody.position.y : rigidbody.position.y;
                rigidbody.position = new Vector2(xPos, yPos);
            }
        }
    }

    private void olderImpUpdate()
    {
        relativeBodyIsMovingX = System.Math.Abs(relativeRigidbody.velocity.x) > 1;
        //relativeBodyIsMovingY = relativeRigidbody.velocity.y > 1;
        relativeBodyIsMovingY = true;
        previousRelativeBodyPos = tempPosHolder;
        tempPosHolder = relativeRigidbody.position;
    }
}
