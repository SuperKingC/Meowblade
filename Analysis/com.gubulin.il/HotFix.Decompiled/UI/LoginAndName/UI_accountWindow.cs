using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_accountWindow : GButton
{
	public Controller button;

	public GGraph mask;

	public GImage back;

	public GImage n51;

	public GImage n55;

	public GImage n52;

	public GImage n54;

	public GImage n47;

	public GTextField n50;

	public GTextField n33;

	public GTextField boundAccountText;

	public UI_Account02 switchAccountBtn;

	public UI_resetBtn resetBtn;

	public UI_CopyBtn CopyBtn;

	public UI_userNameBtn nameBtn;

	public GTextField serverName;

	public GTextField userIdText;

	public GTextField n53;

	public GTextField n56;

	public GTextField n57;

	public UI_exitBtn exit;

	public const string URL = "ui://yb3s7uv7bw1c24";

	public static string Name = "UI_accountWindow";

	public static string GetURL()
	{
		return "ui://yb3s7uv7bw1c24";
	}

	public static UI_accountWindow CreateInstance()
	{
		return (UI_accountWindow)(object)UIPackage.CreateObject("LoginAndName", "accountWindow");
	}

	public static UI_accountWindow CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_accountWindow).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7bw1c24", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		back = (GImage)((GComponent)this).GetChild("back");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n55 = (GImage)((GComponent)this).GetChild("n55");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n54 = (GImage)((GComponent)this).GetChild("n54");
		n47 = (GImage)((GComponent)this).GetChild("n47");
		n50 = (GTextField)((GComponent)this).GetChild("n50");
		string id = "ui://yb3s7uv7bw1c24".Replace("ui://", "") + "-" + ((GObject)n50).id;
		((GObject)n50).text = LanguagesManager.GetDesc(id);
		n33 = (GTextField)((GComponent)this).GetChild("n33");
		string id2 = "ui://yb3s7uv7bw1c24".Replace("ui://", "") + "-" + ((GObject)n33).id;
		((GObject)n33).text = LanguagesManager.GetDesc(id2);
		boundAccountText = (GTextField)((GComponent)this).GetChild("boundAccountText");
		string id3 = "ui://yb3s7uv7bw1c24".Replace("ui://", "") + "-" + ((GObject)boundAccountText).id;
		((GObject)boundAccountText).text = LanguagesManager.GetDesc(id3);
		switchAccountBtn = (UI_Account02)(object)((GComponent)this).GetChild("switchAccountBtn");
		resetBtn = (UI_resetBtn)(object)((GComponent)this).GetChild("resetBtn");
		CopyBtn = (UI_CopyBtn)(object)((GComponent)this).GetChild("CopyBtn");
		nameBtn = (UI_userNameBtn)(object)((GComponent)this).GetChild("nameBtn");
		serverName = (GTextField)((GComponent)this).GetChild("serverName");
		userIdText = (GTextField)((GComponent)this).GetChild("userIdText");
		string id4 = "ui://yb3s7uv7bw1c24".Replace("ui://", "") + "-" + ((GObject)userIdText).id;
		((GObject)userIdText).text = LanguagesManager.GetDesc(id4);
		n53 = (GTextField)((GComponent)this).GetChild("n53");
		string id5 = "ui://yb3s7uv7bw1c24".Replace("ui://", "") + "-" + ((GObject)n53).id;
		((GObject)n53).text = LanguagesManager.GetDesc(id5);
		n56 = (GTextField)((GComponent)this).GetChild("n56");
		string id6 = "ui://yb3s7uv7bw1c24".Replace("ui://", "") + "-" + ((GObject)n56).id;
		((GObject)n56).text = LanguagesManager.GetDesc(id6);
		n57 = (GTextField)((GComponent)this).GetChild("n57");
		string id7 = "ui://yb3s7uv7bw1c24".Replace("ui://", "") + "-" + ((GObject)n57).id;
		((GObject)n57).text = LanguagesManager.GetDesc(id7);
		exit = (UI_exitBtn)(object)((GComponent)this).GetChild("exit");
	}
}
