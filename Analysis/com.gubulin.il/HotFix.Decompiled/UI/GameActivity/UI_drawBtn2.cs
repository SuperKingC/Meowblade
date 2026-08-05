using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_drawBtn2 : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField drawTitle;

	public const string URL = "ui://29q48tv6q9xef5h";

	public static string Name = "UI_drawBtn2";

	public static string GetURL()
	{
		return "ui://29q48tv6q9xef5h";
	}

	public static UI_drawBtn2 CreateInstance()
	{
		return (UI_drawBtn2)(object)UIPackage.CreateObject("GameActivity", "drawBtn2");
	}

	public static UI_drawBtn2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_drawBtn2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6q9xef5h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		drawTitle = (GTextField)((GComponent)this).GetChild("drawTitle");
		string id = "ui://29q48tv6q9xef5h".Replace("ui://", "") + "-" + ((GObject)drawTitle).id;
		((GObject)drawTitle).text = LanguagesManager.GetDesc(id);
	}
}
