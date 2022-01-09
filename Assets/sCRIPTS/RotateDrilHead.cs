using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDrilHead : MonoBehaviour
{
    /// <summary>
    // This script handles the rotation of the drill //
    /// </summary>
 
    public bool canRotate;                              // Public reference to the handle the rotation of the drill head

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0,0,1),10f);
        }
       
    }
}
