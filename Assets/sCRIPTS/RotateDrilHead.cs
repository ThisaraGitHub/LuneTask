using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDrilHead : MonoBehaviour
{
   public bool canRotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0,0,1),10f);
        }
       
    }
}
