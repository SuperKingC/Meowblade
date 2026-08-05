using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_GoToReviewDialog : GComponent
{
	public GImage n5;

	public GImage n3;

	public GTextField n0;

	public GTextField n1;

	public GButton GoToReviewBtn;

	public GRichTextField n6;

	public UI_exitBtn CloseBtn;

	public const string URL = "ui://47lbpgx9rc29j5ltfo";

	public static string Name = "UI_GoToReviewDialog";

	public static string GetURL()
	{
		return "ui://47lbpgx9rc29j5ltfo";
	}

	public static UI_GoToReviewDialog CreateInstance()
	{
		return (UI_GoToReviewDialog)(object)UIPackage.CreateObject("Tips", "GoToReviewDialog");
	}

	public static UI_GoToReviewDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GoToReviewDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9rc29j5ltfo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n0 = (GTextField)((GComponent)this).GetChild("n0");
		string id = "ui://47lbpgx9rc29j5ltfo".Replace("ui://", "") + "-" + ((GObject)n0).id;
		((GObject)n0).text = LanguagesManager.GetDesc(id);
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id2 = "ui://47lbpgx9rc29j5ltfo".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id2);
		GoToReviewBtn = (GButton)((GComponent)this).GetChild("GoToReviewBtn");
		n6 = (GRichTextField)((GComponent)this).GetChild("n6");
		string id3 = "ui://47lbpgx9rc29j5ltfo".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id3);
		CloseBtn = (UI_exitBtn)(object)((GComponent)this).GetChild("CloseBtn");
	}
}
