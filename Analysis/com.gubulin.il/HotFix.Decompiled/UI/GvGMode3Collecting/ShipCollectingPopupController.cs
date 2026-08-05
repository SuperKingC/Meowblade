using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;
using Shift.Legion.ClientApi.Protocol.Building;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using UI.PublicResources;
using UnityEngine;

namespace UI.GvGMode3Collecting;

public class ShipCollectingPopupController
{
	public UI_main_GvGMode3CollectingPanel UIRoot;

	private Queue<ProduceState> ProduceStateQueue;

	private HashSet<string> ProduceStateHashSet;

	private CoroutineQueue PopingCoroutineQueue;

	private string ShipId;

	private readonly Action<PopItemIncrement> _onNumChange;

	public ShipCollectingPopupController(UI_main_GvGMode3CollectingPanel uiRoot, Action<PopItemIncrement> onNumChange = null)
	{
		UIRoot = uiRoot;
		ProduceStateQueue = new Queue<ProduceState>();
		ProduceStateHashSet = new HashSet<string>();
		PopingCoroutineQueue = new CoroutineQueue((MonoBehaviour)(object)FGUIManager.Instance);
		_onNumChange = onNumChange;
	}

	public void Reset()
	{
		ProduceStateQueue.Clear();
		ProduceStateHashSet.Clear();
		PopingCoroutineQueue.Clear();
	}

	public void SetShipCollectingData(ShipCollectingModel data)
	{
		ShipId = data.ShipId;
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

	public void Update()
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
				PopItem(stockChangeRecord.ItemId, stockChangeRecord.Offset, produceState.ProduceEndAt);
			}
		}
	}

	private void PopItem(string itemId, int num, long produceEndTime)
	{
		PopingCoroutineQueue.AddCoroutine(PopCoroutine());
		IEnumerator PopCoroutine()
		{
			if (!((GObject)UIRoot).isDisposed)
			{
				UI_com_ShipOverview shipSlot = null;
				GObject[] children = ((GComponent)UIRoot.ShipList).GetChildren();
				foreach (GObject _slot in children)
				{
					if (_slot.data.ToString() == ShipId)
					{
						shipSlot = (UI_com_ShipOverview)(object)_slot;
						break;
					}
				}
				if (shipSlot != null)
				{
					Vector2 popPos = ((GObject)UIRoot).RootToLocal(((GObject)shipSlot.CollectingPopLoader).LocalToRoot(Vector2.zero, GRoot.inst), GRoot.inst);
					popPos = popPos.Add(new Vector2(Random.Range(-23f, 23f), Random.Range(-15f, 5f)));
					if (!(popPos.y < ((GObject)UIRoot.ShipList).y) && !(((GObject)UIRoot.ShipList).y + ((GObject)UIRoot.ShipList).size.y < popPos.y))
					{
						UI_com_ProductIconWithText com = UI_com_ProductIconWithText.CreateInstance_ILRuntime();
						string iconName = UiHelper.GetIconPath(itemId);
						string url = "ui://PublicResources/" + iconName;
						((GComponent)UIRoot).AddChild((GObject)(object)com);
						((GObject)com).xy = popPos;
						((GObject)com).scale = Vector2.zero;
						com.Icon.url = url;
						((GObject)com.Num).text = $"+{num}";
						PopItemIncrement popItemChange = new PopItemIncrement(itemId, num, produceEndTime);
						GTweenCallback val = default(GTweenCallback);
						GTweenCallback val4 = default(GTweenCallback);
						((GObject)com).TweenScale(Vector2.one, 0.2f).SetEase((EaseType)5).OnComplete((GTweenCallback)delegate
						{
							//IL_001c: Unknown result type (might be due to invalid IL or missing references)
							//IL_0044: Unknown result type (might be due to invalid IL or missing references)
							//IL_0049: Unknown result type (might be due to invalid IL or missing references)
							//IL_004b: Expected O, but got Unknown
							//IL_0050: Expected O, but got Unknown
							GTweener obj = ((GObject)com).TweenMove(((GObject)UIRoot.CollectingPos).xy, 0.6f).SetEase((EaseType)14);
							GTweenCallback obj2 = val;
							if (obj2 == null)
							{
								GTweenCallback val2 = delegate
								{
									//IL_0007: Unknown result type (might be due to invalid IL or missing references)
									//IL_004a: Unknown result type (might be due to invalid IL or missing references)
									//IL_004f: Unknown result type (might be due to invalid IL or missing references)
									//IL_0051: Expected O, but got Unknown
									//IL_0056: Expected O, but got Unknown
									((GObject)com).TweenScale(Vector2.zero, 0.3f).SetEase((EaseType)5);
									GTweener obj3 = ((GObject)com).TweenFade(0f, 0.3f).SetEase((EaseType)5);
									GTweenCallback obj4 = val4;
									if (obj4 == null)
									{
										GTweenCallback val5 = delegate
										{
											if (!((GObject)UIRoot).isDisposed)
											{
												((GComponent)UIRoot).RemoveChild((GObject)(object)com, true);
											}
											_onNumChange?.Invoke(popItemChange);
										};
										GTweenCallback val6 = val5;
										val4 = val5;
										obj4 = val6;
									}
									obj3.OnComplete(obj4);
								};
								GTweenCallback val3 = val2;
								val = val2;
								obj2 = val3;
							}
							obj.OnComplete(obj2);
						});
						yield return (object)new WaitForSeconds(Random.Range(0.3f, 1.3f));
					}
				}
			}
		}
	}
}
