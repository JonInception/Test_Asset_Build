using System.Collections;
using System.Collections.Generic;
using Ludiq;
using UnityEngine;

public class GroundPlaneController : MonoBehaviour
{
	[SerializeField] private GameObject _groundPlane;

    [SerializeField] private GameObject _startPrefabExp;
    [SerializeField] private Vector3 _startExpLocalPos;

    private void Start()
    {
        if (_startPrefabExp)
        {
            SetExpFromPrefab(_startPrefabExp, _startExpLocalPos);
        }
    }

    #region Set Experience object (to appear on next click)
    public void SetExpFromPrefab(GameObject exp)
    {
        var instance = Instantiate(exp);
        SetExpFromSceneObj(instance);
    }

    public void SetExpFromPrefab(GameObject exp, Vector3 localPos)
    {
        var instance = Instantiate(exp);
        SetExpFromSceneObj(instance, localPos);
    }

    public void SetExpFromSceneObj(GameObject exp, Vector3 localPos)
	{
        SetExpFromSceneObj(exp);
		exp.transform.localPosition = localPos;
	}

	public void SetExpFromSceneObj(GameObject exp)
	{
		RemoveChildren(_groundPlane.transform);

		exp.transform.parent = _groundPlane.transform;
		exp.SetActive(true);
	}
    #endregion

    public void PlaceGroundPlane(Vector3 worldPos)
    {
        _groundPlane.transform.position = worldPos;
    }

	private void RemoveChildren(Transform parent)
	{
		// NOTE: dont need reverse traversal since Destroy is not immediate.

		for (var i = 0; i < parent.childCount; i++)
		{
			var child = parent.GetChild(i).gameObject;
			Destroy(child);
		}
	}

}
