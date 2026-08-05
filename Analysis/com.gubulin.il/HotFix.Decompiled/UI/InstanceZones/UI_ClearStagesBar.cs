using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_ClearStagesBar : GButton
{
	public Controller button;

	public Controller Status;

	public GImage bar;

	public GImage bar_2;

	public GImage bar_3;

	public GImage bar_4;

	public GImage bar_5;

	public const string URL = "ui://f4wr270rqfz859";

	public static string Name = "UI_ClearStagesBar";

	public static string GetURL()
	{
		return "ui://f4wr270rqfz859";
	}

	public static UI_ClearStagesBar CreateInstance()
	{
		return (UI_ClearStagesBar)(object)UIPackage.CreateObject("InstanceZones", "ClearStagesBar");
	}

	public static UI_ClearStagesBar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ClearStagesBar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rqfz859", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		bar = (GImage)((GComponent)this).GetChild("bar");
		bar_2 = (GImage)((GComponent)this).GetChild("bar");
		bar_3 = (GImage)((GComponent)this).GetChild("bar");
		bar_4 = (GImage)((GComponent)this).GetChild("bar");
		bar_5 = (GImage)((GComponent)this).GetChild("bar");
	}
}
