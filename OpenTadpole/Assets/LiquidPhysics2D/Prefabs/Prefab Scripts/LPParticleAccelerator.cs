using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;


public class LPParticleAccelerator : LPAimer
{
	public int ParticleSystemImIn = 0;
	private IntPtr shape;
	private LPManager lpman;
    public float Strenght = 3f;
	
	// Use this for initialization
	void Start ()
	{
		shape = GetComponent<LPFixture>().GetShape();
		lpman = FindObjectOfType<LPManager>(); 
	}
	
	void FixedUpdate ()
	{
		if (Active)
		{
			int[] partsinshape = lpman.ParticleSystems[ParticleSystemImIn].GetParticlesInShape(shape,transform);
			
				
			if (partsinshape.Length > 1) 
			{
				Vector3 diff = getdiff()*Strenght ;
						
				LPAPIParticles.ApplyForceToSelectedParticles(lpman.ParticleSystems[ParticleSystemImIn].GetPtr(),partsinshape,diff.x,diff.y);
			}	
		}
	}
	
	void OnDrawGizmos()
	{
		_Color = Color.white;
		drawGiz();
	}
}
