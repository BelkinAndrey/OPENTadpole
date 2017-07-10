using UnityEngine;
using System.Collections;

public class MotionCameraWorld : MonoBehaviour {

    public float StartZoom;
    public float SpeedZoom;
    public float MinZoom;
    public float MaxZoom;

    private bool EnableMotion = true;

    private float Zoom;

    private Vector3 PositionMouse;
    private Vector3 NewCameraPosition;

    void Start()
    {
        Zoom = StartZoom;
    }

    void LateUpdate()
    {
        if (EnableMotion)
        {
            Zoom += Input.GetAxis("Mouse ScrollWheel") * (SpeedZoom * Camera.main.orthographicSize);
            Zoom = Mathf.Clamp(Zoom, MinZoom, MaxZoom);
            Camera.main.orthographicSize = Zoom;

            if (Input.GetMouseButton(2))
            {
                NewCameraPosition = PositionMouse - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                gameObject.transform.position += NewCameraPosition;
            }

            PositionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    public void SetEnableMotion(bool value)
    {
        EnableMotion = value;
    }
}
