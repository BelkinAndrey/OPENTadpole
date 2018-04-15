using UnityEngine;
using System.Collections;

public class Waterfall : MonoBehaviour
{
	private Color nowcol;
	private Color destcol;
	private float desttime;
	private float nowtime;
	private LPParticleGroup pg;
	
	void Start ()
	{
		pg = GetComponent<LPParticleGroup>();
		nowcol = pg._Color;
		destcol = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0.2f,1f));
		StartCoroutine("changecol");
	}
	
	private void setup()
	{
		nowtime = 0f;
		desttime = Random.Range(3f,5f);
		nowcol = destcol;
		destcol = new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0.2f,1f));
		StartCoroutine("changecol");
	}
	
	private IEnumerator changecol()
	{
		while (nowtime < desttime)
		{
			nowtime += Time.deltaTime;
			
			pg._Color = Color.Lerp(nowcol,destcol,nowtime/desttime);
			
			yield return null;
		}
		setup();
	}
}
