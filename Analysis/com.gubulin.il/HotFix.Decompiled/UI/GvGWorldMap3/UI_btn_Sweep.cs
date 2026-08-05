using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Extensions;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace UI.GvGWorldMap3;

public class UI_btn_Sweep : GButton
{
	private enum ClickMode
	{
		Normal,
		Fighting,
		NotOwnSide
	}

	public Controller button;

	public GImage n6;

	public GImage n5;

	public const string URL = "ui://4eq8fgd2qjkisaj";

	public static string Name = "UI_btn_Sweep";

	private const string _ERROR_CODE_FIGHTING = "ErrorCode_-8151";

	private const string _ERROR_CODE_NOT_OWN_SIDE = "ErrorCode_-8157";

	private ClickMode _mode;

	private static readonly Dictionary<ClickMode, string> _code = new Dictionary<ClickMode, string>(2)
	{
		{
			ClickMode.NotOwnSide,
			"ErrorCode_-8157"
		},
		{
			ClickMode.Fighting,
			"ErrorCode_-8151"
		}
	};

	public static string GetURL()
	{
		return "ui://4eq8fgd2qjkisaj";
	}

	public static UI_btn_Sweep CreateInstance()
	{
		return (UI_btn_Sweep)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_Sweep");
	}

	public static UI_btn_Sweep CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Sweep).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2qjkisaj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}

	public void OnLoad()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((GObject)this).onClick.Set(new EventCallback0(OnClick));
	}

	public void OnUnload()
	{
		((GObject)this).onClick.Clear();
	}

	public void OnRender(IslandStateModel islandState)
	{
		if (SetVisible(islandState.IslandId))
		{
			SetGrayed(islandState);
		}
	}

	private bool SetVisible(int islandsId)
	{
		string serverMapId = Singleton<WorldStateManager>.Instance.TryGetIsland(islandsId).DetailInfo.ServerMapId;
		string value = GDMgr.Get<GDEGvGIslandMapConfigData>(serverMapId)?.SweepReward;
		bool flag = !string.IsNullOrEmpty(value);
		bool flag2 = Singleton<WorldStateManager>.Instance.Data.Talents.HasTalent(eTalent.天空霸主);
		((GObject)this).visible = flag2 && flag;
		return ((GObject)this).visible;
	}

	private void SetGrayed(IslandStateModel islandState)
	{
		bool flag = islandState.GetNpcStatus() != eGvGMode3IslandNPCStatus.Obedience;
		bool flag2 = islandState.State == eGvGMode3IslandState.Fighting || islandState.State == eGvGMode3IslandState.Suppress;
		bool flag3 = islandState.GetBelongStatus() != eGvGMode3IslandBelongStatus.OwnSide;
		((GObject)this).grayed = flag || flag2 || flag3;
		_mode = (((GObject)this).grayed ? ((!flag3) ? ClickMode.Fighting : ClickMode.NotOwnSide) : ClickMode.Normal);
	}

	private void OnClick()
	{
		if (_mode == ClickMode.Normal)
		{
			UI_com_IslandCardLoader.OnClickSweep?.Invoke();
		}
		else
		{
			_code[_mode].ToShowLanguageTip();
		}
	}
}
