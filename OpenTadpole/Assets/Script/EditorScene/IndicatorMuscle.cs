using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IndicatorMuscle : MonoBehaviour {

    private float _Box1 = 0;
    private float Box1 
    {
        get { return _Box1; }
        set 
        {
            if (value > 50) _Box1 = 50;
            else if (value < 0) _Box1 = 0; 
            else _Box1 = value;
        }
    }

    private float dempfer1 = 4f;

    private float _Box2 = 0;
    private float Box2 
    {
        get { return _Box2; }
        set 
        {
            if (value > 10) _Box2 = 10;
            else if (value < 0) _Box2 = 0; 
            else _Box2 = value;
        }
    }

    private float dempfer2 = 2f;

    private float force = 0;

    IEnumerator BoxCor() 
    {
        while (true) 
        {
            if (Box2 > 0)
            {
                Box2 -= dempfer2;
            }

            if (Box1 > 0)
            {
                Box1 -= dempfer1;
                Box2 += dempfer1;
            }

            Box1 += force;
            force = 0;

            yield return new WaitForSeconds(0.05f);
        }
    }

    public void AddForce() 
    {
        force += 5;
    }


    void Start() 
    {
        StartCoroutine("BoxCor");
    }

    void LateUpdate() 
    {
        GetComponent<Image>().fillAmount = Box2 / 10;
    }
}
