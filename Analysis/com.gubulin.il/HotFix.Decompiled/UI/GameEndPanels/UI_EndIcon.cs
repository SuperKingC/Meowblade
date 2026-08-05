using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameEndPanels;

public class UI_EndIcon : GComponent
{
	public Controller type;

	public GGraph VictorySfx;

	public GLoader Icon;

	public GGraph chooseText;

	public GRichTextField ChooseText;

	public Transition minify;

	public Transition maximize;

	public const string URL = "ui://hda5vzklay0l4z";

	public static string Name = "UI_EndIcon";

	public static string GetURL()
	{
		return "ui://hda5vzklay0l4z";
	}

	public static UI_EndIcon CreateInstance()
	{
		return (UI_EndIcon)(object)UIPackage.CreateObject("GameEndPanels", "EndIcon");
	}

	public static UI_EndIcon CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EndIcon).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hda5vzklay0l4z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		type = ((GComponent)this).GetController("type");
		VictorySfx = (GGraph)((GComponent)this).GetChild("VictorySfx");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		chooseText = (GGraph)((GComponent)this).GetChild("chooseText");
		ChooseText = (GRichTextField)((GComponent)this).GetChild("ChooseText");
		minify = ((GComponent)this).GetTransition("minify");
		maximize = ((GComponent)this).GetTransition("maximize");
	}
}
