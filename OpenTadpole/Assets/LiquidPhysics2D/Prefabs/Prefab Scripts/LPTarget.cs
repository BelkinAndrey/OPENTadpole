using UnityEngine;
using System.Collections;

public class LPTarget : MonoBehaviour
{
    Vector3 Vert = new Vector3(0f, 0.5f, 0f);
    Vector3 Horz = new Vector3(0.5f, 0f, 0f);
	public LPAimer aimer;
		
	void OnDrawGizmos()
	{
		if (aimer != null)
		{
            Gizmos.color = new Color(aimer._Color.r, aimer._Color.g, aimer._Color.b);
		}
        Gizmos.DrawLine(transform.position - Vert, transform.position + Vert);
        Gizmos.DrawLine(transform.position - Horz, transform.position + Horz);
	}
}
