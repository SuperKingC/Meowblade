using System;
using System.Collections.Generic;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using ProtoBuf;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using UnityEngine;

namespace Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.NPC;

[ProtoContract]
public class C2S_GetNPCShop : SocketManager.BaseSocketPackageBodyContext
{
	[ProtoContract]
	public class Request : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int MUID;

		[ProtoMember(2)]
		public bool FirstOpen;
	}

	[ProtoContract]
	public class Response : SocketManager.BaseSocketPackageBody
	{
		[ProtoMember(1)]
		public int ErrorCode;

		[ProtoMember(2, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.NPCShopModel_ToProtocol")]
		public List<NPCShopModel_ToProtocol> NPCShopModels;

		[ProtoMember(3, TypeName = "Shift.Legion.GvG.Common.Models.GvGMode3.LastestBuyRecord")]
		public LastestBuyRecord LastestBuyRecord;

		[ProtoMember(4)]
		public bool UserBuyLastestYet;

		[ProtoMember(5)]
		public int NValue;

		[ProtoMember(6)]
		public string LastestShopItem;

		public void GetNpcText(GvGMode3EventMissionConfigModel eventConfig, Action<string> onFinished)
		{
			if (LastestBuyRecord == null)
			{
				onFinished?.Invoke(eventConfig.NpcShopText1.ToLanguage());
				return;
			}
			GvGMode3ShopEventFormulaConfigModel gvGMode3ShopEventFormulaConfigModel = GvG3FlagShipMissionsConfigHelper.EventShopFormulas(LastestShopItem);
			string itemName = gvGMode3ShopEventFormulaConfigModel.StoreItemName;
			int selfUserId = GameController.Contexts.gameState.user.value.UserId;
			int num = (int)GameController.Instance.GetServerTime() - (int)LastestBuyRecord.Timestamp_ms / 1000;
			int minutes = Mathf.Max(1, num / 60);
			int itemCnt = LastestBuyRecord.BuyCnt;
			GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions($"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}", LastestBuyRecord.UserId, delegate(UserProfile profile)
			{
				string text = profile?.Name;
				if (UserBuyLastestYet)
				{
					onFinished?.Invoke((selfUserId != LastestBuyRecord.UserId) ? string.Format(eventConfig.NpcShopText2.ToLanguage(), itemName, minutes, text, itemCnt) : string.Format(eventConfig.NpcShopText3.ToLanguage(), new object[2] { itemName, itemCnt }));
				}
				else
				{
					onFinished?.Invoke((itemCnt < NValue) ? string.Format(eventConfig.NpcShopText4, itemName, minutes, text, itemCnt) : string.Format(eventConfig.NpcShopText5, minutes, text, itemCnt, itemName));
				}
			}));
		}
	}

	public C2S_GetNPCShop()
	{
		base.PackageId = SocketManager.ePackageId.C2S_GetNPCShop;
		base.Resp = new Response();
		base.Req = new Request();
	}
}
