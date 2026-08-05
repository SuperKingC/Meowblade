using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.UI;
using FairyGUI;
using ObjectPool;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Spine.Unity;
using UI;
using UI.PublicResources;
using UnityEngine;

public class CampController : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static GComponentCreator _003C_003E9__37_0;

		internal GComponent _003CPlayRefundMaterials_003Eb__37_0()
		{
			return HotFixManager.Instance.appdomain.Instantiate<GComponent>(typeof(UI_ProductionNumFloating).FullName, (object[])null);
		}
	}

	public static CampController Instance;

	public const int SlotMaxNumOld = 5;

	private List<List<int>> _path;

	private Camp _camp;

	private GameObject[] _slots;

	private GameObject[] _newSlots;

	private PortalSoldier[] _portalSoldier;

	private CampSlot[] _campSlots;

	private List<CampSlotController> _slotControllers;

	private const int SlotMaxNum = 15;

	private List<string> spriteList = new List<string>();

	public List<List<int>> Path => _path;

	public Camp Camp => _camp;

	public List<CampSlotController> SlotControllers => _slotControllers;

	private bool ShowNewSlots => _camp.Level > 5;

	private void Awake()
	{
		Instance = this;
		spriteList = new List<string>();
		PooledList<List<int>> obj = new PooledList<List<int>>();
		((List<List<int>>)(object)obj).Add(new List<int> { 2, 6, 7, 8, 9 });
		((List<List<int>>)(object)obj).Add(new List<int> { 1, 2, 6, 7, 8, 9 });
		((List<List<int>>)(object)obj).Add(new List<int> { 3, 4, 5, 7, 8, 9 });
		((List<List<int>>)(object)obj).Add(new List<int> { 3, 4, 5, 7, 8, 9 });
		((List<List<int>>)(object)obj).Add(new List<int> { 4, 5, 7, 8, 9 });
		_path = (List<List<int>>)(object)obj;
		if (_slots == null)
		{
			_slots = (GameObject[])(object)new GameObject[5]
			{
				((Component)((Component)this).transform.Find("PortalSoldier1")).gameObject,
				((Component)((Component)this).transform.Find("PortalSoldier2")).gameObject,
				((Component)((Component)this).transform.Find("PortalSoldier3")).gameObject,
				((Component)((Component)this).transform.Find("PortalSoldier4")).gameObject,
				((Component)((Component)this).transform.Find("PortalSoldier5")).gameObject
			};
		}
		if (_newSlots == null)
		{
			_newSlots = (GameObject[])(object)new GameObject[15]
			{
				((Component)((Component)this).transform.Find("CampSlotNew1")).gameObject,
				((Component)((Component)this).transform.Find("CampSlotNew2")).gameObject,
				((Component)((Component)this).transform.Find("CampSlotNew3")).gameObject,
				((Component)((Component)this).transform.Find("CampSlotNew4")).gameObject,
				((Component)((Component)this).transform.Find("CampSlotNew5")).gameObject,
				((Component)((Component)this).transform.Find("CampSlotNew6")).gameObject,
				((Component)((Component)this).transform.Find("CampSlotNew7")).gameObject,
				((Component)((Component)this).transform.Find("CampSlotNew8")).gameObject,
				((Component)((Component)this).transform.Find("CampSlotNew9")).gameObject,
				((Component)((Component)this).transform.Find("CampSlotNew10")).gameObject,
				((Component)((Component)this).transform.Find("CampSlotNew11")).gameObject,
				((Component)((Component)this).transform.Find("CampSlotNew12")).gameObject,
				((Component)((Component)this).transform.Find("CampSlotNew13")).gameObject,
				((Component)((Component)this).transform.Find("CampSlotNew14")).gameObject,
				((Component)((Component)this).transform.Find("CampSlotNew15")).gameObject
			};
		}
		_portalSoldier = null;
		_campSlots = null;
	}

	public void Init(Camp camp)
	{
		_camp = camp;
		for (int i = 0; i < _newSlots.Length; i++)
		{
			_newSlots[i].AddComponent<CampSlot>().Controller = this;
		}
		_slotControllers = new List<CampSlotController>();
		for (int j = 0; j < 5; j++)
		{
			int num = j + 1;
			CampSlotController campSlotController = ((Component)((Component)this).transform.Find($"CampSlotController{num}")).gameObject.AddComponent<CampSlotController>();
			campSlotController.Init(GetCampSlots(num), this, j);
			_slotControllers.Add(campSlotController);
		}
		SetSlotsVisible();
		GameManagers.Instance.RecruitingCampDataManager.TryMakeOneRecruiting_WhenFinish(0);
	}

	private List<CampSlot> GetCampSlots(int index)
	{
		List<CampSlot> list = new List<CampSlot>();
		int num = index % 5;
		for (int i = 0; i < 15; i++)
		{
			int num2 = i + 1;
			if (num2 % 5 == num)
			{
				CampSlot item = GetPortalSoldier(i, newSlot: true) as CampSlot;
				list.Add(item);
			}
		}
		return list;
	}

	public PortalSoldier GetPortalSoldier(int pos, bool newSlot = false)
	{
		if (_portalSoldier == null)
		{
			_portalSoldier = new PortalSoldier[5]
			{
				((Component)GetSlotGameObject(0, isOld: true).transform.Find("Soldier")).GetComponent<PortalSoldier>(),
				((Component)GetSlotGameObject(1, isOld: true).transform.Find("Soldier")).GetComponent<PortalSoldier>(),
				((Component)GetSlotGameObject(2, isOld: true).transform.Find("Soldier")).GetComponent<PortalSoldier>(),
				((Component)GetSlotGameObject(3, isOld: true).transform.Find("Soldier")).GetComponent<PortalSoldier>(),
				((Component)GetSlotGameObject(4, isOld: true).transform.Find("Soldier")).GetComponent<PortalSoldier>()
			};
		}
		if (_campSlots == null)
		{
			_campSlots = new CampSlot[15]
			{
				GetSlotGameObject(0, isOld: false, isNew: true).GetComponent<CampSlot>(),
				GetSlotGameObject(1, isOld: false, isNew: true).GetComponent<CampSlot>(),
				GetSlotGameObject(2, isOld: false, isNew: true).GetComponent<CampSlot>(),
				GetSlotGameObject(3, isOld: false, isNew: true).GetComponent<CampSlot>(),
				GetSlotGameObject(4, isOld: false, isNew: true).GetComponent<CampSlot>(),
				GetSlotGameObject(5, isOld: false, isNew: true).GetComponent<CampSlot>(),
				GetSlotGameObject(6, isOld: false, isNew: true).GetComponent<CampSlot>(),
				GetSlotGameObject(7, isOld: false, isNew: true).GetComponent<CampSlot>(),
				GetSlotGameObject(8, isOld: false, isNew: true).GetComponent<CampSlot>(),
				GetSlotGameObject(9, isOld: false, isNew: true).GetComponent<CampSlot>(),
				GetSlotGameObject(10, isOld: false, isNew: true).GetComponent<CampSlot>(),
				GetSlotGameObject(11, isOld: false, isNew: true).GetComponent<CampSlot>(),
				GetSlotGameObject(12, isOld: false, isNew: true).GetComponent<CampSlot>(),
				GetSlotGameObject(13, isOld: false, isNew: true).GetComponent<CampSlot>(),
				GetSlotGameObject(14, isOld: false, isNew: true).GetComponent<CampSlot>()
			};
		}
		if (newSlot)
		{
			return _campSlots[pos];
		}
		if (pos >= 5)
		{
			return _campSlots[pos];
		}
		if (ShowNewSlots)
		{
			return _campSlots[pos];
		}
		return _portalSoldier[pos];
	}

	public GameObject GetSlotGameObject(int index, bool isOld = false, bool isNew = false)
	{
		if (isOld)
		{
			return _slots[index];
		}
		if (isNew)
		{
			return _newSlots[index];
		}
		if (index >= 5)
		{
			return _newSlots[index];
		}
		if (ShowNewSlots)
		{
			return _newSlots[index];
		}
		return _slots[index];
	}

	public Vector3 GetSlotPosForLevelUp(int slotIndex)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		Vector3 position = GetSlotGameObject(slotIndex).transform.position;
		if (!ShowNewSlots)
		{
			return position;
		}
		int index = slotIndex % 5;
		Vector3 position2 = GetSlotGameObject(index, isOld: true).transform.position;
		Vector3 val = position - position2;
		Vector3 normalized = ((Vector3)(ref val)).normalized;
		float num = Vector3.Distance(position2, position);
		return normalized * (num * 1f) + position2;
	}

	private void Start()
	{
		RegisterEventListeners();
		SetSlot(_camp.Slot);
	}

	private void OnDisable()
	{
		UnregisterEventListeners();
	}

	private void OnDestroy()
	{
		((MonoBehaviour)this).StopAllCoroutines();
		UnregisterEventListeners();
		for (int i = 0; i < spriteList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Sprite>(spriteList[i]);
		}
	}

	private void RegisterEventListeners()
	{
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", RefreshSlotOnlyOnRepair);
		SharedMessenger.AddListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", SetSlotByEvents);
		SharedMessenger.AddListener("RECRUITING_QUEUE_UPDATED", OnRecruitingQueueUpdated);
		SharedMessenger.AddListener<Dictionary<string, int>>("INFORM_CAMP_REFUND", OnRefund);
	}

	private void UnregisterEventListeners()
	{
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", RefreshSlotOnlyOnRepair);
		SharedMessenger.RemoveListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", SetSlotByEvents);
		SharedMessenger.RemoveListener("RECRUITING_QUEUE_UPDATED", OnRecruitingQueueUpdated);
		SharedMessenger.RemoveListener<Dictionary<string, int>>("INFORM_CAMP_REFUND", OnRefund);
	}

	public void SetSlot(int num)
	{
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		int num2 = ((num <= 0) ? 1 : num);
		HitArea component = _camp.GameObject.GetComponent<HitArea>();
		GameObject stone = component.hitData.decoration;
		GameObject conveyor = component.hitData.conveyor;
		Transform conveyorBackIcon = component.hitData.conveyor.transform.Find("Icon");
		string stoneIcon = ((num > 5) ? "summon_stone_lv5" : $"summon_stone_lv{num2}");
		AssetsManager.Instance.LoadAsset<Sprite>(stoneIcon).Then((Action<Sprite>)delegate(Sprite asset)
		{
			stone.GetComponent<SpriteRenderer>().sprite = asset;
			spriteList.Add(stoneIcon);
		});
		string conveyorIcon = ((num2 > 6) ? "Barracks_10_lv6" : $"Barracks_10_lv{num2}");
		AssetsManager.Instance.LoadAsset<Sprite>(conveyorIcon).Then((Action<Sprite>)delegate(Sprite asset)
		{
			conveyor.GetComponent<SpriteRenderer>().sprite = asset;
			spriteList.Add(conveyorIcon);
		});
		if (num >= 4)
		{
			AssetsManager.Instance.LoadAsset<Sprite>("barracks_crystal_lv4-5").Then((Action<Sprite>)delegate(Sprite asset)
			{
				((Component)conveyorBackIcon).GetComponent<SpriteRenderer>().sprite = asset;
				spriteList.Add("barracks_crystal_lv4-5");
			});
		}
		if (((Component)conveyor.transform.Find("SfxBack")).GetComponentsInChildren<Transform>().Length > 1)
		{
			for (int num3 = ((Component)conveyor.transform.Find("SfxBack")).transform.childCount - 1; num3 >= 0; num3--)
			{
				Object.DestroyImmediate((Object)(object)((Component)((Component)conveyor.transform.Find("SfxBack")).transform.GetChild(num3)).gameObject);
			}
		}
		string prefabName = ((num2 > 5) ? "Barracks_10_5" : $"Barracks_10_{num2}");
		GameObject val = SpawnManager.Instance.InstantiatePool(prefabName, Vector3.zero, 1);
		if ((Object)(object)val != (Object)null)
		{
			val.transform.parent = conveyor.transform.Find("SfxBack");
			val.transform.localPosition = Vector3.zero;
			val.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			val.transform.localScale = Vector3.one;
			val.GetComponent<Renderer>().sortingLayerName = "Default";
			for (int num4 = 0; num4 < ((Component)val.transform).GetComponentsInChildren<Renderer>().Length; num4++)
			{
				((Component)val.transform).GetComponentsInChildren<Renderer>()[num4].sortingLayerName = "Default";
			}
		}
		if (((Component)stone.transform.Find("SfxBack")).GetComponentsInChildren<Transform>().Length > 1)
		{
			for (int num5 = ((Component)stone.transform.Find("SfxBack")).transform.childCount - 1; num5 >= 0; num5--)
			{
				Object.DestroyImmediate((Object)(object)((Component)((Component)stone.transform.Find("SfxBack")).transform.GetChild(num5)).gameObject);
			}
		}
		string prefabName2 = ((num2 > 5) ? "Barracks_stone_5" : $"Barracks_stone_{num2}");
		GameObject val2 = SpawnManager.Instance.InstantiatePool(prefabName2, Vector3.zero, 1);
		if ((Object)(object)val2 != (Object)null)
		{
			val2.transform.parent = stone.transform.Find("SfxBack");
			val2.transform.localPosition = Vector3.zero;
			val2.transform.localScale = Vector3.one;
			val2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			val2.GetComponent<Renderer>().sortingLayerName = "Default";
			for (int num6 = 0; num6 < ((Component)val2.transform).GetComponentsInChildren<Renderer>().Length; num6++)
			{
				((Component)val2.transform).GetComponentsInChildren<Renderer>()[num6].sortingLayerName = "Default";
			}
		}
		if (num > 5)
		{
			return;
		}
		bool enabled = _camp.Level != 5 || _camp.Status != BuildingStatus.Ready;
		for (int num7 = 0; num7 < 5; num7++)
		{
			int index = num7;
			GameObject curSlot = GetSlotGameObject(index);
			((Renderer)curSlot.GetComponent<SpriteRenderer>()).enabled = enabled;
			if (num7 < num)
			{
				AssetsManager.Instance.LoadAsset<Sprite>("workplace_barracks_unlocked").Then((Action<Sprite>)delegate(Sprite asset)
				{
					curSlot.GetComponent<SpriteRenderer>().sprite = asset;
					spriteList.Add("workplace_barracks_unlocked");
				});
				((Component)curSlot.transform.GetChild(1)).gameObject.SetActive(true);
			}
			else
			{
				AssetsManager.Instance.LoadAsset<Sprite>("workplace_barracks_locked").Then((Action<Sprite>)delegate(Sprite asset)
				{
					curSlot.GetComponent<SpriteRenderer>().sprite = asset;
					spriteList.Add("workplace_barracks_locked");
				});
				((Component)curSlot.transform.GetChild(1)).gameObject.SetActive(false);
			}
		}
	}

	public void ContinueUpgrade(BuildingConstructingConfig ConstructingStatus)
	{
		if (_camp.Level >= 1 && _camp.Status == BuildingStatus.Constructing && ConstructingStatus.UpgradeRemainingTime > 3)
		{
			ReSetSlot(_camp.SomeLevelSlot(_camp.NextLevel), _camp.BuildingType, ConstructingStatus);
		}
		else if (_camp.Level >= 1 && _camp.Status == BuildingStatus.Constructing && ConstructingStatus.UpgradeRemainingTime <= 3)
		{
			ScriptApi.CreateTimer(3f, delegate
			{
				int level = ((_camp.NextLevel != 1) ? _camp.NextLevel : 0);
				SetSlot(_camp.SomeLevelSlot(level));
				FGUIManager.Instance.SetBuilderIdleUpgradeComplete(_camp, ConstructingStatus.Workers);
			});
		}
		else if (_camp.Level >= 1 && _camp.Status == BuildingStatus.Ready)
		{
			ScriptApi.CreateTimer(3f, delegate
			{
				int level = ((_camp.NextLevel != 1) ? _camp.NextLevel : 0);
				SetSlot(_camp.SomeLevelSlot(level));
				FGUIManager.Instance.SetBuilderIdleUpgradeComplete(_camp, ConstructingStatus.Workers);
			});
		}
	}

	private void SetSlotsVisible()
	{
		for (int i = 0; i < _slots.Length; i++)
		{
			_slots[i].SetActive(!ShowNewSlots);
		}
		for (int j = 0; j < _newSlots.Length; j++)
		{
			_newSlots[j].SetActive(ShowNewSlots);
		}
	}

	private void ReSetSlot(int value, string buildingType, BuildingConstructingConfig info)
	{
		if (_camp.BuildingType == buildingType && _camp.Level >= 1)
		{
			((Component)this).gameObject.GetComponent<HitArea>().UnlockCampSlot(_camp, info.Workers, info.UpgradeRemainingTime);
			((MonoBehaviour)this).StartCoroutine(RepairTiming(info.UpgradeRemainingTime, value));
		}
	}

	private void SetSlotByEvents(string buildingType, BuildingConstructingConfig info)
	{
		ReSetSlot(_camp.SomeLevelSlot(_camp.NextLevel), buildingType, info);
		UiAudioManager.Instance.PlaySoundEffect("ConstructionSite");
	}

	private void OnRecruitingQueueUpdated()
	{
		for (int i = 0; i < _camp.Slot; i++)
		{
			GetPortalSoldier(i)?.LoadSoldierInCamp(clear: true);
			GetPortalSoldier(i)?.CheckIsStockFull();
		}
	}

	private void OnRefund(Dictionary<string, int> refundRes)
	{
		List<string> itemIdArray = refundRes.Keys.ToList();
		List<int> qtyArray = refundRes.Values.ToList();
		((MonoBehaviour)this).StartCoroutine(PlayRefundMaterials(itemIdArray, qtyArray));
	}

	private IEnumerator PlayRefundMaterials(List<string> itemIdArray, List<int> qtyArray)
	{
		UIPanel uiPanel = GetRefundUiPanel();
		for (int i = 0; i < itemIdArray.Count; i++)
		{
			string itemId = itemIdArray[i];
			int itemQty = qtyArray[i];
			object obj = _003C_003Ec._003C_003E9__37_0;
			if (obj == null)
			{
				GComponentCreator val = () => HotFixManager.Instance.appdomain.Instantiate<GComponent>(typeof(UI_ProductionNumFloating).FullName, (object[])null);
				_003C_003Ec._003C_003E9__37_0 = val;
				obj = (object)val;
			}
			UIObjectFactory.SetPackageItemExtension("ui://kt6rg65omol0if", (GComponentCreator)obj);
			UI_ProductionNumFloating textFloating = UI_ProductionNumFloating.CreateInstance_ILRuntime();
			GTextField textField = textFloating.Title;
			textField.textFormat.size = 38;
			textField.textFormat.color = Color32.op_Implicit(new Color32(byte.MaxValue, byte.MaxValue, (byte)0, byte.MaxValue));
			((GObject)textField).text = $"+{itemQty}";
			GLoader iconLoader = textFloating.Icon;
			((GObject)iconLoader).SetScale(0.24f, 0.24f);
			iconLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(itemId);
			uiPanel.ui.AddChild((GObject)(object)textFloating);
			GObject init = uiPanel.ui.GetChild("line1");
			((GObject)textFloating).SetXY(init.x, init.y);
			((GObject)textFloating).displayObject.gameObject.AddComponent<HotFix_DestroySelf>().destroyTime = 2f;
			textFloating.DisAppear.Play((PlayCompleteCallback)delegate
			{
				uiPanel.ui.RemoveChild((GObject)(object)textFloating);
				((GObject)textFloating).Dispose();
			});
			yield return (object)new WaitForSeconds(0.18f);
		}
	}

	private UIPanel GetRefundUiPanel()
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		Transform val = ((Component)this).gameObject.transform.Find("summon_stone");
		UIPanel val2 = ((Component)val.Find("ProductionNumShow")).GetComponent<UIPanel>();
		if (val2 == null)
		{
			val2 = ((Component)((Component)val).transform.Find("ProductionNumShow")).gameObject.AddComponent<UIPanel>();
			val2.packageName = "PublicResources";
			val2.componentName = "ProductionNumStage";
			val2.container.renderMode = (RenderMode)2;
			val2.SetSortingOrder(4, true);
			val2.sortingOrder = 4;
			val2.CreateUI();
			((Component)val2).transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
		}
		return val2;
	}

	private IEnumerator RepairTiming(int time, int value)
	{
		BuildingConstructingConfig info = _camp.ConstructingConfig;
		while (info.UpgradeRemainingTime > 0)
		{
			if (info.UpgradeRemainingTime <= 1 && !((Component)this).gameObject.GetComponent<HitArea>().haveSmoke)
			{
				for (int i = _camp.Slot; i < _camp.SomeLevelSlot(_camp.NextLevel); i++)
				{
					int index = i;
					if (i >= 5)
					{
						continue;
					}
					ScriptApi.CreateTimer(0.95f, delegate
					{
						//IL_000b: Unknown result type (might be due to invalid IL or missing references)
						//IL_0049: Unknown result type (might be due to invalid IL or missing references)
						//IL_006b: Unknown result type (might be due to invalid IL or missing references)
						//IL_009b: Unknown result type (might be due to invalid IL or missing references)
						GameObject val = SpawnManager.Instance.InstantiatePool("workplaceSmoke_2", Vector3.zero);
						if ((Object)(object)val != (Object)null)
						{
							val.transform.eulerAngles = GetSlotGameObject(index).transform.eulerAngles;
							val.transform.position = GetSlotPosForLevelUp(index);
							val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
							val.transform.localScale = new Vector3(1f, 1f, 1f);
						}
					});
				}
				if (_camp.NextLevel < 6)
				{
					ScriptApi.CreateTimer(0.95f, delegate
					{
						//IL_000b: Unknown result type (might be due to invalid IL or missing references)
						//IL_0041: Unknown result type (might be due to invalid IL or missing references)
						//IL_0067: Unknown result type (might be due to invalid IL or missing references)
						//IL_0097: Unknown result type (might be due to invalid IL or missing references)
						//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
						//IL_00be: Unknown result type (might be due to invalid IL or missing references)
						//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
						GameObject val = SpawnManager.Instance.InstantiatePool("workplaceSmoke_2", Vector3.zero);
						if ((Object)(object)val != (Object)null)
						{
							val.transform.eulerAngles = _camp.GameObject.transform.eulerAngles;
							val.transform.position = _camp.GameObject.transform.position;
							val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
							val.transform.localScale = new Vector3(3f, 3f, 3f);
							val.transform.localPosition = new Vector3(val.transform.localPosition.x, val.transform.localPosition.y + 0.5f, -0.1f);
						}
						((Component)this).gameObject.GetComponent<HitArea>().haveSmoke = true;
					});
				}
			}
			FGUIManager.Instance.BuildingUpgradeBarRefresh(_camp);
			yield return (object)new WaitForSeconds(1f);
		}
		((Component)this).gameObject.GetComponent<HitArea>().isStartRepair = false;
		int level = ((_camp.NextLevel != 1) ? value : 0);
		RefreshAllSlots();
		SetSlot(level);
		HitArea hitArea = _camp.GameObject.GetComponent<HitArea>();
		for (int i2 = 0; i2 < 5; i2++)
		{
			if (((Component)hitArea.hitData.builders.transform.GetChild(i2)).gameObject.activeInHierarchy)
			{
				((Component)hitArea.hitData.builders.transform.GetChild(i2)).GetComponent<SkeletonAnimation>().AnimationName = "idle";
			}
		}
		ScriptApi.CreateTimer(0.35f, delegate
		{
			for (int num = hitArea.smokes.Count - 1; num >= 0; num--)
			{
				Object.Destroy((Object)(object)hitArea.smokes[num]);
			}
			hitArea.smokes.Clear();
		});
	}

	private void RefreshSlotOnlyOnRepair(string buildingType, int level)
	{
		if (buildingType == _camp.BuildingType)
		{
			SetSlot(_camp.Slot);
			if (level > 5)
			{
				SetSlotsVisible();
				GameManagers.Instance.RecruitingCampDataManager.TryMakeOneRecruiting_WhenFinish(0);
				SharedMessenger.Broadcast("CAMP_SLOT_UNLOCK", _camp.Slot);
			}
			else
			{
				((GObject)((Component)_camp.GameObject.GetComponent<CampController>().GetSlotGameObject(level - 1).transform.Find("CmapSlotUi")).GetComponent<UIPanel>().ui).visible = true;
			}
		}
	}

	private void RefreshAllSlots()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		if (_camp.NextLevel != 6)
		{
			return;
		}
		for (int i = 0; i < 3; i++)
		{
			int num = i;
			GameObject val = SpawnManager.Instance.InstantiatePool("buildingSmoke", Vector3.zero);
			if ((Object)(object)val != (Object)null)
			{
				val.transform.eulerAngles = _camp.GameObject.transform.eulerAngles;
				val.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
				val.transform.position = new Vector3(_camp.GameObject.transform.position.x + (float)((num - 1) * 2), _camp.GameObject.transform.position.y, val.transform.position.z);
			}
		}
	}
}
