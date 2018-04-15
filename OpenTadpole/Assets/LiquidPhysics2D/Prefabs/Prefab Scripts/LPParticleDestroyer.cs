using UnityEngine;
using System.Collections;
using System;

public class LPParticleDestroyer : MonoBehaviour
{
	public int ParticleSystemImIn = 0;
	private LPParticleSystem sys;
	private IntPtr Shape;
	
	void Start()
	{
		sys = FindObjectOfType<LPManager>().ParticleSystems[ParticleSystemImIn];
		Shape = GetComponent<LPFixture>().GetShape();
	}
	
	void FixedUpdate ()
	{
		LPAPIParticleSystems.DestroyParticlesInShape(sys.GetPtr(),Shape,transform.position.x,transform.position.y
					,Mathf.Deg2Rad*transform.rotation.eulerAngles.z,false);
	}
}
