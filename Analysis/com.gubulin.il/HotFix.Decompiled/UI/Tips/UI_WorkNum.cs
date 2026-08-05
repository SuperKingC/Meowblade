using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_WorkNum : GButton
{
	public Controller button;

	public GImage n5;

	public GTextField title;

	public const string URL = "ui://47lbpgx9yzxz3m";

	public static string Name = "UI_WorkNum";

	public static string GetURL()
	{
		return "ui://47lbpgx9yzxz3m";
	}

	public static UI_WorkNum CreateInstance()
	{
		return (UI_WorkNum)(object)UIPackage.CreateObject("Tips", "WorkNum");
	}

	public static UI_WorkNum CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WorkNum).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9yzxz3m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n5 = (GImage)((GComponent)this).GetChild("n5");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://47lbpgx9yzxz3m".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
