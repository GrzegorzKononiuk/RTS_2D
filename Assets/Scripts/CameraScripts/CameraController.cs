using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f;
    //public float panBorderThickness = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if(Input.GetKey("w") /**Input.mousePosition.y >= Screen.height - panBorderThickness**/)
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") /**Input.mousePosition.y <= panBorderThickness**/)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") /**Input.mousePosition.x <= panBorderThickness**/)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") /**Input.mousePosition.x >= Screen.width - panBorderThickness**/)
        {
            pos.x += panSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
