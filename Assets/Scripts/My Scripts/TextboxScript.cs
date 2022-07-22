using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextboxScript : MonoBehaviour
{
    public TMPro.TMP_Text text;
    public GameObject textbox;
    public TextAsset script;

    public MovementMage move;

    private bool textActive;

    private bool controlsActive;
    private List<string> scriptList;
    private int listNum;
    public bool textOnStart = false;

    //Interactable Icon
    public GameObject icon;

    private void Start()
    {
        textActive = false;
        controlsActive = false;
        listNum = 0;
        if (icon != null)
        {
            icon.SetActive(false);
        }
        fileToList();

        if (textOnStart)
        {
            textbox.SetActive(true);
            move.disable = true;
            textActive = true;
            text.text = scriptList[0];
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit") && (controlsActive || textOnStart))
        {
            if (!textActive)
            {
                textbox.SetActive(true);
                move.disable = true;
                textActive = true;
                text.text = scriptList[0];
            }
            else
            {
                nextScreen();
            }
        }
    }

    private void nextScreen()
    {
        listNum++;
        if (listNum >= scriptList.Count)
        {
            textbox.SetActive(false);
            textActive = false;
            move.disable = false;
            listNum = 0;

            if (textOnStart)
            {
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            text.text = scriptList[listNum];
        }
    }
    private void fileToList()
    {
        scriptList = new List<string>(script.text.Split("/e"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (icon != null && collision.gameObject.tag == "Player")
        {
            icon.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            controlsActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            controlsActive = false;
            if (icon != null)
            {
                icon.SetActive(false);
            }
        }
    }
}
