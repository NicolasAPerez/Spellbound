using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    public enum targetType
    {
        Self,
        Projectile,
        Raycast
    }
    public enum Element
    {
        Light,
        Wind,
        Fire,
        Water,
        Ice,
        Lightning,
        Nature,
        Earth
    }
    public MagicScript.Runes[] spellRecipe = new MagicScript.Runes[3];
    public string spellName;
    public targetType targetT;
    public Element spellElement;
    public float spellLifeSpan;
    public float spellDamage;
    public GameObject residueOnDecay;
    public int castCost;


    public Spell(string name, string type, float lifespan, float damage, GameObject residue, string[] recipe, string element, int cost)
    {
        spellName = name;
        targetT = spellTargetDict[type];
        spellLifeSpan = lifespan;
        spellDamage = damage;
        residueOnDecay = residue;
        for (int i = 0; i < 3; i++)
        {
            spellRecipe[i] = spellRunesDict[recipe[i]];
        }

        
        spellElement = spellElementsDict[element];
        castCost = cost;
    }

    public bool match(MagicScript.Runes[] toMatch)
    {
        bool ret = true;
        for (int i = 0; i < toMatch.Length; i++)
        {
            ret = (spellRecipe[i] == toMatch[i])? ret : false;
        }
        return ret;
    }

    Dictionary<string, MagicScript.Runes> spellRunesDict = new Dictionary<string, MagicScript.Runes>()
    {
        {"Light", MagicScript.Runes.Light },
        {"Fire", MagicScript.Runes.Fire },
        {"Wind", MagicScript.Runes.Wind },
        {"Water", MagicScript.Runes.Water }

    };

    Dictionary<string, Element> spellElementsDict = new Dictionary<string, Element>()
    {
        {"Light", Element.Light },
        {"Fire", Element.Fire },
        {"Wind", Element.Wind },
        {"Water", Element.Water },
        {"Ice", Element.Ice },
        {"Lightning", Element.Lightning },
        {"Nature", Element.Nature },
        {"Earth", Element.Earth }
    };

    Dictionary<string, targetType> spellTargetDict = new Dictionary<string, targetType>()
    {
        {"Projectile", targetType.Projectile },
        {"Self", targetType.Self },
        {"Raycast", targetType.Raycast },


    };
}
