using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_Ability : GComponent
{
	public Controller BufforDebuff;

	public GLoader icon;

	public GImage n3;

	public GImage n4;

	public GTextField Title;

	public GTextField Lv;

	public const string URL = "ui://b3fc6085stwv1c";

	public static string Name = "UI_com_Ability";

	public static string GetURL()
	{
		return "ui://b3fc6085stwv1c";
	}

	public static UI_com_Ability CreateInstance()
	{
		return (UI_com_Ability)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_Ability");
	}

	public static UI_com_Ability CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Ability).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085stwv1c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		BufforDebuff = ((GComponent)this).GetController("BufforDebuff");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		Lv = (GTextField)((GComponent)this).GetChild("Lv");
	}
}
