using System;
using System.Collections.Generic;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.ClientApi.Sources.Protocol.UserAction;

public class DynamicSecretTreasuryActivity
{
	private GetDynamicSecretTreasuryResponse _data;

	public DateTimeOffset BeginTime => DateTimeHelper.ParseTimeStamp(_data.StartTime).ToOffset(DateTimeHelper.TimezoneOffset);

	public DateTimeOffset EndTime => DateTimeHelper.ParseTimeStamp(_data.EndTime).ToOffset(DateTimeHelper.TimezoneOffset);

	public float ToTotalRecharge => _data.TotalCharged;

	public List<SecretTreasuryBonus> BonusConfigs => _data.BonusConfigs;

	public string ActivityBgUrl => _data.ImageUrl;

	public string ActivityDesc => _data.Desc;

	public DynamicSecretTreasuryActivity(GetDynamicSecretTreasuryResponse response)
	{
		_data = response;
	}

	public bool HasAnyInform()
	{
		if (_data.BonusConfigs == null)
		{
			return false;
		}
		float totalCharged = _data.TotalCharged;
		foreach (SecretTreasuryBonus bonusConfig in _data.BonusConfigs)
		{
			if ((float)bonusConfig.Level <= totalCharged && !bonusConfig.Claimed)
			{
				return true;
			}
		}
		return false;
	}

	public ArchiveExtension_DynamicActivity_LTTR.BonusState GetState(int level)
	{
		SecretTreasuryBonus secretTreasuryBonus = _data.BonusConfigs.Find((SecretTreasuryBonus x) => x.Level == level);
		if ((float)secretTreasuryBonus.Level <= _data.TotalCharged && !secretTreasuryBonus.Claimed)
		{
			return ArchiveExtension_DynamicActivity_LTTR.BonusState.Pending;
		}
		if (secretTreasuryBonus.Claimed)
		{
			return ArchiveExtension_DynamicActivity_LTTR.BonusState.Claimed;
		}
		return ArchiveExtension_DynamicActivity_LTTR.BonusState.Undergoing;
	}

	public void Claim(int level)
	{
		SecretTreasuryBonus secretTreasuryBonus = _data.BonusConfigs.Find((SecretTreasuryBonus x) => x.Level == level);
		secretTreasuryBonus.Claimed = true;
	}

	public bool IsEnable()
	{
		long serverTime = GameController.Instance.GetServerTime();
		bool flag = serverTime >= _data.StartTime && serverTime <= _data.EndTime;
		bool flag2 = true;
		if (_data.BonusConfigs != null)
		{
			foreach (SecretTreasuryBonus bonusConfig in _data.BonusConfigs)
			{
				if (!bonusConfig.Claimed)
				{
					flag2 = false;
					break;
				}
			}
		}
		return flag && !flag2;
	}
}
