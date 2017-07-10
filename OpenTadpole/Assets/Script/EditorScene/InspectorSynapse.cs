using UnityEngine;
using System.Collections;

public class InspectorSynapse : MonoBehaviour {

    public Synapse synapse;

    private byte BColor = 0;

    private Color32 startColor = new Color32(255, 255, 255, 100);
    private Color32 endColor = new Color32(255, 255, 255, 100);

    private bool CoroutineStart = false;
    private bool CoroutineEnd = false;

    IEnumerator ColorDynamic() 
    {
        CoroutineStart = false;

        while (BColor < 254)
        {            
            BColor++;
            endColor = new Color32(255, 255, BColor, 255);
            yield return new WaitForSeconds(0.01f);
            endColor = new Color32(255, 255, 255, 100);
        }
    }

    public void ReLocation(GameObject ParentNeuron, GameObject TargetNeuron)
    {
        if (synapse != null)
        {
            Vector3 StartPos = ParentNeuron.transform.position;
            Vector3 EndPos = TargetNeuron.transform.position;
            StartPos.z = 1f;
            EndPos.z = 1f;
            gameObject.GetComponent<LineRenderer>().SetPosition(0, StartPos);
            gameObject.GetComponent<LineRenderer>().SetPosition(1, EndPos);
        }
    }

    public void Delete() 
    {
        Destroy(gameObject);
    }

    public void StartSignal() 
    {
        startColor = new Color32(255, 255, 0, 255);
        endColor = new Color32(255, 255, 255, 100);
        CoroutineEnd = true;
    }

    public void EndSignal() 
    {
        startColor = new Color32(255, 255, 255, 100);
        endColor = new Color32(255, 255, 0, 255);
        CoroutineStart = true;
        BColor = 0;
    }

    void Update() 
    {
        GetComponent<LineRenderer>().SetColors(startColor, endColor);
        if (CoroutineEnd) 
        {
            CoroutineEnd = false;
            StopAllCoroutines(); 
        }
        if (CoroutineStart)
        {
            StopAllCoroutines(); 
            StartCoroutine("ColorDynamic");
        }
    }
}
