using UnityEngine;
using System.Collections;

public class countercolor : MonoBehaviour {

	public Color _Color;
	
	// Use this for initialization
	void Start ()
	{
		foreach (TextMesh txt in GetComponentsInChildren<TextMesh>()) 
		{
			txt.color = _Color;
		}
	}	
}
