using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_com_MessageDialog : GComponent
{
	public Controller Type;

	public GImage n101;

	public GImage n102;

	public GTextInput InputText;

	public GButton send;

	public GGroup InputGroup;

	public GList MessageView;

	public GGroup n107;

	public GImage n108;

	public GTextField n109;

	public GGroup n110;

	public GImage n111;

	public GImage n113;

	public GTextField n115;

	public GTextField n117;

	public GGroup n116;

	public const string URL = "ui://edr57v33tjql3i";

	public static string Name = "UI_com_MessageDialog";

	public static string GetURL()
	{
		return "ui://edr57v33tjql3i";
	}

	public static UI_com_MessageDialog CreateInstance()
	{
		return (UI_com_MessageDialog)(object)UIPackage.CreateObject("Mail", "com_MessageDialog");
	}

	public static UI_com_MessageDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_MessageDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33tjql3i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Expected O, but got Unknown
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		n101 = (GImage)((GComponent)this).GetChild("n101");
		n102 = (GImage)((GComponent)this).GetChild("n102");
		InputText = (GTextInput)((GComponent)this).GetChild("InputText");
		string id = "ui://edr57v33tjql3i".Replace("ui://", "") + "-" + ((GObject)InputText).id + "-prompt";
		InputText.promptText = LanguagesManager.GetDesc(id);
		send = (GButton)((GComponent)this).GetChild("send");
		InputGroup = (GGroup)((GComponent)this).GetChild("InputGroup");
		MessageView = (GList)((GComponent)this).GetChild("MessageView");
		n107 = (GGroup)((GComponent)this).GetChild("n107");
		n108 = (GImage)((GComponent)this).GetChild("n108");
		n109 = (GTextField)((GComponent)this).GetChild("n109");
		string id2 = "ui://edr57v33tjql3i".Replace("ui://", "") + "-" + ((GObject)n109).id;
		((GObject)n109).text = LanguagesManager.GetDesc(id2);
		n110 = (GGroup)((GComponent)this).GetChild("n110");
		n111 = (GImage)((GComponent)this).GetChild("n111");
		n113 = (GImage)((GComponent)this).GetChild("n113");
		n115 = (GTextField)((GComponent)this).GetChild("n115");
		string id3 = "ui://edr57v33tjql3i".Replace("ui://", "") + "-" + ((GObject)n115).id;
		((GObject)n115).text = LanguagesManager.GetDesc(id3);
		n117 = (GTextField)((GComponent)this).GetChild("n117");
		string id4 = "ui://edr57v33tjql3i".Replace("ui://", "") + "-" + ((GObject)n117).id;
		((GObject)n117).text = LanguagesManager.GetDesc(id4);
		n116 = (GGroup)((GComponent)this).GetChild("n116");
	}
}
