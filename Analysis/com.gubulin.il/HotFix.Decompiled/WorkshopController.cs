using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using FairyGUI;
using GameDataEditor;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;
using Spine.Unity;
using UI;
using UnityEngine;

public class WorkshopController : MonoBehaviour
{
	private static Vector3 TransporterDirectionUp = new Vector3(0f, 1f, 0f);

	private static Vector3 TransporterDirectionDown = new Vector3(0f, -1f, 0f);

	public Transform DeliveryPoint;

	public Transform RefundPoint;

	public float distributionDelayTime;

	public bool isAllocated;

	public Transform[] KeyPoints;

	public Transform[] PathPoints;

	public Transform[] SlotPoints;

	public GComponent workerNum;

	public List<List<string>> taskList = new List<List<string>>();

	public float timing;

	public GameObject[] Workbench;

	public GameObject[] _WorkbenchNominal = (GameObject[])(object)new GameObject[12];

	public WorkShop WorkShop;

	public string ProcessingActionName;

	public Dictionary<string, Sprite> spriteList = new Dictionary<string, Sprite>();

	public Dictionary<int, List<string>> _assigningWorkbenches = new Dictionary<int, List<string>>();

	public Dictionary<int, List<string>> _assigningRecycleWorkbenches = new Dictionary<int, List<string>>();

	private Dictionary<string, int> slotrenderQueue = new Dictionary<string, int>();

	private bool _isAssigningWorkers;

	public GameObject[] WorkbenchNominal
	{
		get
		{
			if (_WorkbenchNominal == null)
			{
				_WorkbenchNominal = (GameObject[])(object)new GameObject[12];
			}
			return _WorkbenchNominal;
		}
	}

	public void Awake()
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		_assigningWorkbenches = new Dictionary<int, List<string>>();
		_assigningRecycleWorkbenches = new Dictionary<int, List<string>>();
		spriteList = new Dictionary<string, Sprite>();
		taskList = new List<List<string>>();
		slotrenderQueue = new Dictionary<string, int>
		{
			{ "4", 2994 },
			{ "5", 2995 },
			{ "6", 2996 },
			{ "13", 3004 },
			{ "8", 3005 },
			{ "9", 3006 }
		};
		TransporterDirectionUp = new Vector3(0f, 1f, 0f);
		TransporterDirectionDown = new Vector3(0f, -1f, 0f);
	}

	public void Start()
	{
		timing = 0f;
		LoadProductOnWorkbench();
		WorkshopStyleInit();
		RegisterEventListeners();
		if (WorkShop.Feature == "Mine" || WorkShop.Feature == "MoltenCore")
		{
			WorkerNumPanelInit();
			if (WorkShop.Level > 0)
			{
				((GObject)workerNum).alpha = 1f;
			}
			else
			{
				((GObject)workerNum).alpha = 0f;
			}
			WorkerNumFade();
		}
	}

	public void WorkerNumPanelInit()
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		UIPanel val = ((Component)((Component)this).gameObject.transform.Find("WokerNum")).gameObject.AddComponent<UIPanel>();
		val.packageName = "PublicResources";
		val.componentName = "WorkNum";
		val.container.renderMode = (RenderMode)2;
		val.SetSortingOrder(4, true);
		val.sortingOrder = 4;
		val.CreateUI();
		workerNum = val.ui;
		workerNum.GetChild("title").text = "";
		workerNum.GetChild("title").data = 0;
		WorkerNumFade();
	}

	protected void WorkerNumFade()
	{
		if (WorkShop.Level < 1)
		{
			((GObject)workerNum).alpha = 0f;
		}
		else if (WorkShop.Feature == "Mine" || WorkShop.Feature == "MoltenCore")
		{
			if (WorkShop.ManPower > 0)
			{
				((GObject)workerNum).alpha = 1f;
			}
			else
			{
				((GObject)workerNum).alpha = 0f;
			}
		}
	}

	public void OnDisable()
	{
	}

	private void SetWorkShop()
	{
		LoadProductOnWorkbench();
		WorkerNumFade();
		GameManagers.Instance.StockController.NeedSyncProduce = true;
	}

	protected void RegisterEventListeners()
	{
		SharedMessenger.AddListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", RefreshSlot);
		SharedMessenger.AddListener<string>("BUILDING_SLOTS_CHANGED", OnSlotChanged);
		SharedMessenger.AddListener<string, int, WorkerStatus>("WORKER_STATUS_CHANGED", OnWorkerStatusChange);
		SharedMessenger.AddListener<string, int>("BUILDING_UPGRADED", RefreshSlotOnlyOnRepair);
		SharedMessenger.AddListener<Building, Dictionary<string, ProductionConfig>>("PRODUCTION_CONFIG_CHANGED", OnBuildingProductionConfigChanged);
	}

	protected void UnregisterEventListeners()
	{
		SharedMessenger.RemoveListener<string, BuildingConstructingConfig>("BUILDING_START_UPGRADING", RefreshSlot);
		SharedMessenger.RemoveListener<string>("BUILDING_SLOTS_CHANGED", OnSlotChanged);
		SharedMessenger.RemoveListener<string, int, WorkerStatus>("WORKER_STATUS_CHANGED", OnWorkerStatusChange);
		SharedMessenger.RemoveListener<string, int>("BUILDING_UPGRADED", RefreshSlotOnlyOnRepair);
		SharedMessenger.RemoveListener<Building, Dictionary<string, ProductionConfig>>("PRODUCTION_CONFIG_CHANGED", OnBuildingProductionConfigChanged);
	}

	public void OnDestroy()
	{
		((MonoBehaviour)this).StopAllCoroutines();
		UnregisterEventListeners();
	}

	public void SetWorkbenchNominal()
	{
		_WorkbenchNominal = (GameObject[])Workbench.Clone();
		if (WorkShop.BuildingType == "4" || WorkShop.BuildingType == "5" || WorkShop.BuildingType == "6")
		{
			for (int num = 5; num >= 0; num--)
			{
				_WorkbenchNominal[5 - num] = Workbench[num];
			}
		}
		else if (WorkShop.BuildingType == "13" || WorkShop.BuildingType == "8" || WorkShop.BuildingType == "9")
		{
			Array.Reverse(_WorkbenchNominal);
			for (int num2 = 11; num2 >= 6; num2--)
			{
				_WorkbenchNominal[num2] = Workbench[num2 - 6];
			}
		}
	}

	protected void OnWorkerStatusChange(string buildingType, int slotIndex, WorkerStatus newStatus)
	{
		if (buildingType == WorkShop.BuildingType && slotIndex < WorkbenchNominal.Length)
		{
			if (WorkShop.Feature == "MoltenCore")
			{
				RecycleWorkbench component = WorkbenchNominal[slotIndex].GetComponent<RecycleWorkbench>();
				component.SetWorkerStatus(newStatus);
			}
			else
			{
				Workbench component2 = WorkbenchNominal[slotIndex].GetComponent<Workbench>();
				component2.SetWorkerStatus(newStatus);
			}
		}
	}

	public void LoadProductOnWorkbench()
	{
		for (int i = 0; i < WorkbenchNominal.Length; i++)
		{
			ProductionConfig productionConfigAt = WorkShop.GetProductionConfigAt(i);
			GameObject val = WorkbenchNominal[i];
			if (WorkShop.Feature == "MoltenCore")
			{
				RecycleWorkbench component = val.GetComponent<RecycleWorkbench>();
				if ((Object)(object)component == (Object)null)
				{
					continue;
				}
				if (component.Owner == null)
				{
					component.Owner = WorkShop as MoltenCore;
					component.WorkbenchIndex = i;
				}
				if (productionConfigAt.Workers > 0)
				{
					if (component.ProductTaskList == null && productionConfigAt.ProductList.Count > 0)
					{
						_assigningRecycleWorkbenches[i] = productionConfigAt.ProductList;
					}
					else if (_assigningWorkbenches.ContainsKey(i))
					{
						_assigningWorkbenches[i] = productionConfigAt.ProductList;
					}
					else
					{
						component.ProductTaskList = productionConfigAt.ProductList;
					}
				}
				else if (component.ProductTaskList != null)
				{
					component.ProductTaskList = null;
					_assigningRecycleWorkbenches.Remove(i);
				}
				continue;
			}
			Workbench component2 = val.GetComponent<Workbench>();
			if (component2.Owner == null)
			{
				component2.Owner = WorkShop;
				component2.WorkbenchIndex = i;
			}
			if (productionConfigAt.Workers > 0)
			{
				if (component2.ProductTaskList == null && productionConfigAt.ProductList.Count > 0)
				{
					if (!_assigningWorkbenches.ContainsKey(i))
					{
						_assigningWorkbenches.Add(i, productionConfigAt.ProductList);
					}
					else
					{
						_assigningWorkbenches[i] = productionConfigAt.ProductList;
					}
				}
				else
				{
					component2.ProductTaskList = productionConfigAt.ProductList;
					_assigningWorkbenches.Remove(i);
				}
			}
			else if (component2.ProductTaskList != null)
			{
				component2.ProductTaskList = null;
				_assigningWorkbenches.Remove(i);
			}
		}
		AssignedWorkerTasks();
	}

	public async void Delivery(Dictionary<string, int> latestProds)
	{
		Dictionary<string, int> deliveringDict = new Dictionary<string, int>();
		foreach (KeyValuePair<string, int> prodKv in latestProds)
		{
			deliveringDict.Add(prodKv.Key, prodKv.Value);
		}
		foreach (KeyValuePair<string, int> prodKv2 in deliveringDict)
		{
			Object obj = Resources.Load("ProductIcon");
			GameObject prodIconObj = Object.Instantiate<GameObject>((GameObject)(object)((obj is GameObject) ? obj : null), DeliveryPoint);
			ProductIconOnTransporter transporter = prodIconObj.GetComponent<ProductIconOnTransporter>();
			if ((Object)(object)transporter == (Object)null)
			{
				transporter = prodIconObj.AddComponent<ProductIconOnTransporter>();
			}
			SpriteRenderer iconRenderer = prodIconObj.GetComponent<SpriteRenderer>();
			string productIcon = UiHelper.GetIconPath(prodKv2.Key);
			if (WorkShop.BuildingType == "8")
			{
				productIcon = "mount_" + productIcon;
				prodIconObj.transform.localEulerAngles = new Vector3(prodIconObj.transform.localEulerAngles.x, 180f, prodIconObj.transform.localEulerAngles.z);
			}
			transporter.SetSprite(new KeyValuePair<string, int>(productIcon, prodKv2.Value), DeliveryPoint, WorkShop.BuildingType);
			string buildingType = WorkShop.BuildingType;
			if (buildingType == "1" || buildingType == "2")
			{
				transporter.direction = TransporterDirectionUp;
				((Renderer)iconRenderer).sortingOrder = 0;
			}
			else if (buildingType == "3" || buildingType == "12")
			{
				transporter.direction = TransporterDirectionDown;
				((Renderer)iconRenderer).sortingOrder = 2;
				transporter.limitZ = -2f;
			}
			else
			{
				((Renderer)iconRenderer).sortingOrder = 1;
				if (buildingType == "13" || buildingType == "8" || buildingType == "9")
				{
					prodIconObj.transform.localPosition = new Vector3(prodIconObj.transform.localPosition.x, prodIconObj.transform.localPosition.y, -1f);
				}
			}
			await Task.Delay(180);
		}
	}

	private void ReSetSlot(string buildingType, BuildingConstructingConfig info)
	{
		if (WorkShop.BuildingType == buildingType && WorkShop.Feature == "WorkShop" && WorkShop.Level >= 1)
		{
			((Component)this).gameObject.GetComponent<HitArea>().UnlockSlot(WorkShop, info.Workers, info.UpgradeRemainingTime);
			((MonoBehaviour)this).StartCoroutine(RepairTiming(info.UpgradeRemainingTime));
		}
	}

	private void ReSetSlotCollection(string buildingType, BuildingConstructingConfig info)
	{
		if (WorkShop.BuildingType == buildingType && WorkShop.Feature == "Mine" && WorkShop.Level >= 1)
		{
			((Component)this).gameObject.GetComponent<HitArea>().UnlockSlotCollection(WorkShop, info.Workers, info.UpgradeRemainingTime);
			((MonoBehaviour)this).StartCoroutine(RepairTiming(info.UpgradeRemainingTime));
		}
	}

	protected void OnBuildingProductionConfigChanged(Building building, Dictionary<string, ProductionConfig> newProductConfig)
	{
		if (!(WorkShop.BuildingType != building.BuildingType))
		{
			WorkShop.ProductionConfigs = DictionaryExtensions.DeepCopy<string, ProductionConfig>(newProductConfig);
			SetWorkShop();
		}
	}

	protected void RefreshSlot(string buildingType, BuildingConstructingConfig info)
	{
		if (buildingType != WorkShop.BuildingType)
		{
			return;
		}
		ReSetSlot(buildingType, info);
		ReSetSlotCollection(buildingType, info);
		UiAudioManager.Instance.PlaySoundEffect("ConstructionSite");
		if (WorkShop.BuildingType == buildingType && (WorkShop.Feature == "WorkShop" || WorkShop.Feature == "MoltenCore"))
		{
			if (WorkShop.Level >= 1)
			{
				((Component)this).gameObject.GetComponent<HitArea>().RepairBuild(info.Workers, info.UpgradeRemainingTime);
			}
			((MonoBehaviour)this).StartCoroutine(RepairTiming(info.UpgradeRemainingTime));
		}
	}

	protected void OnSlotChanged(string buildingType)
	{
		if (!(buildingType == WorkShop.BuildingType))
		{
			return;
		}
		for (int i = WorkShop.Slot; i < Workbench.Length; i++)
		{
			if (WorkShop.Feature == "MoltenCore")
			{
				RecycleWorkbench component = Workbench[i].GetComponent<RecycleWorkbench>();
				if (component != null)
				{
					component.ProductTaskList = null;
				}
			}
			else
			{
				Workbench component2 = Workbench[i].GetComponent<Workbench>();
				if (component2 != null)
				{
					component2.ProductTaskList = null;
				}
			}
		}
	}

	public void ContinueUpgradeCollection(BuildingConstructingConfig constructingStatus)
	{
		if (WorkShop.Level >= 1 && WorkShop.Status == BuildingStatus.Constructing && constructingStatus.UpgradeRemainingTime > 3)
		{
			((Component)this).gameObject.GetComponent<HitArea>().UnlockSlotCollection(WorkShop, constructingStatus.Workers, constructingStatus.UpgradeRemainingTime);
			((MonoBehaviour)this).StartCoroutine(RepairTiming(constructingStatus.UpgradeRemainingTime));
		}
		else if (WorkShop.Level >= 1 && WorkShop.Status == BuildingStatus.Constructing && constructingStatus.UpgradeRemainingTime <= 3)
		{
			ScriptApi.CreateTimer(3f, delegate
			{
				int expectedLevel = ((WorkShop.Level != 0) ? 1 : 0);
				WorkshopStyleInit(expectedLevel);
				FGUIManager.Instance.SetBuilderIdleUpgradeComplete(WorkShop, constructingStatus.Workers);
			});
		}
		else if (WorkShop.Level >= 1 && WorkShop.Status == BuildingStatus.Ready)
		{
			ScriptApi.CreateTimer(3f, delegate
			{
				int expectedLevel = ((WorkShop.Level != 0) ? 1 : 0);
				WorkshopStyleInit(expectedLevel);
				FGUIManager.Instance.SetBuilderIdleUpgradeComplete(WorkShop, constructingStatus.Workers);
			});
		}
	}

	public void ContinueUpgradeWorkshop(BuildingConstructingConfig ConstructingStatus)
	{
		if (WorkShop.Level >= 1 && WorkShop.Status == BuildingStatus.Constructing && ConstructingStatus.UpgradeRemainingTime > 3)
		{
			((Component)this).gameObject.GetComponent<HitArea>().UnlockSlot(WorkShop, ConstructingStatus.Workers, ConstructingStatus.UpgradeRemainingTime);
			((MonoBehaviour)this).StartCoroutine(RepairTiming(ConstructingStatus.UpgradeRemainingTime));
		}
		else if (WorkShop.Level >= 1 && WorkShop.Status == BuildingStatus.Constructing && ConstructingStatus.UpgradeRemainingTime <= 3)
		{
			ScriptApi.CreateTimer(3f, delegate
			{
				int expectedLevel = ((WorkShop.Level != 0) ? 1 : 0);
				WorkshopStyleInit(expectedLevel);
				FGUIManager.Instance.SetBuilderIdleUpgradeComplete(WorkShop, ConstructingStatus.Workers);
				OpenFlowIEnumerator(WorkShop);
			});
		}
		else if (WorkShop.Level >= 1 && WorkShop.Status == BuildingStatus.Ready)
		{
			ScriptApi.CreateTimer(3f, delegate
			{
				int expectedLevel = ((WorkShop.Level != 0) ? 1 : 0);
				WorkshopStyleInit(expectedLevel);
				FGUIManager.Instance.SetBuilderIdleUpgradeComplete(WorkShop, ConstructingStatus.Workers);
				OpenFlowIEnumerator(WorkShop);
			});
		}
	}

	public void ContinueUpgradeMoltenCore(BuildingConstructingConfig ConstructingStatus)
	{
		if (WorkShop.Level < 1)
		{
			return;
		}
		if (WorkShop.Status == BuildingStatus.Constructing && ConstructingStatus.UpgradeRemainingTime > 3)
		{
			if (WorkShop.Level >= 1)
			{
				((Component)this).gameObject.GetComponent<HitArea>().RepairBuild(ConstructingStatus.Workers, ConstructingStatus.UpgradeRemainingTime);
			}
			((MonoBehaviour)this).StartCoroutine(RepairTiming(ConstructingStatus.UpgradeRemainingTime));
		}
		else if (WorkShop.Status == BuildingStatus.Constructing && ConstructingStatus.UpgradeRemainingTime <= 3)
		{
			ScriptApi.CreateTimer(2f, delegate
			{
				FGUIManager.Instance.SetBuilderIdleStates(WorkShop, ConstructingStatus.Workers);
				FGUIManager.Instance.SetReadyBuildingUpgradeBar(WorkShop);
				WorkshopStyleInit(WorkShop.Level + 1);
			});
		}
		else if (WorkShop.Status == BuildingStatus.Ready)
		{
			ScriptApi.CreateTimer(2f, delegate
			{
				FGUIManager.Instance.SetBuilderIdleStates(WorkShop, ConstructingStatus.Workers);
				FGUIManager.Instance.SetReadyBuildingUpgradeBar(WorkShop);
				WorkshopStyleInit(WorkShop.Level + 1);
			});
		}
	}

	private void LoadAssetSprite(int index, string orientationA, string orientationB, Action action)
	{
		if (spriteList.Count <= 0)
		{
			List<string> list = new List<string>
			{
				"workplace_room_" + orientationA + "_" + WorkShop.BuildingType,
				"workplace_room_" + orientationB + "_" + WorkShop.BuildingType,
				$"workplace_locked_{orientationA}_{index}",
				$"workplace_locked_{orientationB}_{index}"
			};
			int loadCount = 0;
			for (int i = 0; i < list.Count; i++)
			{
				int index2 = i;
				string slotName = list[index2];
				AssetsManager.Instance.LoadAsset<Sprite>(slotName).Then((Action<Sprite>)delegate(Sprite asset)
				{
					spriteList.Add(slotName, asset);
					int num = loadCount;
					loadCount = num + 1;
					if (loadCount >= 4)
					{
						action();
					}
				});
			}
		}
		else
		{
			action();
		}
	}

	public virtual void WorkshopStyleInit(int expectedLevel = 0, bool leaseholdChanged = false)
	{
		if (WorkShop.Feature == "MoltenCore")
		{
			return;
		}
		int level = WorkShop.Level + expectedLevel;
		if (WorkShop.BuildingType == "1" || WorkShop.BuildingType == "2" || WorkShop.BuildingType == "3" || WorkShop.BuildingType == "12")
		{
			return;
		}
		string orientationA = "left";
		string orientationB = "right";
		if (WorkShop.BuildingType == "4" || WorkShop.BuildingType == "5" || WorkShop.BuildingType == "6")
		{
			orientationA = "left";
			orientationB = "right";
		}
		int index = Random.Range(1, 4);
		Action action = delegate
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			//IL_0968: Unknown result type (might be due to invalid IL or missing references)
			//IL_09b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_09e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a16: Unknown result type (might be due to invalid IL or missing references)
			//IL_07d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_081a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0849: Unknown result type (might be due to invalid IL or missing references)
			//IL_087b: Unknown result type (might be due to invalid IL or missing references)
			Material val = new Material(Shader.Find("Sprites/Default"));
			val.renderQueue = slotrenderQueue[WorkShop.BuildingType];
			if (!leaseholdChanged)
			{
				for (int i = 0; i < WorkbenchNominal.Length; i++)
				{
					int key = i;
					if (key < WorkbenchNominal.Length - WorkShop.LeaseholdSlot)
					{
						((Renderer)WorkbenchNominal[key].GetComponent<SpriteRenderer>()).material = val;
						if (expectedLevel == 0)
						{
							if (i < WorkShop.SomeLevelSlot(level))
							{
								if (i < 6)
								{
									string slotName = "workplace_room_" + orientationA + "_" + WorkShop.BuildingType;
									if (spriteList.ContainsKey(slotName))
									{
										WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = spriteList[slotName];
									}
									else
									{
										AssetsManager.Instance.LoadAsset<Sprite>(slotName).Then((Action<Sprite>)delegate(Sprite asset)
										{
											WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = asset;
											if (!spriteList.ContainsKey(slotName))
											{
												spriteList.Add(slotName, asset);
											}
										});
									}
								}
								else
								{
									string slotName2 = "workplace_room_" + orientationB + "_" + WorkShop.BuildingType;
									if (spriteList.ContainsKey(slotName2))
									{
										WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = spriteList[slotName2];
									}
									else
									{
										AssetsManager.Instance.LoadAsset<Sprite>(slotName2).Then((Action<Sprite>)delegate(Sprite asset)
										{
											WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = asset;
											if (!spriteList.ContainsKey(slotName2))
											{
												spriteList.Add(slotName2, asset);
											}
										});
									}
								}
							}
							else if (i < 6)
							{
								string slotName3 = $"workplace_locked_{orientationA}_{index}";
								if (spriteList.ContainsKey(slotName3))
								{
									WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = spriteList[slotName3];
								}
								else
								{
									AssetsManager.Instance.LoadAsset<Sprite>(slotName3).Then((Action<Sprite>)delegate(Sprite asset)
									{
										WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = asset;
										if (!spriteList.ContainsKey(slotName3))
										{
											spriteList.Add(slotName3, asset);
										}
									});
								}
							}
							else
							{
								string slotName4 = $"workplace_locked_{orientationB}_{index}";
								if (spriteList.ContainsKey(slotName4))
								{
									WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = spriteList[slotName4];
								}
								else
								{
									AssetsManager.Instance.LoadAsset<Sprite>(slotName4).Then((Action<Sprite>)delegate(Sprite asset)
									{
										WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = asset;
										if (!spriteList.ContainsKey(slotName4))
										{
											spriteList.Add(slotName4, asset);
										}
									});
								}
							}
						}
						else if (i < WorkShop.SomeLevelSlot(WorkShop.Level))
						{
							if (i < 6)
							{
								string slotName5 = "workplace_room_" + orientationA + "_" + WorkShop.BuildingType;
								if (spriteList.ContainsKey(slotName5))
								{
									WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = spriteList[slotName5];
								}
								else
								{
									AssetsManager.Instance.LoadAsset<Sprite>(slotName5).Then((Action<Sprite>)delegate(Sprite asset)
									{
										WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = asset;
										if (!spriteList.ContainsKey(slotName5))
										{
											spriteList.Add(slotName5, asset);
										}
									});
								}
							}
							else
							{
								string slotName6 = "workplace_room_" + orientationB + "_" + WorkShop.BuildingType;
								if (spriteList.ContainsKey(slotName6))
								{
									WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = spriteList[slotName6];
								}
								else
								{
									AssetsManager.Instance.LoadAsset<Sprite>(slotName6).Then((Action<Sprite>)delegate(Sprite asset)
									{
										WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = asset;
										if (!spriteList.ContainsKey(slotName6))
										{
											spriteList.Add(slotName6, asset);
										}
									});
								}
							}
						}
						else if (i < WorkShop.SomeLevelSlot(level))
						{
							AssetsManager.Instance.LoadAsset<Shader>("MoveLightImage").Then((Action<Shader>)delegate(Shader shader)
							{
								//IL_0002: Unknown result type (might be due to invalid IL or missing references)
								//IL_0008: Expected O, but got Unknown
								Material val4 = new Material(shader);
								val4.renderQueue = slotrenderQueue[WorkShop.BuildingType];
								((Renderer)WorkbenchNominal[key].GetComponent<SpriteRenderer>()).material = val4;
								if (key < 6)
								{
									string slotName11 = "workplace_room_" + orientationA + "_" + WorkShop.BuildingType;
									if (spriteList.ContainsKey(slotName11))
									{
										WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = spriteList[slotName11];
									}
									else
									{
										AssetsManager.Instance.LoadAsset<Sprite>(slotName11).Then((Action<Sprite>)delegate(Sprite asset)
										{
											WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = asset;
											if (!spriteList.ContainsKey(slotName11))
											{
												spriteList.Add(slotName11, asset);
											}
										});
									}
									AssetsManager.Instance.LoadAsset<Texture2D>("workplace_room_" + orientationA + "_" + WorkShop.BuildingType + "_flowBack").Then((Action<Texture2D>)delegate(Texture2D asset)
									{
										((Renderer)WorkbenchNominal[key].GetComponent<SpriteRenderer>()).material.SetTexture("_MaskTex", (Texture)(object)asset);
									});
								}
								else
								{
									string slotName12 = "workplace_room_" + orientationB + "_" + WorkShop.BuildingType;
									if (spriteList.ContainsKey(slotName12))
									{
										WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = spriteList[slotName12];
									}
									else
									{
										AssetsManager.Instance.LoadAsset<Sprite>(slotName12).Then((Action<Sprite>)delegate(Sprite asset)
										{
											WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = asset;
											if (!spriteList.ContainsKey(slotName12))
											{
												spriteList.Add(slotName12, asset);
											}
										});
									}
									AssetsManager.Instance.LoadAsset<Texture2D>("workplace_room_" + orientationB + "_" + WorkShop.BuildingType + "_flowBack").Then((Action<Texture2D>)delegate(Texture2D asset)
									{
										((Renderer)WorkbenchNominal[key].GetComponent<SpriteRenderer>()).material.SetTexture("_MaskTex", (Texture)(object)asset);
									});
								}
								AssetsManager.Instance.LoadAsset<Texture2D>("flow").Then((Action<Texture2D>)delegate(Texture2D asset)
								{
									((Renderer)WorkbenchNominal[key].GetComponent<SpriteRenderer>()).material.SetTexture("_LightTex", (Texture)(object)asset);
								});
								((Renderer)WorkbenchNominal[key].GetComponent<SpriteRenderer>()).material.SetFloat("_uvaddspeed", 0.7f);
							});
						}
						else if (i < 6)
						{
							string slotName7 = $"workplace_locked_{orientationA}_{index}";
							if (spriteList.ContainsKey(slotName7))
							{
								WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = spriteList[slotName7];
							}
							else
							{
								AssetsManager.Instance.LoadAsset<Sprite>(slotName7).Then((Action<Sprite>)delegate(Sprite asset)
								{
									WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = asset;
									if (!spriteList.ContainsKey(slotName7))
									{
										spriteList.Add(slotName7, asset);
									}
								});
							}
						}
						else
						{
							string slotName8 = $"workplace_locked_{orientationB}_{index}";
							if (spriteList.ContainsKey(slotName8))
							{
								WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = spriteList[slotName8];
							}
							else
							{
								AssetsManager.Instance.LoadAsset<Sprite>(slotName8).Then((Action<Sprite>)delegate(Sprite asset)
								{
									WorkbenchNominal[key].GetComponent<SpriteRenderer>().sprite = asset;
									if (!spriteList.ContainsKey(slotName8))
									{
										spriteList.Add(slotName8, asset);
									}
								});
							}
						}
						if (WorkShop.Level == 0 && expectedLevel == 1)
						{
							for (int num = WorkShop.Slot; num < WorkShop.SomeLevelSlot(WorkShop.NextLevel); num++)
							{
								int num2 = num;
								GameObject val2 = SpawnManager.Instance.InstantiatePool("workplaceSmoke_2", Vector3.zero);
								if ((Object)(object)val2 != (Object)null)
								{
									val2.transform.position = ((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[num2].transform.position;
									val2.transform.eulerAngles = ((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[num2].transform.eulerAngles;
									val2.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
									val2.transform.localScale = new Vector3(1f, 1f, 1f);
								}
							}
						}
					}
				}
			}
			if (WorkShop.LeaseholdSlot > 0 && WorkShop.Level > 0)
			{
				for (int num3 = 0; num3 < WorkShop.LeaseholdSlot; num3++)
				{
					int leaseIndex = WorkbenchNominal.Length - num3 - 1;
					((Renderer)WorkbenchNominal[leaseIndex].GetComponent<SpriteRenderer>()).material = val;
					GameObject val3 = SpawnManager.Instance.InstantiatePool("workplaceSmoke_2", Vector3.zero);
					if ((Object)(object)val3 != (Object)null)
					{
						val3.transform.position = ((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[leaseIndex].transform.position;
						val3.transform.eulerAngles = ((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[leaseIndex].transform.eulerAngles;
						val3.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
						val3.transform.localScale = new Vector3(1f, 1f, 1f);
					}
					if (leaseIndex < 6)
					{
						string slotName9 = "workplace_room_" + orientationA + "_" + WorkShop.BuildingType;
						if (spriteList.ContainsKey(slotName9))
						{
							WorkbenchNominal[leaseIndex].GetComponent<SpriteRenderer>().sprite = spriteList[slotName9];
						}
						else
						{
							AssetsManager.Instance.LoadAsset<Sprite>(slotName9).Then((Action<Sprite>)delegate(Sprite asset)
							{
								WorkbenchNominal[leaseIndex].GetComponent<SpriteRenderer>().sprite = asset;
								if (!spriteList.ContainsKey(slotName9))
								{
									spriteList.Add(slotName9, asset);
								}
							});
						}
					}
					else
					{
						string slotName10 = "workplace_room_" + orientationB + "_" + WorkShop.BuildingType;
						if (spriteList.ContainsKey(slotName10))
						{
							WorkbenchNominal[leaseIndex].GetComponent<SpriteRenderer>().sprite = spriteList[slotName10];
						}
						else
						{
							AssetsManager.Instance.LoadAsset<Sprite>(slotName10).Then((Action<Sprite>)delegate(Sprite asset)
							{
								WorkbenchNominal[leaseIndex].GetComponent<SpriteRenderer>().sprite = asset;
								if (!spriteList.ContainsKey(slotName10))
								{
									spriteList.Add(slotName10, asset);
								}
							});
						}
					}
				}
			}
		};
		LoadAssetSprite(index, orientationA, orientationB, action);
	}

	public async void AssignedWorkerTasks()
	{
		if (_isAssigningWorkers)
		{
			return;
		}
		_isAssigningWorkers = true;
		if (WorkShop.Feature == "MoltenCore")
		{
			while (_assigningRecycleWorkbenches.Count > 0)
			{
				KeyValuePair<int, List<string>> workbenchInfo = _assigningRecycleWorkbenches.First();
				RecycleWorkbench workbenchScript = WorkbenchNominal[workbenchInfo.Key].GetComponent<RecycleWorkbench>();
				if ((Object)(object)workbenchScript != (Object)null)
				{
					List<string> workbenchProdTask = workbenchInfo.Value;
					_assigningRecycleWorkbenches.Remove(workbenchInfo.Key);
					workbenchScript.ProductTaskList = workbenchProdTask;
					if (_assigningRecycleWorkbenches.Count <= 0)
					{
						_isAssigningWorkers = false;
						return;
					}
				}
				await Task.Delay(1000);
			}
		}
		else
		{
			while (_assigningWorkbenches.Count > 0)
			{
				KeyValuePair<int, List<string>> workbenchInfo2 = _assigningWorkbenches.First();
				Workbench workbenchScript2 = WorkbenchNominal[workbenchInfo2.Key].GetComponent<Workbench>();
				List<string> workbenchProdTask2 = workbenchInfo2.Value;
				_assigningWorkbenches.Remove(workbenchInfo2.Key);
				workbenchScript2.ProductTaskList = workbenchProdTask2;
				if (_assigningWorkbenches.Count <= 0)
				{
					_isAssigningWorkers = false;
					return;
				}
				await Task.Delay(1000);
			}
		}
		_isAssigningWorkers = false;
	}

	private IEnumerator RepairTiming(int time)
	{
		HitArea hitArea = WorkShop.GameObject.GetComponent<HitArea>();
		BuildingConstructingConfig info = WorkShop.ConstructingConfig;
		if (info.UpgradeRemainingTime <= 0)
		{
			PlayWorkshopRepairedSfx();
			FGUIManager.Instance.BuildingUpgradeBarRefresh(WorkShop);
			yield return (object)new WaitForSeconds(1f);
		}
		while (info.UpgradeRemainingTime > 0)
		{
			if (info.UpgradeRemainingTime <= 1 && !hitArea.haveSmoke)
			{
				if (WorkShop.Feature == "Mine")
				{
					ScriptApi.CreateTimer(0.95f, delegate
					{
						//IL_000b: Unknown result type (might be due to invalid IL or missing references)
						//IL_003e: Unknown result type (might be due to invalid IL or missing references)
						//IL_0064: Unknown result type (might be due to invalid IL or missing references)
						//IL_0094: Unknown result type (might be due to invalid IL or missing references)
						GameObject val = SpawnManager.Instance.InstantiatePool("workplaceSmoke", Vector3.zero);
						if ((Object)(object)val != (Object)null)
						{
							val.transform.position = WorkShop.GameObject.transform.position;
							val.transform.eulerAngles = WorkShop.GameObject.transform.eulerAngles;
							val.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
							val.transform.localScale = new Vector3(3f, 3f, 3f);
						}
					});
				}
				else if (WorkShop.Feature == "MoltenCore")
				{
					ScriptApi.CreateTimer(1.95f, delegate
					{
						//IL_000b: Unknown result type (might be due to invalid IL or missing references)
						//IL_0051: Unknown result type (might be due to invalid IL or missing references)
						//IL_0077: Unknown result type (might be due to invalid IL or missing references)
						GameObject val = SpawnManager.Instance.InstantiatePool("buildingSmoke", Vector3.zero);
						if ((Object)(object)val != (Object)null && !hitArea.haveSmoke)
						{
							val.transform.eulerAngles = WorkShop.GameObject.transform.eulerAngles;
							val.transform.position = WorkShop.GameObject.transform.position;
							val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
							hitArea.haveSmoke = true;
						}
					});
				}
				else
				{
					for (int i = WorkShop.Slot; i < WorkShop.SomeLevelSlot(WorkShop.NextLevel); i++)
					{
						int index = i;
						ScriptApi.CreateTimer(0.95f, delegate
						{
							//IL_000b: Unknown result type (might be due to invalid IL or missing references)
							//IL_0052: Unknown result type (might be due to invalid IL or missing references)
							//IL_0089: Unknown result type (might be due to invalid IL or missing references)
							//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
							GameObject val = SpawnManager.Instance.InstantiatePool("workplaceSmoke_2", Vector3.zero);
							if ((Object)(object)val != (Object)null)
							{
								val.transform.position = ((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[index].transform.position;
								val.transform.eulerAngles = ((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[index].transform.eulerAngles;
								val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
								val.transform.localScale = new Vector3(1f, 1f, 1f);
							}
						});
					}
					ScriptApi.CreateTimer(0.95f, delegate
					{
						//IL_000b: Unknown result type (might be due to invalid IL or missing references)
						//IL_0041: Unknown result type (might be due to invalid IL or missing references)
						//IL_0067: Unknown result type (might be due to invalid IL or missing references)
						//IL_0097: Unknown result type (might be due to invalid IL or missing references)
						//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
						//IL_00be: Unknown result type (might be due to invalid IL or missing references)
						//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
						GameObject val = SpawnManager.Instance.InstantiatePool("workplaceSmoke_2", Vector3.zero);
						if ((Object)(object)val != (Object)null)
						{
							val.transform.eulerAngles = WorkShop.GameObject.transform.eulerAngles;
							val.transform.position = WorkShop.GameObject.transform.position;
							val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
							val.transform.localScale = new Vector3(2f, 2f, 2f);
							val.transform.localPosition = new Vector3(val.transform.localPosition.x, val.transform.localPosition.y, -0.1f);
						}
					});
				}
				ScriptApi.CreateTimer(0.95f, delegate
				{
					hitArea.haveSmoke = true;
				});
			}
			FGUIManager.Instance.BuildingUpgradeBarRefresh(WorkShop);
			yield return (object)new WaitForSeconds(1f);
		}
		((Component)this).gameObject.GetComponent<HitArea>().isStartRepair = false;
		int level = ((WorkShop.Level != 0) ? 1 : 0);
		WorkshopStyleInit(level);
		if (workerNum != null)
		{
			((GObject)workerNum).alpha = ((level > 0) ? 1 : 0);
		}
		FGUIManager.Instance.LoadBuildings(WorkShop, isInit: false, 1);
		for (int i2 = 0; i2 < 5; i2++)
		{
			if (((Component)hitArea.hitData.builders.transform.GetChild(i2)).gameObject.activeInHierarchy)
			{
				((Component)hitArea.hitData.builders.transform.GetChild(i2)).GetComponent<SkeletonAnimation>().AnimationName = "idle";
			}
		}
		ScriptApi.CreateTimer((WorkShop.Feature == "MoltenCore") ? 1.05f : 0.45f, delegate
		{
			for (int num = hitArea.smokes.Count - 1; num >= 0; num--)
			{
				Object.Destroy((Object)(object)hitArea.smokes[num]);
			}
			hitArea.smokes.Clear();
		});
		OpenFlowIEnumerator(WorkShop);
	}

	private void PlayWorkshopRepairedSfx()
	{
		HitArea hitArea = WorkShop.GameObject.GetComponent<HitArea>();
		if (hitArea.haveSmoke)
		{
			return;
		}
		if (WorkShop.Feature == "Mine")
		{
			ScriptApi.CreateTimer(0.95f, delegate
			{
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				//IL_003e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0064: Unknown result type (might be due to invalid IL or missing references)
				//IL_0094: Unknown result type (might be due to invalid IL or missing references)
				GameObject val = SpawnManager.Instance.InstantiatePool("workplaceSmoke", Vector3.zero);
				if ((Object)(object)val != (Object)null)
				{
					val.transform.position = WorkShop.GameObject.transform.position;
					val.transform.eulerAngles = WorkShop.GameObject.transform.eulerAngles;
					val.AddComponent<HotFix_DestroySelf>().destroyTime = 0.6f;
					val.transform.localScale = new Vector3(3f, 3f, 3f);
				}
			});
		}
		else if (WorkShop.Feature == "MoltenCore")
		{
			ScriptApi.CreateTimer(1.95f, delegate
			{
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0051: Unknown result type (might be due to invalid IL or missing references)
				//IL_0077: Unknown result type (might be due to invalid IL or missing references)
				GameObject val = SpawnManager.Instance.InstantiatePool("buildingSmoke", Vector3.zero);
				if ((Object)(object)val != (Object)null && !hitArea.haveSmoke)
				{
					val.transform.eulerAngles = WorkShop.GameObject.transform.eulerAngles;
					val.transform.position = WorkShop.GameObject.transform.position;
					val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
					hitArea.haveSmoke = true;
				}
			});
		}
		else
		{
			ScriptApi.CreateTimer(0.95f, delegate
			{
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0041: Unknown result type (might be due to invalid IL or missing references)
				//IL_0067: Unknown result type (might be due to invalid IL or missing references)
				//IL_0097: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
				//IL_00be: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
				GameObject val = SpawnManager.Instance.InstantiatePool("workplaceSmoke_2", Vector3.zero);
				if ((Object)(object)val != (Object)null)
				{
					val.transform.eulerAngles = WorkShop.GameObject.transform.eulerAngles;
					val.transform.position = WorkShop.GameObject.transform.position;
					val.AddComponent<HotFix_DestroySelf>().destroyTime = 1f;
					val.transform.localScale = new Vector3(2f, 2f, 2f);
					val.transform.localPosition = new Vector3(val.transform.localPosition.x, val.transform.localPosition.y, -0.1f);
				}
			});
		}
		ScriptApi.CreateTimer(0.95f, delegate
		{
			hitArea.haveSmoke = true;
		});
	}

	protected void RefreshSlotOnlyOnRepair(string buildingType, int level)
	{
		if (!(WorkShop.Feature == "MoltenCore") && buildingType == WorkShop.BuildingType && level >= 1)
		{
			WorkshopStyleInit();
		}
	}

	public void OpenFlowIEnumerator(Building building)
	{
		if (building.Feature == "WorkShop" && building.Level != 0)
		{
			IEnumerator enumerator = FlowLight(building);
			((MonoBehaviour)this).StartCoroutine(enumerator);
			if (!FGUIManager.Instance.slotFlowLight.ContainsKey(building.BuildingType ?? ""))
			{
				FGUIManager.Instance.slotFlowLight.Add(building.BuildingType ?? "", enumerator);
			}
		}
	}

	public IEnumerator FlowLight(Building building)
	{
		building.GameObject.GetComponent<HitArea>();
		while (true)
		{
			float time = Time.realtimeSinceStartup;
			int decade = (int)time / 10;
			float amend = time - (float)(10 * decade);
			for (int i = WorkShop.Slot; i < WorkShop.SomeLevelSlot(WorkShop.NextLevel); i++)
			{
				if (1.4 <= (double)amend && amend <= 3f)
				{
					((Renderer)((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[i].GetComponent<SpriteRenderer>()).material.SetFloat("_uvaddspeed", amend / 2f + (float)(i - WorkShop.Slot) / 10f);
				}
				else
				{
					((Renderer)((Component)this).gameObject.GetComponent<WorkshopController>().WorkbenchNominal[i].GetComponent<SpriteRenderer>()).material.SetFloat("_uvaddspeed", 0.7f);
				}
			}
			yield return null;
		}
	}
}
