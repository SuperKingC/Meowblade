using System;
using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Manager;
using Shift.Legion.Common.Helpers;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket;

namespace UI.GvGWorldMap3;

public class UI_btn_BattlePass : GButton, IFairyComponent
{
	public Controller button;

	public GImage n7;

	public GImage n3;

	public GImage n5;

	public GImage RedDot;

	public const string URL = "ui://4eq8fgd2tzhp8h";

	public static string Name = "UI_btn_BattlePass";

	private readonly List<UI_com_Contribution> _addContributions = new List<UI_com_Contribution>();

	private float PosX => ((GObject)this).width / 2f;

	public static string GetURL()
	{
		return "ui://4eq8fgd2tzhp8h";
	}

	public static UI_btn_BattlePass CreateInstance()
	{
		return (UI_btn_BattlePass)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_BattlePass");
	}

	public static UI_btn_BattlePass CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BattlePass).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2tzhp8h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
	}

	public void Destroy()
	{
		_addContributions.Clear();
	}

	public void Init()
	{
	}

	public void RegisterUiEvent()
	{
		WorldStateManager instance = Singleton<WorldStateManager>.Instance;
		instance.OnContributionPointsChanged = (Action<ContributionPointsChanged>)Delegate.Combine(instance.OnContributionPointsChanged, new Action<ContributionPointsChanged>(Render));
	}

	public void UnregisterUiEvent()
	{
		WorldStateManager instance = Singleton<WorldStateManager>.Instance;
		instance.OnContributionPointsChanged = (Action<ContributionPointsChanged>)Delegate.Remove(instance.OnContributionPointsChanged, new Action<ContributionPointsChanged>(Render));
	}

	private void Render(ContributionPointsChanged contributionPointsChanged)
	{
		UI_com_Contribution uI_com_Contribution = null;
		foreach (UI_com_Contribution addContribution in _addContributions)
		{
			if (addContribution.Available)
			{
				uI_com_Contribution = addContribution;
				break;
			}
		}
		if (uI_com_Contribution == null)
		{
			uI_com_Contribution = UI_com_Contribution.CreateInstance_ILRuntime();
			((GComponent)this).AddChild((GObject)(object)uI_com_Contribution);
			((GObject)uI_com_Contribution).SetXY(PosX, 0f);
			_addContributions.Add(uI_com_Contribution);
		}
		uI_com_Contribution.ShowSelf(contributionPointsChanged);
	}
}
