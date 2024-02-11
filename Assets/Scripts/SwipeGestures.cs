using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeGestures : MonoBehaviour
{
   /* Vector2 pressDownPos;
    Vector2 pressUpPos;
    Vector2 swipeDirection;

    [SerializeField] public bool swipeUp, swipeDown, swipeLeft, swipeRight;

    [SerializeField] TargetSelect targetSelect;

    private void Start()
    {
    
    }

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

            if (swipeDirection.y > 100f && swipeUp)
            {
                Debug.Log("Swiped up");
                targetSelect.MoveUp();
            }    

            if (swipeDirection.y < -100f && swipeDown)
            {
                Debug.Log("Swipe down");
                targetSelect.MoveDown();
            }

            if (swipeDirection.x < -100f && swipeLeft)
            {
                Debug.Log("Swipe left");
                targetSelect.MoveLeft();
            }

            if(swipeDirection.x > 100f && swipeRight)
            {
                Debug.Log("Swipe right");
                targetSelect.MoveRight();
            }
        }
    }*/
}
