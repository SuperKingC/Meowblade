using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.LegendItem;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.Tips;
using UnityEngine;

namespace UI.FullScreenAnimation;

public class UI_FullScreenAnimationPanel : GComponent, IUiController
{
	public GGraph Mask;

	public GLoader GifLoader;

	public GGraph fullScreenSfxBack;

	public const string URL = "ui://huhayyi1h3uh0";

	public static string Name = "UI_FullScreenAnimationPanel";

	public const string ItemId = "ItemId";

	private string _displayItemId;

	private string uiTitleAnimName = "activated_fx";

	private CustomTaskCompletionSource<bool> callback = null;

	private bool isPlayNewbieMissionReward;

	private GLoader rewardLoader;

	private UI_SummaryMissionReward missionRewardIcon;

	private string rewardIcon;

	private string rewardTitleUrl;

	private string rewardNumText;

	private List<GameObject> SfxCache = new List<GameObject>();

	public static string GetURL()
	{
		return "ui://huhayyi1h3uh0";
	}

	public static UI_FullScreenAnimationPanel CreateInstance()
	{
		return (UI_FullScreenAnimationPanel)(object)UIPackage.CreateObject("FullScreenAnimation", "FullScreenAnimationPanel");
	}

	public static UI_FullScreenAnimationPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FullScreenAnimationPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://huhayyi1h3uh0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		GifLoader = (GLoader)((GComponent)this).GetChild("GifLoader");
		fullScreenSfxBack = (GGraph)((GComponent)this).GetChild("fullScreenSfxBack");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		ShowFullScreen(parameters);
	}

	public void OnShow()
	{
		if (callback != null)
		{
			SharedMessenger.Broadcast("CUSTOM_ACTION_FINISH", callback, arg2: false);
		}
		if (isPlayNewbieMissionReward)
		{
			ShowGetNewbieSummaryMissionRewardSfx();
		}
	}

	public void RegisterUiEventListeners()
	{
		SharedMessenger.AddListener<Level>("BATTLE_START", OnBattleStartEnd);
		SharedMessenger.AddListener<EventContext, string, int>("ON_SOLDIER_SELECTED", OnSoldierSelectEnd);
		SharedMessenger.AddListener<bool>("ON_SCOUT_BTN_CLICK", OnScoutBtnClickHide);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		SharedMessenger.RemoveListener<Level>("BATTLE_START", OnBattleStartEnd);
		SharedMessenger.RemoveListener<EventContext, string, int>("ON_SOLDIER_SELECTED", OnSoldierSelectEnd);
		SharedMessenger.RemoveListener<bool>("ON_SCOUT_BTN_CLICK", OnScoutBtnClickHide);
		if (isPlayNewbieMissionReward)
		{
			((GObject)Mask).onClick.Remove(new EventCallback0(End));
			((GObject)Mask).onClick.Remove(new EventCallback0(NewbieMissionRewardSfxDisposeCallback));
		}
	}

	private void ShowFullScreen(Dictionary<string, object> parameters)
	{
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected O, but got Unknown
		if (parameters == null)
		{
			return;
		}
		if (parameters.TryGetValue("GifUrl", out var _))
		{
			((GObject)GifLoader).visible = true;
			object obj = UiTagManager.Instance.FindObjectByTag("Battle.ArmyGroup1");
			object obj2 = UiTagManager.Instance.FindObjectByTag("Battle.ArmyGroup2");
			if (obj != null && obj2 != null)
			{
				GObject val = (GObject)((obj is GObject) ? obj : null);
				GObject val2 = (GObject)((obj2 is GObject) ? obj2 : null);
				((GObject)GifLoader).xy = val.xy;
				((GObject)GifLoader).TweenMove(val2.xy, 1f).SetRepeat(-1, false);
			}
		}
		if (parameters.TryGetValue("taskCompletionSource", out var value2))
		{
			callback = value2 as CustomTaskCompletionSource<bool>;
		}
		if (parameters.TryGetValue("PlayNewbieSummaryMissionTransition", out var value3))
		{
			isPlayNewbieMissionReward = (bool)value3;
			if (parameters.TryGetValue("RewardLoader", out var value4))
			{
				rewardLoader = (GLoader)value4;
			}
			if (parameters.TryGetValue("RewardIconUrl", out var value5) && value5 != null)
			{
				rewardIcon = value5.ToString();
			}
			if (parameters.TryGetValue("SummaryMissionRewardTitleIconUrl", out var value6) && value6 != null)
			{
				rewardTitleUrl = value6.ToString();
			}
			if (parameters.TryGetValue("RewardNumText", out var value7) && value7 != null)
			{
				rewardNumText = value7.ToString();
			}
			((GObject)Mask).onClick.Add(new EventCallback0(End));
			((GObject)Mask).onClick.Add(new EventCallback0(NewbieMissionRewardSfxDisposeCallback));
		}
		if (parameters.TryGetValue("ItemId", out var value8))
		{
			_displayItemId = value8 as string;
		}
	}

	public void ShowGetNewbieSummaryMissionRewardSfx()
	{
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		((GObject)Mask).touchable = false;
		((GObject)Mask).alpha = 0.6f;
		UI_SummaryMissionReward missionRewardIcon = UI_SummaryMissionReward.CreateInstance_ILRuntime();
		((GComponent)this).AddChild((GObject)(object)missionRewardIcon);
		((GObject)missionRewardIcon).SetScale(0.54f, 0.54f);
		((GObject)missionRewardIcon).SetPivot(0.5f, 0.5f, true);
		((GObject)missionRewardIcon).touchable = false;
		((GObject)missionRewardIcon).sortingOrder = 1000;
		missionRewardIcon.MissionIcon.url = "ui://NewbieMission/" + rewardIcon;
		missionRewardIcon.MissionTitle.url = "ui://FullScreenAnimation/" + rewardTitleUrl;
		((GObject)missionRewardIcon.RewardNum).text = rewardNumText;
		((GObject)missionRewardIcon.MissionTitle).alpha = 0f;
		((GObject)missionRewardIcon.MissionTitle).SetScale(0.25f, 0.25f);
		((GObject)missionRewardIcon.RewardNum).alpha = 0f;
		((GObject)missionRewardIcon.RewardNum).SetScale(0.25f, 0.25f);
		GameObject val = FGUIManager.Instance.AddTextSpecialEffects(fullScreenSfxBack, uiTitleAnimName, new Vector3(163f, 163f, 163f));
		if ((Object)(object)val != (Object)null)
		{
			SfxCache.Add(val);
		}
		Vector2 endPos = new Vector2(((GObject)this).width / 2f, ((GObject)this).height / 2f);
		Vector2 val2 = ((GObject)rewardLoader).LocalToGlobal(Vector2.zero);
		Vector2 val3 = ((GObject)this).GlobalToLocal(val2);
		((GObject)missionRewardIcon).SetXY(val3.x, val3.y);
		((GObject)fullScreenSfxBack).SetXY(val3.x, val3.y);
		((GObject)missionRewardIcon).AddRelation((GObject)(object)fullScreenSfxBack, (RelationType)3);
		((GObject)missionRewardIcon).AddRelation((GObject)(object)fullScreenSfxBack, (RelationType)10);
		GTweenCallback val4 = default(GTweenCallback);
		((GComponent)(object)this).SetTimeout(0.2f).OnComplete((GTweenCallback)delegate
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_003a: Expected O, but got Unknown
			GTweener obj = ((GObject)fullScreenSfxBack).TweenMove(endPos, 0.5f);
			GTweenCallback obj2 = val4;
			if (obj2 == null)
			{
				GTweenCallback val5 = delegate
				{
					//IL_0016: Unknown result type (might be due to invalid IL or missing references)
					//IL_0056: Unknown result type (might be due to invalid IL or missing references)
					((GObject)missionRewardIcon.MissionTitle).TweenScale(new Vector2(1f, 1f), 0.1f);
					((GObject)missionRewardIcon.MissionTitle).TweenFade(1f, 0.1f);
					((GObject)missionRewardIcon.RewardNum).TweenScale(new Vector2(1f, 1f), 0.1f);
					((GObject)missionRewardIcon.RewardNum).TweenFade(1f, 0.1f);
					((GObject)Mask).touchable = true;
					SharedMessenger.Broadcast("GET_NEW_GUIDE_MISSION_END");
					if (!string.IsNullOrEmpty(_displayItemId))
					{
						int num = Shift.Legion.Common.Models.Item.ItemType(_displayItemId);
						if (num == 11)
						{
							int stock = GameManagers.Instance.StockController.GetStock(_displayItemId);
							if (stock > 0)
							{
								UseItem(_displayItemId, stock);
							}
						}
					}
				};
				GTweenCallback val6 = val5;
				val4 = val5;
				obj2 = val6;
			}
			obj.OnComplete(obj2);
			((GObject)fullScreenSfxBack).TweenScale(new Vector2(2f, 2f), 0.5f);
			((GObject)missionRewardIcon).TweenScale(new Vector2(1f, 1f), 0.5f);
			UiAudioManager.Instance.PlaySoundEffect("Missile");
		});
	}

	private void UseItem(string itemId, int num)
	{
		ILRequestHelper<UseItemResponse>.Request((EventContext)null, (Func<Task<UseItemResponse>>)(() => GameController.Contexts.Service<INetworkService>().UseItem(-1L, itemId, num, null)), (Action<UseItemResponse>)delegate(UseItemResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				End();
				List<Bonus> result_bonusList = new List<Bonus>();
				if (response.Bonuses != null)
				{
					foreach (ModelsBonus bonuse in response.Bonuses)
					{
						result_bonusList.Add(Bonus.Get(bonuse.ItemId, bonuse.Qty, bonuse.Type, bonuse.IsShining));
					}
				}
				if (response.StockChangeRecords != null)
				{
					bool flag = false;
					string text = "";
					if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 11 || Shift.Legion.Common.Models.Item.ItemType(itemId) == 29)
					{
						foreach (Bonus item in result_bonusList)
						{
							if (item.ItemId.IndexOf("Unlock.") >= 0)
							{
								string text2 = item.ItemId.Replace("Unlock.", "");
								if (SchemaIndexHelper.GetSchemaById(text2) == "Soldier")
								{
									text = text2;
									flag = true;
								}
							}
							else if (item.ItemId.StartsWith("PotentialLevel."))
							{
								string text3 = item.ItemId.Replace("PotentialLevel.", "");
								if (SchemaIndexHelper.GetSchemaById(text3) == "Soldier")
								{
									text = text3;
									flag = true;
								}
							}
						}
					}
					if (flag)
					{
						for (int num2 = response.StockChangeRecords.Count - 1; num2 >= 0; num2--)
						{
							if (response.StockChangeRecords[num2].Offset > 0 && response.StockChangeRecords[num2].ItemId == text)
							{
								response.StockChangeRecords.RemoveAt(num2);
								break;
							}
							if (response.StockChangeRecords[num2].Offset > 0 && response.StockChangeRecords[num2].Context == 11 && response.StockChangeRecords[num2].ContextValue.IndexOf(text) >= 0)
							{
								response.StockChangeRecords.RemoveAt(num2);
								break;
							}
						}
					}
					GameManagers.Instance.StockController.ReadStockChangeRecords(response.StockChangeRecords);
				}
				if (response.TimeMachineSeconds > 0)
				{
					if (response.Bonuses != null)
					{
						List<Bonus> list = new List<Bonus>();
						foreach (ModelsBonus bonuse2 in response.Bonuses)
						{
							if (Shift.Legion.Common.Models.Item.ItemType(itemId) != 63 || !(bonuse2.ItemId != "Money"))
							{
								list.Add(Bonus.Get(bonuse2.ItemId, bonuse2.Qty, bonuse2.Type, bonuse2.IsShining));
							}
						}
						SharedMessenger.Broadcast("TIME_MACHINE_LAUNCHED", response.TimeMachineSeconds, list);
					}
					else
					{
						ILRequestHelper.ShowErrorCode(82000002);
					}
				}
				if (response.LegendItems != null)
				{
					List<LegendItemUi> list2 = new List<LegendItemUi>();
					List<string> list3 = new List<string>();
					for (int i = 0; i < response.LegendItems.Count; i++)
					{
						ModelsBonus modelsBonus = response.LegendItems[i];
						Bonus bonus = Bonus.Get(modelsBonus.ItemId, modelsBonus.Qty, modelsBonus.Type, modelsBonus.IsShining, modelsBonus.ExtraData);
						Dictionary<string, float> dict = bonus.Claim(GameManagers.Instance);
						long key = long.Parse(dict.First().Key);
						LegendItem legendItem = GameManagers.Instance.InventoryManager.LegendItems[key];
						LegendItemUi legendItemUi = new LegendItemUi(legendItem.InstanceId, legendItem);
						LegendItemsHelper.UpdateLegendItems(legendItemUi);
						list2.Add(legendItemUi);
						list3.Add(legendItemUi.LegendItemData.ItemId);
					}
					Dictionary<string, object> parameters = new Dictionary<string, object>
					{
						{ "LegendItems", list2 },
						{
							"SortingOrder",
							((GObject)this).sortingOrder
						},
						{ "ItemId", itemId }
					};
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_LegendItemBoxPanel.Name, parameters);
					ThinkingDataHelper.Instance.OpenLegendItemBox(itemId, num, list3);
				}
				if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 13)
				{
					GameController.Contexts.Service<IUiService>().OpenPanel(UI_ChoosePendingLottery.Name, null);
				}
				if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 11 || Shift.Legion.Common.Models.Item.ItemType(itemId) == 29)
				{
					ShowChestResult();
				}
				else
				{
					if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 15 || Shift.Legion.Common.Models.Item.ItemType(itemId) == 30)
					{
						foreach (Bonus item2 in result_bonusList)
						{
							if (item2.ItemId.IndexOf("Unlock.") >= 0)
							{
								string itemId2 = item2.ItemId.Replace("Unlock.", "");
								Bonus bonus2 = Bonus.Get(itemId2, new List<int> { 1, item2.Qty }, 2);
								bonus2.Claim(GameManagers.Instance, null, null, forceClaim: true, broadcastInform: true, _isChangeStock: false);
							}
							else if (item2.ItemId.IndexOf("PotentialLevel.") >= 0)
							{
								CommandFactory.CreateTakeItemsCommand(new List<Bonus> { item2 });
							}
						}
						return;
					}
					if (Shift.Legion.Common.Models.Item.ItemType(itemId) == 22 || Shift.Legion.Common.Models.Item.ItemType(itemId) == 23 || Shift.Legion.Common.Models.Item.ItemType(itemId) == 24 || Shift.Legion.Common.Models.Item.ItemType(itemId) == 25 || Shift.Legion.Common.Models.Item.ItemType(itemId) == 26)
					{
						foreach (Bonus item3 in result_bonusList)
						{
							item3.Claim(GameManagers.Instance);
						}
					}
				}
			}
		});
		void ShowChestResult()
		{
			if (string.IsNullOrEmpty(P_0.response.NewBlueprints))
			{
				GameManagers.Instance.Messenger.Broadcast("CHEST_CLAIMED", itemId, P_0.result_bonusList, P_0.response.ClaimedContent);
			}
			else
			{
				List<string> list = JsonHelper.ToObject<List<string>>(P_0.response.NewBlueprints);
				if (list.Count <= 0)
				{
					GameManagers.Instance.Messenger.Broadcast("CHEST_CLAIMED", itemId, P_0.result_bonusList, P_0.response.ClaimedContent);
				}
				else
				{
					LegendItemsHelper.OpenBlueprintsBoxResult(JsonHelper.ToObject<List<string>>(P_0.response.NewBlueprints), itemId);
				}
			}
		}
	}

	private void NewbieMissionRewardSfxDisposeCallback()
	{
		SpawnManager.Instance.UnloadAnimation(uiTitleAnimName);
		((GComponent)this).RemoveChild((GObject)(object)missionRewardIcon, true);
		foreach (GameObject item in SfxCache)
		{
			SpawnManager.Instance.Destroy(item);
		}
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
	}

	private void OnBattleStartEnd(Level level)
	{
		End();
	}

	private void OnSoldierSelectEnd(EventContext eventContext, string soldierId, int chosenType)
	{
		End();
	}

	private void OnScoutBtnClickHide(bool showGifLoader)
	{
		((GObject)GifLoader).visible = showGifLoader;
	}
}
