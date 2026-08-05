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
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;
using Spine.Unity;
using UnityEngine;

public class Workbench : MonoBehaviour
{
	public enum WorkbenchStatus
	{
		NotInited,
		Do_InRoom,
		Do_GrabbedResources,
		Do_BringBackResources,
		Do_GoToWorkbenchWithResources,
		Do_GoToWorkbenchWithOutResources,
		Do_Workbench_Lazy,
		Do_Workbench_Normal,
		Do_Workbench_Diligent,
		Do_WorkbenchFinish,
		Do_ResourcesLack,
		Do_StockIsFull
	}

	private bool isProduceStateRefresh = false;

	private Coroutine _Coroutine_WaitTo_RefreshProduceState;

	private ProduceState waitProduceState;

	private ProduceState _curProduceState;

	public WorkbenchStatus CurStatus;

	public WorkbenchStatus LastStatus;

	private object _lock;

	private WorkbenchStatus tmpStatus;

	private Coroutine CoroutineID;

	private Vector3[] workerMovePath = null;

	private Action Workbench_TweenCallback = null;

	private Dictionary<WorkbenchStatus, Action> WorkbenchStatusMachine;

	private Tweener WorkerTweener;

	private float _x;

	public GameObject ProductIcon;

	public UIPanel productIcon;

	public GameObject WorkbenchSliders;

	public GameObject WorkerFinishIcon;

	private WorkShop _owner;

	public WorkerController workerController;

	public Transform workerController_trans;

	public MoltenCoreWorkerController moltenCoreWorkerController;

	private int _workbenchindex;

	private float timeScale = 1f;

	private string proDuctIconName;

	public WorkerStatus WorkerStatus = WorkerStatus.Normal;

	public bool IsProducing = false;

	public bool IsInterrupted = false;

	public bool IsPaused = false;

	public float ProduceTime = 0f;

	private Tweener _produce;

	private List<string> productTaskList;

	public List<GDEProductData> ProductList;

	public List<GDEProductData> ResultList;

	public Dictionary<string, int> AddonDict;

	public Dictionary<string, int> GrabbedResources = new Dictionary<string, int>();

	public Dictionary<string, int> LatestProductions = new Dictionary<string, int>();

	private int _productTotalWeight;

	private List<string> _productTaskLast;

	private string[] buildingFilter;

	private Coroutine ProduceCoroutine;

	private bool waitingStock = false;

	private bool waitingMaterial = false;

	private string waitingMaterialId = string.Empty;

	private bool _canProduce = false;

	private TweenCallback _afterProduceCallback;

	private ProduceState curProduceState => _curProduceState;

	public WorkShop Owner
	{
		get
		{
			return _owner;
		}
		set
		{
			buildingFilter = new string[2]
			{
				"WorkShop" + value.Position,
				"BuildingType" + value.BuildingType
			};
			_owner = value;
		}
	}

	public int WorkbenchIndex
	{
		get
		{
			return _workbenchindex;
		}
		set
		{
			_workbenchindex = value;
			GameController.Contexts.Service<BaseSceneService>().AddWorkbench(Owner.BuildingType, _workbenchindex, this);
		}
	}

	public List<string> ProductTaskList
	{
		get
		{
			return productTaskList;
		}
		set
		{
			if (productTaskList == null)
			{
				_productTaskLast = value;
			}
			else
			{
				_productTaskLast = ListExtensions.DeepCopy<string>(productTaskList);
			}
			productTaskList = value;
			if (_owner.GetProductionConfigAt(_workbenchindex).Workers == 0)
			{
				productTaskList = null;
			}
			if (value == null)
			{
				waitProduceState = null;
			}
			if ((Object)(object)workerController != (Object)null && workerController.isInit && curProduceState != null)
			{
				Workbench_TweenCallback = null;
				CalcNextWorkerStatus();
			}
		}
	}

	public void RefreshProduceState(int i, ProduceState state)
	{
		waitProduceState = state;
		if (ProductTaskList == null)
		{
			ProductTaskList = Owner.GetProductionConfigAt(WorkbenchIndex).ProductList;
		}
		if (curProduceState == null || state.ProduceStartAt != curProduceState.ProduceStartAt || state.ProduceEndAt != curProduceState.ProduceEndAt || state.WorkerStatus != curProduceState.WorkerStatus || state.ProduceStatus != curProduceState.ProduceStatus || waitProduceState != null)
		{
			isProduceStateRefresh = true;
			if (_Coroutine_WaitTo_RefreshProduceState != null)
			{
				((MonoBehaviour)this).StopCoroutine(_Coroutine_WaitTo_RefreshProduceState);
			}
			_Coroutine_WaitTo_RefreshProduceState = ((MonoBehaviour)this).StartCoroutine(WaitTo_RefreshProduceState(i, state));
		}
	}

	private IEnumerator WaitTo_RefreshProduceState(int i, ProduceState state)
	{
		long serverTm = GameController.Instance.GetServerTime();
		float ui_wait_tm = Random.Range(0f, 2f);
		if (Owner.BuildingType == "12")
		{
			long diff = state.ProduceEndAt - serverTm * 1000;
			ui_wait_tm = (float)diff / 1000f;
		}
		state.UIFinish = false;
		yield return (object)new WaitForSeconds(ui_wait_tm);
		if (waitProduceState != null)
		{
			CalcNextWorkerStatus();
		}
	}

	private void SetCurProduceState()
	{
		if (waitProduceState != null)
		{
			_curProduceState = waitProduceState;
			waitProduceState = null;
		}
	}

	public void ChangeWorkbenchStatus(WorkbenchStatus _status)
	{
		if (!Contexts.sharedInstance.Service<BaseSceneService>().get_EnableMaincity_Monobehaviour())
		{
			return;
		}
		if (WorkbenchStatusMachine == null)
		{
			WorkbenchStatusMachine = new Dictionary<WorkbenchStatus, Action>
			{
				{
					WorkbenchStatus.Do_InRoom,
					WorkbenchStatusHandler_Do_InRoom
				},
				{
					WorkbenchStatus.Do_GrabbedResources,
					WorkbenchStatusHandler_Do_GrabbedResources
				},
				{
					WorkbenchStatus.Do_BringBackResources,
					WorkbenchStatusHandler_Do_BringBackResources
				},
				{
					WorkbenchStatus.Do_GoToWorkbenchWithResources,
					WorkbenchStatusHandler_Do_GoToWorkbenchWithResources
				},
				{
					WorkbenchStatus.Do_GoToWorkbenchWithOutResources,
					WorkbenchStatusHandler_Do_GoToWorkbenchWithOutResources
				},
				{
					WorkbenchStatus.Do_Workbench_Lazy,
					WorkbenchStatusHandler_Do_Workbench_Lazy
				},
				{
					WorkbenchStatus.Do_Workbench_Normal,
					WorkbenchStatusHandler_Do_Workbench_Normal
				},
				{
					WorkbenchStatus.Do_Workbench_Diligent,
					WorkbenchStatusHandler_Do_Workbench_Diligent
				},
				{
					WorkbenchStatus.Do_WorkbenchFinish,
					WorkbenchStatusHandler_Do_WorkbenchFinish
				},
				{
					WorkbenchStatus.Do_ResourcesLack,
					WorkbenchStatusHandler_Do_ResourcesLack
				},
				{
					WorkbenchStatus.Do_StockIsFull,
					WorkbenchStatusHandler_Do_StockIsFull
				}
			};
		}
		if (curProduceState != null)
		{
			if (CurStatus == WorkbenchStatus.NotInited)
			{
				CurStatus = WorkbenchStatus.Do_InRoom;
			}
			tmpStatus = _status;
			if (CoroutineID != null)
			{
				((MonoBehaviour)this).StopCoroutine(CoroutineID);
			}
			CoroutineID = ((MonoBehaviour)this).StartCoroutine(Coroutine_ChangeWorkbenchStatus());
		}
	}

	private IEnumerator Coroutine_ChangeWorkbenchStatus()
	{
		if (Contexts.sharedInstance.Service<BaseSceneService>().get_EnableMaincity_Monobehaviour())
		{
			if ((CurStatus == WorkbenchStatus.Do_GrabbedResources || CurStatus == WorkbenchStatus.Do_BringBackResources || CurStatus == WorkbenchStatus.Do_GoToWorkbenchWithResources || CurStatus == WorkbenchStatus.Do_GoToWorkbenchWithOutResources || CurStatus == WorkbenchStatus.Do_WorkbenchFinish) && WorkerTweener != null)
			{
				yield return TweenExtensions.WaitForCompletion((Tween)(object)WorkerTweener);
			}
			Tweener workerTweener = WorkerTweener;
			if (workerTweener != null)
			{
				TweenExtensions.Kill((Tween)(object)workerTweener, false);
			}
			LastStatus = CurStatus;
			CurStatus = tmpStatus;
			workerMovePath = null;
			Workbench_TweenCallback = null;
			WorkbenchStatusMachine[CurStatus]();
		}
	}

	private void WorkbenchStatusHandler_NotInited()
	{
	}

	private void WorkbenchStatusHandler_Do_InRoom()
	{
		if (LastStatus != WorkbenchStatus.Do_InRoom)
		{
			workerMovePath = workerController.PathArray_StartToBedroomPath;
		}
		workerController.UIChange_StartToBed();
		workerController.InitBubble();
		InitBench();
		Workbench_TweenCallback = workerController.OnInRoom;
		if (Owner.BuildingType == "12")
		{
			WorkerUpdate();
		}
		WorkerMove(workerMovePath);
	}

	private void WorkbenchStatusHandler_Do_GrabbedResources()
	{
		if (LastStatus == WorkbenchStatus.Do_InRoom)
		{
			workerMovePath = workerController.PathArray_BedroomToStartPath;
			workerController.InitWorker();
			if (Owner.Feature != "Mine")
			{
				Workbench_TweenCallback = workerController.ShowSack;
			}
			workerController.UIChange_BedroomToStart();
		}
		else if (LastStatus == WorkbenchStatus.Do_WorkbenchFinish)
		{
			if (Owner.Feature == "Mine")
			{
				workerController.UIChange_StartToWorkbench();
			}
			else
			{
				workerMovePath = workerController.PathArray_FinishToStartPath;
				workerController.UIChange_FinishToStart();
			}
			((WorkshopController)Owner.Controller).Delivery(LatestProductions);
			workerController.InitWorker();
		}
		else if (LastStatus == WorkbenchStatus.Do_ResourcesLack)
		{
			workerMovePath = workerController.PathArray_WorkbenchToStartPath;
			workerController.InitWorker();
		}
		else if (LastStatus == WorkbenchStatus.Do_BringBackResources)
		{
			workerMovePath = null;
		}
		else if (LastStatus == WorkbenchStatus.Do_StockIsFull)
		{
			if (Owner.Feature == "Mine")
			{
				workerController.InitWorker();
				workerController.InitBubble();
				workerController.UIChange_StartToWorkbench();
			}
			else
			{
				workerMovePath = workerController.PathArray_WorkbenchToStartPath;
				workerController.InitWorker();
				workerController.InitBubble();
				workerController.UIChange_WorkbenchToStart();
			}
		}
		else
		{
			if (LastStatus != WorkbenchStatus.Do_GoToWorkbenchWithOutResources)
			{
				ILRuntimeDebug.CatchErrorBySentry("[WorkbenchStatus] CheckFailed! Do_GrabbedResources  LastStatus is {0}", LastStatus);
				return;
			}
			if (Owner.Feature != "Mine")
			{
				workerMovePath = workerController.PathArray_WorkbenchToStartPath;
				workerController.InitWorker();
				workerController.InitBubble();
				workerController.UIChange_WorkbenchToStart();
			}
		}
		workerController.InitBubble();
		WorkerMove(workerMovePath);
	}

	private void WorkbenchStatusHandler_Do_BringBackResources()
	{
		if (LastStatus == WorkbenchStatus.Do_GrabbedResources)
		{
			workerMovePath = null;
			Workbench_TweenCallback = workerController.InitWorker;
		}
		else
		{
			if (LastStatus != WorkbenchStatus.Do_StockIsFull && LastStatus != WorkbenchStatus.Do_Workbench_Lazy && LastStatus != WorkbenchStatus.Do_Workbench_Normal && LastStatus != WorkbenchStatus.Do_Workbench_Diligent && LastStatus != WorkbenchStatus.Do_GoToWorkbenchWithResources)
			{
				ILRuntimeDebug.CatchErrorBySentry("[WorkbenchStatus] CheckFailed! Do_BringBackResources  LastStatus is {0}", LastStatus);
				return;
			}
			workerMovePath = workerController.PathArray_WorkbenchToStartPath;
			if (Owner.Feature == "Mine")
			{
				workerController.InitWorker();
			}
			else
			{
				workerController.ShowSack();
			}
			workerController.InitBubble();
			workerController.UIChange_WorkbenchToStart();
			InitBench();
		}
		workerController.InitBubble();
		WorkerMove(workerMovePath);
	}

	private void WorkbenchStatusHandler_Do_GoToWorkbenchWithOutResources()
	{
		if (LastStatus != WorkbenchStatus.Do_InRoom && LastStatus != WorkbenchStatus.Do_GrabbedResources)
		{
			ILRuntimeDebug.CatchErrorBySentry("[WorkbenchStatus] CheckFailed! Do_GoToWorkbenchWithOutResources  LastStatus is {0}", LastStatus);
			return;
		}
		if (Owner.Feature == "Mine")
		{
			if (LastStatus == WorkbenchStatus.Do_InRoom)
			{
				workerMovePath = workerController.PathArray_BedroomToStartToWorkbenchPath;
				workerController.UIChange_BedroomToStart();
			}
			else
			{
				workerMovePath = workerController.PathArray_WorkbenchToStartPath;
				workerController.UIChange_WorkbenchToStart();
			}
		}
		else
		{
			workerMovePath = workerController.PathArray_StartToWorkbenchPath;
			workerController.UIChange_StartToWorkbench();
		}
		workerController.InitWorker();
		workerController.InitBubble();
		WorkerMove(workerMovePath);
	}

	private void WorkbenchStatusHandler_Do_GoToWorkbenchWithResources()
	{
		if (LastStatus != WorkbenchStatus.Do_GoToWorkbenchWithResources && LastStatus != WorkbenchStatus.Do_GrabbedResources)
		{
			ILRuntimeDebug.CatchErrorBySentry("[WorkbenchStatus] CheckFailed! Do_GoToWorkbenchWithResources  LastStatus is {0}", LastStatus);
			return;
		}
		workerMovePath = workerController.PathArray_StartToWorkbenchPath;
		if (Owner.BuildingType == "12")
		{
			workerMovePath = null;
		}
		if (Owner.Feature == "Mine")
		{
			workerController.InitWorker();
			workerController.UIChange_WorkbenchToStart();
		}
		else
		{
			workerController.ShowSack();
			workerController.UIChange_StartToWorkbench();
		}
		workerController.InitBubble();
		WorkerMove(workerMovePath);
	}

	private void WorkbenchStatusHandler_Do_Workbench_Lazy()
	{
		ShowProduce();
		workerController.ChangeWorkerTitle(1);
		workerController.InitBubble();
		workerController.UIChange_SetWorkerStatus(WorkerStatus.Lazy);
		WorkerMove(null);
	}

	private void WorkbenchStatusHandler_Do_Workbench_Normal()
	{
		ShowProduce();
		workerController.ChangeWorkerTitle(1);
		workerController.InitBubble();
		workerController.UIChange_SetWorkerStatus(WorkerStatus.Normal);
		WorkerMove(null);
	}

	private void WorkbenchStatusHandler_Do_Workbench_Diligent()
	{
		ShowProduce();
		workerController.ChangeWorkerTitle(1);
		workerController.InitBubble();
		workerController.UIChange_SetWorkerStatus(WorkerStatus.Diligent);
		WorkerMove(null);
	}

	private void WorkbenchStatusHandler_Do_WorkbenchFinish()
	{
		workerController.ChangeWorkerTitle(-1);
		workerMovePath = null;
		if (LastStatus == WorkbenchStatus.Do_Workbench_Lazy || LastStatus == WorkbenchStatus.Do_Workbench_Normal || LastStatus == WorkbenchStatus.Do_Workbench_Diligent || LastStatus == WorkbenchStatus.Do_GoToWorkbenchWithResources)
		{
			workerMovePath = workerController.PathArray_WorkbenchToFinishPath;
			workerController.WorkerAnimation.AnimationName = "carry";
			workerController.UIChange_WorkbenchToFinish();
			workerController.InitBubble();
			InitBench();
			WorkerMove(workerMovePath);
		}
		else if (LastStatus != WorkbenchStatus.Do_InRoom)
		{
			ILRuntimeDebug.CatchErrorBySentry("[WorkbenchStatus] CheckFailed! Do_WorkbenchFinish  LastStatus is {0}", LastStatus);
		}
	}

	private void WorkbenchStatusHandler_Do_ResourcesLack()
	{
		InitBench();
		workerController.ShowWaitingMaterialBubble();
		WorkerMove(workerMovePath);
	}

	private void WorkbenchStatusHandler_Do_StockIsFull()
	{
		InitBench();
		workerController.InitBubble();
		if (Owner.Feature == "Mine")
		{
			workerController.InitWorker();
			workerController.UIChange_WorkbenchToStart();
			workerMovePath = workerController.PathArray_WorkbenchToStartPath;
		}
		Workbench_TweenCallback = workerController.ShowWaitingStockSpaceBubble;
		WorkerMove(workerMovePath);
	}

	private void WorkerMove(Vector3[] _path_array)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected O, but got Unknown
		if (Contexts.sharedInstance.Service<BaseSceneService>().get_EnableMaincity_Monobehaviour())
		{
			if (_path_array != null)
			{
				_path_array = workerController.TryAddGradientPointBeforeMove(_path_array);
				WorkerTweener = (Tweener)(object)TweenSettingsExtensions.SetAutoKill<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.SetSpeedBased<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.OnComplete<TweenerCore<Vector3, Path, PathOptions>>(TweenSettingsExtensions.OnUpdate<TweenerCore<Vector3, Path, PathOptions>>(ShortcutExtensions.DOPath(workerController_trans, _path_array, workerController.WorkerSpeed, (PathType)0, (PathMode)2, 10, (Color?)null), new TweenCallback(WorkerUpdate)), new TweenCallback(CalcNextWorkerStatus)), (Ease)1), true), true);
			}
			else
			{
				CalcNextWorkerStatus();
			}
		}
	}

	private void WorkerUpdate()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		float num = workerController_trans.position.x - _x;
		if (Math.Abs(num) > float.Epsilon)
		{
			((SkeletonRenderer)workerController.WorkerAnimation).skeleton.FlipX = num > 0f;
		}
		_x += num;
		if (Owner.Feature == "Mine")
		{
			workerController.UIChange_Alpha();
		}
		if (Owner.Feature == "WorkShop")
		{
			workerController.UIChange_SortingOrder_OnUpdate();
		}
	}

	public void CalcNextWorkerStatus()
	{
		lock (this)
		{
			SetCurProduceState();
			if (!Contexts.sharedInstance.Service<BaseSceneService>().get_EnableMaincity_Monobehaviour())
			{
				return;
			}
			Workbench_TweenCallback?.Invoke();
			Workbench_TweenCallback = null;
			if (CurStatus == WorkbenchStatus.NotInited && Owner.BuildingType == "12")
			{
				Tweener workerTweener = WorkerTweener;
				if (workerTweener != null)
				{
					TweenExtensions.Kill((Tween)(object)workerTweener, false);
				}
				if (CoroutineID != null)
				{
					((MonoBehaviour)this).StopCoroutine(CoroutineID);
				}
				if (ProduceCoroutine != null)
				{
					((MonoBehaviour)this).StopCoroutine(ProduceCoroutine);
				}
				workerController.OnInRoom();
				workerController.InitWorker();
				SetCurProduceState();
				CurStatus = WorkbenchStatus.Do_Workbench_Normal;
			}
			switch (CurStatus)
			{
			case WorkbenchStatus.NotInited:
			case WorkbenchStatus.Do_InRoom:
			{
				LastStatus = WorkbenchStatus.Do_InRoom;
				CurStatus = WorkbenchStatus.Do_InRoom;
				Tweener workerTweener2 = WorkerTweener;
				if (workerTweener2 != null)
				{
					TweenExtensions.Kill((Tween)(object)workerTweener2, false);
				}
				if (CoroutineID != null)
				{
					((MonoBehaviour)this).StopCoroutine(CoroutineID);
				}
				if (ProduceCoroutine != null)
				{
					((MonoBehaviour)this).StopCoroutine(ProduceCoroutine);
				}
				workerController.OnInRoom();
				workerController.InitWorker();
				SetCurProduceState();
				if (curProduceState != null && ProductTaskList != null)
				{
					if (curProduceState.ProduceEndAt == 0L || curProduceState.ProduceEndAt > GameController.Instance.GetServerTime())
					{
						if (curProduceState.ProduceStatus == 2 || curProduceState.ProduceStatus == 3)
						{
							ChangeWorkbenchStatus(WorkbenchStatus.Do_GoToWorkbenchWithOutResources);
						}
						else
						{
							ChangeWorkbenchStatus(WorkbenchStatus.Do_GrabbedResources);
						}
					}
					else
					{
						LastStatus = WorkbenchStatus.Do_InRoom;
						CurStatus = WorkbenchStatus.Do_InRoom;
					}
				}
				else
				{
					_curProduceState = null;
				}
				if (Owner.BuildingType == "12")
				{
					((Component)workerController).gameObject.SetActive(false);
				}
				break;
			}
			case WorkbenchStatus.Do_GrabbedResources:
				if (ProductTaskList == null)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_BringBackResources);
				}
				else if (curProduceState.ProduceStatus == 0 || 1 == curProduceState.ProduceStatus)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_GoToWorkbenchWithResources);
				}
				else if (3 == curProduceState.ProduceStatus)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_GoToWorkbenchWithOutResources);
				}
				else if (2 == curProduceState.ProduceStatus)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_StockIsFull);
				}
				else
				{
					ILRuntimeDebug.CatchErrorBySentry("Do_GrabbedResources?????????");
				}
				break;
			case WorkbenchStatus.Do_GoToWorkbenchWithResources:
				if (ProductTaskList == null)
				{
					if (Owner.Feature == "Mine")
					{
						ChangeWorkbenchStatus(WorkbenchStatus.Do_InRoom);
					}
					else
					{
						ChangeWorkbenchStatus(WorkbenchStatus.Do_BringBackResources);
					}
				}
				else if (Owner.BuildingType == "12" && curProduceState.UIFinish)
				{
					ProductTaskList = null;
					ChangeWorkbenchStatus(WorkbenchStatus.Do_InRoom);
				}
				else if (curProduceState.WorkerStatus == 0)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_Workbench_Normal);
				}
				else if (curProduceState.WorkerStatus == 2)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_Workbench_Lazy);
				}
				else if (curProduceState.WorkerStatus == 1)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_Workbench_Diligent);
				}
				else
				{
					ILRuntimeDebug.CatchErrorBySentry("Do_GoToWorkbenchWithResources?????????");
				}
				break;
			case WorkbenchStatus.Do_GoToWorkbenchWithOutResources:
				if (curProduceState.ProduceStatus == 2)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_StockIsFull);
				}
				else if (curProduceState.ProduceStatus == 3)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_ResourcesLack);
				}
				else if (curProduceState.ProduceStatus == 1)
				{
					if (curProduceState.WorkerStatus == 0)
					{
						ChangeWorkbenchStatus(WorkbenchStatus.Do_GrabbedResources);
					}
					else if (curProduceState.WorkerStatus == 2)
					{
						ChangeWorkbenchStatus(WorkbenchStatus.Do_GrabbedResources);
					}
					else if (curProduceState.WorkerStatus == 1)
					{
						ChangeWorkbenchStatus(WorkbenchStatus.Do_GrabbedResources);
					}
					else
					{
						ILRuntimeDebug.CatchErrorBySentry("Do_GoToWorkbenchWithOutResources ?????????");
					}
				}
				break;
			case WorkbenchStatus.Do_Workbench_Lazy:
			case WorkbenchStatus.Do_Workbench_Normal:
			case WorkbenchStatus.Do_Workbench_Diligent:
			{
				if (isProduceStateRefresh)
				{
					if (curProduceState == null)
					{
						if (Owner.Feature == "Mine")
						{
							workerController.ChangeWorkerTitle(-1);
							ChangeWorkbenchStatus(WorkbenchStatus.Do_InRoom);
						}
						else
						{
							ChangeWorkbenchStatus(WorkbenchStatus.Do_BringBackResources);
						}
					}
					else if (curProduceState.ProduceStatus == 2)
					{
						workerController.ChangeWorkerTitle(-1);
						ChangeWorkbenchStatus(WorkbenchStatus.Do_StockIsFull);
					}
					else if (curProduceState.ProduceStatus == 3)
					{
						workerController.ChangeWorkerTitle(-1);
						ChangeWorkbenchStatus(WorkbenchStatus.Do_ResourcesLack);
					}
					else if (Contexts.sharedInstance.Service<BaseSceneService>().get_EnableMaincity_Monobehaviour())
					{
						if (ProduceCoroutine != null)
						{
							((MonoBehaviour)this).StopCoroutine(ProduceCoroutine);
						}
						ShowFinishProduce(need_sync: false);
						ProduceCoroutine = null;
					}
					break;
				}
				bool flag = false;
				if (productTaskList == null || (productTaskList != null && _productTaskLast == null))
				{
					flag = true;
				}
				else if (productTaskList != null && _productTaskLast != null)
				{
					if (productTaskList.Count != _productTaskLast.Count)
					{
						flag = true;
					}
					else
					{
						int count = productTaskList.Count;
						for (int i = 0; i < count; i++)
						{
							if (_productTaskLast.IndexOf(productTaskList[i]) < 0)
							{
								flag = true;
							}
						}
					}
				}
				if (!flag)
				{
					break;
				}
				_productTaskLast = productTaskList;
				if (Owner.Feature == "Mine")
				{
					if (productTaskList == null)
					{
						workerController.ChangeWorkerTitle(-1);
						ChangeWorkbenchStatus(WorkbenchStatus.Do_InRoom);
					}
					break;
				}
				if (curProduceState == null || productTaskList == null)
				{
					workerController.ChangeWorkerTitle(-1);
					ChangeWorkbenchStatus(WorkbenchStatus.Do_InRoom);
					break;
				}
				if (curProduceState.CurProduceRecords == null)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_BringBackResources);
					break;
				}
				for (int j = 0; j < curProduceState.CurProduceRecords.Length; j++)
				{
					StockChangeRecord stockChangeRecord = curProduceState.CurProduceRecords[j];
					if (productTaskList.IndexOf(stockChangeRecord.ItemId.Replace("I", "P")) < 0)
					{
						ChangeWorkbenchStatus(WorkbenchStatus.Do_BringBackResources);
						break;
					}
				}
				break;
			}
			case WorkbenchStatus.Do_WorkbenchFinish:
				if (ProductTaskList == null)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_InRoom);
				}
				else
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_GrabbedResources);
				}
				break;
			case WorkbenchStatus.Do_ResourcesLack:
				if (ProductTaskList == null)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_InRoom);
				}
				else if (curProduceState.ProduceStatus == 1 || curProduceState.ProduceStatus == 0)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_GrabbedResources);
				}
				else if (curProduceState.ProduceStatus == 2)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_StockIsFull);
				}
				break;
			case WorkbenchStatus.Do_StockIsFull:
				workerController.ShowWaitingStockSpaceBubble();
				if (ProductTaskList == null)
				{
					if (Owner.Feature == "Mine")
					{
						ChangeWorkbenchStatus(WorkbenchStatus.Do_InRoom);
					}
					else
					{
						ChangeWorkbenchStatus(WorkbenchStatus.Do_BringBackResources);
					}
				}
				else if (curProduceState.ProduceStatus == 1 || curProduceState.ProduceStatus == 0)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_GrabbedResources);
				}
				else if (curProduceState.ProduceStatus == 3)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_ResourcesLack);
				}
				break;
			case WorkbenchStatus.Do_BringBackResources:
				if (ProductTaskList == null)
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_InRoom);
				}
				else
				{
					ChangeWorkbenchStatus(WorkbenchStatus.Do_GrabbedResources);
				}
				break;
			}
			isProduceStateRefresh = false;
		}
	}

	private void InitBench()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if (ProduceCoroutine != null)
		{
			((MonoBehaviour)this).StopCoroutine(ProduceCoroutine);
		}
		UiHelper.GetProductLoader(ProductIcon, "");
		WorkbenchSliders.transform.localScale = new Vector3(0f, 0.5f, 1f);
	}

	private void Awake()
	{
		_lock = new object();
		timeScale = 1f;
		WorkerStatus = WorkerStatus.Normal;
		productTaskList = null;
		ProductList = null;
		ResultList = null;
		AddonDict = null;
		if (GrabbedResources == null)
		{
			GrabbedResources = new Dictionary<string, int>();
		}
		if (LatestProductions == null)
		{
			LatestProductions = new Dictionary<string, int>();
		}
	}

	public void InterruptProduce()
	{
		if (_produce != null)
		{
			((Tween)_produce).onComplete = null;
			TweenExtensions.Complete((Tween)(object)_produce, false);
			_produce = null;
		}
		if (ResultList == null)
		{
			ResultList = new List<GDEProductData>();
		}
		else
		{
			ResultList.Clear();
		}
		if (AddonDict == null)
		{
			AddonDict = new Dictionary<string, int>();
		}
		else
		{
			AddonDict.Clear();
		}
		if (IsProducing)
		{
			FinishProduce();
		}
		IsInterrupted = true;
		workerController.WorkInterrupted();
	}

	private void ShowProduce()
	{
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		if (curProduceState.CurProduceRecords == null || curProduceState.CurProduceRecords.Length == 0)
		{
			Workbench_TweenCallback = null;
			CalcNextWorkerStatus();
			return;
		}
		workerController.UIChange_Produce();
		ProduceTime = curProduceState.ProduceEndAt - GameController.Instance.GetServerTime();
		string text = curProduceState.CurProduceRecords[0].ItemId;
		if (Owner.BuildingType == "12")
		{
			ProduceTime = -1f;
		}
		else
		{
			text = text.Replace("I", "P");
		}
		proDuctIconName = UiHelper.GetIconPath(text, 0, null, isMaterialIcon: true);
		UiHelper.GetProductLoader(ProductIcon, proDuctIconName);
		if (Owner.BuildingType == "8" && WorkbenchIndex < 6)
		{
			WorkbenchSliders.transform.localPosition = new Vector3(0.47f, 0.5f, -0.1f);
		}
		else
		{
			WorkbenchSliders.transform.localPosition = new Vector3(-0.47f, 0.5f, -0.1f);
		}
		if (ProduceTime < 0f)
		{
			ProduceTime = 0.1f;
		}
		if (ProduceCoroutine != null)
		{
			((MonoBehaviour)this).StopCoroutine(ProduceCoroutine);
		}
		ProduceCoroutine = ((MonoBehaviour)this).StartCoroutine(StartProduceCoroutine());
	}

	private IEnumerator StartProduceCoroutine()
	{
		if (!Contexts.sharedInstance.Service<BaseSceneService>().get_EnableMaincity_Monobehaviour())
		{
			yield break;
		}
		Vector3 _Scale = new Vector3(0f, 0.5f, 1f);
		long produce_endat = curProduceState.ProduceEndAt;
		long left_tm = produce_endat - GameController.Instance.GetServerTime();
		if (Owner.BuildingType == "12")
		{
			left_tm = 0L;
		}
		long total_tm = curProduceState.ProduceEndAt - curProduceState.ProduceStartAt;
		while (left_tm > 0)
		{
			if (!Contexts.sharedInstance.Service<BaseSceneService>().get_EnableMaincity_Monobehaviour())
			{
				yield break;
			}
			left_tm = produce_endat - GameController.Instance.GetServerTime();
			if (curProduceState == null || (float)left_tm < 0f)
			{
				break;
			}
			_Scale.x = 0.5f * (float)(total_tm - left_tm) / (float)total_tm;
			if (_Scale.x < 0f)
			{
				_Scale.x = 0f;
			}
			WorkbenchSliders.transform.localScale = _Scale;
			yield return (object)new WaitForSeconds(0.5f);
		}
		ShowFinishProduce();
		ProduceCoroutine = null;
	}

	private void ShowFinishProduce(bool need_sync = true)
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		ProduceTime = 0f;
		if (curProduceState == null || ProductTaskList == null)
		{
			if (Contexts.sharedInstance.Service<BaseSceneService>().get_EnableMaincity_Monobehaviour())
			{
				ChangeWorkbenchStatus(WorkbenchStatus.Do_InRoom);
			}
			return;
		}
		if (curProduceState != null && curProduceState.CurProduceRecords != null && curProduceState.CurProduceRecords.Length != 0)
		{
			StockChangeRecord stockChangeRecord = curProduceState.CurProduceRecords[0];
			LatestProductions.Clear();
			LatestProductions.Add(stockChangeRecord.ItemId, stockChangeRecord.Offset);
		}
		curProduceState.UIFinish = true;
		ChangeWorkbenchStatus(WorkbenchStatus.Do_WorkbenchFinish);
		UiHelper.GetProductLoader(ProductIcon, "");
		WorkbenchSliders.transform.localScale = new Vector3(0f, 0.5f, 1f);
		if (need_sync && Owner.BuildingType != "12")
		{
			GameManagers.Instance.StockController.NeedSyncProduce = true;
		}
	}

	public void Produce(out bool waitingStock, out bool waitingMaterial, out string waitingMaterialId)
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		waitingMaterial = false;
		waitingStock = false;
		waitingMaterialId = "";
		if (!IsProducing && CanProduce(out waitingStock, out waitingMaterial, out waitingMaterialId))
		{
			IsProducing = true;
			GDEProductData gDEProductData = ResultList.First();
			CalcProducingTime(gDEProductData.Time);
			proDuctIconName = UiHelper.GetIconPath(gDEProductData.Key, 0, null, isMaterialIcon: true);
			UiHelper.GetProductLoader(ProductIcon, proDuctIconName);
			if (Owner.BuildingType == "8" && WorkbenchIndex < 6)
			{
				WorkbenchSliders.transform.localPosition = new Vector3(0.47f, 0.5f, -0.1f);
			}
			else
			{
				WorkbenchSliders.transform.localPosition = new Vector3(-0.47f, 0.5f, -0.1f);
			}
			_produce = TweenSettingsExtensions.SetAutoKill<Tweener>(ShortcutExtensions.DOScaleX(WorkbenchSliders.transform, 0.5f, ProduceTime), true);
			TweenSettingsExtensions.OnComplete<Tweener>(_produce, new TweenCallback(FinishProduce));
			((Tween)_produce).timeScale = timeScale;
		}
	}

	public void SetProduceStatus(ProduceStatus _status)
	{
		switch (_status)
		{
		case ProduceStatus.Free:
			_canProduce = true;
			break;
		case ProduceStatus.Producing:
			_canProduce = true;
			break;
		case ProduceStatus.WaitingStockSpace:
			_canProduce = false;
			waitingStock = true;
			break;
		case ProduceStatus.WaitingResources:
			_canProduce = false;
			waitingMaterial = true;
			break;
		}
	}

	public bool CanProduce(out bool _waitingStock, out bool _waitingMaterial, out string _waitingMaterialId)
	{
		_waitingMaterial = waitingMaterial;
		_waitingStock = waitingStock;
		_waitingMaterialId = waitingMaterialId;
		if (IsProducing)
		{
			return false;
		}
		if (productTaskList == null || productTaskList.Count < 1)
		{
			return false;
		}
		List<GDEProductData> stockFullList = null;
		if (ResultList.Count <= 0)
		{
			GenerateResultList(out stockFullList);
		}
		return _canProduce;
	}

	public void RefundConsumptions()
	{
		GrabbedResources.Clear();
	}

	public void GrabResources()
	{
		GrabbedResources.Clear();
		if (!CanProduce(out var _, out var _, out var _) || ResultList.Count <= 0)
		{
			return;
		}
		string key = ResultList.First().Key;
		if (!BuildingManager.ProductRequirements.TryGetValue(key, out var value) || value.Count < 1)
		{
			return;
		}
		ModifierManager modifierManager = GameManagers.Instance.ModifierManager;
		float num = 0f * (1f + modifierManager.GetPercentFloatPayload("FreeProduceChance", buildingFilter)) + modifierManager.GetFixedFloatPayload("FreeProduceChance", buildingFilter);
		float num2 = 1f + modifierManager.GetPercentFloatPayload("ProduceCost", buildingFilter);
		float fixedFloatPayload = modifierManager.GetFixedFloatPayload("ProduceCost", buildingFilter);
		bool flag = num > GameManagers.Instance.RandomManager.Float();
		foreach (KeyValuePair<string, int> item in value)
		{
			int value2 = Mathf.RoundToInt((float)item.Value * num2 + fixedFloatPayload);
			if (flag)
			{
			}
			GrabbedResources.Add(item.Key, value2);
		}
	}

	private void FinishProduce()
	{
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		IsProducing = false;
		ProduceTime = 0f;
		LatestProductions.Clear();
		if (ResultList != null && ResultList.Count > 0)
		{
			if (GrabbedResources.Count > 0)
			{
				GrabbedResources.Clear();
			}
			foreach (GDEProductData result in ResultList)
			{
				LatestProductions.Add(result.ItemId, result.SingleNumber);
			}
			foreach (KeyValuePair<string, int> item in AddonDict)
			{
				LatestProductions.Add(item.Key, item.Value);
			}
			GameManagers.Instance.StockController.NeedSyncProduce = true;
		}
		UiHelper.GetProductLoader(ProductIcon, "");
		WorkbenchSliders.transform.localScale = new Vector3(0f, 0.5f, 1f);
		if (ResultList != null)
		{
			ResultList.Clear();
		}
		if (AddonDict != null)
		{
			AddonDict.Clear();
		}
	}

	public void SetWorkerStatus(WorkerStatus status)
	{
		if (workerController.IsWorking)
		{
			WorkerStatus = status;
			switch (status)
			{
			case WorkerStatus.Normal:
				timeScale = 1f;
				break;
			case WorkerStatus.Diligent:
				timeScale = 2f;
				break;
			case WorkerStatus.Lazy:
				timeScale = 0f;
				break;
			default:
				timeScale = 1f;
				break;
			}
			if (_produce != null)
			{
				((Tween)_produce).timeScale = timeScale;
			}
			if ((Object)(object)workerController != (Object)null)
			{
				workerController.SetWorkerStatus(status);
			}
			if ((Object)(object)moltenCoreWorkerController != (Object)null)
			{
				moltenCoreWorkerController.SetWorkerStatus(status);
			}
		}
	}

	public void AfterProduce(TweenCallback action)
	{
		_afterProduceCallback = action;
		ResetProduceCompleteCallback();
	}

	private void ClearProduceCompleteCallbacks()
	{
		_produce = null;
		_afterProduceCallback = null;
	}

	private void ResetProduceCompleteCallback()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		if (_produce != null)
		{
			((Tween)_produce).onComplete = null;
			Tweener produce = _produce;
			((Tween)produce).onComplete = (TweenCallback)Delegate.Combine((Delegate?)(object)((Tween)produce).onComplete, (Delegate?)new TweenCallback(FinishProduce));
			if (_afterProduceCallback != null)
			{
				Tweener produce2 = _produce;
				((Tween)produce2).onComplete = (TweenCallback)Delegate.Combine((Delegate?)(object)((Tween)produce2).onComplete, (Delegate?)(object)_afterProduceCallback);
			}
			Tweener produce3 = _produce;
			((Tween)produce3).onComplete = (TweenCallback)Delegate.Combine((Delegate?)(object)((Tween)produce3).onComplete, (Delegate?)new TweenCallback(ClearProduceCompleteCallbacks));
		}
	}

	public void CalcProducingTime(float baseTime)
	{
		float num = 0f;
		float num2 = 1f;
		if (Owner != null)
		{
			ModifierManager modifierManager = GameManagers.Instance.ModifierManager;
			num2 += modifierManager.GetPercentFloatPayload("ProductionEfficiency", buildingFilter);
			num -= modifierManager.GetFixedFloatPayload("ProducingTime", buildingFilter);
		}
		ProduceTime = (baseTime - num) / num2;
	}

	private void GenerateResultList(out List<GDEProductData> stockFullList)
	{
		if (ResultList == null)
		{
			ResultList = new List<GDEProductData>();
		}
		else
		{
			ResultList.Clear();
		}
		if (AddonDict == null)
		{
			AddonDict = new Dictionary<string, int>();
		}
		else
		{
			AddonDict.Clear();
		}
		List<GDEProductData> targetList = ListExtensions.DeepCopy<GDEProductData>(ProductList);
		int totalWeight = _productTotalWeight;
		stockFullList = new List<GDEProductData>();
		foreach (GDEProductData item in targetList)
		{
			if (GameManagers.Instance.StockController.GetStock(item.ItemId) >= GameManagers.Instance.StockController.GetLimit(item.ItemId))
			{
				stockFullList.Add(item);
			}
		}
		foreach (GDEProductData stockFull in stockFullList)
		{
			totalWeight -= stockFull.Weight;
			targetList.Remove(stockFull);
		}
		if (targetList.Count <= 0)
		{
			return;
		}
		if (targetList.Count == 1)
		{
			ResultList.Add(targetList.First());
		}
		else
		{
			GDEProductData productionByWeight = GetProductionByWeight(ref targetList, ref totalWeight);
			if (productionByWeight != null)
			{
				ResultList.Add(productionByWeight);
			}
		}
		if (!(Owner.Feature == "Mine"))
		{
			return;
		}
		ModifierManager modifierManager = GameManagers.Instance.ModifierManager;
		float num = Owner.AddOnRate * (1f + modifierManager.GetPercentFloatPayload("TreasureFinder", buildingFilter)) + modifierManager.GetFixedFloatPayload("TreasureFinder", buildingFilter);
		float num2 = Owner.ExtraProdRate * (1f + modifierManager.GetPercentFloatPayload("StubornWorker", buildingFilter)) + modifierManager.GetFixedFloatPayload("StubornWorker", buildingFilter);
		if (AddonDict.Count <= 0)
		{
			GDEProductData gDEProductData = null;
			if (num > GameManagers.Instance.RandomManager.Float())
			{
				gDEProductData = GenerateAddOnProduct(Owner, new string[1] { ResultList.First().Key }, ProductFilter.AddOn);
			}
			else if (num2 > GameManagers.Instance.RandomManager.Float())
			{
				gDEProductData = GenerateAddOnProduct(Owner, new string[1] { ResultList.First().Key }, ProductFilter.Normal);
			}
			if (gDEProductData != null)
			{
				AddonDict.Add(gDEProductData.ItemId, gDEProductData.SingleNumber);
			}
		}
	}

	public static GDEProductData GenerateAddOnProduct(WorkShop building, string[] excludes, params ProductFilter[] filters)
	{
		List<GDEProductData> targetList = new List<GDEProductData>();
		int totalWeight = 0;
		foreach (KeyValuePair<string, int> productState in building.GetProductStates(!filters.Contains(ProductFilter.AddOn), filters))
		{
			if (!excludes.Contains(productState.Key) && productState.Value != 0 && BuildingManager.Products.TryGetValue(productState.Key, out var value))
			{
				targetList.Add(value);
				totalWeight += value.Weight;
			}
		}
		return (totalWeight > 0) ? GetProductionByWeight(ref targetList, ref totalWeight) : null;
	}

	public static GDEProductData GetProductionByWeight(ref List<GDEProductData> targetList, ref int totalWeight, bool extract = true)
	{
		GDEProductData result = null;
		int num = 0;
		int num2 = 0;
		int num3 = GameManagers.Instance.RandomManager.Int(0, totalWeight);
		int num4 = -1;
		for (int i = 0; i < targetList.Count; i++)
		{
			num2 += targetList[i].Weight;
			if (num3 >= num && num3 < num2)
			{
				num4 = i;
				result = targetList[i];
				break;
			}
			num = num2;
		}
		if (extract && num4 >= 0)
		{
			targetList.RemoveAt(num4);
			totalWeight -= num4;
		}
		return result;
	}

	private void OnDestroy()
	{
		((MonoBehaviour)this).StopAllCoroutines();
	}
}
