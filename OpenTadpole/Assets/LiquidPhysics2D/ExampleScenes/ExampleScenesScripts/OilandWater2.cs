using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OilandWater2 : MonoBehaviour
{

	public LPParticleSystem sys;
	
	public float UpwardsForce = 0.5f;
	public float Mult = 1f;
			
	void FixedUpdate()
	{
		int oil = 1;
		int water = 0;
			
		List<int> upindices = new List<int>();
		List<int> downindices = new List<int>();
		
		foreach (LPSystemPartPartContact cont in sys.GetParticleContacts())
		{
			if (cont.ParticleAUserData == oil && cont.ParticleBUserData == water)
			{
				if (!upindices.Contains(cont.ParticleAIndex)) upindices.Add(cont.ParticleAIndex);
				if (!downindices.Contains(cont.ParticleBIndex)) downindices.Add(cont.ParticleBIndex);
			}
		}		
		
		if (upindices.Count >0 )
		{
			upindices.Insert(0,upindices.Count);
			LPAPIParticles.ApplyForceToSelectedParticles(sys.GetPtr(),upindices.ToArray(),0f,UpwardsForce);
		}
		if (downindices.Count >0 )
		{
			downindices.Insert(0,downindices.Count);
			LPAPIParticles.ApplyForceToSelectedParticles(sys.GetPtr(),downindices.ToArray(),0f,-UpwardsForce*Mult);
		}
	}
}
