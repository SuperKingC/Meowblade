using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_chipItem : GButton
{
	public Controller button;

	public GGraph advancedSfx;

	public UI_chip chip;

	public GGraph stateBackground;

	public GTextField stateText;

	public GGroup state;

	public GRichTextField total;

	public GRichTextField current;

	public GRichTextField limit;

	public GGroup texts;

	public GImage redNote;

	public GImage note;

	public GImage max;

	public const string URL = "ui://kt6rg65ovv0uec";

	public static string Name = "UI_chipItem";

	public static string GetURL()
	{
		return "ui://kt6rg65ovv0uec";
	}

	public static UI_chipItem CreateInstance()
	{
		return (UI_chipItem)(object)UIPackage.CreateObject("PublicResources", "chipItem");
	}

	public static UI_chipItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_chipItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ovv0uec", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		advancedSfx = (GGraph)((GComponent)this).GetChild("advancedSfx");
		chip = (UI_chip)(object)((GComponent)this).GetChild("chip");
		stateBackground = (GGraph)((GComponent)this).GetChild("stateBackground");
		stateText = (GTextField)((GComponent)this).GetChild("stateText");
		state = (GGroup)((GComponent)this).GetChild("state");
		total = (GRichTextField)((GComponent)this).GetChild("total");
		current = (GRichTextField)((GComponent)this).GetChild("current");
		limit = (GRichTextField)((GComponent)this).GetChild("limit");
		texts = (GGroup)((GComponent)this).GetChild("texts");
		redNote = (GImage)((GComponent)this).GetChild("redNote");
		note = (GImage)((GComponent)this).GetChild("note");
		max = (GImage)((GComponent)this).GetChild("max");
	}
}
