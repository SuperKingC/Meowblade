using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivityPass;

public class UI_btn_ClaimableSlot : GButton
{
	public Controller button;

	public GLoader Icon;

	public GTextField num;

	public const string URL = "ui://11dkggb8nk8fg";

	public static string Name = "UI_btn_ClaimableSlot";

	public static string GetURL()
	{
		return "ui://11dkggb8nk8fg";
	}

	public static UI_btn_ClaimableSlot CreateInstance()
	{
		return (UI_btn_ClaimableSlot)(object)UIPackage.CreateObject("WeekActivityPass", "btn_ClaimableSlot");
	}

	public static UI_btn_ClaimableSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ClaimableSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://11dkggb8nk8fg", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		num = (GTextField)((GComponent)this).GetChild("num");
	}
}
