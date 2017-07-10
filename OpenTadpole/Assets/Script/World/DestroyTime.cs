using UnityEngine;
using System.Collections;

public class DestroyTime : MonoBehaviour {

    public float DestroyTim = 0.1f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("DestroyT");
    }

    IEnumerator DestroyT()
    {
        yield return new WaitForSeconds(DestroyTim);

        Destroy(gameObject);
    }
}
