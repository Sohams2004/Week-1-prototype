using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeGestures : MonoBehaviour
{
    Vector2 pressDownPos;
    Vector2 pressUpPos;
    Vector2 swipeDirection;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressDownPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            pressUpPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            swipeDirection = new Vector2(pressUpPos.x - pressDownPos.x, pressUpPos.y - pressDownPos.y);

            if (swipeDirection.y > 120f)
            {
                Debug.Log("Swiped up");
            }    

            if (swipeDirection.y < -120f)
            {
                Debug.Log("Swipe down");
            }

            if (swipeDirection.x < -120f)
            {
                Debug.Log("Swipe left");
            }

            if(swipeDirection.x > 120f)
            {
                Debug.Log("Swipe right");
            }
        }
    }
}
