using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.PublicResources;
using UnityEngine;

public class SkyPortalShipController : MonoBehaviour
{
	public UI_com_MiningShip UIRoot;

	private Queue<ProduceState> ProduceStateQueue;

	private HashSet<string> ProduceStateHashSet;

	private CoroutineQueue PopingCoroutineQueue;

	private void Awake()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		UIPanel val = ((Component)this).gameObject.AddComponent<UIPanel>();
		val.packageName = "PublicResources";
		val.componentName = "com_MiningShip";
		val.container.renderMode = (RenderMode)2;
		val.SetSortingOrder(4, true);
		val.sortingOrder = 4;
		val.CreateUI();
		((GObject)val.ui).xy = val.ui.GetCenterPos().Mul(-1f);
		((Component)this).transform.localScale = Vector3.one * 0.01f;
		UIRoot = (UI_com_MiningShip)(object)val.ui;
		ProduceStateQueue = new Queue<ProduceState>();
		ProduceStateHashSet = new HashSet<string>();
		PopingCoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)this);
	}

	private void OnDestroy()
	{
		UI_com_MiningShip uIRoot = UIRoot;
		if (uIRoot != null)
		{
			((GObject)uIRoot).Dispose();
		}
		PopingCoroutineQueue.Clear();
	}

	public void SetShipCollectingData(ShipCollectingModel data, int campId)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		ShipConfigModel byShipRaceType = ShipConfigHelper.GetByShipRaceType((int)data.ShipRace);
		string miningCompUrl = ShipConfigHelper.GetSkinById(byShipRaceType.DefaultSkinId).MiningCompUrl;
		((GObject)UIRoot.ShipLoader).asLoader.url = miningCompUrl;
		if (!UIRoot.FloatingTrans.playing)
		{
			float labelTime = UIRoot.FloatingTrans.GetLabelTime("End");
			float num = Random.Range(0f, labelTime);
			UIRoot.FloatingTrans.ignoreEngineTimeScale = false;
			UIRoot.FloatingTrans.Play(1, 0f, num, labelTime, (PlayCompleteCallback)delegate
			{
				UIRoot.FloatingTrans.SetAutoPlay(true, -1, 0f);
			});
		}
		foreach (ProduceState workersState in data.WorkersStates)
		{
			string item = $"{workersState.WorkbenchIndex}_{workersState.ProduceEndAt}";
			if (!ProduceStateHashSet.Contains(item))
			{
				ProduceStateHashSet.Add(item);
				ProduceStateQueue.Enqueue(workersState);
			}
		}
	}

	private void Update()
	{
		if (ProduceStateQueue.Count == 0)
		{
			return;
		}
		long num = (long)(GameController.Instance.GetServerRealtimeSeconds() * 1000.0) - 500;
		if (num < ProduceStateQueue.Peek().ProduceEndAt)
		{
			return;
		}
		ProduceState produceState = ProduceStateQueue.Dequeue();
		ProduceStateHashSet.Remove($"{produceState.WorkbenchIndex}_{produceState.ProduceEndAt}");
		if (produceState.CurProduceRecords != null)
		{
			StockChangeRecord[] curProduceRecords = produceState.CurProduceRecords;
			foreach (StockChangeRecord stockChangeRecord in curProduceRecords)
			{
				PopItem(stockChangeRecord.ItemId, stockChangeRecord.Offset);
			}
		}
	}

	private void PopItem(string itemId, int num)
	{
		PopingCoroutineQueue.AddCoroutine(PopCoroutine());
		IEnumerator PopCoroutine()
		{
			UI_com_ProductIconWithText com = UI_com_ProductIconWithText.CreateInstance_ILRuntime();
			string iconName = UiHelper.GetIconPath(itemId);
			string url = "ui://PublicResources/" + iconName;
			((GComponent)UIRoot).AddChild((GObject)(object)com);
			((GObject)com).xy = ((GComponent)(object)UIRoot).GetCenterPos().Add(new Vector2(Random.Range(-23f, 23f), Random.Range(-15f, 5f)));
			com.Icon.url = url;
			((GObject)com.Num).text = $"+{num}";
			com.DisAppear.SetHook("Finished", (TransitionHook)delegate
			{
				((GComponent)UIRoot).RemoveChild((GObject)(object)com, true);
			});
			com.DisAppear.Play();
			yield return (object)new WaitForSeconds(Random.Range(0.3f, 1.3f));
		}
	}
}
