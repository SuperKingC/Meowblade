using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_AreaEarningsInfo : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n8;

	public GImage n9;

	public GTextField areaName;

	public GList curEarnings;

	public GTextField tip;

	public UI_AdjustBtn TotalExclamationMarkBtn;

	public const string URL = "ui://c9n2h0ksf258a2";

	public static string Name = "UI_AreaEarningsInfo";

	public static string GetURL()
	{
		return "ui://c9n2h0ksf258a2";
	}

	public static UI_AreaEarningsInfo CreateInstance()
	{
		return (UI_AreaEarningsInfo)(object)UIPackage.CreateObject("WorldMap", "AreaEarningsInfo");
	}

	public static UI_AreaEarningsInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AreaEarningsInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksf258a2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		areaName = (GTextField)((GComponent)this).GetChild("areaName");
		string id = "ui://c9n2h0ksf258a2".Replace("ui://", "") + "-" + ((GObject)areaName).id;
		((GObject)areaName).text = LanguagesManager.GetDesc(id);
		curEarnings = (GList)((GComponent)this).GetChild("curEarnings");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://c9n2h0ksf258a2".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		TotalExclamationMarkBtn = (UI_AdjustBtn)(object)((GComponent)this).GetChild("TotalExclamationMarkBtn");
	}
}
