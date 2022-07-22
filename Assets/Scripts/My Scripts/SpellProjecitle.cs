using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellProjecitle : MonoBehaviour
{
    private float endTime;
    private Rigidbody2D body;
    public bool leftFace;

    public Spell spellDetails;

    // Start is called before the first frame update
    void Awake()
    {
        endTime = Time.time + spellDetails.spellLifeSpan;
        body = GetComponent<Rigidbody2D>();
        SetAnimatorBool();
        if (leftFace)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= endTime)
        {
            Decay();
        }
        else
        {
            if (!leftFace)
            {
                body.velocity = new Vector2(10, body.velocity.y);
            }
            else
            {
                body.velocity = new Vector2(-10, body.velocity.y);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Collectable")
        {
            Decay();
        }
    }

    void Decay()
    {
        Instantiate(spellDetails.residueOnDecay, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void SetAnimatorBool()
    {
        Animator ani = GetComponent<Animator>();
        string element = spellDetails.spellElement.ToString();

        if (ani != null)
        {
            ani.SetBool(element, true);
        }
    }
}
