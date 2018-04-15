using UnityEngine;
using System.Collections;

public class taptogglespawner : MonoBehaviour
{
	bool on = false;
	public LPParticleSpawner spawner;
	
	void Update()
	{
		if ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
		{			
			on = !on;
			if (on)
			{
				spawner.StartSpawning();
			}
			else
			{
				spawner.StopSpawning();
			}
		}
	}	
}
