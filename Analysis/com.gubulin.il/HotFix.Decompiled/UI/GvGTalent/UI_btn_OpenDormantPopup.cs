using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGTalent;

public class UI_btn_OpenDormantPopup : GButton
{
	public Controller button;

	public GImage n0;

	public GImage n1;

	public GImage n2;

	public const string URL = "ui://4r1llhd8pdsr64";

	public static string Name = "UI_btn_OpenDormantPopup";

	public static string GetURL()
	{
		return "ui://4r1llhd8pdsr64";
	}

	public static UI_btn_OpenDormantPopup CreateInstance()
	{
		return (UI_btn_OpenDormantPopup)(object)UIPackage.CreateObject("GvGTalent", "btn_OpenDormantPopup");
	}

	public static UI_btn_OpenDormantPopup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_OpenDormantPopup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4r1llhd8pdsr64", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		n2 = (GImage)((GComponent)this).GetChild("n2");
	}
}
