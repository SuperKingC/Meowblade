using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_StoneCardFront : GComponent
{
	public Controller Type;

	public GLoader icon;

	public GImage cLevel;

	public GImage bLevel;

	public GTextField SoldierName;

	public GImage n11;

	public const string URL = "ui://avplaivdldght5u";

	public static string Name = "UI_StoneCardFront";

	public static string GetURL()
	{
		return "ui://avplaivdldght5u";
	}

	public static UI_StoneCardFront CreateInstance()
	{
		return (UI_StoneCardFront)(object)UIPackage.CreateObject("Contract", "StoneCardFront");
	}

	public static UI_StoneCardFront CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_StoneCardFront).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdldght5u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		cLevel = (GImage)((GComponent)this).GetChild("cLevel");
		bLevel = (GImage)((GComponent)this).GetChild("bLevel");
		SoldierName = (GTextField)((GComponent)this).GetChild("SoldierName");
		n11 = (GImage)((GComponent)this).GetChild("n11");
	}
}
