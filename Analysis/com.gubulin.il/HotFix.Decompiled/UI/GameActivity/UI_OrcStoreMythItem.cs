using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_OrcStoreMythItem : GButton
{
	public Controller button;

	public GImage n7;

	public GLoader icon;

	public GTextField num;

	public const string URL = "ui://29q48tv6pav9f4z";

	public static string Name = "UI_OrcStoreMythItem";

	public static string GetURL()
	{
		return "ui://29q48tv6pav9f4z";
	}

	public static UI_OrcStoreMythItem CreateInstance()
	{
		return (UI_OrcStoreMythItem)(object)UIPackage.CreateObject("GameActivity", "OrcStoreMythItem");
	}

	public static UI_OrcStoreMythItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OrcStoreMythItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6pav9f4z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n7 = (GImage)((GComponent)this).GetChild("n7");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
	}
}
