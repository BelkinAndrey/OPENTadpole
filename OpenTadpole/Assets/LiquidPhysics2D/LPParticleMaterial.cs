using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Set various flags on this scriptableobject to add various properties to the particle or particle group associated with it</summary>
public class LPParticleMaterial : ScriptableObject
{
	/// <summary>Water particle</summary>
	[Tooltip("Water particle")]
	public bool	water;
	/// <summary>Without isotropic pressure</summary>
	[Tooltip("Without isotropic pressure")]
	public bool powder;
	/// <summary>With viscosity</summary>]
	[Tooltip("With viscosity")]
	public bool viscous;
	/// <summary>With surface tension</summary>
	[Tooltip("With surface tension")]
	public bool tensile;
	/// <summary>With restitution from stretching</summary>
	[Tooltip("With restitution from stretching")]
	public bool spring;
	/// <summary>With restitution from deformation</summary>
	[Tooltip("With restitution from deformation")]	   
	public bool elastic;
	/// <summary>Zero velocity</summary>
	[Tooltip("Zero velocity")]
	public bool wall; 	
	
	/// <summary>Mix color between contacting particles</summary>
	[Tooltip("Mix color between contacting particles")]   
	public bool colorMixing;
	/// <summary>Prevents other particles from leaking</summary>
	[Tooltip("Prevents other particles from leaking")]
	public bool barrier;
	/// <summary>Less compressibility</summary>
	[Tooltip("Less compressibility")]
	public bool staticPressure;
	/// <summary>Makes pairs or triads with other particles</summary>
	[Tooltip("Makes pairs or triads with other particles")]		   
	public bool reactive;
	/// <summary>With high repulsive force</summary>
	[Tooltip("With high repulsive force")]
	public bool repulsive; 
	
	[Space(10)]
	/// <summary>Particle will be deleted next step</summary>
	[Tooltip("Particle will be deleted next step. Deletes particles in batches more efficiently than one at a time")]
	public bool zombie; 
	
	[Header("Warning: Use flags below with caution!")]
	/// <summary>particle sends contact info to contact listener when it collides with a fixture. Expensive!</summary>
	[Tooltip("particle sends contact info to contact listener when it collides with a fixture. Expensive!")]
	public bool particleContactListener; 
	/// <summary>particle sends contact info to contact listener when it collides with a fixture. Very expensive!! Use with caution!!</summary>
	[Tooltip("particle sends contact info to contact listener when it collides with a fixture. Very expensive!! Use with caution!!")]
	public bool fixtureContactListener; 
	   
	/// <summary>
	/// This uses bitmasking to obtain the Int32 that indicates which particle flags to use in the liquidfun library</summary> 
	public Int32 GetInt()
	{
		Int32 num = 0;
		if (water)
		{
			num |= (Int32)b2ParticleFlag.b2_waterParticle;
		}
		if (powder)
		{
			num |= (Int32)b2ParticleFlag.b2_powderParticle;
		}
		if (viscous)
		{
			num |= (Int32)b2ParticleFlag.b2_viscousParticle;
		}
		if (tensile)
		{
			num |= (Int32)b2ParticleFlag.b2_tensileParticle;
		}
		if (spring)
		{
			num |= (Int32)b2ParticleFlag.b2_springParticle;
		}							
		if (elastic)
		{
			num |= (Int32)b2ParticleFlag.b2_elasticParticle;
		}
		if (wall)
		{
			num |= (Int32)b2ParticleFlag.b2_wallParticle;
		}
		if (colorMixing)
		{
			num |= (Int32)b2ParticleFlag.b2_colorMixingParticle;
		}
		if (barrier)
		{
			num |= (Int32)b2ParticleFlag.b2_barrierParticle;
		}
		if (staticPressure)
		{
			num |= (Int32)b2ParticleFlag.b2_staticPressureParticle;
		}
		if (reactive)
		{
			num |= (Int32)b2ParticleFlag.b2_reactiveParticle;
		}
		if (repulsive)
		{
			num |= (Int32)b2ParticleFlag.b2_repulsiveParticle;
		}
		if (zombie)
		{
			num |= (Int32)b2ParticleFlag.b2_zombieParticle;
		}
		
		if (particleContactListener)
		{
			num |= (Int32)b2ParticleFlag.b2_particleContactListenerParticle;
		}
		
		if (fixtureContactListener)
		{
			num |= (Int32)b2ParticleFlag.b2_fixtureContactListenerParticle;
		}			
		return num;
	}
}
