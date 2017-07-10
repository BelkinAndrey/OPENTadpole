using UnityEngine;
using System.Collections;

public class MotionCamera : MonoBehaviour {

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
        if (PlayerPrefs.HasKey("StartZoom")) Zoom = PlayerPrefs.GetFloat("StartZoom");
        else Zoom = StartZoom;
        if (PlayerPrefs.HasKey("CamX") && PlayerPrefs.HasKey("CamY") && PlayerPrefs.HasKey("CamZ")) transform.position =
            new Vector3(PlayerPrefs.GetFloat("CamX"), PlayerPrefs.GetFloat("CamY"), PlayerPrefs.GetFloat("CamZ"));
    }

    void LateUpdate ()
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

    void OnApplicationQuit() 
    {
        PlayerPrefs.SetFloat("StartZoom", StartZoom);
        PlayerPrefs.SetFloat("CamX", 0);
        PlayerPrefs.SetFloat("CamY", -1840);
        PlayerPrefs.SetFloat("CamZ", -100);
    }
}
