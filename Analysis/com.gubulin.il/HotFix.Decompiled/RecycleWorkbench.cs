using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;
using UnityEngine;

public class RecycleWorkbench : MonoBehaviour
{
	public GameObject ProductIcon;

	public GameObject WorkbenchSliders;

	public GameObject WorkerFinishIcon;

	private MoltenCore _owner;

	public MoltenCoreWorkerController moltenCoreWorkerController;

	private float timeScale = 1f;

	private string proDuctIconName;

	public WorkerStatus WorkerStatus = WorkerStatus.Normal;

	public bool IsWaitingMaterial = false;

	public string WaitingMaterial;

	public bool IsWaitingStockSpace = false;

	public bool IsProducing = false;

	public bool IsInterrupted = false;

	public bool IsPaused = false;

	public float ProduceTime = 0f;

	private Tweener _produce;

	private List<string> productTaskList;

	public List<RecycleProduct> ProductList;

	public List<RecycleProduct> ResultList;

	public Dictionary<string, int> LatestConsumption = new Dictionary<string, int>();

	public Dictionary<string, int> LatestProductions = new Dictionary<string, int>();

	private int _productTotalWeight;

	private Coroutine _finishProduceCoroutine;

	private string[] buildingFilter;

	private Coroutine _Start_FinishProduce;

	private float _produce_tm = 0f;

	private TweenCallback _afterProduceCallback;

	public MoltenCore Owner
	{
		get
		{
			return _owner;
		}
		set
		{
			buildingFilter = new string[1] { "BuildingType" + value.BuildingType };
			_owner = value;
		}
	}

	public int WorkbenchIndex { get; set; }

	public List<string> ProductTaskList
	{
		get
		{
			return productTaskList;
		}
		set
		{
			if ((value != null || productTaskList != null) && (value == null || productTaskList == null || productTaskList.Count != value.Count || productTaskList.Count != productTaskList.Intersect(value).Count()))
			{
				if (IsProducing)
				{
					InterruptProduce();
				}
				_resetProductTaskList(value);
			}
		}
	}

	private void Awake()
	{
		ProduceTime = 0f;
		WorkerStatus = WorkerStatus.Normal;
		LatestConsumption = new Dictionary<string, int>();
		LatestProductions = new Dictionary<string, int>();
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
			ResultList = new List<RecycleProduct>();
		}
		else
		{
			ResultList.Clear();
		}
		RefundConsumptions();
		if (IsProducing)
		{
			FinishProduce(interrupted: true);
		}
		else
		{
			IsInterrupted = true;
		}
		if (_Start_FinishProduce != null)
		{
			((MonoBehaviour)this).StopCoroutine(_Start_FinishProduce);
		}
	}

	private async void _resetProductTaskList(List<string> value)
	{
		productTaskList = value;
		ResetProductTaskList(value);
	}

	private void ResetProductTaskList(List<string> value)
	{
		if (ProductList == null)
		{
			ProductList = new List<RecycleProduct>();
		}
		else
		{
			ProductList.Clear();
		}
		if (ResultList == null)
		{
			ResultList = new List<RecycleProduct>();
		}
		else
		{
			ResultList.Clear();
		}
		_productTotalWeight = 0;
		if (value != null)
		{
			foreach (RecycleProduct currentRecyclingProduct in GameManagers.Instance.RecycleManager.CurrentRecyclingProducts)
			{
				if (value.Contains(currentRecyclingProduct.RecycleProductId))
				{
					ProductList.Add(currentRecyclingProduct);
					_productTotalWeight += currentRecyclingProduct.Weight;
				}
			}
		}
		if (ProductList.Count > 0)
		{
			GenerateResultList(out var _);
			return;
		}
		productTaskList = null;
		Owner.GetProductionConfigAt(WorkbenchIndex).Workers = 0;
	}

	public int Produce()
	{
		if (!IsProducing && CanProduce())
		{
			IsWaitingMaterial = false;
			IsWaitingStockSpace = false;
			IsProducing = true;
			WaitingMaterial = null;
			RecycleProduct recycleProduct = ResultList.First();
			CalcProducingTime(recycleProduct.Time);
			ConsumeProduce();
			string key = recycleProduct.Productions.First().Key;
			int value = recycleProduct.Productions.First().Value;
			if (_Start_FinishProduce != null)
			{
				((MonoBehaviour)this).StopCoroutine(_Start_FinishProduce);
			}
			MoltenCoreWorkerController obj = moltenCoreWorkerController;
			if (obj != null)
			{
				((Component)obj).gameObject.SetActive(false);
			}
			_Start_FinishProduce = ((MonoBehaviour)this).StartCoroutine(Start_FinishProduce());
			return value;
		}
		return 0;
	}

	private IEnumerator Start_FinishProduce()
	{
		_produce_tm = 0f;
		long _end_tm = GameController.Instance.GetServerTime() + (long)ProduceTime;
		while (true)
		{
			_produce_tm += 1f;
			float left_tm = _end_tm - GameController.Instance.GetServerTime();
			if (left_tm <= 0f)
			{
				break;
			}
			yield return (object)new WaitForSeconds(1f);
		}
		FinishProduce();
	}

	public bool CanProduce()
	{
		if (IsProducing)
		{
			return false;
		}
		if (productTaskList == null || productTaskList.Count < 1)
		{
			return false;
		}
		if (ResultList.Count <= 0)
		{
			GenerateResultList(out var _);
		}
		if (ResultList.Count <= 0)
		{
			return false;
		}
		RecycleProduct recycleProduct = ResultList.First();
		if (recycleProduct.Requirements.Count < 1)
		{
			return true;
		}
		foreach (KeyValuePair<string, int> requirement in recycleProduct.Requirements)
		{
			if (GameManagers.Instance.StockController.GetStock(requirement.Key) < requirement.Value)
			{
				IsWaitingMaterial = true;
				WaitingMaterial = requirement.Key;
				return false;
			}
		}
		return true;
	}

	public void CanProduceForUpdateBubbleIcon(ref bool _IsWaitingStockSpace, ref bool _IsWaitingMaterial)
	{
		if (IsProducing || productTaskList == null || productTaskList.Count < 1)
		{
			return;
		}
		_IsWaitingStockSpace = false;
		_IsWaitingMaterial = false;
		if (ResultList.Count <= 0)
		{
			GenerateResultListForUpdateBubbleIcon(ref _IsWaitingStockSpace);
		}
		if (ResultList.Count <= 0)
		{
			return;
		}
		RecycleProduct recycleProduct = ResultList.First();
		if (recycleProduct.Requirements.Count < 1)
		{
			return;
		}
		foreach (KeyValuePair<string, int> requirement in recycleProduct.Requirements)
		{
			if (GameManagers.Instance.StockController.GetStock(requirement.Key) < requirement.Value)
			{
				_IsWaitingMaterial = true;
				break;
			}
		}
	}

	public void RefundConsumptions()
	{
		LatestConsumption.Clear();
	}

	public void ConsumeProduce()
	{
		LatestConsumption.Clear();
		if (ResultList.Count <= 0)
		{
			return;
		}
		RecycleProduct recycleProduct = ResultList.First();
		if (recycleProduct.Requirements.Count < 1)
		{
			return;
		}
		foreach (KeyValuePair<string, int> requirement in recycleProduct.Requirements)
		{
			LatestConsumption.Add(requirement.Key, requirement.Value);
		}
	}

	private void OnDestroy()
	{
		((MonoBehaviour)this).StopAllCoroutines();
	}

	private void FinishProduce(bool interrupted = false)
	{
		MoltenCoreWorkerController obj = moltenCoreWorkerController;
		if (obj != null)
		{
			((Component)obj).gameObject.SetActive(true);
		}
		IsProducing = false;
		ProduceTime = 0f;
		LatestProductions.Clear();
		if (ResultList.Count > 0)
		{
			foreach (RecycleProduct result in ResultList)
			{
				foreach (KeyValuePair<string, int> production in result.Productions)
				{
					LatestProductions.Add(production.Key, production.Value);
				}
			}
		}
		else
		{
			LatestConsumption.Clear();
		}
		if (ResultList.Count > 0)
		{
			GameManagers.Instance.StockController.NeedSyncProduce = true;
		}
		ProductIcon.GetComponent<SpriteRenderer>().sprite = null;
		ResultList.Clear();
		_finishProduceCoroutine = null;
		if (interrupted)
		{
			IsInterrupted = true;
		}
		moltenCoreWorkerController?.SetWorkerPathTweener();
	}

	public void SetWorkerStatus(WorkerStatus status)
	{
		MoltenCoreWorkerController componentInChildren = ((Component)this).GetComponentInChildren<MoltenCoreWorkerController>();
		if (!((Object)(object)componentInChildren == (Object)null) && componentInChildren.workerPathState == WorkerPathState.InProduction)
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
			componentInChildren.SetWorkerStatus(status);
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
			((Tween)produce).onComplete = (TweenCallback)Delegate.Combine((Delegate?)(object)((Tween)produce).onComplete, (Delegate?)new TweenCallback(FinishProduceCallback));
			if (_afterProduceCallback != null)
			{
				Tweener produce2 = _produce;
				((Tween)produce2).onComplete = (TweenCallback)Delegate.Combine((Delegate?)(object)((Tween)produce2).onComplete, (Delegate?)(object)_afterProduceCallback);
			}
			Tweener produce3 = _produce;
			((Tween)produce3).onComplete = (TweenCallback)Delegate.Combine((Delegate?)(object)((Tween)produce3).onComplete, (Delegate?)new TweenCallback(ClearProduceCompleteCallbacks));
		}
	}

	private void FinishProduceCallback()
	{
		FinishProduce();
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

	private void GenerateResultList(out List<RecycleProduct> cannotProdList)
	{
		cannotProdList = new List<RecycleProduct>();
		if (ResultList == null)
		{
			ResultList = new List<RecycleProduct>();
		}
		else
		{
			ResultList.Clear();
		}
		List<RecycleProduct> targetList = ListExtensions.DeepCopy<RecycleProduct>(ProductList);
		int totalWeight = _productTotalWeight;
		foreach (RecycleProduct item in targetList)
		{
			foreach (KeyValuePair<string, int> requirement in item.Requirements)
			{
				if (GameManagers.Instance.StockController.GetStock(requirement.Key) < requirement.Value)
				{
					cannotProdList.Add(item);
					WaitingMaterial = requirement.Key;
					break;
				}
			}
		}
		foreach (RecycleProduct cannotProd in cannotProdList)
		{
			totalWeight -= cannotProd.Weight;
			targetList.Remove(cannotProd);
		}
		if (targetList.Count <= 0)
		{
			IsWaitingMaterial = true;
			return;
		}
		if (targetList.Count == 1)
		{
			ResultList.Add(targetList.First());
			return;
		}
		RecycleProduct productionByWeight = GetProductionByWeight(ref targetList, ref totalWeight);
		if (productionByWeight != null)
		{
			ResultList.Add(productionByWeight);
		}
	}

	private void GenerateResultListForUpdateBubbleIcon(ref bool _IsWaitingStockSpace)
	{
		if (ResultList == null)
		{
			ResultList = new List<RecycleProduct>();
		}
		else
		{
			ResultList.Clear();
		}
		List<RecycleProduct> targetList = ListExtensions.DeepCopy<RecycleProduct>(ProductList);
		int totalWeight = _productTotalWeight;
		List<RecycleProduct> list = new List<RecycleProduct>();
		foreach (RecycleProduct item in targetList)
		{
			string key = item.Productions.First().Key;
			if (GameManagers.Instance.StockController.GetStock(key) >= GameManagers.Instance.StockController.GetLimit(key))
			{
				list.Add(item);
			}
		}
		foreach (RecycleProduct item2 in list)
		{
			totalWeight -= item2.Weight;
			targetList.Remove(item2);
		}
		if (targetList.Count <= 0)
		{
			_IsWaitingStockSpace = true;
			return;
		}
		if (targetList.Count == 1)
		{
			ResultList.Add(targetList.First());
			return;
		}
		RecycleProduct productionByWeight = GetProductionByWeight(ref targetList, ref totalWeight);
		if (productionByWeight != null)
		{
			ResultList.Add(productionByWeight);
		}
	}

	public static RecycleProduct GetProductionByWeight(ref List<RecycleProduct> targetList, ref int totalWeight, bool extract = true)
	{
		RecycleProduct result = null;
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

	public void OnStartProduce()
	{
	}

	public void RefreshProduceState(ProduceState state)
	{
		ProductTaskList = Owner.GetProductionConfigAt(WorkbenchIndex).ProductList;
	}
}
