using System.Collections.Generic;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

public class ReceiveChannelMessages
{
	public bool IsPush;

	public long? StartId { get; set; }

	public eChatUiChannel Channel { get; set; }

	public List<GvGMode3ChatRecord> ChatRecords { get; set; }
}
