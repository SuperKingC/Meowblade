using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_UniversalConfirmDialogI : GComponent
{
	public Controller PageController;

	public GImage back;

	public GTextField tip;

	public GImage n28;

	public GLoader npc;

	public GGraph n27;

	public GTextField npcName;

	public GGroup npcGroup;

	public GImage tipBack;

	public GTextField title;

	public GTextField tip1;

	public GTextField tip2;

	public GTextField tip3;

	public GTextField tip5;

	public GTextField tip4;

	public GButton noBtn;

	public GButton yesBtn;

	public GTextField tip6;

	public GTextField tip7;

	public GTextField tip8;

	public GTextField tip9;

	public GGroup n26;

	public const string URL = "ui://47lbpgx9pl0i1q";

	public static string Name = "UI_UniversalConfirmDialogI";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://47lbpgx9pl0i1q".Replace("ui://", ""), ((GObject)npcName).id, PageController.selectedIndex);
		((GObject)npcName).text = LanguagesManager.GetDesc(id);
		string id2 = string.Format("{0}-{1}-{2}", "ui://47lbpgx9pl0i1q".Replace("ui://", ""), ((GObject)noBtn).id, PageController.selectedIndex);
		((GObject)noBtn).text = LanguagesManager.GetDesc(id2, returnKey: false);
		string id3 = string.Format("{0}-{1}-{2}", "ui://47lbpgx9pl0i1q".Replace("ui://", ""), ((GObject)yesBtn).id, PageController.selectedIndex);
		((GObject)yesBtn).text = LanguagesManager.GetDesc(id3, returnKey: false);
	}

	public static string GetURL()
	{
		return "ui://47lbpgx9pl0i1q";
	}

	public static UI_UniversalConfirmDialogI CreateInstance()
	{
		return (UI_UniversalConfirmDialogI)(object)UIPackage.CreateObject("Tips", "UniversalConfirmDialogI");
	}

	public static UI_UniversalConfirmDialogI CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UniversalConfirmDialogI).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9pl0i1q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Expected O, but got Unknown
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Expected O, but got Unknown
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Expected O, but got Unknown
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Expected O, but got Unknown
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Expected O, but got Unknown
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Expected O, but got Unknown
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Expected O, but got Unknown
		//IL_048b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		back = (GImage)((GComponent)this).GetChild("back");
		tip = (GTextField)((GComponent)this).GetChild("tip");
		n28 = (GImage)((GComponent)this).GetChild("n28");
		npc = (GLoader)((GComponent)this).GetChild("npc");
		n27 = (GGraph)((GComponent)this).GetChild("n27");
		npcName = (GTextField)((GComponent)this).GetChild("npcName");
		string id = "ui://47lbpgx9pl0i1q".Replace("ui://", "") + "-" + ((GObject)npcName).id;
		((GObject)npcName).text = LanguagesManager.GetDesc(id);
		npcGroup = (GGroup)((GComponent)this).GetChild("npcGroup");
		tipBack = (GImage)((GComponent)this).GetChild("tipBack");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id2 = "ui://47lbpgx9pl0i1q".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id2);
		tip1 = (GTextField)((GComponent)this).GetChild("tip1");
		string id3 = "ui://47lbpgx9pl0i1q".Replace("ui://", "") + "-" + ((GObject)tip1).id;
		((GObject)tip1).text = LanguagesManager.GetDesc(id3);
		tip2 = (GTextField)((GComponent)this).GetChild("tip2");
		string id4 = "ui://47lbpgx9pl0i1q".Replace("ui://", "") + "-" + ((GObject)tip2).id;
		((GObject)tip2).text = LanguagesManager.GetDesc(id4);
		tip3 = (GTextField)((GComponent)this).GetChild("tip3");
		string id5 = "ui://47lbpgx9pl0i1q".Replace("ui://", "") + "-" + ((GObject)tip3).id;
		((GObject)tip3).text = LanguagesManager.GetDesc(id5);
		tip5 = (GTextField)((GComponent)this).GetChild("tip5");
		string id6 = "ui://47lbpgx9pl0i1q".Replace("ui://", "") + "-" + ((GObject)tip5).id;
		((GObject)tip5).text = LanguagesManager.GetDesc(id6);
		tip4 = (GTextField)((GComponent)this).GetChild("tip4");
		string id7 = "ui://47lbpgx9pl0i1q".Replace("ui://", "") + "-" + ((GObject)tip4).id;
		((GObject)tip4).text = LanguagesManager.GetDesc(id7);
		noBtn = (GButton)((GComponent)this).GetChild("noBtn");
		yesBtn = (GButton)((GComponent)this).GetChild("yesBtn");
		tip6 = (GTextField)((GComponent)this).GetChild("tip6");
		string id8 = "ui://47lbpgx9pl0i1q".Replace("ui://", "") + "-" + ((GObject)tip6).id;
		((GObject)tip6).text = LanguagesManager.GetDesc(id8);
		tip7 = (GTextField)((GComponent)this).GetChild("tip7");
		string id9 = "ui://47lbpgx9pl0i1q".Replace("ui://", "") + "-" + ((GObject)tip7).id;
		((GObject)tip7).text = LanguagesManager.GetDesc(id9);
		tip8 = (GTextField)((GComponent)this).GetChild("tip8");
		string id10 = "ui://47lbpgx9pl0i1q".Replace("ui://", "") + "-" + ((GObject)tip8).id;
		((GObject)tip8).text = LanguagesManager.GetDesc(id10);
		tip9 = (GTextField)((GComponent)this).GetChild("tip9");
		string id11 = "ui://47lbpgx9pl0i1q".Replace("ui://", "") + "-" + ((GObject)tip9).id;
		((GObject)tip9).text = LanguagesManager.GetDesc(id11);
		n26 = (GGroup)((GComponent)this).GetChild("n26");
	}
}
