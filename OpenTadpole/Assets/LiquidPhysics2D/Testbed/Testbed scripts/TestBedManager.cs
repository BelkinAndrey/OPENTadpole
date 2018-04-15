using UnityEngine;
using System.Collections;

public class TestBedManager : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		Input.multiTouchEnabled = false; 
		DontDestroyOnLoad(gameObject);
	}
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit(); 
	}
		
	void OnGUI()
	{
		if (GUI.Button(new Rect(0,0,Screen.height/4f,Screen.height/4f),"Last Scene") )
		{
			int nextscene = Application.loadedLevel -1;
			if (nextscene < 0) nextscene = Application.levelCount -1; 
			Application.LoadLevel(nextscene); 
		}
		else if (GUI.Button(new Rect(Screen.width - Screen.height/4f,0,Screen.height/4f,Screen.height/4f),"Next Scene"))
		{			
			int nextscene = Application.loadedLevel +1;
			if (nextscene > Application.levelCount -1) nextscene = 0;
			Application.LoadLevel(nextscene); 	
		}
	}
}
