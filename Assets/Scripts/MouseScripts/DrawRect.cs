using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawRect : MonoBehaviour
{
    private LineRenderer lineRend;
    private Vector2 initialMousePosition, currentMousePosition;



    // Start is called before the first frame update
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        lineRend.positionCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
          
            lineRend.positionCount = 4;
            initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRend.SetPosition(0, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRend.SetPosition(1, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRend.SetPosition(2, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRend.SetPosition(3, new Vector2(initialMousePosition.x, initialMousePosition.y));

        }

        if (Input.GetMouseButton(0))
        {
           
            
            currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRend.SetPosition(0, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRend.SetPosition(1, new Vector2(initialMousePosition.x, currentMousePosition.y));
            lineRend.SetPosition(2, new Vector2(currentMousePosition.x, currentMousePosition.y));
            lineRend.SetPosition(3, new Vector2(currentMousePosition.x, initialMousePosition.y));


          

        }
        if (Input.GetMouseButtonUp(0))
        {
            lineRend.positionCount = 4;
            initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRend.SetPosition(0, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRend.SetPosition(1, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRend.SetPosition(2, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRend.SetPosition(3, new Vector2(initialMousePosition.x, initialMousePosition.y));


        }
    }
   
}
