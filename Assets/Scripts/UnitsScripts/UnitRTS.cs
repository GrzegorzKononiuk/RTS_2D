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

    //PRZEROBIONE NA BOOL Z VOIDA BYM MOGL W IFIE SPRAWDZIC 
    public bool SetSelectedVisible(bool visible)
    {
        selectedGameObject.SetActive(visible);
        return visible;
    }
}
