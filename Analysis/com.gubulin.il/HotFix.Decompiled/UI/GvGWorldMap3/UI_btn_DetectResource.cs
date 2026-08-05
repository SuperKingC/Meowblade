using FairyGUI;
using FairyGUI.Utils;
using GvG3;
using HotFix.Sources.Base.Sources.Scripts.GvG3WorldMap.Model;
using Shift.Legion.Common.Helpers;

namespace UI.GvGWorldMap3;

public class UI_btn_DetectResource : GButton
{
	public Controller button;

	public Controller IsAvailable;

	public GImage n3;

	public GImage n8;

	public UI_bar_01 CDProgress;

	public GImage n9;

	public GImage RedDot;

	public const string URL = "ui://4eq8fgd2pepcs7r";

	public static string Name = "UI_btn_DetectResource";

	private string ShipId;

	public static string GetURL()
	{
		return "ui://4eq8fgd2pepcs7r";
	}

	public static UI_btn_DetectResource CreateInstance()
	{
		return (UI_btn_DetectResource)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_DetectResource");
	}

	public static UI_btn_DetectResource CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_DetectResource).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2pepcs7r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		IsAvailable = ((GComponent)this).GetController("IsAvailable");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		CDProgress = (UI_bar_01)(object)((GComponent)this).GetChild("CDProgress");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
	}

	public void Render(bool isDetectorActive, string shipId)
	{
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		ShipId = shipId;
		if (isDetectorActive && !Singleton<GvGTalent勘探强化Manager>.Instance.GetShipCountDown(ShipId).IsExpired())
		{
			UpdateTimeCounting();
			((GObject)RedDot).visible = Singleton<GvGTalent勘探强化Manager>.Instance.HasNotice();
			IsAvailable.selectedIndex = 0;
			if (!Timers.inst.Exists(new TimerCallback(UpdateTimeCounting)))
			{
				Timers.inst.Add(1f, 0, new TimerCallback(UpdateTimeCounting));
			}
		}
		else
		{
			IsAvailable.selectedIndex = 1;
			if (Timers.inst.Exists(new TimerCallback(UpdateTimeCounting)))
			{
				Timers.inst.Remove(new TimerCallback(UpdateTimeCounting));
			}
		}
	}

	private void UpdateTimeCounting(object p = null)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		if (((GObject)this).isDisposed)
		{
			if (Timers.inst.Exists(new TimerCallback(UpdateTimeCounting)))
			{
				Timers.inst.Remove(new TimerCallback(UpdateTimeCounting));
			}
			return;
		}
		ShipCountDown_勘探强化 shipCountDown = Singleton<GvGTalent勘探强化Manager>.Instance.GetShipCountDown(ShipId);
		float num = shipCountDown.GetRemainingCountdownPecent() * 100f;
		((GProgressBar)CDProgress).value = num;
		if (num == 0f)
		{
			IsAvailable.selectedIndex = 1;
			if (Timers.inst.Exists(new TimerCallback(UpdateTimeCounting)))
			{
				Timers.inst.Remove(new TimerCallback(UpdateTimeCounting));
			}
		}
	}
}
