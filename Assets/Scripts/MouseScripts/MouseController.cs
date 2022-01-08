using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 lastClickedPos;
    private List<UnitRTS> selectedUnitRTSList;
    public float speed = 10f;
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
        //Left Mouse Button Pressed
        if (Input.GetMouseButtonDown(0))
        {

           
            startPosition = GetMouseWorldPosition();
            Debug.Log(startPosition + "startpoitn"); 
            
        }


        //Left Mouse Button Released
        if (Input.GetMouseButtonUp(0))
        {

            
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
        //Right Mouse Button Pressed
        if (Input.GetMouseButtonDown(1))
        {
            
            foreach (UnitRTS unitRTS in selectedUnitRTSList)
            {
                if (unitRTS.SetSelectedVisible(true))
                {
                    lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Debug.Log("last clicked pos" + lastClickedPos);
                }
            }
        }
        
        //Right Mouse Button Released
        if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("Right RELESED"); 
        }

        //JESLI OBIEKTY MAJA KOORDYNATY INNE NIZ 0,0,0 TO DAZA DO NICH PO ODPALENIU PROGRAMU
        if ((Vector2)transform.position != lastClickedPos && selectedUnitRTSList.Count >= 0)
        {

            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);

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
