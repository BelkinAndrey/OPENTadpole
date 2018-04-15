using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class uses unity's particle emitter to draw the particles in a particle system
/// It is designed to be a seperate modular element so you may implement your own drawer to suit your particular game</summary>
public class LPDrawParticleSystem : MonoBehaviour 
{	
	[Tooltip("How big should the particles appear relative to their size in the simulation")]	
	public float ParticleDrawScale = 4f;
	[Tooltip("This drawer will draw particles in its parent particle system with the same userdata value as this")]
	public int DrawParticlesWithThisUserData = 0;
	protected Particle[] particles = new Particle[0];
	protected LPParticleSystem sys;
	public bool debug;
	
	public void Initialise(LPParticleSystem partsys)
	{
		GetComponent<ParticleEmitter>().maxSize = GetComponent<ParticleEmitter>().minSize = partsys.ParticleRadius*ParticleDrawScale;
	}
	
	/// <summary>
	/// Redraw the particles in the particle system</summary>
	/// <param name="partdata">An array of LPParticle structs, this is available in LPParticle system</param>
	public virtual void UpdateParticles(LPParticle[] partdata)
	{	
		if (GetComponent<ParticleEmitter>().particleCount < partdata.Length) 
		{
			GetComponent<ParticleEmitter>().Emit(partdata.Length - GetComponent<ParticleEmitter>().particleCount);		
			particles = GetComponent<ParticleEmitter>().particles;
		}
		
		if (debug && particles.Length > 2)
		{
			Debug.Log ( "part 0 "+ particles[0].rotation +" part 1 "+ particles[1].rotation +" part 2 "+ particles[2].rotation);
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
				particles[i].color = partdata[i]._Color;
			}		
		}
		
		GetComponent<ParticleEmitter>().particles = particles;
	}
	
	/// <summary>
	/// Redraw the particles in the particle system, but only ones with a certain userdata value</summary>
	/// <param name="partdata">An array of LPParticle structs, this is available in LPParticle system</param>
	public void UpdateParticles(LPParticle[] allpartdata,bool multi)
	{
		List<LPParticle> partsforme =new List<LPParticle>();
		
		foreach (LPParticle part in allpartdata)
		{
			if (part.UserData == DrawParticlesWithThisUserData)
			{
				partsforme.Add(part);
			}
		}
		
		UpdateParticles(partsforme.ToArray());
	}
}
