using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
using System;
#endif

public class ResourceHolder : MonoBehaviour
{
	public bool CleanBeforeAdding = true;
	public List<UnityEngine.Object> References;
}



#if UNITY_EDITOR
[CustomEditor(typeof(ResourceHolder))]
public class ResourceHolderEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		var script = target as ResourceHolder;

		if (GUILayout.Button("DO IT"))
		{
			DO_IT(script.CleanBeforeAdding, script.References);
		}
	}

	private void DO_IT(bool clean, List<UnityEngine.Object> refs)
	{
		if (clean)
		{
			refs.Clear();
		}
		
		foreach (var path in FilePaths)
		{
			if (path.EndsWith(".meta")) continue;	// skip metas
			if (path.EndsWith(".unity")) continue;	// skip scenes
			if (path.EndsWith(".cs")) continue;		// skip scripts			
			
			Debug.LogWarning($"Testing File: {path}");
			var obj = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
			if (obj == null)
			{
				Debug.LogError("Failure!");
			}
			else
			{
				Debug.Log("Success!");
				refs.Add(obj);
			}
		}
	}
	
	private static IEnumerable<string> FilePaths
	{ 
		get
		{
			var assetPath = Application.dataPath;
			return Directory.GetFiles(assetPath, "*", SearchOption.AllDirectories)
				.Select(path => MakeRelative(path, assetPath));
		}
	}
	
	
	public static string MakeRelative(string filePath, string referencePath)
	{
		var fileUri = new Uri(filePath);
		var referenceUri = new Uri(referencePath);
		return referenceUri.MakeRelativeUri(fileUri).ToString();
	}
}
#endif