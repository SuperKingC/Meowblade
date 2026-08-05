using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using Shift.Legion.Common.Services;
using Shift.Legion.GvG.Common.Models.GvGMode3.Mission;
using UI.GvG3MainStorylineQuest;

namespace UI.GvGWorldMap3;

public class UI_btn_ProgressReward : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField n4;

	public const string URL = "ui://4eq8fgd2h5gss8w";

	public static string Name = "UI_btn_ProgressReward";

	private int _progress = -1;

	public static string GetURL()
	{
		return "ui://4eq8fgd2h5gss8w";
	}

	public static UI_btn_ProgressReward CreateInstance()
	{
		return (UI_btn_ProgressReward)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_ProgressReward");
	}

	public static UI_btn_ProgressReward CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ProgressReward).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h5gss8w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://4eq8fgd2h5gss8w".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
	}

	public void OnLoad()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((GObject)this).onClick.Set(new EventCallback0(OnClick));
	}

	public void OnClose()
	{
		((GObject)this).onClick.Clear();
	}

	public void OnRender(int islandId)
	{
		GvGMode3CampProgressConfigModel gvGMode3CampProgressConfigModel = GvG3FlagShipMissionsConfigHelper.CampMainProgressConfig.Find((GvGMode3CampProgressConfigModel config) => config.CampControlMoonIsland == islandId);
		if (gvGMode3CampProgressConfigModel == null)
		{
			((GObject)this).visible = false;
			return;
		}
		((GObject)this).visible = true;
		_progress = gvGMode3CampProgressConfigModel.Progress;
	}

	private void OnClick()
	{
		if (_progress <= 0)
		{
			throw new Exception($"UI_btn_ProgressReward _progress={_progress} is invalid");
		}
		GameController.Contexts.Service<IUiService>().OpenPanel(UI_main_ProgressRewardPreview.Name, new Dictionary<string, object> { { "CurProgress", _progress } });
	}
}
