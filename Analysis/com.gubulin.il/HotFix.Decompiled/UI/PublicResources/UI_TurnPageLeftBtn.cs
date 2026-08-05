using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_TurnPageLeftBtn : GButton
{
	public Controller button;

	public GGraph n4;

	public GImage n3;

	public const string URL = "ui://kt6rg65omol0hr";

	public static string Name = "UI_TurnPageLeftBtn";

	public static string GetURL()
	{
		return "ui://kt6rg65omol0hr";
	}

	public static UI_TurnPageLeftBtn CreateInstance()
	{
		return (UI_TurnPageLeftBtn)(object)UIPackage.CreateObject("PublicResources", "TurnPageLeftBtn");
	}

	public static UI_TurnPageLeftBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TurnPageLeftBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65omol0hr", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n4 = (GGraph)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
