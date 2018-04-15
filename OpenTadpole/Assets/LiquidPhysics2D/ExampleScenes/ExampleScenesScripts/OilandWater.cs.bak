using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OilandWater : MonoBehaviour
{
	public LPParticleSystem sys;
	
	//[Range(0,1)]
	public float UpwardsForce = 0.4f;
	public float Mult;
		
	// Update is called once per frame
	void FixedUpdate()
	{
		List<int> indices2 = new List<int>();
		
		if (sys.Particles != null)
		{
			for (int i = 0; i < sys.Particles.Length; i++) 
			{
				if(sys.Particles[i].UserData == 0)
				{
					indices2.Add(i);
				}

			}
		}
		if (indices2.Count >0 )
		{
			indices2.Insert(0,indices2.Count);
			LPAPIParticles.ApplyForceToSelectedParticles(sys.GetPtr(),indices2.ToArray(),0f,-UpwardsForce*Mult);
		}
	}
}
