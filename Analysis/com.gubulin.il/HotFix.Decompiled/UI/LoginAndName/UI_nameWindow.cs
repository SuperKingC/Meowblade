using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LoginAndName;

public class UI_nameWindow : GButton
{
	public Controller button;

	public GGraph mask;

	public UI_tipYes tipYes;

	public UI_tipNo tipNo;

	public UI_backMainButton exitBtn;

	public UI_allReceive startGameBtn;

	public GImage tipBackground;

	public GRichTextField title;

	public GImage inputBackground;

	public UI_clear clearInputBtn;

	public GTextInput inputName;

	public UI_nameTip nameTipBtn;

	public GGroup tipGroup;

	public const string URL = "ui://yb3s7uv7ryu86";

	public static string Name = "UI_nameWindow";

	public static string GetURL()
	{
		return "ui://yb3s7uv7ryu86";
	}

	public static UI_nameWindow CreateInstance()
	{
		return (UI_nameWindow)(object)UIPackage.CreateObject("LoginAndName", "nameWindow");
	}

	public static UI_nameWindow CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_nameWindow).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://yb3s7uv7ryu86", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		mask = (GGraph)((GComponent)this).GetChild("mask");
		tipYes = (UI_tipYes)(object)((GComponent)this).GetChild("tipYes");
		tipNo = (UI_tipNo)(object)((GComponent)this).GetChild("tipNo");
		exitBtn = (UI_backMainButton)(object)((GComponent)this).GetChild("exitBtn");
		startGameBtn = (UI_allReceive)(object)((GComponent)this).GetChild("startGameBtn");
		tipBackground = (GImage)((GComponent)this).GetChild("tipBackground");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://yb3s7uv7ryu86".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		inputBackground = (GImage)((GComponent)this).GetChild("inputBackground");
		clearInputBtn = (UI_clear)(object)((GComponent)this).GetChild("clearInputBtn");
		inputName = (GTextInput)((GComponent)this).GetChild("inputName");
		string id2 = "ui://yb3s7uv7ryu86".Replace("ui://", "") + "-" + ((GObject)inputName).id + "-prompt";
		inputName.promptText = LanguagesManager.GetDesc(id2);
		nameTipBtn = (UI_nameTip)(object)((GComponent)this).GetChild("nameTipBtn");
		tipGroup = (GGroup)((GComponent)this).GetChild("tipGroup");
	}
}
