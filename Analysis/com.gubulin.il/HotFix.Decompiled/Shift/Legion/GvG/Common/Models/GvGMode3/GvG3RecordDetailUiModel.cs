using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.GvG.Common.Models.Battle;
using Shift.Legion.GvG.Common.Models.BattleLog;

namespace Shift.Legion.GvG.Common.Models.GvGMode3;

public class GvG3RecordDetailUiModel
{
	public string RecordLevelId { get; set; }

	public BattleLogShipInfo RedInfo { get; set; }

	public BattleLogShipInfo BlueInfo { get; set; }

	public GvGMode3CalcBattleParams BattleParams { get; set; }

	public BattleRecordDetailModel RedDetailData { get; set; }

	public BattleRecordDetailModel BlueDetailData { get; set; }

	public GetGvGBattleResultResponse BattleResult { get; set; }

	public bool CheckDataIntegrity => !string.IsNullOrEmpty(RecordLevelId) && RedInfo != null && BlueInfo != null && BattleParams != null && RedDetailData != null && BlueDetailData != null && BattleResult != null;
}
