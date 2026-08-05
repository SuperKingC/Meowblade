using System;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models;
using UnityEngine;

namespace UI.SpecialActivity;

public class UI_PlayerReturnActivityPanel : GComponent
{
	public class RecallPlayerBonusConfig
	{
		public RecallConfig RecallConfig;
	}

	public class RecallConfig
	{
		public int OfflineDays;

		public int ClaimBonusLimit;
	}

	public Controller Type;

	public Controller IsClaimed;

	public Controller InviterType;

	public GImage back;

	public GTextField OpenTime;

	public GTextField n28;

	public GTextField n30;

	public GTextField LastRecordTime;

	public GTextField ReturnTime;

	public GTextField n39;

	public GImage n56;

	public GGroup n40;

	public GTextField n33;

	public GTextField n34;

	public GTextField OfflineDays;

	public GTextField n36;

	public GTextField ChapterName;

	public GImage n55;

	public GGroup n38;

	public GTextField n63;

	public GImage n64;

	public GGroup n65;

	public GTextField n41;

	public UI_com_MyInviteCode MyInviteCode;

	public UI_btn_CopyInviteCode CopyInviteCodeBtn;

	public UI_com_InputInviteCode InputInviteCode;

	public UI_btn_Submit SubmitBtn;

	public UI_btn_RewardDetail RewardDetail;

	public GTextField InviterClaimedRewards;

	public UI_com_Reward ReturnerReward;

	public GTextField n53;

	public GTextField n57;

	public GImage n61;

	public GImage n62;

	public GImage n59;

	public GImage n60;

	public Transition t0;

	public const string URL = "ui://kozswd8hpl78f3s";

	public static string Name = "UI_PlayerReturnActivityPanel";

	private PlayerReturnActivity Data;

	private string InviterClaimedRewardsTemplate;

	private RecallPlayerBonusConfig Config;

	private int OfflineDays_ToDisplay => (Data.PlayerInfo.RecallTime - Data.PlayerInfo.LastActiveTime).Days + 1;

	public static string GetURL()
	{
		return "ui://kozswd8hpl78f3s";
	}

	public static UI_PlayerReturnActivityPanel CreateInstance()
	{
		return (UI_PlayerReturnActivityPanel)(object)UIPackage.CreateObject("SpecialActivity", "PlayerReturnActivityPanel");
	}

	public static UI_PlayerReturnActivityPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PlayerReturnActivityPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hpl78f3s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Expected O, but got Unknown
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected O, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected O, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Expected O, but got Unknown
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected O, but got Unknown
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Expected O, but got Unknown
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Expected O, but got Unknown
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a7: Expected O, but got Unknown
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Expected O, but got Unknown
		//IL_055d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0567: Expected O, but got Unknown
		//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Expected O, but got Unknown
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d2: Expected O, but got Unknown
		//IL_05de: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Expected O, but got Unknown
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fe: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		IsClaimed = ((GComponent)this).GetController("IsClaimed");
		InviterType = ((GComponent)this).GetController("InviterType");
		back = (GImage)((GComponent)this).GetChild("back");
		OpenTime = (GTextField)((GComponent)this).GetChild("OpenTime");
		string id = "ui://kozswd8hpl78f3s".Replace("ui://", "") + "-" + ((GObject)OpenTime).id;
		((GObject)OpenTime).text = LanguagesManager.GetDesc(id);
		n28 = (GTextField)((GComponent)this).GetChild("n28");
		string id2 = "ui://kozswd8hpl78f3s".Replace("ui://", "") + "-" + ((GObject)n28).id;
		((GObject)n28).text = LanguagesManager.GetDesc(id2);
		n30 = (GTextField)((GComponent)this).GetChild("n30");
		string id3 = "ui://kozswd8hpl78f3s".Replace("ui://", "") + "-" + ((GObject)n30).id;
		((GObject)n30).text = LanguagesManager.GetDesc(id3);
		LastRecordTime = (GTextField)((GComponent)this).GetChild("LastRecordTime");
		ReturnTime = (GTextField)((GComponent)this).GetChild("ReturnTime");
		n39 = (GTextField)((GComponent)this).GetChild("n39");
		string id4 = "ui://kozswd8hpl78f3s".Replace("ui://", "") + "-" + ((GObject)n39).id;
		((GObject)n39).text = LanguagesManager.GetDesc(id4);
		n56 = (GImage)((GComponent)this).GetChild("n56");
		n40 = (GGroup)((GComponent)this).GetChild("n40");
		n33 = (GTextField)((GComponent)this).GetChild("n33");
		string id5 = "ui://kozswd8hpl78f3s".Replace("ui://", "") + "-" + ((GObject)n33).id;
		((GObject)n33).text = LanguagesManager.GetDesc(id5);
		n34 = (GTextField)((GComponent)this).GetChild("n34");
		string id6 = "ui://kozswd8hpl78f3s".Replace("ui://", "") + "-" + ((GObject)n34).id;
		((GObject)n34).text = LanguagesManager.GetDesc(id6);
		OfflineDays = (GTextField)((GComponent)this).GetChild("OfflineDays");
		n36 = (GTextField)((GComponent)this).GetChild("n36");
		string id7 = "ui://kozswd8hpl78f3s".Replace("ui://", "") + "-" + ((GObject)n36).id;
		((GObject)n36).text = LanguagesManager.GetDesc(id7);
		ChapterName = (GTextField)((GComponent)this).GetChild("ChapterName");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n38 = (GGroup)((GComponent)this).GetChild("n38");
		n63 = (GTextField)((GComponent)this).GetChild("n63");
		string id8 = "ui://kozswd8hpl78f3s".Replace("ui://", "") + "-" + ((GObject)n63).id;
		((GObject)n63).text = LanguagesManager.GetDesc(id8);
		n64 = (GImage)((GComponent)this).GetChild("n64");
		n65 = (GGroup)((GComponent)this).GetChild("n65");
		n41 = (GTextField)((GComponent)this).GetChild("n41");
		string id9 = "ui://kozswd8hpl78f3s".Replace("ui://", "") + "-" + ((GObject)n41).id;
		((GObject)n41).text = LanguagesManager.GetDesc(id9);
		MyInviteCode = (UI_com_MyInviteCode)(object)((GComponent)this).GetChild("MyInviteCode");
		CopyInviteCodeBtn = (UI_btn_CopyInviteCode)(object)((GComponent)this).GetChild("CopyInviteCodeBtn");
		InputInviteCode = (UI_com_InputInviteCode)(object)((GComponent)this).GetChild("InputInviteCode");
		SubmitBtn = (UI_btn_Submit)(object)((GComponent)this).GetChild("SubmitBtn");
		RewardDetail = (UI_btn_RewardDetail)(object)((GComponent)this).GetChild("RewardDetail");
		InviterClaimedRewards = (GTextField)((GComponent)this).GetChild("InviterClaimedRewards");
		string id10 = "ui://kozswd8hpl78f3s".Replace("ui://", "") + "-" + ((GObject)InviterClaimedRewards).id;
		((GObject)InviterClaimedRewards).text = LanguagesManager.GetDesc(id10);
		ReturnerReward = (UI_com_Reward)(object)((GComponent)this).GetChild("ReturnerReward");
		n53 = (GTextField)((GComponent)this).GetChild("n53");
		string id11 = "ui://kozswd8hpl78f3s".Replace("ui://", "") + "-" + ((GObject)n53).id;
		((GObject)n53).text = LanguagesManager.GetDesc(id11);
		n57 = (GTextField)((GComponent)this).GetChild("n57");
		string id12 = "ui://kozswd8hpl78f3s".Replace("ui://", "") + "-" + ((GObject)n57).id;
		((GObject)n57).text = LanguagesManager.GetDesc(id12);
		n61 = (GImage)((GComponent)this).GetChild("n61");
		n62 = (GImage)((GComponent)this).GetChild("n62");
		n59 = (GImage)((GComponent)this).GetChild("n59");
		n60 = (GImage)((GComponent)this).GetChild("n60");
		t0 = ((GComponent)this).GetTransition("t0");
	}

	public void Init()
	{
		if (InviterClaimedRewardsTemplate == null)
		{
			InviterClaimedRewardsTemplate = ((GObject)InviterClaimedRewards).text;
		}
		if (Config == null)
		{
			Config = "RecallPlayerBonusConfig".ToConfiguration<RecallPlayerBonusConfig>();
		}
		Update();
	}

	public void RegisterUIEvent()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GObject)RewardDetail).onClick.Set(new EventCallback1(OpenRewardDetailPanel));
		((GObject)SubmitBtn).onClick.Set(new EventCallback1(OnSubmitInviteCode));
		((GObject)CopyInviteCodeBtn).onClick.Set(new EventCallback0(OnCopyInviteCodeToClicpboard));
	}

	public void UnregisterUIEvent()
	{
		((GObject)RewardDetail).onClick.Clear();
		((GObject)SubmitBtn).onClick.Clear();
		((GObject)CopyInviteCodeBtn).onClick.Clear();
	}

	private void OpenRewardDetailPanel(EventContext context)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_HelpPanel.Name, null);
	}

	private void OnSubmitInviteCode(EventContext context)
	{
		string inviteCode = ((GObject)InputInviteCode.Input).text;
		ILRequestHelper<ClaimRecallPlayerResponse>.Request((EventContext)null, (Func<Task<ClaimRecallPlayerResponse>>)(() => GameController.Contexts.Service<INetworkService>().ClaimRecallPlayer(inviteCode)), (Action<ClaimRecallPlayerResponse>)delegate(ClaimRecallPlayerResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				IsClaimed.selectedIndex = 1;
				FGUIManager.Instance.GetPlayerReturnActivity(null, mustUpdateData: true);
			}
		});
	}

	private void OnCopyInviteCodeToClicpboard()
	{
		GUIUtility.systemCopyBuffer = GameController.Contexts.gameState.user.value.InvitingCode;
		"CopyInviteCodeTip".ToShowLanguageTip();
	}

	private void Update()
	{
		Data = FGUIManager.Instance.PlayerReturnActivity;
		if (Data != null)
		{
			RenderActivityTime();
			RenderReturnTime();
			RenderPlayerInfo();
		}
	}

	private void RenderActivityTime()
	{
		DateTimeOffset dateTimeOffset = Data.Activity.BeginTime[0].ToOffset(DateTimeHelper.TimezoneOffset);
		DateTimeOffset dateTimeOffset2 = Data.Activity.EndTime[0].ToOffset(DateTimeHelper.TimezoneOffset);
		object[] args = new object[8]
		{
			dateTimeOffset.Year,
			dateTimeOffset.Month,
			dateTimeOffset.Day,
			$"{dateTimeOffset.Hour:D2}:{dateTimeOffset.Minute:D2}",
			dateTimeOffset2.Year,
			dateTimeOffset2.Month,
			dateTimeOffset2.Day,
			$"{dateTimeOffset2.Hour:D2}:{dateTimeOffset2.Minute:D2}"
		};
		((GObject)OpenTime).text = "PlayerReturnActivityTime".ToLanguage().Format(args);
	}

	private void RenderReturnTime()
	{
		DateTimeOffset dateTimeOffset = Data.PlayerInfo.LastActiveTime;
		if (Data.PlayerInfo.IsRecallPlayer && Data.PlayerInfo.ClaimRecallPlayerBonus)
		{
			dateTimeOffset = Data.PlayerInfo.RecallTime;
		}
		DateTimeOffset dateTimeOffset2 = dateTimeOffset.ToOffset(DateTimeHelper.TimezoneOffset);
		DateTimeOffset dateTimeOffset3 = Data.PlayerInfo.RecallTime.ToOffset(DateTimeHelper.TimezoneOffset);
		string richText = "PlayerReturnTimeTemplate".ToLanguage();
		((GObject)LastRecordTime).text = richText.Format(dateTimeOffset2.Year, dateTimeOffset2.Month, dateTimeOffset2.Day, $"{dateTimeOffset2.Hour:D2}", $"{dateTimeOffset2.Minute:D2}");
		((GObject)ReturnTime).text = richText.Format(dateTimeOffset3.Year, dateTimeOffset3.Month, dateTimeOffset3.Day, $"{dateTimeOffset3.Hour:D2}", $"{dateTimeOffset3.Minute:D2}");
	}

	private void RenderPlayerInfo()
	{
		if (Data.PlayerInfo.IsRecallPlayer && !Data.PlayerInfo.ClaimRecallPlayerBonus)
		{
			RenderReturnerPlayerInfo();
		}
		else
		{
			RenderInviterPlayerInfo();
		}
	}

	private void RenderReturnerPlayerInfo()
	{
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Expected O, but got Unknown
		Type.selectedIndex = 1;
		((GObject)OfflineDays).text = $"{OfflineDays_ToDisplay}";
		((GObject)ChapterName).text = Data.PlayerInfo.ProgressDesc.ToLanguage();
		if (Data.PlayerInfo.Bonus.Count > 0)
		{
			RItem bonus = Data.PlayerInfo.Bonus[0];
			((GObject)ReturnerReward.num).text = $"{bonus.cnt}";
			FGUIManager.Instance.SetItemIconAndFrame(ReturnerReward.icon, bonus.ItemId, null, "", frameVisible: false);
			((GObject)ReturnerReward).onClick.Set((EventCallback0)delegate
			{
				FGUIManager.Instance.ItemTip(bonus.ItemId, ((GObject)this).sortingOrder, noCheckBtn: true);
			});
		}
		else
		{
			ILRuntimeDebug.LogError("[RenderReturnerPlayerInfo] Data.PlayerInfo.Bonus为空");
		}
	}

	private void RenderInviterPlayerInfo()
	{
		Type.selectedIndex = 0;
		((GObject)InviterClaimedRewards).text = InviterClaimedRewardsTemplate.Format(Data.PlayerInfo.InviterClaimCount, Config.RecallConfig.ClaimBonusLimit);
		((GObject)MyInviteCode.InviteCode).text = GameController.Contexts.gameState.user.value.InvitingCode;
		bool flag = !Data.PlayerInfo.IsRecallPlayer && OfflineDays_ToDisplay > Config.RecallConfig.OfflineDays;
		InviterType.selectedIndex = (flag ? 1 : 0);
	}
}
