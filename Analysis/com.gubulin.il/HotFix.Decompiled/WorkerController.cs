using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
using UnityEngine.Rendering;

public class WorkerController : GoblinController
{
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

	private GameObject produceProgress;

	private SpriteRenderer produceProgressRenderer;

	private GameObject bubble;

	private Transform bubbleTransform;

	private GComponent bubbleUi;

	private float _x;

	private float _y;

	private TweenCallback<int> toPointChange;

	private string CurrentTweenerName;

	private Tweener CurrentTweener;

	private float baseTimeScale = 1f;

	private static Sprite Sack_Sprite;

	public WorkerInfo workerInfo;

	private float _workerSpeed = 1f;

	private string waitingRequirementName;

	private string waitingStockSpaceName;

	public WorkerStatus WorkerStatus = WorkerStatus.Normal;

	private int WorkerMovingErrorFramesCnt = 0;

	private float workbenchToStartToBedroomSpeed;

	private float workbenchToStartSpeed;

	private float bedroomToStartSpeed;

	private float startToWorkbenchSpeed;

	private float workbenchToFinishSpeed;

	private float finishToStartSpeed;

	private float startToBedroomSpeed;

	public Workbench Workbench;

	public WorkshopController WorkshopController;

	public float Delayed;

	public bool IsWorking = false;

	public bool IsGoingToBedroom = false;

	public bool IsCommingOutFromBedroom = false;

	public bool IsPreparing = false;

	public bool IsDelivering = false;

	public bool IsRefunding = false;

	public bool IsWaitingMaterial = false;

	public bool IsWaitingStockSpace = false;

	public string WaitingMaterialId;

	public GameObject FireIcon;

	public GameObject DreamIcon;

	public string ProcessingActionName;

	public GameObject FinishIcon;

	public SpriteRenderer FinishIconRenderer;

	public SpriteRenderer FinishIconRenderer2nd;

	public Tweener BedroomToStartTweener;

	public Transform[] BedroomToStartPath;

	public Tweener FinishToStartTweener;

	public Transform[] FinishToStartPath;

	public Tweener StartToBedroomTweener;

	public Transform[] StartToBedroomPath;

	public Transform[] WorkbenchToStartToBedroomPath;

	public Tweener StartToWorkbenchTweener;

	public Transform[] StartToWorkbenchPath;

	public Tweener WorkbenchToFinishTweener;

	public Transform[] WorkbenchToFinishPath;

	public Tweener WorkbenchToStartTweener;

	public Transform[] WorkbenchToStartPath;

	public Tweener WorkbenchToStartToBedroomTweener;

	private GComponent test_workerTitle;

	private float can_produce_check_tm;

	public bool isInit = false;

	public Vector3[] PathArray_BedroomToStartPath;

	public Vector3[] PathArray_FinishToStartPath;

	public Vector3[] PathArray_WorkbenchToStartToBedroomPath;

	public Vector3[] PathArray_StartToBedroomPath;

	public Vector3[] PathArray_StartToWorkbenchPath;

	public Vector3[] PathArray_WorkbenchToFinishPath;

	public Vector3[] PathArray_WorkbenchToStartPath;

	public Vector3[] PathArray_BedroomToStartToWorkbenchPath;

	public WorkerStatus ui_WorkerStatus = WorkerStatus.Normal;

	private Coroutine _WaitToSetNormalWorkStatus;

	public SkeletonAnimation WorkerAnimation => _workerAnimation;

	private float workerTimeScale
	{
		get
		{
			float num = workerInfo?.Potential ?? 1f;
			return baseTimeScale * num;
		}
		set
		{
			baseTimeScale = value;
		}
	}

	public float WorkerSpeed
	{
		get
		{
			float num = 0f;
			ModifierManager modifierManager = GameManagers.Instance.ModifierManager;
			if (modifierManager.GlobalFixedModifierDictionary.ContainsKey("WorkerSpeed"))
			{
				num += (float)modifierManager.GlobalFixedModifierDictionary["WorkerSpeed"]["Payload"];
			}
			if (modifierManager.MainCityFixedModifierDictionary.ContainsKey("WorkerSpeed"))
			{
				num += (float)modifierManager.MainCityFixedModifierDictionary["WorkerSpeed"]["Payload"];
			}
			float num2 = 1f;
			if (modifierManager.GlobalPercentModifierDictionary.ContainsKey("WorkerSpeed"))
			{
				num2 += (float)modifierManager.GlobalPercentModifierDictionary["WorkerSpeed"]["Payload"];
			}
			if (modifierManager.MainCityPercentModifierDictionary.ContainsKey("WorkerSpeed"))
			{
				num2 += (float)modifierManager.MainCityPercentModifierDictionary["WorkerSpeed"]["Payload"];
			}
			return _workerSpeed * num2 + num;
		}
	}

	private void SetPathPoints()
	{
		if (selfIndex < WorkshopController.Workbench.Length / 2)
		{
			BedroomToStartPath = (Transform[])(object)new Transform[3]
			{
				WorkshopController.KeyPoints[2],
				WorkshopController.KeyPoints[3],
				WorkshopController.KeyPoints[0]
			};
			FinishToStartPath = (Transform[])(object)new Transform[3]
			{
				WorkshopController.KeyPoints[1],
				WorkshopController.PathPoints[2],
				WorkshopController.KeyPoints[0]
			};
			StartToBedroomPath = (Transform[])(object)new Transform[4]
			{
				WorkshopController.KeyPoints[0],
				WorkshopController.KeyPoints[4],
				WorkshopController.KeyPoints[5],
				WorkshopController.KeyPoints[2]
			};
			if (selfIndex < 2)
			{
				StartToWorkbenchPath = (Transform[])(object)new Transform[2]
				{
					WorkshopController.KeyPoints[0],
					WorkshopController.SlotPoints[selfIndex]
				};
				WorkbenchToFinishPath = (Transform[])(object)new Transform[2]
				{
					WorkshopController.SlotPoints[selfIndex],
					WorkshopController.KeyPoints[1]
				};
				WorkbenchToStartPath = (Transform[])(object)new Transform[2]
				{
					WorkshopController.SlotPoints[selfIndex],
					WorkshopController.KeyPoints[0]
				};
			}
			else
			{
				StartToWorkbenchPath = (Transform[])(object)new Transform[2]
				{
					WorkshopController.KeyPoints[0],
					WorkshopController.SlotPoints[selfIndex]
				};
				WorkbenchToFinishPath = (Transform[])(object)new Transform[2]
				{
					WorkshopController.SlotPoints[selfIndex],
					WorkshopController.KeyPoints[1]
				};
				WorkbenchToStartPath = (Transform[])(object)new Transform[2]
				{
					WorkshopController.SlotPoints[selfIndex],
					WorkshopController.KeyPoints[0]
				};
			}
		}
		else if (selfIndex < WorkshopController.Workbench.Length)
		{
			BedroomToStartPath = (Transform[])(object)new Transform[3]
			{
				WorkshopController.KeyPoints[2],
				WorkshopController.KeyPoints[3],
				WorkshopController.KeyPoints[6]
			};
			FinishToStartPath = (Transform[])(object)new Transform[3]
			{
				WorkshopController.KeyPoints[7],
				WorkshopController.PathPoints[3],
				WorkshopController.KeyPoints[6]
			};
			StartToBedroomPath = (Transform[])(object)new Transform[4]
			{
				WorkshopController.KeyPoints[6],
				WorkshopController.KeyPoints[4],
				WorkshopController.KeyPoints[5],
				WorkshopController.KeyPoints[2]
			};
			if (selfIndex - WorkshopController.Workbench.Length / 2 < 2)
			{
				StartToWorkbenchPath = (Transform[])(object)new Transform[2]
				{
					WorkshopController.KeyPoints[6],
					WorkshopController.SlotPoints[selfIndex]
				};
				WorkbenchToFinishPath = (Transform[])(object)new Transform[2]
				{
					WorkshopController.SlotPoints[selfIndex],
					WorkshopController.KeyPoints[7]
				};
				WorkbenchToStartPath = (Transform[])(object)new Transform[2]
				{
					WorkshopController.SlotPoints[selfIndex],
					WorkshopController.KeyPoints[6]
				};
			}
			else
			{
				StartToWorkbenchPath = (Transform[])(object)new Transform[2]
				{
					WorkshopController.KeyPoints[6],
					WorkshopController.SlotPoints[selfIndex]
				};
				WorkbenchToFinishPath = (Transform[])(object)new Transform[2]
				{
					WorkshopController.SlotPoints[selfIndex],
					WorkshopController.KeyPoints[7]
				};
				WorkbenchToStartPath = (Transform[])(object)new Transform[2]
				{
					WorkshopController.SlotPoints[selfIndex],
					WorkshopController.KeyPoints[6]
				};
			}
		}
		WorkbenchToStartToBedroomPath = (Transform[])(object)new Transform[StartToBedroomPath.Length + 1];
		WorkbenchToStartToBedroomPath[0] = WorkbenchToStartPath[0];
		for (int i = 0; i < StartToBedroomPath.Length; i++)
		{
			WorkbenchToStartToBedroomPath[i + 1] = StartToBedroomPath[i];
		}
	}

	private void Awake()
	{
		_workerSpeed = 1f;
		baseTimeScale = 1f;
		_workerAnimation = ((Component)((Component)this).transform).GetComponent<SkeletonAnimation>();
		GameController.Contexts.Service<BaseSceneService>().AddWorkerController(this);
		GameController.Contexts.Service<BaseSceneService>().AddSkeletonAnimation(_workerAnimation);
		isInit = false;
		if ((Object)(object)Sack_Sprite == (Object)null)
		{
			AssetsManager.Instance.LoadAsset<Sprite>("sack3").Then((Action<Sprite>)delegate(Sprite asset)
			{
				Sack_Sprite = asset;
			});
		}
		bool flag = false;
	}

	private void Start()
	{
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		can_produce_check_tm = 0f;
		_ = WorkshopController;
		if (false)
		{
			WorkshopController = ((Component)WorkshopController).GetComponent<WorkshopController>();
		}
		BuildingType = WorkshopController.WorkShop.BuildingType;
		selfIndex = Array.IndexOf(WorkshopController.Workbench, ((Component)((Component)this).transform.parent).gameObject);
		if (WorkshopController.WorkShop.Feature == "WorkShop")
		{
			SetPathPoints();
		}
		if (BedroomToStartPath.Length != 0)
		{
			Vector3 position = BedroomToStartPath.First().position;
			((Component)this).transform.position = position;
			_x = position.x;
		}
		_workerRenderer = ((Component)((Component)this).transform).GetComponent<MeshRenderer>();
		((Renderer)_workerRenderer).sortingOrder = 0;
		FinishIconRenderer = FinishIcon.GetComponent<SpriteRenderer>();
		GameObject val = new GameObject();
		val.transform.parent = FinishIcon.transform;
		val.transform.localPosition = new Vector3(0f, 0.5f, 0.1f);
		val.transform.localScale = new Vector3(1f, 1f, 1f);
		FinishIconRenderer2nd = val.AddComponent<SpriteRenderer>();
		productRenderer = product.GetComponent<SpriteRenderer>();
		produceProgress = ((Component)product.transform.GetChild(0)).gameObject;
		produceProgressRenderer = produceProgress.GetComponent<SpriteRenderer>();
		if (WorkshopController.WorkShop.Feature != "Mine")
		{
			((Renderer)produceProgressRenderer).sortingLayerID = SortingLayer.NameToID("UI");
		}
		Workbench.workerController = this;
		Workbench.workerController_trans = ((Component)this).transform;
		bubble = Object.Instantiate<GameObject>(Resources.Load<GameObject>("bubble"), ((Component)this).transform);
		SortingGroup val2 = bubble.AddComponent<SortingGroup>();
		val2.sortingLayerName = "UI";
		val2.sortingOrder = 2;
		bubbleTransform = bubble.transform;
		UIPanel val3 = ((Component)bubble.transform.Find("WorkerBubbleUi")).gameObject.AddComponent<UIPanel>();
		val3.packageName = "PublicResources";
		val3.componentName = "WorkerBubble";
		val3.container.renderMode = (RenderMode)2;
		if (WorkshopController.WorkShop.Feature == "Mine")
		{
			val3.SetSortingOrder((selfIndex % 2 != 0) ? 4 : 3, true);
		}
		val3.CreateUI();
		bubbleTransform.localScale *= 1.25f;
		bubbleUi = val3.ui;
		bubbleUi.GetChild("MateriaNuml").sortingOrder = 100;
		bubble.SetActive(false);
		PathArray_BedroomToStartPath = TransformListToPosArray(BedroomToStartPath);
		PathArray_FinishToStartPath = TransformListToPosArray(FinishToStartPath);
		PathArray_WorkbenchToStartToBedroomPath = TransformListToPosArray(WorkbenchToStartToBedroomPath);
		Transform[] array = (Transform[])(object)new Transform[BedroomToStartPath.Length + StartToWorkbenchPath.Length];
		for (int i = 0; i < array.Length; i++)
		{
			if (i < BedroomToStartPath.Length)
			{
				array[i] = BedroomToStartPath[i];
			}
			else
			{
				array[i] = StartToWorkbenchPath[i - BedroomToStartPath.Length];
			}
		}
		PathArray_BedroomToStartToWorkbenchPath = TransformListToPosArray(array);
		PathArray_StartToBedroomPath = TransformListToPosArray(StartToBedroomPath);
		PathArray_StartToWorkbenchPath = TransformListToPosArray(StartToWorkbenchPath);
		PathArray_WorkbenchToFinishPath = TransformListToPosArray(WorkbenchToFinishPath);
		PathArray_WorkbenchToStartPath = TransformListToPosArray(WorkbenchToStartPath);
		if (BuildingType == "12")
		{
			UiHelper.GetProductLoader(FinishIcon, "");
		}
		isInit = true;
		((Behaviour)WorkerAnimation).enabled = false;
		((Behaviour)this).enabled = false;
		((Component)this).gameObject.SetActive(false);
		if (test_workerTitle != null)
		{
			test_workerTitle.GetChild("name").text = Workbench.WorkbenchIndex.ToString();
		}
	}

	private void OnDestroy()
	{
		((MonoBehaviour)this).StopAllCoroutines();
	}

	private void Update()
	{
	}

	public void WorkInterrupted()
	{
		if (!Workbench.IsInterrupted)
		{
			return;
		}
		Workbench.IsInterrupted = false;
		if (WorkshopController.WorkShop.Feature == "Mine")
		{
			if (!IsPreparing && !IsDelivering && !IsGoingToBedroom && !IsWaitingStockSpace && !IsCommingOutFromBedroom)
			{
				GObject child = WorkshopController.workerNum.GetChild("title");
				int num = (int)child.data;
				if (num > 0)
				{
					child.text = $"{num - 1}";
					child.data = num - 1;
				}
				if (Workbench.ProductTaskList != null)
				{
					StartProduce();
				}
			}
		}
		else if (!IsDelivering && !IsGoingToBedroom && !IsCommingOutFromBedroom && !IsWaitingMaterial && !IsWaitingStockSpace)
		{
			IsRefunding = true;
			IsPreparing = false;
			if (WorkerStatus != WorkerStatus.Lazy)
			{
				WorkbenchToStart();
			}
		}
	}

	public void OnArriveStartFromBedroom()
	{
		IsCommingOutFromBedroom = false;
		StartToWorkbench();
	}

	public void BedroomToStart()
	{
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		if (WorkshopController.WorkShop.BuildingType == "13" || WorkshopController.WorkShop.BuildingType == "8" || WorkshopController.WorkShop.BuildingType == "9")
		{
			((Renderer)_workerRenderer).sortingOrder = 1;
		}
		else
		{
			((Renderer)_workerRenderer).sortingOrder = 0;
		}
		IsCommingOutFromBedroom = true;
		SetupTweener("BedroomToStart", ref BedroomToStartTweener, ref bedroomToStartSpeed, TransformListToPosArray(BedroomToStartPath), "run", new TweenCallback(OnArriveStartFromBedroom), delegate
		{
			IsCommingOutFromBedroom = false;
		});
		FGUIManager.Instance.SetGoblinTitle(this);
		FGUIManager.Instance.WorkerTitleFade(this, 1f);
	}

	public void StartToWorkbench()
	{
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected O, but got Unknown
		if (IsRefunding)
		{
			IsRefunding = false;
		}
		if (Workbench.ProductTaskList == null || Workbench.ProductTaskList.Count < 1)
		{
			IsPreparing = false;
			return;
		}
		IsPreparing = true;
		Workbench.GrabResources();
		((Renderer)_workerRenderer).sortingOrder = 1;
		if (WorkshopController.WorkShop.Feature == "Mine")
		{
			((Renderer)_workerRenderer).sortingOrder = ((selfIndex % 2 == 0) ? 1 : 2);
		}
		else
		{
			((Renderer)_workerRenderer).sortingOrder = 1;
		}
		string workerAnimation = "run";
		bool flag = Workbench.CanProduce(out IsWaitingStockSpace, out IsWaitingMaterial, out WaitingMaterialId);
		if (WorkshopController.WorkShop.Feature == "Mine")
		{
			if (!flag)
			{
				IsPreparing = false;
				CheckCannotProduceStatus();
				return;
			}
			UiHelper.GetProductLoader(FinishIcon, "");
		}
		else if (flag)
		{
			workerAnimation = "carry";
			UiHelper.GetProductLoader(FinishIcon, "sack3");
		}
		else
		{
			UiHelper.GetProductLoader(FinishIcon, "");
		}
		SetupTweener("StartToWorkbench", ref StartToWorkbenchTweener, ref startToWorkbenchSpeed, TransformListToPosArray(StartToWorkbenchPath), workerAnimation, new TweenCallback(StartProduce), delegate
		{
			IsPreparing = false;
		});
	}

	public void StartProduce()
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		IsPreparing = false;
		UiHelper.GetProductLoader(FinishIcon, "");
		((Component)FinishIconRenderer).gameObject.transform.localScale = new Vector3(3.75f, 3.75f, 1f);
		if (Workbench.IsProducing)
		{
			_workerAnimation.AnimationName = WorkshopController.ProcessingActionName;
			return;
		}
		Workbench.Produce(out IsWaitingStockSpace, out IsWaitingMaterial, out WaitingMaterialId);
		if (Workbench.IsProducing)
		{
			_workerAnimation.AnimationName = WorkshopController.ProcessingActionName;
			Workbench.AfterProduce((TweenCallback)delegate
			{
				WorkbenchToFinish();
			});
			if (WorkshopController.WorkShop.Feature == "Mine")
			{
				((Renderer)_workerRenderer).sortingOrder = -1;
				((Renderer)productRenderer).sortingOrder = -1;
				((Renderer)produceProgressRenderer).sortingOrder = -1;
				FGUIManager.Instance.WorkerTitleFade(this, 0f);
				return;
			}
			((Renderer)_workerRenderer).sortingOrder = 1;
			((Renderer)productRenderer).sortingOrder = 1;
			((Renderer)produceProgressRenderer).sortingOrder = 2;
			Transform transform = product.transform;
			Vector3 localPosition = transform.localPosition;
			((Vector3)(ref localPosition))._002Ector(localPosition.x, 0.1f, localPosition.z);
			transform.localPosition = localPosition;
			Transform transform2 = produceProgress.transform;
			transform2.localScale = new Vector3(transform2.localScale.x, 0.5f, 1f);
			Transform transform3 = ((Component)produceProgressRenderer).transform;
			transform3.localPosition = new Vector3(transform3.localPosition.x, -0.2f, transform3.localPosition.z);
		}
		else
		{
			CheckCannotProduceStatus();
		}
	}

	public void WorkbenchToStart()
	{
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		string workerAnimation = "run";
		if (IsRefunding)
		{
			if (Workbench.GrabbedResources.Count > 0)
			{
				Workbench.RefundConsumptions();
				workerAnimation = "carry";
				UiHelper.GetProductLoader(FinishIcon, "sack3");
			}
		}
		else if (WorkshopController.WorkShop.Feature == "WorkShop" && !Workbench.CanProduce(out IsWaitingStockSpace, out IsWaitingMaterial, out WaitingMaterialId))
		{
			CheckCannotProduceStatus();
			return;
		}
		if (WorkshopController.WorkShop.Feature == "Mine")
		{
			int sortingOrder = 1;
			if (selfIndex % 2 != 0)
			{
				sortingOrder = 2;
			}
			((Renderer)FinishIconRenderer).sortingOrder = sortingOrder;
			((Renderer)FinishIconRenderer2nd).sortingOrder = sortingOrder;
			((Renderer)_workerRenderer).sortingOrder = sortingOrder;
			((Renderer)productRenderer).sortingOrder = 0;
			((Renderer)produceProgressRenderer).sortingOrder = 0;
			FGUIManager.Instance.WorkerTitleFade(this, 1f);
		}
		else
		{
			((Renderer)_workerRenderer).sortingOrder = 1;
			((Renderer)FinishIconRenderer).sortingOrder = 1;
			((Renderer)FinishIconRenderer2nd).sortingOrder = 1;
		}
		SetupTweener("WorkbenchToStart", ref WorkbenchToStartTweener, ref workbenchToStartSpeed, TransformListToPosArray(WorkbenchToStartPath), workerAnimation, new TweenCallback(StartToWorkbench));
	}

	public void WorkbenchToFinish()
	{
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Expected O, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		IsDelivering = true;
		string workerAnimation = "run";
		if (Workbench.LatestProductions.Count > 0)
		{
			workerAnimation = "carry";
			string[] array = Workbench.LatestProductions.Keys.ToArray();
			string itemId = "";
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i];
				int num = Workbench.LatestProductions[text];
				if (i == 0)
				{
					itemId = text;
				}
				switch (i)
				{
				case 0:
				{
					if (WorkshopController.WorkShop.BuildingType == "8")
					{
						UiHelper.GetProductLoader(FinishIcon, "egg_" + text);
					}
					else
					{
						string resourcePath3 = UiHelper.GetResourcePath(text, 0);
						UiHelper.GetProductLoader(FinishIcon, resourcePath3);
					}
					Vector3 localPosition = FinishIcon.transform.localPosition;
					((Vector3)(ref localPosition))._002Ector(localPosition.x, 4f, localPosition.z);
					FinishIcon.transform.localPosition = localPosition;
					break;
				}
				case 1:
				{
					if (WorkshopController.WorkShop.BuildingType == "8")
					{
						UiHelper.GetProductLoader(FinishIcon, "egg_" + text);
						break;
					}
					string resourcePath = UiHelper.GetResourcePath(itemId, 0);
					string resourcePath2 = UiHelper.GetResourcePath(text, 0);
					UiHelper.GetProductLoader(FinishIcon, resourcePath, resourcePath2);
					break;
				}
				}
			}
			if (WorkshopController.WorkShop.Feature == "Mine")
			{
				int sortingOrder = 1;
				if (selfIndex % 2 != 0)
				{
					sortingOrder = 2;
				}
				((Renderer)FinishIconRenderer).sortingOrder = sortingOrder;
				((Renderer)FinishIconRenderer2nd).sortingOrder = sortingOrder;
				((Renderer)_workerRenderer).sortingOrder = sortingOrder;
				((Renderer)productRenderer).sortingOrder = 0;
				((Renderer)produceProgressRenderer).sortingOrder = 0;
				FGUIManager.Instance.WorkerTitleFade(this, 1f);
			}
			else
			{
				((Renderer)_workerRenderer).sortingOrder = 1;
				((Renderer)FinishIconRenderer).sortingOrder = 1;
				((Renderer)FinishIconRenderer2nd).sortingOrder = 1;
			}
		}
		if (WorkshopController.WorkShop.Feature == "Mine")
		{
			int sortingOrder2 = 1;
			if (selfIndex % 2 != 0)
			{
				sortingOrder2 = 2;
			}
			((Renderer)FinishIconRenderer).sortingOrder = sortingOrder2;
			((Renderer)FinishIconRenderer2nd).sortingOrder = sortingOrder2;
			((Renderer)_workerRenderer).sortingOrder = sortingOrder2;
			((Renderer)productRenderer).sortingOrder = 0;
			((Renderer)produceProgressRenderer).sortingOrder = 0;
			FGUIManager.Instance.WorkerTitleFade(this, 1f);
		}
		else
		{
			((Renderer)_workerRenderer).sortingOrder = 1;
			((Renderer)FinishIconRenderer).sortingOrder = 1;
			((Renderer)FinishIconRenderer2nd).sortingOrder = 1;
		}
		SetupTweener("WorkbenchToFinish", ref WorkbenchToFinishTweener, ref workbenchToFinishSpeed, TransformListToPosArray(WorkbenchToFinishPath), workerAnimation, new TweenCallback(FinishToStart), delegate
		{
			IsDelivering = false;
		});
	}

	public void FinishToStart()
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		IsDelivering = false;
		UiHelper.GetProductLoader(FinishIcon, "");
		WorkshopController.Delivery(Workbench.LatestProductions);
		((Renderer)_workerRenderer).sortingOrder = 0;
		SetupTweener("FinishToStart", ref FinishToStartTweener, ref finishToStartSpeed, TransformListToPosArray(FinishToStartPath), "run", new TweenCallback(StartToWorkbench));
	}

	public void StartToBedroom()
	{
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		IsGoingToBedroom = true;
		UiHelper.GetProductLoader(FinishIcon, "");
		if (WorkshopController.WorkShop.Feature == "WorkShop")
		{
			((Renderer)_workerRenderer).sortingOrder = 0;
			if (WorkshopController.WorkShop.BuildingType == "13" || WorkshopController.WorkShop.BuildingType == "9" || WorkshopController.WorkShop.BuildingType == "8")
			{
				((Renderer)_workerRenderer).sortingOrder = 1;
			}
		}
		else
		{
			((SkeletonRenderer)_workerAnimation).Skeleton.A = 1f;
			int sortingOrder = 1;
			if (selfIndex % 2 != 0)
			{
				sortingOrder = 2;
			}
			((Renderer)FinishIconRenderer).sortingOrder = sortingOrder;
			((Renderer)FinishIconRenderer2nd).sortingOrder = sortingOrder;
			((Renderer)_workerRenderer).sortingOrder = sortingOrder;
			((Renderer)productRenderer).sortingOrder = 0;
			((Renderer)produceProgressRenderer).sortingOrder = 0;
			FGUIManager.Instance.WorkerTitleFade(this, 1f);
		}
		Transform[] transformsArray = (Workbench.IsProducing ? WorkbenchToStartToBedroomPath : StartToBedroomPath);
		SetupTweener("StartToBedroom", ref StartToBedroomTweener, ref startToBedroomSpeed, TransformListToPosArray(transformsArray), "run", new TweenCallback(OnArrivedBedroom), delegate
		{
			IsGoingToBedroom = false;
		});
	}

	public void OnArrivedBedroom()
	{
		IsWorking = false;
		IsGoingToBedroom = false;
		IsCommingOutFromBedroom = false;
		IsPreparing = false;
		IsDelivering = false;
		IsWaitingMaterial = false;
		IsWaitingStockSpace = false;
		if (WorkshopController.WorkShop.Feature == "Mine")
		{
			((Renderer)_workerRenderer).sortingOrder = 0;
		}
		FGUIManager.Instance.ClearGoblinTitle(this);
		((Behaviour)this).enabled = false;
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

	public void SetWorkerStatus(WorkerStatus status)
	{
		if (!IsWorking)
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
			if (WorkshopController.WorkShop.Feature != "Mine")
			{
				ShowSpecialEffects("sleep", DreamIcon);
			}
			bubble.SetActive(false);
			WaitingMaterialId = "";
			if (!string.IsNullOrEmpty(waitingRequirementName))
			{
				AssetsManager.Instance.UnloadAsset<Sprite>(waitingRequirementName);
				waitingRequirementName = "";
			}
			if (!string.IsNullOrEmpty(waitingStockSpaceName))
			{
				AssetsManager.Instance.UnloadAsset<Sprite>(waitingStockSpaceName);
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

	public IEnumerator UpdateWorkerBubble()
	{
		yield return (object)new WaitForFixedUpdate();
		if (_workerAnimation.AnimationName == "idle" && IsWorking)
		{
			UpdateBubbleIcon();
		}
	}

	private void WorkerWakeUp()
	{
		if (Workbench.IsProducing)
		{
			_workerAnimation.AnimationName = WorkshopController.ProcessingActionName;
		}
		else if (IsWaitingStockSpace)
		{
			_workerAnimation.AnimationName = "idle";
			ShowWaitingStockSpaceBubble();
		}
		else if (IsWaitingMaterial)
		{
			if (!string.IsNullOrEmpty(WaitingMaterialId))
			{
				ShowWaitingMaterialBubble();
			}
		}
		else if (IsRefunding)
		{
			WorkbenchToStart();
		}
	}

	public void UpdateBubbleIcon()
	{
		if (IsWaitingMaterial)
		{
			if (!string.IsNullOrEmpty(WaitingMaterialId))
			{
				ShowWaitingMaterialBubble();
			}
		}
		else if (IsWaitingStockSpace)
		{
			ShowWaitingStockSpaceBubble();
		}
		else
		{
			bubble.SetActive(false);
			waitingRequirementName = "";
			waitingStockSpaceName = "";
			WaitingMaterialId = "";
		}
	}

	public void CheckCannotProduceStatus()
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		if (IsWaitingMaterial)
		{
			if (!string.IsNullOrEmpty(WaitingMaterialId))
			{
				ShowWaitingMaterialBubble();
			}
		}
		else if (IsWaitingStockSpace)
		{
			ShowWaitingStockSpaceBubble();
		}
		else
		{
			Debug.LogWarning((object)(WorkshopController.WorkShop.Name + "目前不能生产"));
		}
		if (WorkshopController.WorkShop.Feature == "Mine")
		{
			Vector3 val = ((Component)this).gameObject.transform.position - StartToWorkbenchPath[0].position;
			float magnitude = ((Vector3)(ref val)).magnitude;
			if (magnitude > 0.1f)
			{
				WorkbenchToStart();
				return;
			}
		}
		_workerAnimation.AnimationName = "idle";
		if (WorkshopController.WorkShop.Feature == "Mine")
		{
			((SkeletonRenderer)_workerAnimation).Skeleton.A = 1f;
			FinishIconRenderer.color = new Color(FinishIconRenderer.color.r, FinishIconRenderer.color.g, FinishIconRenderer.color.b, 1f);
			FinishIconRenderer2nd.color = new Color(FinishIconRenderer2nd.color.r, FinishIconRenderer2nd.color.g, FinishIconRenderer2nd.color.b, 1f);
		}
	}

	private void ChangeWorkerOrder(int point)
	{
		((Renderer)_workerRenderer).sortingOrder = 0;
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		if (!IsWaitingMaterial || incr <= 0 || itemId != WaitingMaterialId || (Object)(object)bubble == (Object)null)
		{
			return;
		}
		string text = (Workbench.ProductList?.First())?.Key;
		if (text != null && BuildingManager.ProductRequirements.TryGetValue(text, out var value) && value.TryGetValue(itemId, out var value2))
		{
			string[] subKeys = new string[1] { "BuildingType" + BuildingType };
			float num = 1f + GameManagers.Instance.ModifierManager.GetPercentFloatPayload("ProduceCost", subKeys);
			float fixedFloatPayload = GameManagers.Instance.ModifierManager.GetFixedFloatPayload("ProduceCost", subKeys);
			value2 = Mathf.RoundToInt((float)value2 * num + fixedFloatPayload);
			int stock = GameManagers.Instance.StockController.GetStock(itemId);
			if (stock < value2)
			{
				GObject child = bubbleUi.GetChild("MateriaNuml");
				child.alpha = 1f;
				child.asCom.GetChild("curNum").text = $"{stock}";
				child.asCom.GetChild("sprit").text = "/";
				child.asCom.GetChild("requireNum").text = $"{value2}";
				child.SetPivot(0.5f, 0.5f, true);
				child.SetXY(bubbleUi.GetChild("icon").x, bubbleUi.GetChild("icon").y + 46f);
			}
		}
	}

	public void ShowWaitingMaterialBubble()
	{
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		WorkerAnimation.AnimationName = "idle";
		if (Workbench.ProductTaskList == null)
		{
			return;
		}
		string text = Workbench.ProductTaskList[0];
		string key = text.Replace("I", "P");
		if (!BuildingManager.ProductRequirements.TryGetValue(key, out var value))
		{
			return;
		}
		string text2 = string.Empty;
		int num = 0;
		string[] subKeys = new string[1] { "BuildingType" + BuildingType };
		foreach (KeyValuePair<string, int> item in value)
		{
			float num2 = 1f + GameManagers.Instance.ModifierManager.GetPercentFloatPayload("ProduceCost", subKeys);
			float fixedFloatPayload = GameManagers.Instance.ModifierManager.GetFixedFloatPayload("ProduceCost", subKeys);
			int num3 = Mathf.RoundToInt((float)item.Value * num2 + fixedFloatPayload);
			if (GameManagers.Instance.StockController.GetStock(item.Key) < num3)
			{
				text2 = item.Key;
				num = item.Value;
				break;
			}
		}
		if (!string.IsNullOrEmpty(text2))
		{
			bubble.SetActive(true);
			bubbleTransform.localScale = new Vector3(3f, 3f, 3f);
			bubbleTransform.localPosition = new Vector3(0.5f, 6f, 0f);
			bubbleUi.GetChild("max").alpha = 0f;
			bubbleUi.GetChild("MateriaNuml").alpha = 0f;
			waitingRequirementName = UiHelper.GetIconPath(text2);
			bubbleUi.GetChild("icon").asLoader.url = "ui://PublicResources/" + waitingRequirementName;
			float num4 = 1f + GameManagers.Instance.ModifierManager.GetPercentFloatPayload("ProduceCost", subKeys);
			float fixedFloatPayload2 = GameManagers.Instance.ModifierManager.GetFixedFloatPayload("ProduceCost", subKeys);
			int num5 = Mathf.RoundToInt((float)num * num4 + fixedFloatPayload2);
			GObject child = bubbleUi.GetChild("MateriaNuml");
			child.alpha = 1f;
			child.asCom.GetChild("curNum").text = $"{GameManagers.Instance.StockController.GetStock(text2)}";
			child.asCom.GetChild("sprit").text = "/";
			child.asCom.GetChild("requireNum").text = $"{num5}";
			child.SetPivot(0.5f, 0.5f, true);
			child.SetXY(bubbleUi.GetChild("icon").x, bubbleUi.GetChild("icon").y + 46f);
			FGUIManager.Instance.WorkerTitleFade(this, 0f);
		}
	}

	public void ShowWaitingStockSpaceBubble()
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		WorkerAnimation.AnimationName = "idle";
		if (Workbench.ProductTaskList != null && Workbench.ProductTaskList.Count != 0)
		{
			bubble.SetActive(true);
			bubbleTransform.localScale = new Vector3(3f, 3f, 3f);
			bubbleTransform.localPosition = new Vector3(0.5f, 6f, 0f);
			bubbleUi.GetChild("max").alpha = 1f;
			bubbleUi.GetChild("MateriaNuml").alpha = 0f;
			int index = Random.Range(0, Workbench.ProductTaskList.Count);
			string text = Workbench.ProductTaskList[index];
			string itemName = text.Replace("P", "I");
			bubbleUi.GetChild("icon").asLoader.url = "ui://PublicResources/" + UiHelper.GetIconPath(itemName);
			FGUIManager.Instance.WorkerTitleFade(this, 0f);
		}
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

	private void SetupTweener(string tweenerName, ref Tweener targetTweener, ref float targetSpeed, Vector3[] path, string workerAnimation, TweenCallback callback = null, Action forceCompleteAction = null)
	{
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected O, but got Unknown
		if (CurrentTweener != null)
		{
			foreach (Tween item in DOTween.PlayingTweens())
			{
				if ((object)item == CurrentTweener)
				{
					TweenExtensions.Complete((Tween)(object)CurrentTweener, false);
					forceCompleteAction?.Invoke();
				}
				else if (item.target == ((Tween)CurrentTweener).target)
				{
					TweenExtensions.Complete(item, false);
				}
				if (CurrentTweener == null)
				{
					break;
				}
			}
		}
		TweenCallback val = (TweenCallback)delegate
		{
			CurrentTweener = null;
			TweenCallback obj = callback;
			if (obj != null)
			{
				obj.Invoke();
			}
		};
		TweenCallback val2 = null;
		if (WorkshopController.WorkShop.Feature == "Mine")
		{
			val2 = (TweenCallback)delegate
			{
				//IL_0011: Unknown result type (might be due to invalid IL or missing references)
				//IL_0042: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
				//IL_00da: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
				//IL_0110: Unknown result type (might be due to invalid IL or missing references)
				//IL_0125: Unknown result type (might be due to invalid IL or missing references)
				//IL_0130: Unknown result type (might be due to invalid IL or missing references)
				if (((Component)_workerRenderer).transform.position.z >= -0.36f)
				{
					float num = (0.04f - ((Component)_workerRenderer).transform.position.z) * 2.5f;
					if (num > 1f)
					{
						num = 1f;
					}
					if (num < 0f)
					{
						num = 0f;
					}
					((SkeletonRenderer)_workerAnimation).Skeleton.A = num;
					FinishIconRenderer.color = new Color(FinishIconRenderer.color.r, FinishIconRenderer.color.g, FinishIconRenderer.color.b, num);
					FinishIconRenderer2nd.color = new Color(FinishIconRenderer2nd.color.r, FinishIconRenderer2nd.color.g, FinishIconRenderer2nd.color.b, num);
				}
			};
		}
		_workerAnimation.AnimationName = workerAnimation;
		if (targetTweener is TweenerCore<Vector3, Path, PathOptions> val3)
		{
			float workerSpeed = WorkerSpeed;
			targetSpeed = workerSpeed;
			TweenExtensions.Restart((Tween)(object)TweenSettingsExtensions.OnComplete<Tweener>(((Tweener)val3).ChangeEndValue((object)path, targetSpeed, true), val), true, -1f);
			if (val2 != null)
			{
				TweenSettingsExtensions.OnUpdate<TweenerCore<Vector3, Path, PathOptions>>(val3, val2);
			}
		}
		else
		{
			targetTweener = (Tweener)(object)TweenSettingsExtensions.SetAutoKill<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.SetSpeedBased<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.OnComplete<TweenerCore<Vector3, Path, PathOptions>>(ShortcutExtensions.DOPath(((Component)this).transform, path, WorkerSpeed, (PathType)0, (PathMode)2, 10, (Color?)null), val), (Ease)1), true), false);
			if (val2 != null)
			{
				TweenSettingsExtensions.OnUpdate<Tweener>(targetTweener, val2);
			}
		}
		CurrentTweener = targetTweener;
		CurrentTweenerName = tweenerName;
		((Tween)targetTweener).timeScale = workerTimeScale;
	}

	public void OnInRoom()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		WorkerAnimation.AnimationName = "run";
		if (BedroomToStartPath.Length != 0)
		{
			Vector3 position = BedroomToStartPath.First().position;
			((Component)this).transform.position = position;
			_x = position.x;
		}
		if (_WaitToSetNormalWorkStatus != null)
		{
			((MonoBehaviour)this).StopCoroutine(_WaitToSetNormalWorkStatus);
		}
		UIChange_SetWorkerStatus(WorkerStatus.Normal);
		((Behaviour)WorkerAnimation).enabled = false;
		((Behaviour)this).enabled = false;
		((Component)this).gameObject.SetActive(false);
		if (Workbench.LastStatus == Workbench.WorkbenchStatus.Do_InRoom || Workbench.LastStatus == Workbench.WorkbenchStatus.NotInited)
		{
			return;
		}
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

	public void ShowSack()
	{
		((Behaviour)WorkerAnimation).enabled = true;
		WorkerAnimation.AnimationName = "carry";
		UiHelper.GetProductLoader(FinishIcon, "sack3");
	}

	public void InitWorker()
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		((Component)this).gameObject.SetActive(true);
		((Behaviour)WorkerAnimation).enabled = true;
		WorkerAnimation.AnimationName = "run";
		((SkeletonRenderer)WorkerAnimation).Skeleton.A = 1f;
		UiHelper.GetProductLoader(FinishIcon, "");
		((Component)FinishIconRenderer).gameObject.transform.localScale = new Vector3(3.75f, 3.75f, 1f);
	}

	public void InitBubble()
	{
		bubble.SetActive(false);
	}

	public void UIChange_Produce()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		UiHelper.GetProductLoader(FinishIcon, "");
		((Component)FinishIconRenderer).gameObject.transform.localScale = new Vector3(3.75f, 3.75f, 1f);
		_workerAnimation.AnimationName = WorkshopController.ProcessingActionName;
		if (WorkshopController.WorkShop.Feature == "Mine")
		{
			((Renderer)_workerRenderer).sortingOrder = -1;
			((Renderer)productRenderer).sortingOrder = -1;
			((Renderer)produceProgressRenderer).sortingOrder = -1;
			FGUIManager.Instance.WorkerTitleFade(this, 0f);
			return;
		}
		((Renderer)_workerRenderer).sortingOrder = 1;
		((Renderer)productRenderer).sortingOrder = 1;
		((Renderer)produceProgressRenderer).sortingOrder = 2;
		Transform transform = product.transform;
		Vector3 localPosition = transform.localPosition;
		((Vector3)(ref localPosition))._002Ector(localPosition.x, 0.1f, localPosition.z);
		transform.localPosition = localPosition;
		Transform transform2 = produceProgress.transform;
		transform2.localScale = new Vector3(transform2.localScale.x, 0.5f, 1f);
		Transform transform3 = ((Component)produceProgressRenderer).transform;
		transform3.localPosition = new Vector3(transform3.localPosition.x, -0.2f, transform3.localPosition.z);
	}

	public void UIChange_StartToBed()
	{
		InitWorker();
		if (WorkshopController.WorkShop.Feature == "WorkShop")
		{
			((Renderer)_workerRenderer).sortingOrder = 0;
			if (WorkshopController.WorkShop.BuildingType == "13" || WorkshopController.WorkShop.BuildingType == "9" || WorkshopController.WorkShop.BuildingType == "8")
			{
				((Renderer)_workerRenderer).sortingOrder = 1;
			}
			return;
		}
		((SkeletonRenderer)_workerAnimation).Skeleton.A = 1f;
		int sortingOrder = 1;
		if (selfIndex % 2 != 0)
		{
			sortingOrder = 2;
		}
		((Renderer)FinishIconRenderer).sortingOrder = sortingOrder;
		((Renderer)FinishIconRenderer2nd).sortingOrder = sortingOrder;
		((Renderer)_workerRenderer).sortingOrder = sortingOrder;
		((Renderer)productRenderer).sortingOrder = 0;
		((Renderer)produceProgressRenderer).sortingOrder = 0;
		FGUIManager.Instance.WorkerTitleFade(this, 1f);
	}

	public void UIChange_BedroomToStart()
	{
		if (WorkshopController.WorkShop.BuildingType == "13" || WorkshopController.WorkShop.BuildingType == "8" || WorkshopController.WorkShop.BuildingType == "9")
		{
			((Renderer)_workerRenderer).sortingOrder = 1;
		}
		else
		{
			((Renderer)_workerRenderer).sortingOrder = 0;
		}
		FGUIManager.Instance.SetGoblinTitle(this);
		FGUIManager.Instance.WorkerTitleFade(this, 1f);
	}

	public void UIChange_FinishToStart()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		UiHelper.GetProductLoader(FinishIcon, "");
		((Component)FinishIconRenderer).gameObject.transform.localScale = new Vector3(3.75f, 3.75f, 1f);
		((Renderer)_workerRenderer).sortingOrder = 0;
	}

	public void UIChange_WorkbenchToStart()
	{
		if (WorkshopController.WorkShop.Feature == "Mine")
		{
			int sortingOrder = 1;
			if (selfIndex % 2 != 0)
			{
				sortingOrder = 2;
			}
			((Renderer)FinishIconRenderer).sortingOrder = sortingOrder;
			((Renderer)FinishIconRenderer2nd).sortingOrder = sortingOrder;
			((Renderer)_workerRenderer).sortingOrder = sortingOrder;
			((Renderer)productRenderer).sortingOrder = 0;
			((Renderer)produceProgressRenderer).sortingOrder = 0;
			FGUIManager.Instance.WorkerTitleFade(this, 1f);
		}
		else
		{
			((Renderer)_workerRenderer).sortingOrder = 1;
			((Renderer)FinishIconRenderer).sortingOrder = 1;
			((Renderer)FinishIconRenderer2nd).sortingOrder = 1;
		}
	}

	public void UIChange_StartToWorkbench()
	{
		((Renderer)_workerRenderer).sortingOrder = 1;
		if (WorkshopController.WorkShop.Feature == "Mine")
		{
			((Renderer)_workerRenderer).sortingOrder = ((selfIndex % 2 == 0) ? 1 : 2);
		}
		else
		{
			((Renderer)_workerRenderer).sortingOrder = 1;
		}
	}

	public void UIChange_WorkbenchToFinish()
	{
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		string[] array = Workbench.LatestProductions.Keys.ToArray();
		string itemId = "";
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			int num = Workbench.LatestProductions[text];
			if (i == 0)
			{
				itemId = text;
			}
			switch (i)
			{
			case 0:
			{
				if (WorkshopController.WorkShop.BuildingType == "8")
				{
					UiHelper.GetProductLoader(FinishIcon, "egg_" + text);
				}
				else
				{
					string resourcePath3 = UiHelper.GetResourcePath(text, 0);
					UiHelper.GetProductLoader(FinishIcon, resourcePath3);
				}
				Vector3 localPosition = FinishIcon.transform.localPosition;
				((Vector3)(ref localPosition))._002Ector(localPosition.x, 4f, localPosition.z);
				FinishIcon.transform.localPosition = localPosition;
				break;
			}
			case 1:
			{
				if (WorkshopController.WorkShop.BuildingType == "8")
				{
					UiHelper.GetProductLoader(FinishIcon, "egg_" + text);
					break;
				}
				string resourcePath = UiHelper.GetResourcePath(itemId, 0);
				string resourcePath2 = UiHelper.GetResourcePath(text, 0);
				UiHelper.GetProductLoader(FinishIcon, resourcePath, resourcePath2);
				break;
			}
			}
		}
		if (WorkshopController.WorkShop.Feature == "Mine")
		{
			int sortingOrder = 1;
			if (selfIndex % 2 != 0)
			{
				sortingOrder = 2;
			}
			((Renderer)FinishIconRenderer).sortingOrder = sortingOrder;
			((Renderer)FinishIconRenderer2nd).sortingOrder = sortingOrder;
			((Renderer)_workerRenderer).sortingOrder = sortingOrder;
			((Renderer)productRenderer).sortingOrder = 0;
			((Renderer)produceProgressRenderer).sortingOrder = 0;
			FGUIManager.Instance.WorkerTitleFade(this, 1f);
		}
		else
		{
			((Renderer)_workerRenderer).sortingOrder = 1;
			((Renderer)FinishIconRenderer).sortingOrder = 1;
			((Renderer)FinishIconRenderer2nd).sortingOrder = 1;
		}
	}

	public void ChangeWorkerTitle(int num)
	{
		if (!(WorkshopController.WorkShop.Feature != "Mine"))
		{
			List<int> list = null;
			GObject child = WorkshopController.workerNum.GetChild("title");
			list = ((child.data != null && !(child.data is int)) ? ((List<int>)child.data) : new List<int>());
			if (list.IndexOf(Workbench.WorkbenchIndex) < 0 && num > 0)
			{
				list.Add(Workbench.WorkbenchIndex);
			}
			else if (list.IndexOf(Workbench.WorkbenchIndex) >= 0 && num < 0)
			{
				list.Remove(Workbench.WorkbenchIndex);
			}
			child.data = list;
			child.text = list.Count.ToString();
		}
	}

	public void UIChange_Alpha()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		if (((Component)_workerRenderer).transform.position.z >= -0.36f)
		{
			float num = (0.04f - ((Component)_workerRenderer).transform.position.z) * 2.5f;
			if (num > 1f)
			{
				num = 1f;
			}
			if (num < 0f)
			{
				num = 0f;
			}
			((SkeletonRenderer)_workerAnimation).Skeleton.A = num;
			FinishIconRenderer.color = new Color(FinishIconRenderer.color.r, FinishIconRenderer.color.g, FinishIconRenderer.color.b, num);
			FinishIconRenderer2nd.color = new Color(FinishIconRenderer2nd.color.r, FinishIconRenderer2nd.color.g, FinishIconRenderer2nd.color.b, num);
		}
	}

	public void UIChange_SortingOrder_OnUpdate()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		if (WorkshopController.WorkShop.BuildingType == "13" || WorkshopController.WorkShop.BuildingType == "8" || WorkshopController.WorkShop.BuildingType == "9")
		{
			((Renderer)_workerRenderer).sortingOrder = ((!(((Component)_workerRenderer).transform.position.z < -2f)) ? 1 : 2);
		}
	}

	public Vector3[] TryAddGradientPointBeforeMove(Vector3[] pathArray)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		if (!(WorkshopController.WorkShop.BuildingType == "13") && !(WorkshopController.WorkShop.BuildingType == "8") && !(WorkshopController.WorkShop.BuildingType == "9"))
		{
			return pathArray;
		}
		if (((Component)_workerRenderer).transform.position.z > -2f)
		{
			return pathArray;
		}
		Transform val = WorkshopController.KeyPoints[3];
		Vector3 position = val.position;
		if (pathArray.Length != 0 && pathArray[0] == position)
		{
			return pathArray;
		}
		Vector3[] array = (Vector3[])(object)new Vector3[pathArray.Length + 1];
		array[0] = position;
		for (int i = 0; i < pathArray.Length; i++)
		{
			array[i + 1] = pathArray[i];
		}
		return array;
	}

	public void UIChange_SetWorkerStatus(WorkerStatus status)
	{
		WorkerStatus workerStatus = ui_WorkerStatus;
		ui_WorkerStatus = status;
		switch (status)
		{
		case WorkerStatus.Normal:
			if (workerStatus == WorkerStatus.Lazy)
			{
				_workerAnimation.AnimationName = WorkshopController.ProcessingActionName;
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
		{
			if (DreamIcon.transform.childCount > 0)
			{
				((Component)DreamIcon.transform.GetChild(0)).gameObject.SetActive(false);
			}
			_workerAnimation.AnimationState.AddAnimation(1, "emoji1", true, 0f);
			if (string.IsNullOrEmpty(waitingRequirementName) && string.IsNullOrEmpty(waitingStockSpaceName))
			{
				ShowSpecialEffects("fire_orange", FireIcon);
			}
			int num2 = (int)(GameManagers.Instance.UserArchiveManager.GetBaseDiligentWorkerDuration() * (1f + GameManagers.Instance.ModifierManager.GetPercentFloatPayload("DiligentWorkerDuration")) + GameManagers.Instance.ModifierManager.GetFixedFloatPayload("DiligentWorkerDuration"));
			if (_WaitToSetNormalWorkStatus != null)
			{
				((MonoBehaviour)this).StopCoroutine(_WaitToSetNormalWorkStatus);
			}
			_WaitToSetNormalWorkStatus = ((MonoBehaviour)this).StartCoroutine(UIChange_WaitToSetNormalWorkStatus(num2));
			break;
		}
		case WorkerStatus.Lazy:
		{
			if (FireIcon.transform.childCount > 0)
			{
				((Component)FireIcon.transform.GetChild(0)).gameObject.SetActive(false);
			}
			_workerAnimation.AnimationName = "sleep";
			if (WorkshopController.WorkShop.Feature != "Mine")
			{
				ShowSpecialEffects("sleep", DreamIcon);
			}
			bubble.SetActive(false);
			WaitingMaterialId = "";
			if (!string.IsNullOrEmpty(waitingRequirementName))
			{
				AssetsManager.Instance.UnloadAsset<Sprite>(waitingRequirementName);
				waitingRequirementName = "";
			}
			if (!string.IsNullOrEmpty(waitingStockSpaceName))
			{
				AssetsManager.Instance.UnloadAsset<Sprite>(waitingStockSpaceName);
				waitingStockSpaceName = "";
			}
			int num = (int)(GameManagers.Instance.UserArchiveManager.GetBaseLazyWorkerDuration() * (1f + GameManagers.Instance.ModifierManager.GetPercentFloatPayload("LazyWorkerDuration")) + GameManagers.Instance.ModifierManager.GetFixedFloatPayload("LazyWorkerDuration"));
			if (_WaitToSetNormalWorkStatus != null)
			{
				((MonoBehaviour)this).StopCoroutine(_WaitToSetNormalWorkStatus);
			}
			_WaitToSetNormalWorkStatus = ((MonoBehaviour)this).StartCoroutine(UIChange_WaitToSetNormalWorkStatus(num));
			break;
		}
		}
	}

	private IEnumerator UIChange_WaitToSetNormalWorkStatus(float tm)
	{
		yield return (object)new WaitForSeconds(tm);
		UIChange_SetWorkerStatus(WorkerStatus.Normal);
	}
}
