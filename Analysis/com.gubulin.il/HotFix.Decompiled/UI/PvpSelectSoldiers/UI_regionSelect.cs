using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_regionSelect : GComponent
{
	public Controller Status;

	public GGraph n69;

	public GImage n67;

	public GImage n68;

	public GImage n58;

	public GImage n66;

	public GImage n50;

	public GGraph SfxBack;

	public UI_RegionContent Content;

	public const string URL = "ui://82mo10n5jjlwdb6";

	public static string Name = "UI_regionSelect";

	public static string GetURL()
	{
		return "ui://82mo10n5jjlwdb6";
	}

	public static UI_regionSelect CreateInstance()
	{
		return (UI_regionSelect)(object)UIPackage.CreateObject("PvpSelectSoldiers", "regionSelect");
	}

	public static UI_regionSelect CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_regionSelect).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5jjlwdb6", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		n69 = (GGraph)((GComponent)this).GetChild("n69");
		n67 = (GImage)((GComponent)this).GetChild("n67");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		n58 = (GImage)((GComponent)this).GetChild("n58");
		n66 = (GImage)((GComponent)this).GetChild("n66");
		n50 = (GImage)((GComponent)this).GetChild("n50");
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		Content = (UI_RegionContent)(object)((GComponent)this).GetChild("Content");
	}
}
