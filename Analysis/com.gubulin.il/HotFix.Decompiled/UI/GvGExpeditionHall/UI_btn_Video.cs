using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Sources.Enums;

namespace UI.GvGExpeditionHall;

public class UI_btn_Video : GButton
{
	public Controller button;

	public GImage n8;

	public GImage n9;

	public GImage RedDot;

	public GImage n10;

	public const string URL = "ui://k19peou7jrm3p6o";

	public static string Name = "UI_btn_Video";

	public static string GetURL()
	{
		return "ui://k19peou7jrm3p6o";
	}

	public static UI_btn_Video CreateInstance()
	{
		return (UI_btn_Video)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_Video");
	}

	public static UI_btn_Video CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_Video).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7jrm3p6o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
		n10 = (GImage)((GComponent)this).GetChild("n10");
	}

	public void CheckRedDot()
	{
		((GObject)RedDot).visible = false;
		foreach (KeyValuePair<string, Mission> videoMission in MissionManager.VideoMissions)
		{
			if (videoMission.Value.MissionState(GameManagers.Instance).Status != MissionStatus.Completed)
			{
				continue;
			}
			((GObject)RedDot).visible = true;
			break;
		}
	}
}
