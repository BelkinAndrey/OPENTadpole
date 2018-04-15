using UnityEngine;
using System.Collections;

public class StartStopAimer : MonoBehaviour
{
	public float StartTime = 5f;	
	public float StopTime = 20f;
		
	private bool started;
	private float nowtime = 0f;
	private LPAimer aimer;
	
	void Start()
	{
		aimer = GetComponent<LPAimer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		nowtime += Time.deltaTime;
		
		if (!started && nowtime > StartTime)
		{
			aimer.Active = true;
			started = true;
		}
		else if ( nowtime > StopTime)
		{
			aimer.Active = false;
		}
	}
}
