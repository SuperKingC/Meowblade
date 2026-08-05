using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_GainBtn : GButton
{
	public Controller button;

	public Controller PageController;

	public GGraph back;

	public GGraph n3;

	public GTextField title;

	public const string URL = "ui://b9yxt7u0f4szu";

	public static string Name = "UI_GainBtn";

	public static string GetURL()
	{
		return "ui://b9yxt7u0f4szu";
	}

	public static UI_GainBtn CreateInstance()
	{
		return (UI_GainBtn)(object)UIPackage.CreateObject("AccountInfo", "GainBtn");
	}

	public static UI_GainBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GainBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0f4szu", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		PageController = ((GComponent)this).GetController("PageController");
		back = (GGraph)((GComponent)this).GetChild("back");
		n3 = (GGraph)((GComponent)this).GetChild("n3");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://b9yxt7u0f4szu".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
