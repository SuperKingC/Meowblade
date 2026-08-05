using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Mail;

public class UI_com_UserMessage : GComponent
{
	public Controller state;

	public GImage n97;

	public GImage n108;

	public GImage n110;

	public GComponent Avatar;

	public GImage n100;

	public GTextField level;

	public GTextField name;

	public GGraph n104;

	public GList MedalList;

	public UI_com_Newmessage newMessage;

	public const string URL = "ui://edr57v33tjql3b";

	public static string Name = "UI_com_UserMessage";

	public static string GetURL()
	{
		return "ui://edr57v33tjql3b";
	}

	public static UI_com_UserMessage CreateInstance()
	{
		return (UI_com_UserMessage)(object)UIPackage.CreateObject("Mail", "com_UserMessage");
	}

	public static UI_com_UserMessage CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_UserMessage).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://edr57v33tjql3b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		state = ((GComponent)this).GetController("state");
		n97 = (GImage)((GComponent)this).GetChild("n97");
		n108 = (GImage)((GComponent)this).GetChild("n108");
		n110 = (GImage)((GComponent)this).GetChild("n110");
		Avatar = (GComponent)((GComponent)this).GetChild("Avatar");
		n100 = (GImage)((GComponent)this).GetChild("n100");
		level = (GTextField)((GComponent)this).GetChild("level");
		string id = "ui://edr57v33tjql3b".Replace("ui://", "") + "-" + ((GObject)level).id;
		((GObject)level).text = LanguagesManager.GetDesc(id);
		name = (GTextField)((GComponent)this).GetChild("name");
		string id2 = "ui://edr57v33tjql3b".Replace("ui://", "") + "-" + ((GObject)name).id;
		((GObject)name).text = LanguagesManager.GetDesc(id2);
		n104 = (GGraph)((GComponent)this).GetChild("n104");
		MedalList = (GList)((GComponent)this).GetChild("MedalList");
		newMessage = (UI_com_Newmessage)(object)((GComponent)this).GetChild("newMessage");
	}
}
