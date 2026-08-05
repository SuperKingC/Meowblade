using Shift.Legion.Common.Models;
using Shift.Legion.Helpers;

namespace Shift.Legion.ClientApi.RPC.Api;

public class UserLoginCredentialsProto
{
	private StockConfig _GemValue = null;

	private StockConfig _MTGValue = null;

	private StockConfig _ManPowerValue = null;

	public int UserId { get; set; }

	public string NickName { get; set; }

	public string UserLevel { get; set; }

	public string Gem { get; set; }

	public StockConfig GemValue
	{
		get
		{
			if (_GemValue == null)
			{
				_GemValue = JsonHelper.ToObject<StockConfig>(Gem);
			}
			if (_GemValue == null)
			{
				_GemValue = new StockConfig
				{
					Stock = 0
				};
			}
			return _GemValue;
		}
	}

	public string MTG { get; set; }

	public StockConfig MTGValue
	{
		get
		{
			if (_MTGValue == null)
			{
				_MTGValue = JsonHelper.ToObject<StockConfig>(MTG);
			}
			if (_MTGValue == null)
			{
				_MTGValue = new StockConfig
				{
					Stock = 0
				};
			}
			return _MTGValue;
		}
	}

	public string ManPower { get; set; }

	public StockConfig ManPowerValue
	{
		get
		{
			if (_ManPowerValue == null)
			{
				_ManPowerValue = JsonHelper.ToObject<StockConfig>(ManPower);
			}
			if (_ManPowerValue == null)
			{
				_ManPowerValue = new StockConfig
				{
					Stock = 0
				};
			}
			return _ManPowerValue;
		}
	}

	public string CurrentMaxLegionPower { get; set; }
}
