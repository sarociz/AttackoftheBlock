using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float rapidez = 20;
    // Use this for initialization1
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        //transform.position = Vector2.MoveTowards(transform.position, mousePosition, rapidez * Time.deltaTime);
        transform.position = mousePosition;
    }

}