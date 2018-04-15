using UnityEngine;
using System.Collections;

public class GoBetweenScenes : MonoBehaviour
{
	int scenescount = 5;
	
	int currentscene = 0;
	
	void OnGUI()
	{
		if (GUI.Button(new Rect(0,0,Screen.height/8f,Screen.height/8f),"Last Scene") )
		{
			int nextscene = currentscene +1;
			if (nextscene > scenescount -1) nextscene = 0;
			Application.LoadLevel(nextscene); 
			
		}
		else if (GUI.Button(new Rect(Screen.height/8f,0,Screen.height/8f,Screen.height/8f),"Next Scene"))
		{
			int nextscene = currentscene -1;
			if (nextscene < 0) nextscene = scenescount -1; 
			Application.LoadLevel(nextscene); 
		}
	}
}
