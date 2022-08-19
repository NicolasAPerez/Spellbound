using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleVis : MonoBehaviour
{
    public GameObject toVis;
    public GameObject toInvis;

    public void swapVis()
    {
        toInvis.SetActive(false);
        toVis.SetActive(true);
    }
}
