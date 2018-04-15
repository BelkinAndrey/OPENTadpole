using UnityEngine;
using System.Collections;

/// <summary>
/// Static class that stores what colours to draw the Liquid Physics 2D gizmos
/// You can change the gizmo colours here</summary>
public static class LPColors 
{
	public static Color DefaultParticleCol = new Color(0.337f,0.4f,0.8f,0.486f);
		
	public static Color Selected = new Color(0f,1f,1f);
	
	public static Color StaticAwake = new Color(0f,1f,0f);
	public static Color StaticAsleep = new Color(0f,0.7f,0f);
	public static Color StaticInactive = new Color(0f,0.3f,0f);
	
	public static Color DynamicAwake = new Color(1f,1f,0f);
	public static Color DynamicAsleep = new Color(0.7f,0.7f,0f);
	public static Color DynamicInActive = new Color(0.3f,0.3f,0f);
		
	public static Color KinematicAwake = new Color(1f,0.54f,0f);
	public static Color KinematicAsleep = new Color(0.7f,0.37f,0f);
	public static Color KinematicInActive = new Color(0.3f,0f,0f);
	
	public static Color Sensor = new Color(0.75f,0.1f,0.75f);
	
	public static Color ParticleGroup = new Color(0f,0.5f,1f);
	
	public static Color Joint = new Color(1f,0.24f,0.58f);  
	
	public static Color Raycast = new Color(0.6f,0.6f,0.6f);
}
