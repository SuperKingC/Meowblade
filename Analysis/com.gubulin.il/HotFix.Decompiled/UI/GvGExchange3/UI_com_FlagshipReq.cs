using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvG.Common.Models;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using UI.Tips;

namespace UI.GvGExchange3;

public class UI_com_FlagshipReq : GComponent
{
	public Controller Requirement;

	public GImage n9;

	public GImage n13;

	public GList Reqs;

	public UI_com_Scroll ListScroll;

	public GTextField n3;

	public GTextField n4;

	public GTextField n5;

	public GTextField n6;

	public GTextField n7;

	public GImage n8;

	public GGroup n10;

	public GImage n12;

	public GTextField FirstDayTip;

	public GTextField EmptyTip;

	public const string URL = "ui://tt2iq07odwxte";

	public static string Name = "UI_com_FlagshipReq";

	public static string GetURL()
	{
		return "ui://tt2iq07odwxte";
	}

	public static UI_com_FlagshipReq CreateInstance()
	{
		return (UI_com_FlagshipReq)(object)UIPackage.CreateObject("GvGExchange3", "com_FlagshipReq");
	}

	public static UI_com_FlagshipReq CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FlagshipReq).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odwxte", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected O, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Requirement = ((GComponent)this).GetController("Requirement");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		Reqs = (GList)((GComponent)this).GetChild("Reqs");
		ListScroll = (UI_com_Scroll)(object)((GComponent)this).GetChild("ListScroll");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://tt2iq07odwxte".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://tt2iq07odwxte".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id3 = "ui://tt2iq07odwxte".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id3);
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id4 = "ui://tt2iq07odwxte".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id4);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id5 = "ui://tt2iq07odwxte".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id5);
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n10 = (GGroup)((GComponent)this).GetChild("n10");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		FirstDayTip = (GTextField)((GComponent)this).GetChild("FirstDayTip");
		string id6 = "ui://tt2iq07odwxte".Replace("ui://", "") + "-" + ((GObject)FirstDayTip).id;
		((GObject)FirstDayTip).text = LanguagesManager.GetDesc(id6);
		EmptyTip = (GTextField)((GComponent)this).GetChild("EmptyTip");
		string id7 = "ui://tt2iq07odwxte".Replace("ui://", "") + "-" + ((GObject)EmptyTip).id;
		((GObject)EmptyTip).text = LanguagesManager.GetDesc(id7);
	}

	public void Init()
	{
		Reqs.SetVirtual();
		Singleton<GvG3FlagshipReqManager>.Instance.GetFlagshipMissions(Renderer);
	}

	public void Destroy()
	{
	}

	public void Renderer(FlagshipMissions missions)
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		List<FlagShipReqMission_ToProtocol> missionList = missions.Missions.Where((FlagShipReqMission_ToProtocol mission) => mission.FinishCount < mission.FinishMaxCount).ToList();
		Reqs.itemRenderer = new ListItemRenderer(MissionRenderer);
		Reqs.numItems = missionList.Count;
		Requirement.selectedIndex = ((missionList.Count <= 0) ? 1 : 0);
		DisplayEmptyTip();
		void DisplayEmptyTip()
		{
			if (Requirement.selectedIndex != 0)
			{
				((GObject)FirstDayTip).visible = Singleton<WorldStateManager>.Instance.Data.PlayerFlagshipInfo.FlagShipMissionLastRefreshTimestamp <= 0;
				((GObject)EmptyTip).visible = Singleton<WorldStateManager>.Instance.Data.PlayerFlagshipInfo.FlagShipMissionLastRefreshTimestamp > 0;
			}
		}
		void MissionRenderer(int index, GObject obj)
		{
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Expected O, but got Unknown
			if (obj is UI_com_FlagshipMission uI_com_FlagshipMission)
			{
				FlagShipReqMission_ToProtocol flagShipReqMission_ToProtocol = missionList[index];
				((GObject)uI_com_FlagshipMission.MissionName).text = flagShipReqMission_ToProtocol.MissionName;
				((GObject)uI_com_FlagshipMission.MissionTimes).text = $"{flagShipReqMission_ToProtocol.FinishMaxCount - flagShipReqMission_ToProtocol.FinishCount}/{flagShipReqMission_ToProtocol.FinishMaxCount}";
				bool flag = RequirementsRenderer(uI_com_FlagshipMission.Requirements, flagShipReqMission_ToProtocol.Requirements);
				RequirementsRenderer(uI_com_FlagshipMission.Bonus, flagShipReqMission_ToProtocol.Rewards, isReward: true);
				uI_com_FlagshipMission.Type.selectedIndex = ((!flag) ? 1 : 0);
				((GObject)uI_com_FlagshipMission.Submit).data = flagShipReqMission_ToProtocol.Uid;
				((GObject)uI_com_FlagshipMission.Submit).onClick.Set(new EventCallback1(SubmitMission));
			}
		}
		static bool RequirementsRenderer(GList list, List<RItem> items, bool isReward = false)
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			bool enough = true;
			list.itemRenderer = new ListItemRenderer(ItemRender);
			list.numItems = items.Count;
			return enough;
			void ItemRender(int index, GObject obj)
			{
				if (obj is UI_com_ExchangeItem uI_com_ExchangeItem)
				{
					RItem rItem = items[index];
					if (isReward)
					{
						((GObject)uI_com_ExchangeItem.BonusCnt).text = rItem.cnt.ToString();
					}
					else
					{
						((GObject)uI_com_ExchangeItem.ReqCnt).text = rItem.cnt.ToString();
					}
					uI_com_ExchangeItem.IsBonus.selectedIndex = (isReward ? 1 : 0);
					int num = 0;
					if (!isReward)
					{
						num = Singleton<GvGStoreHouseManager>.Instance.GetItemCount(rItem.ItemId, includingGSStock: true);
					}
					bool flag = isReward || num >= rItem.cnt;
					uI_com_ExchangeItem.Enough.selectedIndex = ((!flag) ? 1 : 0);
					enough &= flag;
					FGUIManager.Instance.SetItemIconAndFrame(uI_com_ExchangeItem.Icon, rItem.ItemId, null, "", isReward);
					uI_com_ExchangeItem.Icon.InitMaterialIntroductionBtn(rItem.ItemId);
				}
			}
		}
	}

	private void SubmitMission(EventContext context)
	{
		int muid = (int)((GObject)(UI_com_FlagshipMission)(object)context.sender).data;
		Singleton<GvG3FlagshipReqManager>.Instance.SubmitFlagshipMission(muid);
	}
}
