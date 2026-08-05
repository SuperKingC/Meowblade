using System;
using DG.Tweening;
using FairyGUI;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;
using UI.GvG3SupplyDepot;
using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGCampFlagship.SupplyDepot;

public class FoodSupplyCallback
{
	private readonly UI_com_FoodSupply _uiComponent;

	private readonly string _shipId;

	private readonly C2S_GiveFoodDailySupplyToShip.Response _response;

	private Action _onComplete;

	private bool _flagShipProgressCompleted = false;

	private bool _shipProgressCompleted = false;

	private bool _isWaitingForProgress = true;

	public FoodSupplyCallback(UI_com_FoodSupply uiComponent, string shipId, C2S_GiveFoodDailySupplyToShip.Response response)
	{
		_uiComponent = uiComponent;
		_shipId = shipId;
		_response = response;
	}

	public void Execute(Action onComplete)
	{
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		if (((GObject)_uiComponent).isDisposed)
		{
			onComplete?.Invoke();
			return;
		}
		_onComplete = onComplete;
		UI_com_ShipFood uI_com_ShipFood = null;
		for (int i = 0; i < _uiComponent.Ships.Ships.numItems; i++)
		{
			if (((GComponent)_uiComponent.Ships.Ships).GetChildAt(i) is UI_com_ShipFood uI_com_ShipFood2 && !(((GObject)uI_com_ShipFood2.Increase).data.ToString() != _shipId))
			{
				uI_com_ShipFood = uI_com_ShipFood2;
				break;
			}
		}
		if (uI_com_ShipFood == null)
		{
			_uiComponent.UpdateUi(_response, _shipId);
			onComplete?.Invoke();
			return;
		}
		_uiComponent.TweenCount++;
		((GProgressBar)_uiComponent.Store.Food).TweenValue((double)_response.FlagShipCur / (double)_uiComponent.FlagShipMaxFood * 100.0, 0.3f).SetEase((EaseType)0).OnComplete((GTweenCallback)delegate
		{
			((GObject)_uiComponent.Store.Food.FoodNumber).text = $"{_response.FlagShipCur}/{_uiComponent.FlagShipMaxFood}";
			_flagShipProgressCompleted = true;
			CheckProgressCompletion();
		});
		GLoader flyAnim = _uiComponent.Ships.flyAnim;
		ShowFlyAnimations(uI_com_ShipFood, flyAnim);
		int num = Singleton<WorldStateManager>.Instance.Data.RealTimeFoodOnBoardModel.Base;
		((GProgressBar)uI_com_ShipFood.Food).TweenValue((double)_response.ShipCur / (double)num * 100.0, 0.5f).SetEase((EaseType)0).OnComplete((GTweenCallback)delegate
		{
			_uiComponent.TweenCount--;
			_uiComponent.UpdateUi(_response, _shipId);
			_shipProgressCompleted = true;
			CheckProgressCompletion();
		});
		((GObject)_uiComponent).TweenFade(1f, 1.5f).OnUpdate((GTweenCallback)delegate
		{
			((GObject)_uiComponent).InvalidateBatchingState();
		});
	}

	private void ShowFlyAnimations(UI_com_ShipFood foodBtn, GLoader flyAnim)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected O, but got Unknown
		for (int i = 0; i < 10; i++)
		{
			GLoader item = new GLoader();
			UI_com_effCoinFlash clip = UI_com_effCoinFlash.CreateInstance();
			((GComponent)_uiComponent.Ships).AddChild((GObject)(object)item);
			((GComponent)_uiComponent.Ships).AddChild((GObject)(object)clip);
			((GObject)item).width = ((GObject)flyAnim).width;
			((GObject)item).height = ((GObject)flyAnim).height;
			item.url = flyAnim.url;
			item.fill = flyAnim.fill;
			((GObject)clip).alpha = 0f;
			Vector2 val = ((GObject)_uiComponent.Ships).GlobalToLocal(((GObject)_uiComponent.Store).LocalToGlobal(Vector2.op_Implicit(((GObject)_uiComponent.Store.n8).position)));
			((GObject)item).position = Vector2.op_Implicit(val + ((GObject)item).size * 0.5f);
			((GObject)item).pivot = Vector2.one * 0.5f;
			((GObject)item).pivotAsAnchor = true;
			TweenCallback val3 = default(TweenCallback);
			EventCallback0 val6 = default(EventCallback0);
			((GObject)item).TweenMove(Vector2.op_Implicit(((GObject)item).position) + Random.insideUnitCircle * 100f, 0.33f).SetDelay(Random.Range(0f, 0.5f)).SetEase((EaseType)8)
				.OnComplete((GTweenCallback)delegate
				{
					//IL_001c: Unknown result type (might be due to invalid IL or missing references)
					//IL_0026: Unknown result type (might be due to invalid IL or missing references)
					//IL_002b: Unknown result type (might be due to invalid IL or missing references)
					//IL_0047: Unknown result type (might be due to invalid IL or missing references)
					//IL_006c: Unknown result type (might be due to invalid IL or missing references)
					//IL_0071: Unknown result type (might be due to invalid IL or missing references)
					//IL_0073: Expected O, but got Unknown
					//IL_0078: Expected O, but got Unknown
					if (!((GObject)_uiComponent).isDisposed)
					{
						Vector2 offset = Random.insideUnitCircle * 30f;
						Tween val2 = TweenSettingsExtensions.SetEase<Tween>(((GObject)(object)item).TweenToTarget((GObject)(object)foodBtn.Food.n16, offset, 0.66f), (Ease)8);
						TweenCallback obj = val3;
						if (obj == null)
						{
							TweenCallback val4 = delegate
							{
								//IL_0028: Unknown result type (might be due to invalid IL or missing references)
								//IL_007b: Unknown result type (might be due to invalid IL or missing references)
								//IL_0080: Unknown result type (might be due to invalid IL or missing references)
								//IL_0082: Expected O, but got Unknown
								//IL_0087: Expected O, but got Unknown
								if (!((GObject)_uiComponent).isDisposed)
								{
									((GObject)clip).position = ((GObject)item).position;
									((GObject)clip).alpha = 1f;
									clip.n0.SetPlaySettings(0, -1, 1, -1);
									EventListener onPlayEnd = clip.n0.onPlayEnd;
									EventCallback0 obj2 = val6;
									if (obj2 == null)
									{
										EventCallback0 val7 = delegate
										{
											((GObject)clip).Dispose();
										};
										EventCallback0 val8 = val7;
										val6 = val7;
										obj2 = val8;
									}
									onPlayEnd.Add(obj2);
									((GObject)item).Dispose();
								}
							};
							TweenCallback val5 = val4;
							val3 = val4;
							obj = val5;
						}
						TweenSettingsExtensions.OnComplete<Tween>(val2, obj);
					}
				});
		}
	}

	private void CheckProgressCompletion()
	{
		if (_isWaitingForProgress && _flagShipProgressCompleted && _shipProgressCompleted)
		{
			_isWaitingForProgress = false;
			_onComplete?.Invoke();
		}
	}
}
