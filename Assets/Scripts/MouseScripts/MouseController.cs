using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private Vector2 startPosition;
    private List<UnitRTS> selectedUnitRTSList;
   
    private void Awake()
    {
        selectedUnitRTSList = new List<UnitRTS>();
       
        
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            //Left Mouse Button Pressed
            startPosition = GetMouseWorldPosition();

        }



        if (Input.GetMouseButtonUp(0))
        {

            //LEft Mouse Button Released
            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, GetMouseWorldPosition());

            //Deselect All Units

            foreach (UnitRTS unitRTS in selectedUnitRTSList)
            {
                unitRTS.SetSelectedVisible(false);
            }


            selectedUnitRTSList.Clear();

            //Select units within Selection Area
            foreach (Collider2D collider2D in collider2DArray)
            {
                UnitRTS unitRTS = collider2D.GetComponent<UnitRTS>();
                if (unitRTS != null)
                {

                    unitRTS.SetSelectedVisible(true);
                    selectedUnitRTSList.Add(unitRTS);
                }
            }
            Debug.Log(selectedUnitRTSList.Count);

        }
        if (Input.GetMouseButtonDown(1))
        {

            startPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
        if ((Vector2)transform.position != startPosition)
        {

            Debug.Log("yoyooyo"); 

        }
    }
    
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
