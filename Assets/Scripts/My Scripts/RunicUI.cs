using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunicUI : MonoBehaviour
{
    public MagicScript MagicScript;
    public SpriteRenderer[] runes = new SpriteRenderer[3];

    Dictionary<MagicScript.Runes, int> runeToSprite = new Dictionary<MagicScript.Runes, int>()
    {
        {MagicScript.Runes.Light, 0},
        {MagicScript.Runes.Wind, 1},
        {MagicScript.Runes.Fire, 2},
        {MagicScript.Runes.Water, 3}
    };
    private void Start()
    {
        clearUI();
    }
    public void updateSprite(MagicScript.Runes rune, int toChange)
    {
        if (rune == MagicScript.Runes.None)
        {
            runes[toChange].enabled = false;
        }
        else
        {
            runes[(toChange)].enabled = true;
            runes[(toChange)].sprite = MagicScript.runes[runeToSprite[rune]];
        }
    }

    public void clearUI()
    {
        for (int i = 0; i < runes.Length; i++)
        {
            updateSprite(MagicScript.Runes.None, i);
        }
    }


}
