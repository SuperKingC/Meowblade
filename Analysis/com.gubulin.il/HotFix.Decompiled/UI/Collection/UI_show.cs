using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Collection;

public class UI_show : GButton
{
	public Controller button;

	public GGraph n7;

	public GImage bg;

	public GImage n5;

	public GTextField n6;

	public const string URL = "ui://ehe4tm5zwj3d4c";

	public static string Name = "UI_show";

	public static string GetURL()
	{
		return "ui://ehe4tm5zwj3d4c";
	}

	public static UI_show CreateInstance()
	{
		return (UI_show)(object)UIPackage.CreateObject("Collection", "show");
	}

	public static UI_show CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_show).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ehe4tm5zwj3d4c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n7 = (GGraph)((GComponent)this).GetChild("n7");
		bg = (GImage)((GComponent)this).GetChild("bg");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://ehe4tm5zwj3d4c".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
	}

	public void SetControllerPageText(int pageIndex)
	{
		string id = string.Format("{0}-{1}-{2}", "ui://ehe4tm5zwj3d4c".Replace("ui://", ""), ((GObject)n6).id, pageIndex);
		((GObject)n6).text = LanguagesManager.GetDesc(id);
	}
}
