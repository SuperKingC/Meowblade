using FairyGUI;
using FairyGUI.Utils;

namespace UI.ProgressionMission;

public class UI_NewRewards : GComponent
{
	public Controller button;

	public GImage n115;

	public GImage upArrow;

	public GImage n116;

	public Transition t0;

	public const string URL = "ui://mapat4i5n8gwv4rn";

	public static string Name = "UI_NewRewards";

	public static string GetURL()
	{
		return "ui://mapat4i5n8gwv4rn";
	}

	public static UI_NewRewards CreateInstance()
	{
		return (UI_NewRewards)(object)UIPackage.CreateObject("ProgressionMission", "NewRewards");
	}

	public static UI_NewRewards CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_NewRewards).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5n8gwv4rn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		button = ((GComponent)this).GetController("button");
		n115 = (GImage)((GComponent)this).GetChild("n115");
		upArrow = (GImage)((GComponent)this).GetChild("upArrow");
		n116 = (GImage)((GComponent)this).GetChild("n116");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
