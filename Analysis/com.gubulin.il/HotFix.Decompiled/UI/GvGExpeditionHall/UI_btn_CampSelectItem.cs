using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_CampSelectItem : GButton
{
	public Controller button;

	public Controller CampId;

	public GImage n48;

	public GLoader n47;

	public GTextField red;

	public GTextField green;

	public GTextField blue;

	public GTextField yellow;

	public GGroup name_notchosen;

	public GTextField red2;

	public GTextField green2;

	public GTextField blue2;

	public GTextField yellow2;

	public GGroup name_chosen;

	public const string URL = "ui://k19peou7dnvl2a";

	public static string Name = "UI_btn_CampSelectItem";

	public static string GetURL()
	{
		return "ui://k19peou7dnvl2a";
	}

	public static UI_btn_CampSelectItem CreateInstance()
	{
		return (UI_btn_CampSelectItem)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_CampSelectItem");
	}

	public static UI_btn_CampSelectItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_CampSelectItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7dnvl2a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Expected O, but got Unknown
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		CampId = ((GComponent)this).GetController("CampId");
		n48 = (GImage)((GComponent)this).GetChild("n48");
		n47 = (GLoader)((GComponent)this).GetChild("n47");
		red = (GTextField)((GComponent)this).GetChild("red");
		string id = "ui://k19peou7dnvl2a".Replace("ui://", "") + "-" + ((GObject)red).id;
		((GObject)red).text = LanguagesManager.GetDesc(id);
		green = (GTextField)((GComponent)this).GetChild("green");
		string id2 = "ui://k19peou7dnvl2a".Replace("ui://", "") + "-" + ((GObject)green).id;
		((GObject)green).text = LanguagesManager.GetDesc(id2);
		blue = (GTextField)((GComponent)this).GetChild("blue");
		string id3 = "ui://k19peou7dnvl2a".Replace("ui://", "") + "-" + ((GObject)blue).id;
		((GObject)blue).text = LanguagesManager.GetDesc(id3);
		yellow = (GTextField)((GComponent)this).GetChild("yellow");
		string id4 = "ui://k19peou7dnvl2a".Replace("ui://", "") + "-" + ((GObject)yellow).id;
		((GObject)yellow).text = LanguagesManager.GetDesc(id4);
		name_notchosen = (GGroup)((GComponent)this).GetChild("name-notchosen");
		red2 = (GTextField)((GComponent)this).GetChild("red2");
		string id5 = "ui://k19peou7dnvl2a".Replace("ui://", "") + "-" + ((GObject)red2).id;
		((GObject)red2).text = LanguagesManager.GetDesc(id5);
		green2 = (GTextField)((GComponent)this).GetChild("green2");
		string id6 = "ui://k19peou7dnvl2a".Replace("ui://", "") + "-" + ((GObject)green2).id;
		((GObject)green2).text = LanguagesManager.GetDesc(id6);
		blue2 = (GTextField)((GComponent)this).GetChild("blue2");
		string id7 = "ui://k19peou7dnvl2a".Replace("ui://", "") + "-" + ((GObject)blue2).id;
		((GObject)blue2).text = LanguagesManager.GetDesc(id7);
		yellow2 = (GTextField)((GComponent)this).GetChild("yellow2");
		string id8 = "ui://k19peou7dnvl2a".Replace("ui://", "") + "-" + ((GObject)yellow2).id;
		((GObject)yellow2).text = LanguagesManager.GetDesc(id8);
		name_chosen = (GGroup)((GComponent)this).GetChild("name-chosen");
	}
}
