using UnityEngine;
using System.Collections;

public class StopAfterSeconds : MonoBehaviour {

	public LPParticleSpawner[] Spawners;
	public LPJointRevolute joint;
	public float StopTime = 4f;
	public float StartTime = 12f;
	float nowtime;
	bool on = true;
		
	void Start()
	{
		StartCoroutine("dostuff");
	}
	
	IEnumerator dostuff()
	{
		while(on)
		{
			nowtime += Time.deltaTime;
			if(nowtime >= StopTime)
			{
				foreach(LPParticleSpawner spawner in Spawners)
				{
					spawner.StopSpawning();
				}
			}			
			if(nowtime >= StartTime)
			{	
				LPAPIJoint.SetRevoluteJointMotorSpeed(joint.GetPtr(),15f);
				on = false;
			}
			yield return null;
		}
	}
}
