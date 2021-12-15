using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [SerializeField] public Transform selectionAreaTransform;
    
    private Vector3 startPosition;
    private List<UnitRTS> selectedUnitRTSList;
    
    private void Awake()
    {
        selectedUnitRTSList = new List<UnitRTS>();
        selectionAreaTransform.gameObject.SetActive(false);
        
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
            selectionAreaTransform.gameObject.SetActive(true);
            //Left Mouse Button Pressed
            startPosition = GetMouseWorldPosition();
            
        }
     
        if(Input.GetMouseButton(0))
        {
            // Left Mouse Button Held Down
            Vector3 currentMousePosition = GetMouseWorldPosition();
            Vector3 lowerLeft = new Vector3(
                Mathf.Min(startPosition.x, currentMousePosition.x),
                Mathf.Min(startPosition.y, currentMousePosition.y)
            );
            Vector3 upperRight = new Vector3(
                Mathf.Max(startPosition.x, currentMousePosition.x),
                Mathf.Max(startPosition.y, currentMousePosition.y)
            );
            selectionAreaTransform.position = lowerLeft;
            selectionAreaTransform.localScale = upperRight - lowerLeft;
        }
       
        if (Input.GetMouseButtonUp(0))
        {
            selectionAreaTransform.gameObject.SetActive(false);
            //LEft Mouse Button Released
            Collider2D[] collider2DArray = Physics2D.OverlapAreaAll(startPosition, GetMouseWorldPosition());
            
            //Deselect All Units
        
            foreach(UnitRTS unitRTS in selectedUnitRTSList)
            {
                unitRTS.SetSelectedVisible(false);
            }
       
            selectedUnitRTSList.Clear();
            
            //Select units within Selection Area
            foreach(Collider2D collider2D in collider2DArray)
            {
                UnitRTS unitRTS = collider2D.GetComponent<UnitRTS>();
                if(unitRTS != null)
                {
                    unitRTS.SetSelectedVisible(true);
                    selectedUnitRTSList.Add(unitRTS);
                }
            }
            Debug.Log(selectedUnitRTSList.Count);

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
