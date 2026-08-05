using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Spine.Unity;
using UI;
using UI.PublicResources;
using UnityEngine;

public class StorehouseController : MonoBehaviour
{
	public Storehouse storehouse;

	private string lvIcon;

	private string lvTopIcon;

	private string stockIcon;

	private string LvBottomIcon;

	private string stockBottomIcon;

	private UIPanel deliveryPopup;

	private Transform BubbleTrans;

	private UI_com_StorehouseBubble BubbleUI;

	private List<string> BubbleItems;

	private void Start()
	{
		BubbleItems = new List<string> { "I69001", "I69003", "I69004", "I69005", "I69006" };
		SetStoreHouseLvIcon();
		PlayDragonMouthOut();
		TextPanelInit();
		ChangeStockInconAndSfx(storehouse.StockStatus);
		SharedMessenger.AddListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", storehouseUpgrade);
		SharedMessenger.AddListener<StockStatus>("STOCK_STATUS_CHANGED", ChangeStockInconAndSfx);
		SharedMessenger.AddListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.AddListener<string, Level, Team, bool>("LEVEL_COMPLETED", OnLevelCompleted);
		UpdateBubbleState();
	}

	private void OnDestroy()
	{
		((MonoBehaviour)this).StopAllCoroutines();
		SharedMessenger.RemoveListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", storehouseUpgrade);
		SharedMessenger.RemoveListener<StockStatus>("STOCK_STATUS_CHANGED", ChangeStockInconAndSfx);
		SharedMessenger.RemoveListener<string, int, (StockInContext, string)>("ON_STOCK_CHANGE", OnStockChange);
		SharedMessenger.RemoveListener<string, Level, Team, bool>("LEVEL_COMPLETED", OnLevelCompleted);
	}

	private void OnLevelCompleted(string arg1, Level arg2, Team arg3, bool arg4)
	{
		UpdateBubbleState();
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (BubbleItems.Contains(itemId))
		{
			UpdateBubbleState();
		}
	}

	private void UpdateBubbleState()
	{
		foreach (string bubbleItem in BubbleItems)
		{
			if (GameManagers.Instance.StockController.GetStock(bubbleItem) > 0 && CheckItemUsable(bubbleItem))
			{
				ShowBubble(bubbleItem);
				return;
			}
		}
		HideBubble();
	}

	private bool CheckItemUsable(string itemId)
	{
		string text = "";
		string text2 = "";
		List<Modifier> list = Item.Effect(GameManagers.Instance, itemId);
		if (list != null)
		{
			foreach (Modifier item in list)
			{
				if (item.ModifierId == "UseMinChapter")
				{
					text = item.GetPayload<string>();
				}
				if (item.ModifierId == "UseMinLevel")
				{
					text2 = item.GetPayload<string>();
				}
			}
		}
		if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2) && !GameManagers.Instance.UserArchiveManager.GetChapterLevelProgress(text).Contains(text2))
		{
			return false;
		}
		return true;
	}

	private void ShowBubble(string itemId)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)BubbleTrans == (Object)null)
		{
			BubbleTrans = ((Component)this).transform.Find("Bubble");
			UIPanel val = ((Component)BubbleTrans).gameObject.AddComponent<UIPanel>();
			val.packageName = "PublicResources";
			val.componentName = "com_StorehouseBubble";
			val.container.renderMode = (RenderMode)2;
			val.SetSortingOrder(4, true);
			val.sortingOrder = 4;
			val.CreateUI();
			((GObject)val.ui).xy = val.ui.GetCenterPos().Mul(-1f);
			BubbleUI = (UI_com_StorehouseBubble)(object)val.ui;
		}
		((Component)BubbleTrans).gameObject.SetActive(true);
		FGUIManager.Instance.SetItemIconAndFrame(BubbleUI.Icon, itemId, null, "", frameVisible: false);
	}

	private void HideBubble()
	{
		if ((Object)(object)BubbleTrans != (Object)null)
		{
			((Component)BubbleTrans).gameObject.SetActive(false);
		}
	}

	private void ChangeStockInconAndSfx(StockStatus stockStatus)
	{
		SetStoreHouseStockIconAndSfx((int)(stockStatus + 1));
	}

	private void UnloadSprite(string iconName, string newIcon)
	{
		if (!string.IsNullOrWhiteSpace(iconName))
		{
			AssetsManager.Instance.UnloadAsset<Sprite>(iconName);
		}
		iconName = newIcon;
	}

	private void storehouseUpgrade(string buildingType, BuildingConstructingConfig info)
	{
		if (storehouse.BuildingType == buildingType)
		{
			if (storehouse.Level >= 1)
			{
				((Component)this).gameObject.GetComponent<HitArea>().RepairBuild(info.Workers, info.UpgradeRemainingTime);
			}
			((MonoBehaviour)this).StartCoroutine(RepairTiming(info.UpgradeRemainingTime));
			UiAudioManager.Instance.PlaySoundEffect("ConstructionSite");
		}
	}

	public IEnumerator RepairTiming(int time)
	{
		HitArea hitArea = storehouse.GameObject.GetComponent<HitArea>();
		BuildingConstructingConfig info = storehouse.ConstructingConfig;
		int totalTime = info.UpgradeRemainingTime;
		if (totalTime <= 0)
		{
			PlayStoreHouseRepairedSfx();
			FGUIManager.Instance.BuildingUpgradeBarRefresh(storehouse);
			yield return (object)new WaitForSeconds(1f);
		}
		while (info.UpgradeRemainingTime > 0)
		{
			if (info.UpgradeRemainingTime <= 1 && !((Component)this).gameObject.GetComponent<HitArea>().haveSmoke)
			{
				ScriptApi.CreateTimer(1.95f, delegate
				{
					//IL_000b: Unknown result type (might be due to invalid IL or missing references)
					//IL_0051: Unknown result type (might be due to invalid IL or missing references)
					//IL_0077: Unknown result type (might be due to invalid IL or missing references)
					GameObject val = SpawnManager.Instance.InstantiatePool("buildingSmoke", Vector3.zero);
					if ((Object)(object)val != (Object)null && !hitArea.haveSmoke)
					{
						val.transform.eulerAngles = storehouse.GameObject.transform.eulerAngles;
						val.transform.position = storehouse.GameObject.transform.position;
						val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
						hitArea.haveSmoke = true;
					}
				});
			}
			FGUIManager.Instance.BuildingUpgradeBarRefresh(storehouse);
			yield return (object)new WaitForSeconds(1f);
		}
		for (int i = 0; i < 5; i++)
		{
			if (((Component)hitArea.hitData.builders.transform.GetChild(i)).gameObject.activeInHierarchy)
			{
				((Component)hitArea.hitData.builders.transform.GetChild(i)).GetComponent<SkeletonAnimation>().AnimationName = "idle";
			}
		}
		ScriptApi.CreateTimer(1.05f, delegate
		{
			for (int num = hitArea.smokes.Count - 1; num >= 0; num--)
			{
				Object.Destroy((Object)(object)hitArea.smokes[num]);
			}
			hitArea.smokes.Clear();
		});
		SetStoreHouseLvIcon(1);
		((Component)this).gameObject.GetComponent<HitArea>().isStartRepair = false;
	}

	private void PlayStoreHouseRepairedSfx()
	{
		HitArea hitArea = storehouse.GameObject.GetComponent<HitArea>();
		if (hitArea.haveSmoke)
		{
			return;
		}
		ScriptApi.CreateTimer(0.95f, delegate
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			GameObject val = SpawnManager.Instance.InstantiatePool("buildingSmoke", Vector3.zero);
			if ((Object)(object)val != (Object)null && !hitArea.haveSmoke)
			{
				val.transform.eulerAngles = storehouse.GameObject.transform.eulerAngles;
				val.transform.position = storehouse.GameObject.transform.position;
				val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
				hitArea.haveSmoke = true;
			}
		});
	}

	public void ContinueUpgrade(BuildingConstructingConfig ConstructingStatus)
	{
		if (storehouse.Status == BuildingStatus.Constructing && ConstructingStatus.UpgradeRemainingTime > 3)
		{
			if (storehouse.Level >= 1)
			{
				((Component)this).gameObject.GetComponent<HitArea>().RepairBuild(ConstructingStatus.Workers, ConstructingStatus.UpgradeRemainingTime);
			}
			((MonoBehaviour)this).StartCoroutine(RepairTiming(ConstructingStatus.UpgradeRemainingTime));
		}
		else if (storehouse.Status == BuildingStatus.Constructing && ConstructingStatus.UpgradeRemainingTime <= 3)
		{
			ScriptApi.CreateTimer(2f, delegate
			{
				FGUIManager.Instance.SetBuilderIdleStates(storehouse, ConstructingStatus.Workers);
				FGUIManager.Instance.SetReadyBuildingUpgradeBar(storehouse);
				SetStoreHouseLvIcon(1);
			});
		}
		else if (storehouse.Status == BuildingStatus.Ready)
		{
			ScriptApi.CreateTimer(2f, delegate
			{
				FGUIManager.Instance.SetBuilderIdleStates(storehouse, ConstructingStatus.Workers);
				FGUIManager.Instance.SetReadyBuildingUpgradeBar(storehouse);
				SetStoreHouseLvIcon(1);
			});
		}
	}

	public void SetStoreHouseLvIcon(int levelIncrement = 0)
	{
		int num = storehouse.Level + levelIncrement;
		GameObject gameObject = storehouse.GameObject;
		HitArea.HitData hitData = gameObject.GetComponent<HitArea>().hitData;
		AssetsManager.Instance.LoadAsset<Sprite>($"storehouse_lv{num}").Then((Action<Sprite>)delegate(Sprite asset)
		{
			((Component)hitData.decoration.transform.Find("LvIcon")).GetComponent<SpriteRenderer>().sprite = asset;
		});
		UnloadSprite(lvIcon, $"storehouse_lv{num}");
		string text = "";
		string text2 = "";
		if (num == 1)
		{
			text = "storehouseTop_lv1";
		}
		else if (num <= 3)
		{
			text = "storehouseTop_lv2-3";
		}
		else if (num <= 4)
		{
			text = "storehouseTop_lv6";
		}
		else if (num <= 5)
		{
			text = "storehouseTop_lv7";
		}
		AssetsManager.Instance.LoadAsset<Sprite>(text).Then((Action<Sprite>)delegate(Sprite asset)
		{
			((Component)hitData.decoration.transform.Find("LvBottomIcon")).GetComponent<SpriteRenderer>().sprite = asset;
		});
		UnloadSprite(LvBottomIcon, text);
		AssetsManager.Instance.LoadAsset<Sprite>($"storehouse_dragonTop_lv{num}").Then((Action<Sprite>)delegate(Sprite asset)
		{
			((Component)hitData.decoration.transform.Find("LvTopIcon")).GetComponent<SpriteRenderer>().sprite = asset;
		});
		UnloadSprite(lvTopIcon, $"storehouse_dragonTop_lv{num}");
	}

	public void PlayDragonMouthOut()
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("17").Level <= 0)
		{
			return;
		}
		HitArea component = ((Component)this).gameObject.GetComponent<HitArea>();
		if (((Component)component.hitData.decoration.transform.Find("LvIcon")).GetComponentsInChildren<Transform>().Length > 1)
		{
			return;
		}
		GameObject val = SpawnManager.Instance.InstantiatePool("ui_dragon_mouth_out", Vector3.zero, 1);
		if ((Object)(object)val != (Object)null)
		{
			val.transform.parent = component.hitData.decoration.transform.Find("LvIcon");
			val.transform.localPosition = new Vector3(0f, 1.4f, 0f);
			val.GetComponent<Renderer>().sortingLayerName = "Default";
			for (int i = 0; i < ((Component)val.transform).GetComponentsInChildren<Renderer>().Length; i++)
			{
				((Component)val.transform).GetComponentsInChildren<Renderer>()[i].sortingLayerName = "Default";
			}
		}
	}

	private void TextPanelInit()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		deliveryPopup = ((Component)((Component)((Component)this).gameObject.transform.Find("DeliveryPoint")).transform.Find("ProductionNumShow")).gameObject.AddComponent<UIPanel>();
		deliveryPopup.packageName = "PublicResources";
		deliveryPopup.componentName = "ProductionNumStage";
		deliveryPopup.container.renderMode = (RenderMode)2;
		deliveryPopup.SetSortingOrder(4, true);
		deliveryPopup.sortingOrder = 4;
		deliveryPopup.CreateUI();
		((Component)deliveryPopup).transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
	}

	public void PlayDragonMouthExplosion(int num)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
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
		UI_ProductionNumFloating NumFloating = UI_ProductionNumFloating.CreateInstance_ILRuntime();
		TextFormat textFormat = NumFloating.Title.textFormat;
		textFormat.size = 20;
		NumFloating.Title.textFormat = textFormat;
		((GObject)NumFloating.Title).text = $"+{num}";
		deliveryPopup.ui.AddChild((GObject)(object)NumFloating);
		((GObject)NumFloating).sortingOrder = 101;
		Vector2 val2 = default(Vector2);
		((Vector2)(ref val2))._002Ector(0f, 0f);
		((GObject)NumFloating).SetXY(val2.x, val2.y - 100f);
		((GObject)NumFloating).displayObject.gameObject.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
		NumFloating.DisAppear.Play(1, 0f, (PlayCompleteCallback)delegate
		{
			deliveryPopup.ui.RemoveChild((GObject)(object)NumFloating);
			((GObject)NumFloating).Dispose();
		});
	}

	public void SetStoreHouseStockIconAndSfx(int stockLevel)
	{
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		GameObject gameObject = storehouse.GameObject;
		HitArea.HitData hitData = gameObject.GetComponent<HitArea>().hitData;
		AssetsManager.Instance.LoadAsset<Sprite>($"stock_{stockLevel}").Then((Action<Sprite>)delegate(Sprite asset)
		{
			((Component)hitData.decoration.transform.Find("StockIcon")).GetComponent<SpriteRenderer>().sprite = asset;
		});
		UnloadSprite(stockIcon, $"stock_{stockLevel}");
		if (stockLevel == 5)
		{
			AssetsManager.Instance.LoadAsset<Sprite>("stock_bottom").Then((Action<Sprite>)delegate(Sprite asset)
			{
				((Component)hitData.decoration.transform.Find("StockBottom")).GetComponent<SpriteRenderer>().sprite = asset;
			});
			UnloadSprite(stockBottomIcon, "stock_bottom");
		}
		else
		{
			((Component)hitData.decoration.transform.Find("StockBottom")).GetComponent<SpriteRenderer>().sprite = null;
			UnloadSprite(stockBottomIcon, null);
		}
		if (hitData.mask.GetComponentsInChildren<Transform>().Length > 1)
		{
			for (int num = hitData.mask.transform.childCount - 1; num >= 0; num--)
			{
				Object.DestroyImmediate((Object)(object)((Component)hitData.mask.transform.GetChild(num)).gameObject);
			}
		}
		GameObject val = SpawnManager.Instance.InstantiatePool($"treasure_room_{stockLevel}", Vector3.zero, 1);
		if ((Object)(object)val != (Object)null)
		{
			val.transform.parent = hitData.mask.transform;
			val.transform.localPosition = Vector3.zero;
			val.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			val.GetComponent<Renderer>().sortingLayerName = "Default";
			for (int num2 = 0; num2 < ((Component)val.transform).GetComponentsInChildren<Renderer>().Length; num2++)
			{
				((Component)val.transform).GetComponentsInChildren<Renderer>()[num2].sortingLayerName = "Default";
			}
		}
	}
}
