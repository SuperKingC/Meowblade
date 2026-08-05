using FairyGUI;
using FairyGUI.Utils;

namespace UI.ProgressionMission;

public class UI_TakeAll : GButton
{
	public Controller button;

	public GImage buyBtn;

	public GLoader n4;

	public const string URL = "ui://mapat4i5g8ttv4s6";

	public static string Name = "UI_TakeAll";

	public static string GetURL()
	{
		return "ui://mapat4i5g8ttv4s6";
	}

	public static UI_TakeAll CreateInstance()
	{
		return (UI_TakeAll)(object)UIPackage.CreateObject("ProgressionMission", "TakeAll");
	}

	public static UI_TakeAll CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_TakeAll).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://mapat4i5g8ttv4s6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		buyBtn = (GImage)((GComponent)this).GetChild("buyBtn");
		n4 = (GLoader)((GComponent)this).GetChild("n4");
	}
}
