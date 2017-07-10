using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HungerManager : MonoBehaviour {

    public Image hanger;

    public Slider satiety;
    public Slider voracity;

    private int counter = 1;

    void FixedUpdate()
    {
        float b = hanger.color.b;
        if (b < 1f)
        {
            b += 0.05f;
            if (b > 1) b = 1;
            hanger.color = new Color(1, 1, b, 1);
        }

        if (satiety.value != 100) 
        {
            if (satiety.value == 0) UpHanger();
            else if (counter % satiety.value == 0) UpHanger();
        }

        float v = 100 - voracity.value;
        if (v != 100) 
        {
            if (v == 0) DownSatiety();
            else if (counter % (v * 5) == 0) DownSatiety();
        }

        counter++;
        if (counter > 100000000) counter = 1;
    }

    private void UpHanger()
    {
        hanger.color = new Color(1, 1, 0, 1);
        gameObject.GetComponent<ManagerWorld>().SetSignal(32);
    }

    private void DownSatiety() 
    {
        if ((EventSystem.current.currentInputModule as ExtendedStandaloneInputModule).GetNamePointerEvent() != "SliderHunger1") 
        {
            if (satiety.value != 0) satiety.value--;
        }
    } 
}
