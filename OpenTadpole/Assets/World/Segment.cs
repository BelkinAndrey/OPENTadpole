using UnityEngine;
using System.Collections;

public class Segment : MonoBehaviour {

    public GameObject prefabBox;
    public GameObject WaterBox;

    public Transform trigger;

    private LPManager lpman;

    private Bounds bound;
    private GameObject _box;
    private int _state = 0;

    private int state 
    {
        get { return _state; }
        set 
        {
            if ((value == 0) && (_state != 0)) 
            {
                if (_box != null) 
                {
                    lpman.allBodies[_box.GetComponent<LPBody>().myIndex].Delete();
                    Destroy(_box); 
                }
            }

            if ((value == 1) && (_state != 1)) 
            {
                if (prefabBox != null) 
                {
                    GameObject clone = Instantiate(prefabBox, transform.position, transform.rotation) as GameObject;
                    clone.name = "Box";
                    clone.transform.parent = transform;
                    _box = clone;

                    LPAPIParticleSystems.DestroyParticlesInShape(lpman.ParticleSystems[0].GetPtr(), clone.GetComponent<LPFixture>().GetShape(),
                        transform.position.x, transform.position.y, 0, false);

                    clone.GetComponent<LPBody>().Initialise(lpman);
                }
            }

            if ((value == 2) && (_state != 2)) 
            {
                if (_box != null)
                {
                    lpman.allBodies[_box.GetComponent<LPBody>().myIndex].Delete();
                    Destroy(_box);
                }

                if (WaterBox != null) 
                {
                    WaterBox.GetComponent<LPParticleGroupBox>().Initialise(lpman.ParticleSystems[0]);
                }
            } 

            _state = value;
        }
    }

    void Start() 
    {
        bound = new Bounds(transform.position, new Vector3(5, 5, 0));
        lpman = FindObjectOfType<LPManager>();
    }

    void Update() 
    {
        RunSegment();
    }

    private void RunSegment() 
    {
        Bounds RBoundBig = new Bounds(trigger.position, new Vector3(230, 230, 0));
        Bounds RBoundSmall = new Bounds(trigger.position, new Vector3(150, 150, 0));

        if (RBoundBig.SqrDistance(transform.position) < 25) 
        {
            if (RBoundBig.Intersects(bound)) 
            {
                if (RBoundSmall.Intersects(bound))
                {
                    state = 2;
                }
                else 
                {
                    state = 1;
                } 
            }
        } else if (state != 0) state = 0;
    }
}
