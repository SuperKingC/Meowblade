using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.UI;
using GameDataEditor;
using HotFix;
using HotFix.Sources.Base.Scripts.Managers;
using HotFix.Sources.Base.Scripts.UI;
using HotFix.Sources.ThirdParty.SDKs.Android;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;
using Shift.Legion.Helpers;
using UnityEngine;

public class ThinkingDataHelper : MonoBehaviour
{
	public static ThinkingDataHelper Instance;

	private bool _trackEnabled;

	public const string RMB = "RMB";

	public const string USD = "USD";

	public bool IsNewUser { get; set; }

	public int GetLegendItemFromBlackMarketStats()
	{
		Dictionary<string, int> value = GameManagers.Instance.AchievementManager.LegendItemFromBlackMarketStats.GetValue();
		return value.Sum((KeyValuePair<string, int> pair) => pair.Value);
	}

	private void Awake()
	{
		Instance = this;
		_trackEnabled = false;
	}

	public void SetDynamicSuperProperties()
	{
		if (_trackEnabled)
		{
		}
	}

	public void SetSuperProperties(User user)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Invalid comparison between Unknown and I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Invalid comparison between Unknown and I4
		string value = "";
		if (((int)Application.platform == 8 || (int)Application.platform == 1) && !string.IsNullOrWhiteSpace(HotUpdateProcess.UserSource))
		{
			value = HotUpdateProcess.UserSource;
		}
		if ((int)Application.platform == 11 || (int)Application.platform == 2)
		{
			value = HotUpdateProcess.ChannelCode;
		}
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{
				"channel",
				GameController.UserAgent
			},
			{ "server_id", user.ServerName },
			{ "channelcode", value }
		};
		SetSuperProperties(superProperties);
	}

	public void UpdateLevel(int _level)
	{
		Track("player_levelup");
		UserSet(new Dictionary<string, object> { 
		{
			"level",
			GameManagers.Instance.UserArchiveManager.GetUserLevel()
		} });
	}

	public void UpdateCurCompleteLevelId(string battleId, Level level, Team winner, bool newCompleteFlag)
	{
		if (level.Chapter.Type == ChapterType.StoryMain)
		{
			switch (winner)
			{
			case Team.Red:
				UserSet(new Dictionary<string, object> { { "mainline_id", level.LevelId } });
				break;
			case Team.Blue:
				Track("mainline_failed");
				break;
			}
		}
		else if (level.Chapter.Type == ChapterType.RepeatableInstance)
		{
			switch (winner)
			{
			case Team.Red:
				SoulCompletedTrack(level.ChapterId, level.LevelId);
				break;
			case Team.Blue:
				SoulFailedTrack(level.ChapterId, level.LevelId);
				break;
			}
		}
		else if (level.Chapter.Type == ChapterType.RepeatableInstanceDefensive)
		{
			if (winner == Team.Blue)
			{
				DefendFailedTrack(level.ChapterId, level.LevelId.Last().ToString());
			}
		}
		else if (level.Chapter.Type != ChapterType.RepeatableInstanceOffensive && level.Chapter.Type == ChapterType.TreasureHunt)
		{
			if (winner == Team.Blue)
			{
				LegendItemLevelFailedTrack(level.LevelId);
			}
			else
			{
				LegendItemLevelCompletedTrack(level.LevelId);
			}
		}
	}

	public void TrackTapTapInitBegin()
	{
		Track("taptap_init_begin");
	}

	public void TrackTapTapInitFinish()
	{
		Track("taptap_init_finish");
	}

	public void SetUserBirthdayOnce(DateTime userBirthday)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object> { { "birthday", userBirthday } };
		UserSetOnce(superProperties);
	}

	public void SetUserDataOnce(User user)
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Invalid comparison between Unknown and I4
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Invalid comparison between Unknown and I4
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Invalid comparison between Unknown and I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Invalid comparison between Unknown and I4
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			{
				"channel",
				GameController.UserAgent
			},
			{ "server_id", user.ServerName },
			{ "account_id", user.UserId },
			{
				"create_time",
				DateTimeHelper.ParseTimeStamp((int)GameController.Instance.GetServerTime()).LocalDateTime
			},
			{ "level", 0 }
		};
		if (((int)Application.platform == 8 || (int)Application.platform == 1) && !string.IsNullOrWhiteSpace(HotUpdateProcess.UserSource))
		{
			dictionary.Add("channelcode", HotUpdateProcess.UserSource);
		}
		if ((int)Application.platform == 11 || (int)Application.platform == 2)
		{
			dictionary.Add("channelcode", HotUpdateProcess.ChannelCode);
		}
		UserSetOnce(dictionary);
		SetSuperProperties(user);
	}

	public void UserLoginTrack()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Invalid comparison between Unknown and I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Invalid comparison between Unknown and I4
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Invalid comparison between Unknown and I4
		if (_trackEnabled)
		{
			if (!IsNewUser)
			{
				Login(GameController.Contexts.gameState.user.value.UserId.ToString());
			}
			if (((int)Application.platform == 8 || (int)Application.platform == 1) && !string.IsNullOrWhiteSpace(HotUpdateProcess.UserSource))
			{
				UserSetOnce(new Dictionary<string, object> { 
				{
					"channelcode",
					HotUpdateProcess.UserSource
				} });
			}
			if ((int)Application.platform == 11 || (int)Application.platform == 2)
			{
				UserSetOnce(new Dictionary<string, object> { 
				{
					"channelcode",
					HotUpdateProcess.ChannelCode
				} });
			}
			SetSuperProperties(GameController.Contexts.gameState.user.value);
			Track("player_login");
			UserSet(new Dictionary<string, object> { 
			{
				"last_login_time",
				DateTime.Now
			} });
			GatewayRecord();
			Flush();
		}
	}

	public void UserEnterGameTrack()
	{
		SetDynamicSuperProperties();
		Track("player_enter");
		UserSet(new Dictionary<string, object>
		{
			{
				"diamond_hold",
				GameManagers.Instance.StockController.GetStock("Gem")
			},
			{
				"gold_hold",
				GameManagers.Instance.StockController.GetStock("Money")
			},
			{
				"card_hold",
				GameManagers.Instance.StockController.GetOwnedSoldiers(onlyUnlocked: true).Count
			},
			{
				"farmer_hold",
				Dungeon.GetTotalManPower(GameManagers.Instance)
			}
		});
	}

	public void SetLoginType(string loginType)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object> { { "login_type", loginType } };
		UserSet(superProperties);
	}

	public void OrderFinishedTrack(int orderId, string itemId, string currencyId, float payAmount, string payMethod)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			{ "order_id", orderId },
			{ "pay_item_id", itemId },
			{ "pay_currency_id", currencyId },
			{ "pay_amount", payAmount },
			{ "order_finished", payMethod }
		};
		if (itemId.Contains("PVP"))
		{
			dictionary.Add("season_id", RankDataHelper.PvpRankProgress.Id);
			dictionary.Add("turn_id", RankDataHelper.PvpRankProgress.TurnId);
		}
		Track("order_finished", dictionary);
		UserSet(new Dictionary<string, object>
		{
			{
				"total_revenue",
				GameManagers.Instance.UserArchiveManager.GetTotalRecharge()
			},
			{
				"total_revenue_orders",
				GameManagers.Instance.UserArchiveManager.GetRechargeOrderCnt()
			}
		});
	}

	public void OrderInitTrack(int orderId, string itemId, string currencyId, float payAmount)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>
		{
			{ "order_id", orderId },
			{ "pay_item_id", itemId },
			{ "pay_currency_id", currencyId },
			{ "pay_amount", payAmount }
		};
		if (itemId.Contains("PVP"))
		{
			dictionary.Add("season_id", RankDataHelper.PvpRankProgress.Id);
			dictionary.Add("turn_id", RankDataHelper.PvpRankProgress.TurnId);
		}
		Track("order_init", dictionary);
	}

	public void PayPreviewTrack(string itemId)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object> { { "pay_item_id", itemId } };
		Track("pay_preview", superProperties);
	}

	public void NoPayPreviewTrack()
	{
		Track("nopay_preview");
	}

	public void AssignOccupantTrack(string soldierId, float profitCd, string profitId, float profitPlus, string strongholdId)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "card_id", soldierId },
			{ "profit_cd", profitCd },
			{ "profit_id", profitId },
			{ "profit_plus", profitPlus },
			{ "stronghold_id", strongholdId }
		};
		Track("station_change", superProperties);
	}

	public void MainlineCompletedTrack(string id1st, int count1st, string id2nd, int count2nd, string id3rd, int count3rd, string choiceId, int choiceCount)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "oneFromThree_1st_id", id1st },
			{ "oneFromThree_1st__count", count1st },
			{ "oneFromThree_2nd_id", id2nd },
			{ "oneFromThree_2nd__count", count2nd },
			{ "oneFromThree_3rd_id", id3rd },
			{ "oneFromThree_3rd_count", count3rd },
			{ "oneFromThree_choice_id", choiceId },
			{ "oneFromThree_choice_count", choiceCount }
		};
		Track("mainline_completed", superProperties);
	}

	private void OnStockChange(string itemId, int incr, (StockInContext, string) context)
	{
		string value = $"{context.Item1}{context.Item2}";
		switch (itemId)
		{
		case "Gem":
		{
			Dictionary<string, object> superProperties3 = new Dictionary<string, object>
			{
				{ "diamond_source", value },
				{ "diamond_cost", incr }
			};
			Track("diamond_change", superProperties3);
			break;
		}
		default:
			if (!(itemId == "I40199"))
			{
				if (itemId == "ManPower")
				{
					Dictionary<string, object> superProperties = new Dictionary<string, object>
					{
						{ "farmer_source", value },
						{ "farmer_cost", incr }
					};
					Track("farmer", superProperties);
				}
				break;
			}
			goto case "I40999";
		case "I40999":
		case "I41000":
		case "I41001":
		case "I41002":
		case "I41003":
		case "I41011":
		case "I41012":
		case "I41013":
		case "I41014":
		case "I40105":
		case "I40131":
		case "I61003":
		case "I61001":
		case "I61002":
		case "I40200":
		{
			Dictionary<string, object> superProperties2 = new Dictionary<string, object>
			{
				{ "bag_type", value },
				{ "goods_id", itemId },
				{ "goods_cost", incr }
			};
			Track("bag_change", superProperties2);
			break;
		}
		}
	}

	public void SoldierOnLevelUpTrack(string soldierid, int level1, int level2)
	{
		if (level2 > level1)
		{
			Dictionary<string, object> superProperties = new Dictionary<string, object>
			{
				{ "card_id", soldierid },
				{ "card_level", level2 }
			};
			Track("card_levelUp", superProperties);
		}
	}

	private void OnSoldierSummoning(string soldierId, int levelChange, Dictionary<string, int> bonus)
	{
		if (levelChange > 0)
		{
			Dictionary<string, object> superProperties = new Dictionary<string, object>
			{
				{ "card_id", soldierId },
				{
					"card_quality",
					GameManagers.Instance.SoldierManager.Get(soldierId).PotentialLevel
				}
			};
			Track("card_qualityUp", superProperties);
		}
	}

	public void OnEvoluteCompletedTrack(string soldierId)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "card_id", soldierId },
			{
				"card_rank",
				GameManagers.Instance.SoldierManager.Get(soldierId).EvoLevel
			}
		};
		Track("card_rankUp", superProperties);
	}

	public void EquipLevelUpTrack(string equipId, int equipLevel, string soldierId)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "equip_id", equipId },
			{ "equip_level", equipLevel },
			{ "card_preview_id", soldierId }
		};
		Track("equip_levelUp", superProperties);
	}

	private void AcceptanceTrack(string buildingType, int level)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "build_id", buildingType },
			{ "build_level", level }
		};
		Track("bulid_levelUp", superProperties);
	}

	public void BulidingMakeTrack(string buildingType, int buildingLevel, List<string> proList, int workerNum)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "build_id", buildingType },
			{ "build_level", buildingLevel },
			{ "buliding_farmer_hold", workerNum }
		};
		Track("bulid_make", superProperties);
	}

	public void RecycleTrack(string proId, int goldNum, int workerNum)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "recycle_id", proId },
			{ "recycle_gold", goldNum },
			{ "buliding_farmer_hold", workerNum }
		};
		Track("recycle", superProperties);
	}

	private void TechActive(string techId, int level)
	{
		if (level == 1)
		{
			Dictionary<string, object> superProperties = new Dictionary<string, object>
			{
				{ "tec_id", techId },
				{
					"tec_hold",
					GameManagers.Instance.StockController.GetStock("TechPoint")
				}
			};
			Track("tec_active", superProperties);
		}
	}

	public void OffReward(int offTime, int moneyInr)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "off_duration", offTime },
			{ "off_gold", moneyInr }
		};
		Track("off_reward", superProperties);
	}

	public void GachaTrack(string gachaType, int diaCost, int chipCost, List<string> cardList)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "gacha_type", gachaType },
			{ "diamond_cost", diaCost },
			{ "chip_cost", chipCost },
			{ "card_id", cardList },
			{
				"chip_hold",
				GameManagers.Instance.StockController.GetStock("I40105")
			}
		};
		Track("gacha", superProperties);
	}

	public void VisitFriend(int userId)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object> { { "target_role_id", userId } };
		Track("visit_friend", superProperties);
	}

	public void SignInTrack(string type, int days)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "sign_type", type },
			{ "sign_days", days }
		};
		Track("sign_in", superProperties);
	}

	public void DailyTaskTrack(string taskId)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object> { { "task_id", taskId } };
		Track("daily_task", superProperties);
	}

	public void GetAchievementTrack(string achievementId)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object> { { "achievement_id", achievementId } };
		Track("get_achievement", superProperties);
	}

	public void FirstpayRewardTrack()
	{
		Track("firstpay_reward");
	}

	public void TotalRewardTrack(float _step)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "total_reward_name", "累充" },
			{ "total_reward_step", _step }
		};
		Track("total_reward", superProperties);
	}

	public void ContractTrack(string type, int _validityCd)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "contract_type", type },
			{ "validity_cd", _validityCd }
		};
		Track("contract", superProperties);
	}

	public void SoulEnterTrack(string soulId, string levelId)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "soul_id", soulId },
			{ "soul_camp_id", levelId }
		};
		Track("soul_enter", superProperties);
	}

	public void SoulScoutTrack(string soulId, string levelId)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "soul_id", soulId },
			{ "soul_camp_id", levelId }
		};
		Track("soul_scout", superProperties);
	}

	public void SoulCompletedTrack(string soulId, string levelId)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "soul_id", soulId },
			{ "soul_camp_id", levelId },
			{
				"spirit_hold",
				GameManagers.Instance.StockController.GetStock("I40101")
			}
		};
		Track("soul_completed", superProperties);
	}

	public void SoulFailedTrack(string soulId, string levelId)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "soul_id", soulId },
			{ "soul_camp_id", levelId },
			{
				"spirit_hold",
				GameManagers.Instance.StockController.GetStock("I40101")
			}
		};
		Track("soul_failed", superProperties);
	}

	public void SoulPointRewardTrack(string soulId, string rewardId, int _count, float _point)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "soul_id", soulId },
			{ "reward_id", rewardId },
			{ "reward_count", _count },
			{ "soul_point", _point }
		};
		Track("soul_point_reward", superProperties);
	}

	public void DefendEnterTrack(string defendId, string defendLevel)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "defend_id", defendId },
			{ "defend_level", defendLevel }
		};
		Track("defend_enter", superProperties);
	}

	public void DefendScoutTrack(string defendId, string campId)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "defend_id", defendId },
			{ "soul_camp_id", campId }
		};
		Track("defend_scout", superProperties);
	}

	public void DefendCompletedTrack(string defendId, string defendLevel, List<int> rune)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "defend_id", defendId },
			{ "defend_level", defendLevel },
			{ "defend_rune_count", rune },
			{
				"spirit_hold",
				GameManagers.Instance.StockController.GetStock("I40108")
			}
		};
		Track("defend_completed", superProperties);
	}

	public void DefendFailedTrack(string defendId, string defendLevel)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "defend_id", defendId },
			{ "defend_level", defendLevel }
		};
		Track("defend_failed", superProperties);
	}

	public void AttackRefreshTrack(string taskId, int taskStar)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "attack_task_id", taskId },
			{ "attack_star", taskStar }
		};
		Track("attack_refresh", superProperties);
	}

	public void AttackEnterTrack(string taskId, int taskStar)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "attack_task_id", taskId },
			{ "attack_star", taskStar },
			{
				"spirit_hold",
				GameManagers.Instance.StockController.GetStock("I40107")
			}
		};
		Track("attack_enter", superProperties);
	}

	public void AttackScoutTrack(string taskId, int taskStar)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "attack_task_id", taskId },
			{ "attack_star", taskStar }
		};
		Track("attack_scout", superProperties);
	}

	public void AttackCompletedTrack(string taskId, int taskStar, string rewardId, int clearStages, int stages)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "attack_task_id", taskId },
			{ "attack_star", taskStar },
			{ "attack_reward_id", rewardId },
			{ "attack_clearStages", clearStages },
			{ "attack_stages", stages }
		};
		Track("attack_completed", superProperties);
	}

	public void AttackFailedTrack(string taskId, int taskStar, int partIndex)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "attack_task_id", taskId },
			{ "attack_star", taskStar },
			{ "end_part_id", partIndex }
		};
		Track("attack_failed", superProperties);
	}

	public void GatewayRecord()
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{
				"Header",
				HotUpdateProcess.GatewayHeader
			},
			{
				"Cost",
				HotUpdateProcess.GatewayCost
			}
		};
		Track("GatewayRecord", superProperties);
	}

	public void PingRecord(int cost)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object> { { "cost", cost } };
		Track("PingRecord", superProperties);
	}

	public void RPCRecord(int PacketId, int msgindex, int cost, string msg)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "rpc_packetid", PacketId },
			{ "rpc_msgindex", msgindex },
			{ "rpc_cost", cost },
			{ "rpc_msg", msg }
		};
		Track("rpc_record", superProperties);
	}

	private void RegistTrack(User user)
	{
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Invalid comparison between Unknown and I4
		if (HotUpdateProcess.ChannelCode == "toutiao-android")
		{
			AndroidBasicPlugInManager.Instance.GetIp(delegate
			{
				OceanEngineEventManager.Instance.InvokeAction(OceanEngineEventManager.eventType.Register, null);
			});
		}
		if (HotUpdateProcess.ChannelCode == "taptap" || HotUpdateProcess.ChannelCode == "tapplay")
		{
			AndroidBasicPlugInManager.Instance.GetIp(delegate
			{
				TapTapEventManager.Instance.InvokeAction(TapTapEventManager.TapTapEventType.Register, null);
			});
		}
		if (HotUpdateProcess.ChannelCode == "bilibili")
		{
			AndroidBasicPlugInManager.Instance.GetIp(delegate
			{
				BiliBiliEventManager.Instance.InvokeAction(BiliBiliEventManager.BiliBiliEventType.USER_REGISTER);
			});
		}
		if (HotUpdateProcess.ChannelCode == "gdt-android")
		{
			((GDTSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.GDT]).OnRegister(GameController.Contexts.gameState.user.value.LastLoginType);
		}
		if ((int)Application.platform == 8)
		{
			AndroidBasicPlugInManager.Instance.GetIp(delegate
			{
				OceanEngineEventManager.Instance.InvokeAction(OceanEngineEventManager.eventType.Register, null);
				TapTapEventManager.Instance.InvokeAction_IOS(TapTapEventManager.TapTapEventType.Register, null);
				BiliBiliEventManager.Instance.InvokeAction(BiliBiliEventManager.BiliBiliEventType.USER_REGISTER);
			});
		}
		if (_trackEnabled)
		{
			IsNewUser = true;
			Login(user.UserId.ToString());
			Track("regist");
			SetUserDataOnce(user);
			SetLoginType(UiHelper.LoginTypeStr);
			Flush();
		}
	}

	public void LegendItemsDraw(List<string> cards)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object> { { "card_id", cards } };
		Track("legend_item_draw", superProperties);
	}

	public void LegendItemsExchange(string card)
	{
		ItemEffectIdentifiedLegendItem itemEffectIdentifiedLegendItem = JsonHelper.ToObject<ItemEffectIdentifiedLegendItem>(GDMgr.Get<GDEItemData>(card).Effect);
		Dictionary<string, object> superProperties = new Dictionary<string, object> { { "legendItem_id", itemEffectIdentifiedLegendItem.LegendItemId } };
		Track("legend_item_exchange", superProperties);
		UserSet(new Dictionary<string, object> { 
		{
			"legendItems_exchangeCount",
			Instance.GetLegendItemFromBlackMarketStats()
		} });
	}

	public void LegendItemLevelEnterTrack(string taskId)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object> { { "legendItem_level_id", taskId } };
		Track("legendItem_level_enter", superProperties);
	}

	public void LegendItemLevelCompletedTrack(string taskId)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object> { { "legendItem_level_id", taskId } };
		Track("legendItem_level_completed", superProperties);
	}

	public void LegendItemLevelReward(string taskId, string reward, int count)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "legendItem_level_id", taskId },
			{ "level_reward_id", reward },
			{ "level_reward_count", count }
		};
		Track("legendItem_level_reward", superProperties);
	}

	public void LegendItemLevelFailedTrack(string taskId)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object> { { "legendItem_level_id", taskId } };
		Track("legendItem_level_failed", superProperties);
	}

	public void LegendItemEnhanceTrack()
	{
		Track("legendItem_level_enhance");
	}

	public void LegendItemChangePropertyTrack()
	{
		Track("legendItem_level_changeProperty");
	}

	public void LegendItemReforgeTrack(LegendItemUi itemUi)
	{
		int num = ((itemUi.ReforgeIndex != null) ? itemUi.ReforgeIndex.Count : 0);
		string itemId = itemUi.LegendItemData.ItemId;
		List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
		if (LegendItemManager.LegendItemReforgeLockCosts.TryGetValue(itemId, out var value))
		{
			list.AddRange(value.Last());
		}
		int num2 = LegendItemsHelper.GetReforgeLockCostCount(itemUi);
		if (num == 0)
		{
			num2 = num;
		}
		string key = list.First().Key;
		float num3 = list.First().Value;
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "locked_entries_count", num },
			{ "reforge_cost_id", key },
			{
				"reforge_cost_value",
				num3 * (float)num2
			}
		};
		Track("legendItem_level_reforge", superProperties);
	}

	public void LegendItemSlotUnlockTrack(string sid)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object> { { "soldier_id", sid } };
		Track("legendItem_slot_unlock", superProperties);
	}

	public void OpenLegendItemBox(string legendItemBoxId, int legendItemBoxValue, List<string> legendItemsRewardId)
	{
		if (Shift.Legion.Common.Models.Item.ItemType(legendItemBoxId) != 17 && !(legendItemBoxId == "I40188") && !(legendItemBoxId == "I40189") && !(legendItemBoxId == "I40190"))
		{
			Dictionary<string, object> superProperties = new Dictionary<string, object>
			{
				{ "legendItem_id", legendItemBoxId },
				{ "legendItem_value", legendItemBoxValue },
				{ "legendItems_reward_id", legendItemsRewardId }
			};
			Track("legendItemBox_open", superProperties);
		}
	}

	public void PvpSelectZone(int bigZoneId, string rsName)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "big_zone_id", bigZoneId },
			{ "rsname", rsName },
			{
				"season_id",
				RankDataHelper.PvpRankProgress.Id
			},
			{
				"turn_id",
				RankDataHelper.PvpRankProgress.TurnId
			}
		};
		Track("pvp_select_zone", superProperties);
	}

	public void PvpBattleCompleted(string rankUpRewardId, int rankUpRewardValue, int rankChanged)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "pvp_rank_up_reward_id", rankUpRewardId },
			{ "pvp_rank_up_reward_value", rankUpRewardValue },
			{ "pvp_rank_change", rankChanged },
			{
				"season_id",
				RankDataHelper.PvpRankProgress.Id
			},
			{
				"turn_id",
				RankDataHelper.PvpRankProgress.TurnId
			}
		};
		Track("pvp_battle_victory", superProperties);
	}

	public void PvpBattleFailed()
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{
				"season_id",
				RankDataHelper.PvpRankProgress.Id
			},
			{
				"turn_id",
				RankDataHelper.PvpRankProgress.TurnId
			}
		};
		Track("pvp_battle_fail", superProperties);
	}

	public void PvpBattleStart()
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{
				"season_id",
				RankDataHelper.PvpRankProgress.Id
			},
			{
				"turn_id",
				RankDataHelper.PvpRankProgress.TurnId
			}
		};
		Track("pvp_battle_start", superProperties);
	}

	public void PvpTopBattleUnlocked()
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{
				"season_id",
				RankDataHelper.PvpRankProgress.Id
			},
			{
				"turn_id",
				RankDataHelper.PvpRankProgress.TurnId
			}
		};
		Track("start_pvp_top_battle", superProperties);
	}

	public void GetPvpIdleReward(string rewardId, int rewardValue)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object>
		{
			{ "pvp_idle_reward_id", rewardId },
			{ "pvp_idle_reward_value", rewardValue },
			{
				"season_id",
				RankDataHelper.PvpRankProgress.Id
			},
			{
				"turn_id",
				RankDataHelper.PvpRankProgress.TurnId
			}
		};
		Track("pvp_idle_reward", superProperties);
	}

	public void SetUserIsNewGuideModeOnce(string guideMode)
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object> { { "guide_mode", guideMode } };
		UserSetOnce(superProperties);
	}

	public void NewbieMissionCompletedTrack(Mission mission)
	{
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode() && mission.MissionType == MissionType.Newbie)
		{
			Dictionary<string, object> superProperties = new Dictionary<string, object>
			{
				{ "newbie_mission_id", mission.Id },
				{
					"newbie_mission_name",
					mission.Data.Name
				},
				{
					"newbie_mission_desc",
					mission.Data.Desc
				}
			};
			Track("newbie_mission_completed", superProperties);
		}
	}

	public void NewbieMissionClaimedTrack(Mission mission)
	{
		if (GameManagers.Instance.UserArchiveManager.IsNewGuideMode() && (mission.MissionType == MissionType.Newbie || mission.MissionType == MissionType.NewbieSummary))
		{
			if (mission.MissionType == MissionType.NewbieSummary)
			{
				Dictionary<string, object> superProperties = new Dictionary<string, object>
				{
					{ "newbie_mission_id", mission.Id },
					{
						"newbie_mission_name",
						mission.Data.Name
					},
					{
						"newbie_mission_desc",
						mission.Data.Desc
					}
				};
				Track("newbie_mission_completed", superProperties);
			}
			Dictionary<string, object> superProperties2 = new Dictionary<string, object>
			{
				{ "newbie_mission_id", mission.Id },
				{
					"newbie_mission_name",
					mission.Data.Name
				},
				{
					"newbie_mission_desc",
					mission.Data.Desc
				}
			};
			Track("newbie_mission_claimed", superProperties2);
		}
	}

	public void ClickQTE()
	{
		Dictionary<string, object> superProperties = new Dictionary<string, object> { 
		{
			"current_level_id",
			GameManagers.Instance.UserArchiveManager.GetCurrentLevelId()
		} };
		Track("click_qte", superProperties);
	}

	public void ThinkingApiLogout()
	{
		Logout();
	}

	public void UserSetOnce(Dictionary<string, object> superProperties)
	{
		if (_trackEnabled && HotUpdateProcess.ChannelCode == "gdt-android")
		{
			superProperties.Add("sub_channelcode", GDTSDK.SubChannel);
		}
	}

	public void UserSet(Dictionary<string, object> superProperties)
	{
		if (_trackEnabled)
		{
		}
	}

	public void Track(string eventName)
	{
		Track(eventName, null);
	}

	public void Track(string eventName, Dictionary<string, object> superProperties)
	{
		if (_trackEnabled)
		{
		}
	}

	public void SetSuperProperties(Dictionary<string, object> superProperties)
	{
		if (_trackEnabled)
		{
		}
	}

	public void Logout()
	{
		if (_trackEnabled)
		{
		}
	}

	public void Login(string userId)
	{
		if (_trackEnabled)
		{
		}
	}

	public void Flush()
	{
		if (_trackEnabled)
		{
		}
	}

	public void EnableAutoTrack()
	{
		if (_trackEnabled)
		{
		}
	}

	public void TimeEvent(string param)
	{
		if (_trackEnabled)
		{
		}
	}

	private void Start()
	{
		SharedMessenger.AddListener<User>("NEW_USER_REGISTERED", RegistTrack);
	}
}
