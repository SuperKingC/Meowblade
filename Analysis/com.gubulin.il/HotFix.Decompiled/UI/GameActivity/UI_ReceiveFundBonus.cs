using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_ReceiveFundBonus : GButton
{
	public Controller button;

	public GImage background;

	public GImage note;

	public GLoader icon;

	public const string URL = "ui://29q48tv6n44140";

	public static string Name = "UI_ReceiveFundBonus";

	public static string GetURL()
	{
		return "ui://29q48tv6n44140";
	}

	public static UI_ReceiveFundBonus CreateInstance()
	{
		return (UI_ReceiveFundBonus)(object)UIPackage.CreateObject("GameActivity", "ReceiveFundBonus");
	}

	public static UI_ReceiveFundBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReceiveFundBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6n44140", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		background = (GImage)((GComponent)this).GetChild("background");
		note = (GImage)((GComponent)this).GetChild("note");
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
