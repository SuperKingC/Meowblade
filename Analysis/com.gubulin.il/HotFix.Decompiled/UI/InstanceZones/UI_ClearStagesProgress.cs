using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_ClearStagesProgress : GProgressBar
{
	public Controller Status;

	public Controller Type;

	public GImage n23;

	public UI_ClearStagesBar bar;

	public UI_ClearStagesLogo logo;

	public GTextField curNum;

	public GTextField tip;

	public GTextField totalNum;

	public const string URL = "ui://f4wr270rqfz84t";

	public static string Name = "UI_ClearStagesProgress";

	public static string GetURL()
	{
		return "ui://f4wr270rqfz84t";
	}

	public static UI_ClearStagesProgress CreateInstance()
	{
		return (UI_ClearStagesProgress)(object)UIPackage.CreateObject("InstanceZones", "ClearStagesProgress");
	}

	public static UI_ClearStagesProgress CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ClearStagesProgress).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rqfz84t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		Type = ((GComponent)this).GetController("Type");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		bar = (UI_ClearStagesBar)(object)((GComponent)this).GetChild("bar");
		logo = (UI_ClearStagesLogo)(object)((GComponent)this).GetChild("logo");
		curNum = (GTextField)((GComponent)this).GetChild("curNum");
		string id = "ui://f4wr270rqfz84t".Replace("ui://", "") + "-" + ((GObject)curNum).id;
		((GObject)curNum).text = LanguagesManager.GetDesc(id);
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://f4wr270rqfz84t".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		totalNum = (GTextField)((GComponent)this).GetChild("totalNum");
		string id3 = "ui://f4wr270rqfz84t".Replace("ui://", "") + "-" + ((GObject)totalNum).id;
		((GObject)totalNum).text = LanguagesManager.GetDesc(id3);
	}
}
