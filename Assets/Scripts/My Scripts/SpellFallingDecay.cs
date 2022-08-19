using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFallingDecay : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject decayObj;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.down * 10;
    }
    private void Update()
    {
        if (rb.velocity.y == 0)
        {
            Decay();
        }
    }
    private void FixedUpdate()
    {
        
        rb.velocity = Vector3.down * 10;

        
    }

    

    void Decay()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(decayObj, newPos, Quaternion.identity);
        Destroy(gameObject);
    }
}
