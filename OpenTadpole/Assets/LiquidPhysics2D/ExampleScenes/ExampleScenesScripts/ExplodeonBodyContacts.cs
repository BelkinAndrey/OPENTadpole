using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplodeonBodyContacts : MonoBehaviour
{
	
	LPParticleSystem partsys;
	LPBody bod;
	
	// Use this for initialization
	void Start ()
	{
		partsys = FindObjectOfType<LPParticleSystem>();
		bod = GetComponent<LPBody>();
	}
	
	void FixedUpdate ()
	{
		List<LPSystemFixPartContact> conts =  partsys.GetBodyContacts();
		
		if (conts.Count > 0)
		{
			Debug.Log( " particle index " + conts[0].ParticleIndex  
			          +" particle userdata " + conts[0].ParticleUserData  
			          +" body " + conts[0].BodyIndex 
			          +" fix " + conts[0].FixtureIndex
			          + " weight " +conts[0].Weight
			          + " normalx " +conts[0].Normal.x
			          + " normaly " +conts[0].Normal.y
			          );
			
			List<int> todo = new List<int>();
			
			foreach (LPSystemFixPartContact cont in conts)
			{
				if (cont.BodyIndex == bod.myIndex && !todo.Contains(cont.ParticleIndex))
				{
					todo.Add(cont.ParticleIndex);
				}
			}
			
			if (todo.Count > 0)
			{
				todo.Insert(0,todo.Count);
				LPAPIParticles.ExplodeSelectedParticles(partsys.GetPtr(),todo.ToArray(),transform.position.x,transform.position.y,600f);
			}
			
		}			
	}	
}
