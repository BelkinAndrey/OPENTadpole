using UnityEngine;
using System.Collections;

public class RaycasterPoint : MonoBehaviour
{
	void OnDrawGizmos()
	{
		Gizmos.color = LPColors.Raycast;
		Gizmos.DrawWireSphere(transform.position,0.5f);
	}
}
