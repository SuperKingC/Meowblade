using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_SoldierStock : GButton
{
	public Controller button;

	public GImage numNote;

	public GRichTextField Amount_t;

	public const string URL = "ui://k2sprg26in7b3e";

	public static string Name = "UI_SoldierStock";

	public static string GetURL()
	{
		return "ui://k2sprg26in7b3e";
	}

	public static UI_SoldierStock CreateInstance()
	{
		return (UI_SoldierStock)(object)UIPackage.CreateObject("IslandComeAgain", "SoldierStock");
	}

	public static UI_SoldierStock CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SoldierStock).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26in7b3e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		numNote = (GImage)((GComponent)this).GetChild("numNote");
		Amount_t = (GRichTextField)((GComponent)this).GetChild("Amount_t");
	}
}
