using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_BattleRecord : GButton
{
	public Controller button;

	public GImage n3;

	public const string URL = "ui://k2sprg26uctj81";

	public static string Name = "UI_BattleRecord";

	public static string GetURL()
	{
		return "ui://k2sprg26uctj81";
	}

	public static UI_BattleRecord CreateInstance()
	{
		return (UI_BattleRecord)(object)UIPackage.CreateObject("IslandComeAgain", "BattleRecord");
	}

	public static UI_BattleRecord CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BattleRecord).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26uctj81", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
	}
}
