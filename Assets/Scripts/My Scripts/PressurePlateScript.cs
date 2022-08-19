using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    private int numPress;
    private bool pressed;
    public bool stayPressed;
    public bool onlyPlayer;
    private SpriteRenderer spriteRenderer;

    public Sprite unPressedSprite;
    public Sprite pressedSprite;
    public GameObject[] affectedObj;
    public GameObject[] affectedObjStartFaded;

    private void Start()
    {
        FadeObj(0.5f,false);
        spriteRenderer = GetComponent<SpriteRenderer>();
        numPress = 0;
    }

    void FadeObj(float opacity, bool firstGroup)
    {
        GameObject[] toFade = (firstGroup)? affectedObj : affectedObjStartFaded;

        foreach (GameObject obj in toFade)
        {
            BoxCollider2D bc = obj.GetComponent<BoxCollider2D>();
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();

            if (bc != null)
            {
                bc.enabled = false;
            }
            if (sr != null)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, opacity);
            }
        }
    }

    void UnfadeObj(bool firstGroup)
    {
        GameObject[] toUnfade = (firstGroup) ? affectedObj : affectedObjStartFaded;

        foreach (GameObject obj in toUnfade)
        {
            BoxCollider2D bc = obj.GetComponent<BoxCollider2D>();
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();

            if (bc != null)
            {
                bc.enabled = true;
            }
            if (sr != null)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((onlyPlayer && collision.tag == "Player") || !onlyPlayer)
        {
            numPress++;
            if (numPress >= 1)
            {
                spriteRenderer.sprite = pressedSprite;
                pressed = true;
                FadeObj(0.5f, true);
                UnfadeObj(false);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((onlyPlayer && collision.tag == "Player") || !onlyPlayer)
        {

            numPress--;
            if (numPress <= 0 && !stayPressed)
            {
                spriteRenderer.sprite = unPressedSprite;
                pressed = false;
                UnfadeObj(true);
                FadeObj(0.5f, false);
            }
        }
    }
}
