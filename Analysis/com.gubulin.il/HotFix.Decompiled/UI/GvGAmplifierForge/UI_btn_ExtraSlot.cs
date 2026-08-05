using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierForge;

public class UI_btn_ExtraSlot : GButton
{
	public Controller ItemType;

	public UI_AmplifierSlot Amplifier;

	public UI_com_Item Item;

	public UI_com_Formula Formula;

	public GImage n205;

	public GLoader TalentSrc;

	public const string URL = "ui://fpjheycbrxgdv4fh";

	public static string Name = "UI_btn_ExtraSlot";

	public static string GetURL()
	{
		return "ui://fpjheycbrxgdv4fh";
	}

	public static UI_btn_ExtraSlot CreateInstance()
	{
		return (UI_btn_ExtraSlot)(object)UIPackage.CreateObject("GvGAmplifierForge", "btn_ExtraSlot");
	}

	public static UI_btn_ExtraSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ExtraSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbrxgdv4fh", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ItemType = ((GComponent)this).GetController("ItemType");
		Amplifier = (UI_AmplifierSlot)(object)((GComponent)this).GetChild("Amplifier");
		Item = (UI_com_Item)(object)((GComponent)this).GetChild("Item");
		Formula = (UI_com_Formula)(object)((GComponent)this).GetChild("Formula");
		n205 = (GImage)((GComponent)this).GetChild("n205");
		TalentSrc = (GLoader)((GComponent)this).GetChild("TalentSrc");
	}
}
