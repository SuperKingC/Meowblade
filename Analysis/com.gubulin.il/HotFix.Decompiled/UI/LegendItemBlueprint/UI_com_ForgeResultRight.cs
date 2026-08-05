using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_ForgeResultRight : GComponent
{
	public GImage n17;

	public GImage n18;

	public GTextField n19;

	public GTextField title3;

	public GRichTextField score;

	public GTextField title2;

	public GTextField primeAttribute;

	public GImage n28;

	public GImage n29;

	public UI_com_Propetry2 SubEntries;

	public const string URL = "ui://h09dvkcgh0te3r";

	public static string Name = "UI_com_ForgeResultRight";

	public static string GetURL()
	{
		return "ui://h09dvkcgh0te3r";
	}

	public static UI_com_ForgeResultRight CreateInstance()
	{
		return (UI_com_ForgeResultRight)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_ForgeResultRight");
	}

	public static UI_com_ForgeResultRight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ForgeResultRight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgh0te3r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n17 = (GImage)((GComponent)this).GetChild("n17");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n19 = (GTextField)((GComponent)this).GetChild("n19");
		string id = "ui://h09dvkcgh0te3r".Replace("ui://", "") + "-" + ((GObject)n19).id;
		((GObject)n19).text = LanguagesManager.GetDesc(id);
		title3 = (GTextField)((GComponent)this).GetChild("title3");
		string id2 = "ui://h09dvkcgh0te3r".Replace("ui://", "") + "-" + ((GObject)title3).id;
		((GObject)title3).text = LanguagesManager.GetDesc(id2);
		score = (GRichTextField)((GComponent)this).GetChild("score");
		title2 = (GTextField)((GComponent)this).GetChild("title2");
		string id3 = "ui://h09dvkcgh0te3r".Replace("ui://", "") + "-" + ((GObject)title2).id;
		((GObject)title2).text = LanguagesManager.GetDesc(id3);
		primeAttribute = (GTextField)((GComponent)this).GetChild("primeAttribute");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		n29 = (GImage)((GComponent)this).GetChild("n29");
		SubEntries = (UI_com_Propetry2)(object)((GComponent)this).GetChild("SubEntries");
	}
}
