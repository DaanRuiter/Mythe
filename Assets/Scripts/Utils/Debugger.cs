using UnityEngine;
using System.Collections;

public class Debugger
{
	public static void log(string type, string message)
	{
		if(isInterest(type))
		{
			Debug.Log(message);
		}
	}

	private static bool isInterest(string type)
	{
		foreach(string current in DebuggerSettings.interests) 
		{
			if(current.Equals(type))
			{
				return true;
			}
		} 
		return false;
	}
}

public class DebugInterests
{
	public static string N = "Niek";
	public static string BLA = "blabla";
}
