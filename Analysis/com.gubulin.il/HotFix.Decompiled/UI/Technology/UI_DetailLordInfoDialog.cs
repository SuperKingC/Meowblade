using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_DetailLordInfoDialog : GComponent
{
	public Controller Type;

	public GImage back;

	public GGraph n30;

	public GLoader IconFrame;

	public GLoader IconLoader;

	public GTextField Title;

	public GTextField gradeTitle;

	public GTextField Level;

	public GTextField pieceTitle;

	public GTextField pieceNum;

	public GTextField describe;

	public GButton exit;

	public GTextField n31;

	public GImage n33;

	public const string URL = "ui://7ca77a3fgp9d2n";

	public static string Name = "UI_DetailLordInfoDialog";

	public static string GetURL()
	{
		return "ui://7ca77a3fgp9d2n";
	}

	public static UI_DetailLordInfoDialog CreateInstance()
	{
		return (UI_DetailLordInfoDialog)(object)UIPackage.CreateObject("Technology", "DetailLordInfoDialog");
	}

	public static UI_DetailLordInfoDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DetailLordInfoDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fgp9d2n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Expected O, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		back = (GImage)((GComponent)this).GetChild("back");
		n30 = (GGraph)((GComponent)this).GetChild("n30");
		IconFrame = (GLoader)((GComponent)this).GetChild("IconFrame");
		IconLoader = (GLoader)((GComponent)this).GetChild("IconLoader");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://7ca77a3fgp9d2n".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		gradeTitle = (GTextField)((GComponent)this).GetChild("gradeTitle");
		string id2 = "ui://7ca77a3fgp9d2n".Replace("ui://", "") + "-" + ((GObject)gradeTitle).id;
		((GObject)gradeTitle).text = LanguagesManager.GetDesc(id2);
		Level = (GTextField)((GComponent)this).GetChild("Level");
		string id3 = "ui://7ca77a3fgp9d2n".Replace("ui://", "") + "-" + ((GObject)Level).id;
		((GObject)Level).text = LanguagesManager.GetDesc(id3);
		pieceTitle = (GTextField)((GComponent)this).GetChild("pieceTitle");
		string id4 = "ui://7ca77a3fgp9d2n".Replace("ui://", "") + "-" + ((GObject)pieceTitle).id;
		((GObject)pieceTitle).text = LanguagesManager.GetDesc(id4);
		pieceNum = (GTextField)((GComponent)this).GetChild("pieceNum");
		string id5 = "ui://7ca77a3fgp9d2n".Replace("ui://", "") + "-" + ((GObject)pieceNum).id;
		((GObject)pieceNum).text = LanguagesManager.GetDesc(id5);
		describe = (GTextField)((GComponent)this).GetChild("describe");
		string id6 = "ui://7ca77a3fgp9d2n".Replace("ui://", "") + "-" + ((GObject)describe).id;
		((GObject)describe).text = LanguagesManager.GetDesc(id6);
		exit = (GButton)((GComponent)this).GetChild("exit");
		n31 = (GTextField)((GComponent)this).GetChild("n31");
		string id7 = "ui://7ca77a3fgp9d2n".Replace("ui://", "") + "-" + ((GObject)n31).id;
		((GObject)n31).text = LanguagesManager.GetDesc(id7);
		n33 = (GImage)((GComponent)this).GetChild("n33");
	}
}
