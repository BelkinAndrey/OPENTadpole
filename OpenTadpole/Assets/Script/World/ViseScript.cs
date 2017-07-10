using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ViseScript : MonoBehaviour {

    public Sprite VOff;
    public Sprite VOn;

    public SpriteRenderer vise;

    public bool OnOff = false;

    public GameObject head;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F6))
        {
            if (gameObject.GetComponent<Image>())
            {
                OnOff = !OnOff;
                vise.enabled = OnOff;
                if (OnOff)
                {
                    gameObject.GetComponent<Image>().sprite = VOn;

                    LPAPIBody.SetBodyType(head.GetComponent<LPBody>().GetPtr(), (int)LPBodyTypes.Static);
                }
                else
                {
                    gameObject.GetComponent<Image>().sprite = VOff;

                    LPAPIBody.SetBodyType(head.GetComponent<LPBody>().GetPtr(), (int)LPBodyTypes.Dynamic);
                }
            }
        }
    }
}
