using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmootherCamera : MonoBehaviour
{
    public GameObject playerCharacter;
    public float moveSpeed;
    public Vector2 minClamp;
    public Vector2 maxClamp;
    private Vector2 camPos;

    void FixedUpdate()
    {
        camPos = transform.position;
        Vector2 moveTo = new Vector2(clampedValue(playerCharacter.transform.position.x, minClamp.x, maxClamp.x), clampedValue(playerCharacter.transform.position.y, minClamp.y, maxClamp.y)) ;

        camPos = Vector2.MoveTowards(camPos, moveTo, moveSpeed);

        transform.position = new Vector3(camPos.x, camPos.y, -10);
    }

    float clampedValue(float original, float min, float max)
    {
        return Mathf.Clamp(original, min, max);
    }
}
