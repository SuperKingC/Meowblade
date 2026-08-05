using System.Collections.Generic;
using System.Linq;
using GameDataEditor;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using ProtoBuf;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Enums;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;

[ProtoContract]
public class C2S_GetContributionItemInfo : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int non;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2)]
		public string JsonContributionInfo;

		[ProtoMember(3)]
		public bool YesterdayClaimed;

		[ProtoMember(4)]
		public string ContributionBoxConfig;

		[ProtoMember(5)]
		public string DailySupplyBoxConfig;

		[ProtoMember(6)]
		public int 每日补给NextClaimTimestamp;

		private List<ContributionBoxConfig> _contributionBoxConfig;

		private List<Contribution> _contributionInfo;

		private List<string> _contributionBoxItems;

		private List<Contribution> _contributionInfo_NoBattlePass;

		public string DailySupplyBoxItemId => DailySupplyBoxConfig;

		public List<ContributionBoxConfig> ContributionBoxConfigData
		{
			get
			{
				if (_contributionBoxConfig != null)
				{
					return _contributionBoxConfig;
				}
				GDEConfigurationData gDEConfigurationData = GDMgr.Get<GDEConfigurationData>(ContributionBoxConfig);
				_contributionBoxConfig = JsonHelper.ToObject<List<ContributionBoxConfig>>(gDEConfigurationData.Config);
				return _contributionBoxConfig;
			}
		}

		public List<Contribution> ContributionInfo
		{
			get
			{
				if (_contributionInfo != null)
				{
					return _contributionInfo;
				}
				if (string.IsNullOrEmpty(JsonContributionInfo))
				{
					return null;
				}
				ContributionsWrapper contributionsWrapper = JsonHelper.ToObject<ContributionsWrapper>(JsonContributionInfo);
				_contributionInfo = new List<Contribution>();
				foreach (ContributionWrapper contribution in contributionsWrapper.Contributions)
				{
					_contributionInfo.Add(new Contribution
					{
						Key = contribution.Key.ToString(),
						Value = contribution.Value
					});
				}
				return _contributionInfo;
			}
		}

		public long TotalContributionScore => TotalScore();

		public string ContributionBoxIcon
		{
			get
			{
				string result = string.Empty;
				if (ContributionInfo == null)
				{
					return result;
				}
				long totalContributionScore = TotalContributionScore;
				for (int i = 0; i < ContributionBoxConfigData.Count; i++)
				{
					ContributionBoxConfig contributionBoxConfig = ContributionBoxConfigData[i];
					if (contributionBoxConfig.Min <= (float)totalContributionScore && contributionBoxConfig.Max > (float)totalContributionScore)
					{
						result = $"ui://GvGFlagship3/Box{i + 1}";
						break;
					}
				}
				return result;
			}
		}

		public List<string> ContributionBoxItems
		{
			get
			{
				if (_contributionBoxItems != null)
				{
					return _contributionBoxItems;
				}
				long totalContributionScore = TotalContributionScore;
				foreach (ContributionBoxConfig contributionBoxConfigDatum in ContributionBoxConfigData)
				{
					if (!(contributionBoxConfigDatum.Min <= (float)totalContributionScore) || !(contributionBoxConfigDatum.Max > (float)totalContributionScore))
					{
						continue;
					}
					_contributionBoxItems = new List<string>(contributionBoxConfigDatum.Items.Keys.ToList());
					break;
				}
				return _contributionBoxItems;
			}
		}

		public List<Contribution> ContributionInfo_NoBattlePass
		{
			get
			{
				if (_contributionInfo_NoBattlePass != null)
				{
					return _contributionInfo_NoBattlePass;
				}
				if (string.IsNullOrEmpty(JsonContributionInfo))
				{
					return null;
				}
				ContributionsWrapper contributionsWrapper = JsonHelper.ToObject<ContributionsWrapper>(JsonContributionInfo);
				_contributionInfo_NoBattlePass = new List<Contribution>();
				foreach (ContributionWrapper contribution in contributionsWrapper.Contributions)
				{
					if (contribution.Key != eContributionKey.BuyForBattlePass)
					{
						_contributionInfo_NoBattlePass.Add(new Contribution
						{
							Key = contribution.Key.ToString(),
							Value = contribution.Value
						});
					}
				}
				return _contributionInfo_NoBattlePass;
			}
		}

		public float TotalContributionScore_NoBattlePass => TotalScore_NoBattlePass();

		public int DailySupplyStatus()
		{
			if (每日补给NextClaimTimestamp < 0)
			{
				return 0;
			}
			return ((int)GameController.Instance.GetServerTime() > 每日补给NextClaimTimestamp) ? 1 : 2;
		}

		private long TotalScore()
		{
			long num = 0L;
			foreach (Contribution item in ContributionInfo)
			{
				num += item.Value;
			}
			return num;
		}

		private float TotalScore_NoBattlePass()
		{
			float num = 0f;
			foreach (Contribution item in ContributionInfo_NoBattlePass)
			{
				num += (float)item.Value;
			}
			return num;
		}

		public bool DailyRewardShowRedDot()
		{
			int num = (int)TotalContributionScore;
			return (!YesterdayClaimed && num > 0 && Singleton<WorldStateManager>.Instance.Data.UserPlayDays != 1) || DailySupplyStatus() == 1;
		}
	}

	public C2S_GetContributionItemInfo()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetContributionItemInfo;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
