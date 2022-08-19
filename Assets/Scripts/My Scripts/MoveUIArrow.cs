using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUIArrow : MonoBehaviour
{
    public GameObject arrow;

    private void OnMouseOver()
    {
        arrow.transform.position = new Vector3 (arrow.transform.position.x, transform.position.y, arrow.transform.position.z);
    }
}
