using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_MissionBonusSlot : GComponent
{
	public Controller StateController;

	public GImage n10;

	public GGraph n19;

	public GTextField Title;

	public GTextField Desc;

	public UI_Avatar Avatar;

	public GList BonusList;

	public GImage n22;

	public GTextField Title_2;

	public const string URL = "ui://0i520nzmfjbqo91";

	public static string Name = "UI_MissionBonusSlot";

	public static string GetURL()
	{
		return "ui://0i520nzmfjbqo91";
	}

	public static UI_MissionBonusSlot CreateInstance()
	{
		return (UI_MissionBonusSlot)(object)UIPackage.CreateObject("LordOfDreams", "MissionBonusSlot");
	}

	public static UI_MissionBonusSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MissionBonusSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmfjbqo91", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StateController = ((GComponent)this).GetController("StateController");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n19 = (GGraph)((GComponent)this).GetChild("n19");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://0i520nzmfjbqo91".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		string id2 = "ui://0i520nzmfjbqo91".Replace("ui://", "") + "-" + ((GObject)Desc).id;
		((GObject)Desc).text = LanguagesManager.GetDesc(id2);
		Avatar = (UI_Avatar)(object)((GComponent)this).GetChild("Avatar");
		BonusList = (GList)((GComponent)this).GetChild("BonusList");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		Title_2 = (GTextField)((GComponent)this).GetChild("Title");
		string id3 = "ui://0i520nzmfjbqo91".Replace("ui://", "") + "-" + ((GObject)Title_2).id;
		((GObject)Title_2).text = LanguagesManager.GetDesc(id3);
	}
}
