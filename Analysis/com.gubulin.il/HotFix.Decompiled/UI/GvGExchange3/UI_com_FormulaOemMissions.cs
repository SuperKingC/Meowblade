using System;
using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3Common.Model.Oem;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.Model.UserProfile;
using HotFix.Sources.Base.Sources.Scripts.GvG3.GvG3UI.UI.GvGCampFlagship.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.Mission;
using UI.GvGOEMForge3;
using UnityEngine;

namespace UI.GvGExchange3;

public class UI_com_FormulaOemMissions : GComponent
{
	public Controller HasMission;

	public GImage n5;

	public GImage n16;

	public GImage n19;

	public GImage n17;

	public GImage n18;

	public GImage n21;

	public GImage n22;

	public GGroup n20;

	public UI_com_TxtChange EmptyTip;

	public UI_btn_FormulaOemFilter Filter;

	public UI_btn_TaitanActivated TaitanActivated;

	public GList FormulaMissions;

	public UI_com_PageTurn TurnPage;

	public const string URL = "ui://tt2iq07osmtg2t";

	public static string Name = "UI_com_FormulaOemMissions";

	private const int _MISSION_COUNT_PER_PAGE = 10;

	private const int _MISSION_FIRST_PAGE_NUMBER = 1;

	private Action _displayFilterPanel;

	private Coroutine _updateMissionState;

	private Action _onSubmit;

	private Action<FormulaOemMissionsFilter> _onFilterChange;

	private readonly WaitForSeconds _perSecond = new WaitForSeconds(1f);

	private readonly string _curCacheId = $"{Singleton<GvGMode3RoomManager>.Instance.ObserverRecord.CurIZId}";

	private int _selectingMissionIndex;

	private readonly Lazy<C2S_GetFormulaOEMMissios.Response> _oemMissionsLazy = new Lazy<C2S_GetFormulaOEMMissios.Response>(() => new C2S_GetFormulaOEMMissios.Response
	{
		Details = new List<FormulaOEMMissionsDetail>(10),
		PageMax = 1,
		PageNumber = 1
	});

	private readonly Lazy<C2S_GetFormulaOEMMissios.Request> _requestLazy = new Lazy<C2S_GetFormulaOEMMissios.Request>(() => new C2S_GetFormulaOEMMissios.Request
	{
		Filter = FormulaOemMissionsFilterExtensions.CreateDefaultFilter(),
		PageNumber = 1,
		PageCount = 10
	});

	public Action<FormulaOemMissionsFilter> OnFilterChange => _onFilterChange;

	private FormulaOEMMissionsDetail SelectingMission => OemMissions.Details[_selectingMissionIndex] ?? throw new ArgumentNullException(string.Format("UI_com_FormulaOemMissions {0} _selectingMissionIndex={1}", "SelectingMission", _selectingMissionIndex));

	private C2S_GetFormulaOEMMissios.Response OemMissions => _oemMissionsLazy.Value;

	public C2S_GetFormulaOEMMissios.Request GetOemMissionsRequest => _requestLazy.Value;

	public static string GetURL()
	{
		return "ui://tt2iq07osmtg2t";
	}

	public static UI_com_FormulaOemMissions CreateInstance()
	{
		return (UI_com_FormulaOemMissions)(object)UIPackage.CreateObject("GvGExchange3", "com_FormulaOemMissions");
	}

	public static UI_com_FormulaOemMissions CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaOemMissions).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07osmtg2t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		HasMission = ((GComponent)this).GetController("HasMission");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n21 = (GImage)((GComponent)this).GetChild("n21");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n20 = (GGroup)((GComponent)this).GetChild("n20");
		EmptyTip = (UI_com_TxtChange)(object)((GComponent)this).GetChild("EmptyTip");
		Filter = (UI_btn_FormulaOemFilter)(object)((GComponent)this).GetChild("Filter");
		TaitanActivated = (UI_btn_TaitanActivated)(object)((GComponent)this).GetChild("TaitanActivated");
		FormulaMissions = (GList)((GComponent)this).GetChild("FormulaMissions");
		TurnPage = (UI_com_PageTurn)(object)((GComponent)this).GetChild("TurnPage");
	}

	public void Init(Action displayFilterPanel)
	{
		_displayFilterPanel = displayFilterPanel;
		InitChildComponents();
		CreateActions();
		InitFormulaMissionsGList();
		UpdateFormulaOemMissions();
	}

	public void RegisterUiEvent()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		TaitanActivated.RegisterEvent();
		TurnPage.RegisterEvent();
		((GObject)Filter).onClick.Set(new EventCallback0(OnFilterBtnClick));
	}

	public void UnregisterUiEvent()
	{
		TaitanActivated.UnregisterEvent();
		TurnPage.UnregisterEvent();
		((GObject)Filter).onClick.Clear();
	}

	public void Destroy()
	{
		if (_updateMissionState != null)
		{
			FGUIManager.Instance.CloseIEnumerator(_updateMissionState);
			_updateMissionState = null;
		}
		_onSubmit = null;
		_displayFilterPanel = null;
		TaitanActivated.Destroy();
		TurnPage.Destroy();
	}

	private void InitFormulaMissionsGList()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		FormulaMissions.itemRenderer = new ListItemRenderer(MissionRenderer);
	}

	private void InitChildComponents()
	{
		TaitanActivated.Init(UpdateFilterHasTitan);
		TurnPage.Init(UpdateSelectingPage, OemMissions.PageNumber, OemMissions.PageMax);
	}

	private void CreateActions()
	{
		CreateActionOnFilterChange();
		CreateActionOnSubmit();
	}

	private void UpdateFormulaOemMissions()
	{
		_selectingMissionIndex = 0;
		Singleton<GvG3FlagshipReqManager>.Instance.GetFormulaOemMissions(GetOemMissionsRequest, UpdateFormulaMissions);
	}

	private void UpdateFormulaMissions(C2S_GetFormulaOEMMissios.Response response)
	{
		UpdateOemMissionDetails(response);
		RenderFormulaMissions();
		TryCreateMissionCountdown();
		TurnPage.RenderPageNumber(OemMissions.PageNumber, OemMissions.PageMax);
	}

	private void UpdateOemMissionDetails(C2S_GetFormulaOEMMissios.Response response)
	{
		OemMissions.Details.Clear();
		OemMissions.Details.AddRange(response.Details ?? new List<FormulaOEMMissionsDetail>());
		OemMissions.PageNumber = response.PageNumber;
		OemMissions.PageMax = response.PageMax;
	}

	private void UpdateSelectingPage(int pageNumber)
	{
		GetOemMissionsRequest.PageNumber = pageNumber;
		UpdateFormulaOemMissions();
	}

	private void UpdateFilterHasTitan(bool hasTitan)
	{
		GetOemMissionsRequest.Filter.HasTitanTalent = hasTitan;
		GetOemMissionsRequest.PageNumber = 1;
		UpdateFormulaOemMissions();
	}

	private void OnFilterBtnClick()
	{
		_displayFilterPanel?.Invoke();
	}

	private void CreateActionOnFilterChange()
	{
		_onFilterChange = delegate(FormulaOemMissionsFilter newFilter)
		{
			GetOemMissionsRequest.Filter = newFilter;
			GetOemMissionsRequest.PageNumber = 1;
			UpdateFormulaOemMissions();
		};
	}

	private void RenderFormulaMissions()
	{
		FormulaMissions.numItems = OemMissions.Details.Count;
		HasMission.selectedIndex = ((OemMissions.Details.Count <= 0) ? 1 : 0);
		bool flag = GetOemMissionsRequest.Filter.IsDefaultFilter();
		EmptyTip.Status.SetSelectedIndex(flag ? 1 : 0);
	}

	private void MissionRenderer(int index, GObject obj)
	{
		if (obj is UI_btn_OemFormula btn)
		{
			FormulaOEMMissionsDetail formulaOEMMissionsDetail = OemMissions.Details[index];
			OemMissionAmplifier oemMissionAmplifier = OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(formulaOEMMissionsDetail.AmpIdx);
			AmplifierModel amplifierModel = oemMissionAmplifier.AmplifierModel;
			RenderAmpRaceOrSoldier(btn, amplifierModel);
			RenderAmpRarity(btn, oemMissionAmplifier.AmplifierFormulaModel.Rarity);
			RenderOemMissionAvailable(btn, formulaOEMMissionsDetail.IsNotAvailable());
			RenderOemMissionGiverName(btn, formulaOEMMissionsDetail.UserId);
			RenderMissionCountdown(btn, formulaOEMMissionsDetail);
			RenderMissionTitan(btn, formulaOEMMissionsDetail);
			RenderMissionCriRate(btn, formulaOEMMissionsDetail);
			RenderMissionCount(btn, formulaOEMMissionsDetail);
			RenderAmpName(btn, amplifierModel);
			SetOemMissionBtnClickEvent(obj, index);
		}
	}

	private static void RenderAmpRaceOrSoldier(UI_btn_OemFormula btn, AmplifierModel amplifier)
	{
		bool flag = string.IsNullOrEmpty(amplifier.AffectedSoldier);
		if (flag)
		{
			RenderHelper_RaceTypeIcon.RenderAmplifierAffectedRace(btn.RaceType, amplifier);
		}
		else
		{
			RenderHelper_SimpleSolierIcon.RenderAmplifierAffectedSoldier(btn.AffectedSoldier, amplifier);
		}
		btn.IsShowRace.SetSelectedIndex(flag ? 1 : 0);
	}

	private static void RenderAmpRarity(UI_btn_OemFormula btn, int rarity)
	{
		btn.Rarity.SetSelectedIndex(rarity);
	}

	private static void RenderOemMissionAvailable(UI_btn_OemFormula btn, bool notAvailable)
	{
		btn.FormulaEnable.SetSelectedIndex(notAvailable ? 1 : 0);
	}

	private void RenderOemMissionGiverName(UI_btn_OemFormula btn, int userId)
	{
		GvG3ProfileHelper.GetUserProfile(new GvG3UserProfileRequestOptions(_curCacheId, userId, delegate(UserProfile profile)
		{
			if (!((GObject)btn).isDisposed)
			{
				((GObject)btn.PlayerName).text = profile.Name;
			}
		}));
	}

	private static void RenderAmpName(UI_btn_OemFormula btn, AmplifierModel amplifier)
	{
		((GObject)btn.FormulaName).text = amplifier.Name;
	}

	private static void RenderMissionCountdown(UI_btn_OemFormula btn, FormulaOEMMissionsDetail detail)
	{
		((GObject)btn.Countdown.Countdown).text = detail.GetMissionCountdown(out var countdownType);
		btn.Countdown.State.SetSelectedIndex(countdownType);
	}

	private static void RenderMissionCount(UI_btn_OemFormula btn, FormulaOEMMissionsDetail detail)
	{
		((GObject)btn.AvailableCount).text = detail.GetMissionAvailableCount();
	}

	private static void RenderMissionTitan(UI_btn_OemFormula btn, FormulaOEMMissionsDetail detail)
	{
		btn.Taitan.State.SetSelectedIndex(detail.HasTitanTalent ? 1 : 0);
	}

	private static void RenderMissionCriRate(UI_btn_OemFormula btn, FormulaOEMMissionsDetail detail)
	{
		btn.Crit.Color.SetSelectedIndex(detail.精益求精Level);
		((GObject)btn.Crit.CritValue).text = detail.GetMissionCriRate();
	}

	private void SetOemMissionBtnClickEvent(GObject btn, int index)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		btn.data = index;
		btn.onClick.Set(new EventCallback1(ShowMissionDetail));
	}

	private void ShowMissionDetail(EventContext context)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		int selectingMissionIndex = (int)((GObject)context.sender).data;
		_selectingMissionIndex = selectingMissionIndex;
		FormulaOEMMissionsDetail selectingMission = SelectingMission;
		if (!selectingMission.IsNotAvailable())
		{
			UnityUiService.Instance.OpenPanel(UI_main_GvG3FormulaForge.Name, new Dictionary<string, object>
			{
				{ "Muid", selectingMission.MUID },
				{ "ReloadAction", _onSubmit }
			});
		}
	}

	private void TryCreateMissionCountdown()
	{
		if (_updateMissionState == null)
		{
			_updateMissionState = FGUIManager.Instance.OpenIEnumerator(UpdateMissionsState());
		}
	}

	private IEnumerator UpdateMissionsState()
	{
		while (!((GObject)FormulaMissions).isDisposed)
		{
			yield return _perSecond;
			UpdateMissionsCountdown();
		}
	}

	private void UpdateMissionsCountdown()
	{
		for (int i = 0; i < ((GComponent)FormulaMissions).numChildren; i++)
		{
			int num = FormulaMissions.ChildIndexToItemIndex(i);
			if (((GComponent)FormulaMissions).GetChildAt(num) is UI_btn_OemFormula btn)
			{
				FormulaOEMMissionsDetail detail = OemMissions.Details[num];
				RenderMissionCountdown(btn, detail);
			}
		}
	}

	private void CreateActionOnSubmit()
	{
		_onSubmit = delegate
		{
			SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_RefreshFormulaOEMMissios
			{
				Req = new C2S_RefreshFormulaOEMMissios.Request
				{
					MUIDs = new List<int> { SelectingMission.MUID }
				}
			}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
			{
				C2S_RefreshFormulaOEMMissios.Response response = (C2S_RefreshFormulaOEMMissios.Response)contextResponse.Resp;
				if (response.ErrorCode != 0)
				{
					ILRequestHelper.ShowErrorCode(response.ErrorCode);
				}
				else
				{
					UpdateSubmitMission(response.Details);
				}
			});
		};
	}

	private void UpdateSubmitMission(List<FormulaOEMMissionsDetail> updateDetails)
	{
		UpdateDetails(updateDetails);
		RenderSelectingMissionUi();
	}

	private void UpdateDetails(List<FormulaOEMMissionsDetail> updateDetails)
	{
		if (updateDetails == null)
		{
			return;
		}
		Dictionary<int, FormulaOEMMissionsDetail> dictionary = new Dictionary<int, FormulaOEMMissionsDetail>();
		foreach (FormulaOEMMissionsDetail updateDetail in updateDetails)
		{
			dictionary.Add(updateDetail.MUID, updateDetail);
		}
		foreach (FormulaOEMMissionsDetail detail in OemMissions.Details)
		{
			if (dictionary.TryGetValue(detail.MUID, out var value))
			{
				detail.OverrideValues(value);
			}
		}
	}

	private void RenderSelectingMissionUi()
	{
		GObject childAt = ((GComponent)FormulaMissions).GetChildAt(_selectingMissionIndex);
		if (childAt != null)
		{
			MissionRenderer(_selectingMissionIndex, childAt);
		}
	}
}
