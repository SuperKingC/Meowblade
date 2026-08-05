using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGPlayerCommand3;

public class UI_btn_ContributionPointAdd : GButton
{
	public Controller button;

	public Controller ConfigIndex;

	public GImage n3;

	public GTextField Multiple3;

	public GTextField Multiple2;

	public GTextField Multiple;

	public GTextField ContributionPointsAdd;

	public GImage n10;

	public GImage n7;

	public const string URL = "ui://vheg8vabeai3i";

	public static string Name = "UI_btn_ContributionPointAdd";

	public static string GetURL()
	{
		return "ui://vheg8vabeai3i";
	}

	public static UI_btn_ContributionPointAdd CreateInstance()
	{
		return (UI_btn_ContributionPointAdd)(object)UIPackage.CreateObject("GvGPlayerCommand3", "btn_ContributionPointAdd");
	}

	public static UI_btn_ContributionPointAdd CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ContributionPointAdd).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://vheg8vabeai3i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		ConfigIndex = ((GComponent)this).GetController("ConfigIndex");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		Multiple3 = (GTextField)((GComponent)this).GetChild("Multiple3");
		string id = "ui://vheg8vabeai3i".Replace("ui://", "") + "-" + ((GObject)Multiple3).id;
		((GObject)Multiple3).text = LanguagesManager.GetDesc(id);
		Multiple2 = (GTextField)((GComponent)this).GetChild("Multiple2");
		string id2 = "ui://vheg8vabeai3i".Replace("ui://", "") + "-" + ((GObject)Multiple2).id;
		((GObject)Multiple2).text = LanguagesManager.GetDesc(id2);
		Multiple = (GTextField)((GComponent)this).GetChild("Multiple");
		string id3 = "ui://vheg8vabeai3i".Replace("ui://", "") + "-" + ((GObject)Multiple).id;
		((GObject)Multiple).text = LanguagesManager.GetDesc(id3);
		ContributionPointsAdd = (GTextField)((GComponent)this).GetChild("ContributionPointsAdd");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n7 = (GImage)((GComponent)this).GetChild("n7");
	}
}
