using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using UI.Contract;
using UI.GameEndPanels;
using UI.Legion;
using UI.QuickBattle;
using UI.RecruitingCamp;
using UI.UpGrade;

namespace UI.PvpSelectSoldiers;

public class UI_PvpBattleFail : GComponent, IUiController
{
	public GLoader background;

	public GGraph BlackMask;

	public GImage DropBackground;

	public GGraph n113;

	public UI_GoToCamp GoToCamp;

	public UI_GoToLegion GoToLegion;

	public UI_GoToContract GoToContract;

	public GTextField n114;

	public GGroup Choose;

	public UI_YesButton YesButton;

	public GImage n115;

	public Transition V_Rotate;

	public const string URL = "ui://82mo10n5hcbs6x";

	public static string Name = "UI_PvpBattleFail";

	private int battleResult = 1;

	private object battleStats;

	private string battleId;

	private bool isQuickBattle;

	public static string GetURL()
	{
		return "ui://82mo10n5hcbs6x";
	}

	public static UI_PvpBattleFail CreateInstance()
	{
		return (UI_PvpBattleFail)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PvpBattleFail");
	}

	public static UI_PvpBattleFail CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PvpBattleFail).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5hcbs6x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GLoader)((GComponent)this).GetChild("background");
		BlackMask = (GGraph)((GComponent)this).GetChild("BlackMask");
		DropBackground = (GImage)((GComponent)this).GetChild("DropBackground");
		n113 = (GGraph)((GComponent)this).GetChild("n113");
		GoToCamp = (UI_GoToCamp)(object)((GComponent)this).GetChild("GoToCamp");
		GoToLegion = (UI_GoToLegion)(object)((GComponent)this).GetChild("GoToLegion");
		GoToContract = (UI_GoToContract)(object)((GComponent)this).GetChild("GoToContract");
		n114 = (GTextField)((GComponent)this).GetChild("n114");
		string id = "ui://82mo10n5hcbs6x".Replace("ui://", "") + "-" + ((GObject)n114).id;
		((GObject)n114).text = LanguagesManager.GetDesc(id);
		Choose = (GGroup)((GComponent)this).GetChild("Choose");
		YesButton = (UI_YesButton)(object)((GComponent)this).GetChild("YesButton");
		n115 = (GImage)((GComponent)this).GetChild("n115");
		V_Rotate = ((GComponent)this).GetTransition("V_Rotate");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}

	public void Init(Dictionary<string, object> parameters)
	{
		((GObject)BlackMask).alpha = 0.6f;
		if (parameters.TryGetValue("BattleId", out var value))
		{
			battleId = value.ToString();
		}
		if (parameters.TryGetValue("BattleResult", out var value2))
		{
			battleResult = (int)value2;
		}
		if (parameters.TryGetValue("BattleStats", out var value3))
		{
			battleStats = value3;
		}
		if (parameters.TryGetValue("isQuickBattle", out var value4) && (bool)value4)
		{
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
			isQuickBattle = true;
		}
		else
		{
			FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
			isQuickBattle = false;
		}
	}

	public void OnShow()
	{
		UiAudioManager.Instance.PlayBackgroundSound("BattleFail");
		Dictionary<string, object> parameters = new Dictionary<string, object>
		{
			{
				"SortingOrder",
				((GObject)this).sortingOrder + 1
			},
			{ "BattleResult", battleResult },
			{ "BattleStats", battleStats },
			{ "ShowLookBack", true },
			{ "isRankBattle", true },
			{ "BattleId", battleId }
		};
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_DamageMeter.Name, parameters);
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		((GObject)YesButton).onClick.Add(new EventCallback1(ConfirmBtnClickEvent));
		((GObject)GoToContract).onClick.Add(new EventCallback0(OpenContract));
		((GObject)GoToCamp).onClick.Add(new EventCallback0(OpenCamp));
		((GObject)GoToLegion).onClick.Add(new EventCallback0(OpenLegion));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		((GObject)YesButton).onClick.Remove(new EventCallback1(ConfirmBtnClickEvent));
		((GObject)GoToContract).onClick.Remove(new EventCallback0(OpenContract));
		((GObject)GoToCamp).onClick.Remove(new EventCallback0(OpenCamp));
		((GObject)GoToLegion).onClick.Remove(new EventCallback0(OpenLegion));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
		{
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null },
			{
				"LoadingAnimationDirection",
				LoadingAnimationDirection.Left
			},
			{
				"OpenUiOnReturn",
				UI_LadderTournamentPanel.Name
			}
		}));
	}

	private void ReturnToLadderTournamentPanel()
	{
		List<string> panelsName = new List<string>
		{
			UI_DamageMeter.Name,
			Name,
			UI_QuickBattlePanel.Name,
			UI_PvPBattleResultAnimationEffect.Name,
			UI_PvpSelectSoldiersPanel.Name
		};
		GameController.Contexts.Service<IUiService>().CloseSomePanels(panelsName, reservePackageRes: true, ignoreLoading: true, edgeMaskVisible: true);
		UI_LadderTournamentPanel.LadderTournamentPanel?.UpdatePanel();
	}

	private void ConfirmBtnClickEvent(EventContext context)
	{
		if (isQuickBattle)
		{
			ReturnToLadderTournamentPanel();
		}
		else
		{
			End();
		}
	}

	private void OpenCamp()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		Building buildingByType = GameManagers.Instance.BuildingManager.GetBuildingByType("10");
		if (buildingByType.Status == BuildingStatus.Banned)
		{
			List<string> arg = new List<string>
			{
				LanguagesManager.GetDesc("CsharpCodeZhTcText21"),
				LanguagesManager.GetDesc("CsharpCodeZhTcText22")
			};
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 120, arg3: false);
			return;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		string text = "";
		if (buildingByType.Status == BuildingStatus.Ready)
		{
			dictionary.Add("Parent", this);
			dictionary.Add("Building", buildingByType);
			text = UI_UpGradePanel.Name;
		}
		else if (buildingByType.Level == 0)
		{
			dictionary.Add("Building", buildingByType);
			dictionary.Add("Parent", this);
			text = UI_UpGradePanel.Name;
		}
		else
		{
			text = UI_RecruitingCamp.Name;
		}
		CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
		{
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null },
			{
				"LoadingAnimationDirection",
				LoadingAnimationDirection.Left
			},
			{ "OpenUiOnReturn", text },
			{ "UiParamsOnReturn", dictionary }
		}));
	}

	private void OpenLegion()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Style", "Self");
		CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
		{
			{ "ForceCloseOtherUi", true },
			{ "TaskCompletionSource", null },
			{
				"LoadingAnimationDirection",
				LoadingAnimationDirection.Left
			},
			{
				"OpenUiOnReturn",
				UI_LegionPanel.Name
			},
			{ "UiParamsOnReturn", dictionary }
		}));
	}

	private void OpenContract()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name);
		if (GameManagers.Instance.BuildingManager.GetBuildingByType("16").Level > 0)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("Parent", this);
			CommandFactory.CreateOpenSceneCommand("MainCity.Right", new SceneArguments(new Dictionary<string, object>
			{
				{ "ForceCloseOtherUi", true },
				{ "TaskCompletionSource", null },
				{
					"LoadingAnimationDirection",
					LoadingAnimationDirection.Left
				},
				{
					"OpenUiOnReturn",
					UI_ContractPanel.Name
				},
				{ "UiParamsOnReturn", dictionary }
			}));
		}
		else
		{
			List<string> arg = new List<string> { LanguagesManager.GetDesc("CsharpCodeZhTcText152") };
			SharedMessenger.Broadcast("SHOW_TIPS", arg, 120, arg3: false);
		}
	}
}
