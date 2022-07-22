using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUIManager : MonoBehaviour
{
    public Sprite[] healthSprites = new Sprite[6];
    public SpriteRenderer rend;
    public int healthCount;
    private bool currentlyUpdating; 
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        healthCount = 5;
    }

    public bool incrementHealth()
    {
        if (healthCount < 5)
        {
            healthCount++;
            rend.sprite = healthSprites[healthCount];
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool deincrementHealth()
    {
        if (healthCount > 0)
        {
            healthCount--;
            rend.sprite = healthSprites[healthCount];
            return true;
        }
        else
        {
            return false;
        }
    }
    
    //For later use in smooth health transtions
    /*
    bool setHealth(int health)
    {

    }
    */
}
