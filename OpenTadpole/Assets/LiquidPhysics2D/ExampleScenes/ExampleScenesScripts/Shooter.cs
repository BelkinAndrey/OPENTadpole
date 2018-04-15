using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using System.Runtime.InteropServices;

public class Shooter : MonoBehaviour
{
	public float ExplosionStrenght = 30f;
	public LPParticleMaterial DebrisMaterial;
	public int ParticleSystemImIn = 0;
	private LPManager lpman;
	private LPRayCaster caster;
	private IntPtr shape;
	public bool AutoShoot;
	public float Shootinterval = 0.5f;
	
	void Start ()
	{
		lpman = FindObjectOfType<LPManager>();
		caster = GetComponent<LPRayCaster>();
		shape = GetComponent<LPFixture>().GetShape();
		
		if(AutoShoot)StartCoroutine("shoot");		
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			Debug.Log(Input.mousePosition);
			oneshot2(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
		
		if (Input.touchCount > 0)
		{			
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				oneshot2(Camera.main.ScreenToWorldPoint(new Vector3(Input.touches[0].position.x,Input.touches[0].position.y)));
			}
		}
		
		#if UNITY_EDITOR || UNITY_STANDALONE
		if (Input.GetMouseButtonDown(0))
		{
			oneshot2(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
		#endif
	}
	
	private void oneshot2(Vector3 pos)
	{		
		IntPtr partsysptr = lpman.ParticleSystems[ParticleSystemImIn].GetPtr();
        IntPtr worldPtr = lpman.GetPtr();
        IntPtr particlesPointer = LPAPIParticleSystems.GetParticlesInShape(worldPtr, partsysptr
		                                                                   ,shape,pos.x,pos.y
		                                                                   ,transform.rotation.eulerAngles.z);
		
		int[] particlesArray = new int[1];
		Marshal.Copy (particlesPointer,particlesArray,0,1);
		int foundNum = particlesArray[0];
		
		if (foundNum > 0) 
		{	
			int[] Indices = new int[foundNum+1];
			Marshal.Copy(particlesPointer, Indices, 0, foundNum+1);
			
			LPAPIParticles.SetSelectedParticleFlags(partsysptr,Indices,DebrisMaterial.GetInt());
			LPAPIParticles.SetSelectedParticleUserData(partsysptr,Indices,2);
			LPAPIParticles.ExplodeSelectedParticles(partsysptr,Indices,pos.x,pos.y,ExplosionStrenght);
		}				
	}
	
	
	private void oneshot()
	{		
		LPRayCastHit[] hits = caster.RaycastWorld();
		if (hits.Length > 0)
		{
			hits  = hits.OrderBy(d => d.Fraction).ToArray();
			
			
			
			IntPtr partsysptr = lpman.ParticleSystems[ParticleSystemImIn].GetPtr();
            IntPtr worldPtr = lpman.GetPtr();
            IntPtr particlesPointer = LPAPIParticleSystems.GetParticlesInShape(worldPtr, partsysptr
			                                                                   ,shape,hits[0].Position.x,hits[0].Position.y
			                                                                   ,transform.rotation.eulerAngles.z);
			
			int[] particlesArray = new int[1];
			Marshal.Copy (particlesPointer,particlesArray,0,1);
			int foundNum = particlesArray[0];
			
			
			if (foundNum > 0) 
			{	
				int[] Indices = new int[foundNum+1];
				Marshal.Copy(particlesPointer, Indices, 0, foundNum+1);
				
				LPAPIParticles.SetSelectedParticleFlags(partsysptr,Indices,DebrisMaterial.GetInt());
				LPAPIParticles.SetSelectedParticleUserData(partsysptr,Indices,2);
				LPAPIParticles.ExplodeSelectedParticles(partsysptr,Indices,hits[0].Position.x,hits[0].Position.y,ExplosionStrenght);
			}		
		}			
	}
	
	
	private IEnumerator shoot()
	{
		while (true)
		{
			yield return new WaitForSeconds(Shootinterval);		
			oneshot();
		}
	}
}
