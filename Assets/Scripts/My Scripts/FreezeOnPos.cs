using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeOnPos : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 positionToFreeze;
    public bool freezeAtX, freezeAtY;
    private bool greaterThanX, greaterThanY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        greaterThanX = rb.position.x > positionToFreeze.x;
        greaterThanY = rb.position.y > positionToFreeze.y;
    }

    private void Update()
    {
        bool xFreeze = (greaterThanX != rb.position.x > positionToFreeze.x) && freezeAtX;
        bool yFreeze = (greaterThanY != rb.position.y > positionToFreeze.y) && freezeAtY;

        RigidbodyConstraints2D posCons = 0;
        posCons |= (xFreeze) ? RigidbodyConstraints2D.FreezePositionX : 0;
        posCons |= (yFreeze) ? RigidbodyConstraints2D.FreezePositionY : 0;
        posCons |= RigidbodyConstraints2D.FreezeRotation;
        rb.constraints = posCons;
    }
}
