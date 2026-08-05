using FairyGUI;
using FairyGUI.Utils;

namespace UI.UnlockSoldierShow;

public class UI_dec_02 : GComponent
{
	public GImage n83;

	public GImage n85;

	public GImage n86;

	public GImage n84;

	public Transition t0;

	public const string URL = "ui://ia1am3ehi7qut34";

	public static string Name = "UI_dec_02";

	public static string GetURL()
	{
		return "ui://ia1am3ehi7qut34";
	}

	public static UI_dec_02 CreateInstance()
	{
		return (UI_dec_02)(object)UIPackage.CreateObject("UnlockSoldierShow", "dec_02");
	}

	public static UI_dec_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ia1am3ehi7qut34", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n83 = (GImage)((GComponent)this).GetChild("n83");
		n85 = (GImage)((GComponent)this).GetChild("n85");
		n86 = (GImage)((GComponent)this).GetChild("n86");
		n84 = (GImage)((GComponent)this).GetChild("n84");
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
