using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemCultivation;

public class UI_AttributeReplace : GComponent
{
	public Controller TypeController;

	public Controller AttributeContent;

	public GImage ContentBack;

	public GRichTextField primeAttribute;

	public GRichTextField questionMark;

	public GImage n10;

	public GTextField Title;

	public GMovieClip n13;

	public Transition ChangeText;

	public const string URL = "ui://b9wlonaqknp3hc";

	public static string Name = "UI_AttributeReplace";

	public static string GetURL()
	{
		return "ui://b9wlonaqknp3hc";
	}

	public static UI_AttributeReplace CreateInstance()
	{
		return (UI_AttributeReplace)(object)UIPackage.CreateObject("LegendItemCultivation", "AttributeReplace");
	}

	public static UI_AttributeReplace CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AttributeReplace).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9wlonaqknp3hc", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		TypeController = ((GComponent)this).GetController("TypeController");
		AttributeContent = ((GComponent)this).GetController("AttributeContent");
		ContentBack = (GImage)((GComponent)this).GetChild("ContentBack");
		primeAttribute = (GRichTextField)((GComponent)this).GetChild("primeAttribute");
		questionMark = (GRichTextField)((GComponent)this).GetChild("questionMark");
		string id = "ui://b9wlonaqknp3hc".Replace("ui://", "") + "-" + ((GObject)questionMark).id;
		((GObject)questionMark).text = LanguagesManager.GetDesc(id);
		n10 = (GImage)((GComponent)this).GetChild("n10");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id2 = "ui://b9wlonaqknp3hc".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id2);
		n13 = (GMovieClip)((GComponent)this).GetChild("n13");
		ChangeText = ((GComponent)this).GetTransition("ChangeText");
	}
}
