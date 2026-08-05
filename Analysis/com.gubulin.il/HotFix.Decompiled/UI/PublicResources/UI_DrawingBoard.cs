using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_DrawingBoard : GComponent
{
	public Controller PageController;

	public GImage back;

	public UI_DrawingBoardIcon Icon;

	public GImage newIcon;

	public Transition flashing;

	public const string URL = "ui://kt6rg65oo4kt1a";

	public static string Name = "UI_DrawingBoard";

	public static string GetURL()
	{
		return "ui://kt6rg65oo4kt1a";
	}

	public static UI_DrawingBoard CreateInstance()
	{
		return (UI_DrawingBoard)(object)UIPackage.CreateObject("PublicResources", "DrawingBoard");
	}

	public static UI_DrawingBoard CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DrawingBoard).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oo4kt1a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		back = (GImage)((GComponent)this).GetChild("back");
		Icon = (UI_DrawingBoardIcon)(object)((GComponent)this).GetChild("Icon");
		newIcon = (GImage)((GComponent)this).GetChild("newIcon");
		flashing = ((GComponent)this).GetTransition("flashing");
	}
}
