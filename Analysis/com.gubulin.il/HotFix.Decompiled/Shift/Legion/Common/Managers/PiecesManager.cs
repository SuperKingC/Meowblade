using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using Shift.Legion.ClientApi.Models;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;

namespace Shift.Legion.Common.Managers;

public class PiecesManager : Manager
{
	private static Dictionary<string, Pieces> _piecesDict;

	private static Dictionary<PiecesType, List<Pieces>> _typedPiecesDict;

	private static Dictionary<string, List<Pieces>> _soldierSoulStoneDict;

	public static Dictionary<string, Pieces> PiecesDict
	{
		get
		{
			if (_piecesDict == null)
			{
				_piecesDict = new Dictionary<string, Pieces>();
				foreach (GDEPiecesData allItem in GDMgr.GetAllItems<GDEPiecesData>())
				{
					_piecesDict.Add(allItem.Key, new Pieces(allItem));
				}
			}
			return _piecesDict;
		}
	}

	public static Dictionary<PiecesType, List<Pieces>> TypedPiecesDict
	{
		get
		{
			if (_typedPiecesDict == null)
			{
				_typedPiecesDict = new Dictionary<PiecesType, List<Pieces>>();
				foreach (Pieces value in PiecesDict.Values)
				{
					if (!_typedPiecesDict.ContainsKey(value.Type))
					{
						_typedPiecesDict.Add(value.Type, new List<Pieces>());
					}
					_typedPiecesDict[value.Type].Add(value);
				}
			}
			return _typedPiecesDict;
		}
	}

	public static Dictionary<string, List<Pieces>> SoldierSoulStoneDict
	{
		get
		{
			if (_soldierSoulStoneDict == null)
			{
				_soldierSoulStoneDict = new Dictionary<string, List<Pieces>>();
				foreach (Pieces item in GetPiecesByType(PiecesType.SoulStone))
				{
					if (!_soldierSoulStoneDict.ContainsKey(item.RelativeContext))
					{
						_soldierSoulStoneDict.Add(item.RelativeContext, new List<Pieces>());
					}
					_soldierSoulStoneDict[item.RelativeContext].Add(item);
				}
			}
			return _soldierSoulStoneDict;
		}
	}

	public PiecesManager(GameManagers managers)
		: base(managers)
	{
	}

	public static List<Pieces> GetPiecesByType(PiecesType type)
	{
		List<Pieces> value;
		return TypedPiecesDict.TryGetValue(type, out value) ? value : null;
	}

	public static List<Pieces> GetSoulStoneCompositeDataBySoldier(string soldierId)
	{
		List<Pieces> value;
		return SoldierSoulStoneDict.TryGetValue(soldierId, out value) ? value : null;
	}

	public static List<Pieces> GetPiecesDataByCompositeResult(IEnumerable<Pieces> checkingList = null, params string[] itemIds)
	{
		if (checkingList == null)
		{
			checkingList = PiecesDict.Values;
		}
		return checkingList.Where((Pieces pieces) => pieces.Result.Keys.Intersect(itemIds).Any()).ToList();
	}

	public ActionResult Composite(string piecesId, int compositeCnt = 1, bool broadcastInform = false)
	{
		GDEPiecesData gDEPiecesData = GDMgr.Get<GDEPiecesData>(piecesId);
		if (gDEPiecesData == null)
		{
			return new ActionResult
			{
				Result = false,
				ResultCode = ActionResultCode.DataNotFound
			};
		}
		Pieces pieces = new Pieces(gDEPiecesData);
		if (GetMaxComposite(piecesId) < compositeCnt)
		{
			return new ActionResult
			{
				Result = false,
				ResultCode = ActionResultCode.NotEnoughPieces
			};
		}
		if (pieces.Result.Count < 1)
		{
			return new ActionResult
			{
				Result = false,
				ResultCode = ActionResultCode.PieceMixError
			};
		}
		DoComposite(pieces, compositeCnt, broadcastInform, out var _);
		return new ActionResult
		{
			Result = true
		};
	}

	private Dictionary<string, int> DoComposite(Pieces piecesData, int compositeCnt, bool broadcastInform, out List<KeyValuePair<Bonus, int>> bonusInfoList)
	{
		bonusInfoList = new List<KeyValuePair<Bonus, int>>();
		Dictionary<string, float> dictionary = new Dictionary<string, float>();
		foreach (KeyValuePair<string, int> item in piecesData.Result)
		{
			string key = item.Key;
			int num = item.Value * compositeCnt;
			if (num > 0)
			{
				Bonus bonus = Bonus.Get(key, num);
				bonusInfoList.Add(new KeyValuePair<Bonus, int>(bonus, Shift.Legion.Common.Models.Item.IsShining(key)));
				bonus.Claim(Managers, dictionary, null, forceClaim: true, broadcastInform);
			}
		}
		Dictionary<string, int> dictionary2 = new Dictionary<string, int>();
		foreach (KeyValuePair<string, float> item2 in dictionary)
		{
			if (!dictionary2.ContainsKey(item2.Key))
			{
				dictionary2.Add(item2.Key, 0);
			}
			dictionary2[item2.Key] += (int)item2.Value;
		}
		Managers.Messenger.Broadcast("PIECES_COMPOUND", piecesData, compositeCnt, dictionary2, bonusInfoList);
		Managers.StockController.ReadStockChangeRecords(new StockChangeRecord[1]
		{
			new StockChangeRecord
			{
				ItemId = piecesData.ItemId,
				Offset = -piecesData.CompositeRequirement * compositeCnt,
				Context = 18,
				ContextValue = piecesData.PiecesId,
				Type = 1
			}
		});
		return dictionary2;
	}

	public int GetMaxComposite(string piecesId)
	{
		GDEPiecesData gDEPiecesData = GDMgr.Get<GDEPiecesData>(piecesId);
		if (gDEPiecesData == null)
		{
			return 0;
		}
		if (gDEPiecesData.CompositeRequirements < 1)
		{
			return 0;
		}
		return Managers.StockController.GetStock(gDEPiecesData.ItemId) / gDEPiecesData.CompositeRequirements;
	}

	public Dictionary<string, int> MaxCompositeSoldierSoulStoneTo(string soldierId, int targetPotentialLevel, out List<CompositeInformData> informDatas)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		informDatas = new List<CompositeInformData>();
		List<Pieces> soulStoneCompositeDataBySoldier = GetSoulStoneCompositeDataBySoldier(soldierId);
		if (soulStoneCompositeDataBySoldier == null)
		{
			return dictionary;
		}
		for (int i = 1; i <= targetPotentialLevel + 1; i++)
		{
			SoldierPotentialData soldierPotential = ConfigDataManager.GetSoldierPotential(soldierId, i);
			if (soldierPotential == null)
			{
				continue;
			}
			List<Pieces> piecesDataByCompositeResult = GetPiecesDataByCompositeResult(soulStoneCompositeDataBySoldier, soldierPotential.Requirements(Managers).Keys.ToArray());
			foreach (Pieces item in piecesDataByCompositeResult)
			{
				int maxComposite = GetMaxComposite(item.PiecesId);
				if (maxComposite <= 0)
				{
					continue;
				}
				string itemId = item.ItemId;
				int num = item.CompositeRequirement * maxComposite;
				dictionary.TryGetValue(itemId, out var value);
				value -= num;
				if (value == 0)
				{
					dictionary.Remove(itemId);
				}
				else if (dictionary.ContainsKey(itemId))
				{
					dictionary[itemId] = value;
				}
				else
				{
					dictionary.Add(itemId, value);
				}
				List<KeyValuePair<Bonus, int>> bonusInfoList;
				Dictionary<string, int> dictionary2 = DoComposite(item, maxComposite, broadcastInform: false, out bonusInfoList);
				informDatas.Add(new CompositeInformData
				{
					PiecesId = item.PiecesId,
					BonusList = bonusInfoList.Select(delegate(KeyValuePair<Bonus, int> bonusInfoKv)
					{
						Bonus key2 = bonusInfoKv.Key;
						return new ModelsBonus
						{
							ItemId = key2.ItemId,
							Qty = key2.Qty,
							Type = key2.Type,
							IsShining = bonusInfoKv.Value
						};
					}).ToList(),
					CompositeCnt = maxComposite,
					CompositeResult = dictionary2
				});
				foreach (KeyValuePair<string, int> item2 in dictionary2)
				{
					string key = item2.Key;
					int value2 = item2.Value;
					if (dictionary.ContainsKey(key))
					{
						dictionary[key] += value2;
					}
					else
					{
						dictionary.Add(key, value2);
					}
				}
			}
		}
		return dictionary;
	}
}
