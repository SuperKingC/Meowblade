using System.Collections.Generic;
using System.Threading.Tasks;
using GameDataEditor;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class RecruitingCampDataManager : Manager
{
	private const int MaxSlotNum = 15;

	private Dictionary<int, string> _producingQueue = new Dictionary<int, string>();

	private List<string> _producingStringQueue = new List<string>();

	private readonly Dictionary<int, Dictionary<string, int>> _consumptionQueue = new Dictionary<int, Dictionary<string, int>>();

	public Dictionary<int, float> ProducingTime = new Dictionary<int, float>();

	public Dictionary<int, int> ProducingEndTime = new Dictionary<int, int>();

	public Dictionary<int, int> IsNowProducing = new Dictionary<int, int>();

	private readonly Dictionary<int, float> _productTime = new Dictionary<int, float>();

	public bool[] _canProduct = new bool[15];

	private int timerid;

	private static string[] buildingFilter = new string[1] { "BuildingType10" };

	public Dictionary<int, float> ProductTime => _productTime;

	public Dictionary<int, string> ProducingQueue
	{
		get
		{
			GetQueueData();
			return _producingQueue;
		}
		set
		{
			Dictionary<int, string> producingQueue = _producingQueue;
			_producingQueue = value;
			for (int i = 0; i < _producingQueue.Count; i++)
			{
				string text = producingQueue[i];
				string text2 = _producingQueue[i];
				if (text != text2)
				{
					Managers.UserArchiveManager.SetCampSoldier(i, text2);
					CancelProduceProgress(i);
				}
			}
			Managers.SoldierStuffIsReadyManager.UpdateProducingSoldierStates();
			GetTime();
			Managers.Messenger.Broadcast("RECRUITING_QUEUE_UPDATED");
		}
	}

	public RecruitingCampDataManager(GameManagers managers)
		: base(managers)
	{
	}

	public override Task Init()
	{
		GetQueueData();
		GetTime();
		for (int i = 0; i < _canProduct.Length; i++)
		{
			ProducingEndTime.Add(i, 0);
			_canProduct[i] = false;
			ProducingTime.Add(i, 0f);
			IsNowProducing.Add(i, -1);
			_consumptionQueue.Add(i, new Dictionary<string, int>());
		}
		return null;
	}

	public void InitWhenUIReady()
	{
		WaitTo_MakeOneRecruiting();
	}

	private void WaitTo_MakeOneRecruiting()
	{
		if (timerid <= 0)
		{
			timerid = ScriptApi.CreateTimer(1f, MakeOneRecruiting);
			return;
		}
		TimerEntity entityWithId = GameController.Contexts.timer.GetEntityWithId(timerid);
		if (entityWithId != null)
		{
			entityWithId.ReplaceRepeat(1);
			entityWithId.ReplaceDuration(0.5f);
			entityWithId.ReplaceElapsedTime(0f);
			entityWithId.ReplaceCallbackAction(MakeOneRecruiting);
		}
		else
		{
			timerid = ScriptApi.CreateTimer(1f, MakeOneRecruiting);
		}
	}

	public void TryMakeOneRecruiting_WhenFinish(int idx)
	{
		WaitTo_MakeOneRecruiting();
	}

	public async void MakeOneRecruiting()
	{
		if (Contexts.sharedInstance.Service<BaseSceneService>().GetEnableMainCityProduce())
		{
			GameManagers.Instance.StockController.NeedSyncProduce = true;
		}
	}

	public override void AddEventListener()
	{
	}

	public override void RemoveEventListener()
	{
	}

	public bool IsProducing(int pos)
	{
		return _canProduct[pos];
	}

	public float GetSetupTime(int pos)
	{
		return _productTime[pos];
	}

	public float GetRemainingTime(int pos)
	{
		return _productTime[pos] * (1f - ProducingTime[pos]);
	}

	private void GetTime()
	{
		float num = 1f + Managers.ModifierManager.GetPercentFloatPayload("ProductionEfficiency", new string[1] { "BuildingType10" });
		for (int i = 0; i < 15; i++)
		{
			float num2 = 0f;
			if (!string.IsNullOrEmpty(_producingQueue[i]) && _producingQueue[i] != "Unlock" && _producingQueue[i] != "Lock")
			{
				num2 = Singleton<SoldierProductManager>.Instance.GetSoldierProductData(_producingQueue[i]).Time;
			}
			_productTime[i] = num2 / num;
		}
	}

	private void GetQueueData()
	{
		_producingQueue.Clear();
		for (int i = 0; i < 15; i++)
		{
			string value = Managers.UserArchiveManager.GetCampSoldier(i);
			if (string.IsNullOrEmpty(value))
			{
				value = "Lock";
			}
			_producingQueue.Add(i, value);
		}
	}

	public void TryStartProduceSoldier(ProduceState _state, long ServerTm)
	{
		int produceStatus = _state.ProduceStatus;
		int workbenchIndex = _state.WorkbenchIndex;
		long num = _state.ProduceEndAt - ServerTm;
		ProducingTime[workbenchIndex] = 1f - 1f * (float)num / _productTime[workbenchIndex];
		ProducingEndTime[workbenchIndex] = (int)_state.ProduceEndAt;
		IsNowProducing[workbenchIndex] = produceStatus;
		switch (produceStatus)
		{
		case 0:
			CampController.Instance?.GetPortalSoldier(workbenchIndex)?.LoadSoldierInCamp(clear: true);
			break;
		case 1:
			CampController.Instance?.GetPortalSoldier(workbenchIndex)?.LoadSoldierInCamp();
			CampController.Instance?.GetPortalSoldier(workbenchIndex)?.Show_ProducingCountDown(ProducingEndTime[workbenchIndex], _productTime[workbenchIndex]);
			break;
		case 2:
		{
			string text = CampController.Instance?.GetPortalSoldier(workbenchIndex)?.SoldierId;
			if (!string.IsNullOrEmpty(text))
			{
				GameManagers.Instance.StockController.SetStock(text, _state.CurStock, StockInContext.CampSync);
			}
			CampController.Instance?.GetPortalSoldier(workbenchIndex)?.Show_StockFull();
			break;
		}
		case 3:
			CampController.Instance?.GetPortalSoldier(workbenchIndex)?.Show_LackResource();
			break;
		}
	}

	public bool IsSoldierProducible(string soldierId)
	{
		GDESoldierProductData soldierProductData = Singleton<SoldierProductManager>.Instance.GetSoldierProductData(soldierId);
		if (soldierProductData == null)
		{
			return false;
		}
		int stock = Managers.StockController.GetStock(soldierId);
		int limit = Managers.StockController.GetLimit(soldierId);
		if (stock >= limit)
		{
			return false;
		}
		if (soldierProductData.StuffNumber <= 0)
		{
			return true;
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		if (soldierProductData.Stuff1 != "null")
		{
			if (Managers.StockController.GetStock(soldierProductData.Stuff1) >= soldierProductData.Number1)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (soldierProductData.Stuff2 != "null")
		{
			if (Managers.StockController.GetStock(soldierProductData.Stuff2) >= soldierProductData.Number2)
			{
				flag2 = true;
			}
		}
		else
		{
			flag2 = true;
		}
		if (soldierProductData.Stuff3 != "null")
		{
			if (Managers.StockController.GetStock(soldierProductData.Stuff3) >= soldierProductData.Number3)
			{
				flag3 = true;
			}
		}
		else
		{
			flag3 = true;
		}
		if (soldierProductData.Stuff4 != "null")
		{
			if (Managers.StockController.GetStock(soldierProductData.Stuff4) >= soldierProductData.Number4)
			{
				flag4 = true;
			}
		}
		else
		{
			flag4 = true;
		}
		if (flag && flag2 && flag3 && flag4)
		{
			return true;
		}
		return false;
	}

	public void StartProduce(int pos, int status)
	{
	}

	public void ConsumeSoldierMaterials(int pos)
	{
		_consumptionQueue[pos].Clear();
	}

	public void Refund(int pos, bool needInform = true)
	{
		if (_consumptionQueue[pos].Count > 0)
		{
			if (needInform)
			{
				Managers.Messenger.Broadcast("INFORM_CAMP_REFUND", _consumptionQueue[pos]);
			}
			_consumptionQueue[pos].Clear();
		}
	}

	private void CancelProduceProgress(int index)
	{
		Refund(index);
		ProducingTime[index] = 0f;
		ProducingEndTime[index] = 0;
		_canProduct[index] = false;
	}

	public void IncrSoldierStock(string soldierId, int changed)
	{
		float num = 0f * (1f + Managers.ModifierManager.GetPercentFloatPayload("CloneSoldier", buildingFilter)) + Managers.ModifierManager.GetFixedFloatPayload("CloneSoldier", buildingFilter);
		if (num > Managers.RandomManager.Float())
		{
			Managers.StockController.IncrStock(soldierId, changed, StockInContext.ProduceAddon, "10");
		}
		Managers.StockController.IncrStock(soldierId, changed, StockInContext.Building, "10");
	}

	public bool IsAssembling(string soldierId)
	{
		foreach (string value in ProducingQueue.Values)
		{
			if (soldierId == value)
			{
				return true;
			}
		}
		return false;
	}

	public void OnServersideStockChange()
	{
		for (int i = 0; i < _canProduct.Length; i++)
		{
			string soldierId = _producingQueue[i];
			if (!IsSoldierMaterialsEnough(soldierId) && _canProduct[i] && _productTime[i] > 0f)
			{
				CancelProduceProgress(i);
			}
		}
	}

	private bool IsSoldierMaterialsEnough(string soldierId)
	{
		StockController stockController = Managers.StockController;
		GDESoldierProductData soldierProductData = Singleton<SoldierProductManager>.Instance.GetSoldierProductData(soldierId);
		if (soldierProductData == null)
		{
			return true;
		}
		if (soldierProductData.StuffNumber <= 0)
		{
			return true;
		}
		bool flag = true;
		bool flag2 = true;
		bool flag3 = true;
		bool flag4 = true;
		if (soldierProductData.Stuff1 != "null" && stockController.GetStock(soldierProductData.Stuff1) < 0)
		{
			flag = false;
		}
		if (soldierProductData.Stuff2 != "null" && stockController.GetStock(soldierProductData.Stuff2) < 0)
		{
			flag2 = false;
		}
		if (soldierProductData.Stuff3 != "null" && stockController.GetStock(soldierProductData.Stuff3) < 0)
		{
			flag3 = false;
		}
		if (soldierProductData.Stuff4 != "null" && stockController.GetStock(soldierProductData.Stuff4) < 0)
		{
			flag4 = false;
		}
		return flag && flag2 && flag3 && flag4;
	}
}
