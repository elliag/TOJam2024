using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to a GameObject with a Collider, then mouse over the object to see your cursor change.
public class cursor : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Update()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

}
