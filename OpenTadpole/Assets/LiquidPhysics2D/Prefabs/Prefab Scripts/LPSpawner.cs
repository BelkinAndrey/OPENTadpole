using UnityEngine;
using System.Collections;

public abstract class LPSpawner : LPAimer
{
	[Tooltip("Rate at which particles are spawned")]
	public float SpawnsPerSecond = 10f;
	
	protected LPManager lpman;
	
	void Start()
	{
		#if UNITY_EDITOR
		if(GameObject.FindObjectOfType<LPManager>() == null)
		{
			Debug.LogError("There is no LiquidFunManager. You must have one in your scene for Liquid Physics 2D to work");
			return;
		}	
		#endif
		
		lpman = FindObjectOfType<LPManager>();
		
		Start2();
		
		if (Active) StartCoroutine("Spawn");
	}
	
	protected abstract void Start2();
	
	/// <summary>
	/// Start this spawner spawning particles</summary>
	public void StartSpawning()
	{
		StartCoroutine("Spawn");
	}
	
	/// <summary>
	/// Stop this spawner spawning particles</summary>
	public void StopSpawning()
	{
		StopCoroutine("Spawn");
	}
	
	IEnumerator Spawn()
	{
		while(true)
		{		
			DoSpawn();
			
			yield return new WaitForSeconds(1f/SpawnsPerSecond);
		}		
	}
	
	/// <summary>
	/// Call this to spawn one instance of the particle group (or single particle if SpawnOnlyOneParticle is true)</summary>
	protected abstract void DoSpawn();
}
