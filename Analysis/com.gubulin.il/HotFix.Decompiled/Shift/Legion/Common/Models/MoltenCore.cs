using System;
using Shift.Legion.Common.Managers;

namespace Shift.Legion.Common.Models;

public class MoltenCore : WorkShop
{
	public new object Controller;

	private float _baseRebateRate = -1f;

	public float BaseRebateRate
	{
		get
		{
			if (_baseRebateRate < 0f)
			{
				if (FeatureConfig != null && FeatureConfig.TryGetValue("RebateRate", out var value))
				{
					_baseRebateRate = Convert.ToSingle(value);
				}
				else
				{
					_baseRebateRate = 0.01f;
				}
			}
			return _baseRebateRate;
		}
	}

	public MoltenCore(GameManagers managers, Config<WorkShopConfig> config)
		: base(managers, config)
	{
	}

	public override ActionResult FinishUpgrade()
	{
		return base.FinishUpgrade();
	}
}
