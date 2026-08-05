using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.Scripts.UI;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Core.PathCore;
using DG.Tweening.Plugins.Options;
using FairyGUI;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Spine.Unity;
using UnityEngine;

public class MoltenCoreWorkerController : GoblinController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static TweenCallback _003C_003E9__92_1;

		internal void _003CSetupTweener_003Eb__92_1()
		{
		}
	}

	private const string AnimationCarry = "carry";

	private const string AnimationRun = "run";

	private const string AnimationIdle = "idle";

	private const string AnimationSleep = "sleep";

	private const string AnimationSeriousFace = "emoji1";

	private const string AnimationHammer = "work1_1";

	private const string AnimationSeesaw = "work2_1";

	private const string AnimationFlask = "work3_1";

	private const string AnimationWriting = "work4_1";

	private const string AnimationFork = "work5_1";

	private const float NormalTimeScale = 1f;

	private const float DreamTimeScale = 0f;

	private const float FireTimeScale = 2f;

	private SkeletonAnimation _workerAnimation;

	private MeshRenderer _workerRenderer;

	public GameObject product;

	private SpriteRenderer productRenderer;

	private int CurMoneyNum;

	private string curProductName;

	private float _x;

	private TweenCallback<int> toPointChange;

	private GameObject bubble;

	public GameObject FireIcon;

	public GameObject DreamIcon;

	private Tweener CurrentTweener;

	private float baseTimeScale = 1f;

	public WorkerInfo workerInfo;

	private float _workerSpeed = 1f;

	private string waitingRequirementName;

	private string waitingStockSpaceName;

	public string WaitingMaterialId;

	public WorkerStatus WorkerStatus = WorkerStatus.Normal;

	public WorkerActiveState workerActiveState;

	public WorkerPathState workerPathState;

	public RecycleWorkbench Workbench;

	public MoltenCoreController WorkshopController;

	private float workbenchToStartToBedroomSpeed;

	private float workbenchToStartSpeed;

	private float bedroomToStartSpeed;

	private float startToWorkbenchSpeed;

	private float workbenchToFinishSpeed;

	private float finishToStartSpeed;

	private float startToBedroomSpeed;

	private float workbenchToBedroomSpeed;

	private float finishToBedroomSpeed;

	private StorehouseController _storehouseController;

	public GameObject FinishIcon;

	public SpriteRenderer FinishIconRenderer;

	public SpriteRenderer FinishIconRenderer2nd;

	public Tweener BedroomToStartTweener;

	public Transform[] BedroomToStartPath;

	public Tweener StartToWorkbenchTweener;

	public Transform[] StartToWorkbenchPath;

	public Tweener WorkbenchToFinishTweener;

	public Transform[] WorkbenchToFinishPath;

	public Tweener FinishToStartTweener;

	public Transform[] FinishToStartPath;

	public Tweener StartToBedroomTweener;

	public Transform[] StartToBedroomPath;

	public Tweener WorkbenchToBedroomTweener;

	public Transform[] WorkbenchToBedroomPath;

	public Tweener FinishToBedroomTweener;

	public Transform[] FinishToBedroomPath;

	public bool returnMaterial;

	private bool is_init = false;

	private float workerTimeScale
	{
		get
		{
			return 1f;
		}
		set
		{
			baseTimeScale = value;
		}
	}

	public float WorkerSpeed => 1f;

	private void Awake()
	{
		_workerAnimation = ((Component)((Component)this).transform).GetComponent<SkeletonAnimation>();
		GameController.Contexts.Service<BaseSceneService>().AddMoltenCoreWorker(this);
		GameController.Contexts.Service<BaseSceneService>().AddSkeletonAnimation(_workerAnimation);
		is_init = false;
	}

	private void Start()
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		workerActiveState = WorkerActiveState.Resting;
		workerPathState = WorkerPathState.InTheRest;
		WorkerStatus = WorkerStatus.Normal;
		selfIndex = Array.IndexOf(WorkshopController.Workbench, ((Component)((Component)this).transform.parent).gameObject);
		BuildingType = WorkshopController.WorkShop.BuildingType;
		_storehouseController = GameManagers.Instance.BuildingManager.GetBuildingByType("11").GameObject.GetComponent<StorehouseController>();
		if (BedroomToStartPath.Length != 0)
		{
			Vector3 position = BedroomToStartPath.First().position;
			((Component)this).transform.position = position;
			_x = position.x;
		}
		_workerRenderer = ((Component)((Component)this).transform).GetComponent<MeshRenderer>();
		FinishIconRenderer = FinishIcon.GetComponent<SpriteRenderer>();
		GameObject val = new GameObject();
		val.transform.parent = FinishIcon.transform;
		val.transform.localPosition = new Vector3(0f, 0.5f, 0.1f);
		val.transform.localScale = new Vector3(1f, 1f, 1f);
		FinishIconRenderer2nd = val.AddComponent<SpriteRenderer>();
		productRenderer = product.GetComponent<SpriteRenderer>();
		Workbench.moltenCoreWorkerController = this;
		is_init = true;
	}

	private void OnDestroy()
	{
	}

	private void Update()
	{
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		if (!is_init || Workbench.IsProducing)
		{
			return;
		}
		if (Workbench.IsPaused)
		{
			if (CurrentTweener != null)
			{
				((Tween)CurrentTweener).timeScale = 0f;
			}
			return;
		}
		if (CurrentTweener != null && Math.Abs(((Tween)CurrentTweener).timeScale - workerTimeScale) > 0.01f)
		{
			((Tween)CurrentTweener).timeScale = workerTimeScale;
		}
		if (Workbench.IsInterrupted)
		{
			Workbench.IsInterrupted = false;
			if (workerPathState == WorkerPathState.InProduction)
			{
				BenchToFinish();
			}
		}
		SetWorkerActiveState();
		if (_workerAnimation.AnimationName != "idle")
		{
			float num = ((Component)this).transform.position.x - _x;
			if (Math.Abs(num) > float.Epsilon)
			{
				((SkeletonRenderer)_workerAnimation).skeleton.FlipX = num > 0f;
			}
			_x += num;
		}
		if (workerActiveState == WorkerActiveState.Resting)
		{
			if (workerPathState == WorkerPathState.WaitMaterial || workerPathState == WorkerPathState.WaitStock)
			{
				StartToBedroom();
			}
		}
		else if (workerActiveState == WorkerActiveState.Working)
		{
			if (workerPathState == WorkerPathState.WaitMaterial || workerPathState == WorkerPathState.WaitStock)
			{
				StartToWorkbench();
			}
			else if (workerPathState == WorkerPathState.InTheRest)
			{
				BedroomToStart();
			}
		}
		else if ((workerActiveState == WorkerActiveState.Stockout || workerActiveState == WorkerActiveState.StockFull) && workerPathState == WorkerPathState.InTheRest)
		{
			BedroomToStart();
		}
	}

	private void SetWorkerActiveState()
	{
		if (Workbench.ProductTaskList == null)
		{
			workerActiveState = WorkerActiveState.Resting;
		}
		else if (Workbench.ProductTaskList != null && Workbench.CanProduce())
		{
			workerActiveState = WorkerActiveState.Working;
		}
		else if (Workbench.IsWaitingStockSpace)
		{
			workerActiveState = WorkerActiveState.StockFull;
		}
		else if (Workbench.IsWaitingMaterial)
		{
			workerActiveState = WorkerActiveState.Stockout;
		}
	}

	public void SetWorkerPathTweener()
	{
		if (workerPathState == WorkerPathState.BedroomToStart || workerPathState == WorkerPathState.FinishToStart)
		{
			if (workerActiveState == WorkerActiveState.Working)
			{
				StartToWorkbench();
			}
			else if (workerActiveState == WorkerActiveState.Resting)
			{
				StartToBedroom();
			}
			else if (workerActiveState == WorkerActiveState.StockFull || workerActiveState == WorkerActiveState.Stockout)
			{
				returnMaterial = false;
				_workerAnimation.AnimationName = "idle";
				if (workerActiveState == WorkerActiveState.StockFull)
				{
					workerPathState = WorkerPathState.WaitStock;
					ShowWaitingStockSpaceBubble();
				}
				else if (workerActiveState == WorkerActiveState.Stockout)
				{
					workerPathState = WorkerPathState.WaitMaterial;
					ShowWaitingMaterialBubble(Workbench.WaitingMaterial);
				}
			}
		}
		else if (workerPathState == WorkerPathState.StartToBench)
		{
			if (Workbench.IsInterrupted)
			{
				returnMaterial = true;
			}
			int num = (int)WorkshopController.workerNum.GetChild("title").data;
			WorkshopController.workerNum.GetChild("title").text = $"{num + 1}";
			WorkshopController.workerNum.GetChild("title").data = num + 1;
			if (workerActiveState == WorkerActiveState.Working)
			{
				StartProduce();
			}
			else if (workerActiveState == WorkerActiveState.StockFull || workerActiveState == WorkerActiveState.Stockout)
			{
				BenchToFinish();
			}
			else if (workerActiveState == WorkerActiveState.Resting)
			{
				BenchToBedroom();
			}
		}
		else if (workerPathState == WorkerPathState.InProduction)
		{
			if (Workbench.IsInterrupted)
			{
				returnMaterial = true;
			}
			if (workerActiveState != WorkerActiveState.Resting)
			{
				BenchToFinish();
			}
			else if (workerActiveState == WorkerActiveState.Resting)
			{
				BenchToBedroom();
			}
		}
		else if (workerPathState == WorkerPathState.BenchToFinish)
		{
			if (workerActiveState == WorkerActiveState.Resting)
			{
				FinishToBedroom();
			}
			else
			{
				FinishToStart();
			}
			_storehouseController.PlayDragonMouthExplosion(CurMoneyNum);
		}
	}

	public void BedroomToStart()
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		workerPathState = WorkerPathState.BedroomToStart;
		SetupTweener(ref BedroomToStartTweener, ref bedroomToStartSpeed, TransformListToPosArray(BedroomToStartPath), "run", new TweenCallback(SetWorkerPathTweener));
		FGUIManager.Instance.SetGoblinTitle(this);
		FGUIManager.Instance.WorkerTitleFade(this, 1f);
	}

	public void StartToWorkbench()
	{
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		returnMaterial = false;
		workerPathState = WorkerPathState.StartToBench;
		UiHelper.GetProductLoader(((Component)FinishIconRenderer).gameObject, "");
		if (!((Object)(object)Workbench == (Object)null) && Workbench.ResultList != null && Workbench.ResultList.Count != 0)
		{
			RecycleProduct recycleProduct = Workbench.ResultList.First();
			string text = ((recycleProduct.Requirements.Count > 0) ? recycleProduct.Requirements.First().Key : "sack3");
			if (text == "sack3")
			{
				UiHelper.GetProductLoader(((Component)FinishIconRenderer).gameObject, "sack3");
				curProductName = "sack3";
			}
			else
			{
				string iconPath = UiHelper.GetIconPath(text);
				UiHelper.GetProductLoader(((Component)FinishIconRenderer).gameObject, iconPath);
				curProductName = iconPath;
			}
			if (bubble != null)
			{
				Object.Destroy((Object)(object)bubble);
				waitingRequirementName = "";
				waitingStockSpaceName = "";
				WaitingMaterialId = "";
			}
			SetupTweener(ref StartToWorkbenchTweener, ref startToWorkbenchSpeed, TransformListToPosArray(StartToWorkbenchPath), "carry", new TweenCallback(SetWorkerPathTweener));
		}
	}

	public void StartToBedroom()
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		returnMaterial = false;
		workerPathState = WorkerPathState.StartToBedroom;
		UiHelper.GetProductLoader(((Component)FinishIconRenderer).gameObject, "");
		if (bubble != null)
		{
			Object.Destroy((Object)(object)bubble);
			waitingRequirementName = "";
			waitingStockSpaceName = "";
			WaitingMaterialId = "";
		}
		SetupTweener(ref StartToBedroomTweener, ref startToBedroomSpeed, TransformListToPosArray(StartToBedroomPath), "run", new TweenCallback(OnArrivedBedroom));
		FGUIManager.Instance.ClearGoblinTitle(this);
	}

	public void BenchToBedroom()
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		workerPathState = WorkerPathState.BenchToBedroom;
		UiHelper.GetProductLoader(((Component)FinishIconRenderer).gameObject, "");
		if (bubble != null)
		{
			Object.Destroy((Object)(object)bubble);
			waitingRequirementName = "";
			waitingStockSpaceName = "";
			WaitingMaterialId = "";
		}
		SetupTweener(ref WorkbenchToBedroomTweener, ref workbenchToBedroomSpeed, TransformListToPosArray(WorkbenchToBedroomPath), "run", new TweenCallback(OnArrivedBedroom));
		int num = (int)WorkshopController.workerNum.GetChild("title").data;
		WorkshopController.workerNum.GetChild("title").text = $"{num - 1}";
		WorkshopController.workerNum.GetChild("title").data = num - 1;
		FGUIManager.Instance.ClearGoblinTitle(this);
	}

	public void FinishToBedroom()
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		workerPathState = WorkerPathState.FinishToBedroom;
		UiHelper.GetProductLoader(((Component)FinishIconRenderer).gameObject, "");
		if (bubble != null)
		{
			Object.Destroy((Object)(object)bubble);
			waitingRequirementName = "";
			waitingStockSpaceName = "";
			WaitingMaterialId = "";
		}
		SetupTweener(ref FinishToBedroomTweener, ref finishToBedroomSpeed, TransformListToPosArray(FinishToBedroomPath), "run", new TweenCallback(OnArrivedBedroom));
		FGUIManager.Instance.ClearGoblinTitle(this);
	}

	public void BenchToFinish()
	{
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		FGUIManager.Instance.WorkerTitleFade(this, 1f);
		int num = (int)WorkshopController.workerNum.GetChild("title").data;
		WorkshopController.workerNum.GetChild("title").text = $"{num - 1}";
		WorkshopController.workerNum.GetChild("title").data = num - 1;
		workerPathState = WorkerPathState.BenchToFinish;
		string workerAnimation = "run";
		if (Workbench.LatestProductions.Count > 0)
		{
			workerAnimation = "carry";
			string[] array = Workbench.LatestProductions.Keys.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				string key = array[i];
				int num2 = Workbench.LatestProductions[key];
				switch (i)
				{
				case 0:
				{
					UiHelper.GetProductLoader(((Component)FinishIconRenderer).gameObject, "sack5");
					Vector3 localPosition = FinishIcon.transform.localPosition;
					((Vector3)(ref localPosition))._002Ector(localPosition.x, 4f, localPosition.z);
					FinishIcon.transform.localPosition = localPosition;
					break;
				}
				case 1:
					((Renderer)FinishIconRenderer2nd).sortingOrder = 1;
					break;
				}
			}
			FGUIManager.Instance.WorkerTitleFade(this, 1f);
		}
		else if (returnMaterial)
		{
			workerAnimation = "carry";
			UiHelper.GetProductLoader(((Component)FinishIconRenderer).gameObject, curProductName);
			Vector3 localPosition2 = FinishIcon.transform.localPosition;
			((Vector3)(ref localPosition2))._002Ector(localPosition2.x, 4f, localPosition2.z);
			FinishIcon.transform.localPosition = localPosition2;
			FGUIManager.Instance.WorkerTitleFade(this, 1f);
			CurMoneyNum = 1;
		}
		SetupTweener(ref WorkbenchToFinishTweener, ref workbenchToFinishSpeed, TransformListToPosArray(WorkbenchToFinishPath), workerAnimation, new TweenCallback(SetWorkerPathTweener));
	}

	public void FinishToStart()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		workerPathState = WorkerPathState.FinishToStart;
		UiHelper.GetProductLoader(((Component)FinishIconRenderer).gameObject, "");
		SetupTweener(ref FinishToStartTweener, ref finishToStartSpeed, TransformListToPosArray(FinishToStartPath), "run", new TweenCallback(SetWorkerPathTweener));
	}

	public void OnArrivedBedroom()
	{
		workerPathState = WorkerPathState.InTheRest;
		Dictionary<int, InvitedWorker> invitedWorkers = GameManagers.Instance.FriendsManager.InvitedWorkers;
		Dictionary<int, Tuple<int, string, int>> value = GameManagers.Instance.FriendsManager.InvitingSlotsConfig.GetValue();
		foreach (InvitedWorker value3 in invitedWorkers.Values)
		{
			KeyValuePair<string, int> allocateInfo = value3.AllocateInfo;
			string key = allocateInfo.Key;
			int value2 = allocateInfo.Value;
			if (!(BuildingType == key) || selfIndex != value2)
			{
				continue;
			}
			{
				foreach (KeyValuePair<int, Tuple<int, string, int>> item in value)
				{
					if (item.Value.Item1 == value3.InvitedUserId)
					{
						FGUIManager.Instance.ClearGoblinTitle(this);
						GameController.Contexts.Service<INetworkService>().AssignInvitedWorker(item.Key, value3.InvitedUserId, null, -1);
						GameManagers.Instance.FriendsManager.AssignInvitedWorker(item.Key, value3.InvitedUserId);
						break;
					}
				}
				break;
			}
		}
	}

	public void StartProduce()
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		if (!Workbench.IsProducing)
		{
			FGUIManager.Instance.WorkerTitleFade(this, 0f);
			workerPathState = WorkerPathState.InProduction;
			UiHelper.GetProductLoader(((Component)FinishIconRenderer).gameObject, "");
			((Component)FinishIconRenderer).gameObject.transform.localScale = new Vector3(3.75f, 3.75f, 1f);
			CurMoneyNum = Workbench.Produce();
			if (Workbench.IsProducing)
			{
				_workerAnimation.AnimationName = WorkshopController.ProcessingActionName;
				Workbench.AfterProduce(new TweenCallback(SetWorkerPathTweener));
				Workbench.OnStartProduce();
			}
			else
			{
				CurMoneyNum = 0;
				BenchToFinish();
			}
		}
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (workerActiveState != WorkerActiveState.Stockout || !(itemId == WaitingMaterialId) || !((Object)(object)bubble != (Object)null))
		{
			return;
		}
		RecycleProduct recycleProduct = Workbench.ProductList.First();
		string recycleProductId = recycleProduct.RecycleProductId;
		if (!BuildingManager.ProductRequirements.TryGetValue(recycleProductId, out var value))
		{
			return;
		}
		foreach (KeyValuePair<string, int> item in value)
		{
			if (!(item.Key == Workbench.WaitingMaterial))
			{
				continue;
			}
			UIPanel component = ((Component)bubble.transform.Find("WorkerBubbleUi")).gameObject.GetComponent<UIPanel>();
			component.ui.GetChild("MateriaNuml").alpha = 1f;
			int stock = GameManagers.Instance.StockController.GetStock(item.Key);
			component.ui.GetChild("MateriaNuml").sortingOrder = 100;
			component.ui.GetChild("MateriaNuml").asCom.GetChild("curNum").text = $"{stock}";
			component.ui.GetChild("MateriaNuml").asCom.GetChild("sprit").text = "/";
			component.ui.GetChild("MateriaNuml").asCom.GetChild("requireNum").text = $"{item.Value}";
			component.ui.GetChild("MateriaNuml").SetPivot(0.5f, 0.5f, true);
			component.ui.GetChild("MateriaNuml").SetXY(component.ui.GetChild("icon").x, component.ui.GetChild("icon").y + 46f);
			if (stock < item.Value || workerActiveState != WorkerActiveState.Stockout)
			{
				break;
			}
			{
				foreach (KeyValuePair<string, int> item2 in value)
				{
					if (GameManagers.Instance.StockController.GetStock(item2.Key) < item2.Value)
					{
						WaitingMaterialId = item2.Key;
						ShowWaitingMaterialBubble(WaitingMaterialId);
					}
				}
				break;
			}
		}
	}

	private void ShowWaitingMaterialBubble(string innerIconName)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)bubble == (Object)null)
		{
			bubble = Object.Instantiate<GameObject>(Resources.Load<GameObject>("bubble"), ((Component)this).transform);
			UIPanel val = ((Component)bubble.transform.Find("WorkerBubbleUi")).gameObject.AddComponent<UIPanel>();
			val.packageName = "PublicResources";
			val.componentName = "WorkerBubble";
			val.container.renderMode = (RenderMode)2;
			val.SetSortingOrder(3, true);
			val.CreateUI();
			((Component)val).transform.localScale = ((Component)val).transform.localScale * 1.25f;
		}
		bubble.transform.localScale = new Vector3(3f, 3f, 3f);
		bubble.transform.localPosition = new Vector3(0.5f, 6f, 0f);
		WaitingMaterialId = innerIconName;
		UIPanel component = ((Component)bubble.transform.Find("WorkerBubbleUi")).gameObject.GetComponent<UIPanel>();
		component.ui.GetChild("max").alpha = 0f;
		component.ui.GetChild("MateriaNuml").alpha = 0f;
		waitingRequirementName = UiHelper.GetIconPath(innerIconName);
		component.ui.GetChild("icon").asLoader.url = "ui://PublicResources/" + waitingRequirementName;
		RecycleProduct recycleProduct = Workbench.ProductList.First();
		string recycleProductId = recycleProduct.RecycleProductId;
		if (!BuildingManager.ProductRequirements.TryGetValue(recycleProductId, out var value))
		{
			return;
		}
		foreach (KeyValuePair<string, int> item in value)
		{
			if (item.Key == innerIconName)
			{
				component.ui.GetChild("MateriaNuml").alpha = 1f;
				component.ui.GetChild("MateriaNuml").asCom.GetChild("curNum").text = $"{GameManagers.Instance.StockController.GetStock(item.Key)}";
				component.ui.GetChild("MateriaNuml").asCom.GetChild("sprit").text = "/";
				component.ui.GetChild("MateriaNuml").asCom.GetChild("requireNum").text = $"{item.Value}";
				component.ui.GetChild("MateriaNuml").SetPivot(0.5f, 0.5f, true);
				component.ui.GetChild("MateriaNuml").SetXY(component.ui.GetChild("icon").x, component.ui.GetChild("icon").y + 46f);
				break;
			}
		}
		FGUIManager.Instance.WorkerTitleFade(this, 0f);
	}

	private void ShowWaitingStockSpaceBubble()
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)(object)bubble == (Object)null)
		{
			bubble = Object.Instantiate<GameObject>(Resources.Load<GameObject>("bubble"), ((Component)this).transform);
			UIPanel val = ((Component)bubble.transform.Find("WorkerBubbleUi")).gameObject.AddComponent<UIPanel>();
			val.packageName = "PublicResources";
			val.componentName = "WorkerBubble";
			val.container.renderMode = (RenderMode)2;
			if (selfIndex % 2 != 0)
			{
				val.SetSortingOrder(4, true);
			}
			else
			{
				val.SetSortingOrder(3, true);
			}
			val.CreateUI();
			((Component)val).transform.localScale = ((Component)val).transform.localScale * 1.25f;
		}
		bubble.transform.localScale = new Vector3(3f, 3f, 3f);
		bubble.transform.localPosition = new Vector3(0.5f, 6f, 0f);
		UIPanel component = ((Component)bubble.transform.Find("WorkerBubbleUi")).gameObject.GetComponent<UIPanel>();
		component.ui.GetChild("max").alpha = 1f;
		component.ui.GetChild("MateriaNuml").alpha = 0f;
		RecycleProduct recycleProduct = Workbench.ProductList.First();
		string key = recycleProduct.Productions.First().Key;
		waitingStockSpaceName = UiHelper.GetIconPath(key);
		component.ui.GetChild("icon").asLoader.url = "ui://PublicResources/" + waitingStockSpaceName;
		FGUIManager.Instance.WorkerTitleFade(this, 0f);
	}

	private void ShowSpecialEffects(string effects, GameObject parent)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		if (parent.transform.childCount == 0)
		{
			GameObject val = SpawnManager.Instance.InstantiatePool(effects, Vector3.zero, 1);
			if (!((Object)(object)val == (Object)null))
			{
				val.GetComponent<Renderer>().sortingLayerName = "Default";
				for (int i = 0; i < ((Component)val.transform).GetComponentsInChildren<Renderer>().Length; i++)
				{
					((Component)val.transform).GetComponentsInChildren<Renderer>()[i].sortingLayerName = "Default";
				}
				val.transform.position = parent.transform.position;
				val.transform.eulerAngles = parent.transform.eulerAngles;
				val.transform.parent = parent.transform;
			}
		}
		else
		{
			((Component)parent.transform.GetChild(0)).gameObject.SetActive(true);
		}
	}

	public Vector3[] TransformListToPosArray(Transform[] transformsArray)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		Vector3[] array = (Vector3[])(object)new Vector3[transformsArray.Length];
		for (int i = 0; i < transformsArray.Length; i++)
		{
			array[i] = transformsArray[i].position;
		}
		return array;
	}

	private void WorkerWakeUp()
	{
		if (Workbench.IsProducing)
		{
			_workerAnimation.AnimationName = WorkshopController.ProcessingActionName;
		}
		else if (Workbench.IsWaitingStockSpace)
		{
			_workerAnimation.AnimationName = "idle";
			ShowWaitingStockSpaceBubble();
		}
		else if (Workbench.IsWaitingMaterial && !string.IsNullOrEmpty(Workbench.WaitingMaterial))
		{
			ShowWaitingMaterialBubble(Workbench.WaitingMaterial);
		}
	}

	public void SetWorkerStatus(WorkerStatus status)
	{
		if (workerActiveState == WorkerActiveState.Resting)
		{
			return;
		}
		WorkerStatus workerStatus = WorkerStatus;
		WorkerStatus = status;
		switch (status)
		{
		case WorkerStatus.Normal:
			workerTimeScale = 1f;
			if (workerStatus == WorkerStatus.Lazy)
			{
				WorkerWakeUp();
			}
			if (FireIcon.transform.childCount > 0)
			{
				((Component)FireIcon.transform.GetChild(0)).gameObject.SetActive(false);
			}
			if (DreamIcon.transform.childCount > 0)
			{
				((Component)DreamIcon.transform.GetChild(0)).gameObject.SetActive(false);
			}
			break;
		case WorkerStatus.Diligent:
			workerTimeScale = 2f;
			if (DreamIcon.transform.childCount > 0)
			{
				((Component)DreamIcon.transform.GetChild(0)).gameObject.SetActive(false);
			}
			_workerAnimation.AnimationState.AddAnimation(1, "emoji1", true, 0f);
			if (string.IsNullOrEmpty(waitingRequirementName) && string.IsNullOrEmpty(waitingStockSpaceName))
			{
				ShowSpecialEffects("fire_orange", FireIcon);
			}
			break;
		case WorkerStatus.Lazy:
			workerTimeScale = 0f;
			if (FireIcon.transform.childCount > 0)
			{
				((Component)FireIcon.transform.GetChild(0)).gameObject.SetActive(false);
			}
			_workerAnimation.AnimationName = "sleep";
			ShowSpecialEffects("sleep", DreamIcon);
			if (string.IsNullOrEmpty(waitingRequirementName))
			{
				if ((Object)(object)bubble != (Object)null)
				{
					Object.Destroy((Object)(object)bubble);
					if (!string.IsNullOrWhiteSpace(waitingRequirementName))
					{
						AssetsManager.Instance.UnloadAsset<Sprite>(waitingRequirementName);
					}
				}
				waitingRequirementName = "";
				WaitingMaterialId = "";
			}
			if ((Object)(object)bubble != (Object)null)
			{
				Object.Destroy((Object)(object)bubble);
				if (!string.IsNullOrWhiteSpace(waitingStockSpaceName))
				{
					AssetsManager.Instance.UnloadAsset<Sprite>(waitingStockSpaceName);
				}
				waitingStockSpaceName = "";
			}
			break;
		default:
			workerTimeScale = 1f;
			break;
		}
		if (CurrentTweener != null)
		{
			((Tween)CurrentTweener).timeScale = workerTimeScale;
		}
	}

	private void SetupTweener(ref Tweener targetTweener, ref float targetSpeed, Vector3[] path, string workerAnimation, TweenCallback callback = null)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		TweenCallback val = (TweenCallback)delegate
		{
			CurrentTweener = null;
			TweenCallback obj2 = callback;
			if (obj2 != null)
			{
				obj2.Invoke();
			}
		};
		object obj = _003C_003Ec._003C_003E9__92_1;
		if (obj == null)
		{
			TweenCallback val2 = delegate
			{
			};
			_003C_003Ec._003C_003E9__92_1 = val2;
			obj = (object)val2;
		}
		TweenCallback val3 = (TweenCallback)obj;
		_workerAnimation.AnimationName = workerAnimation;
		if (targetTweener is TweenerCore<Vector3, Path, PathOptions> val4)
		{
			float workerSpeed = WorkerSpeed;
			if (Math.Abs(workerSpeed - targetSpeed) > float.Epsilon)
			{
				targetSpeed = workerSpeed;
				((Tweener)val4).ChangeEndValue((object)val4.endValue, targetSpeed, true);
			}
			TweenExtensions.Restart((Tween)(object)TweenSettingsExtensions.OnUpdate<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.OnComplete<TweenerCore<Vector3, Path, PathOptions>>(val4, val), val3), true, -1f);
		}
		else
		{
			targetTweener = (Tweener)(object)TweenSettingsExtensions.SetAutoKill<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.SetSpeedBased<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.OnUpdate<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.OnComplete<TweenerCore<Vector3, Path, PathOptions>>(ShortcutExtensions.DOPath(((Component)this).transform, path, WorkerSpeed, (PathType)0, (PathMode)2, 10, (Color?)null), val), val3), (Ease)1), true), false);
		}
		CurrentTweener = targetTweener;
		((Tween)targetTweener).timeScale = workerTimeScale;
	}
}
