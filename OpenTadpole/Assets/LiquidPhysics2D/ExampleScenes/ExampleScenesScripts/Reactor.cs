using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Reactor : MonoBehaviour 
{

	public LPParticleSystem sys;
	public LPParticleMaterial wall;
	public LPParticleMaterial zombie;

	void FixedUpdate() 
	{
		List<LPSystemPartPartContact> contactslist = sys.GetParticleContacts();
		List<int> indices = new List<int>();
		List<int> delindices = new List<int>();
		
		int water = 2;
		int lava = 1;
		
		foreach (var contact in contactslist)
		{
			if (contact.ParticleAUserData == water && contact.ParticleBUserData == lava)
			{
				if (!indices.Contains(contact.ParticleBIndex))
				{
					indices.Add(contact.ParticleBIndex);
				}
				if (!delindices.Contains(contact.ParticleAIndex))
				{
					delindices.Add(contact.ParticleAIndex);                     
                }	
            }
        }
                
        if (indices.Count > 0)
	    {
			indices.Insert(0,indices.Count);
        	LPAPIParticles.SetSelectedParticleFlags(sys.GetPtr(),indices.ToArray(),wall.GetInt());
			LPAPIParticles.SetSelectedParticleColor(sys.GetPtr(),indices.ToArray(),100,100,100,255);
			LPAPIParticles.SetSelectedParticleUserData(sys.GetPtr(),indices.ToArray(),0);
	    }
	    
		if (indices.Count > 0)
		{	
            delindices.Insert(0,delindices.Count);
			LPAPIParticles.SetSelectedParticleFlags(sys.GetPtr(),delindices.ToArray(),zombie.GetInt());
		}
    }
}
