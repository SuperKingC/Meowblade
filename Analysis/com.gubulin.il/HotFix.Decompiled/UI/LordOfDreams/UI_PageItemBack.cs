using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_PageItemBack : GButton
{
	public Controller button;

	public GImage n6;

	public const string URL = "ui://0i520nzmtajuo8v";

	public static string Name = "UI_PageItemBack";

	public static string GetURL()
	{
		return "ui://0i520nzmtajuo8v";
	}

	public static UI_PageItemBack CreateInstance()
	{
		return (UI_PageItemBack)(object)UIPackage.CreateObject("LordOfDreams", "PageItemBack");
	}

	public static UI_PageItemBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PageItemBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmtajuo8v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
