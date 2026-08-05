using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_ReplenishBtnDark : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n4;

	public GGraph n5;

	public const string URL = "ui://k2sprg26noxc9c";

	public static string Name = "UI_ReplenishBtnDark";

	public static string GetURL()
	{
		return "ui://k2sprg26noxc9c";
	}

	public static UI_ReplenishBtnDark CreateInstance()
	{
		return (UI_ReplenishBtnDark)(object)UIPackage.CreateObject("IslandComeAgain", "ReplenishBtnDark");
	}

	public static UI_ReplenishBtnDark CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReplenishBtnDark).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26noxc9c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GGraph)((GComponent)this).GetChild("n5");
	}
}
