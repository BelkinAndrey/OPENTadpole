using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class SelectionNeuron : MonoBehaviour {

    public UnityEvent SelectOn = new UnityEvent();
    public UnityEvent SelectOff = new UnityEvent();
    public UnityEvent MultiSelectOn = new UnityEvent();

    public GameObject SelectorNeuronOne;
    public List<GameObject> SelectionList = new List<GameObject>();

    public void RayOn(GameObject Object) 
    {
        if ((SelectorNeuronOne != null) && (Object == null)) SelectOff.Invoke();
        Deselct();
        SelectorNeuronOne = Object;
        if (Object != null) SelectOn.Invoke(); 
    }

    public void SelOff() 
    {
        SelectorNeuronOne = null;
        SelectOff.Invoke();
        Deselct();
    }

    public void SelectionRect(Rect rect) 
    {
        SelOff();
        Deselct();
        Vector2 point1 = Camera.main.ScreenToWorldPoint(new Vector2(rect.xMax, Screen.height - rect.yMax));
        Vector2 point2 = Camera.main.ScreenToWorldPoint(new Vector2(rect.xMin, Screen.height - rect.yMin));
        Collider2D[] hit = Physics2D.OverlapAreaAll(point1, point2, 1 << 8);
        if (hit.Length > 0)
        {
            if (hit.Length == 1)
            {
                RayOn(hit[0].gameObject);
                SelectionList.Clear();
            }
            else
            {
                for (int i = 0; i < hit.Length; i++)
                {
                    SelectionList.Add(hit[i].gameObject);
                    hit[i].gameObject.transform.localScale = new Vector3(2f, 2f, 1f);
                }
                MultiSelectOn.Invoke();
            }
        }
    }

    void Deselct() 
    {
        for (int i = 0; i < SelectionList.Count; i++) 
        {
            SelectionList[i].transform.localScale = new Vector3(1f, 1f, 1f);
        }
        SelectionList.Clear();
    }
}
