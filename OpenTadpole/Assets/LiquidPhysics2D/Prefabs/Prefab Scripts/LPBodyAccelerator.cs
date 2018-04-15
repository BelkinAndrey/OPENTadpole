using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

public class LPBodyAccelerator : LPAimer 
{
	private LPManager lpman;
	private LPBody bod;

	void Start()
	{
		lpman = FindObjectOfType<LPManager>();
		bod  = GetComponent<LPBody>();
	}

	void FixedUpdate ()
	{	
		int[] conts = bod.GetContacts();
		if (conts.Length > 1)
		{
			Vector3 diff = getdiff ();
            for (int i = 1; i < conts.Length; i++)
			{
				if (lpman.allBodies.ContainsKey(conts[i]))
				{
					LPAPIBody.ApplyForceToCentreOfBody(lpman.allBodies[conts[i]].GetPtr(),diff.x,diff.y);
				}                                                   
			}
		}					
	}
	
	void OnDrawGizmos()
	{
		_Color = Color.white;
		drawGiz();
	}
}


