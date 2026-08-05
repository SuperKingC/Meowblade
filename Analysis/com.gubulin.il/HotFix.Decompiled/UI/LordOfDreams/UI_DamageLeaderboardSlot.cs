using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_DamageLeaderboardSlot : GComponent
{
	public Controller TypeController;

	public UI_Avatar Avatar;

	public GLoader n1;

	public GLoader n2;

	public GLoader n3;

	public GTextField PlayerName;

	public GTextField n5;

	public GTextField DamageText;

	public GTextField Ranking;

	public const string URL = "ui://0i520nzm121eo4h";

	public static string Name = "UI_DamageLeaderboardSlot";

	public static string GetURL()
	{
		return "ui://0i520nzm121eo4h";
	}

	public static UI_DamageLeaderboardSlot CreateInstance()
	{
		return (UI_DamageLeaderboardSlot)(object)UIPackage.CreateObject("LordOfDreams", "DamageLeaderboardSlot");
	}

	public static UI_DamageLeaderboardSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DamageLeaderboardSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzm121eo4h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		TypeController = ((GComponent)this).GetController("TypeController");
		Avatar = (UI_Avatar)(object)((GComponent)this).GetChild("Avatar");
		n1 = (GLoader)((GComponent)this).GetChild("n1");
		n2 = (GLoader)((GComponent)this).GetChild("n2");
		n3 = (GLoader)((GComponent)this).GetChild("n3");
		PlayerName = (GTextField)((GComponent)this).GetChild("PlayerName");
		string id = "ui://0i520nzm121eo4h".Replace("ui://", "") + "-" + ((GObject)PlayerName).id;
		((GObject)PlayerName).text = LanguagesManager.GetDesc(id);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id2 = "ui://0i520nzm121eo4h".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
		DamageText = (GTextField)((GComponent)this).GetChild("DamageText");
		string id3 = "ui://0i520nzm121eo4h".Replace("ui://", "") + "-" + ((GObject)DamageText).id;
		((GObject)DamageText).text = LanguagesManager.GetDesc(id3);
		Ranking = (GTextField)((GComponent)this).GetChild("Ranking");
	}
}
