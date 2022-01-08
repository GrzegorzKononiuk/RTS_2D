using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRTS : MonoBehaviour
{
    public GameObject selectedGameObject;
    
    private void Awake()
    {
        selectedGameObject = transform.Find("Selected").gameObject;
        SetSelectedVisible(false);
    }

   
    public bool SetSelectedVisible(bool visible)
    {
        selectedGameObject.SetActive(visible);
        return visible;
    }
}
