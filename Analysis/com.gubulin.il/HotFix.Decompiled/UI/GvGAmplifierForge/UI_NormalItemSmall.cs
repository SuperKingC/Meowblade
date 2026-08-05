using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_NormalItemSmall : GComponent
{
	public GLoader frame;

	public GLoader back;

	public GLoader icon;

	public const string URL = "ui://fpjheycbslenv4gg";

	public static string Name = "UI_NormalItemSmall";

	public static string GetURL()
	{
		return "ui://fpjheycbslenv4gg";
	}

	public static UI_NormalItemSmall CreateInstance()
	{
		return (UI_NormalItemSmall)(object)UIPackage.CreateObject("GvGAmplifierForge", "NormalItemSmall");
	}

	public static UI_NormalItemSmall CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_NormalItemSmall).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbslenv4gg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		frame = (GLoader)((GComponent)this).GetChild("frame");
		back = (GLoader)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
