using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Dissolver : MonoBehaviour 
{
	
	public LPParticleSystem sys;
	public LPParticleMaterial sludge;
	
	void FixedUpdate() 
	{
		List<LPSystemPartPartContact> contactslist = sys.GetParticleContacts();
		List<int> indices = new List<int>();
		
		int acid = 2;
		int stone = 1;
		
		foreach (var contact in contactslist)
		{
			if (contact.ParticleAUserData == acid && contact.ParticleBUserData == stone)
			{
				if (!indices.Contains(contact.ParticleBIndex))
				{
					indices.Add(contact.ParticleBIndex);
				}
			}
		}
		
		if (indices.Count > 0)
		{
			indices.Insert(0,indices.Count);
			LPAPIParticles.SetSelectedParticleFlags(sys.GetPtr(),indices.ToArray(),sludge.GetInt());
			LPAPIParticles.SetSelectedParticleUserData(sys.GetPtr(),indices.ToArray(),0);
		}
	}
}

