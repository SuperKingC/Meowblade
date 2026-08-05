using System;
using System.Collections.Generic;
using Shift.Legion.ClientApi.Protocol.Store;

namespace Shift.Legion.ClientApi.Protocol.UserAction;

public class SimpleDynamicPromotionActivity
{
	public string ActivityId;

	public string ActivityName;

	public string PageName;

	public StoreItem[] StoreItems;

	public string Desc;

	public List<DateTimeOffset> BeginTime;

	public List<DateTimeOffset> EndTime;

	public List<string> LevelCase;
}
