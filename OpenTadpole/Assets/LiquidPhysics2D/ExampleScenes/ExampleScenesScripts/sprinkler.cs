using UnityEngine;
using System.Collections;

public class sprinkler : MonoBehaviour
 {
	public float desttime = 3f;
	public float speed = 5f;
	private float nowtime;
	private float mult = 1f;
	
	private float startx;
	
	void Start ()
	{
		StartCoroutine("spray");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	private IEnumerator spray()
	{
		while (true)
		{
			nowtime += Time.deltaTime;
			if (nowtime > desttime)
			{
				nowtime = 0f;
				mult *=-1f;	
			}			
			transform.Translate(speed*Time.deltaTime*mult,0f,0f);
			
			yield return null;
		}
	}
}
