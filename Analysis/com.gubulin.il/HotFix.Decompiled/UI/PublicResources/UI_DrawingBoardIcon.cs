using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_DrawingBoardIcon : GButton
{
	public Controller button;

	public GGraph mask;

	public GLoader icon;

	public const string URL = "ui://kt6rg65oo4kt1b";

	public static string Name = "UI_DrawingBoardIcon";

	public static string GetURL()
	{
		return "ui://kt6rg65oo4kt1b";
	}

	public static UI_DrawingBoardIcon CreateInstance()
	{
		return (UI_DrawingBoardIcon)(object)UIPackage.CreateObject("PublicResources", "DrawingBoardIcon");
	}

	public static UI_DrawingBoardIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DrawingBoardIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oo4kt1b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		mask = (GGraph)((GComponent)this).GetChild("mask");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
