using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_IslandFilter : GButton
{
	public Controller State;

	public GImage n4;

	public GImage n3;

	public GTextField FilterName;

	public GList Icons;

	public GImage n8;

	public GImage n9;

	public const string URL = "ui://4eq8fgd2kivrsbo";

	public static string Name = "UI_btn_IslandFilter";

	public static string GetURL()
	{
		return "ui://4eq8fgd2kivrsbo";
	}

	public static UI_btn_IslandFilter CreateInstance()
	{
		return (UI_btn_IslandFilter)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_IslandFilter");
	}

	public static UI_btn_IslandFilter CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_IslandFilter).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2kivrsbo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		FilterName = (GTextField)((GComponent)this).GetChild("FilterName");
		Icons = (GList)((GComponent)this).GetChild("Icons");
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
	}
}
