using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class InputUtilities
{
    public static void GetMouseInput(out bool isTouched, out Vector3 position)
    {
        position = new Vector3();
        #if UNITY_EDITOR
        {
            // use the input stuff
            isTouched = Input.GetMouseButton(0);
            if (isTouched)
            {
                position = Input.mousePosition;
            }
        }
        #else
            {
                isTouched = (Input.touchCount > 0);
                if(isTouched)
                {
                    position = Input.GetTouch(0).position;
                }
            }
        #endif
    }
}
