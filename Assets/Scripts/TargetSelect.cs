using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSelect : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] GameObject path;

    private void Start()
    {
        material = GetComponent<Material>();

        path.SetActive(false);
    }

    private void OnMouseEnter()
    {
        Debug.Log("Hovering");
        //material.color = Color.gray;
    }

    void OnMouseExit()
    {
        //material.color = Color.white;
    }

    private void OnMouseDown()
    {
        Debug.Log("Object selected");
        path.SetActive(true);
    }

    private void OnMouseUp()
    {
        path.SetActive(false);
    }
}
