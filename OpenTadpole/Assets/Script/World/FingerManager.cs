using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FingerManager : MonoBehaviour {

    public GameObject finger;
    

    void Update() 
    {
            if (finger != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if ((EventSystem.current.currentInputModule as ExtendedStandaloneInputModule).GetNamePointerEvent() == "Raw")
                    {
                        finger.SetActive(true);
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {
                    finger.SetActive(false);
                }

                if (Input.GetMouseButton(0))
                {
                    Vector3 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Pos.z = 0f;
                    finger.transform.position = Pos;
                }
            }
    }

}
