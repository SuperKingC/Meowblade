using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.ClientApi.Protocol.UserAction;
using Shift.Legion.ClientApi.RPC;
using Shift.Legion.ClientApi.RPC.Api;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Models.Store;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using Spine.Unity;
using UI.Friends;
using UI.LegendItemDungeon;
using UI.Tips;
using UnityEngine;
using UnityEngine.Rendering;

namespace UI.AccountInfo;

public class UI_AccountInfoPanel : GComponent, IUiController
{
	public GGraph Mask;

	public UI_Dialog Dialog;

	public UI_loginWindow BindMobileDialog;

	public Transition ShowSelf;

	public Transition ShowBindMobileDialog;

	public const string URL = "ui://b9yxt7u0t1jr0";

	public static string Name = "UI_AccountInfoPanel";

	private List<GButton> visibleBasicBtns;

	private List<string> textureList = new List<string>();

	private UI_InvitationPanel IuiInvitationPanel;

	private UI_ResetPanel ResetPanel;

	private UI_ExchangePanel ExchangePanel;

	private UI_ReturnItemsPopup ReturnItemsPopup;

	private Coroutine RefreshGainBtnStatusCoroutine;

	private string userName;

	private int invateId;

	private bool toUnloadAni;

	private const string TITLE_LIST = "TitleList";

	private const string AVATAR_FRAME_LIST = "FrameList";

	private const string NAME_PLATE_LIST = "NamePlateList";

	private ArchiveExtension_DecorativeObjects.Model UsingDO;

	private static Dictionary<string, List<StoreItem>> DecorationData = null;

	private static Dictionary<string, ArchiveExtension_DecorativeObjects.DecorativeObjects> DecorationState = null;

	private Dictionary<string, GComponent> Selector = new Dictionary<string, GComponent>();

	private const int DO_NOT_ACTIVATED = 0;

	private const int DO_TAKE_OFF = 1;

	private const int DO_USING = 2;

	private UI_BuyPanel BuyPanel;

	private bool needChangeProfileAvatar { get; set; }

	private byte[] bytes132 { get; set; }

	private byte[] bytes450 { get; set; }

	private Texture2D t_132 { get; set; }

	public static string GetURL()
	{
		return "ui://b9yxt7u0t1jr0";
	}

	public static UI_AccountInfoPanel CreateInstance()
	{
		return (UI_AccountInfoPanel)(object)UIPackage.CreateObject("AccountInfo", "AccountInfoPanel");
	}

	public static UI_AccountInfoPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AccountInfoPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0t1jr0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_Dialog)(object)((GComponent)this).GetChild("Dialog");
		BindMobileDialog = (UI_loginWindow)(object)((GComponent)this).GetChild("BindMobileDialog");
		ShowSelf = ((GComponent)this).GetTransition("ShowSelf");
		ShowBindMobileDialog = ((GComponent)this).GetTransition("ShowBindMobileDialog");
	}

	public void BeforeDestroy()
	{
		if (RefreshGainBtnStatusCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RefreshGainBtnStatusCoroutine);
		}
	}

	public void Destroy()
	{
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MaxUiBgmVolume);
		if ((Object)(object)t_132 != (Object)null)
		{
			Object.Destroy((Object)(object)t_132);
		}
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		visibleBasicBtns = new List<GButton>();
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		((GObject)this).sortingOrder = 1;
		((GObject)BindMobileDialog).visible = false;
		((GObject)Dialog.exchangeBtn).enabled = true;
		GetFriendRequestNote();
		int registerAtTimestamp = GameController.Contexts.gameState.user.value.RegisterAtTimestamp;
		int num = (int)GameController.Instance.GetServerTime();
		Dialog.showFPS.selectedIndex = (UiHelper.ShowFrameRateSwitch ? 1 : 0);
		FPSSwitchBtnInit();
		((GObject)Dialog.friendsBtn).enabled = true;
		if (num - registerAtTimestamp < 86400)
		{
			((GObject)Dialog.AddFriendTip).visible = true;
			((GObject)Dialog.friendsBtn).enabled = false;
		}
		BoundBtnInit();
		if (GameController.Configs.TryGetValue("IC", out var value) && value == "1")
		{
			((GObject)Dialog.invitationBtn).visible = true;
			visibleBasicBtns.Add((GButton)(object)Dialog.invitationBtn);
		}
		else
		{
			((GObject)Dialog.invitationBtn).visible = false;
		}
		if (GameController.IsAutoLoginAccount)
		{
			((GObject)Dialog.logoutBtn).visible = false;
		}
		else
		{
			((GObject)Dialog.logoutBtn).visible = true;
			visibleBasicBtns.Add((GButton)(object)Dialog.logoutBtn);
		}
		string value2;
		bool flag = GameController.Configs.TryGetValue("RC", out value2) && value2 == "1";
		if (HotUpdateProcess.Instance.IsRegionOutCN || flag)
		{
			((GObject)Dialog.exchangeBtn).visible = true;
			visibleBasicBtns.Add((GButton)(object)Dialog.exchangeBtn);
		}
		else
		{
			((GObject)Dialog.exchangeBtn).visible = false;
		}
		if (GameController.Configs.TryGetValue("FriP", out var value3) && value3 == "0")
		{
			((GObject)Dialog.friendsBtn).visible = false;
		}
		else
		{
			((GObject)Dialog.friendsBtn).visible = true;
			((GObject)Dialog.friendsBtn.n6).visible = false;
			visibleBasicBtns.Add((GButton)(object)Dialog.friendsBtn);
		}
		if (GameController.Configs.TryGetValue("CustomerServiceOnline", out var value4) && value4 == "1")
		{
			((GObject)Dialog.feedbackBtn).visible = true;
			visibleBasicBtns.Add((GButton)(object)Dialog.feedbackBtn);
		}
		else
		{
			((GObject)Dialog.feedbackBtn).visible = false;
		}
		if (HotUpdateProcess.ChannelCode == "xipu")
		{
			((GObject)Dialog.joinQqChatBtn).visible = true;
			visibleBasicBtns.Add((GButton)(object)Dialog.joinQqChatBtn);
		}
		else
		{
			((GObject)Dialog.joinQqChatBtn).visible = false;
		}
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			EnsureBasicBtnsPos();
			Dialog.feedbackBtn.icon.url = "ui://b9yxt7u0qlo451";
		}
		else if (HotUpdateProcess.ChannelCode == "xipu")
		{
			EnsureBasicBtnsPos();
		}
		BgmSwitchInit();
		SoundSwitchInit();
		InvitationBtnInit();
		LodBtnInit();
		MouseEffectBtnInit();
		DebugInfoSwitchInit();
		InitDecoration();
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			LanguageChoiceBtnInit();
		}
	}

	private void EnsureBasicBtnsPos()
	{
		int num = int.MaxValue;
		for (int i = 0; i < visibleBasicBtns.Count; i++)
		{
			int num2 = i / 2;
			int num3 = i % 2;
			GButton val = visibleBasicBtns[i];
			((GObject)val).x = 110 + 292 * num3;
			((GObject)val).y = 329 + 130 * num2;
			if ((object)val == Dialog.friendsBtn)
			{
				num = num2;
			}
			if (num2 >= num)
			{
				((GObject)val).y = ((GObject)val).y + 20f;
			}
		}
		if (((GObject)Dialog.friendsBtn).visible)
		{
			((GObject)Dialog.AddFriendTip).x = ((GObject)Dialog.friendsBtn).x + 126f;
			((GObject)Dialog.AddFriendTip).y = ((GObject)Dialog.friendsBtn).y - 20f;
		}
	}

	private void FPSSwitchBtnInit()
	{
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		((GObject)Dialog.fpschoice).grayed = false;
		((GObject)Dialog.fpschoice).touchable = true;
		((GObject)Dialog.fpschoice.title).text = UiHelper.FrameRate.ToString();
		foreach (int frameRateCandidate in UiHelper.FrameRateCandidates)
		{
			UI_ComboBox2_item uI_ComboBox2_item = Dialog.fpschoice.list.AddItemFromPool() as UI_ComboBox2_item;
			((GObject)uI_ComboBox2_item.title).text = frameRateCandidate.ToString();
			((GObject)uI_ComboBox2_item).data = frameRateCandidate;
			uI_ComboBox2_item.buttonController.selectedIndex = ((frameRateCandidate == UiHelper.FrameRate) ? 1 : 0);
			((GObject)uI_ComboBox2_item).onClick.Set(new EventCallback1(OnChooseFPS));
		}
		Dialog.fpschoice.list.ResizeToFit(UiHelper.FrameRateCandidates.Count);
		((GObject)Dialog.fpschoice).onClick.Set(new EventCallback1(ToggleFPSChoiceList));
	}

	private void HideFPSChoiceList()
	{
		Dialog.fpschoice.buttonController.selectedIndex = 0;
		Dialog.fpschoice.listController.selectedIndex = 0;
	}

	private void ToggleFPSChoiceList(EventContext eventContext = null)
	{
		EventDispatcher val = ((eventContext != null) ? eventContext.sender : null);
		bool flag = val is UI_ComboBox2_item;
		if (Dialog.fpschoice.buttonController.selectedIndex == 0)
		{
			Dialog.fpschoice.buttonController.selectedIndex = 1;
			Dialog.fpschoice.listController.selectedIndex = 1;
			RefreshFPSChoiceList();
		}
		else if (Dialog.fpschoice.buttonController.selectedIndex == 1)
		{
			Dialog.fpschoice.buttonController.selectedIndex = 0;
			Dialog.fpschoice.listController.selectedIndex = 0;
		}
	}

	private void RefreshFPSChoiceList()
	{
		for (int i = 0; i < Dialog.fpschoice.list.numItems; i++)
		{
			UI_ComboBox2_item uI_ComboBox2_item = ((GComponent)Dialog.fpschoice.list).GetChildAt(i) as UI_ComboBox2_item;
			if (UiHelper.FrameRate == (int)((GObject)uI_ComboBox2_item).data)
			{
				uI_ComboBox2_item.buttonController.selectedIndex = 1;
			}
			else
			{
				uI_ComboBox2_item.buttonController.selectedIndex = 0;
			}
		}
	}

	private void OnChooseFPS(EventContext eventContext)
	{
		UI_ComboBox2_item uI_ComboBox2_item = eventContext.sender as UI_ComboBox2_item;
		if (UiHelper.FrameRate != (int)((GObject)uI_ComboBox2_item).data)
		{
			UiHelper.FrameRate = (int)((GObject)uI_ComboBox2_item).data;
			Application.targetFrameRate = UiHelper.FrameRate;
			((GObject)Dialog.fpschoice.title).text = UiHelper.FrameRate.ToString();
		}
	}

	private void LanguageChoiceBtnInit()
	{
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		((GObject)Dialog.languagechoice).grayed = false;
		((GObject)Dialog.languagechoice).touchable = true;
		List<Intl_LangConfig> list = null;
		foreach (Intl_LocaleConfig locale in HotUpdateProcess.Instance.RegionModel.Zone.locales)
		{
			if (locale.code == HotUpdateProcess.ZoneKey)
			{
				list = locale.languages;
				break;
			}
		}
		if (list == null)
		{
			return;
		}
		foreach (Intl_LangConfig item in list)
		{
			UI_ComboBox1_item uI_ComboBox1_item = Dialog.languagechoice.list.AddItemFromPool() as UI_ComboBox1_item;
			((GObject)uI_ComboBox1_item.title).text = item.name;
			((GObject)uI_ComboBox1_item).data = item.code;
			if (HotUpdateProcess.LanguageKey == item.code)
			{
				uI_ComboBox1_item.buttonController.selectedIndex = 1;
				((GObject)Dialog.languagechoice.title).text = item.name;
			}
			else
			{
				uI_ComboBox1_item.buttonController.selectedIndex = 0;
			}
			((GObject)uI_ComboBox1_item).onClick.Set(new EventCallback1(OnChooseLanguage));
		}
		Dialog.languagechoice.list.ResizeToFit(list.Count);
		((GObject)Dialog.languagechoice).onClick.Set(new EventCallback1(ToggleLanguageChoiceList));
	}

	private void HideLanguageChoiceList()
	{
		Dialog.languagechoice.buttonController.selectedIndex = 0;
		Dialog.languagechoice.listController.selectedIndex = 0;
	}

	private void ToggleLanguageChoiceList(EventContext eventContext)
	{
		EventDispatcher sender = eventContext.sender;
		bool flag = sender is UI_ComboBox1_item;
		if (Dialog.languagechoice.buttonController.selectedIndex == 0)
		{
			Dialog.languagechoice.buttonController.selectedIndex = 1;
			Dialog.languagechoice.listController.selectedIndex = 1;
			RefreshLanguageChoiceList();
		}
		else if (Dialog.languagechoice.buttonController.selectedIndex == 1)
		{
			Dialog.languagechoice.buttonController.selectedIndex = 0;
			Dialog.languagechoice.listController.selectedIndex = 0;
		}
	}

	private void RefreshLanguageChoiceList()
	{
		for (int i = 0; i < Dialog.languagechoice.list.numItems; i++)
		{
			UI_ComboBox1_item uI_ComboBox1_item = ((GComponent)Dialog.languagechoice.list).GetChildAt(i) as UI_ComboBox1_item;
			if (HotUpdateProcess.LanguageKey == ((GObject)uI_ComboBox1_item).data.ToString())
			{
				uI_ComboBox1_item.buttonController.selectedIndex = 1;
			}
			else
			{
				uI_ComboBox1_item.buttonController.selectedIndex = 0;
			}
		}
	}

	private void OnChooseLanguage(EventContext eventContext)
	{
		UI_ComboBox1_item langItem = eventContext.sender as UI_ComboBox1_item;
		if (!(((GObject)langItem).data.ToString() == HotUpdateProcess.LanguageKey))
		{
			UnityUiService.Instance.OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
			{
				{
					"Content",
					string.Format(LanguagesManager.GetDesc("CsharpCodeTextTipDownloadResourceAfterChangeLanguage"), ((GObject)langItem.title).text)
				},
				{
					"Buttons",
					new Dictionary<string, Action>
					{
						{
							"Confirm",
							delegate
							{
								GameLocalDataManager.SetLanguagePrefer(((GObject)langItem).data.ToString());
								GameLocalDataManager.MarkChosenLanguagePrefer(hasChosen: true);
								GameController.Quit();
							}
						},
						{ "Cancel", null }
					}
				},
				{ "PageIndex", 0 },
				{ "ClickSound", "Confirm" }
			}, multiMode: false, ignoreQueue: true);
		}
	}

	private void LodBtnInit()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.LevelsOfDetail).onClick.Set(new EventCallback0(SetGraphicQualitySetting));
		string battleModelQualityStringSetting = HotFix_Utils.GetBattleModelQualityStringSetting();
		if (battleModelQualityStringSetting == "_low")
		{
			((GButton)Dialog.LevelsOfDetail).selected = true;
		}
		else
		{
			((GButton)Dialog.LevelsOfDetail).selected = false;
		}
	}

	private void SetGraphicQualitySetting()
	{
		if (((GButton)Dialog.LevelsOfDetail).selected)
		{
			HotFix_Utils.SetBattleModelQualityStringSetting("_low");
		}
		else
		{
			HotFix_Utils.SetBattleModelQualityStringSetting("");
		}
	}

	private void MouseEffectBtnInit()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)Dialog.effectSwitch).onClick.Set(new EventCallback0(SetMouseEffectSetting));
		string mouseEffectSetting = HotFix_Utils.GetMouseEffectSetting();
		((GButton)Dialog.effectSwitch).selected = mouseEffectSetting == "on";
	}

	private void SetMouseEffectSetting()
	{
		if (((GButton)Dialog.effectSwitch).selected)
		{
			HotFix_Utils.SetMouseEffectSetting("on");
		}
		else
		{
			HotFix_Utils.SetMouseEffectSetting("off");
		}
	}

	public void OnShow()
	{
		if (UiHelper.LoginTypeStr == UserLoginCredentialsType.AppleId.ToString() || UiHelper.LoginTypeStr == UserLoginCredentialsType.Telephone.ToString())
		{
			((GObject)Dialog.Personal.cancelBtn).visible = true;
			((GObject)Dialog.Personal.bgWithCancelBtn).visible = true;
			((GObject)Dialog.Personal.n146).visible = false;
			((GObject)Dialog.Personal.n140).height = 236f;
		}
		((GObject)Dialog.feedbackBtn2).visible = ShouldShowFeedbackBtn2();
		if (HotUpdateProcess.ChannelCode == "xipu")
		{
			((GObject)Dialog.feedbackBtn3).visible = true;
			((GObject)Dialog.bookBtn).visible = false;
		}
		UiAudioManager.Instance.SetMainCityBgmVolume(UiAudioManager.Instance.MiddleBgmVolume);
		ShowSelf.Play();
		Dialog.SetButtonTitle();
	}

	private bool ShouldShowFeedbackBtn2()
	{
		if (HotUpdateProcess.ChannelCode == "xipu")
		{
			return false;
		}
		return !HotUpdateProcess.Instance.IsRegionOutCN;
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Expected O, but got Unknown
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Expected O, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Expected O, but got Unknown
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected O, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
		((GButton)Dialog.bgmSwitch).onChanged.Add(new EventCallback0(BgmSwitchEvent));
		((GButton)Dialog.soundSwitch).onChanged.Add(new EventCallback0(SoundSwitchEvent));
		((GButton)Dialog.debugSwitch).onChanged.Set(new EventCallback0(DebugInfoEvent));
		((GObject)Dialog.invitationBtn).onClick.Add(new EventCallback0(InvitationPanelInit));
		((GObject)Dialog.resetBtn).onClick.Add(new EventCallback0(ResetPanelInit));
		((GObject)BindMobileDialog.exit).onClick.Add(new EventCallback0(PopupWindowClosed));
		((GObject)BindMobileDialog.confirmBtn).onClick.Add(new EventCallback1(BindMobileByAccount));
		((GObject)BindMobileDialog.GainBtn).onClick.Add(new EventCallback1(GetCode));
		((GObject)Dialog.boundBtn).onClick.Add(new EventCallback0(BindMobilePanelInit));
		((GObject)Dialog.exchangeBtn).onClick.Add(new EventCallback0(ExchangePanelInit));
		((GObject)Dialog.friendsBtn).onClick.Add(new EventCallback0(OpenFriendsPanel));
		((GObject)Dialog.feedbackBtn).data = "游戏内设置按钮";
		((GObject)Dialog.feedbackBtn).onClick.Add(new EventCallback1(UiHelper.CustomerServiceOnlineClickLink));
		((GObject)Dialog.feedbackBtn2).onClick.Add(new EventCallback0(GoToBBSFeedbackPage));
		((GObject)Dialog.feedbackBtn3).onClick.Set(new EventCallback0(OnClickXiPuDouyinPage));
		((GObject)Dialog.joinQqChatBtn).onClick.Set(new EventCallback0(OnClickXiPuJoinQqChat));
		((GObject)Dialog.bookBtn).onClick.Add(new EventCallback0(OpenHelpPanel));
		((GObject)Dialog.logoutBtn).onClick.Add(new EventCallback0(LogInAgain));
		RegisterUiEventListeners_Decoration();
		SharedMessenger.AddListener<bool>("UPDATE_FRIEND_REQUEST_NOTE", OnSetFriendRequestNote);
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
		((GButton)Dialog.bgmSwitch).onChanged.Remove(new EventCallback0(BgmSwitchEvent));
		((GButton)Dialog.soundSwitch).onChanged.Remove(new EventCallback0(SoundSwitchEvent));
		((GButton)Dialog.debugSwitch).onChanged.Clear();
		((GObject)Dialog.invitationBtn).onClick.Remove(new EventCallback0(InvitationPanelInit));
		((GObject)Dialog.resetBtn).onClick.Remove(new EventCallback0(ResetPanelInit));
		((GObject)BindMobileDialog.exit).onClick.Remove(new EventCallback0(PopupWindowClosed));
		((GObject)BindMobileDialog.confirmBtn).onClick.Remove(new EventCallback1(BindMobileByAccount));
		((GObject)BindMobileDialog.GainBtn).onClick.Remove(new EventCallback1(GetCode));
		((GObject)Dialog.boundBtn).onClick.Remove(new EventCallback0(BindMobilePanelInit));
		((GObject)Dialog.exchangeBtn).onClick.Remove(new EventCallback0(ExchangePanelInit));
		((GObject)Dialog.friendsBtn).onClick.Remove(new EventCallback0(OpenFriendsPanel));
		((GObject)Dialog.feedbackBtn2).onClick.Remove(new EventCallback0(GoToBBSFeedbackPage));
		((GObject)Dialog.feedbackBtn3).onClick.Clear();
		((GObject)Dialog.joinQqChatBtn).onClick.Clear();
		((GObject)Dialog.bookBtn).onClick.Remove(new EventCallback0(OpenHelpPanel));
		((GObject)Dialog.logoutBtn).onClick.Remove(new EventCallback0(LogInAgain));
		UnRegisterUiEventListeners_Decoration();
		SharedMessenger.RemoveListener<bool>("UPDATE_FRIEND_REQUEST_NOTE", OnSetFriendRequestNote);
	}

	private void CopyBuffer()
	{
		GUIUtility.systemCopyBuffer = ((GObject)Dialog.Personal.IdText).text;
		List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText82") + "ID" + LanguagesManager.GetDesc("CsharpCodeZhTcText83") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	private void OpenFriendsPanel()
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Order", ((GObject)this).sortingOrder);
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_FriendsPanel.Name, dictionary);
	}

	private void GoToBBSFeedbackPage()
	{
		ILRequestHelper<GetBBSKeyResponse>.Request((EventContext)null, (Func<Task<GetBBSKeyResponse>>)(() => GameController.Contexts.Service<INetworkService>().GetBBSKey()), (Action<GetBBSKeyResponse>)delegate(GetBBSKeyResponse response)
		{
			if (response != null)
			{
				if (!response.Result)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					string text = $"UserId={response.UserId}&Timestamp={response.Timestamp}&Key={response.BBSKey}&Language={HotUpdateProcess.LanguageKey}";
					string text2 = ((GameController.UserAgent == "pro" || GameController.UserAgent == "ios_pro") ? "" : GameController.UserAgent);
					string text3 = Application.version + "\t" + text2;
					Dictionary<string, string> obj = new Dictionary<string, string>
					{
						{
							"userid",
							$"{GameController.Contexts.gameState.user.value.UserId}"
						},
						{
							"level",
							$"{GameManagers.Instance.UserArchiveManager.GetUserLevel()}"
						},
						{
							"gold_hold",
							string.Format("{0}", GameManagers.Instance.StockController.GetStock("Money"))
						},
						{
							"diamond_hold",
							string.Format("{0}", GameManagers.Instance.StockController.GetStock("Gem"))
						},
						{
							"total_revenue",
							$"{GameManagers.Instance.UserArchiveManager.GetTotalRecharge()}"
						},
						{
							"mainline_underway",
							GameManagers.Instance.UserArchiveManager.GetCurrentLevelId() ?? ""
						},
						{
							"create_time",
							GameController.Contexts.gameState.user.value.RegisterAt.DateTime.ToString("s")
						},
						{
							"farmer_hold",
							$"{Dungeon.GetTotalManPower(GameManagers.Instance)}"
						},
						{
							"fmt_UserAgent",
							text3 ?? ""
						},
						{
							"model",
							SystemInfo.deviceModel
						},
						{
							"operating_system",
							SystemInfo.operatingSystem
						},
						{
							"deviceUniqueIdentifier",
							SystemInfo.deviceUniqueIdentifier
						}
					};
					string text4 = "customField=" + UiHelper.UrlEncode(JsonHelper.ToJson(obj)) + "&channelCode=" + HotUpdateProcess.ChannelCode;
					string url = response.BBSURL + "/?" + text + "#/feedback?" + text4;
					UiHelper.UniWebViewOpenUrl(url, LanguagesManager.GetDesc("CsharpCodeZhTcText15"));
				}
			}
		});
	}

	private void OnClickXiPuDouyinPage()
	{
		UiHelper.OpenUrl("https://v.douyin.com/tC5nZ2fCrTk");
	}

	private void OnClickXiPuJoinQqChat()
	{
		UiHelper.OpenUrl("https://qm.qq.com/q/6RfNsnJGf0");
	}

	public void End()
	{
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			HideLanguageChoiceList();
		}
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		for (int i = 0; i < textureList.Count; i++)
		{
			AssetsManager.Instance.UnloadAsset<Texture2D>(textureList[i]);
		}
		if (toUnloadAni)
		{
			SpawnManager.Instance.UnloadAnimation("Goblinworker_UI_001");
		}
	}

	private void BgmSwitchInit()
	{
		if (GameLocalDataManager.HasKey("BgmSwitch"))
		{
			if (GameLocalDataManager.GetBool("BgmSwitch"))
			{
				((GButton)Dialog.bgmSwitch).selected = true;
			}
			else
			{
				((GButton)Dialog.bgmSwitch).selected = false;
			}
		}
		else
		{
			((GButton)Dialog.bgmSwitch).selected = true;
			GameLocalDataManager.SetBool("BgmSwitch", value: true);
		}
	}

	private void SoundSwitchInit()
	{
		if (GameLocalDataManager.HasKey("SoundSwitch"))
		{
			if (GameLocalDataManager.GetBool("SoundSwitch"))
			{
				((GButton)Dialog.soundSwitch).selected = true;
			}
			else
			{
				((GButton)Dialog.soundSwitch).selected = false;
			}
		}
		else
		{
			((GButton)Dialog.soundSwitch).selected = true;
			GameLocalDataManager.SetBool("SoundSwitch", value: true);
		}
	}

	private void DebugInfoSwitchInit()
	{
		bool selected = GameLocalDataManager.GetBool("DebugInfoSwitch");
		((GButton)Dialog.debugSwitch).selected = selected;
	}

	private void DebugInfoEvent()
	{
		bool selected = ((GButton)Dialog.debugSwitch).selected;
		GameLocalDataManager.SetBool("DebugInfoSwitch", selected);
		SharedMessenger.Broadcast("DEBUG_INFO_SWITCH_CHANGED");
	}

	private void BgmSwitchEvent()
	{
		if (((GButton)Dialog.bgmSwitch).selected)
		{
			GameLocalDataManager.SetBool("BgmSwitch", value: true);
			UiAudioManager.Instance.UpdateBgmSwitch(_switch: true);
		}
		else
		{
			GameLocalDataManager.SetBool("BgmSwitch", value: false);
			UiAudioManager.Instance.UpdateBgmSwitch(_switch: false);
		}
	}

	private void SoundSwitchEvent()
	{
		if (((GButton)Dialog.soundSwitch).selected)
		{
			GameLocalDataManager.SetBool("SoundSwitch", value: true);
			UiAudioManager.Instance.UpdateSoundSwitch(_switch: true);
		}
		else
		{
			GameLocalDataManager.SetBool("SoundSwitch", value: false);
			UiAudioManager.Instance.UpdateSoundSwitch(_switch: false);
		}
	}

	private void InvitationBtnInit()
	{
		bool flag = GameController.Contexts.gameState.user.value.InvitedFrom <= 0;
		bool flag2 = (GameController.Contexts.gameState.user.value.RegisterAt.AddDays(1.0) - DateTimeHelper.Now).TotalSeconds >= 0.0;
		if (flag && flag2)
		{
			Dialog.invitationBtn.Status.selectedIndex = 0;
			((GObject)Dialog.invitationBtn.note).visible = false;
		}
		else
		{
			Dialog.invitationBtn.Status.selectedIndex = 1;
			((GObject)Dialog.invitationBtn.note).visible = true;
		}
	}

	private void LogInAgain()
	{
		SharedMessenger.Broadcast("SWITCH_ACCOUNT");
	}

	private void ResetLegendItemsData()
	{
		LegendItemsHelper.ClearLegendItems();
		LegendItemDungeonUiHelper.ClearDungeonData();
	}

	private void ShowRestartTip()
	{
		UnityUiService.Instance.OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				LanguagesManager.GetDesc("CsharpCodeZhTcText84") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText85")
			},
			{
				"Buttons",
				new Dictionary<string, Action> { 
				{
					"Confirm",
					HotFix_Utils.Restart
				} }
			},
			{ "PageIndex", 4 },
			{ "ClickSound", "Confirm" },
			{ "Order", 999999 }
		}, multiMode: false, ignoreQueue: true);
	}

	private void ReturnPopupInit(Dictionary<string, float> bonus, int type)
	{
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		ReturnItemsPopup = UI_ReturnItemsPopup.CreateInstance();
		((GObject)ReturnItemsPopup.Dialog).alpha = 1f;
		((GObject)ReturnItemsPopup.Mask).alpha = 1f;
		((GObject)ReturnItemsPopup.Dialog.SpineBack).visible = true;
		((GObject)ReturnItemsPopup.Dialog.n33).x = -100f;
		((GObject)ReturnItemsPopup.Dialog.n33).y = 312f;
		((GObject)ReturnItemsPopup.Dialog.SpineBack).x = 60f;
		((GObject)ReturnItemsPopup.Dialog.SpineBack).y = 466f;
		ReturnItemsPopup.Dialog.Type.selectedIndex = type;
		ReturnItemsPopup.Dialog.SetTypeControllerPageText(type);
		((GObject)ReturnItemsPopup.Dialog.receiveBtn).data = new Tuple<int, Dictionary<string, float>>(type, bonus);
		((GObject)ReturnItemsPopup.Dialog.receiveBtn).onClick.Add(new EventCallback1(PlayMissileSfx));
		((GComponent)GRoot.inst).AddChild((GObject)(object)ReturnItemsPopup);
		((GObject)ReturnItemsPopup).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)ReturnItemsPopup);
		string key = Enumerable.First(bonus).Key;
		((GObject)ReturnItemsPopup).data = key;
		FGUIManager.Instance.SetItemIconAndFrame(ReturnItemsPopup.Dialog.Item.icon, key, textureList);
		((GObject)ReturnItemsPopup.Dialog.Item.num).text = $"{Convert.ToInt32(Enumerable.First(bonus).Value)}";
		SpineInit();
		ReturnItemsPopup.ShowDialog.Play();
	}

	private void CloseReturnPopup()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		((GObject)ReturnItemsPopup.Dialog.receiveBtn).onClick.Remove(new EventCallback1(PlayMissileSfx));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)ReturnItemsPopup, true);
	}

	private void SpineInit()
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		GameObject canvasObject = default(GameObject);
		ref GameObject reference = ref canvasObject;
		Object obj = Object.Instantiate(Resources.Load("SpineTest", typeof(GameObject)));
		reference = (GameObject)(object)((obj is GameObject) ? obj : null);
		if ((Object)(object)canvasObject != (Object)null)
		{
			canvasObject.transform.localScale = new Vector3(130f, 130f, 130f);
			canvasObject.transform.localPosition = -new Vector3(0f, 0f, 0f);
			canvasObject.transform.localEulerAngles = -new Vector3(0f, 0f, 0f);
			GoWrapper val = new GoWrapper(canvasObject);
			((DisplayObject)val).SetXY(0f, 0f);
			((DisplayObject)val).pivot = new Vector2(0.5f, 0.5f);
			((DisplayObject)val).scaleX = 1f;
			ReturnItemsPopup.Dialog.SpineBack.SetNativeObject((DisplayObject)(object)val);
		}
		SpawnManager.Instance.LoadAnimation("Goblinworker_UI_001").Then((Action<SkeletonDataAsset>)delegate(SkeletonDataAsset asset)
		{
			toUnloadAni = true;
			if (ReturnItemsPopup != null && !((GObject)ReturnItemsPopup).isDisposed)
			{
				GameObject obj2 = canvasObject;
				SkeletonAnimation val2 = ((obj2 != null) ? obj2.GetComponent<SkeletonAnimation>() : null);
				if (!((Object)(object)val2 == (Object)null) && !((Object)(object)asset == (Object)null))
				{
					((SkeletonRenderer)val2).skeletonDataAsset = asset;
					((SkeletonRenderer)val2).Initialize(true);
					SpineHelper.SetSkin((ISkeletonAnimation)(object)val2, "skin_fuben");
					val2.AnimationState.AddAnimation(0, "idle", true, 0f);
				}
			}
		});
	}

	private void PlayMissileSfx(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Expected O, but got Unknown
		Tuple<int, Dictionary<string, float>> tuple = (Tuple<int, Dictionary<string, float>>)((GObject)context.sender).data;
		foreach (KeyValuePair<string, float> item in tuple.Item2)
		{
			Bonus.Get(item.Key, item.Value).Claim(GameManagers.Instance);
		}
		switch (tuple.Item1)
		{
		case 0:
			GameController.Contexts.gameState.user.value.Telephone = userName.Substring(userName.Length - 4, 4).PadLeft(11, '*');
			BoundBtnInit();
			break;
		case 1:
			GameController.Contexts.gameState.user.value.InvitedFrom = invateId;
			InvitationBtnInit();
			break;
		}
		((GObject)ReturnItemsPopup.Dialog).alpha = 0f;
		((GObject)ReturnItemsPopup.Dialog.SpineBack).visible = false;
		((GObject)ReturnItemsPopup.Mask).alpha = 0f;
		((GObject)ReturnItemsPopup.missibleSfxBack).SetPivot(0.5f, 0.5f, true);
		FGUIManager.Instance.AddTextSpecialEffects(ReturnItemsPopup.missibleSfxBack, "exp_missile_green", Vector3.zero);
		((GObject)ReturnItemsPopup.missibleSfxBack).TweenMove(((GObject)ReturnItemsPopup.missbleEndPos).xy, 0.5f);
		UiAudioManager.Instance.PlaySoundEffect("Missile");
		((GComponent)(object)this).SetTimeout(0.5f).OnComplete((GTweenCallback)delegate
		{
			CloseReturnPopup();
		});
	}

	private void InvitationPanelInit()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		if (UiHelper.LoginTypeStr == UserLoginCredentialsType.Guest.ToString())
		{
			UiHelper.GuestsAccessRestrictTip();
		}
		else if (Dialog.invitationBtn.Status.selectedIndex != 1)
		{
			IuiInvitationPanel = UI_InvitationPanel.CreateInstance();
			((GObject)IuiInvitationPanel.mask).onClick.Add(new EventCallback0(CloseVisitPanel));
			((GObject)IuiInvitationPanel.Dialog.confirmBtn).onClick.Add(new EventCallback1(UseInvitationCode));
			((GComponent)GRoot.inst).AddChild((GObject)(object)IuiInvitationPanel);
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)IuiInvitationPanel);
			IuiInvitationPanel.ShowSelf.Play();
		}
	}

	private void CloseVisitPanel()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		((GObject)IuiInvitationPanel.mask).onClick.Remove(new EventCallback0(CloseVisitPanel));
		((GObject)IuiInvitationPanel.Dialog.confirmBtn).onClick.Remove(new EventCallback1(UseInvitationCode));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)IuiInvitationPanel, true);
	}

	private void UseInvitationCode(EventContext context)
	{
		string _code = ((GObject)IuiInvitationPanel.Dialog.inputUsername).text;
		ILRequestHelper<SetInvitedFromResponse>.Request(context, () => GameController.Contexts.Service<INetworkService>().SetInvitedFrom(_code), delegate(SetInvitedFromResponse response)
		{
			if (!response.Result)
			{
				CloseVisitPanel();
				OverflowTip(LanguagesManager.GetErrorMessage(response.ErrorCode));
			}
			else
			{
				invateId = response.InvitedFrom;
				if (response.InvitedBonus != null && response.InvitedBonus.Count > 0)
				{
					ReturnPopupInit(response.InvitedBonus, 1);
					CloseVisitPanel();
					InvitationBtnInit();
				}
				else
				{
					CloseVisitPanel();
					GameController.Contexts.gameState.user.value.InvitedFrom = invateId;
					InvitationBtnInit();
				}
			}
		});
	}

	private void OverflowTip(string _tips)
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				_tips ?? ""
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
						}
					},
					{ "Cancel", null }
				}
			},
			{ "PageIndex", 4 },
			{ "ClickSound", "Confirm" },
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
	}

	private void ResetPanelInit()
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		if (HotUpdateProcess.ChannelCode == "bilibili")
		{
			"目前无法重置数据".ToConfirmPopup(null, null, (AlignType)1, 40, mirrorBtns: false, needCancelButton: false);
			return;
		}
		ResetPanel = UI_ResetPanel.CreateInstance();
		((GObject)ResetPanel.Mask).onClick.Add(new EventCallback0(CloseResetPanel));
		((GObject)ResetPanel.Dialog.yesBtn).enabled = false;
		((GObject)ResetPanel.Dialog.inputUsername).text = "";
		ResetPanel.Dialog.inputUsername.maxLength = UiHelper.ResetTip.Length;
		((GObject)ResetPanel.Dialog.yesBtn).onClick.Add(new EventCallback0(ResetConfirmEvent));
		((GObject)ResetPanel.Dialog.DataBackUp).onClick.Add(new EventCallback0(OpenDataBackUpPanel));
		ResetPanel.Dialog.inputUsername.onChanged.Add(new EventCallback0(WarnningTip));
		((GComponent)GRoot.inst).AddChild((GObject)(object)ResetPanel);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)ResetPanel);
		((GObject)ResetPanel).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		ResetPanel.ShowDialog.Play();
	}

	private void CloseResetPanel()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		((GObject)ResetPanel.Mask).onClick.Remove(new EventCallback0(CloseResetPanel));
		((GObject)ResetPanel.Dialog.yesBtn).onClick.Remove(new EventCallback0(ResetConfirmEvent));
		((GObject)ResetPanel.Dialog.DataBackUp).onClick.Remove(new EventCallback0(OpenDataBackUpPanel));
		ResetPanel.Dialog.inputUsername.onChanged.Remove(new EventCallback0(WarnningTip));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)ResetPanel, true);
	}

	private void WarnningTip()
	{
		string text = ((GObject)ResetPanel.Dialog.inputUsername).text;
		if (text == UiHelper.ResetTip)
		{
			((GObject)ResetPanel.Dialog.yesBtn).enabled = true;
		}
		else
		{
			((GObject)ResetPanel.Dialog.yesBtn).enabled = false;
		}
	}

	private void ResetConfirmTip()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_UniversalConfirmPopup.Name, new Dictionary<string, object>
		{
			{
				"Content",
				LanguagesManager.GetDesc("CsharpCodeZhTcText86") + "？" + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText87") + "(" + LanguagesManager.GetDesc("CsharpCodeZhTcText88") + ")" + LanguagesManager.GetDesc("CsharpCodeZhTcText89") + Environment.NewLine + LanguagesManager.GetDesc("CsharpCodeZhTcText90") + LanguagesManager.Comma + LanguagesManager.GetDesc("CsharpCodeZhTcText91") + "！"
			},
			{
				"Buttons",
				new Dictionary<string, Action>
				{
					{
						"Confirm",
						delegate
						{
							ResetConfirmEvent();
						}
					},
					{
						"Cancel",
						delegate
						{
						}
					}
				}
			},
			{ "PageIndex", 0 },
			{ "ClickSound", "Confirm" },
			{
				"Order",
				((GObject)this).sortingOrder
			}
		});
	}

	private void OpenDataBackUpPanel()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_DataBackUpPanel.Name, new Dictionary<string, object> { 
		{
			"DataBackUpPanelType",
			UI_DataBackUpPanel.DataBackUpPanelType.Optional
		} });
	}

	private async void ResetConfirmEvent()
	{
		Action openDataBackUpPanel = delegate
		{
			GameController.Contexts.Service<IUiService>().OpenPanel(UI_DataBackUpPanel.Name, new Dictionary<string, object> { 
			{
				"DataBackUpPanelType",
				UI_DataBackUpPanel.DataBackUpPanelType.ForceDeletion
			} });
		};
		UiHelper.ResetUserArchive(openDataBackUpPanel);
	}

	private async void ResetArchive(string token)
	{
		ConfirmResetArchiveResponse response = await GameController.Contexts.Service<INetworkService>().ConfirmResetArchive(token);
		if (!response.Result)
		{
			ILRequestHelper.ShowErrorCode(response.ErrorCode);
			return;
		}
		SharedMessenger.Broadcast("NEED_RESTART", new NeedRestartResponse
		{
			Tip = LanguagesManager.GetErrorMessage(response.ErrorCode),
			IsEnforced = true
		});
	}

	private void BindMobilePanelInit()
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		if (Dialog.boundBtn.Status.selectedIndex == 1)
		{
			return;
		}
		((GObject)BindMobileDialog.inputUsername).text = "";
		((GObject)BindMobileDialog.inputPassword).text = "";
		((GObject)BindMobileDialog.GainBtn).touchable = false;
		BoundBtnInit();
		if (BindMobileDialog.GainBtn.PageController.selectedIndex != 2)
		{
			BindMobileDialog.GainBtn.PageController.selectedIndex = 0;
		}
		BindMobileDialog.inputUsername.onChanged.Add(new EventCallback0(UpdateGainBtnStatus));
		((GObject)BindMobileDialog).visible = true;
		ShowBindMobileDialog.Play();
		GameObject gameObject = ((Component)((GObject)this).displayObject.gameObject.transform.Find("loginWindow")).gameObject;
		if (!Object.op_Implicit((Object)(object)gameObject))
		{
			return;
		}
		SortingGroup val = ((gameObject != null) ? gameObject.GetComponent<SortingGroup>() : null);
		if (!((Object)(object)val != (Object)null))
		{
			val = ((gameObject != null) ? gameObject.AddComponent<SortingGroup>() : null);
			if (val != null)
			{
				val.sortingLayerName = "UI";
			}
		}
	}

	private void BoundBtnInit()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			((GObject)Dialog.boundBtn).visible = false;
		}
		else if ((int)Application.platform == 2)
		{
			((GObject)Dialog.boundBtn).visible = false;
		}
		else if (HotUpdateProcess.ChannelCode == "bilibili")
		{
			((GObject)Dialog.boundBtn).visible = false;
		}
		else if (HotUpdateProcess.ChannelCode == "xipu")
		{
			((GObject)Dialog.boundBtn).visible = false;
		}
		else if (string.IsNullOrWhiteSpace(GameController.Contexts.gameState.user.value.Telephone))
		{
			Dialog.boundBtn.Status.selectedIndex = 0;
			((GObject)Dialog.boundBtn.note).visible = false;
		}
		else
		{
			Dialog.boundBtn.Status.selectedIndex = 1;
			((GObject)Dialog.boundBtn.note).visible = true;
			visibleBasicBtns.Add((GButton)(object)Dialog.boundBtn);
		}
	}

	private void UpdateGainBtnStatus()
	{
		if (BindMobileDialog.GainBtn.PageController.selectedIndex != 2)
		{
			if (((GObject)BindMobileDialog.inputUsername).text.Length >= 11)
			{
				((GObject)BindMobileDialog.GainBtn).touchable = true;
				BindMobileDialog.GainBtn.PageController.selectedIndex = 1;
			}
			else
			{
				((GObject)BindMobileDialog.GainBtn).touchable = false;
				BindMobileDialog.GainBtn.PageController.selectedIndex = 0;
			}
		}
	}

	private void PopupWindowClosed()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		BindMobileDialog.inputUsername.onChanged.Remove(new EventCallback0(UpdateGainBtnStatus));
		((GObject)BindMobileDialog).visible = false;
	}

	private void GetCode(EventContext context)
	{
		if (((GObject)BindMobileDialog.inputUsername).text.Length != 11 || ((GObject)BindMobileDialog.inputUsername).text[0] != '1')
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText77") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, ((GObject)this).sortingOrder, arg3: false);
			return;
		}
		ILRequestHelper<BindMobileResponse>.Request(context, () => GameController.Contexts.Service<INetworkService>().BindMobile(((GObject)BindMobileDialog.inputUsername).text), delegate(BindMobileResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (RefreshGainBtnStatusCoroutine != null)
				{
					FGUIManager.Instance.CloseIEnumerator(RefreshGainBtnStatusCoroutine);
				}
				RefreshGainBtnStatusCoroutine = FGUIManager.Instance.OpenIEnumerator(ReGainCode(response.Cd));
			}
		});
	}

	private IEnumerator ReGainCode(int time)
	{
		((GObject)BindMobileDialog.GainBtn).touchable = false;
		BindMobileDialog.GainBtn.PageController.selectedIndex = 2;
		while (time > 0)
		{
			((GObject)BindMobileDialog.GainBtn.title).text = string.Format("{0}{1}", time, LanguagesManager.GetDesc("CsharpCodeZhTcText92"));
			yield return (object)new WaitForSeconds(1f);
			time--;
		}
		((GObject)BindMobileDialog.GainBtn).touchable = false;
		BindMobileDialog.GainBtn.PageController.selectedIndex = 0;
		((GObject)BindMobileDialog.GainBtn.title).text = LanguagesManager.GetDesc("CsharpCodeZhTcText78");
		UpdateGainBtnStatus();
		if (RefreshGainBtnStatusCoroutine != null)
		{
			FGUIManager.Instance.CloseIEnumerator(RefreshGainBtnStatusCoroutine);
		}
	}

	private void BindMobileByAccount(EventContext context)
	{
		if (string.IsNullOrWhiteSpace(((GObject)BindMobileDialog.inputUsername).text) || string.IsNullOrWhiteSpace(((GObject)BindMobileDialog.inputPassword).text))
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText79") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
			return;
		}
		if (((GObject)BindMobileDialog.inputUsername).text.Length != 11 || ((GObject)BindMobileDialog.inputUsername).text[0] != '1')
		{
			List<string> arg2 = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText80") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg2, 1, arg3: false);
			return;
		}
		userName = ((GObject)BindMobileDialog.inputUsername).text;
		string password = ((GObject)BindMobileDialog.inputPassword).text;
		ILRequestHelper<BindMobileVerifyResponse>.Request(context, () => GameController.Contexts.Service<INetworkService>().BindMobileVerify(userName, password), delegate(BindMobileVerifyResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				if (response.Bonuses != null && response.Bonuses.Count > 0)
				{
					ReturnPopupInit(response.Bonuses, 0);
				}
				else
				{
					GameController.Contexts.gameState.user.value.Telephone = userName.Substring(userName.Length - 4, 4).PadLeft(11, '*');
					BoundBtnInit();
				}
				PopupWindowClosed();
			}
		});
	}

	private void ExchangePanelInit()
	{
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Invalid comparison between I4 and Unknown
		if (UiHelper.LoginTypeStr == UserLoginCredentialsType.Guest.ToString())
		{
			UiHelper.GuestsAccessRestrictTip();
			return;
		}
		if (HotUpdateProcess.Instance.IsRegionOutCN)
		{
			UnityUiService.Instance.OpenPanel(UI_main_FacebookGiftCode.Name, new Dictionary<string, object>());
			return;
		}
		if (HotUpdateProcess.ChannelCode == "bilibili")
		{
			UnityUiService.Instance.OpenPanel(UI_GiftCodePanel.Name, new Dictionary<string, object>());
			return;
		}
		if (HotUpdateProcess.ChannelCode == "xipu")
		{
			UnityUiService.Instance.OpenPanel(UI_GiftCodePanel.Name, new Dictionary<string, object>());
			return;
		}
		ExchangePanel = UI_ExchangePanel.CreateInstance();
		((GObject)ExchangePanel.mask).onClick.Add(new EventCallback0(CloseExchangePanel));
		((GObject)ExchangePanel.Dialog.copyRedeemCodeBtn).onClick.Add(new EventCallback0(CopyGiftRedeemCode));
		((GObject)ExchangePanel.Dialog.ClaimBtn).onClick.Set(new EventCallback0(ClaimGiftRedeemCode));
		if (11 == (int)Application.platform)
		{
			ExchangePanel.Dialog.RedeemType.selectedIndex = 1;
		}
		else
		{
			ExchangePanel.Dialog.RedeemType.selectedIndex = 0;
		}
		((GObject)ExchangePanel).SetSize(((GObject)GRoot.inst).width, ((GObject)GRoot.inst).height);
		((GComponent)GRoot.inst).AddChild((GObject)(object)ExchangePanel);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)ExchangePanel);
		((GObject)ExchangePanel.Dialog.Code).text = LanguagesManager.GetDesc("CsharpCodeTextGiftRedeemCode");
		((GObject)ExchangePanel.Dialog.YourID).text = GameController.Contexts.gameState.user.value.UserId.ToString();
		ExchangePanel.ShowDialog.Play();
	}

	private void CloseExchangePanel()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		((GObject)ExchangePanel.mask).onClick.Remove(new EventCallback0(CloseExchangePanel));
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)ExchangePanel, true);
	}

	public void CopyGiftRedeemCode()
	{
		GUIUtility.systemCopyBuffer = string.Format("{0} {1}", LanguagesManager.GetDesc("CsharpCodeTextGiftRedeemCode"), GameController.Contexts.gameState.user.value.UserId);
		List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeTextGiftRedeemCodeCopied") };
		SharedMessenger.Broadcast("SHOW_TIPS", arg, 1, arg3: false);
	}

	public void ClaimGiftRedeemCode()
	{
		string text = ((GObject)ExchangePanel.Dialog.RedeemCodeInput).text;
		Task<GiftRedeemClaimResponse> task = GameController.Contexts.Service<INetworkService>().GiftRedeemClaim(text);
		task.GetAwaiter().OnCompleted(delegate
		{
			GiftRedeemClaimResponse result = task.Result;
			if (!result.Result)
			{
				ILRequestHelper.ShowErrorCode(result.ErrorCode);
			}
			else
			{
				SharedMessenger.Broadcast("SHOW_TIPS", new List<string> { LanguagesManager.GetDesc("CsharpGiftCodeRedeemSuccess") }, 1, arg3: false);
			}
		});
	}

	private void OpenHelpPanel()
	{
		UiHelper.OpenHelpPage("游戏帮助界面");
	}

	private void OnSetFriendRequestNote(bool hasMsg)
	{
		Dialog.friendsBtn.hasMsg.selectedIndex = (hasMsg ? 1 : 0);
	}

	private void GetFriendRequestNote()
	{
		Dialog.friendsBtn.hasMsg.selectedIndex = 0;
		ILRequestHelper<GetFriendsApplyInfoResponse>.Request((EventContext)null, (Func<Task<GetFriendsApplyInfoResponse>>)(() => Contexts.sharedInstance.Service<INetworkService>().GetFriendsApplyInfo()), (Action<GetFriendsApplyInfoResponse>)delegate(GetFriendsApplyInfoResponse response)
		{
			if (!response.Result)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				List<FriendsApplyProto> data = response.Data;
				if (data != null && data.Count > 0)
				{
					Dialog.friendsBtn.hasMsg.selectedIndex = 1;
				}
			}
		});
	}

	private void InitDecoration()
	{
		needChangeProfileAvatar = false;
		((GObject)Dialog.Personal.VerifingStatus).visible = false;
		if (GameController.IsAutoLoginAccount)
		{
			((GObject)Dialog.Personal.DeOrSaBtn).enabled = false;
			((GObject)Dialog.Personal.DeOrSaBtn).visible = false;
		}
		else
		{
			((GObject)Dialog.Personal.DeOrSaBtn).enabled = true;
			((GObject)Dialog.Personal.DeOrSaBtn).visible = true;
		}
		Action action = delegate
		{
			((GObject)Dialog.Personal.VerifingStatus).visible = true;
		};
		((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.SetSelfImageByWebRequestAndStorage(Name, Dialog.Personal.AvatarLoader.icon, action));
		((GComponent)Dialog.Personal).GetController("isDefault").selectedIndex = 0;
		int userId = GameController.Contexts.gameState.user.value.UserId;
		((GObject)Dialog.Personal.IdText).text = userId.ToString();
		FGUIManager.Instance.GetUserMedal(userId, Dialog.Personal.n147);
		RefreshUserName();
		GetUsingDecorations();
	}

	private void GetUsingDecorations()
	{
		UsingDO = GameManagers.Instance.UserArchiveManager.GetDecorativeObjectsModel();
	}

	private void RegisterUiEventListeners_Decoration()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected O, but got Unknown
		((GObject)Dialog.titleBtn).onClick.Add(new EventCallback0(OnChangeToTitlePage));
		((GObject)Dialog.AvatarBtn).onClick.Add(new EventCallback0(OnChangeToAvatarPage));
		((GObject)Dialog.frameAvatarBtn).onClick.Add(new EventCallback0(OnChangeToFramePage));
		((GObject)Dialog.namePlateBtn).onClick.Add(new EventCallback0(OnChangeToNamePlatePage));
		((GObject)Dialog.Personal.DeOrSaBtn).onClick.Add(new EventCallback0(OnSaveDecoration));
		((GObject)Dialog.Personal.copyBtn).onClick.Add(new EventCallback0(CopyBuffer));
		((GObject)Dialog.Personal.modifyBtn).onClick.Add(new EventCallback0(OnSaveName));
		((GObject)Dialog.Personal.cancelBtn).onClick.Add(new EventCallback0(RemoveAccount));
		((GObject)Dialog.Avatarloader).onClick.Add(new EventCallback0(PickNewAvatarImage));
		SharedMessenger.AddListener("REFRESH_USERNAME", RefreshUserName);
	}

	private void UnRegisterUiEventListeners_Decoration()
	{
		((GObject)Dialog.titleBtn).onClick.Clear();
		((GObject)Dialog.AvatarBtn).onClick.Clear();
		((GObject)Dialog.frameAvatarBtn).onClick.Clear();
		((GObject)Dialog.namePlateBtn).onClick.Clear();
		((GObject)Dialog.Personal.DeOrSaBtn).onClick.Clear();
		((GObject)Dialog.Personal.copyBtn).onClick.Clear();
		((GObject)Dialog.Personal.modifyBtn).onClick.Clear();
		((GObject)Dialog.Personal.cancelBtn).onClick.Clear();
		((GObject)Dialog.Avatarloader).onClick.Clear();
		SharedMessenger.RemoveListener("REFRESH_USERNAME", RefreshUserName);
	}

	private async Task GetDecorationStateByType(int type)
	{
		GetDecorativeObjectsResponse dic = await GameController.Contexts.Service<INetworkService>().GetDecorativeObjects(type);
		if (dic.Result)
		{
			ArchiveExtension_DecorativeObjects.ListDecorativeObjects decorativeObjectsData = dic.Data.As<ArchiveExtension_DecorativeObjects.ListDecorativeObjects>();
			List<ArchiveExtension_DecorativeObjects.DecorativeObjects> list = decorativeObjectsData.List;
			foreach (ArchiveExtension_DecorativeObjects.DecorativeObjects data in list)
			{
				DecorationState.Add(data.Id, data);
			}
		}
		else
		{
			ILRequestHelper.ShowErrorCode(dic.ErrorCode);
		}
	}

	private List<StoreItem> GetDecorationDataByID(string ActivityID)
	{
		List<StoreItem> list = new List<StoreItem>();
		ActivityManager.Activities.TryGetValue(ActivityID, out var value);
		foreach (ActivityContentPayload value2 in value.ContentPayload(GameManagers.Instance).Values)
		{
			StoreActivityPayload storeActivityPayload = (StoreActivityPayload)value2;
			list.AddRange(storeActivityPayload.StoreItems(GameManagers.Instance).Values);
		}
		return list;
	}

	private async Task GetDecorationData()
	{
		if (DecorationState == null)
		{
			DecorationState = new Dictionary<string, ArchiveExtension_DecorativeObjects.DecorativeObjects>();
			await GetDecorationStateByType(1);
			await GetDecorationStateByType(2);
			await GetDecorationStateByType(3);
		}
		if (DecorationData == null)
		{
			DecorationData = new Dictionary<string, List<StoreItem>>
			{
				{
					"TitleList",
					GetDecorationDataByID("DO_Title")
				},
				{
					"FrameList",
					GetDecorationDataByID("DO_AvatarFrame")
				},
				{
					"NamePlateList",
					GetDecorationDataByID("DO_Nameplate")
				}
			};
			foreach (KeyValuePair<string, List<StoreItem>> pageData in DecorationData)
			{
				_ = pageData.Key;
				foreach (StoreItem itemData in pageData.Value)
				{
					string itemID = Enumerable.First(itemData.Content).Key;
					GDEItemData gdeItem = GDMgr.Get<GDEItemData>(itemID);
					ItemEffectIdentifiedDO itemEffect = JsonHelper.ToObject<ItemEffectIdentifiedDO>(gdeItem.Effect);
					DecorationState.TryGetValue(itemEffect.DecorativeObjects.Id, out var itemState);
					GDMgr.Get<GDEDecorativeObjectsData>(itemEffect.DecorativeObjects.Id);
					itemState = null;
				}
			}
		}
		Selector.Clear();
		foreach (string key in DecorationData.Keys)
		{
			Selector.Add(key, null);
		}
	}

	private async Task UpdateDecorationPanel()
	{
		await GetDecorationData();
		foreach (KeyValuePair<string, List<StoreItem>> pageData in DecorationData)
		{
			string listName = pageData.Key;
			GList uiList = ((GComponent)Dialog).GetChild(listName).asList;
			((GComponent)uiList).RemoveChildren();
			foreach (StoreItem itemData in pageData.Value)
			{
				GComponent uiSlot = uiList.AddItemFromPool().asCom;
				string itemID = Enumerable.First(itemData.Content).Key;
				GDEItemData gdeItem = GDMgr.Get<GDEItemData>(itemID);
				ItemEffectIdentifiedDO itemEffect = JsonHelper.ToObject<ItemEffectIdentifiedDO>(gdeItem.Effect);
				DecorationState.TryGetValue(itemEffect.DecorativeObjects.Id, out var itemState);
				RenderDecorationItem(gdeDO: GDMgr.Get<GDEDecorativeObjectsData>(itemEffect.DecorativeObjects.Id), uiSlot: uiSlot, itemData: itemData, itemState: itemState, listName: listName);
				itemState = null;
			}
		}
	}

	private void RenderDecorationItem(GComponent uiSlot, StoreItem itemData, ArchiveExtension_DecorativeObjects.DecorativeObjects itemState, GDEDecorativeObjectsData gdeDO, string listName)
	{
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected O, but got Unknown
		uiSlot.GetController("status").selectedIndex = 0;
		uiSlot.GetController("info").selectedIndex = 1;
		uiSlot.GetChild("Icon").asLoader.url = "ui://PublicResources/" + itemData.Icon;
		if (itemData.Price != null && itemData.Price.Count > 0)
		{
			GComponent asCom = uiSlot.GetChild("Price").asCom;
			GLoader asLoader = asCom.GetChild("icon").asLoader;
			string key = FGUIManager.Instance.GetPriceItemId(itemData).Key;
			Dictionary<string, float> dictionary = itemData.Price.First();
			((GObject)asCom.GetChild("Num").asTextField).text = $"{Convert.ToInt32(dictionary.Values.First())}";
			asLoader.url = "ui://PublicResources/" + key;
		}
		if (itemState != null)
		{
			if (itemState.State == 3)
			{
				uiSlot.GetController("status").selectedIndex = 1;
				uiSlot.GetController("info").selectedIndex = 0;
			}
			else if (itemState.State == 1)
			{
				long num = itemState.ExpiredTime - DateTimeHelper.Ticks;
				if (num > 0)
				{
					uiSlot.GetController("status").selectedIndex = 1;
					((GObject)uiSlot.GetChild("TimeLimit").asTextField).text = UiHelper.ParseTimeChnForGift((int)num) + LanguagesManager.GetDesc("CsharpCodeZhTcText93");
				}
			}
		}
		uiSlot.GetController("status").selectedIndex = 1;
		((GObject)uiSlot).onClick.Clear();
		((GObject)uiSlot).onClick.Set((EventCallback0)delegate
		{
			OnClickItem(uiSlot, itemData, gdeDO, listName);
		});
	}

	private void OnClickItem(GComponent uiSlot, StoreItem itemData, GDEDecorativeObjectsData gdeDO, string listName)
	{
		if (uiSlot.GetController("status").selectedIndex == 0)
		{
			OpenBuyPanel(uiSlot, itemData, gdeDO);
			return;
		}
		if (Selector[listName] == uiSlot)
		{
			Selector[listName].GetController("status").selectedIndex = 1;
			Selector[listName] = null;
			OnTakeOffDecoration(listName);
			return;
		}
		if (Selector[listName] != null)
		{
			Selector[listName].GetController("status").selectedIndex = 1;
		}
		uiSlot.GetController("status").selectedIndex = 2;
		Selector[listName] = uiSlot;
		OnUseDecoration(itemData, gdeDO, listName);
	}

	private void OnUseDecoration(StoreItem itemData, GDEDecorativeObjectsData gdeDO, string listName)
	{
		string url = "ui://PublicResources/" + itemData.Icon;
		switch (listName)
		{
		case "TitleList":
			((GObject)Dialog.Personal.TitleLoader).visible = true;
			Dialog.Personal.TitleLoader.url = url;
			break;
		case "FrameList":
			((GObject)Dialog.Personal.FrameLoader).visible = true;
			Dialog.Personal.FrameLoader.url = url;
			break;
		case "NamePlateList":
			Dialog.Personal.isDefault.selectedIndex = 1;
			Dialog.Personal.NamePlateLoader.url = url;
			break;
		}
	}

	private void OnTakeOffDecoration(string listName)
	{
		switch (listName)
		{
		case "TitleList":
			((GObject)Dialog.Personal.TitleLoader).visible = false;
			break;
		case "FrameList":
			((GObject)Dialog.Personal.FrameLoader).visible = false;
			break;
		case "NamePlateList":
			Dialog.Personal.isDefault.selectedIndex = 0;
			break;
		}
	}

	private async void OnSaveDecoration()
	{
		if (((GComponent)Dialog).GetController("pageControl").selectedIndex == 0)
		{
			await UpdateDecorationPanel();
			((GComponent)Dialog).GetController("pageControl").selectedIndex = 2;
			((GComponent)Dialog.Personal.DeOrSaBtn).GetController("clickChange").selectedIndex = 1;
		}
		else
		{
			ProfileChangeAvatar();
			((GComponent)Dialog).GetController("pageControl").selectedIndex = 0;
			((GComponent)Dialog.Personal.DeOrSaBtn).GetController("clickChange").selectedIndex = 0;
		}
	}

	private void OnChangeToTitlePage()
	{
		((GComponent)Dialog).GetController("pageControl").selectedIndex = 1;
	}

	private void OnChangeToAvatarPage()
	{
		((GComponent)Dialog).GetController("pageControl").selectedIndex = 2;
	}

	private void OnChangeToFramePage()
	{
		((GComponent)Dialog).GetController("pageControl").selectedIndex = 3;
	}

	private void OnChangeToNamePlatePage()
	{
		((GComponent)Dialog).GetController("pageControl").selectedIndex = 4;
	}

	private void OpenBuyPanel(GComponent uiSlot, StoreItem itemData, GDEDecorativeObjectsData gdeDO)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		BuyPanel = UI_BuyPanel.CreateInstance();
		((GObject)BuyPanel.Mask).onClick.Add(new EventCallback0(CloseBuyPanel));
		((GObject)BuyPanel.Dialog.Buy_Exit).onClick.Add(new EventCallback0(CloseBuyPanel));
		((GComponent)GRoot.inst).AddChild((GObject)(object)BuyPanel);
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)BuyPanel);
		UI_BuyDialog dialog = BuyPanel.Dialog;
		((GObject)dialog.Buy_Title).text = itemData.Name;
		((GObject)dialog.Buy_Message).text = itemData.Desc;
		((GComponent)dialog).GetController("BuyControl").selectedIndex = 0;
		((GObject)dialog.Buy_BuyBtn).onClick.Add((EventCallback0)delegate
		{
			OnBuy(uiSlot, itemData, gdeDO);
		});
		BuyPanel.ShowDialog.Play();
	}

	private void OnBuy(GComponent uiSlot, StoreItem itemData, GDEDecorativeObjectsData gdeDO)
	{
		PurchaseManager.Instance.PlaceOrder(itemData.StoreItemId, "Default")?.GetAwaiter().OnCompleted(delegate
		{
			CloseBuyPanel();
		});
	}

	private void CloseBuyPanel()
	{
		((GObject)BuyPanel.Mask).onClick.Clear();
		((GObject)BuyPanel.Dialog.Buy_Exit).onClick.Clear();
		((GObject)BuyPanel.Dialog.Buy_BuyBtn).onClick.Clear();
		((GComponent)GRoot.inst).RemoveChild((GObject)(object)BuyPanel, true);
		UpdateDecorationPanel();
	}

	private void PickNewAvatarImage()
	{
		NativeGalleryHelper.PickImage(async delegate(Texture2D texture2d)
		{
			_ = Application.persistentDataPath + "/";
			Texture2D t_450 = NativeGalleryHelper.CropTexture(texture2d, 450);
			Texture2D t_451 = NativeGalleryHelper.CropTexture(texture2d, 132);
			Object.Destroy((Object)(object)texture2d);
			await UploadNewAvatar(t_451, t_450);
		});
	}

	private async Task UploadNewAvatar(Texture2D t_132, Texture2D t_450)
	{
		bytes132 = ImageConversion.EncodeToJPG(t_132, 60);
		bytes450 = ImageConversion.EncodeToJPG(t_450, 50);
		if (bytes450 == null || bytes132 == null)
		{
			Debug.LogError((object)"东西没拿到");
		}
		else
		{
			needChangeProfileAvatar = true;
		}
		Object.Destroy((Object)(object)t_450);
		if ((Object)(object)this.t_132 != (Object)null)
		{
			Object.Destroy((Object)(object)t_132);
		}
		((GComponent)Dialog.Avatarloader).GetController("isShowIcon").selectedIndex = 1;
		GLoader avatar = Dialog.Avatarloader.icon;
		avatar.texture = new NTexture((Texture)(object)t_132);
		this.t_132 = t_132;
	}

	private async void ProfileChangeAvatar()
	{
		if (!needChangeProfileAvatar)
		{
			return;
		}
		ProfileChangeAvatarResponse resp = await GameController.Contexts.Service<INetworkService>().ProfileChangeAvatar(bytes132, bytes450);
		if (resp.Result)
		{
			needChangeProfileAvatar = false;
			GLoader avatar = Dialog.Personal.AvatarLoader.icon;
			if (avatar.texture != null)
			{
				avatar.texture.Dispose();
			}
			avatar.texture = new NTexture((Texture)(object)t_132);
			((GObject)Dialog.Personal.VerifingStatus).visible = true;
			GameLocalDataManager.SelfLocalData _userLocalData = new GameLocalDataManager.SelfLocalData
			{
				ExpiredTime = 0L
			};
			GameLocalDataManager.SetSelfUserLocalData(_userLocalData);
			SharedMessenger.Broadcast("USER_PROFILE_CHANGE");
		}
		else
		{
			ILRequestHelper.ShowErrorCode(resp.ErrorCode);
		}
	}

	private void OnSaveName()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_ChangeNamePanel.Name, null);
	}

	private void RefreshUserName()
	{
		FGUIManager.Instance.OpenIEnumerator(FGUIManager.Instance.GetUserNickName(GameController.Contexts.gameState.user.value.UserId, (GTextField)(object)Dialog.Personal.NameText));
	}

	private void RemoveAccount()
	{
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_RemoveAccountPanel.Name, null);
	}
}
