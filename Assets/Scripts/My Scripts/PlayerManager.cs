using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private MagicScript Magic;
    private MovementMage Movement;
    private MageHealth Health;
    public Vector2 respawnLoc;
    private SpriteRenderer rend;
    private Rigidbody2D rb;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Health = GetComponent<MageHealth>();
        Magic = GetComponent<MagicScript>();
        Movement = GetComponent<MovementMage>();
        rb = GetComponent<Rigidbody2D>();

    }

    


    void respawn()
    {
        this.transform.position = respawnLoc;
        rb.velocity = Vector2.zero;

        for (int i = 0; i < 5; i++)
        {
            Health.heal();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!Health.hurt())
            {
                respawn();
            }
            
        }
    }

}
