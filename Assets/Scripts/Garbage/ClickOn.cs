using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOn : MonoBehaviour
{
    [SerializeField]
    private Material red;
    [SerializeField]
    private Material green;

    private MeshRenderer myRend;
   
    void Start()
    {
        myRend = GetComponent<MeshRenderer>();
    }


    public void ClickMe()
    {
        myRend.material = green;
    }
}
