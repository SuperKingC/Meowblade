using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_Dialog : GComponent
{
	public Controller pageControl;

	public Controller showFPS;

	public GImage back;

	public UI_Personal Personal;

	public GGraph line;

	public GGraph n156;

	public GTextField n38;

	public GTextField n37;

	public UI_show bgmSwitch;

	public UI_show soundSwitch;

	public GGraph n162;

	public GTextField n100;

	public UI_show LevelsOfDetail;

	public GGraph n188;

	public GTextField n189;

	public UI_show effectSwitch;

	public GGraph n160;

	public UI_ComboBox1 languagechoice;

	public GTextField n39;

	public GGraph n224;

	public GTextField n225;

	public UI_show debugSwitch;

	public GGraph n228;

	public UI_ComboBox2 fpschoice;

	public GTextField n230;

	public GGroup n231;

	public UI_boundBtn boundBtn;

	public UI_boundBtn invitationBtn;

	public UI_resetBtn resetBtn;

	public UI_exchangeBtn exchangeBtn;

	public UI_exchangeBtn feedbackBtn;

	public UI_BookBtn logoutBtn;

	public UI_boundBtn friendsBtn;

	public UI_BookBtn joinQqChatBtn;

	public UI_exchangeBtn feedbackBtn2;

	public UI_exchangeBtn feedbackBtn3;

	public GTextField AddFriendTip;

	public GImage n167;

	public GImage n168;

	public GImage n169;

	public GImage n170;

	public GImage n171;

	public GImage n172;

	public GImage n186;

	public GImage n174;

	public GImage n175;

	public GImage n176;

	public GImage n177;

	public UI_accountInfoBtn AvatarBtn;

	public UI_accountInfoBtn titleBtn;

	public UI_accountInfoBtn frameAvatarBtn;

	public UI_accountInfoBtn namePlateBtn;

	public GGroup subPanel;

	public GTextField n68;

	public UI_DO_ListHeader TitleList_Header;

	public UI_DO_ListHeader FrameList_Header;

	public UI_DO_ListHeader NamePlateList_Header;

	public GList TitleList;

	public GList FrameList;

	public GList NamePlateList;

	public GImage AddBtn;

	public UI_ImageTest Avatarloader;

	public UI_BookBtnNew bookBtn;

	public const string URL = "ui://b9yxt7u0t1jr1";

	public static string Name = "UI_Dialog";

	public static string GetURL()
	{
		return "ui://b9yxt7u0t1jr1";
	}

	public static UI_Dialog CreateInstance()
	{
		return (UI_Dialog)(object)UIPackage.CreateObject("AccountInfo", "Dialog");
	}

	public static UI_Dialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Dialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0t1jr1", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Expected O, but got Unknown
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Expected O, but got Unknown
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Expected O, but got Unknown
		//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Expected O, but got Unknown
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_0533: Expected O, but got Unknown
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0549: Expected O, but got Unknown
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Expected O, but got Unknown
		//IL_056b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Expected O, but got Unknown
		//IL_0581: Unknown result type (might be due to invalid IL or missing references)
		//IL_058b: Expected O, but got Unknown
		//IL_0597: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a1: Expected O, but got Unknown
		//IL_05ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b7: Expected O, but got Unknown
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cd: Expected O, but got Unknown
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e3: Expected O, but got Unknown
		//IL_05ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f9: Expected O, but got Unknown
		//IL_0605: Unknown result type (might be due to invalid IL or missing references)
		//IL_060f: Expected O, but got Unknown
		//IL_0673: Unknown result type (might be due to invalid IL or missing references)
		//IL_067d: Expected O, but got Unknown
		//IL_0689: Unknown result type (might be due to invalid IL or missing references)
		//IL_0693: Expected O, but got Unknown
		//IL_0720: Unknown result type (might be due to invalid IL or missing references)
		//IL_072a: Expected O, but got Unknown
		//IL_0736: Unknown result type (might be due to invalid IL or missing references)
		//IL_0740: Expected O, but got Unknown
		//IL_074c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0756: Expected O, but got Unknown
		//IL_0762: Unknown result type (might be due to invalid IL or missing references)
		//IL_076c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		pageControl = ((GComponent)this).GetController("pageControl");
		showFPS = ((GComponent)this).GetController("showFPS");
		back = (GImage)((GComponent)this).GetChild("back");
		Personal = (UI_Personal)(object)((GComponent)this).GetChild("Personal");
		line = (GGraph)((GComponent)this).GetChild("line");
		n156 = (GGraph)((GComponent)this).GetChild("n156");
		n38 = (GTextField)((GComponent)this).GetChild("n38");
		string id = "ui://b9yxt7u0t1jr1".Replace("ui://", "") + "-" + ((GObject)n38).id;
		((GObject)n38).text = LanguagesManager.GetDesc(id);
		n37 = (GTextField)((GComponent)this).GetChild("n37");
		string id2 = "ui://b9yxt7u0t1jr1".Replace("ui://", "") + "-" + ((GObject)n37).id;
		((GObject)n37).text = LanguagesManager.GetDesc(id2);
		bgmSwitch = (UI_show)(object)((GComponent)this).GetChild("bgmSwitch");
		soundSwitch = (UI_show)(object)((GComponent)this).GetChild("soundSwitch");
		n162 = (GGraph)((GComponent)this).GetChild("n162");
		n100 = (GTextField)((GComponent)this).GetChild("n100");
		string id3 = "ui://b9yxt7u0t1jr1".Replace("ui://", "") + "-" + ((GObject)n100).id;
		((GObject)n100).text = LanguagesManager.GetDesc(id3);
		LevelsOfDetail = (UI_show)(object)((GComponent)this).GetChild("LevelsOfDetail");
		n188 = (GGraph)((GComponent)this).GetChild("n188");
		n189 = (GTextField)((GComponent)this).GetChild("n189");
		string id4 = "ui://b9yxt7u0t1jr1".Replace("ui://", "") + "-" + ((GObject)n189).id;
		((GObject)n189).text = LanguagesManager.GetDesc(id4);
		effectSwitch = (UI_show)(object)((GComponent)this).GetChild("effectSwitch");
		n160 = (GGraph)((GComponent)this).GetChild("n160");
		languagechoice = (UI_ComboBox1)(object)((GComponent)this).GetChild("languagechoice");
		n39 = (GTextField)((GComponent)this).GetChild("n39");
		string id5 = "ui://b9yxt7u0t1jr1".Replace("ui://", "") + "-" + ((GObject)n39).id;
		((GObject)n39).text = LanguagesManager.GetDesc(id5);
		n224 = (GGraph)((GComponent)this).GetChild("n224");
		n225 = (GTextField)((GComponent)this).GetChild("n225");
		string id6 = "ui://b9yxt7u0t1jr1".Replace("ui://", "") + "-" + ((GObject)n225).id;
		((GObject)n225).text = LanguagesManager.GetDesc(id6);
		debugSwitch = (UI_show)(object)((GComponent)this).GetChild("debugSwitch");
		n228 = (GGraph)((GComponent)this).GetChild("n228");
		fpschoice = (UI_ComboBox2)(object)((GComponent)this).GetChild("fpschoice");
		n230 = (GTextField)((GComponent)this).GetChild("n230");
		string id7 = "ui://b9yxt7u0t1jr1".Replace("ui://", "") + "-" + ((GObject)n230).id;
		((GObject)n230).text = LanguagesManager.GetDesc(id7);
		n231 = (GGroup)((GComponent)this).GetChild("n231");
		boundBtn = (UI_boundBtn)(object)((GComponent)this).GetChild("boundBtn");
		invitationBtn = (UI_boundBtn)(object)((GComponent)this).GetChild("invitationBtn");
		resetBtn = (UI_resetBtn)(object)((GComponent)this).GetChild("resetBtn");
		exchangeBtn = (UI_exchangeBtn)(object)((GComponent)this).GetChild("exchangeBtn");
		feedbackBtn = (UI_exchangeBtn)(object)((GComponent)this).GetChild("feedbackBtn");
		logoutBtn = (UI_BookBtn)(object)((GComponent)this).GetChild("logoutBtn");
		friendsBtn = (UI_boundBtn)(object)((GComponent)this).GetChild("friendsBtn");
		joinQqChatBtn = (UI_BookBtn)(object)((GComponent)this).GetChild("joinQqChatBtn");
		feedbackBtn2 = (UI_exchangeBtn)(object)((GComponent)this).GetChild("feedbackBtn2");
		feedbackBtn3 = (UI_exchangeBtn)(object)((GComponent)this).GetChild("feedbackBtn3");
		AddFriendTip = (GTextField)((GComponent)this).GetChild("AddFriendTip");
		string id8 = "ui://b9yxt7u0t1jr1".Replace("ui://", "") + "-" + ((GObject)AddFriendTip).id;
		((GObject)AddFriendTip).text = LanguagesManager.GetDesc(id8);
		n167 = (GImage)((GComponent)this).GetChild("n167");
		n168 = (GImage)((GComponent)this).GetChild("n168");
		n169 = (GImage)((GComponent)this).GetChild("n169");
		n170 = (GImage)((GComponent)this).GetChild("n170");
		n171 = (GImage)((GComponent)this).GetChild("n171");
		n172 = (GImage)((GComponent)this).GetChild("n172");
		n186 = (GImage)((GComponent)this).GetChild("n186");
		n174 = (GImage)((GComponent)this).GetChild("n174");
		n175 = (GImage)((GComponent)this).GetChild("n175");
		n176 = (GImage)((GComponent)this).GetChild("n176");
		n177 = (GImage)((GComponent)this).GetChild("n177");
		AvatarBtn = (UI_accountInfoBtn)(object)((GComponent)this).GetChild("AvatarBtn");
		titleBtn = (UI_accountInfoBtn)(object)((GComponent)this).GetChild("titleBtn");
		frameAvatarBtn = (UI_accountInfoBtn)(object)((GComponent)this).GetChild("frameAvatarBtn");
		namePlateBtn = (UI_accountInfoBtn)(object)((GComponent)this).GetChild("namePlateBtn");
		subPanel = (GGroup)((GComponent)this).GetChild("subPanel");
		n68 = (GTextField)((GComponent)this).GetChild("n68");
		string id9 = "ui://b9yxt7u0t1jr1".Replace("ui://", "") + "-" + ((GObject)n68).id;
		((GObject)n68).text = LanguagesManager.GetDesc(id9);
		TitleList_Header = (UI_DO_ListHeader)(object)((GComponent)this).GetChild("TitleList_Header");
		FrameList_Header = (UI_DO_ListHeader)(object)((GComponent)this).GetChild("FrameList_Header");
		NamePlateList_Header = (UI_DO_ListHeader)(object)((GComponent)this).GetChild("NamePlateList_Header");
		TitleList = (GList)((GComponent)this).GetChild("TitleList");
		FrameList = (GList)((GComponent)this).GetChild("FrameList");
		NamePlateList = (GList)((GComponent)this).GetChild("NamePlateList");
		AddBtn = (GImage)((GComponent)this).GetChild("AddBtn");
		Avatarloader = (UI_ImageTest)(object)((GComponent)this).GetChild("Avatarloader");
		bookBtn = (UI_BookBtnNew)(object)((GComponent)this).GetChild("bookBtn");
	}

	public void SetButtonTitle()
	{
		((GObject)AvatarBtn.title).text = LanguagesManager.GetDesc("AccountInfo-Dialog-AvatarBtn-title");
		((GObject)titleBtn.title).text = LanguagesManager.GetDesc("AccountInfo-Dialog-titleBtn-title");
		((GObject)frameAvatarBtn.title).text = LanguagesManager.GetDesc("AccountInfo-Dialog-frameAvatarBtn-title");
		((GObject)namePlateBtn.title).text = LanguagesManager.GetDesc("AccountInfo-Dialog-namePlateBtn-title");
	}
}
