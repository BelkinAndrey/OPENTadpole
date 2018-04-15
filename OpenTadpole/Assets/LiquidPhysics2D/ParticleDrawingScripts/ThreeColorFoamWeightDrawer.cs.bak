using UnityEngine;
using System.Collections;

public class ThreeColorFoamWeightDrawer : LPDrawParticleSystem
{
	public Color High;
	public Color Mid;
	public Color Low;
	
	public AnimationCurve curve;
	
	public float divisor = 5f;
	public float threshold = 0.8f;
		
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

				float val = 1- ( curve.Evaluate(partdata[i].Weight/divisor));
				
				if (val < threshold)
				{
					particles[i].color = Color.Lerp(Low,Mid,val/threshold) ;
				}
				else
				{
					particles[i].color = Color.Lerp(Mid,High,(val-threshold)/(1f-threshold));
				}				
			}		
		}		
		GetComponent<ParticleEmitter>().particles = particles;
	}
}
