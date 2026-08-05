using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecord3;

public class UI_com_RightProfileDisplay : GComponent
{
	public Controller IsMe;

	public GComponent Avatar;

	public GTextField ShipName;

	public GList Medals;

	public UI_com_Component3 n3;

	public GTextField PlayerName;

	public const string URL = "ui://b3fc6085h4u0fu";

	public static string Name = "UI_com_RightProfileDisplay";

	public static string GetURL()
	{
		return "ui://b3fc6085h4u0fu";
	}

	public static UI_com_RightProfileDisplay CreateInstance()
	{
		return (UI_com_RightProfileDisplay)(object)UIPackage.CreateObject("GvGBattleRecord3", "com_RightProfileDisplay");
	}

	public static UI_com_RightProfileDisplay CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_RightProfileDisplay).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b3fc6085h4u0fu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		IsMe = ((GComponent)this).GetController("IsMe");
		Avatar = (GComponent)((GComponent)this).GetChild("Avatar");
		ShipName = (GTextField)((GComponent)this).GetChild("ShipName");
		Medals = (GList)((GComponent)this).GetChild("Medals");
		n3 = (UI_com_Component3)(object)((GComponent)this).GetChild("n3");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
	}
}
