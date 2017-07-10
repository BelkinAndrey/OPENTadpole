using UnityEngine;
using System.Collections;

public class HeadTadpole : MonoBehaviour {

    public Transform pointL1;
    public Transform pointL2;

    public Transform LF;
    public Transform RF;

    void OnDrawGizmos() 
    {
        if ((pointL1 != null) && (pointL2 != null))
        {
            Gizmos.DrawLine(pointL1.position, pointL2.position);
        }
    }
}
