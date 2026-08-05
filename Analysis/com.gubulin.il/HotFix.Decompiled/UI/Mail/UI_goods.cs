using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_goods : GButton
{
	public Controller button;

	public GImage Bg;

	public GLoader icon;

	public GRichTextField title;

	public Transition t0;

	public const string URL = "ui://edr57v33oipip";

	public static string Name = "UI_goods";

	public static string GetURL()
	{
		return "ui://edr57v33oipip";
	}

	public static UI_goods CreateInstance()
	{
		return (UI_goods)(object)UIPackage.CreateObject("Mail", "goods");
	}

	public static UI_goods CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_goods).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33oipip", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Bg = (GImage)((GComponent)this).GetChild("Bg");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://edr57v33oipip".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
