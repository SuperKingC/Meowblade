using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_tipYes : GButton
{
	public Controller button;

	public GImage mark;

	public GTextField title;

	public const string URL = "ui://yb3s7uv7ryu88";

	public static string Name = "UI_tipYes";

	public static string GetURL()
	{
		return "ui://yb3s7uv7ryu88";
	}

	public static UI_tipYes CreateInstance()
	{
		return (UI_tipYes)(object)UIPackage.CreateObject("LoginAndName", "tipYes");
	}

	public static UI_tipYes CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_tipYes).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7ryu88", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		mark = (GImage)((GComponent)this).GetChild("mark");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://yb3s7uv7ryu88".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
