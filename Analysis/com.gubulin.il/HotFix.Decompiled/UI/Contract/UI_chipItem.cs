using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_chipItem : GButton
{
	public Controller button;

	public GGraph specialEffectsBack;

	public GLoader back;

	public GLoader icon;

	public GLoader frame;

	public GImage note;

	public Transition swing;

	public const string URL = "ui://avplaivdkn9kw";

	public static string Name = "UI_chipItem";

	public static string GetURL()
	{
		return "ui://avplaivdkn9kw";
	}

	public static UI_chipItem CreateInstance()
	{
		return (UI_chipItem)(object)UIPackage.CreateObject("Contract", "chipItem");
	}

	public static UI_chipItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_chipItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdkn9kw", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		specialEffectsBack = (GGraph)((GComponent)this).GetChild("specialEffectsBack");
		back = (GLoader)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		note = (GImage)((GComponent)this).GetChild("note");
		swing = ((GComponent)this).GetTransition("swing");
	}
}
