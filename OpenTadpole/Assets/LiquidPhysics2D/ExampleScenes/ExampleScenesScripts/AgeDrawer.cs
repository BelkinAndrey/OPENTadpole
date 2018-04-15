using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AgeDrawer : LPDrawParticleSystem
{
	public float scale = 1f;
	
	public override void UpdateParticles(List<LPParticle> partdata)
	{	
        if (GetComponent<ParticleEmitter>().particleCount < partdata.Count) 
		{
            GetComponent<ParticleEmitter>().Emit(partdata.Count - GetComponent<ParticleEmitter>().particleCount);		
			particles = GetComponent<ParticleEmitter>().particles;
		}
		
		for (int i=0; i < particles.Length; i ++)
		{		
            if (i > partdata.Count - 1)
			{
				particles[i].energy = 0f;
			}
			else
			{
				particles[i].position  = partdata[i].Position;
				float val =  partdata[i].LifeTime*scale;
				particles[i].color = new Color(1f,val, val);
			}		
		}
		
		GetComponent<ParticleEmitter>().particles = particles;
	}
}
