using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Medal;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UnityEngine;

namespace UI.GvGExpeditionHall;

public class UI_com_AvatarFramesPanel : GComponent
{
	private enum ProfileCheck
	{
		None,
		Checked
	}

	public GGraph n14;

	public GImage n0;

	public GImage n1;

	public GImage n13;

	public GList Medals;

	public GTextField PlayerName;

	public UI_RedDot RedDot;

	public GComponent Avatar;

	public GImage n15;

	public GImage PendingMark;

	public const string URL = "ui://k19peou7pc8xp76";

	public static string Name = "UI_com_AvatarFramesPanel";

	private const string _GVG3_PROFILE_CHECKED = "GvG3ProfileChecked";

	private List<GvGMedalRecord> _medalRecords = new List<GvGMedalRecord>();

	private int MyUserId => GameController.Contexts.gameState.user.value.UserId;

	public static string GetURL()
	{
		return "ui://k19peou7pc8xp76";
	}

	public static UI_com_AvatarFramesPanel CreateInstance()
	{
		return (UI_com_AvatarFramesPanel)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_AvatarFramesPanel");
	}

	public static UI_com_AvatarFramesPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AvatarFramesPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7pc8xp76", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n14 = (GGraph)((GComponent)this).GetChild("n14");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		Medals = (GList)((GComponent)this).GetChild("Medals");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		RedDot = (UI_RedDot)(object)((GComponent)this).GetChild("RedDot");
		Avatar = (GComponent)((GComponent)this).GetChild("Avatar");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		PendingMark = (GImage)((GComponent)this).GetChild("PendingMark");
	}

	public void Init()
	{
		RenderNoEnterIzProfile();
		SetRedDotVisible();
		OnInit();
	}

	private void OnInit()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((GObject)this).onClick.Set(new EventCallback0(OnClick));
		SharedMessenger.AddListener("USER_PROFILE_CHANGE", RenderNoEnterIzProfile);
	}

	public void OnDestroy()
	{
		SharedMessenger.RemoveListener("USER_PROFILE_CHANGE", RenderNoEnterIzProfile);
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
		FGUIManager.Instance.ReleaseGloaderTexture2D(UI_com_AvatarPopup.Name);
	}

	private void OnClick()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		FairyGUITip.ShowTip<UI_com_AvatarPopup>(null, eFairyGUITipDir.None, RenderPopup);
		ChangeRedDotVisibleAndRecordCheck();
		void RenderPopup(UI_com_AvatarPopup popup)
		{
			popup.Load(_medalRecords);
		}
	}

	private void ChangeRedDotVisibleAndRecordCheck()
	{
		if (((GObject)RedDot).visible)
		{
			((GObject)RedDot).visible = false;
			GameLocalDataManager.SetInt("GvG3ProfileChecked", 1);
		}
	}

	private void RenderNoEnterIzProfile()
	{
		FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.GetUserNickName(MyUserId, PlayerName));
		RenderNoEnterIzAvatar();
		RenderNoEnterIzMedals();
	}

	private void RenderNoEnterIzAvatar()
	{
		GLoader asLoader = Avatar.GetChild("HeadPortrait").asCom.GetChild("icon").asLoader;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.SetSelfImageByWebRequestAndStorage(Name, asLoader, ShowAvatarPending));
		void ShowAvatarPending()
		{
			((GObject)PendingMark).visible = true;
		}
	}

	private void RenderNoEnterIzMedals()
	{
		ILRequestHelper<GetGvGMedalRecordResponse>.Request((EventContext)null, (Func<Task<GetGvGMedalRecordResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetGvGMedalRecord()), (Action<GetGvGMedalRecordResponse>)delegate(GetGvGMedalRecordResponse response)
		{
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				_medalRecords = (string.IsNullOrEmpty(response.JsonGvGMedalRecord) ? new List<GvGMedalRecord>() : JsonHelper.ToObject<List<GvGMedalRecord>>(response.JsonGvGMedalRecord));
				_medalRecords = _medalRecords.Where((GvGMedalRecord mr) => mr.IsShowing).ToList();
				_medalRecords.Sort(SortMedals);
				GComponentExtension.RenderMedals(Medals, _medalRecords);
			}
		});
	}

	private int SortMedals(GvGMedalRecord a, GvGMedalRecord b)
	{
		int num = b.Config.Rarity - a.Config.Rarity;
		if (num != 0)
		{
			return num;
		}
		return a.Config.Index - b.Config.Index;
	}

	private void SetRedDotVisible()
	{
		((GObject)RedDot).visible = GameLocalDataManager.GetInt("GvG3ProfileChecked") == 0;
	}
}
