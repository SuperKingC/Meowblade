using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_AttributeBack : GComponent
{
	public Controller ShowSwitchBtn;

	public GImage ContentBack;

	public GRichTextField primeAttribute;

	public GImage n10;

	public GTextField Title;

	public UI_EffectSwitchBtn SwitchBtn;

	public GMovieClip n12;

	public Transition ChangeText;

	public const string URL = "ui://b9wlonaqlofp11";

	public static string Name = "UI_AttributeBack";

	public static string GetURL()
	{
		return "ui://b9wlonaqlofp11";
	}

	public static UI_AttributeBack CreateInstance()
	{
		return (UI_AttributeBack)(object)UIPackage.CreateObject("LegendItemCultivation", "AttributeBack");
	}

	public static UI_AttributeBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AttributeBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqlofp11", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ShowSwitchBtn = ((GComponent)this).GetController("ShowSwitchBtn");
		ContentBack = (GImage)((GComponent)this).GetChild("ContentBack");
		primeAttribute = (GRichTextField)((GComponent)this).GetChild("primeAttribute");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://b9wlonaqlofp11".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		SwitchBtn = (UI_EffectSwitchBtn)(object)((GComponent)this).GetChild("SwitchBtn");
		n12 = (GMovieClip)((GComponent)this).GetChild("n12");
		ChangeText = ((GComponent)this).GetTransition("ChangeText");
	}
}
