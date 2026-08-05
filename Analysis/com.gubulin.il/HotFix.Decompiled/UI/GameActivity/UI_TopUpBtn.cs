using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_TopUpBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n4;

	public GGraph effPos;

	public const string URL = "ui://29q48tv6ftzvby";

	public static string Name = "UI_TopUpBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6ftzvby";
	}

	public static UI_TopUpBtn CreateInstance()
	{
		return (UI_TopUpBtn)(object)UIPackage.CreateObject("GameActivity", "TopUpBtn");
	}

	public static UI_TopUpBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TopUpBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6ftzvby", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		effPos = (GGraph)((GComponent)this).GetChild("effPos");
	}
}
