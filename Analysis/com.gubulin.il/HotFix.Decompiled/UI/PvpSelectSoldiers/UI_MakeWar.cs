using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_MakeWar : GButton
{
	public Controller button;

	public GImage n13;

	public GImage n9;

	public GGroup n12;

	public const string URL = "ui://82mo10n5gwv069";

	public static string Name = "UI_MakeWar";

	public static string GetURL()
	{
		return "ui://82mo10n5gwv069";
	}

	public static UI_MakeWar CreateInstance()
	{
		return (UI_MakeWar)(object)UIPackage.CreateObject("PvpSelectSoldiers", "MakeWar");
	}

	public static UI_MakeWar CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MakeWar).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5gwv069", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n12 = (GGroup)((GComponent)this).GetChild("n12");
	}
}
