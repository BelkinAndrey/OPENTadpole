using UnityEngine;
using System.Collections;

public class WeightDrawer : LPDrawParticleSystem
{
	public float Wscale = 1f;
	
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
				float val =  partdata[i].Weight*Wscale;
				particles[i].color = new Color(1f-val,0f, val);
			}		
		}
		
		GetComponent<ParticleEmitter>().particles = particles;
	}
}