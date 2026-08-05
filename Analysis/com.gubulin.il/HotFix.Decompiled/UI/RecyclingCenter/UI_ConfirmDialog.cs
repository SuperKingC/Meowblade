using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_ConfirmDialog : GComponent
{
	public Controller Status;

	public GButton noBtn;

	public GButton yesBtn;

	public GImage n22;

	public GLoader npc;

	public GGraph n21;

	public GTextField npcName;

	public GGroup npcGroup;

	public GImage tipBack;

	public GTextField title;

	public GTextField tip1;

	public GTextField tip2;

	public const string URL = "ui://72poq8plkxix15";

	public static string Name = "UI_ConfirmDialog";

	public void SetControllerPageText()
	{
		string id = string.Format("{0}-{1}-{2}", "ui://72poq8plkxix15".Replace("ui://", ""), ((GObject)yesBtn).id, Status.selectedIndex);
		yesBtn.title = LanguagesManager.GetDesc(id);
		string id2 = string.Format("{0}-{1}-{2}", "ui://72poq8plkxix15".Replace("ui://", ""), ((GObject)title).id, Status.selectedIndex);
		((GObject)title).text = LanguagesManager.GetDesc(id2);
		string id3 = string.Format("{0}-{1}-{2}", "ui://72poq8plkxix15".Replace("ui://", ""), ((GObject)tip1).id, Status.selectedIndex);
		((GObject)tip1).text = LanguagesManager.GetDesc(id3);
		string id4 = string.Format("{0}-{1}-{2}", "ui://72poq8plkxix15".Replace("ui://", ""), ((GObject)tip2).id, Status.selectedIndex);
		((GObject)tip2).text = LanguagesManager.GetDesc(id4);
		noBtn.title = LanguagesManager.GetDesc("RecyclingCenter-ConfirmDialog-noBtn-title");
	}

	public static string GetURL()
	{
		return "ui://72poq8plkxix15";
	}

	public static UI_ConfirmDialog CreateInstance()
	{
		return (UI_ConfirmDialog)(object)UIPackage.CreateObject("RecyclingCenter", "ConfirmDialog");
	}

	public static UI_ConfirmDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plkxix15", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		noBtn = (GButton)((GComponent)this).GetChild("noBtn");
		yesBtn = (GButton)((GComponent)this).GetChild("yesBtn");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		npc = (GLoader)((GComponent)this).GetChild("npc");
		n21 = (GGraph)((GComponent)this).GetChild("n21");
		npcName = (GTextField)((GComponent)this).GetChild("npcName");
		string id = "ui://72poq8plkxix15".Replace("ui://", "") + "-" + ((GObject)npcName).id;
		((GObject)npcName).text = LanguagesManager.GetDesc(id);
		npcGroup = (GGroup)((GComponent)this).GetChild("npcGroup");
		tipBack = (GImage)((GComponent)this).GetChild("tipBack");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id2 = "ui://72poq8plkxix15".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id2);
		tip1 = (GTextField)((GComponent)this).GetChild("tip1");
		string id3 = "ui://72poq8plkxix15".Replace("ui://", "") + "-" + ((GObject)tip1).id;
		((GObject)tip1).text = LanguagesManager.GetDesc(id3);
		tip2 = (GTextField)((GComponent)this).GetChild("tip2");
		string id4 = "ui://72poq8plkxix15".Replace("ui://", "") + "-" + ((GObject)tip2).id;
		((GObject)tip2).text = LanguagesManager.GetDesc(id4);
	}
}
