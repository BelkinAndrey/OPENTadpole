using UnityEngine;
using System.Collections;
using System;

public class TapToBounceParticleGroup : MonoBehaviour 
{
    float startZ = 1;
    private LPParticleSystem sys;

	// Use this for initialization
	void Start () {
        sys = GameObject.FindObjectOfType<LPParticleSystem>();
        StartCoroutine("SplitGroup");
	}
	
	// Update is called once per frame
	void Update () {
        if (LPAPIParticleSystems.GetNumberOfParticles(sys.GetPtr()) <= 0)
        {
            return;
        }

        SetPositionToGroupCenteroid();
        MoveGroupToMousePosition();
	}

    private void MoveGroupToMousePosition()
    {
        // Move towards the mouse position
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 diff = mousePos - transform.position;
            diff.Normalize();
            diff.Scale(new Vector3(10000, 10000, 10000));
            LPAPIParticleGroups.ApplyForceToParticleGroup(GetComponent<LPParticleGroup>().GetPtr(), diff.x, diff.y);
        }
    }

    private void SetPositionToGroupCenteroid()
    {
        // Set the position to the particle group center
        LPParticleGroup group = GetComponent<LPParticleGroup>();
        Vector2 center = group.GetCenter();
        if (!(float.IsNaN(center.x)) && !(float.IsNaN(center.y)))
        {
            transform.position = new Vector3(center.x, center.y, startZ);
        }
        else
        {
            transform.position = new Vector3(-1000, -1000, -1000);
        }
    }

    IEnumerator SplitGroup()
    {
        // Splitting a group can be costly so do not perform this operation each frame
        while (LPAPIParticleSystems.GetNumberOfParticles(sys.GetPtr()) > 0)
        {
            LPAPIParticleGroups.SplitParticleGroup(FindObjectOfType<LPManager>().ParticleSystems[0].GetPtr(), FindObjectOfType<LPParticleGroup>().GetPtr());

            IntPtr largestGroup = sys.GetLargestGroupDataFromPlugin();
            GetComponent<LPParticleGroup>().SetThingPtr(largestGroup);
            yield return new WaitForSeconds(1f);
        }
    }
}
