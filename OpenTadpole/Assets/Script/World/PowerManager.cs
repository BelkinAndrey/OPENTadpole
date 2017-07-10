using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PowerManager : MonoBehaviour {

    public Image power;

    public Slider fatigue;
    public Slider endurance;

    private int counter = 1;

    public JointTadLP j;

    void FixedUpdate()
    {
        float b = power.color.b;
        if (b < 1f)
        {
            b += 0.05f;
            if (b > 1) b = 1;
            power.color = new Color(1, 1, b, 1);
        }

        float v = 100 - fatigue.value;
        if (v != 100)
        {
            if (v == 0) UpPower();
            else if (counter % v == 0) UpPower();
        }

        if (endurance.value != 100)
        {
            if (j.reduction > endurance.value)
            {
                if (fatigue.value != 100) fatigue.value++;
                j.reduction = 0;
            }
        }

        counter++;
        if (counter > 100000000) counter = 1;
    }

    private void UpPower()
    {
        power.color = new Color(1, 1, 0, 1);
        gameObject.GetComponent<ManagerWorld>().SetSignal(33);
    }

    private void UpFatigue() 
    {
        if ((EventSystem.current.currentInputModule as ExtendedStandaloneInputModule).GetNamePointerEvent() != "SliderPower1") 
        {
            if (fatigue.value != 100) fatigue.value++;
        }
    }
}
