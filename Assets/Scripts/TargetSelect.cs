using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public enum CarType 
{
    Horizontal,
    Vertical
}


public class TargetSelect : MonoBehaviour
{
    [SerializeField] CarType type;

    [SerializeField] GameObject path;

    [SerializeField] Rigidbody rb;

    [SerializeField] float timer = 2f;
    [SerializeField] float speed = 10f;

    Vector2 pressDownPos;
    Vector2 pressUpPos;
    Vector2 swipeDirection;

    LevelManager levelManager;

    [SerializeField] bool swipeUp, swipeDown, swipeLeft, swipeRight;
    [SerializeField] bool moveUp, moveDown, moveLeft, moveRight;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        rb = GetComponent<Rigidbody>();

        path.SetActive(false);
    }

    private void OnMouseDown()
    {
        Debug.Log("Object selected");
        path.SetActive(true);

        if (type == CarType.Horizontal)
        {
            swipeRight = true;
            swipeLeft = true;

            swipeUp = false;
            swipeDown = false;
        }

        else
        {
            swipeUp = true;
            swipeDown = true;

            swipeRight = false;
            swipeLeft = false;
        }
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
                moveUp = true;
            }

            if (swipeDirection.y < -100f && swipeDown)
            {
                Debug.Log("Swipe down");
                moveDown = true;
            }

            if (swipeDirection.x < -100f && swipeLeft)
            {
                Debug.Log("Swipe left");
                moveLeft = true;
            }

            if (swipeDirection.x > 100f && swipeRight)
            {
                Debug.Log("Swipe right");
                moveRight = true;
            }
        }

        if (moveUp)
        {
            Debug.Log("wswdqd");
            MoveUp();
        }

        else if (moveDown)
        {
            MoveDown();
        }

        else if (moveLeft)
        {
            MoveLeft();
        }

        else if (moveRight)
        {
            MoveRight();
        }
    }

    public void OnMouseUp()
    {
        path.SetActive(false);
    }
    
    public void MoveUp()
    {
        Debug.Log("Moved up");
        //Vector3 moveUp = Vector3.forward * Time.deltaTime;
        Vector3 moveUp = new Vector3(0, 0, 0.05f);
        rb.MovePosition(transform.localPosition += moveUp);
    }
    
    public void MoveDown()
    {
        Debug.Log("Moved down");
        //Vector3 moveDown = Vector3.forward * Time.deltaTime;
        Vector3 moveDown = new Vector3(0, 0, -0.05f);
        rb.MovePosition(transform.localPosition += moveDown);
    }

    public void MoveLeft()
    {
        Debug.Log("Moved Left");
        //Vector3 moveLeft = Vector3.left * Time.deltaTime;
        Vector3 moveLeft = new Vector3(-0.05f, 0, 0);
        rb.MovePosition(transform.localPosition += moveLeft);
    }
    
    public void MoveRight()
    {
        Debug.Log("Moved Right");
        //Vector3 moveRight = Vector3.left * Time.deltaTime;
        Vector3 moveRight = new Vector3(0.05f, 0, 0);
        rb.MovePosition(transform.localPosition += moveRight);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Outline"))
        {
            Debug.Log("Destroyed");
            Destroy(gameObject);
            levelManager.VehiclesDestroyedTrack();
        }

        if (other.gameObject.CompareTag("Vehicle"))
        {
            Debug.Log("Crashed into vehicle");
            StartCoroutine(RestartLevel());
        } 
        
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Crashed into vehicle");
            StartCoroutine(RestartLevel());
        }
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
