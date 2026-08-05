using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using UI;
using UnityEngine;

public class MoltenCoreController : WorkshopController
{
	private GameObject background;

	private GameObject mask;

	private GameObject decoration;

	private GameObject builders;

	private GameObject Door;

	private GameObject Dragon1;

	private GameObject Dragon2;

	private HitArea hitarea;

	private GameObject itemIcons;

	public List<SpriteRenderer> ItemIconSprites;

	private GameObject workers;

	private List<string> curProductDatas;

	private List<string> moltenCoreSprites;

	private new void Start()
	{
		curProductDatas = new List<string>();
		moltenCoreSprites = new List<string>();
		SharedMessenger.AddListener<string>("BUILDING_CONSTRUCTING_COMPLETE", UpdateWorkshopStyle);
		SharedMessenger.AddListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", base.RefreshSlot);
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", RefreshStyleOnlyOnRepair);
		hitarea = ((Component)this).gameObject.GetComponent<HitArea>();
		background = hitarea.hitData.background;
		mask = hitarea.hitData.mask;
		decoration = hitarea.hitData.decoration;
		builders = hitarea.hitData.builders;
		Door = ((Component)((Component)this).gameObject.transform.Find("Door")).gameObject;
		Dragon1 = ((Component)((Component)this).gameObject.transform.Find("Dragon1")).gameObject;
		Dragon2 = ((Component)((Component)this).gameObject.transform.Find("Dragon2")).gameObject;
		itemIcons = ((Component)((Component)this).gameObject.transform.Find("ItemIcons")).gameObject;
		workers = ((Component)((Component)this).gameObject.transform.Find("Wokkers")).gameObject;
		timing = 0f;
		WorkshopStyleInit(WorkShop.Level);
		WorkerNumPanelInit();
		((GObject)workerNum).alpha = ((WorkShop.Level > 0) ? 1 : 0);
		WorkerNumFade();
		((MonoBehaviour)this).StartCoroutine(RealStartCoroutine());
	}

	public IEnumerator RealStartCoroutine()
	{
		while (!Contexts.sharedInstance.gameState.isMainCityInitialized)
		{
			yield return (object)new WaitForSeconds(0.5f);
		}
		GameManagers.Instance.RecycleManager.GetCurrentRecyclingProducts(delegate
		{
			LoadProductOnWorkbench();
			RegisterEventListeners();
			WorkerNumFade();
		});
	}

	private new void OnDestroy()
	{
		UnregisterEventListeners();
		((MonoBehaviour)this).StopAllCoroutines();
		SharedMessenger.RemoveListener<string>("BUILDING_CONSTRUCTING_COMPLETE", UpdateWorkshopStyle);
	}

	private void UpdateWorkshopStyle(string buildingType)
	{
		if (buildingType == WorkShop.BuildingType)
		{
			WorkshopStyleInit(WorkShop.Level + 1);
		}
	}

	private IEnumerator UnLoadMoltenCoreSprites(bool isInit)
	{
		if (!isInit)
		{
			background.GetComponent<SpriteRenderer>().sprite = null;
			yield return (object)new WaitForSeconds(3f);
			mask.GetComponent<SpriteRenderer>().sprite = null;
			for (int i = 0; i < moltenCoreSprites.Count; i++)
			{
				AssetsManager.Instance.UnloadAsset<Sprite>(moltenCoreSprites[i]);
			}
		}
	}

	public override void WorkshopStyleInit(int expectedLevel = 0, bool leaseholdChanged = false)
	{
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		if (WorkShop.Feature != "MoltenCore")
		{
			return;
		}
		background.SetActive(true);
		if (WorkShop.Status == BuildingStatus.Constructing)
		{
			builders.SetActive(true);
		}
		else
		{
			builders.SetActive(false);
		}
		if (WorkShop.Status == BuildingStatus.Ready)
		{
			expectedLevel = WorkShop.Level + 1;
		}
		if (expectedLevel <= 0)
		{
			mask.SetActive(true);
			string maskSpriteName = "room_locked_mask_" + WorkShop.BuildingType;
			AssetsManager.Instance.LoadAsset<Sprite>(maskSpriteName).Then((Action<Sprite>)delegate(Sprite asset)
			{
				mask.GetComponent<SpriteRenderer>().sprite = asset;
				if (!moltenCoreSprites.Contains(maskSpriteName))
				{
					moltenCoreSprites.Add(maskSpriteName);
				}
			});
			string roomSpriteName = "room_locked_" + WorkShop.BuildingType;
			AssetsManager.Instance.LoadAsset<Sprite>(roomSpriteName).Then((Action<Sprite>)delegate(Sprite asset)
			{
				background.GetComponent<SpriteRenderer>().sprite = asset;
				if (!moltenCoreSprites.Contains(roomSpriteName))
				{
					moltenCoreSprites.Add(roomSpriteName);
				}
			});
			Door.SetActive(false);
			Dragon1.SetActive(false);
			Dragon2.SetActive(false);
			decoration.SetActive(false);
			itemIcons.SetActive(false);
			workers.SetActive(false);
			return;
		}
		mask.SetActive(false);
		Door.SetActive(true);
		Dragon1.SetActive(true);
		Dragon2.SetActive(true);
		decoration.SetActive(true);
		itemIcons.SetActive(true);
		workers.SetActive(true);
		AssetsManager.Instance.LoadAsset<Sprite>("room_unlocked_" + WorkShop.BuildingType).Then((Action<Sprite>)delegate(Sprite asset)
		{
			FGUIManager.Instance.OpenIEnumerator(UnLoadMoltenCoreSprites(isInit: false));
			background.GetComponent<SpriteRenderer>().sprite = asset;
		});
		string text = "";
		string text2 = "";
		if (expectedLevel <= 1)
		{
			text = "room_door_17_lv1";
			text2 = "room_top_17_lv1";
		}
		else if (expectedLevel <= 3)
		{
			text = "room_door_17_lv2-3";
			text2 = "room_top_17_lv2-3";
		}
		else if (expectedLevel <= 5)
		{
			text = "room_door_17_lv4-5";
			text2 = "room_top_17_lv4-5";
		}
		AssetsManager.Instance.LoadAsset<Sprite>(text).Then((Action<Sprite>)delegate(Sprite asset)
		{
			Door.GetComponent<SpriteRenderer>().sprite = asset;
		});
		AssetsManager.Instance.LoadAsset<Sprite>(text2).Then((Action<Sprite>)delegate(Sprite asset)
		{
			Dragon1.GetComponent<SpriteRenderer>().sprite = asset;
		});
		AssetsManager.Instance.LoadAsset<Sprite>(text2).Then((Action<Sprite>)delegate(Sprite asset)
		{
			Dragon2.GetComponent<SpriteRenderer>().sprite = asset;
		});
		AssetsManager.Instance.LoadAsset<Sprite>($"room_deco_17_lv{expectedLevel}").Then((Action<Sprite>)delegate(Sprite asset)
		{
			decoration.GetComponent<SpriteRenderer>().sprite = asset;
		});
		LoadDragonMouthSfx(Dragon1, "ui_dragon_mouth_in", new Vector3(0f, -0.45f, 0f));
		GameObject val = LoadDragonMouthSfx(Dragon2, "ui_dragon_mouth_out", new Vector3(0f, -0.45f, 0f));
		val.transform.localEulerAngles = new Vector3(-90f, 90f, 0f);
		LoadDragonMouthSfx(decoration, $"Workshop_17_{expectedLevel}", new Vector3(-0.03f, 0.26f, -0.3f), "UI");
		LoadItemIcons();
	}

	private void LoadItemIcons()
	{
		for (int i = 0; i < curProductDatas.Count; i++)
		{
			if (i > 4)
			{
				break;
			}
			int index = i;
			AssetsManager.Instance.LoadAsset<Shader>("ImageGrayShader").Then((Action<Shader>)delegate(Shader shader)
			{
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				//IL_0008: Expected O, but got Unknown
				//IL_004f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0054: Unknown result type (might be due to invalid IL or missing references)
				Material material = new Material(shader);
				((Renderer)ItemIconSprites[index]).material = material;
				ItemIconSprites[index].color = Color32.op_Implicit(new Color32((byte)192, (byte)192, (byte)192, byte.MaxValue));
				string resourcePath = UiHelper.GetResourcePath(curProductDatas[index], 0);
				UiHelper.GetProductLoader(((Component)ItemIconSprites[index]).gameObject, resourcePath);
			});
		}
	}

	protected void RefreshStyleOnlyOnRepair(string buildingType, int level)
	{
		if (!(WorkShop.Feature != "MoltenCore") && buildingType == WorkShop.BuildingType && level >= 1)
		{
			WorkshopStyleInit(WorkShop.Level);
		}
	}

	private void UnloadSprite(string iconName, string newIcon)
	{
		if (!string.IsNullOrWhiteSpace(iconName))
		{
			AssetsManager.Instance.UnloadAsset<Sprite>(iconName);
		}
		iconName = newIcon;
	}

	public GameObject LoadDragonMouthSfx(GameObject obj, string sfxName, Vector3 posVector3, string sorting_layer_name = "Default")
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		if (obj.GetComponentsInChildren<Transform>().Length > 1)
		{
			Object.Destroy((Object)(object)((Component)obj.GetComponentsInChildren<Transform>()[1]).gameObject);
		}
		GameObject val = SpawnManager.Instance.InstantiatePool(sfxName, Vector3.zero, 1);
		if ((Object)(object)val != (Object)null)
		{
			val.transform.parent = obj.transform;
			val.transform.localPosition = posVector3;
			val.GetComponent<Renderer>().sortingLayerName = sorting_layer_name;
			for (int i = 0; i < ((Component)val.transform).GetComponentsInChildren<Renderer>().Length; i++)
			{
				((Component)val.transform).GetComponentsInChildren<Renderer>()[i].sortingLayerName = sorting_layer_name;
			}
		}
		return val;
	}

	public void PlayDragonMouthExplosion()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		HitArea component = ((Component)this).gameObject.GetComponent<HitArea>();
		GameObject val = SpawnManager.Instance.InstantiatePool("ui_dragon_mouth_explosion", Vector3.zero, 1);
		if ((Object)(object)val != (Object)null)
		{
			val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
			val.transform.parent = component.hitData.decoration.transform.Find("StockBottom");
			val.transform.localPosition = new Vector3(0f, 1.4f, 0f);
			val.GetComponent<Renderer>().sortingLayerName = "Default";
			for (int i = 0; i < ((Component)val.transform).GetComponentsInChildren<Renderer>().Length; i++)
			{
				((Component)val.transform).GetComponentsInChildren<Renderer>()[i].sortingLayerName = "Default";
			}
		}
	}
}
