using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_drawBtn1 : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField drawTitle;

	public const string URL = "ui://29q48tv6q9xef5f";

	public static string Name = "UI_drawBtn1";

	public static string GetURL()
	{
		return "ui://29q48tv6q9xef5f";
	}

	public static UI_drawBtn1 CreateInstance()
	{
		return (UI_drawBtn1)(object)UIPackage.CreateObject("GameActivity", "drawBtn1");
	}

	public static UI_drawBtn1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_drawBtn1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6q9xef5f", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://29q48tv6q9xef5f".Replace("ui://", "") + "-" + ((GObject)drawTitle).id;
		((GObject)drawTitle).text = LanguagesManager.GetDesc(id);
	}
}
