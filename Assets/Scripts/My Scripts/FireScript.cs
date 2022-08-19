using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    private void Awake()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, .5f);
        foreach (Collider2D c in col)
        {
            if (c.tag == "Flammable")
            {
                Animator a = c.GetComponent<Animator>();
                if (a != null)
                {
                    a.SetBool("OnFire", true);
                }
                else
                {
                    Destroy(c.gameObject);
                }
            }
            else if (c.tag == "Enemy")
            {
                Destroy(c.gameObject);
            }
        }
    }

    
}
