using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FairyGUI;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvGServer.Models.Map;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

public class GvGIZConfigModel
{
	public string IZConfigId;

	public string Title;

	public string Desc;

	public string CostTime;

	public string LevelDegree;

	public string ProfitDegree;

	public List<RItem> Rewards;

	public List<RItem> SpecialRewards;

	public List<RItem> SpecialRewards2;

	public int ProcessCount;

	public List<GvGProcessInfo> Processes;

	public void UpdateRoomsData(Action onSuccess)
	{
		ILRequestHelper<GetGvGMode3ProcessByIZConfigIdResponse>.Request((EventContext)null, (Func<Task<GetGvGMode3ProcessByIZConfigIdResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetGvGMode3ProcessByIZConfigId(IZConfigId)), (Action<GetGvGMode3ProcessByIZConfigIdResponse>)delegate(GetGvGMode3ProcessByIZConfigIdResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				Processes = response.Processes ?? new List<GvGProcessInfo>();
				onSuccess();
			}
		});
	}
}
