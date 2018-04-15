using UnityEngine;
using System.Collections;

public class counter : MonoBehaviour
{
	public TextMesh txt;
	LPManager lpman;
	
	// Use this for initialization
	void Start ()
	{
		lpman = FindObjectOfType<LPManager>();
		StartCoroutine("howmany");
	}
	
	
	IEnumerator howmany()
	{
		while(true)
		{
			yield return new WaitForSeconds(0.5f);
			
			int count = 0;
			if (lpman.ParticleSystems.Length == 1)
			{
				count = lpman.ParticleSystems[0].Particles.Length;
			}
			else if (lpman.ParticleSystems.Length > 1)
			{
				foreach (LPParticleSystem sys in lpman.ParticleSystems)
				{
					count += sys.Particles.Length;
				}
			}
			txt.text = count.ToString();				
		}
	}
}
