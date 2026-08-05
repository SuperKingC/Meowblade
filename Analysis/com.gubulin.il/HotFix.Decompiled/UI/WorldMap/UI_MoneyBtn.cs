using FairyGUI;
using FairyGUI.Utils;

namespace UI.WorldMap;

public class UI_MoneyBtn : GButton
{
	public Controller button;

	public GGraph SfxBack;

	public GImage icon;

	public const string URL = "ui://c9n2h0ksm7wz90";

	public static string Name = "UI_MoneyBtn";

	public static string GetURL()
	{
		return "ui://c9n2h0ksm7wz90";
	}

	public static UI_MoneyBtn CreateInstance()
	{
		return (UI_MoneyBtn)(object)UIPackage.CreateObject("WorldMap", "MoneyBtn");
	}

	public static UI_MoneyBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MoneyBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://c9n2h0ksm7wz90", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		icon = (GImage)((GComponent)this).GetChild("icon");
	}
}
