using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

/// <summary>
/// Represents and manages the liquidfun physics simulation world.
/// You will need an instance of this component on a gameobject in your scene in order for the physics simulation to run.</summary>
public class LPManager : MonoBehaviour
{
	[Tooltip("Gravity Vector in the world")]	
	public Vector2 Gravity = new Vector2(0f, -9.81f);	
	[Tooltip("How much time should pass in the simulation every time it steps")]	
	public float TimeStep = 1.0f / 60.0f;	
	[Tooltip("How accurate body velocity calculations should be. Note: More accurate = more expensive")]	
	public int VelocityIterations = 6;	
	[Tooltip("How accurate body position calculations should be. Note: More accurate = more expensive ")]	
	public int m_positionIterations = 2;	
	[Tooltip("Should non-error debug messages appear in unity editor ")]	
	public bool DebugMessages = true;	
	[Tooltip("Override the recommended number of particle iterations")]	
	public bool OverrideParticleIterations;		
	[Tooltip("If overriding use this many particle iterations. Note: less particle iterations can dramatically improve performance. but does so at the cost of a less accurate, more volatile simulation")]
	public int ParticleIterationsOverride = 2;	
	[Tooltip("Use a contact listener. Will reduce performance especially if you have particles with contact listener flags set")]
	public bool UseContactListener = false;		
	private int m_particleIterations = 2;
	
	[HideInInspector]
	public LPParticleSystem[] ParticleSystems;
	
	public LPContactListener ContactListener {get; private set;}
	
	private IntPtr worldPtr;
	
	/// <summary>
	/// Get the pointer to the C++ object represented by this object (In this case it is the world object)</summary>
	public IntPtr GetPtr()
	{
		return worldPtr;
	}	
	
	public Dictionary<int,LPBody> allBodies = new Dictionary<int, LPBody>();
	private int bodiesIndex = 0;
	
	/// <summary>
	/// Pass an LPBody in here after creation to add it to the list of all the bodies in the world and assign it an index</summary>
	public int AddBody(LPBody body)
	{
		allBodies.Add(bodiesIndex,body);
		bodiesIndex++;
		return bodiesIndex -1;
	}

	/// <summary>
	/// Pass the index of an LPBody object in here in order to remove it from the list of all bodies in the world</summary>
	public void RemoveBody(int index)
	{
		allBodies.Remove(index);
	}
	
	/// <summary>
	/// Sets up the physics world and the bodies, particle systems and joints in it.
	/// This is called on Awake() so you can implement your code on Start() and the liquidfun stuff will be ready</summary>				
	void Awake() 
	{
		//Always turn off debug messages in a build (Debug.Log writes to a log file and costs performance)
		if ( !Application.isEditor && !Debug.isDebugBuild)
		{
			DebugMessages = false;
		}
		
		//Check for duplicate LPmanagers
		if(GameObject.FindObjectsOfType<LPManager>().Length > 1)
		{  
			Debug.LogError("There is more than one LiquidFunManager in your scene. There can be only one!");
		}
		else
		{
			//Create contact listener c# object
			ContactListener = new LPContactListener();
			//Create World
			worldPtr = LPAPIWorld.CreateWorld(Gravity.x,Gravity.y);
			if (DebugMessages) Debug.Log("World Created at: 0x" + worldPtr.ToInt64());
			
			//Initialise Contact Listener
			if (UseContactListener)
			{
				ContactListener.Initialise(worldPtr);
			}
			
			//Create bodies
			LPBody[] bodies = GameObject.FindObjectsOfType<LPBody>();
			foreach (LPBody bod in bodies) 
			{
				if (bod.SpawnOnPlay) 
				{
					bod.Initialise(this);
				}
            }
			if (DebugMessages) Debug.Log(bodies.Length + " Bodies created");
			
			//Create Joints
			foreach (LPJoint joint in GameObject.FindObjectsOfType<LPJoint>()) 
			{
				if (joint.GetType() != typeof(LPJointGear))
				{
                    if (joint.SpawnOnPlay)
                    {
                        joint.Initialise(this);
                    }
				}		
			}
			foreach (LPJoint joint in GameObject.FindObjectsOfType<LPJointGear>()) 
			{
                if (joint.SpawnOnPlay)
                {
                    joint.Initialise(this);
                }
			} 
			       
            //Create Particles
			ParticleSystems =  GameObject.FindObjectsOfType<LPParticleSystem>();
			for (int i = 0; i < ParticleSystems.Length; i++)
			{
				ParticleSystems[i].Initialise(worldPtr,DebugMessages,i);	
			}			
			//Set or Determine recommended number of particle iterations
			if (OverrideParticleIterations)
			{
				m_particleIterations = ParticleIterationsOverride;
			}
			else
			{
				m_particleIterations = LPAPIParticleSystems.GetParticleIterations(Gravity.magnitude,ParticleSystems[0].ParticleRadius,TimeStep);
				if (DebugMessages) Debug.Log("Recommended number of particle iterations is "+ m_particleIterations.ToString());
			}
        }
    }

	/// <summary>
	/// The physics world is 'stepped' on fixedupdate
	/// Also if the contact listener is active it is updated at this time</summary>	
    void FixedUpdate() 
	{	
        LPAPIWorld.StepWithParticleIterations(worldPtr, TimeStep, VelocityIterations, m_positionIterations, m_particleIterations);
        if (UseContactListener)
        {
            ContactListener.Update();
        }
	}	
	
	/// <summary>
	/// Update the position and rotation of non static bodies in the world.
	/// The bodies positions and angles are updated in unitys update event handler method.
	/// This is so that this information is only fetched when it is needed (ie when you are going to draw the item associated with the body)
	/// If the frame rate slow this data will be fetched less and will help improve performance.</summary>
	void Update() 
	{
		List<LPBody> bodies = new List<LPBody>();
		
		foreach (KeyValuePair<int,LPBody> bod in allBodies)
		{
			if (bod.Value.shouldUpdate())
			{
				bodies.Add(bod.Value);
			}
		}
	
		if (bodies.Count > 0) 
		{
			IntPtr[] ptrs = new IntPtr[bodies.Count];
			
			for (int i = 0; i < bodies.Count ; i++)
			{
				ptrs[i] = bodies[i].GetPtr();
			}
			
			IntPtr bodinfoptr = LPAPIBody.GetAllBodyInfo(ptrs,bodies.Count);
					  
			float[] bodinfo= new float[bodies.Count*3];
			Marshal.Copy(bodinfoptr,  bodinfo, 0, bodies.Count*3);
			
			for (int i = 0; i < bodies.Count ; i++)
			{
				bodies[i].LPmanUpdate(bodinfo[i*3]
				                      ,bodinfo[(i*3)+1]	
				                      ,bodinfo[(i*3)+2]								
									
				);			
			}
		}
	}	

    public LPBody TestPointForBody(float x, float y)
    {
        int bodyIndex = LPAPIWorld.WorldTestPointForBody(worldPtr, x, y);
        if (bodyIndex == -1)
        {
            return null;
        }
        return allBodies[bodyIndex];
    }
}
