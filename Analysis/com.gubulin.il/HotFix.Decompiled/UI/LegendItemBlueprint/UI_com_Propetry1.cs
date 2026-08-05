using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_Propetry1 : GComponent
{
	public Controller Type;

	public Controller State;

	public GImage line;

	public GTextField Title;

	public GRichTextField content;

	public GRichTextField SubEntries;

	public const string URL = "ui://h09dvkcgh0te3u";

	public static string Name = "UI_com_Propetry1";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://h09dvkcgh0te3u".Replace("ui://", ""), ((GObject)Title).id, State.selectedIndex);
		((GObject)Title).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://h09dvkcgh0te3u";
	}

	public static UI_com_Propetry1 CreateInstance()
	{
		return (UI_com_Propetry1)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_Propetry1");
	}

	public static UI_com_Propetry1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Propetry1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgh0te3u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		State = ((GComponent)this).GetController("State");
		line = (GImage)((GComponent)this).GetChild("line");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://h09dvkcgh0te3u".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		content = (GRichTextField)((GComponent)this).GetChild("content");
		SubEntries = (GRichTextField)((GComponent)this).GetChild("SubEntries");
	}
}
