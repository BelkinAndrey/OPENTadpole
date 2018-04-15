using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public static class EditingStatics
{
	public static bool editing = false;
}

public class LPShapeEditor: Editor	
{
	private bool editing;
	private int editpoint;
	private bool isclosest;				
	private bool drawingpoint;
	private bool created;
	private int createdindex;
	private Vector3 LastPoint;	
	
	protected virtual void OnSceneGUI()
	{	
		if (!Application.isPlaying) 
		{							
			Event e = Event.current;		
			Manipulate(e);
        }		
    }
        
    protected void DrawPointsUI()
    {
		DrawDefaultInspector();	
		LPCorporeal poly = (LPCorporeal)target;	
		string msg = "Draw Shape";	
		if (poly.Drawing)
		{ 
			msg = "Stop Drawing";
		}
		
		if(GUILayout.Button(msg))
		{		
			poly.Drawing = !poly.Drawing;
			
			if (poly.Drawing) poly.DontDrawLoop = true;
			else poly.DontDrawLoop = false;
			
			if(poly.Drawing)
            {
				Undo.RecordObject (poly,"Draw poly shape");
				poly.drawingfirstpoint = true;
                poly.EmptyPoints();
            }
        }
    }
    
    protected void Manipulate(Event e)
	{
		LPCorporeal poly = (LPCorporeal)target;	
		
		if (poly.Drawing)
		{
			Drawpoints(poly,e);	
		}
		else if (e.shift)
		{     	
			Movepoints(poly,e);
		}
		else if (e.control)
		{     
			Removepoints(poly,e);             
		}          
		else if (e.alt)
        {     
            Insertpoints(poly,e);         
        }
    }
      
    protected void Drawpoints(LPCorporeal poly, Event e)
    {	
		Vector3 mousepos = GetMousePos(e);
		int cID = GetCID();
		
		if (!poly.drawingfirstpoint)
		{
			Handles.DrawAAPolyLine(2f,new Vector3[2]{LastPoint,mousepos});
		}
		
		switch (e.type)
		{				
		case EventType.mouseDown:	
			if (!drawingpoint)
			{
				LastPoint = mousepos;
				poly.AddPoint(mousepos - poly.transform.position);
				if(poly.drawingfirstpoint)poly.drawingfirstpoint = false;
			}								
			drawingpoint = true;
			e.Use(); 
            break;
			
		case EventType.mouseUp:				            
			drawingpoint = false; 
			e.Use();          
			break;
			
		case EventType.MouseMove:		
			e.Use();
             break;
                
        case EventType.layout:
            HandleUtility.AddDefaultControl(cID);
            break;
		    }	       
		    if (GUI.changed) EditorUtility.SetDirty(target);         
    }
    
	protected void CheckDists(LPCorporeal poly)
    {
		LPFixture[] polys = poly.gameObject.GetComponents<LPFixturePoly>();
		LPFixture[] chains = poly.gameObject.GetComponents<LPFixtureChainShape>();
		
		LPFixture[] fixes = new LPFixture[0];
		
		if (polys!=null && chains == null)
		{
			fixes = polys;
		}
		else if(polys==null && chains != null)
		{
			fixes = chains;
		}
		else if (polys!=null && chains !=null)
		{
			fixes = new LPFixture[polys.Length + chains.Length];
			Array.Copy(polys, fixes,polys.Length);
			Array.Copy(chains,0,fixes,polys.Length,chains.Length);
		}
		
		if (fixes.Length > 1)
		{
			fixes  = fixes.OrderBy(d => d.ClosestDist).ToArray();
			fixes[0].EditMe = true;
			
			for (int i = 1; i < fixes.Length; i++) 
			{
				fixes[i].EditMe = false;
			}
		}

    }
    
	protected void Movepoints(LPCorporeal poly, Event e)
	{
		Vector3 mousepos = GetMousePos(e);
		int cID = GetCID();		
		
		if (!editing)
		{
			int closest;
			float dist;
			isclosest = CheckDists(poly.transform,poly.GetPoints(),poly.transform.position,mousepos,cID,out closest,out dist,Color.blue,poly.EditMe);
			poly.ClosestDist = dist;			
			if (isclosest)
			{
				editpoint = closest;
			}		
			if(!EditingStatics.editing)CheckDists(poly);
		}
		
		if (poly.EditMe)
		{		
			switch (e.type)
			{				
			case EventType.mouseDown:									
				if (isclosest)
				{
					Undo.RecordObject (poly,"Move Point in poly shape");
					editing = true;
					EditingStatics.editing = true;
				}			
				e.Use();
				break;
				
			case EventType.mouseUp:				            
				if (editing)
				{
					editing = false;
					EditingStatics.editing = false;
				}		            
				e.Use();
				break;
				
			case EventType.MouseMove:	
				e.Use();
				break;
	                
	            case EventType.MouseDrag:	
	                e.Use();
	                break;
	                
	            case EventType.layout:
	                HandleUtility.AddDefaultControl(cID);
	                break;
	        }	        
	        if (GUI.changed) EditorUtility.SetDirty(target);
	        
	        if (editing)
	        {
	            poly.EditPoint(editpoint,mousepos - poly.transform.position);
	        }				
		}
    }
    
	protected void Removepoints(LPCorporeal poly, Event e)
	{
		Vector3 mousepos = GetMousePos(e);
		int cID = GetCID();		
		
		int closest;
		float dist;
		isclosest = CheckDists(poly.transform,poly.GetPoints(),poly.transform.position,mousepos,cID,out closest, out dist,Color.red,poly.EditMe);	
		poly.ClosestDist = dist;			
		if (isclosest)
		{
			editpoint = closest;
		}
		CheckDists(poly);
		
		if(poly.EditMe)
		{
		
			switch (e.type)
			{				
			case EventType.mouseDown:									
				if (isclosest && poly.GetPoints().Count > 3)
				{
					Undo.RecordObject (poly,"Remove Point from poly shape");
					poly.RemovePoint(closest);
				}				
				e.Use();
				break;
				
			case EventType.MouseMove:	
				e.Use();
	                break;
	                
	            case EventType.layout:
	                HandleUtility.AddDefaultControl(cID);
	                break;
	        }	        
	        if (GUI.changed) EditorUtility.SetDirty(target); 
        } 
    }
    
	protected void Insertpoints(LPCorporeal poly, Event e)
    {
		Vector3 mousepos = GetMousePos(e);
		int cID = GetCID();	
		
		int closest = 0;
		float dist = 0;
		if (!created) isclosest = DrawLines(poly.transform,poly.GetPoints(),poly.transform.position,mousepos
																		,cID,out closest,out dist,Color.green,poly.EditMe);	
		poly.ClosestDist = dist;	
	    CheckDists(poly);	
		
		if (poly.EditMe)
		{
			switch (e.type)
			{				
			case EventType.mouseDown:	
				if (isclosest) 
				{
					Undo.RecordObject (poly,"Add Point to poly shape");
					poly.InsertPoint(closest+1,mousepos-poly.transform.position);	
					created = true;	
					createdindex = closest+1;
					EditingStatics.editing = true;
				}								
				e.Use();
				break;
				
			case EventType.MouseDrag:
				if (created)poly.EditPoint(createdindex,mousepos - poly.transform.position);
		
				e.Use();
	                break;
	                
			case EventType.MouseMove:		
				e.Use();
				break;
	                
			case EventType.mouseUp:				            
				created = false; 
				EditingStatics.editing = false;
				e.Use();
				break;
	                
	            case EventType.layout:
	                HandleUtility.AddDefaultControl(cID);
	                break;
	        }	        
	        if (GUI.changed) EditorUtility.SetDirty(target); 				
		}    
    }
    
    
	protected Vector3 GetMousePos(Event e)
	{
		Ray rayo =  HandleUtility.GUIPointToWorldRay(e.mousePosition);			
		return new Vector3(rayo.origin.x,rayo.origin.y,0f);	
	}
	
	protected int GetCID()
	{
		return GUIUtility.GetControlID(GetHashCode(), FocusType.Passive);	
    }
    
	private bool DrawLines(Transform transform,List<Vector3> pointsList,Vector3 tran,Vector3 mousepos,int controlID,out int closest,out float dist
							,Color col, bool editme)
    {
		tran = new Vector3(tran.x,tran.y,0f);
		Vector3[] points = LPShapeTools.TransformPoints(transform,tran,pointsList);
		closest = 0;
		dist = 10f;
		bool isclosest = false;
		List<int> contenders = new List<int>();
		
		for (int i = 0; i < points.Length; i++)
		{
			int j = i+1;
			if(j == points.Length) j = 0;
			
			points[i] = new Vector3(points[i].x,points[i].y,0f);
			points[j] = new Vector3(points[j].x,points[j].y,0f);
			if (HandleUtility.DistancePointLine(mousepos,points[i]+tran,points[j]+tran) < 1f)
			{
				contenders.Add(i);
			}
		} 
		
		if (contenders.Count > 0)
		{
			isclosest = true;
			closest = contenders[0];
			int closest2 = closest+1;
			if(closest2 == points.Length) closest2 = 0;
			dist = HandleUtility.DistancePointLine(mousepos,points[closest]+tran,points[closest2]+tran);
			
			if (contenders.Count > 1)
			{
				for (int i = 1; i < contenders.Count; i++)
				{
					int index = contenders[i];
					int index2 = index+1;
					if(index2 == points.Length) index2 = 0;
					
					float dist2 = HandleUtility.DistancePointLine(mousepos,points[index]+tran,points[index2]+tran);
					
					if ( dist2 < dist)
					{
						dist = dist2;
						closest = contenders[i];
					}
				}
			}        
		} 
		
		if (editme && isclosest)
		{
			Handles.color = col;
			int closest2 = closest+1;
			if(closest2 == points.Length) closest2 = 0;
			Handles.DrawAAPolyLine(10f,new Vector3[2]{points[closest]+tran,points[closest2]+tran});   //DrawLine();
		}
   	
		return isclosest;
    }
    
	private bool CheckDists(Transform transform,List<Vector3> pointsList,Vector3 tran,Vector3 mousepos,int controlID
							,out int closest,out float dist,Color col,bool editme)
	{
		tran = new Vector3(tran.x,tran.y,0f);
		Vector3[] points = LPShapeTools.TransformPoints(transform,tran,pointsList);
		closest = 0;
		dist = 10f;
		bool isclosest = false;
		List<int> contenders = new List<int>();
		
		for (int i = 0; i < points.Length; i++)
		{
			points[i] = new Vector3(points[i].x,points[i].y,0f);
			if ((mousepos - (points[i]+tran)).magnitude < 1f)
			{
				contenders.Add(i);
			}
		} 
		
		if (contenders.Count > 0)
		{
			isclosest = true;
			closest = contenders[0];
			dist = (mousepos - (points[contenders[0]]+tran)).sqrMagnitude;
			
			if (contenders.Count > 1)
			{
				for (int i = 1; i < contenders.Count; i++)
				{
					float compdist = (mousepos - (points[contenders[i]]+tran)).sqrMagnitude;
					if (compdist < dist)
					{
						dist = compdist;
						closest = contenders[i];
					}
				}
			}        
		} 
		
		for (int i = 0; i < points.Length; i++)
		{
			if (isclosest && i==closest && editme)
			{
				Handles.color = Color.yellow;
			}
			else Handles.color = col;
			
			Handles.DotCap(controlID,points[i]+tran,Quaternion.identity,HandleUtility.GetHandleSize(points[i]+tran)*0.07f);
		}
		return isclosest;
	}
	
	private void DrawDots()
	{
		
	}
}


