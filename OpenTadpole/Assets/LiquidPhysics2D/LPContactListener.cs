using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

/// <summary>
///The contact listener class stores information about contacts.
///There are 2 kinds of conatcts in liquidfun, contacts between 2 fixtures, contacts between 2 particles
///and contacts between a a fixture and a particle.</summary>
public class LPContactListener 
{
	private IntPtr ContactListenerPtr;
	
	/// <summary>
	/// Array of contact data for fixture / fixture contacts that took place during the last step. This is updated on FixedUpdate</summary>	
	public LPContactFixFix[] FixtureFixtureContacts;
	/// <summary>
	/// Array of contact data for fixture / particle contacts that took place during the last step. This is updated on FixedUpdate</summary>
	public LPContactPartFix[] ParticleFixtureContacts;
	/// <summary>
	/// Array of contact data for particle / particle contacts that took place during the last step. This is updated on FixedUpdate</summary>
	public LPContactPartPart[] ParticleParticleContacts;
	
	private int ff = 11;
	private int pf = 6;
	private int pp = 3;
	
	/// <summary>
	/// Get the pointer to the C++ object represented by this object (in this case the contact listener)</summary>
	public IntPtr GetPtr()
	{
		return ContactListenerPtr;
	}
	
	/// <summary>
	/// Create a contact listener object in the simulation</summary>
	public void Initialise(IntPtr worldptr)
	{
		ContactListenerPtr = LPAPIContacts.SetContactListener(worldptr);	
	}
	
	private bool floattoBool(float input)
	{
		if(input == 1f) return true;
		else return false;
	}
	
	/// <summary>
	/// Get the latest contact info from the simulation and parse that infor into easily readable arrays of structs</summary>
	public void Update()
	{
		IntPtr contactinfo = LPAPIContacts.UpdateContactListener(ContactListenerPtr);
		
		//find out how many contacts there were
		float[] info = new float[3];
		Marshal.Copy (contactinfo,info,0,3);
		int fixfixnum = (int)info[0];  
		int fixpartnum = (int)info[1];
		int partpartnum = (int)info[2];  //Debug.Log("fixfix "+fixfixnum +" fixpart "+fixpartnum+ " partpart "+partpartnum );
		int totalnum = 3+ fixfixnum*ff + fixpartnum*pf + partpartnum*pp;
		float[] allinfo = new float[totalnum];
		Marshal.Copy (contactinfo,allinfo,0,totalnum);
		
		//Parse contacts into structsS
		FixtureFixtureContacts = new LPContactFixFix[fixfixnum];
		for (int i = 0; i < fixfixnum; i++)
		{
			FixtureFixtureContacts[i] = new LPContactFixFix
			{
				 BodyAIndex = (int)allinfo[3+(i*ff)]
				,BodyBIndex = (int)allinfo[4+(i*ff)]
				,FixtureAIndex = (int)allinfo[5+(i*ff)]
				,FixtureBIndex = (int)allinfo[6+(i*ff)]
				,ManifoldPoint1 = new Vector3(allinfo[7+(i*ff)],allinfo[8+(i*ff)])
				,ManifoldPoint2 = new Vector3(allinfo[9+(i*ff)],allinfo[10+(i*ff)])
				,Normal = new Vector3(allinfo[11+(i*ff)],allinfo[12+(i*ff)])
				,IsTouching = floattoBool(allinfo[12+(i*ff)])
			};
		}
		
		int start = 3+(fixfixnum*ff);
		ParticleFixtureContacts = new LPContactPartFix[fixpartnum];
		for (int i = 0; i < fixpartnum; i++)
		{
			ParticleFixtureContacts[i] = new LPContactPartFix
			{
				ParticleSystemIndex = (int)allinfo[start+(i*pf)]
				,ParticleIndex = (int)allinfo[start+(i*pf)+1]
				,BodyIndex = (int)allinfo[start+(i*pf)+2]
				,FixtureIndex = (int)allinfo[start+(i*pf)+3]
				,Normal = new Vector3((int)allinfo[start+(i*pf)+4],(int)allinfo[start+(i*pf)+5])
			};
		}
		
		start = 3+(fixfixnum*ff)+(fixpartnum*pf);
		ParticleParticleContacts = new LPContactPartPart[partpartnum];
		for (int i = 0; i < partpartnum; i++)
		{
			ParticleParticleContacts[i] = new LPContactPartPart
			{
				 ParticleSystemIndex = (int)allinfo[start+(i*pp)]
				,ParticleAIndex = (int)allinfo[start+(i*pp)+1]
				,ParticleBIndex = (int)allinfo[start+(i*pp)+2]
				//,Normal = new Vector3((int)allinfo[start+(i*pp)+3],(int)allinfo[start+(i*pp)+4])
			};
		}
	}
}
