using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UI.AddCredit;
using UI.Tips;

namespace Shift.Legion.Common.Models;

public class NewbieGACHAActivityPayload : ActivityContentPayload
{
	public enum eProgress
	{
		WaitToStart,
		WaitToClick,
		WaitToConfirm,
		End
	}

	public static string ProgressKey = "Progress";

	public static string ContentKey = "Content";

	public static string SelectKey = "Select";

	public const string NewbieGachaActivityId = "NewbieGacha";

	public readonly string LotteryId;

	public readonly int Repeat = 1;

	public readonly List<Dictionary<string, int>> Tickets;

	public string LotteryOption;

	public NewbieGACHAActivityPayload(int payloadIndex, string lotteryOption, Dictionary<string, object> data, Activity activity)
		: base(data)
	{
		ContentIndex = payloadIndex;
		Activity = activity;
		LotteryOption = lotteryOption;
		if (data.TryGetValue("Lottery", out var value))
		{
			LotteryId = value.ToString();
		}
		if (data.TryGetValue("Repeat", out var value2))
		{
			Repeat = Convert.ToInt32(value2);
		}
		Tickets = new List<Dictionary<string, int>>();
		if (data.TryGetValue("Tickets", out var value3))
		{
			for (int i = 0; i < ((ArrayList)value3).Count; i++)
			{
				Tickets.Add((Dictionary<string, int>)((ArrayList)value3)[i]);
			}
		}
	}

	private Dictionary<string, int> FindValidTicketConfig(GameManagers managers)
	{
		for (int num = Tickets.Count - 1; num >= 0; num--)
		{
			Dictionary<string, int> dictionary = Tickets[num];
			bool flag = true;
			foreach (KeyValuePair<string, int> item in dictionary)
			{
				if (managers.StockController.GetStock(item.Key) >= item.Value)
				{
					continue;
				}
				flag = false;
				break;
			}
			if (flag)
			{
				return dictionary;
			}
		}
		return null;
	}

	public bool CheckTicket(GameManagers managers, List<string> ticketItems, out Dictionary<string, int> ticketConfig)
	{
		ticketConfig = null;
		if (Tickets.Count < 1)
		{
			return true;
		}
		if (ticketItems == null || ticketItems.Count < 1)
		{
			ticketConfig = FindValidTicketConfig(managers);
			return ticketConfig != null;
		}
		foreach (Dictionary<string, int> ticket in Tickets)
		{
			if (ticket.Count != ticketItems.Count || ticket.Keys.Any((string itemId) => !ticketItems.Contains(itemId)))
			{
				continue;
			}
			ticketConfig = ticket;
			foreach (KeyValuePair<string, int> item in ticket)
			{
				if (managers.StockController.GetStock(item.Key) < item.Value)
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private void ConsumeTickets(GameManagers managers, Dictionary<string, int> ticketConfig = null)
	{
		if (ticketConfig == null || ticketConfig.Count < 1)
		{
			return;
		}
		StockChangeRecord[] array = new StockChangeRecord[ticketConfig.Count];
		int num = 0;
		foreach (KeyValuePair<string, int> item in ticketConfig)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item.Key,
				Offset = -item.Value,
				Context = 6,
				ContextValue = LotteryId,
				Type = 1
			};
		}
		managers.StockController.ReadStockChangeRecords(array);
	}

	private void InitConfig(ref ActivityConfig config)
	{
		if (!config.Progress.ContainsKey(ProgressKey))
		{
			config.Progress.Add(ProgressKey, 0);
		}
		if (!config.Progress.ContainsKey(ContentKey))
		{
			config.Progress.Add(ContentKey, new List<List<ModelsBonus>>());
		}
		if (!config.Progress.ContainsKey(SelectKey))
		{
			config.Progress.Add(SelectKey, -1);
		}
	}

	private void _StepProgress(ref ActivityConfig config)
	{
		if (!config.Progress.TryGetValue(ProgressKey, out var value))
		{
			throw new Exception("NewbieGACHAActivityPayload 没有" + ProgressKey + " 不可能走到这里，因为已经InitConfig了");
		}
		int num = (int)value;
		num++;
		config.Progress[ProgressKey] = num;
	}

	private void _Select(ref ActivityConfig config, int Select)
	{
		if (!GameManagers.Instance.UserArchiveManager.IsNewGuideForeignMode6() && !GameManagers.Instance.UserArchiveManager.IsNewGuideMode6() && !GameManagers.Instance.UserArchiveManager.IsNewGuideMode7())
		{
			if (Select < 0 || Select >= Repeat)
			{
				throw new Exception($"NewbieGACHAActivityPayload Select是{Select}？？");
			}
			if (!config.Progress.ContainsKey(SelectKey))
			{
				throw new Exception("NewbieGACHAActivityPayload 没有" + SelectKey + " 不可能走到这里，因为已经InitConfig了");
			}
		}
		config.Progress[SelectKey] = Select;
	}

	public int DoNextProgress(GameManagers managers, ref ActivityConfig config, int next_progress, int SelectIdx = -1)
	{
		InitConfig(ref config);
		int num = (int)config.Progress[ProgressKey];
		switch (next_progress)
		{
		case 1:
			managers.UserArchiveManager.SetActivityProgress(config);
			return 0;
		case 2:
			managers.UserArchiveManager.SetActivityProgress(config);
			return 0;
		case 3:
		{
			_Select(ref config, SelectIdx);
			List<List<ModelsBonus>> list = (List<List<ModelsBonus>>)config.Progress[ContentKey];
			List<ModelsBonus> list2 = list[SelectIdx];
			foreach (ModelsBonus item in list2)
			{
				Bonus bonus = Bonus.Get(item.ItemId, item.Qty);
				bonus.Claim(managers);
			}
			managers.UserArchiveManager.SetActivityProgress(config);
			return 0;
		}
		default:
			return 81310006;
		}
	}

	public int GetNewbieGACHAActivityProgress()
	{
		ActivityConfig config = Activity.ActivityProgress(GameManagers.Instance);
		InitConfig(ref config);
		return (int)config.Progress[ProgressKey];
	}

	public List<List<ModelsBonus>> GetNewbieGACHAActivityContent(bool isInit, out List<int> counts)
	{
		ActivityConfig config = Activity.ActivityProgress(GameManagers.Instance);
		InitConfig(ref config);
		List<List<ModelsBonus>> list = new List<List<ModelsBonus>>();
		if (isInit)
		{
			ArrayList arrayList = (ArrayList)config.Progress[ContentKey];
			for (int i = 0; i < arrayList.Count; i++)
			{
				List<ModelsBonus> list2 = new List<ModelsBonus>();
				ArrayList arrayList2 = (ArrayList)arrayList[i];
				for (int j = 0; j < arrayList2.Count; j++)
				{
					Dictionary<string, object> dictionary = (Dictionary<string, object>)arrayList2[j];
					ModelsBonus modelsBonus = new ModelsBonus();
					foreach (string key in dictionary.Keys)
					{
						switch (key)
						{
						case "Type":
							modelsBonus.Type = int.Parse(dictionary[key].ToString());
							break;
						case "ItemId":
							modelsBonus.ItemId = dictionary[key].ToString();
							break;
						case "Qty":
							modelsBonus.Qty = int.Parse(dictionary[key].ToString());
							break;
						case "IsCard3":
							modelsBonus.IsCard3 = bool.Parse(dictionary[key].ToString());
							break;
						case "IsShining":
							modelsBonus.IsShining = int.Parse(dictionary[key].ToString());
							break;
						}
					}
					list2.Add(modelsBonus);
				}
				list.Add(list2);
			}
		}
		else
		{
			list = (List<List<ModelsBonus>>)config.Progress[ContentKey];
		}
		counts = new List<int>();
		for (int k = 0; k < list.Count; k++)
		{
			counts.Add(list[k].Count);
		}
		return list;
	}

	private ActivityConfig UpdateActivityConfig(int progress, List<List<ModelsBonus>> content, int select = -1)
	{
		ActivityConfig config = Activity.ActivityProgress(GameManagers.Instance);
		InitConfig(ref config);
		config.Progress[ProgressKey] = progress;
		config.Progress[SelectKey] = select;
		config.Progress[ContentKey] = content;
		return config;
	}

	public async Task<bool> UpdateNewbieGACHAActivityProgress(int select = -1)
	{
		int curProgress = GetNewbieGACHAActivityProgress();
		if (curProgress >= 3)
		{
			ILRequestHelper.ShowErrorCode(81320002);
			return false;
		}
		Dictionary<string, int> ticketConfig = new Dictionary<string, int>();
		if (curProgress == 0 && !CheckTicket(GameManagers.Instance, null, out ticketConfig))
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					"    " + LanguagesManager.GetDesc("CsharpCodeZhTcText187") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText188") + "？"
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{
							"Confirm",
							delegate
							{
								GameController.Contexts.Service<IUiService>().OpenPanel(UI_BlackMarketerAddCredit.Name, new Dictionary<string, object> { 
								{
									"Activity",
									FGUIManager.Instance.GetBlackMarketerActivity("UI_BlackMarketerAddCredit")
								} });
							}
						},
						{ "Cancel", null }
					}
				},
				{ "PageIndex", 4 },
				{ "ClickSound", "Confirm" }
			});
			return false;
		}
		NewbieGACHAResponse _response = await GameController.Contexts.Service<INetworkService>().UpdateNewbieGACHAProgress(Activity.ActivityId, curProgress + 1, select);
		if (_response.ErrorCode != 0)
		{
			ILRequestHelper.ShowErrorCode(_response.ErrorCode);
			return false;
		}
		if (_response.Progress == 1)
		{
			ConsumeTickets(GameManagers.Instance, ticketConfig);
		}
		ActivityConfig activityConfig = UpdateActivityConfig(_response.Progress, _response.BonusLists, _response.Select);
		int result = DoNextProgress(GameManagers.Instance, ref activityConfig, _response.Progress, _response.Select);
		if (result != 0 && result != 81320002)
		{
			ILRequestHelper.ShowErrorCode(result);
			return false;
		}
		return true;
	}
}
