using System.Collections.Generic;
using Shift.Legion.Common.Managers;
using UI.MainCity;
using UnityEngine;

public class SpringFestivalEntranceController : MonoBehaviour
{
	public GameObject woeker;

	public GameObject notise;

	public GameObject back;

	public BoxCollider boxCollider;

	private void Awake()
	{
	}

	private void Start()
	{
		SetEntranceStatus();
		SharedMessenger.AddListener<string, Dictionary<string, object>>("OPEN_UI", UpdateMainCityUI);
	}

	private void Update()
	{
	}

	public void SetEntranceStatus()
	{
		if (GameController.Configs.TryGetValue("SF21", out var value) && value == "1" && GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress("C1002").Contains("P215"))
		{
			woeker.SetActive(true);
			notise.SetActive(true);
			back.SetActive(true);
			((Collider)boxCollider).enabled = true;
		}
		else
		{
			woeker.SetActive(false);
			notise.SetActive(false);
			back.SetActive(false);
			((Collider)boxCollider).enabled = false;
		}
	}

	public void AddGuideTab()
	{
		UiTagManager instance = UiTagManager.Instance;
		instance.Register("MainCity.SpecialEntrance", ((Component)this).gameObject);
	}

	public void UpdateMainCityUI(string uiName, Dictionary<string, object> uiParams)
	{
		if (uiName == UI_MainCity.Name)
		{
			SetEntranceStatus();
		}
	}
}
