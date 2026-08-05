using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Plot;

public class UI_clickarea : GButton
{
	public Controller button;

	public GLoader background;

	public GRichTextField dialogue;

	public GRichTextField title;

	public const string URL = "ui://56axd6he8h2b0";

	public static string Name = "UI_clickarea";

	public static string GetURL()
	{
		return "ui://56axd6he8h2b0";
	}

	public static UI_clickarea CreateInstance()
	{
		return (UI_clickarea)(object)UIPackage.CreateObject("Plot", "clickarea");
	}

	public static UI_clickarea CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_clickarea).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://56axd6he8h2b0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		background = (GLoader)((GComponent)this).GetChild("background");
		dialogue = (GRichTextField)((GComponent)this).GetChild("dialogue");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://56axd6he8h2b0".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
