using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_dec_02 : GComponent
{
	public GImage n66;

	public GImage n68;

	public GImage n67;

	public GImage n65;

	public GImage n69;

	public Transition t0;

	public Transition unlock;

	public const string URL = "ui://29q48tv6cp085f9k";

	public static string Name = "UI_dec_02";

	public static string GetURL()
	{
		return "ui://29q48tv6cp085f9k";
	}

	public static UI_dec_02 CreateInstance()
	{
		return (UI_dec_02)(object)UIPackage.CreateObject("GameActivity", "dec_02");
	}

	public static UI_dec_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_dec_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6cp085f9k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n66 = (GImage)((GComponent)this).GetChild("n66");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		n65 = (GImage)((GComponent)this).GetChild("n65");
		n69 = (GImage)((GComponent)this).GetChild("n69");
		t0 = ((GComponent)this).GetTransition("t0");
		unlock = ((GComponent)this).GetTransition("unlock");
	}
}
