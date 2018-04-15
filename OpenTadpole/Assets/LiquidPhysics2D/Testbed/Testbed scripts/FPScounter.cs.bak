using UnityEngine;
using System.Collections;

public class FPScounter : MonoBehaviour
{
	 public float updateInterval = 0.5f;
	
	 float accum = 0.0f; 
	 int frames = 0; 
	 float timeleft; 	
	 TextMesh textm;
	
	// Use this for initialization
	void Start ()
	{
		timeleft = updateInterval; 
		textm = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		timeleft -= Time.deltaTime;
		accum += Time.timeScale/Time.deltaTime;
		++frames;
		
		if( timeleft <= 0.0f )
		{
			textm.text = (accum/frames).ToString("f2");
			timeleft = updateInterval;
			accum = 0.0f;
			frames = 0;
		}
	}
}
