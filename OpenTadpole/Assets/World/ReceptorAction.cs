using UnityEngine;
using System.Collections;

public class ReceptorAction : MonoBehaviour {

    public GameObject manager;
    public int index;

    void OnTriggerStay2D(Collider2D other) 
    {
        if (other.tag != "food")
        {
            if (manager != null) manager.GetComponent<ManagerWorld>().SetSignal(index);
        }
        else 
        {
            if (index == 0) 
            {
                Destroy(other.gameObject);
                manager.GetComponent<HungerManager>().satiety.value = 100;
                manager.GetComponent<PowerManager>().fatigue.value = 0;
            }
        }
    }
}
