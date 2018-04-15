using UnityEngine;
using System.Collections;
using System;
 
public class LPParticleSpawner : LPSpawner
{
	[Tooltip("If this is set only one particle will be spawned at a time, rather than a shape filled with particles")]
	public bool SpawnOnlyOneParticle;
	[Tooltip("Reference to a LPParticleGroup component. Must be set in order for this to work")]
	public LPParticleGroup pg;
	public bool JoinGroups;
	
	bool first = true;
	IntPtr lastgroup;
	
	protected override void Start2()
	{
		if(pg == null)pg = GetComponent<LPParticleGroup>();
		#if UNITY_EDITOR
		if(GameObject.FindObjectOfType<LPParticleSystem>() == null)
		{
			Debug.LogError("There is no ParticleSystem. You must have one in your scene particles in Liquid Physics 2D to work");
			return;
		}
		#endif	
	}
		
	protected override void DoSpawn()
	{
		Vector3 diff = getdiff ();
		
		if (! SpawnOnlyOneParticle)
		{			
			pg.LinearVelocity = new Vector2(diff.x,diff.y);
			pg.Initialise(lpman.ParticleSystems[pg.ParticleSystemImIn]);
			

			if (JoinGroups) 
			{
				if (first)first = false;
				else
				{
					LPAPIParticleGroups.JoinParticleGroups(lpman.ParticleSystems[pg.ParticleSystemImIn].GetPtr()
					                                       ,lastgroup,pg.GetPtr());
				}
				lastgroup = pg.GetPtr();
			}
		}
		else
		{
			int mat = 0;
			if (pg.ParticlesMaterial !=null) mat = pg.ParticlesMaterial.GetInt();
			
			LPAPIParticles.CreateParticleInSystem(lpman.ParticleSystems[pg.ParticleSystemImIn].GetPtr()
			                                      ,mat,transform.position.x,transform.position.y,diff.x,diff.y
			                                      ,(int)(pg._Color.r*255f),(int)(pg._Color.g*255f),(int)(pg._Color.b*255f),(int)(pg._Color.a*255f)
			                                      ,pg.LifeTime);				
		}
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = _Color = pg._Color;
		drawGiz();
	}
}
