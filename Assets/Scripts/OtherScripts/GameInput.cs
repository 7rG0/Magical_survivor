using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
   public Vector2 mousePosScreen = Vector2.zero;

    static public GameInput gameInput;

    private void Awake()
    {
        gameInput = this;
    }
    public Vector2 GetCurrentMousePos()
    {
        Vector2 mousePosScreen = Input.mousePosition;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(mousePosScreen);

        return mousePos;
    }
}
