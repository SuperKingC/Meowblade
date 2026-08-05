using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_ForumEntryBtn : GButton
{
	public GGraph SpineBack;

	public const string URL = "ui://j611zmymstpuv43p";

	public static string Name = "UI_ForumEntryBtn";

	public static string GetURL()
	{
		return "ui://j611zmymstpuv43p";
	}

	public static UI_ForumEntryBtn CreateInstance()
	{
		return (UI_ForumEntryBtn)(object)UIPackage.CreateObject("MainCity", "ForumEntryBtn");
	}

	public static UI_ForumEntryBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ForumEntryBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmymstpuv43p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		SpineBack = (GGraph)((GComponent)this).GetChild("SpineBack");
	}
}
