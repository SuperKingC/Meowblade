using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_btn_BattleResultBonus : GButton
{
	public Controller IsClaimed;

	public GLoader Icon;

	public GImage n101;

	public GTextField Count;

	public const string URL = "ui://b3fc6085dzdc3c";

	public static string Name = "UI_btn_BattleResultBonus";

	public static string GetURL()
	{
		return "ui://b3fc6085dzdc3c";
	}

	public static UI_btn_BattleResultBonus CreateInstance()
	{
		return (UI_btn_BattleResultBonus)(object)UIPackage.CreateObject("GvGBattleRecord3", "btn_BattleResultBonus");
	}

	public static UI_btn_BattleResultBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BattleResultBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085dzdc3c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		IsClaimed = ((GComponent)this).GetController("IsClaimed");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		n101 = (GImage)((GComponent)this).GetChild("n101");
		Count = (GTextField)((GComponent)this).GetChild("Count");
	}
}
