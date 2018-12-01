using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Boundary : MonoBehaviour
{
    public float speed;

    void Start()
    {
    }

    void FixedUpdate()
    {
        float yMove = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(0f, yMove, 0f);
        // initially, the temporary vector should equal the player's position
        Vector2 clampedPosition = transform.position;
        // Now we can manipulte it to clamp the y element
        clampedPosition.y = Mathf.Clamp(transform.position.y,1.1f, 1.1f);
        // re-assigning the transform's position will clamp it
        transform.position = clampedPosition;
    }
}