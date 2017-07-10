using UnityEngine;
using System.Collections;

public class KeyVisio : MonoBehaviour {

    public ParticleRenderer PR;

	void Update () {

        if (Input.GetKeyDown(KeyCode.F12)) 
        {
            PR.enabled = !PR.enabled;
        }
	
	}
}
