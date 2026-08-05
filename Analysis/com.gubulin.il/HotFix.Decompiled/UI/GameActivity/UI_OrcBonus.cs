using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_OrcBonus : GButton
{
	public Controller button;

	public GImage iconBack;

	public GLoader icon;

	public GTextField num;

	public const string URL = "ui://29q48tv6u85j5a";

	public static string Name = "UI_OrcBonus";

	public static string GetURL()
	{
		return "ui://29q48tv6u85j5a";
	}

	public static UI_OrcBonus CreateInstance()
	{
		return (UI_OrcBonus)(object)UIPackage.CreateObject("GameActivity", "OrcBonus");
	}

	public static UI_OrcBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OrcBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6u85j5a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
	}
}
