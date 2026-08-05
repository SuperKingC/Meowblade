using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_BuildTimeInfo : GComponent
{
	public GImage n147;

	public GLoader icon;

	public GTextField Info;

	public GImage n150;

	public const string URL = "ui://k19peou7mm1mp6g";

	public static string Name = "UI_com_BuildTimeInfo";

	public static string GetURL()
	{
		return "ui://k19peou7mm1mp6g";
	}

	public static UI_com_BuildTimeInfo CreateInstance()
	{
		return (UI_com_BuildTimeInfo)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_BuildTimeInfo");
	}

	public static UI_com_BuildTimeInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BuildTimeInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7mm1mp6g", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n147 = (GImage)((GComponent)this).GetChild("n147");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		Info = (GTextField)((GComponent)this).GetChild("Info");
		n150 = (GImage)((GComponent)this).GetChild("n150");
	}
}
