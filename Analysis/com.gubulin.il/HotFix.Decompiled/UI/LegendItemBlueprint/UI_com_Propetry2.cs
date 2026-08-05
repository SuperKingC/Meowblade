using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_Propetry2 : GComponent
{
	public Controller Type;

	public GTextField Title;

	public GRichTextField content;

	public GList NewEntry;

	public GList OldEntry;

	public UI_com_FxAndSet OriginalFx;

	public GImage line;

	public GList AllFx;

	public const string URL = "ui://h09dvkcgqz9p3v";

	public static string Name = "UI_com_Propetry2";

	public static string GetURL()
	{
		return "ui://h09dvkcgqz9p3v";
	}

	public static UI_com_Propetry2 CreateInstance()
	{
		return (UI_com_Propetry2)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_Propetry2");
	}

	public static UI_com_Propetry2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Propetry2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgqz9p3v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://h09dvkcgqz9p3v".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		content = (GRichTextField)((GComponent)this).GetChild("content");
		NewEntry = (GList)((GComponent)this).GetChild("NewEntry");
		OldEntry = (GList)((GComponent)this).GetChild("OldEntry");
		OriginalFx = (UI_com_FxAndSet)(object)((GComponent)this).GetChild("OriginalFx");
		line = (GImage)((GComponent)this).GetChild("line");
		AllFx = (GList)((GComponent)this).GetChild("AllFx");
	}
}
