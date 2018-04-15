using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoamWeightDrawer : LPDrawParticleSystem
{
	public Color Foam;
	public Color Liquid;
	
	public AnimationCurve curve;
		
	public override void UpdateParticles(LPParticle[] partdata)
	{	
		if (GetComponent<ParticleEmitter>().particleCount < partdata.Length) 
		{
			GetComponent<ParticleEmitter>().Emit(partdata.Length - GetComponent<ParticleEmitter>().particleCount);		
			particles = GetComponent<ParticleEmitter>().particles;
		}
		
		for (int i=0; i < particles.Length; i ++)
		{		
			if (i > partdata.Length-1)
			{
				particles[i].energy = 0f;
			}
			else
			{
				particles[i].position  = partdata[i].Position;				
				particles[i].color = Color.Lerp(Foam,Liquid,curve.Evaluate( partdata[i].Weight));
			}		
		}
		
		GetComponent<ParticleEmitter>().particles = particles;
	}
}

