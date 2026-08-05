using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using GameDataEditor;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.Store;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;
using UI.AddCredit;
using UI.GiftBag;
using UnityEngine;

namespace HotFix.Sources.Base.Scripts.Managers;

public class EventManager : MonoBehaviour
{
	private void Awake()
	{
		SharedMessenger.AddListener<User>("NEW_USER_REGISTERED", OnNewUserRegistered);
		SharedMessenger.AddListener("NEW_DAY_LOGIN", OnNewDayLogin);
		SharedMessenger.AddListener<int>("USER_LEVEL_UP", OnUserLevelUp);
		SharedMessenger.AddListener<string, Level, Team, bool>("LEVEL_COMPLETED", OnLevelCompleted);
		SharedMessenger.AddListener<string>("ENTER_STORY_MAIN_LEVEL", OnEnterLevel);
		SharedMessenger.AddListener<Level>("BATTLE_START", OnBattleStart);
		SharedMessenger.AddListener<string>("ACHIEVEMENT_BONUS_CLAIMED", OnAchievementClaimed);
		SharedMessenger.AddListener<string, Dictionary<string, object>>("OPEN_UI", OnUIPanelOpened);
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
		SharedMessenger.RemoveListener<User>("NEW_USER_REGISTERED", OnNewUserRegistered);
		SharedMessenger.RemoveListener("NEW_DAY_LOGIN", OnNewDayLogin);
		SharedMessenger.RemoveListener<int>("USER_LEVEL_UP", OnUserLevelUp);
		SharedMessenger.RemoveListener<string, Level, Team, bool>("LEVEL_COMPLETED", OnLevelCompleted);
		SharedMessenger.RemoveListener<string>("ENTER_STORY_MAIN_LEVEL", OnEnterLevel);
		SharedMessenger.RemoveListener<Level>("BATTLE_START", OnBattleStart);
		SharedMessenger.RemoveListener<string>("ACHIEVEMENT_BONUS_CLAIMED", OnAchievementClaimed);
		SharedMessenger.RemoveListener<string, Dictionary<string, object>>("OPEN_UI", OnUIPanelOpened);
	}

	private void OnNewUserRegistered(User user)
	{
		LogEventOnFacebook(EventType.registration);
		LogStandardEventOnFacebook(StandardEvent.fb_mobile_complete_registration, new EventParams
		{
			RegistrationMethod = user.LastLoginType
		});
		LogStandardEventOnGoogle(EventOnGoogle.sign_up, new ParamOnGoogle
		{
			Method = user.LastLoginType
		});
	}

	private void OnNewDayLogin()
	{
		LogEventOnFacebook(EventType.login);
		LogStandardEventOnGoogle(EventOnGoogle.login, new ParamOnGoogle
		{
			Method = UiHelper.LoginTypeStr
		});
	}

	private void OnUserLevelUp(int newLevel)
	{
		if (newLevel == 3)
		{
			LogEventOnFacebook(EventType.darklordlevel_3);
		}
		if (newLevel == 5)
		{
			LogEventOnFacebook(EventType.darklordlevel_5);
		}
		LogStandardEventOnGoogle(EventOnGoogle.level_up, new ParamOnGoogle
		{
			Level = newLevel,
			Character = GameController.Contexts.gameState.user.value.UserId.ToString()
		});
	}

	private void OnLevelCompleted(string battleId, Level level, Team winner, bool newCompleteFlag)
	{
		if (winner != Team.Blue)
		{
			if (level.LevelId == "P110")
			{
				LogEventOnFacebook(EventType.clear_p110);
				LogStandardEventOnGoogle(EventOnGoogle.tutorial_complete, new ParamOnGoogle());
			}
			if (level.LevelId == "P120")
			{
				LogEventOnFacebook(EventType.clear_p120);
			}
			if (level.LevelId == "P210")
			{
				LogStandardEventOnFacebook(StandardEvent.fb_mobile_tutorial_completion, new EventParams
				{
					Level = GameManagers.Instance.UserArchiveManager.GetUserLevel().ToString()
				});
			}
			LogStandardEventOnGoogle(EventOnGoogle.level_end, new ParamOnGoogle
			{
				LevelName = level.LevelId,
				Success = true
			});
		}
	}

	private void OnEnterLevel(string levelId)
	{
		if (levelId == "P101")
		{
			LogStandardEventOnGoogle(EventOnGoogle.tutorial_begin, new ParamOnGoogle());
		}
	}

	private void OnBattleStart(Level level)
	{
		LogStandardEventOnGoogle(EventOnGoogle.level_start, new ParamOnGoogle
		{
			LevelName = level.LevelId
		});
	}

	private void OnAchievementClaimed(string achievementId)
	{
		LogStandardEventOnGoogle(EventOnGoogle.unlock_achievement, new ParamOnGoogle
		{
			AchievementId = achievementId
		});
	}

	private void OnUIPanelOpened(string uiName, Dictionary<string, object> withParameters)
	{
		if (!(uiName == UI_GiftBagPanel.Name) && !(uiName == UI_BlackMarketerAddCredit.Name))
		{
		}
	}

	public static void LogPlaceOrder(Order orderInfo, int numItems, float paidTotal)
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			float num = paidTotal / 100f;
			LogStandardEventOnFacebook(StandardEvent.fb_mobile_initiated_checkout, new EventParams
			{
				ContentType = "product",
				ContentId = orderInfo.StoreItemId,
				NumItems = numItems,
				Currency = "USD",
				OrderId = orderInfo.OrderId.ToString(),
				ValueToSum = num
			});
			LogStandardEventOnGoogle(EventOnGoogle.begin_checkout, new ParamOnGoogle
			{
				Currency = "USD",
				Value = num,
				Items = new ItemOnGoogle[1]
				{
					new ItemOnGoogle
					{
						ItemId = orderInfo.StoreItemId,
						Price = num,
						Quantity = numItems
					}
				}
			});
		}
	}

	public static void LogPurchase(Order orderInfo, int numItems, float paidTotal)
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			float num = paidTotal / 100f;
			LogStandardEventOnFacebook(StandardEvent.fb_mobile_purchase, new EventParams
			{
				ContentType = "product",
				ContentId = orderInfo.StoreItemId,
				NumItems = numItems,
				Currency = "USD",
				ValueToSum = num,
				OrderId = orderInfo.OrderId.ToString()
			});
			LogStandardEventOnGoogle(EventOnGoogle.purchase, new ParamOnGoogle
			{
				TransactionId = orderInfo.TransactionId,
				Currency = "USD",
				Value = num,
				Items = new ItemOnGoogle[1]
				{
					new ItemOnGoogle
					{
						ItemId = orderInfo.StoreItemId,
						Price = num,
						Quantity = numItems
					}
				}
			});
		}
	}

	public static void LogStandardEventOnFacebook(StandardEvent standardEvent, EventParams eventParams)
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Invalid comparison between Unknown and I4
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Invalid comparison between Unknown and I4
		if (!HotUpdateProcess.Instance.IsRegionOutCN || HotUpdateProcess.Instance.ChannelConfig == null || HotUpdateProcess.Instance.ChannelConfig.dataCollection == null)
		{
			return;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("EventName", standardEvent.ToString());
		dictionary.Add("EventParams", JsonHelper.ToJson(eventParams));
		foreach (Intl_SDKInfo item in HotUpdateProcess.Instance.ChannelConfig.dataCollection)
		{
			if (!item.sdkCode.Equals("FacebookADSDK"))
			{
				continue;
			}
			if ((int)Application.platform == 8)
			{
				SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].FacebookLogStandardEvent(JsonHelper.ToJson(dictionary));
				break;
			}
			if ((int)Application.platform == 11)
			{
				switch (standardEvent)
				{
				case StandardEvent.fb_mobile_initiated_checkout:
					((FacebookSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.FacebookSDK]).LogInitialCheckout(JsonHelper.ToJson(dictionary));
					break;
				case StandardEvent.fb_mobile_purchase:
					((FacebookSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.FacebookSDK]).LogPurchase(JsonHelper.ToJson(dictionary));
					break;
				default:
					((FacebookSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.FacebookSDK]).LogStandardEvent(JsonHelper.ToJson(dictionary));
					break;
				}
				break;
			}
		}
	}

	public static void LogStandardEventOnGoogle(EventOnGoogle eventName, ParamOnGoogle param)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Invalid comparison between Unknown and I4
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Invalid comparison between Unknown and I4
		if (!HotUpdateProcess.Instance.IsRegionOutCN || HotUpdateProcess.Instance.ChannelConfig == null || HotUpdateProcess.Instance.ChannelConfig.dataCollection == null)
		{
			return;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("EventName", eventName.ToString());
		dictionary.Add("EventParams", JsonHelper.ToJson(param));
		foreach (Intl_SDKInfo item in HotUpdateProcess.Instance.ChannelConfig.dataCollection)
		{
			if (item.sdkCode.Equals("GoogleADSDK"))
			{
				if ((int)Application.platform == 8)
				{
					break;
				}
				if ((int)Application.platform == 11)
				{
					((GoogleSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.GoogleSDK]).LogStandardEvent(JsonHelper.ToJson(dictionary));
				}
			}
		}
	}

	public static void LogEventOnFacebook(EventType eventType)
	{
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Invalid comparison between Unknown and I4
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Invalid comparison between Unknown and I4
		if (!HotUpdateProcess.Instance.IsRegionOutCN || HotUpdateProcess.Instance.ChannelConfig == null || HotUpdateProcess.Instance.ChannelConfig.dataCollection == null)
		{
			return;
		}
		foreach (Intl_SDKInfo item in HotUpdateProcess.Instance.ChannelConfig.dataCollection)
		{
			if (item.sdkCode.Equals("FacebookADSDK"))
			{
				if ((int)Application.platform == 8)
				{
					SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].FacebookLogEvent(eventType.ToString());
					break;
				}
				if ((int)Application.platform == 11)
				{
					((FacebookSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.FacebookSDK]).LogEvent(eventType.ToString());
					break;
				}
			}
		}
	}

	public static void LogEventOnGoogle(EventOnGoogle eventType)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Invalid comparison between Unknown and I4
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Invalid comparison between Unknown and I4
		if (!HotUpdateProcess.Instance.IsRegionOutCN || HotUpdateProcess.Instance.ChannelConfig == null || HotUpdateProcess.Instance.ChannelConfig.dataCollection == null)
		{
			return;
		}
		foreach (Intl_SDKInfo item in HotUpdateProcess.Instance.ChannelConfig.dataCollection)
		{
			if (item.sdkCode.Equals("GoogleADSDK"))
			{
				if ((int)Application.platform == 8)
				{
					break;
				}
				if ((int)Application.platform == 11)
				{
					((GoogleSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.GoogleSDK]).LogEvent(eventType.ToString());
					break;
				}
			}
		}
	}

	public static void LogEventOnFacebook(EventType eventType, Dictionary<string, string> param)
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Invalid comparison between Unknown and I4
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Invalid comparison between Unknown and I4
		if (!HotUpdateProcess.Instance.IsRegionOutCN || HotUpdateProcess.Instance.ChannelConfig == null || HotUpdateProcess.Instance.ChannelConfig.dataCollection == null)
		{
			return;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("EventName", eventType.ToString());
		dictionary.Add("EventParams", JsonHelper.ToJson(param));
		foreach (Intl_SDKInfo item in HotUpdateProcess.Instance.ChannelConfig.dataCollection)
		{
			if (item.sdkCode.Equals("FacebookADSDK"))
			{
				if ((int)Application.platform == 8)
				{
					SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].FacebookLogEventAndParams(JsonHelper.ToJson(dictionary));
					break;
				}
				if ((int)Application.platform == 11)
				{
					((FacebookSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.FacebookSDK]).LogEventAndParams(JsonHelper.ToJson(dictionary));
					break;
				}
			}
		}
	}

	public static void LogSpecificStoreItemsForFacebook(string storeItemId)
	{
		if (!HotUpdateProcess.Instance.IsRegionOutCN)
		{
			return;
		}
		if (!(storeItemId == "MonthPack1"))
		{
			if (storeItemId == "MonthPack2")
			{
				LogEventOnFacebook(EventType.monthpack_big);
				return;
			}
			GDEStoreContentConfigData gDEStoreContentConfigData = GDMgr.Get<GDEStoreContentConfigData>(storeItemId);
			if (!string.IsNullOrEmpty(gDEStoreContentConfigData.InternationalPrice))
			{
				List<Dictionary<string, int>> source = JsonHelper.ToObject<List<Dictionary<string, int>>>(gDEStoreContentConfigData.InternationalPrice);
				if (source.Any((Dictionary<string, int> price) => price.TryGetValue("USD", out var value) && value == 99))
				{
					LogEventOnFacebook(EventType.purchase_minimum);
				}
			}
		}
		else
		{
			LogEventOnFacebook(EventType.monthpack_small);
		}
	}

	public static void SetUserId(string userId)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		if (HotUpdateProcess.Instance.IsRegionOutCN && (int)Application.platform != 8 && (int)Application.platform == 11)
		{
			((GoogleSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.GoogleSDK]).SetUserId(userId);
		}
	}

	public static void SetUserProperty(string property)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		if ((int)Application.platform != 8 && (int)Application.platform == 11)
		{
			((GoogleSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.GoogleSDK]).SetUserProperty(property);
		}
	}
}
