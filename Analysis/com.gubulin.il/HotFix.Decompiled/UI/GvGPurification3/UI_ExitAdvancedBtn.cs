using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPurification3;

public class UI_ExitAdvancedBtn : GButton
{
	public Controller button;

	public GImage n5;

	public const string URL = "ui://v7vqvgvmkvzvld";

	public static string Name = "UI_ExitAdvancedBtn";

	public static string GetURL()
	{
		return "ui://v7vqvgvmkvzvld";
	}

	public static UI_ExitAdvancedBtn CreateInstance()
	{
		return (UI_ExitAdvancedBtn)(object)UIPackage.CreateObject("GvGPurification3", "ExitAdvancedBtn");
	}

	public static UI_ExitAdvancedBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExitAdvancedBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://v7vqvgvmkvzvld", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
