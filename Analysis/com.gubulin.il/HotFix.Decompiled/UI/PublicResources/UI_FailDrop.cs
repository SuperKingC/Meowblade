using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_FailDrop : GButton
{
	public Controller button;

	public GImage Bg;

	public GLoader icon;

	public GRichTextField title;

	public const string URL = "ui://kt6rg65oodqn2l";

	public static string Name = "UI_FailDrop";

	public static string GetURL()
	{
		return "ui://kt6rg65oodqn2l";
	}

	public static UI_FailDrop CreateInstance()
	{
		return (UI_FailDrop)(object)UIPackage.CreateObject("PublicResources", "FailDrop");
	}

	public static UI_FailDrop CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_FailDrop).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oodqn2l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://kt6rg65oodqn2l".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
