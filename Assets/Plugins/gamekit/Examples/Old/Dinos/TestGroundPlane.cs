using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGroundPlane : MonoBehaviour
{
	[SerializeField] private GroundPlaneController controller;
	[SerializeField] private GameObject[] stuff;
	private int i = 0;
	private GameObject NextThing
	{
		get
		{
			if (stuff.Length == 0)
			{
				Debug.LogError("No stuff defined!");
				return null;
			}
			i++; 				// increase index 
			i %= stuff.Length; 	// wrap around
			return stuff[i];
		}
	} 

	public void OnClick()
	{
		var copy = Instantiate(NextThing);
		controller.SetExpFromSceneObj(copy, Vector3.zero);
	}
}
