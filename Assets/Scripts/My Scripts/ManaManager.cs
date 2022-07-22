using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaManager : MonoBehaviour
{
    public int manaLevel;
    public ManaBarMask mask;

    public SpriteRenderer manaBackground;
    public SpriteRenderer manaOverlay;

    private int manaRegenTimer;

    // Start is called before the first frame update
    void Start()
    {
        manaLevel = 100;
    }

    // Update is called once per frame
    void Update()
    {
        mask.setMana(manaLevel);
        if (mask.getCurrentMana() == 100)
        {
            toggleVisibility(false);
        }
        else
        {
            toggleVisibility(true);
        }

    }
    private void FixedUpdate()
    {
        if (manaRegenTimer == 5)
        {
            manaLevel = (manaLevel != 100) ? manaLevel + 1 : 100;
            manaRegenTimer = 0;
        
        }
        else
        {
            manaRegenTimer++;
        }
    }
    public bool cast(int manaToCast, int recoverTime)
    {
        if (manaToCast > manaLevel)
        {
            return false;
        }
        else
        {
            manaLevel -= manaToCast;
            mask.forceSetMana(manaLevel);
            manaRegenTimer = -recoverTime;
            return true;
        }
    }

    public void toggleVisibility(bool toggle)
    {
        manaBackground.enabled = toggle;
        manaOverlay.enabled = toggle;
    }
}
