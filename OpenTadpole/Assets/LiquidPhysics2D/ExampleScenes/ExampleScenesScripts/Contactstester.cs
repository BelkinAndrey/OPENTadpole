using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Contactstester : MonoBehaviour
{
	private List<LPContactFixFix> fixfix = new List<LPContactFixFix>();
	private List<LPContactPartFix> partfix = new List<LPContactPartFix>();
	private List<Vector3> pfposes = new List<Vector3>();
	private List<LPContactPartPart> partpart = new List<LPContactPartPart>();
	private List<Vector3> ppposes = new List<Vector3>();
	private List<Vector3> ppposes2 = new List<Vector3>();
	private LPManager lpman;
	void Start()
	{
		lpman = FindObjectOfType<LPManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (lpman.ContactListener.FixtureFixtureContacts !=null && lpman.ContactListener.FixtureFixtureContacts.Length >0)
		{
			foreach (LPContactFixFix ff in lpman.ContactListener.FixtureFixtureContacts)
			{
				fixfix.Add(ff);
				Debug.Log("Fixture-Fixture Collision entered between Body# "+ff.BodyAIndex +" Fixture# "+ff.FixtureAIndex 
				          +" and Body# "+ff.BodyBIndex +" Fixture# "+ ff.FixtureBIndex + "IsTouching = " + ff.IsTouching);
			}
		}

		if (lpman.ContactListener.ParticleFixtureContacts !=null && lpman.ContactListener.ParticleFixtureContacts.Length >0)
		{
			foreach (LPContactPartFix pf in lpman.ContactListener.ParticleFixtureContacts)
			{
				partfix.Add(pf);
				pfposes.Add (lpman.ParticleSystems[pf.ParticleSystemIndex].Particles[pf.ParticleIndex].Position);
				Debug.Log("Particle-Fixture Collision entered between ParticleSystem# "+pf.ParticleSystemIndex +" Particle# "+pf.ParticleIndex 
				          +" and Body# "+pf.BodyIndex +" Fixture# "+ pf.FixtureIndex);
			}
		}
		
		if (lpman.ContactListener.ParticleParticleContacts !=null && lpman.ContactListener.ParticleParticleContacts.Length >0)
		{
			foreach (LPContactPartPart pp in lpman.ContactListener.ParticleParticleContacts)
			{
				partpart.Add(pp);
				ppposes.Add (lpman.ParticleSystems[pp.ParticleSystemIndex].Particles[pp.ParticleAIndex].Position);
				ppposes2.Add (lpman.ParticleSystems[pp.ParticleSystemIndex].Particles[pp.ParticleBIndex].Position);
				Debug.Log("Particle-Particle Collision entered between ParticleSystem# "+pp.ParticleSystemIndex +" Particle# "+pp.ParticleAIndex 
				          +" and Particle# "+pp.ParticleBIndex);
			}
		}
	}
	
	void OnDrawGizmos()
	{		
		foreach (LPContactFixFix ff in fixfix)
		{
			Gizmos.DrawLine(ff.ManifoldPoint1,ff.ManifoldPoint1+ff.Normal);
		}
		for (int i = 0; i < partfix.Count; i++) 
		{			
			Gizmos.color = Color.cyan;			
			Gizmos.DrawLine(pfposes[i],pfposes[i]+ partfix[i].Normal*0.5f);
		}		
		for (int i = 0; i < partpart.Count; i++) 
		{			
			Gizmos.color = Color.red;			
			Gizmos.DrawLine(ppposes[i],ppposes2[i]);
		}				
	}
}
