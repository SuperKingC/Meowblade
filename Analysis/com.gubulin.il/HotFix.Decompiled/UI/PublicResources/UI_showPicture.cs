using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_showPicture : GButton
{
	public Controller button;

	public Controller StatusController;

	public GLoader frame;

	public GLoader icon;

	public GTextField questionMark;

	public const string URL = "ui://kt6rg65opewc16";

	public static string Name = "UI_showPicture";

	public static string GetURL()
	{
		return "ui://kt6rg65opewc16";
	}

	public static UI_showPicture CreateInstance()
	{
		return (UI_showPicture)(object)UIPackage.CreateObject("PublicResources", "showPicture");
	}

	public static UI_showPicture CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_showPicture).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65opewc16", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		StatusController = ((GComponent)this).GetController("StatusController");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		questionMark = (GTextField)((GComponent)this).GetChild("questionMark");
	}
}
