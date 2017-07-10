using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawParticleWorld : LPDrawParticleSystem
{
    public Transform target;
    public float MaxVis = 3000;
    public float MaxAlfa = 1f;

    public Color col;

    public override void UpdateParticles(List<LPParticle> partdata)
    {
        if (GetComponent<ParticleEmitter>().particleCount < partdata.Count)
        {
            GetComponent<ParticleEmitter>().Emit(partdata.Count - GetComponent<ParticleEmitter>().particleCount);
            particles = GetComponent<ParticleEmitter>().particles;
        }

        for (int i = 0; i < particles.Length; i++)
        {
            if (i < partdata.Count - 1)
            {
                particles[i].position = partdata[i].Position;

                float r = Vector3.SqrMagnitude(target.position - partdata[i].Position);
                float colorA = 0f;
                if (r > MaxVis) colorA = 0;
                else colorA = (1 - (r / MaxVis)) * MaxAlfa;

                particles[i].color = new Color(col.r, col.g, col.b, colorA);
            }
            else 
            {
                particles[i].energy = 0f;
            }
        }
        GetComponent<ParticleEmitter>().particles = particles;
    }
}
