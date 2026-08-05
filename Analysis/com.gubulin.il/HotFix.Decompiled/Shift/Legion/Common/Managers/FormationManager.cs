using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameDataEditor;
using GameMaths;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.Common.Managers;

public class FormationManager : Manager
{
	private static List<Dictionary<string, object>> _formationUnlockCost;

	private static Dictionary<string, Formation> _formations;

	private static Dictionary<string, Formation> _playerUsableFormations;

	private static Dictionary<string, Formation> _formationsUnlockedAtBegin;

	public const string CommonDefaultFormation = "FA01";

	public const string DefenseModeDefaultFormation = "FFB_01";

	public static List<Dictionary<string, object>> FormationUnlockCost
	{
		get
		{
			if (_formationUnlockCost == null)
			{
				_formationUnlockCost = new List<Dictionary<string, object>>();
				foreach (GDEFormationUnlockData allItem in GDMgr.GetAllItems<GDEFormationUnlockData>())
				{
					Dictionary<string, object> item = JsonHelper.ToObject<Dictionary<string, object>>(allItem.Cost);
					_formationUnlockCost.Add(item);
				}
			}
			return _formationUnlockCost;
		}
	}

	public static Dictionary<string, Formation> Formations
	{
		get
		{
			if (_formations == null)
			{
				EnsureFormationData();
			}
			return _formations;
		}
	}

	public static Dictionary<string, Formation> PlayerUsableFormations
	{
		get
		{
			if (_playerUsableFormations == null)
			{
				EnsureFormationData();
			}
			return _playerUsableFormations;
		}
	}

	public static Dictionary<string, Formation> FormationsUnlockedAtBegin
	{
		get
		{
			if (_formationsUnlockedAtBegin == null)
			{
				EnsureFormationData();
			}
			return _formationsUnlockedAtBegin;
		}
	}

	public bool HasMultipleFormations => Managers.UserArchiveManager.GetUnlockedFormations().Count > 1;

	private static void EnsureFormationData()
	{
		if (_formations == null)
		{
			_formations = new Dictionary<string, Formation>();
		}
		else
		{
			_formations.Clear();
		}
		if (_playerUsableFormations == null)
		{
			_playerUsableFormations = new Dictionary<string, Formation>();
		}
		else
		{
			_playerUsableFormations.Clear();
		}
		if (_formationsUnlockedAtBegin == null)
		{
			_formationsUnlockedAtBegin = new Dictionary<string, Formation>();
		}
		else
		{
			_formationsUnlockedAtBegin.Clear();
		}
		foreach (GDEFormationData allItem in GDMgr.GetAllItems<GDEFormationData>())
		{
			Formation formation = new Formation(allItem);
			_formations.Add(allItem.Key, formation);
			if (formation.PlayerUsable)
			{
				_playerUsableFormations.Add(allItem.Key, formation);
			}
			if (formation.UnlockedAtBegin)
			{
				_formationsUnlockedAtBegin.Add(allItem.Key, formation);
			}
		}
	}

	public FormationManager(GameManagers managers)
		: base(managers)
	{
	}

	public override void AddEventListener()
	{
		Managers.Messenger.AddListener<int>("NEW_FORMATION_SLOT_UNLOCKED", UnlockFormationSlot);
		Managers.Messenger.AddListener<List<string>>("FORMATION_FORCE_UNLOCKED", ForceUnlockFormation);
		Managers.Messenger.AddListener<List<string>>("FORMATION_FORCE_LOCKED", ForceLockFormation);
	}

	public override void RemoveEventListener()
	{
		Managers.Messenger.RemoveListener<int>("NEW_FORMATION_SLOT_UNLOCKED", UnlockFormationSlot);
		Managers.Messenger.RemoveListener<List<string>>("FORMATION_FORCE_UNLOCKED", ForceUnlockFormation);
		Managers.Messenger.RemoveListener<List<string>>("FORMATION_FORCE_LOCKED", ForceLockFormation);
	}

	public override Task Init()
	{
		Dictionary<string, GDEFormationData> unlockedFormations = GetUnlockedFormations();
		foreach (KeyValuePair<string, Formation> item in FormationsUnlockedAtBegin)
		{
			if (!unlockedFormations.ContainsKey(item.Key))
			{
				Managers.UserArchiveManager.UnlockFormation(item.Key);
			}
		}
		return null;
	}

	public void UnlockFormationSlot(int slotIndex)
	{
		string ctx = ChapterType.StoryMain.ToString();
		foreach (object value in Enum.GetValues(typeof(BattleMode)))
		{
			string mode = value.ToString();
			Managers.FormationUnitsManager.ChangeFormationUnit(ctx, mode, slotIndex, "Unlock");
		}
	}

	public bool IsUnlocked(string formationId)
	{
		return GetUnlockedFormations().ContainsKey(formationId);
	}

	public Dictionary<string, GDEFormationData> GetUnlockedFormations()
	{
		Dictionary<string, GDEFormationData> dictionary = new Dictionary<string, GDEFormationData>();
		foreach (string unlockedFormation in Managers.UserArchiveManager.GetUnlockedFormations())
		{
			GDEFormationData gDEFormationData = GDMgr.Get<GDEFormationData>(unlockedFormation);
			if (gDEFormationData != null)
			{
				dictionary.Add(unlockedFormation, gDEFormationData);
			}
		}
		dictionary.Remove("FFB_01");
		return dictionary;
	}

	public static GDEFormationData GetFormation(string formationId)
	{
		return GDMgr.Get<GDEFormationData>(formationId);
	}

	public bool CanUnlockFormation(string formationId)
	{
		if (!Formations.TryGetValue(formationId, out var value))
		{
			return false;
		}
		if (!value.PlayerUsable)
		{
			return true;
		}
		Dictionary<string, object> nextFormationCost = GetNextFormationCost();
		if (nextFormationCost == null)
		{
			return false;
		}
		foreach (KeyValuePair<string, object> item in nextFormationCost)
		{
			if (Managers.StockController.GetStock(item.Key) < (int)item.Value)
			{
				return false;
			}
		}
		return true;
	}

	private void ConsumeFormationUnlock(string formationId)
	{
		Dictionary<string, object> nextFormationCost = GetNextFormationCost();
		if (nextFormationCost == null)
		{
			return;
		}
		StockChangeRecord[] array = new StockChangeRecord[nextFormationCost.Count];
		int num = 0;
		foreach (KeyValuePair<string, object> item in nextFormationCost)
		{
			array[num++] = new StockChangeRecord
			{
				ItemId = item.Key,
				Offset = -(int)item.Value,
				Context = 8,
				ContextValue = formationId,
				Type = 1
			};
		}
		Managers.StockController.ReadStockChangeRecords(array);
	}

	private void ForceUnlockFormation(List<string> formationIds)
	{
		foreach (string formationId in formationIds)
		{
			Managers.UserArchiveManager.UnlockFormation(formationId);
		}
	}

	private void ForceLockFormation(List<string> formationIds)
	{
		foreach (string formationId in formationIds)
		{
			Managers.UserArchiveManager.LockFormation(formationId);
		}
	}

	public bool UnlockFormation(string formationId, bool free = false)
	{
		if (!free)
		{
			if (!CanUnlockFormation(formationId))
			{
				return false;
			}
			ConsumeFormationUnlock(formationId);
		}
		Managers.UserArchiveManager.UnlockFormation(formationId);
		return true;
	}

	public Dictionary<string, object> GetNextFormationCost()
	{
		Dictionary<string, GDEFormationData> unlockedFormations = GetUnlockedFormations();
		IEnumerable<string> first = PlayerUsableFormations.Keys.Intersect(unlockedFormations.Keys);
		int num = first.Except(FormationsUnlockedAtBegin.Keys).Count();
		if (num < FormationUnlockCost.Count)
		{
			return FormationUnlockCost[num];
		}
		return null;
	}

	public ActionResult SetCurrentFormation(string context, string subContext, string formationId)
	{
		List<string> unlockedFormations = Managers.UserArchiveManager.GetUnlockedFormations();
		if (!unlockedFormations.Contains(formationId))
		{
			return new ActionResult
			{
				Result = false,
				ResultCode = ActionResultCode.FormationNotUnlocked
			};
		}
		GDEFormationData gDEFormationData = GDMgr.Get<GDEFormationData>(formationId);
		if (gDEFormationData == null)
		{
			return new ActionResult
			{
				Result = false,
				ResultCode = ActionResultCode.WrongFormation
			};
		}
		Managers.UserArchiveManager.SetCurrentFormation(context, subContext, formationId);
		return new ActionResult
		{
			Result = true
		};
	}

	public Vector2 SlotSizeOfFormation(string formationId, int index)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		GDEFormationData formation = GetFormation(formationId);
		return SlotSizeOfFormation(formation, index);
	}

	public static Vector2 SlotSizeOfFormation(GDEFormationData formation, int index)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		if (formation == null || index < 0 || index >= 12)
		{
			return Vector2.zero;
		}
		index++;
		Vector2 result = default(Vector2);
		switch (index)
		{
		case 1:
			((Vector2)(ref result))._002Ector(formation.Size1.x, formation.Size1.y);
			break;
		case 2:
			((Vector2)(ref result))._002Ector(formation.Size2.x, formation.Size2.y);
			break;
		case 3:
			((Vector2)(ref result))._002Ector(formation.Size3.x, formation.Size3.y);
			break;
		case 4:
			((Vector2)(ref result))._002Ector(formation.Size4.x, formation.Size4.y);
			break;
		case 5:
			((Vector2)(ref result))._002Ector(formation.Size5.x, formation.Size5.y);
			break;
		case 6:
			((Vector2)(ref result))._002Ector(formation.Size6.x, formation.Size6.y);
			break;
		case 7:
			((Vector2)(ref result))._002Ector(formation.Size7.x, formation.Size7.y);
			break;
		case 8:
			((Vector2)(ref result))._002Ector(formation.Size8.x, formation.Size8.y);
			break;
		case 9:
			((Vector2)(ref result))._002Ector(formation.Size9.x, formation.Size9.y);
			break;
		case 10:
			((Vector2)(ref result))._002Ector(formation.Size10.x, formation.Size10.y);
			break;
		case 11:
			((Vector2)(ref result))._002Ector(formation.Size11.x, formation.Size11.y);
			break;
		case 12:
			((Vector2)(ref result))._002Ector(formation.Size12.x, formation.Size12.y);
			break;
		default:
			result = Vector2.zero;
			break;
		}
		return result;
	}

	public Vector2 SlotPositionOfFormation(string formationId, int index)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		GDEFormationData formation = GetFormation(formationId);
		return SlotPositionOfFormation(formation, index);
	}

	public static Vector2 SlotPositionOfFormation(GDEFormationData formation, int index)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		if (formation == null)
		{
			return Vector2.zero;
		}
		index++;
		Vector2 result = default(Vector2);
		switch (index)
		{
		case 1:
			((Vector2)(ref result))._002Ector(formation.Slot1.x, formation.Slot1.y);
			break;
		case 2:
			((Vector2)(ref result))._002Ector(formation.Slot2.x, formation.Slot2.y);
			break;
		case 3:
			((Vector2)(ref result))._002Ector(formation.Slot3.x, formation.Slot3.y);
			break;
		case 4:
			((Vector2)(ref result))._002Ector(formation.Slot4.x, formation.Slot4.y);
			break;
		case 5:
			((Vector2)(ref result))._002Ector(formation.Slot5.x, formation.Slot5.y);
			break;
		case 6:
			((Vector2)(ref result))._002Ector(formation.Slot6.x, formation.Slot6.y);
			break;
		case 7:
			((Vector2)(ref result))._002Ector(formation.Slot7.x, formation.Slot7.y);
			break;
		case 8:
			((Vector2)(ref result))._002Ector(formation.Slot8.x, formation.Slot8.y);
			break;
		case 9:
			((Vector2)(ref result))._002Ector(formation.Slot9.x, formation.Slot9.y);
			break;
		case 10:
			((Vector2)(ref result))._002Ector(formation.Slot10.x, formation.Slot10.y);
			break;
		case 11:
			((Vector2)(ref result))._002Ector(formation.Slot11.x, formation.Slot11.y);
			break;
		case 12:
			((Vector2)(ref result))._002Ector(formation.Slot12.x, formation.Slot12.y);
			break;
		default:
			result = Vector2.zero;
			break;
		}
		return result;
	}

	public float SlotVisionRadiusOfFormation(string formationId, int index)
	{
		GDEFormationData formation = GetFormation(formationId);
		return SlotVisionRadiusOfFormation(formation, index);
	}

	public static float SlotVisionRadiusOfFormation(GDEFormationData formation, int index)
	{
		if (formation == null)
		{
			return 0f;
		}
		index++;
		return index switch
		{
			1 => formation.VisionRadius1, 
			2 => formation.VisionRadius2, 
			3 => formation.VisionRadius3, 
			4 => formation.VisionRadius4, 
			5 => formation.VisionRadius5, 
			6 => formation.VisionRadius6, 
			7 => formation.VisionRadius7, 
			8 => formation.VisionRadius8, 
			9 => formation.VisionRadius9, 
			10 => formation.VisionRadius10, 
			11 => formation.VisionRadius11, 
			12 => formation.VisionRadius12, 
			_ => 0f, 
		};
	}

	public int SlotsOfFormation(string formationId)
	{
		GDEFormationData formation = GetFormation(formationId);
		return SlotsOfFormation(formation);
	}

	public int SlotsOfFormation(GDEFormationData formation)
	{
		if (formation == null)
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < 12; i++)
		{
			if (IsFormationSlotAvailable(formation, i))
			{
				num++;
			}
		}
		return num;
	}

	public bool IsFormationSlotAvailable(GDEFormationData formation, int index)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return SlotSizeOfFormation(formation, index) != Vector2.zero;
	}
}
