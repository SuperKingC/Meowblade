using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_equipItem : GButton
{
	public Controller button;

	public GGraph n19;

	public GLoader FloorLoader;

	public GLoader FrameLoader;

	public GLoader IconLoader;

	public GImage Select;

	public GTextField title;

	public GTextField tip;

	public GLoader SkillIconLoader;

	public GImage frameImage;

	public GGroup SkillGroup;

	public Transition showSelf;

	public Transition rising;

	public const string URL = "ui://kt6rg65oscgugh";

	public static string Name = "UI_equipItem";

	public static string GetURL()
	{
		return "ui://kt6rg65oscgugh";
	}

	public static UI_equipItem CreateInstance()
	{
		return (UI_equipItem)(object)UIPackage.CreateObject("PublicResources", "equipItem");
	}

	public static UI_equipItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_equipItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oscgugh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n19 = (GGraph)((GComponent)this).GetChild("n19");
		FloorLoader = (GLoader)((GComponent)this).GetChild("FloorLoader");
		FrameLoader = (GLoader)((GComponent)this).GetChild("FrameLoader");
		IconLoader = (GLoader)((GComponent)this).GetChild("IconLoader");
		Select = (GImage)((GComponent)this).GetChild("Select");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://kt6rg65oscgugh".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://kt6rg65oscgugh".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		SkillIconLoader = (GLoader)((GComponent)this).GetChild("SkillIconLoader");
		frameImage = (GImage)((GComponent)this).GetChild("frameImage");
		SkillGroup = (GGroup)((GComponent)this).GetChild("SkillGroup");
		showSelf = ((GComponent)this).GetTransition("showSelf");
		rising = ((GComponent)this).GetTransition("rising");
	}
}
