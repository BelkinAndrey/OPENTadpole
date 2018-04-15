using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

public class LPRayCaster : MonoBehaviour {
	
	public bool QueryParticleSystem = true;
	public LPRaycastModes Mode = LPRaycastModes.HitEverything; 
	public GameObject StartPoint;
	public GameObject EndPoint;
	LPManager lpman;
		
	// Use this for initialization
	void Start ()
	{
		#if UNITY_EDITOR
		if(FindObjectOfType<LPManager>() == null)
		{
			Debug.LogError("There is no LPManager. You must have one in your scene for Liquid Physics 2D to work");
			return;
		}
		#endif
		lpman = FindObjectOfType<LPManager>();	
	}
	
	public LPRayCastHit[] RaycastWorld()
	{
		IntPtr RayCastInfo = LPAPIRaycast.RaycastWorld(lpman.GetPtr()
		                                               ,StartPoint.transform.position.x,StartPoint.transform.position.y
		                                               ,EndPoint.transform.position.x,EndPoint.transform.position.y
		                                               ,(int)Mode,QueryParticleSystem);
		
		//find out how many hits there were
		float[] info = new float[2];
		Marshal.Copy (RayCastInfo,info,0,2);
		int fixnum = (int)info[0];
		int partnum = (int)info[1];
		int totalhits = fixnum+partnum;
		
		//get the hit data
		int num = 2+(totalhits*7);
		float[] allinfo = new float[num];
		Marshal.Copy (RayCastInfo,allinfo,0,num);
		//LPAPIUtility.ReleaseFloatArray(RayCastInfo);
		
		//create and return objects to represent the data	
		LPRayCastHit[] hits = new LPRayCastHit[totalhits];
	
		for (int i = 0; i < totalhits; i++)
		{
			LPRayCastHitType hittype;
			if (i < fixnum) hittype = LPRayCastHitType.LPFixture;
			else hittype = LPRayCastHitType.LPParticle;
			
			hits[i] = new LPRayCastHit()
			{
			 WhatDidIHit = hittype	
			,ParentIndex = (int)allinfo[2+(7*i)]
			,Index = (int)allinfo[3+(7*i)]
			,Position = new Vector3(allinfo[4+(7*i)],allinfo[5+(7*i)])
			,Normal = new Vector3(allinfo[6+(7*i)],allinfo[7+(7*i)])
			,Fraction = allinfo[8+(7*i)]
			};
		}
				
		return hits;	
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = LPColors.Raycast;
		Gizmos.DrawLine(StartPoint.transform.position,EndPoint.transform.position);
	}
}
