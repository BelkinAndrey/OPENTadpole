using UnityEngine;
using System.Collections;

public class sprayacid : MonoBehaviour {

	public LPParticleSpawner spawner;
	public GameObject target;
	
	void Update()
	{
		if (Input.touchCount > 0)
		{		
			target.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.touches[0].position.x,Input.touches[0].position.y));
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				spawner.StartSpawning();
			}
			else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
			{
				spawner.StopSpawning();
			}
		}
		
		#if UNITY_EDITOR || UNITY_STANDALONE
		target.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (Input.GetMouseButtonDown(0))
		{
			spawner.StartSpawning();
		}
		if (Input.GetMouseButtonUp(0))
		{
			spawner.StopSpawning();
		}
		#endif
	}
}
