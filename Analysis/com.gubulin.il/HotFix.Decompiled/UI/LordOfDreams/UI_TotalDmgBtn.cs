using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_TotalDmgBtn : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://0i520nzm121eo4f";

	public static string Name = "UI_TotalDmgBtn";

	public static string GetURL()
	{
		return "ui://0i520nzm121eo4f";
	}

	public static UI_TotalDmgBtn CreateInstance()
	{
		return (UI_TotalDmgBtn)(object)UIPackage.CreateObject("LordOfDreams", "TotalDmgBtn");
	}

	public static UI_TotalDmgBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TotalDmgBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzm121eo4f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
