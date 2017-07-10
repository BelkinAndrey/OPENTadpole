using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.IO;

public class GUIInterface : MonoBehaviour {

    public GUISkin skin;

    public Texture2D CloseButton;
    public Texture2D FullButton;
    public Texture2D ClearButton;
    public Texture2D OpenButton;
    public Texture2D SaveButton;
    public Texture2D DownButton;

    public Texture2D LogoButton;

    //public string TextLoad = "";

    private bool pilot = false;
    Vector2 ScrollBlok;

    int W = 800;
    int H = 600;

    Resolution[] resolutions;

    public UnityEvent MouseWindowsOn = new UnityEvent();
    public UnityEvent MouseWindowsExit = new UnityEvent();

    private bool _OnRect = false;
    private bool OnRect
    {
        get { return _OnRect; }
        set
        {
            if (_OnRect != value)
            {
                if (value) { MouseWindowsOn.Invoke(); }
                else { MouseWindowsExit.Invoke(); }
            }
            _OnRect = value;
        }
    }
    

    void Start() 
    {
        resolutions = Screen.resolutions;
    }

    void OnGUI()
    {
        GUI.skin = skin;

        GUI.Box(new Rect(0, 0, Screen.width, 30), "");

        if (GUI.Button(new Rect(0, 0, 140, 30), LogoButton)) 
        {
            Application.OpenURL("https://github.com/BelkinAndrey/OPENTadpole");
        }

        GUI.Label(new Rect(150, 5, 170, 30), ">> ConnectomTadpole <<");

        if (GUI.Button(new Rect(325, 0, 115, 30), " SimWorldTadpole")) 
        {
             Application.LoadLevel(1);
        }

        if (GUI.Button(new Rect(Screen.width - 30, 0, 30, 30), CloseButton))
        {
            Application.Quit();
        }

        if (GUI.Button(new Rect(Screen.width - 60, 0, 30, 30), FullButton))
        {
            if (!Screen.fullScreen)
            {
                W = Screen.width;
                H = Screen.height;
                Screen.fullScreen = true;
                Screen.SetResolution(resolutions[resolutions.Length - 1].width, resolutions[resolutions.Length - 1].height, true);
            }
            else
            {
                Screen.fullScreen = false;
                Screen.SetResolution(W, H, false);
            }
        }

        GetComponent<SaveOpen>().PathFile = GUI.TextField(new Rect(Screen.width - 260, 5, 180, 20), GetComponent<SaveOpen>().PathFile);

        if (GUI.Button(new Rect(Screen.width - 80, 0, 20, 30), DownButton)) 
        {
            pilot = !pilot;
        }

        if (GUI.Button(new Rect(Screen.width - 350, 0, 30, 30), ClearButton)) 
        {
            PlayerPrefs.SetString("Path", "");
            PlayerPrefs.SetFloat("StartZoom", 3200);
            PlayerPrefs.SetFloat("CamX", 0);
            PlayerPrefs.SetFloat("CamY", -1840);
            PlayerPrefs.SetFloat("CamZ", -100);
            Application.LoadLevel(0);
        }

        if (GUI.Button(new Rect(Screen.width - 320, 0, 30, 30), OpenButton))
        {
            GetComponent<SaveOpen>().Open();
        }

        if (GUI.Button(new Rect(Screen.width - 290, 0, 30, 30), SaveButton))
        {
            GetComponent<SaveOpen>().Save();
        }

        if (pilot)
        {
            Rect RectPilot = new Rect(Screen.width - 260, 35, 200, 200);
            OnRect = RectPilot.Contains(Event.current.mousePosition);

            GUILayout.BeginArea(RectPilot, GUI.skin.box);
            ScrollBlok = GUILayout.BeginScrollView(ScrollBlok, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));

            string[] dir = Directory.GetFiles(Application.dataPath + "/Data/", "*.tad");
            foreach (string value in dir) 
            {
                GUILayout.BeginHorizontal();
                string v = value.Remove(value.Length - 4).Remove(0, Application.dataPath.Length + 6);
                if (GUILayout.Button(v))
                {
                    GameObject C = GameObject.Find("Camera");
                    PlayerPrefs.SetFloat("StartZoom", C.GetComponent<Camera>().orthographicSize);
                    PlayerPrefs.SetFloat("CamX", C.transform.position.x);
                    PlayerPrefs.SetFloat("CamY", C.transform.position.y);
                    PlayerPrefs.SetFloat("CamZ", C.transform.position.z);

                    PlayerPrefs.SetString("Path", v);
                    Application.LoadLevel(0);
                }
                GUILayout.EndHorizontal();
            }

            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }
    }
}
