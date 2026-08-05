using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemInfo;

public class UI_com_Propetry : GComponent
{
	public Controller Type;

	public Controller State;

	public GImage line;

	public GTextField Title;

	public GRichTextField content;

	public const string URL = "ui://lzvt5p2vwx6nf";

	public static string Name = "UI_com_Propetry";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://lzvt5p2vwx6nf".Replace("ui://", ""), ((GObject)Title).id, State.selectedIndex);
		((GObject)Title).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://lzvt5p2vwx6nf";
	}

	public static UI_com_Propetry CreateInstance()
	{
		return (UI_com_Propetry)(object)UIPackage.CreateObject("LegendItemInfo", "com_Propetry");
	}

	public static UI_com_Propetry CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Propetry).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lzvt5p2vwx6nf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		State = ((GComponent)this).GetController("State");
		line = (GImage)((GComponent)this).GetChild("line");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://lzvt5p2vwx6nf".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		content = (GRichTextField)((GComponent)this).GetChild("content");
	}

	public void GetControllerText(int index)
	{
		string id = string.Format("{0}-{1}-texts_{2}", "ui://lzvt5p2vwx6nf".Replace("ui://", ""), ((GObject)Title).id, index);
		((GObject)Title).text = LanguagesManager.GetDesc(id);
	}
}
