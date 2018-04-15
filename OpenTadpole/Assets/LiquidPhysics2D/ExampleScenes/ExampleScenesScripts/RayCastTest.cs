using UnityEngine;
using System.Collections;

public class RayCastTest : MonoBehaviour {

	public LPRayCaster caster;
	private LPRayCastHit[] hits;
	
	void Start ()
	{
		hits =  caster.RaycastWorld();
		foreach (LPRayCastHit hit in hits)
		{
			Debug.Log("parent index " +hit.ParentIndex.ToString());
			Debug.Log("index " +hit.Index.ToString());
			Debug.Log("Fraction " +hit.Fraction.ToString());
		}
	}
	
	void OnDrawGizmos()
	{
		if (hits != null)
		{
			foreach (LPRayCastHit hit in hits)
			{
				if (hit.WhatDidIHit == LPRayCastHitType.LPFixture) Gizmos.color = Color.red;
				else Gizmos.color = Color.blue;
				Gizmos.DrawLine(hit.Position,hit.Position+ hit.Normal);	
			}
		}
	}
}
