using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmootherCamera : MonoBehaviour
{
    public GameObject playerCharacter;
    public float moveSpeed;
    public Vector2 minClamp;
    public Vector2 maxClamp;
    public Vector2 offset;
    public bool isClamped;
    private Vector2 camPos;

    void FixedUpdate()
    {
        camPos = transform.position;
        Vector2 moveTo;
        if (isClamped)
        {
            moveTo = new Vector2(clampedValue(playerCharacter.transform.position.x, minClamp.x, maxClamp.x) + offset.x, clampedValue(playerCharacter.transform.position.y, minClamp.y, maxClamp.y) + offset.y);
        }
        else
        {
            moveTo = new Vector2(playerCharacter.transform.position.x + offset.x, playerCharacter.transform.position.y + offset.y);
        }

        camPos = Vector2.MoveTowards(camPos, moveTo, moveSpeed);

        transform.position = new Vector3(camPos.x, camPos.y, -10);
    }

    float clampedValue(float original, float min, float max)
    {
        return Mathf.Clamp(original, min, max);
    }
}
