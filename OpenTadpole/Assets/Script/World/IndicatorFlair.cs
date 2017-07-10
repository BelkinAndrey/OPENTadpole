using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IndicatorFlair : MonoBehaviour {

    public Image LeftIndicator;
    public Image RightIndicator;

    void FixedUpdate()
    {
        float bL = LeftIndicator.color.b;
        if (bL < 1f) 
        {
            bL += 0.05f;
            if (bL > 1) bL = 1;
            LeftIndicator.color = new Color(1, 1, bL, 1);
        }

        float bR = RightIndicator.color.b;
        if (bR < 1f)
        {
            bR += 0.05f;
            if (bR > 1) bR = 1;
            RightIndicator.color = new Color(1, 1, bR, 1);
        }
    }

    public void LeftUp() 
    {
        LeftIndicator.color = new Color(1, 1, 0, 1);
        gameObject.GetComponent<ManagerWorld>().SetSignal(34);
    }

    public void RightUp() 
    {
        RightIndicator.color = new Color(1, 1, 0, 1);
        gameObject.GetComponent<ManagerWorld>().SetSignal(35);
    }
}
