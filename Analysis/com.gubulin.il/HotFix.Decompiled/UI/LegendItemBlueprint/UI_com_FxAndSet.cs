using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_FxAndSet : GComponent
{
	public GTextField Title0;

	public GRichTextField FxText;

	public GTextField Title1;

	public GRichTextField SetText;

	public const string URL = "ui://h09dvkcgtviv4d";

	public static string Name = "UI_com_FxAndSet";

	public static string GetURL()
	{
		return "ui://h09dvkcgtviv4d";
	}

	public static UI_com_FxAndSet CreateInstance()
	{
		return (UI_com_FxAndSet)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_FxAndSet");
	}

	public static UI_com_FxAndSet CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FxAndSet).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgtviv4d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Title0 = (GTextField)((GComponent)this).GetChild("Title0");
		string id = "ui://h09dvkcgtviv4d".Replace("ui://", "") + "-" + ((GObject)Title0).id;
		((GObject)Title0).text = LanguagesManager.GetDesc(id);
		FxText = (GRichTextField)((GComponent)this).GetChild("FxText");
		Title1 = (GTextField)((GComponent)this).GetChild("Title1");
		string id2 = "ui://h09dvkcgtviv4d".Replace("ui://", "") + "-" + ((GObject)Title1).id;
		((GObject)Title1).text = LanguagesManager.GetDesc(id2);
		SetText = (GRichTextField)((GComponent)this).GetChild("SetText");
	}
}
