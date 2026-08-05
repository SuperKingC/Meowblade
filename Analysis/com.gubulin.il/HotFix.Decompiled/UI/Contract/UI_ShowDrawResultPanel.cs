using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_ShowDrawResultPanel : GComponent
{
	public Controller PageController;

	public GGraph mask;

	public GImage back;

	public GTextField title;

	public GTextField tip;

	public GList resultList;

	public UI_again againBtn;

	public GButton exitBtn;

	public GGroup content10;

	public UI_ResultDialog content1;

	public Transition showContent;

	public Transition showContent1;

	public const string URL = "ui://avplaivd108mt3k";

	public static string Name = "UI_ShowDrawResultPanel";

	public static string GetURL()
	{
		return "ui://avplaivd108mt3k";
	}

	public static UI_ShowDrawResultPanel CreateInstance()
	{
		return (UI_ShowDrawResultPanel)(object)UIPackage.CreateObject("Contract", "ShowDrawResultPanel");
	}

	public static UI_ShowDrawResultPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ShowDrawResultPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivd108mt3k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		PageController = ((GComponent)this).GetController("PageController");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://avplaivd108mt3k".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		tip = (GTextField)((GComponent)this).GetChild("tip");
		string id2 = "ui://avplaivd108mt3k".Replace("ui://", "") + "-" + ((GObject)tip).id;
		((GObject)tip).text = LanguagesManager.GetDesc(id2);
		resultList = (GList)((GComponent)this).GetChild("resultList");
		againBtn = (UI_again)(object)((GComponent)this).GetChild("againBtn");
		exitBtn = (GButton)((GComponent)this).GetChild("exitBtn");
		content10 = (GGroup)((GComponent)this).GetChild("content10");
		content1 = (UI_ResultDialog)(object)((GComponent)this).GetChild("content1");
		showContent = ((GComponent)this).GetTransition("showContent");
		showContent1 = ((GComponent)this).GetTransition("showContent1");
	}
}
