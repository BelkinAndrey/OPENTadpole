using UnityEngine;
using System.Collections;

public class AttachMouseQueryToMouse : MonoBehaviour 
{
    private MouseQueryWorldForBody mouseQuery;
    private LPJointMouse mouseJoint;
    LPManager lpMan;

	// Use this for initialization
	void Start ()
    {
        mouseQuery = GetComponent<MouseQueryWorldForBody>();
        lpMan = FindObjectOfType<LPManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (mouseQuery.ClickedBody != null)
        {
            // Attach with mouse joint
            if(mouseJoint == null)
            {
                mouseJoint = gameObject.AddComponent<LPJointMouse>();
                mouseJoint.BodyA = mouseQuery.ClickedBody.gameObject;
                mouseJoint.BodyB = mouseQuery.ClickedBody.gameObject;
                mouseJoint.MaximumForce = 500;
                mouseJoint.Initialise(lpMan);
            }

            bool aTouch = false;
            Vector3 touchPos = new Vector3();
            InputUtilities.GetMouseInput(out aTouch, out touchPos);
            if (aTouch)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(touchPos);
                mouseJoint.SetTarget(mousePos);
            }
        }
        else
        {
           TryDeleteMouseJoint();
        }
	}

    private void TryDeleteMouseJoint()
    {
        if (mouseJoint != null)
        {
            mouseJoint.Delete();
        }
    }
}
