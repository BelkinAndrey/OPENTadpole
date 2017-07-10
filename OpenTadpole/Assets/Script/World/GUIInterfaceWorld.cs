using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.IO;

public class GUIInterfaceWorld : MonoBehaviour {

    public GUISkin skin;

    public Texture2D CloseButton;
    public Texture2D FullButton;
    public Texture2D ReStartButton;
    public Texture2D OpenButton;
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

        GUI.Label(new Rect(150, 5, 170, 30), ">> SimWorldTadpole <<");

        if (GUI.Button(new Rect(325, 0, 125, 30), " ConnectomTadpole"))
        {
            Application.LoadLevel(0);
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

        GetComponent<LoadBrain>().PathFile = GUI.TextField(new Rect(Screen.width - 260, 5, 180, 20), GetComponent<LoadBrain>().PathFile);

        if (GUI.Button(new Rect(Screen.width - 80, 0, 20, 30), DownButton))
        {
            pilot = !pilot;
        }



        if (GUI.Button(new Rect(Screen.width - 320, 0, 30, 30), ReStartButton))
        {
            Application.LoadLevel(1);
        }

        if (GUI.Button(new Rect(Screen.width - 290, 0, 30, 30), OpenButton))
        {
            GetComponent<LoadBrain>().Open(); 
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
                    PlayerPrefs.SetString("Path", v);
                    Application.LoadLevel(1);
                }
                GUILayout.EndHorizontal();
            }

            GUILayout.EndScrollView();
            GUILayout.EndArea();
        }
    }
}
