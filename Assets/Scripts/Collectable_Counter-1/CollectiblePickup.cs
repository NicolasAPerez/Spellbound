using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickup : MonoBehaviour
{
    public Sprite empty;
    private SpriteRenderer sr;
    private bool collected;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        collected = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collected)
        {
            CollectibleText.numCollectibles += 5;
            sr.sprite = empty;
            collected = true;
        }
    }
}
