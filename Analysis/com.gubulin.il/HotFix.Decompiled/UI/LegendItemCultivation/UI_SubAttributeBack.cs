using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_SubAttributeBack : GComponent
{
	public Controller Type;

	public Controller ShowSwitchBtn;

	public GImage ContentBack;

	public GRichTextField primeAttribute;

	public GImage n10;

	public GTextField Title;

	public UI_EffectSwitchBtn SwitchBtn;

	public const string URL = "ui://b9wlonaqlofp12";

	public static string Name = "UI_SubAttributeBack";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://b9wlonaqlofp12".Replace("ui://", ""), ((GObject)Title).id, Type.selectedIndex);
		((GObject)Title).text = LanguagesManager.GetDesc(id);
	}

	public static string GetURL()
	{
		return "ui://b9wlonaqlofp12";
	}

	public static UI_SubAttributeBack CreateInstance()
	{
		return (UI_SubAttributeBack)(object)UIPackage.CreateObject("LegendItemCultivation", "SubAttributeBack");
	}

	public static UI_SubAttributeBack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SubAttributeBack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqlofp12", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		ShowSwitchBtn = ((GComponent)this).GetController("ShowSwitchBtn");
		ContentBack = (GImage)((GComponent)this).GetChild("ContentBack");
		primeAttribute = (GRichTextField)((GComponent)this).GetChild("primeAttribute");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://b9wlonaqlofp12".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		SwitchBtn = (UI_EffectSwitchBtn)(object)((GComponent)this).GetChild("SwitchBtn");
	}

	public string GetControllerText(int index)
	{
		string id = string.Format("{0}-{1}-texts_{2}", "ui://b9wlonaqlofp12".Replace("ui://", ""), ((GObject)Title).id, index);
		return LanguagesManager.GetDesc(id);
	}
}
