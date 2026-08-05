using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_RepeatedAttack : GButton
{
	public Controller button;

	public Controller State;

	public GImage n4;

	public GImage n5;

	public GImage n3;

	public GImage n6;

	public const string URL = "ui://4eq8fgd2hx326scn";

	public static string Name = "UI_btn_RepeatedAttack";

	public static string GetURL()
	{
		return "ui://4eq8fgd2hx326scn";
	}

	public static UI_btn_RepeatedAttack CreateInstance()
	{
		return (UI_btn_RepeatedAttack)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_RepeatedAttack");
	}

	public static UI_btn_RepeatedAttack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_RepeatedAttack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2hx326scn", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
