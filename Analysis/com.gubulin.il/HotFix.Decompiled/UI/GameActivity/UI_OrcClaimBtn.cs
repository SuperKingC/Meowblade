using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_OrcClaimBtn : GButton
{
	public Controller button;

	public Controller State;

	public GImage icon;

	public GImage n5;

	public GImage n6;

	public const string URL = "ui://29q48tv6mbra4i";

	public static string Name = "UI_OrcClaimBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6mbra4i";
	}

	public static UI_OrcClaimBtn CreateInstance()
	{
		return (UI_OrcClaimBtn)(object)UIPackage.CreateObject("GameActivity", "OrcClaimBtn");
	}

	public static UI_OrcClaimBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_OrcClaimBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6mbra4i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		icon = (GImage)((GComponent)this).GetChild("icon");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
