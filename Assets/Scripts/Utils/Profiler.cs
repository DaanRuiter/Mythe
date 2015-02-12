using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Profiler {
	private static Dictionary<string,float> profiles = new Dictionary<string,float>();
	
	public static void StartTime (string tag)
	{
		if(profiles.ContainsKey(tag))
		{
			Debug.LogError("this tag has been already started!");
		} else {
			profiles.Add(tag,Time.realtimeSinceStartup);
		}
	}
	public static void EndTime (string tag)
	{
		if(profiles.ContainsKey(tag))
		{
			Debug.Log(tag + " takes " + (Time.realtimeSinceStartup - profiles[tag])*1000 + " MS");
			profiles.Remove(tag);
		} else {
			Debug.LogError("this tag has not been started yet!");
		}
	}
}