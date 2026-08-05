using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Medal;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Shift.Legion.Shift.Legion.Common.Sources.Extensions;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UI.AccountInfo;
using UI.GvG3Medal;
using UnityEngine;

namespace UI.GvGExpeditionHall;

public class UI_com_AvatarPopup : GComponent
{
	public Controller AvatarIsPending;

	public Controller EnterIz;

	public GGraph back;

	public GLoader n0;

	public UI_com_UserProfile ProfileDisplay;

	public GLoader ChangeProfileBg;

	public GLoader ChangeMedalBg;

	public UI_btn_GoTo GoToChnageProfile;

	public UI_btn_GoTo GoToChangeMedals;

	public GTextField n15;

	public GTextField n24;

	public GImage n25;

	public GImage n33;

	public GImage n37;

	public GImage n38;

	public GImage n39;

	public GGroup n34;

	public const string URL = "ui://k19peou7pc8xp7b";

	public static string Name = "UI_com_AvatarPopup";

	private List<GvGMedalRecord> _medalRecords;

	private int MyUserId => GameController.Contexts.gameState.user.value.UserId;

	public static string GetURL()
	{
		return "ui://k19peou7pc8xp7b";
	}

	public static UI_com_AvatarPopup CreateInstance()
	{
		return (UI_com_AvatarPopup)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_AvatarPopup");
	}

	public static UI_com_AvatarPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AvatarPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7pc8xp7b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		AvatarIsPending = ((GComponent)this).GetController("AvatarIsPending");
		EnterIz = ((GComponent)this).GetController("EnterIz");
		back = (GGraph)((GComponent)this).GetChild("back");
		n0 = (GLoader)((GComponent)this).GetChild("n0");
		ProfileDisplay = (UI_com_UserProfile)(object)((GComponent)this).GetChild("ProfileDisplay");
		ChangeProfileBg = (GLoader)((GComponent)this).GetChild("ChangeProfileBg");
		ChangeMedalBg = (GLoader)((GComponent)this).GetChild("ChangeMedalBg");
		GoToChnageProfile = (UI_btn_GoTo)(object)((GComponent)this).GetChild("GoToChnageProfile");
		GoToChangeMedals = (UI_btn_GoTo)(object)((GComponent)this).GetChild("GoToChangeMedals");
		n15 = (GTextField)((GComponent)this).GetChild("n15");
		string id = "ui://k19peou7pc8xp7b".Replace("ui://", "") + "-" + ((GObject)n15).id;
		((GObject)n15).text = LanguagesManager.GetDesc(id);
		n24 = (GTextField)((GComponent)this).GetChild("n24");
		string id2 = "ui://k19peou7pc8xp7b".Replace("ui://", "") + "-" + ((GObject)n24).id;
		((GObject)n24).text = LanguagesManager.GetDesc(id2);
		n25 = (GImage)((GComponent)this).GetChild("n25");
		n33 = (GImage)((GComponent)this).GetChild("n33");
		n37 = (GImage)((GComponent)this).GetChild("n37");
		n38 = (GImage)((GComponent)this).GetChild("n38");
		n39 = (GImage)((GComponent)this).GetChild("n39");
		n34 = (GGroup)((GComponent)this).GetChild("n34");
	}

	public void Load(List<GvGMedalRecord> medals = null)
	{
		((GObject)this).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		_medalRecords = medals;
		EnterIz.SetSelectedIndex(Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.HasEnterIZ ? 1 : 0);
		RenderNoEnterIzProfile();
		HandleEvent();
	}

	private void RenderNoEnterIzProfile()
	{
		FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.GetUserNickName(MyUserId, ProfileDisplay.PlayerName));
		RenderNoEnterIzAvatar();
		RenderNoEnterIzMedals();
	}

	private void RenderNoEnterIzAvatar()
	{
		GLoader asLoader = ProfileDisplay.Avatar.GetChild("HeadPortrait").asCom.GetChild("icon").asLoader;
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.SetSelfImageByWebRequestAndStorage(Name, asLoader, ShowAvatarPending));
		void ShowAvatarPending()
		{
			AvatarIsPending.SetSelectedIndex(1);
		}
	}

	private void RenderNoEnterIzMedals()
	{
		if (_medalRecords != null)
		{
			GComponentExtension.RenderMedals(ProfileDisplay.Medals, _medalRecords);
			return;
		}
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
				GComponentExtension.RenderMedals(ProfileDisplay.Medals, _medalRecords);
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

	private void HandleEvent()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		OnLoaded();
		((GObject)this).onRemovedFromStage.Set(new EventCallback0(OnDispose));
	}

	private void OnLoaded()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		((GObject)back).onClick.Set(new EventCallback0(ClosePopup));
		((GObject)GoToChnageProfile).onClick.Set(new EventCallback0(OnGoToChangeProfileClick));
		((GObject)GoToChangeMedals).onClick.Set(new EventCallback0(OnGoToChangeMedalsClick));
		((GObject)ChangeProfileBg).onClick.Set(new EventCallback0(OnGoToChangeProfileClick));
		((GObject)ChangeMedalBg).onClick.Set(new EventCallback0(OnGoToChangeMedalsClick));
		SharedMessenger.AddListener("USER_PROFILE_CHANGE", RenderNoEnterIzProfile);
	}

	private void OnDispose()
	{
		((GObject)back).onClick.Clear();
		((GObject)GoToChnageProfile).onClick.Clear();
		((GObject)GoToChangeMedals).onClick.Clear();
		((GObject)ChangeProfileBg).onClick.Clear();
		((GObject)ChangeMedalBg).onClick.Clear();
		SharedMessenger.RemoveListener("USER_PROFILE_CHANGE", RenderNoEnterIzProfile);
	}

	private void ClosePopup()
	{
		if (((GObject)this).parent is Window)
		{
			((GComponent)GRoot.inst).RemoveChild((GObject)(object)((GObject)this).parent, true);
		}
	}

	private void OnGoToChangeProfileClick()
	{
		ClosePopup();
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_AccountInfoPanel.Name, null);
	}

	private void OnGoToChangeMedalsClick()
	{
		ClosePopup();
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_GvG3Medal.Name, null);
	}
}
