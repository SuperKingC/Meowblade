using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemInfo;

public class UI_Propetry : GButton
{
	public Controller button;

	public Controller Type;

	public GGraph line;

	public GTextField Title;

	public GRichTextField content;

	public const string URL = "ui://lzvt5p2vi09ec";

	public static string Name = "UI_Propetry";

	public static string GetURL()
	{
		return "ui://lzvt5p2vi09ec";
	}

	public static UI_Propetry CreateInstance()
	{
		return (UI_Propetry)(object)UIPackage.CreateObject("LegendItemInfo", "Propetry");
	}

	public static UI_Propetry CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Propetry).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lzvt5p2vi09ec", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		line = (GGraph)((GComponent)this).GetChild("line");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://lzvt5p2vi09ec".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		content = (GRichTextField)((GComponent)this).GetChild("content");
	}
}
