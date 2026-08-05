using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using UI;
using UnityEngine;

public class MaterialFlow : MonoBehaviour
{
	private List<string> unlockItemList = new List<string>();

	private string[] stuffId = new string[4];

	private float timeNow;

	public float timingStart;

	public WorkshopController workshopController;

	public Transform startPoint;

	public float timingEnd;

	public float timeUpLimit;

	public float timeDownLimit;

	private float delayTime;

	private bool isDestroyed = false;

	private void Start()
	{
		isDestroyed = false;
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", SetUnlockItemList);
		SharedMessenger.AddListener<string>("PRODUCT_UNLOCKED", UpUnlockItemList);
		delayTime = ((Component)this).GetComponent<HitArea>().repairBuildTime;
		Flow();
		timingStart = timeDownLimit + 1f;
		timeNow = timingStart;
	}

	private void OnDestroy()
	{
		if (!isDestroyed)
		{
			isDestroyed = true;
			((MonoBehaviour)this).StopAllCoroutines();
			SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", SetUnlockItemList);
			SharedMessenger.RemoveListener<string>("PRODUCT_UNLOCKED", UpUnlockItemList);
		}
	}

	private void Update()
	{
		timeNow -= Time.deltaTime;
		GenerateIcon();
	}

	private void UpUnlockItemList(string productId)
	{
		if (productId[1] == '4')
		{
			((MonoBehaviour)this).StartCoroutine(FlowTiming());
		}
	}

	private void SetUnlockItemList(string buildingType, int level)
	{
		if (buildingType == "13")
		{
			GameManagers.Instance.UserArchiveManager.UnlockProduct("P40004");
			((MonoBehaviour)this).StartCoroutine(FlowTiming());
		}
	}

	public void Flow()
	{
		if (workshopController.WorkShop.Level <= 0)
		{
			return;
		}
		Dictionary<string, int> productStates = workshopController.WorkShop.GetProductStates(false);
		List<string> unlockedProducts = GameManagers.Instance.UserArchiveManager.GetUnlockedProducts();
		List<GDEProductData> list = new List<GDEProductData>();
		foreach (KeyValuePair<string, int> item in productStates)
		{
			if (BuildingManager.Products.ContainsKey(item.Key))
			{
				GDEProductData gDEProductData = BuildingManager.Products[item.Key];
				if (unlockedProducts.Contains(gDEProductData.Key))
				{
					list.Add(gDEProductData);
				}
			}
		}
		unlockItemList.Clear();
		foreach (GDEProductData item2 in list)
		{
			stuffId = (BuildingManager.ProductRequirements.ContainsKey(item2.Key) ? BuildingManager.ProductRequirements[item2.Key].Keys.ToArray() : new string[0]);
			string[] array = stuffId;
			foreach (string text in array)
			{
				if (text != "null")
				{
					unlockItemList.Add(GDMgr.Get<GDEItemData>(text).Key);
				}
			}
		}
	}

	private void GenerateIcon()
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		if (!(timeNow <= timingEnd))
		{
			return;
		}
		if (unlockItemList.Count > 0)
		{
			int index = Random.Range(0, unlockItemList.Count);
			Object obj = Resources.Load("ProductIcon");
			GameObject val = Object.Instantiate<GameObject>((GameObject)(object)((obj is GameObject) ? obj : null), startPoint);
			val.GetComponent<ProductIconOnTransporter>().direction = new Vector3(0f, -3.5f, 0f);
			int num = Random.Range(0, 100);
			string key = ((num > 50) ? "sack3" : UiHelper.GetIconPath(unlockItemList[index]));
			ProductIconOnTransporter component = val.GetComponent<ProductIconOnTransporter>();
			component.SetSprite(new KeyValuePair<string, int>(key, 0));
			component.iconUiPanel.container.renderMode = (RenderMode)0;
			MeshRenderer component2 = ((Component)component.iconUiPanel.ui.GetChild("icon").displayObject.gameObject.transform.Find("Image")).GetComponent<MeshRenderer>();
			if ((Object)(object)component2 != (Object)null)
			{
				((Renderer)component2).material.renderQueue = 2999;
			}
			((Renderer)val.gameObject.GetComponent<SpriteRenderer>()).sortingOrder = 1;
		}
		timingStart = Random.Range(timeDownLimit, timeUpLimit);
		timeNow = timingStart;
	}

	private IEnumerator FlowTiming()
	{
		while (delayTime >= 0f)
		{
			delayTime -= Time.deltaTime;
			yield return 0;
		}
		Flow();
	}
}
