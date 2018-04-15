using UnityEngine;
using System.Collections;

//This class contains information about a raycast hitting a fixture
public struct LPRayCastHit
{
	//Indicates whether the raycast hit has hit a fixture or a particle.
	public LPRayCastHitType WhatDidIHit;
	//Indicates the index number of the fixtures body or the particles particle system
	public int ParentIndex;
	public Vector3 Position;
	public Vector3 Normal;
	//Indicates the fixtures index or the index of the particle in its particle system 
	public int Index;
	public float Fraction;
}

