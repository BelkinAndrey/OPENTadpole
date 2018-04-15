using UnityEngine;
using System;

public abstract class LPJoint : LPThing
{
    [Tooltip("Should this joint spawn on play")]
    public bool SpawnOnPlay = true;
	[Tooltip("Gameobject with 1st body attached to this joint")]
	public GameObject BodyA;
	[Tooltip("Gameobject with 2nd body attached to this joint")]
	public GameObject BodyB;
	[Tooltip("Should the bodies connected by this joint collide with each other?")]
	public bool CollideConnected = false;
	
	protected LPManager lpman;

    public bool initialised = false;
	
	/// <summary>Create this joint in the simulation</summary>	
	public void Initialise(LPManager man)
	{
        lpman = man;
		if (BodyA !=null && BodyB !=null && BodyA.GetComponent<LPBody>() != null && BodyB.GetComponent<LPBody>() != null)
		{
            if (BodyA.GetComponent<LPBody>().Initialised && BodyB.GetComponent<LPBody>().Initialised)
            {
			    Initialise2(lpman.GetPtr());
                initialised = true;
            }
		}
		else Debug.LogError("The " + gameObject.name + " Joint must be assigned 2 Bodies to connect in order to be created");
	}
	
	protected abstract void Initialise2(IntPtr world);
	
	/// <summary>Delete this joint, in the simulation and in unity</summary>	
	public override void Delete()
	{
		LPAPIJoint.DeleteJoint(lpman.GetPtr(),ThingPtr);
		Destroy(this);
	}

    public void Update()
    {
        if (!initialised)   // Initialise the joints which have not been initialised on play
        {
            if (BodyA != null && BodyB != null)
            {
                if (BodyA.GetComponent<LPBody>().Initialised && BodyB.GetComponent<LPBody>().Initialised)
                {
                    Debug.Log("GameObject : " + gameObject.name + ", spawned joint.");
                    Initialise(lpman);
                }
            }
        }
    }

    internal void SetLPman(LPManager lPManager)
    {
        this.lpman = lPManager;
    }
}
