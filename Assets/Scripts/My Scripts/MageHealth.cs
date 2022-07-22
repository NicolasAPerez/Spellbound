using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public HealthBarUIManager uIManager;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool heal()
    {
        uIManager.incrementHealth();
        health++;
        return true;
    }
    public bool hurt()
    {
        uIManager.deincrementHealth();
        health--;
        if (health <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
