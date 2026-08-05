using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.GvG.Common.Models.GvGMode3;

namespace UI.GvGWorldMap3;

public class UI_com_IslandNpc : GComponent
{
	public Controller Status;

	public GImage n3;

	public GTextField n0;

	public GTextField n1;

	public GLoader n4;

	public const string URL = "ui://4eq8fgd2h4tpdv";

	public static string Name = "UI_com_IslandNpc";

	public static string GetURL()
	{
		return "ui://4eq8fgd2h4tpdv";
	}

	public static UI_com_IslandNpc CreateInstance()
	{
		return (UI_com_IslandNpc)(object)UIPackage.CreateObject("GvGWorldMap3", "com_IslandNpc");
	}

	public static UI_com_IslandNpc CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_IslandNpc).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2h4tpdv", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://4eq8fgd2h4tpdv".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id2 = "ui://4eq8fgd2h4tpdv".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id2);
		n4 = (GLoader)((GComponent)this).GetChild("n4");
	}

	public void OnRender(IslandStateModel islandState, List<UI_main_IslandDefenders.UnitInfo> unitInfos)
	{
		bool flag = unitInfos.Any((UI_main_IslandDefenders.UnitInfo u) => u.HasBoss);
		bool flag2 = islandState.IslandEvents.Any((IIslandEvent e) => e.EventType.IsBattleRandomEvent());
		Status.SetSelectedIndex(flag2 ? 1 : (flag ? 2 : 0));
	}
}
