using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Playback;

public class UI_PageBtnFoo : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n4;

	public UI_CutTab n3;

	public GTextField n6;

	public const string URL = "ui://9u6qpm6phqom1d";

	public static string Name = "UI_PageBtnFoo";

	public static string GetURL()
	{
		return "ui://9u6qpm6phqom1d";
	}

	public static UI_PageBtnFoo CreateInstance()
	{
		return (UI_PageBtnFoo)(object)UIPackage.CreateObject("Playback", "PageBtnFoo");
	}

	public static UI_PageBtnFoo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PageBtnFoo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://9u6qpm6phqom1d", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n3 = (UI_CutTab)(object)((GComponent)this).GetChild("n3");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://9u6qpm6phqom1d".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
	}
}
