using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_GoTo : GButton
{
	public Controller button;

	public Controller usable;

	public GImage n3;

	public GImage n4;

	public const string URL = "ui://k19peou7qx5ip7f";

	public static string Name = "UI_btn_GoTo";

	public static string GetURL()
	{
		return "ui://k19peou7qx5ip7f";
	}

	public static UI_btn_GoTo CreateInstance()
	{
		return (UI_btn_GoTo)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_GoTo");
	}

	public static UI_btn_GoTo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_GoTo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7qx5ip7f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		usable = ((GComponent)this).GetController("usable");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
	}
}
