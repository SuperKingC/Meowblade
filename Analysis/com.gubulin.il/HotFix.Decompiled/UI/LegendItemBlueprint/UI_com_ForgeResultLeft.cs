using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_ForgeResultLeft : GComponent
{
	public GImage n16;

	public GImage n23;

	public GTextField n24;

	public GTextField title3;

	public GTextField score;

	public GTextField title2;

	public GTextField primeAttribute;

	public GList Content;

	public const string URL = "ui://h09dvkcgh0te3q";

	public static string Name = "UI_com_ForgeResultLeft";

	public static string GetURL()
	{
		return "ui://h09dvkcgh0te3q";
	}

	public static UI_com_ForgeResultLeft CreateInstance()
	{
		return (UI_com_ForgeResultLeft)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_ForgeResultLeft");
	}

	public static UI_com_ForgeResultLeft CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ForgeResultLeft).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgh0te3q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n24 = (GTextField)((GComponent)this).GetChild("n24");
		string id = "ui://h09dvkcgh0te3q".Replace("ui://", "") + "-" + ((GObject)n24).id;
		((GObject)n24).text = LanguagesManager.GetDesc(id);
		title3 = (GTextField)((GComponent)this).GetChild("title3");
		string id2 = "ui://h09dvkcgh0te3q".Replace("ui://", "") + "-" + ((GObject)title3).id;
		((GObject)title3).text = LanguagesManager.GetDesc(id2);
		score = (GTextField)((GComponent)this).GetChild("score");
		title2 = (GTextField)((GComponent)this).GetChild("title2");
		string id3 = "ui://h09dvkcgh0te3q".Replace("ui://", "") + "-" + ((GObject)title2).id;
		((GObject)title2).text = LanguagesManager.GetDesc(id3);
		primeAttribute = (GTextField)((GComponent)this).GetChild("primeAttribute");
		Content = (GList)((GComponent)this).GetChild("Content");
	}
}
