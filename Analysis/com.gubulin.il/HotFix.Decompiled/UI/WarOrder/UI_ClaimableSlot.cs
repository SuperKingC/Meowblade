using FairyGUI;
using FairyGUI.Utils;

namespace UI.WarOrder;

public class UI_ClaimableSlot : GButton
{
	public Controller button;

	public GLoader frame;

	public GLoader back;

	public GLoader icon;

	public GTextField num;

	public const string URL = "ui://ax280w58okbc1w";

	public static string Name = "UI_ClaimableSlot";

	public static string GetURL()
	{
		return "ui://ax280w58okbc1w";
	}

	public static UI_ClaimableSlot CreateInstance()
	{
		return (UI_ClaimableSlot)(object)UIPackage.CreateObject("WarOrder", "ClaimableSlot");
	}

	public static UI_ClaimableSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ClaimableSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ax280w58okbc1w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		back = (GLoader)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
	}
}
