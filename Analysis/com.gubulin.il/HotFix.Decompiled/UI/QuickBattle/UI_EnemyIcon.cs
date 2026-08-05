using FairyGUI;
using FairyGUI.Utils;

namespace UI.QuickBattle;

public class UI_EnemyIcon : GButton
{
	public Controller button;

	public GImage back;

	public GLoader healthBar;

	public UI_HeadPortrait IconBtn;

	public const string URL = "ui://kqd1t06of2581i";

	public static string Name = "UI_EnemyIcon";

	public static string GetURL()
	{
		return "ui://kqd1t06of2581i";
	}

	public static UI_EnemyIcon CreateInstance()
	{
		return (UI_EnemyIcon)(object)UIPackage.CreateObject("QuickBattle", "EnemyIcon");
	}

	public static UI_EnemyIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnemyIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kqd1t06of2581i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		back = (GImage)((GComponent)this).GetChild("back");
		healthBar = (GLoader)((GComponent)this).GetChild("healthBar");
		IconBtn = (UI_HeadPortrait)(object)((GComponent)this).GetChild("IconBtn");
	}
}
