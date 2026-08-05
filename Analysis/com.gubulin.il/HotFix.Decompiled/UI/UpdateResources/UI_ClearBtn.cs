using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UpdateResources;

public class UI_ClearBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GRichTextField title;

	public const string URL = "ui://sui7dihff4szc";

	public static string Name = "UI_ClearBtn";

	public static string GetURL()
	{
		return "ui://sui7dihff4szc";
	}

	public static UI_ClearBtn CreateInstance()
	{
		return (UI_ClearBtn)(object)UIPackage.CreateObject("UpdateResources", "ClearBtn");
	}

	public static UI_ClearBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ClearBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://sui7dihff4szc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://sui7dihff4szc".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
