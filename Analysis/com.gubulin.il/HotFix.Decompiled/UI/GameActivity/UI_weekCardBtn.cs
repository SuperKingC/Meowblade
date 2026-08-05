using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_weekCardBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n4;

	public GImage note;

	public const string URL = "ui://29q48tv6q9xe6f";

	public static string Name = "UI_weekCardBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6q9xe6f";
	}

	public static UI_weekCardBtn CreateInstance()
	{
		return (UI_weekCardBtn)(object)UIPackage.CreateObject("GameActivity", "weekCardBtn");
	}

	public static UI_weekCardBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_weekCardBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6q9xe6f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
