using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_btn_arrow : GButton
{
	public Controller button;

	public GImage n86;

	public GImage n87;

	public const string URL = "ui://ebc4ciwrvmepq43";

	public static string Name = "UI_btn_arrow";

	public static string GetURL()
	{
		return "ui://ebc4ciwrvmepq43";
	}

	public static UI_btn_arrow CreateInstance()
	{
		return (UI_btn_arrow)(object)UIPackage.CreateObject("GvGOnIsland3", "btn_arrow");
	}

	public static UI_btn_arrow CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_arrow).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrvmepq43", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n86 = (GImage)((GComponent)this).GetChild("n86");
		n87 = (GImage)((GComponent)this).GetChild("n87");
	}
}
