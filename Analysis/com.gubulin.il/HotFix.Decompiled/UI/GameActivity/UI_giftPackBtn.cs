using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_giftPackBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GImage note;

	public GImage n5;

	public const string URL = "ui://29q48tv6q9xef5r";

	public static string Name = "UI_giftPackBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6q9xef5r";
	}

	public static UI_giftPackBtn CreateInstance()
	{
		return (UI_giftPackBtn)(object)UIPackage.CreateObject("GameActivity", "giftPackBtn");
	}

	public static UI_giftPackBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_giftPackBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6q9xef5r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		note = (GImage)((GComponent)this).GetChild("note");
		n5 = (GImage)((GComponent)this).GetChild("n5");
	}
}
