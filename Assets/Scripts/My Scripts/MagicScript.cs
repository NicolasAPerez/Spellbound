using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicScript : MonoBehaviour
{
    public enum Runes
    {
        None,
        Light,
        Wind,
        Fire,
        Water
    }
    public ManaManager manaBar;
    public bool quickStart;

    public Sprite[] runes = new Sprite[4];
    public Runes[] spellRunes = new Runes[3];

    public float timeBetweenInput;
    private float timeTracker;
    private int runeCount;
    private bool castingSpell;
    private int spellToCast;
    public RunicUI runeUI;

    //To Fade on non-use
    public GameObject runeWheel;
    private bool runeWheelFading;
    private float runeWheelTimer;

    //For facing info
    public MovementMage move;
    private bool leftFace;

    public GameObject placeholder;
    public GameObject[] residues = new GameObject[1];
    public List<Spell> spellbook = new List<Spell>();
    public TextAsset spellText;
    // Start is called before the first frame update
    void Start()
    {

        runeCount = 0;
        castingSpell = false;
        leftFace = false;
        runeWheelFading = false;
        fillSpellbook();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeTracker && !castingSpell && !move.disable)
        {
            if (runeCount < 3)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    spellRunes[runeCount] = Runes.Wind;
                    runeUI.updateSprite(Runes.Wind, runeCount);
                    runeCount++;
                    timeTracker = Time.time + timeBetweenInput;

                    runeWheelFading = false;
                    runeWheel.SetActive(true);
                }
                else if (Input.GetButtonDown("Fire2"))
                {
                    spellRunes[runeCount] = Runes.Light;
                    runeUI.updateSprite(Runes.Light, runeCount);
                    runeCount++;
                    timeTracker = Time.time + timeBetweenInput;

                    runeWheelFading = false;
                    runeWheel.SetActive(true);
                }
                else if (Input.GetButtonDown("Fire3"))
                {
                    spellRunes[runeCount] = Runes.Fire;
                    runeUI.updateSprite(Runes.Fire, runeCount);
                    runeCount++;
                    timeTracker = Time.time + timeBetweenInput;

                    runeWheelFading = false;
                    runeWheel.SetActive(true);
                }
                else if (Input.GetButtonDown("Fire4"))
                {
                    spellRunes[runeCount] = Runes.Water;
                    runeUI.updateSprite(Runes.Water, runeCount);
                    runeCount++;
                    timeTracker = Time.time + timeBetweenInput;

                    runeWheelFading = false;
                    runeWheel.SetActive(true);

                }
                else
                {
                    if (!runeWheelFading)
                    {
                        runeWheelFading = true;
                        runeWheelTimer = Time.time;
                    }
                    else
                    {
                        if (runeWheelTimer + 1 <= Time.time)
                        {
                            runeWheel.SetActive(false);
                        }
                    }
                }
            }

            else if (runeCount == 3)
            {
                spellToCast = matchSpell();
                runeCount = 0;
                runeUI.clearUI();
                
                for (int i = 0; i < 3; i++)
                {
                    spellRunes[i] = Runes.None;
                }

                castingSpell = (spellToCast != -1);
            }
        }


        if (leftFace != move.leftFace)
        {
            placeholder.transform.localPosition = new Vector2(-placeholder.transform.localPosition.x, placeholder.transform.localPosition.y);
            leftFace = move.leftFace;
        }
    }

    private void FixedUpdate()
    {
        if (castingSpell)
        {
            Debug.Log("You cast " + spellbook[spellToCast].spellName);
            Cast(spellToCast);
            castingSpell = false;
        }
    }

    void fillSpellbook()
    {
        string[] sp = spellText.text.Split('\n');
        for (int i = 0; i < sp.Length; i++)
        {
            string[] properties = sp[i].Split(',');
            string[] recipeTemp = { properties[5], properties[6], properties[7] };
            float lifespan = float.Parse(properties[2]);
            float damage = float.Parse(properties[3]);
            int residue = int.Parse(properties[4]);
            int cost = int.Parse(properties[9]);
            spellbook.Add(new Spell(properties[0], properties[1], lifespan, damage, residues[residue], recipeTemp, properties[8], cost));
        }
    }

    int matchSpell()
    {
        int index = -1;
        if (runeCount != 3)
        {
            return -1;
        }
        else
        {
            for (int i = 0; i < spellbook.Count; i++){
                if (spellbook[i].match(spellRunes))
                {
                    index = i;
                }
            }
        }
        return index;
    }

    GameObject Cast(int index)
    {
        if (manaBar.cast(spellbook[index].castCost, 10))
        {
            GameObject castedSpell = Instantiate(placeholder, placeholder.GetComponentInParent<Transform>());


            if (spellbook[index].targetT == Spell.targetType.Projectile)
            {
                SpellProjecitle proj = castedSpell.AddComponent<SpellProjecitle>();
                proj.spellDetails = spellbook[index];
                proj.leftFace = move.leftFace;


            }
            castedSpell.SetActive(true);
            return castedSpell;
        }
        else
        {
            return null;
        }

    }
}
