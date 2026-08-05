using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_DescContainer : GComponent
{
	public GTextField Desc;

	public const string URL = "ui://k19peou7smkl6p8u";

	public static string Name = "UI_DescContainer";

	public static string GetURL()
	{
		return "ui://k19peou7smkl6p8u";
	}

	public static UI_DescContainer CreateInstance()
	{
		return (UI_DescContainer)(object)UIPackage.CreateObject("GvGExpeditionHall", "DescContainer");
	}

	public static UI_DescContainer CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DescContainer).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7smkl6p8u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
	}
}
