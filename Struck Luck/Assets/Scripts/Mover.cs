using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private GameObject Player;
    public Camera Camera;
    public float xMin, xMax, yMin, yMax;
    void Start()
    {
    }
    void FixedUpdate()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 wantedPos = Camera.main.ScreenToWorldPoint(new Vector2(mousePos.x, mousePos.y));
        transform.position = wantedPos;
    }

}