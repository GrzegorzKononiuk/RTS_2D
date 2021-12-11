using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClick : MonoBehaviour
{
    private Vector3 startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
          

            startPosition = GetMouseWorldPosition();
            Debug.Log(startPosition);



        }
        if (Input.GetMouseButtonUp(0))
        {
         

           

        }


    }

                   
     

    // Get Mouse Position in World (horyzontal)
    //TUTAJ POLMIROFIZM BO NARAZIE JEST TYLKO HORYZONTALNIE BO POD 2D PRZYKALD BYL 
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
