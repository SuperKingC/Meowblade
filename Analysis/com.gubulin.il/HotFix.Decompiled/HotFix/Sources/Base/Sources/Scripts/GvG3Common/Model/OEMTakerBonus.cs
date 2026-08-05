using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using ProtoBuf;
using Shift.Legion.GvG.Common.Models;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

[ProtoContract]
public class OEMTakerBonus
{
	[ProtoMember(1, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> BaseBonus_ToProtocol;

	[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> ExtraBonus_ToProtocol;

	[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> CritalBonus_ToProtocol;

	[ProtoMember(4, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> TitanBonus_ToProtocol;

	[ProtoMember(5, TypeName = "Shift.Legion.GvG.Common.Models.RItem")]
	public List<RItem> OtherBonus_ToProtocol;

	[ProtoMember(6, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem.OEMResult")]
	public OEMResult OEMResult_Formula;

	[ProtoMember(7, TypeName = "HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem.OEMResult")]
	public OEMResult OEMResult_Material;

	private List<OEMTakerBonusItem> _bonusItems;

	public List<OEMTakerBonusItem> BonusItems(int ampIdx)
	{
		if (_bonusItems != null)
		{
			return _bonusItems;
		}
		OemMissionBonus bonus = OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(ampIdx).Bonus;
		bool flag = bonus != null;
		_bonusItems = new List<OEMTakerBonusItem>();
		if (BaseBonus_ToProtocol != null)
		{
			foreach (RItem item in BaseBonus_ToProtocol)
			{
				_bonusItems.Add(new OEMTakerBonusItem
				{
					Item = item,
					Type = eOEMTakeBonusType.Base,
					Obtained = true
				});
			}
		}
		else if (flag)
		{
			KeyValuePair<string, int> baseBonus = bonus.GetBaseBonus();
			_bonusItems.Add(new OEMTakerBonusItem
			{
				Item = new RItem
				{
					ItemId = baseBonus.Key,
					cnt = baseBonus.Value
				},
				Type = eOEMTakeBonusType.Base,
				Obtained = false
			});
		}
		if (ExtraBonus_ToProtocol != null)
		{
			foreach (RItem item2 in ExtraBonus_ToProtocol)
			{
				_bonusItems.Add(new OEMTakerBonusItem
				{
					Item = item2,
					Type = eOEMTakeBonusType.Extra,
					Obtained = true
				});
			}
		}
		else if (flag)
		{
			KeyValuePair<string, int> extraBonus = bonus.GetExtraBonus();
			_bonusItems.Add(new OEMTakerBonusItem
			{
				Item = new RItem
				{
					ItemId = extraBonus.Key,
					cnt = extraBonus.Value
				},
				Type = eOEMTakeBonusType.Extra,
				Obtained = false
			});
		}
		if (CritalBonus_ToProtocol != null)
		{
			foreach (RItem item3 in CritalBonus_ToProtocol)
			{
				_bonusItems.Add(new OEMTakerBonusItem
				{
					Item = item3,
					Type = eOEMTakeBonusType.CriticalHit,
					Obtained = true
				});
			}
		}
		else if (flag)
		{
			KeyValuePair<string, int> criticalBonus = bonus.GetCriticalBonus();
			_bonusItems.Add(new OEMTakerBonusItem
			{
				Item = new RItem
				{
					ItemId = criticalBonus.Key,
					cnt = criticalBonus.Value
				},
				Type = eOEMTakeBonusType.CriticalHit,
				Obtained = false
			});
		}
		if (TitanBonus_ToProtocol != null)
		{
			foreach (RItem item4 in TitanBonus_ToProtocol)
			{
				_bonusItems.Add(new OEMTakerBonusItem
				{
					Item = item4,
					Type = eOEMTakeBonusType.Talent,
					Obtained = true
				});
			}
		}
		else if (flag)
		{
			KeyValuePair<string, int> titanBonus = bonus.GetTitanBonus();
			_bonusItems.Add(new OEMTakerBonusItem
			{
				Item = new RItem
				{
					ItemId = titanBonus.Key,
					cnt = titanBonus.Value
				},
				Type = eOEMTakeBonusType.Talent,
				Obtained = false
			});
		}
		if (OtherBonus_ToProtocol != null)
		{
			foreach (RItem item5 in OtherBonus_ToProtocol)
			{
				_bonusItems.Add(new OEMTakerBonusItem
				{
					Item = item5,
					Type = eOEMTakeBonusType.Contribution,
					Obtained = true
				});
			}
		}
		return _bonusItems;
	}

	public int GetBonusContributionPoint(int ampIdx)
	{
		List<OEMTakerBonusItem> bonusItems = BonusItems(ampIdx);
		return GetOemTakerContributionScore(bonusItems);
	}

	public static int GetOemTakerContributionScore(List<OEMTakerBonusItem> bonusItems)
	{
		int num = 0;
		foreach (OEMTakerBonusItem bonusItem in bonusItems)
		{
			if (bonusItem.Obtained && bonusItem.Item.ItemId == "ContributionPoint")
			{
				num += bonusItem.Item.cnt;
			}
		}
		return num;
	}
}
