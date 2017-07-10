using UnityEngine;
using System.Collections;

public class aquariumManager : MonoBehaviour {

    public GameObject prefabBox;

    public Transform trigger;

    const int X = 12;
    const int Y = 20;

    [ContextMenu("CreateCubes")]
    private void GreateCubes() 
    {
        if (prefabBox != null)
        {
            for (int ix = 0; ix < X; ix++)
            {
                for (int iy = 0; iy < Y; iy++)
                {
                    Vector3 pos = transform.position + new Vector3((iy * 40) + 20, (ix * 40) + 20, 0);
                    GameObject clone = Instantiate(prefabBox, pos, transform.rotation) as GameObject;
                    clone.name = "Segment_" + ix + "_" + iy;
                    if (clone.GetComponent<Segment>()) clone.GetComponent<Segment>().trigger = trigger;
                    clone.transform.parent = transform;
                }
            }
        }
    }

}
