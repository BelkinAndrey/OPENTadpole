using UnityEngine;
using System.Collections;
using System;

public class Melter : MonoBehaviour
{	
	public float waittime  = 1f;
	private LPParticleSystem sys;
	private LPParticleGroup group;
    public LPParticleMaterial mat;
	
	void Start ()
	{
		group = GetComponent<LPParticleGroup>();
		sys = FindObjectOfType<LPManager>().ParticleSystems[group.ParticleSystemImIn];
		StartCoroutine("Melt");
	}
	
	private IEnumerator Melt()
	{
		yield return new WaitForSeconds(waittime);
        if (mat != null) LPAPIParticleGroups.SetParticleFlagsInGroup(sys.GetPtr(), group.GetPtr(), mat.GetInt());
        else LPAPIParticleGroups.SetParticleFlagsInGroup(sys.GetPtr(), group.GetPtr(),0);
	
		Debug.Log("flags set");
	}
}
