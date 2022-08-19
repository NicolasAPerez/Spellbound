using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private MagicScript Magic;
    private MovementMage Movement;
    private MageHealth Health;
    public Vector2 respawnLoc;
    public GameObject camera;
    private SpriteRenderer rend;
    private Rigidbody2D rb;
    private Animator animator;
    private float invulTimer;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Health = GetComponent<MageHealth>();
        Magic = GetComponent<MagicScript>();
        Movement = GetComponent<MovementMage>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentsInChildren<Animator>()[0];

        if (TranferBetweenScenes.playerStartSleeping)
        {
            animator.SetBool("sleeping", true);
            Movement.disable = true;
            TranferBetweenScenes.playerStartSleeping = false;
        }

    }

    


    void respawn()
    {
        this.transform.position = respawnLoc;
        rb.velocity = Vector2.zero;
        camera.transform.position = respawnLoc;

        for (int i = 0; i < 5; i++)
        {
            Health.heal();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && Time.time > invulTimer)
        {
            if (!Health.hurt())
            {
                respawn();
            }
            else
            {
                invulTimer = Time.time + 1f;
            }
            
        }
    }

}
