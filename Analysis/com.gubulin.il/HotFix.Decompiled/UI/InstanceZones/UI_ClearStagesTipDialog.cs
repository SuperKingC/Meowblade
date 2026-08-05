using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.InstanceZones;

public class UI_ClearStagesTipDialog : GComponent
{
	public GImage background;

	public GTextField n1;

	public GTextField num;

	public GGraph n4;

	public GTextField n5;

	public GTextField tip;

	public const string URL = "ui://f4wr270rqfz85c";

	public static string Name = "UI_ClearStagesTipDialog";

	public static string GetURL()
	{
		return "ui://f4wr270rqfz85c";
	}

	public static UI_ClearStagesTipDialog CreateInstance()
	{
		return (UI_ClearStagesTipDialog)(object)UIPackage.CreateObject("InstanceZones", "ClearStagesTipDialog");
	}

	public static UI_ClearStagesTipDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ClearStagesTipDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://f4wr270rqfz85c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		background = (GImage)((GComponent)this).GetChild("background");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://f4wr270rqfz85c".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		num = (GTextField)((GComponent)this).GetChild("num");
		string id2 = "ui://f4wr270rqfz85c".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id2);
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id3 = "ui://f4wr270rqfz85c".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id3);
		tip = (GTextField)((GComponent)this).GetChild("tip");
	}
}
