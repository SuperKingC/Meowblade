using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_frameMask : GButton
{
	public Controller button;

	public GGraph redMask;

	public GImage n7;

	public const string URL = "ui://kt6rg65oj93ujp";

	public static string Name = "UI_frameMask";

	public static string GetURL()
	{
		return "ui://kt6rg65oj93ujp";
	}

	public static UI_frameMask CreateInstance()
	{
		return (UI_frameMask)(object)UIPackage.CreateObject("PublicResources", "frameMask");
	}

	public static UI_frameMask CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_frameMask).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oj93ujp", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		redMask = (GGraph)((GComponent)this).GetChild("redMask");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
