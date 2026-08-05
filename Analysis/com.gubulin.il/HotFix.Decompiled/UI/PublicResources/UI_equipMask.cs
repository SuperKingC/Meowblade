using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_equipMask : GButton
{
	public Controller button;

	public GGraph redMask;

	public GImage n6;

	public const string URL = "ui://kt6rg65oj93ujo";

	public static string Name = "UI_equipMask";

	public static string GetURL()
	{
		return "ui://kt6rg65oj93ujo";
	}

	public static UI_equipMask CreateInstance()
	{
		return (UI_equipMask)(object)UIPackage.CreateObject("PublicResources", "equipMask");
	}

	public static UI_equipMask CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_equipMask).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oj93ujo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
