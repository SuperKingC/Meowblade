using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_cancelBtn : GButton
{
	public Controller button;

	public GImage background;

	public GRichTextField title;

	public GLoader ticketIcon;

	public GTextField cost;

	public GLoader icon;

	public const string URL = "ui://avplaivdpzi2t3v";

	public static string Name = "UI_cancelBtn";

	public static string GetURL()
	{
		return "ui://avplaivdpzi2t3v";
	}

	public static UI_cancelBtn CreateInstance()
	{
		return (UI_cancelBtn)(object)UIPackage.CreateObject("Contract", "cancelBtn");
	}

	public static UI_cancelBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_cancelBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdpzi2t3v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
		title = (GRichTextField)((GComponent)this).GetChild("title");
		string id = "ui://avplaivdpzi2t3v".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		ticketIcon = (GLoader)((GComponent)this).GetChild("ticketIcon");
		cost = (GTextField)((GComponent)this).GetChild("cost");
		string id2 = "ui://avplaivdpzi2t3v".Replace("ui://", "") + "-" + ((GObject)cost).id;
		((GObject)cost).text = LanguagesManager.GetDesc(id2);
		icon = (GLoader)((GComponent)this).GetChild("icon");
	}
}
