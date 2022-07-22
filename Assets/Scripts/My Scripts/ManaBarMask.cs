using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBarMask : MonoBehaviour
{
    protected int percentMana;
    protected int currentMana;

    // Update is called once per frame
    private void Start()
    {
        currentMana = 0;
    }
    void Update()
    {
        maskUpdate();
    }
    private void FixedUpdate()
    {
        currentMana = (currentMana < percentMana) ? currentMana + 1 : (currentMana > percentMana)? currentMana - 1 : percentMana;
    }

    public void setMana(int mana)
    {
        percentMana = mana;
    }
    public void forceSetMana(int mana)
    {
        currentMana = mana;
    }
    public int getCurrentMana()
    {
        return currentMana;
    }

    public void maskUpdate()
    {
        this.transform.localPosition = new Vector2((currentMana/100f) * 2.4f - 1.2f, 0f);
    }


}
