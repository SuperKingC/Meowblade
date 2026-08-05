using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivity;

public class UI_tab_01 : GButton
{
	public Controller c1;

	public Controller button;

	public GImage n16;

	public GImage n18;

	public GLoader n17;

	public const string URL = "ui://r1j1a2l0nbmf38";

	public static string Name = "UI_tab_01";

	public static string GetURL()
	{
		return "ui://r1j1a2l0nbmf38";
	}

	public static UI_tab_01 CreateInstance()
	{
		return (UI_tab_01)(object)UIPackage.CreateObject("QQGameActivity", "tab_01");
	}

	public static UI_tab_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_tab_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r1j1a2l0nbmf38", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		c1 = ((GComponent)this).GetController("c1");
		button = ((GComponent)this).GetController("button");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n17 = (GLoader)((GComponent)this).GetChild("n17");
	}
}
