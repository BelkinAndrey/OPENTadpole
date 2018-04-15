using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

public class tapmine : MonoBehaviour {
	

	public float ExplosionStrenght = 30f;
	public int ParticleSystemImIn = 0;
	
	public LPFixture ExplosionShape;
	
	private LPManager lpman;
	private IntPtr shape;
	
	void Start ()
	{
		lpman = FindObjectOfType<LPManager>();
		shape = ExplosionShape.GetShape();
	}
	
	void Splode(Vector3 splodepos)
	{
		Vector3 pos = Camera.main.ScreenToWorldPoint(splodepos);
		
		IntPtr partsysptr = lpman.ParticleSystems[ParticleSystemImIn].GetPtr();
        IntPtr worldPtr = lpman.GetPtr();
        IntPtr particlesPointer = LPAPIParticleSystems.GetParticlesInShape(worldPtr, partsysptr
		                                                                   ,shape,pos.x,pos.y
		                                                                   ,0f);
		
		int[] particlesArray = new int[1];
		Marshal.Copy (particlesPointer,particlesArray,0,1);
		int foundNum = particlesArray[0];
		
		
		if (foundNum > 0) 
		{	
			int[] Indices = new int[foundNum+1];
			Marshal.Copy(particlesPointer, Indices, 0, foundNum+1);
			
			LPAPIParticles.ExplodeSelectedParticles(partsysptr,Indices,pos.x,pos.y,ExplosionStrenght);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.touchCount > 0)
		{			
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				Splode(Input.touches[0].position);
			}	
		}
		
		#if UNITY_EDITOR || UNITY_STANDALONE
		if (Input.GetMouseButtonDown(0))
		{
			Splode(Input.mousePosition);
		}
		#endif
	}
}
