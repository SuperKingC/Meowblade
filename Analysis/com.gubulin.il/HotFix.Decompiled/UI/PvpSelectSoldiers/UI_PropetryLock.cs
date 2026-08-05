using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PropetryLock : GButton
{
	public Controller button;

	public Controller Status;

	public GImage bg;

	public GImage n4;

	public GGraph n7;

	public GTextField n8;

	public GImage n9;

	public const string URL = "ui://82mo10n5fhbydd3";

	public static string Name = "UI_PropetryLock";

	public static string GetURL()
	{
		return "ui://82mo10n5fhbydd3";
	}

	public static UI_PropetryLock CreateInstance()
	{
		return (UI_PropetryLock)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PropetryLock");
	}

	public static UI_PropetryLock CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PropetryLock).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5fhbydd3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n7 = (GGraph)((GComponent)this).GetChild("n7");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id = "ui://82mo10n5fhbydd3".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id);
		n9 = (GImage)((GComponent)this).GetChild("n9");
	}
}
