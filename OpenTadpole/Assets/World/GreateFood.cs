using UnityEngine;
using System.Collections;

public class GreateFood : MonoBehaviour {

    public GameObject prefabFood;
    public Sprite[] sprites;

    public HeadTadpole head;

    void Update() 
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            Vector3 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Pos.z = 0f;

            if (prefabFood != null)
            {
                Collider2D[] hit = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (hit.Length > 0)
                {
                    if (hit[0].tag == "food") 
                    {
                        Destroy(hit[0].gameObject);
                    }

                }
                else
                {
                    GameObject clone = Instantiate(prefabFood, Pos, transform.rotation) as GameObject;
                    clone.name = "food";
                    clone.transform.Rotate(Vector3.forward, Random.Range(-20f, 20f));

                    if (head != null) clone.GetComponent<FoodManager>().head = head;
                    clone.GetComponent<FoodManager>().manager = gameObject;

                    clone.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
                }
            }
        }
    }
}
