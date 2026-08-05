using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model;
using ProtoBuf;
using Shift.Legion.Common.Managers;
using Shift.Legion.Helpers;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.FlagShip;

[ProtoContract]
public class C2S_GetAllContributionExcludingBuy : SocketManager.BaseSocketPackageBodyContext
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

		private List<Contribution> _contributionInfo;

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
						Key = $"GvG3Contribution_{contribution.Key}".ToLanguage(),
						Value = contribution.Value
					});
				}
				return _contributionInfo;
			}
		}
	}

	public C2S_GetAllContributionExcludingBuy()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetAllContributionExcludingBuy;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
