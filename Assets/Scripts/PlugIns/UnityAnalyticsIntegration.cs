using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;

public class UnityAnalyticsIntegration : MonoBehaviour {
	
	// Use this for initialization
	void Start () 
	{
		const string projectId = "f0a6c6c9-1d88-4d2e-af9a-dd2769ab1a1a";
		UnityAnalytics.StartSDK (projectId);
	}
}