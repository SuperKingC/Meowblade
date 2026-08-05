using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_ConfirmBtn : GButton
{
	public Controller button;

	public GLoader icon;

	public GTextField title;

	public GButton n8;

	public const string URL = "ui://avplaivdpzi2t3r";

	public static string Name = "UI_ConfirmBtn";

	public static string GetURL()
	{
		return "ui://avplaivdpzi2t3r";
	}

	public static UI_ConfirmBtn CreateInstance()
	{
		return (UI_ConfirmBtn)(object)UIPackage.CreateObject("Contract", "ConfirmBtn");
	}

	public static UI_ConfirmBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ConfirmBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdpzi2t3r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://avplaivdpzi2t3r".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n8 = (GButton)((GComponent)this).GetChild("n8");
	}
}
