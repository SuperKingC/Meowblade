using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_probabilityBtn : GButton
{
	public Controller button;

	public GGraph n5;

	public GImage n3;

	public GTextField n4;

	public const string URL = "ui://29q48tv6q9xef61";

	public static string Name = "UI_probabilityBtn";

	public static string GetURL()
	{
		return "ui://29q48tv6q9xef61";
	}

	public static UI_probabilityBtn CreateInstance()
	{
		return (UI_probabilityBtn)(object)UIPackage.CreateObject("GameActivity", "probabilityBtn");
	}

	public static UI_probabilityBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_probabilityBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6q9xef61", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GGraph)((GComponent)this).GetChild("n5");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://29q48tv6q9xef61".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
	}
}
