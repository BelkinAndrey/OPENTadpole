using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;

public class Mine : MonoBehaviour 
{
	
	public float ExplosionStrenght = 30f;
	public int ParticleSystemImIn = 0;
    public float fusetime = 4f;
	
	public LPFixture ExplosionShape;
	public LPFixture MineShape;
	
	private LPManager lpman;
	private IntPtr shape;

	void Start ()
	{
		lpman = FindObjectOfType<LPManager>();
		shape = ExplosionShape.GetShape();
        StartCoroutine("fuse");
	}

    IEnumerator fuse()
    {
        yield return new WaitForSeconds(fusetime);
        Splode();
    }

    public void Splode()
    {
        IntPtr partsysptr = lpman.ParticleSystems[ParticleSystemImIn].GetPtr();
        IntPtr worldPtr = lpman.GetPtr();
        IntPtr particlesPointer = LPAPIParticleSystems.GetParticlesInShape(worldPtr, partsysptr
                                                                           , shape, transform.position.x, transform.position.y
                                                                           , transform.rotation.eulerAngles.z);

        int[] particlesArray = new int[1];
        Marshal.Copy(particlesPointer, particlesArray, 0, 1);
        int foundNum = particlesArray[0];


        if (foundNum > 0)
        {
            int[] Indices = new int[foundNum + 1];
            Marshal.Copy(particlesPointer, Indices, 0, foundNum + 1);

            LPAPIParticles.ExplodeSelectedParticles(partsysptr, Indices, transform.position.x, transform.position.y, ExplosionStrenght);
        }
        GetComponent<LPBody>().Delete();
        Destroy(gameObject);
    }
		
}
