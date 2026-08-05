using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_item : GButton
{
	public Controller button;

	public GGraph advancedSfx;

	public GLoader frame;

	public UI_frameMask frameMask;

	public GLoader back;

	public GLoader icon;

	public UI_equipMask iconMask;

	public GTextField tip;

	public UI_MateriaNuml MateriaNuml;

	public const string URL = "ui://kt6rg65ot1tzf9";

	public static string Name = "UI_item";

	public static string GetURL()
	{
		return "ui://kt6rg65ot1tzf9";
	}

	public static UI_item CreateInstance()
	{
		return (UI_item)(object)UIPackage.CreateObject("PublicResources", "item");
	}

	public static UI_item CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_item).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65ot1tzf9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		advancedSfx = (GGraph)((GComponent)this).GetChild("advancedSfx");
		frame = (GLoader)((GComponent)this).GetChild("frame");
		frameMask = (UI_frameMask)(object)((GComponent)this).GetChild("frameMask");
		back = (GLoader)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		iconMask = (UI_equipMask)(object)((GComponent)this).GetChild("iconMask");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id = "ui://kt6rg65ot1tzf9".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id);
		MateriaNuml = (UI_MateriaNuml)(object)((GComponent)this).GetChild("MateriaNuml");
	}
}
