using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_chip : GButton
{
	public Controller button;

	public UI_chipSon chipSon;

	public GLoader frame;

	public const string URL = "ui://kt6rg65ovv0uee";

	public static string Name = "UI_chip";

	public static string GetURL()
	{
		return "ui://kt6rg65ovv0uee";
	}

	public static UI_chip CreateInstance()
	{
		return (UI_chip)(object)UIPackage.CreateObject("PublicResources", "chip");
	}

	public static UI_chip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_chip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovv0uee", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		chipSon = (UI_chipSon)(object)((GComponent)this).GetChild("chipSon");
		frame = (GLoader)((GComponent)this).GetChild("frame");
	}
}
