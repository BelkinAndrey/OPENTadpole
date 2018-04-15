using UnityEngine;
using System.Collections;

public class taptogglepump : MonoBehaviour
{
	public LPParticleAccelerator pump;
	
	void Update()
	{
		if (Input.touchCount > 0)
		{			
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				pump.Active = !pump.Active;
			}
		}	
		#if UNITY_EDITOR || UNITY_STANDALONE
		if (Input.GetMouseButtonDown(0))
		{
			pump.Active = !pump.Active;
		}
		#endif
	}	
}
