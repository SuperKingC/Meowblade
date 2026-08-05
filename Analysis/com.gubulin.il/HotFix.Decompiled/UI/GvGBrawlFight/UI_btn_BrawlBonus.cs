using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBrawlFight;

public class UI_btn_BrawlBonus : GButton
{
	public Controller SelfExecuting;

	public GLoader ItemIcon;

	public GTextField Num;

	public const string URL = "ui://hozu168rk7me4t";

	public static string Name = "UI_btn_BrawlBonus";

	public static string GetURL()
	{
		return "ui://hozu168rk7me4t";
	}

	public static UI_btn_BrawlBonus CreateInstance()
	{
		return (UI_btn_BrawlBonus)(object)UIPackage.CreateObject("GvGBrawlFight", "btn_BrawlBonus");
	}

	public static UI_btn_BrawlBonus CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_BrawlBonus).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168rk7me4t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SelfExecuting = ((GComponent)this).GetController("SelfExecuting");
		ItemIcon = (GLoader)((GComponent)this).GetChild("ItemIcon");
		Num = (GTextField)((GComponent)this).GetChild("Num");
	}
}
