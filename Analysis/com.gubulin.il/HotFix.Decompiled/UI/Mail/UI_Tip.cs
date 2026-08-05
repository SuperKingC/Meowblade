using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_Tip : GComponent
{
	public GGraph mask;

	public GImage bg;

	public GRichTextField tips;

	public GButton no;

	public GButton yes;

	public GTextField title;

	public GGroup Tip;

	public GButton close;

	public const string URL = "ui://edr57v33oipi13";

	public static string Name = "UI_Tip";

	public static string GetURL()
	{
		return "ui://edr57v33oipi13";
	}

	public static UI_Tip CreateInstance()
	{
		return (UI_Tip)(object)UIPackage.CreateObject("Mail", "Tip");
	}

	public static UI_Tip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Tip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33oipi13", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		mask = (GGraph)((GComponent)this).GetChild("mask");
		bg = (GImage)((GComponent)this).GetChild("bg");
		tips = (GRichTextField)((GComponent)this).GetChild("tips");
		string id = "ui://edr57v33oipi13".Replace("ui://", "") + "-" + ((GObject)tips).id;
		((GObject)tips).text = LanguagesManager.GetDesc(id);
		no = (GButton)((GComponent)this).GetChild("no");
		yes = (GButton)((GComponent)this).GetChild("yes");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id2 = "ui://edr57v33oipi13".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id2);
		Tip = (GGroup)((GComponent)this).GetChild("Tip");
		close = (GButton)((GComponent)this).GetChild("close");
	}
}
