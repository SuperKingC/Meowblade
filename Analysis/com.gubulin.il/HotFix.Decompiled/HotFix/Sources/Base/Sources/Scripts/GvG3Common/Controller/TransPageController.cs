using System;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Controller;

internal class TransPageController<T> where T : Enum
{
	private T _CurPage;

	private GameObject _CurPageGO;

	private Transform _Root;

	public T SelectedPage
	{
		get
		{
			return _CurPage;
		}
		set
		{
			if (!object.Equals(_CurPage, value))
			{
				_CurPage = value;
				_CurPageGO.SetActive(false);
				_CurPageGO = ((Component)_Root.Find(_CurPage.ToString())).gameObject;
				_CurPageGO.SetActive(true);
			}
		}
	}

	public Transform SelectedPageTrans => _CurPageGO.transform;

	public GameObject SelectedPageGameObject => _CurPageGO;

	public bool Enabled
	{
		get
		{
			return ((Component)_Root).gameObject.activeInHierarchy;
		}
		set
		{
			((Component)_Root).gameObject.SetActive(value);
		}
	}

	public GameObject GameObject => ((Component)_Root).gameObject;

	public TransPageController(Transform root, T initialPage, bool closeOtherPages = false)
	{
		_Root = root;
		_CurPage = initialPage;
		_CurPageGO = ((Component)_Root.Find(_CurPage.ToString())).gameObject;
		_CurPageGO.SetActive(true);
		if (!closeOtherPages)
		{
			return;
		}
		foreach (T value in Enum.GetValues(typeof(T)))
		{
			if (!object.Equals(_CurPage, value))
			{
				((Component)_Root.Find(value.ToString())).gameObject.SetActive(false);
			}
		}
	}

	public GameObject GetPageGameObject(T page)
	{
		return ((Component)_Root.Find(page.ToString())).gameObject;
	}

	public Transform Find(string path)
	{
		return _Root.Find(path);
	}
}
