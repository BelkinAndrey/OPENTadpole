using UnityEngine;
using System.Collections;

public class TrackParentCamera : MonoBehaviour
{
    private Camera thisCamera;
    private Camera mainCamera;
    public MeshFilter quadFilter;

    // Use this for initialization
    void Start()
    {
        thisCamera = GetComponent<Camera>();
        mainCamera = transform.parent.GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (thisCamera && mainCamera)
        {
            thisCamera.aspect = mainCamera.aspect;
            thisCamera.orthographicSize = mainCamera.orthographicSize;
            //thisCamera.transform.position = mainCamera.transform.position;

            if (quadFilter)
            {
                quadFilter.transform.localScale = new Vector3(thisCamera.orthographicSize * 2f * mainCamera.aspect, thisCamera.orthographicSize * 2f, 1f);
                //quadFilter.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.x, quadFilter.transform.position.z);
            }
        }
    }
}
