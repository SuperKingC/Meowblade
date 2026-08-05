using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_StartBattleConfirm : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n4;

	public const string URL = "ui://twlbabicrl4qm2";

	public static string Name = "UI_StartBattleConfirm";

	public static string GetURL()
	{
		return "ui://twlbabicrl4qm2";
	}

	public static UI_StartBattleConfirm CreateInstance()
	{
		return (UI_StartBattleConfirm)(object)UIPackage.CreateObject("Battle", "StartBattleConfirm");
	}

	public static UI_StartBattleConfirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StartBattleConfirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicrl4qm2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
