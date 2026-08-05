using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_CampScoreSlot : GComponent
{
	public Controller CampId;

	public GImage n0;

	public GLoader n2;

	public GTextField Score;

	public GTextField n5;

	public GGroup n6;

	public const string URL = "ui://hd2s9kukbrpp4q";

	public static string Name = "UI_CampScoreSlot";

	public static string GetURL()
	{
		return "ui://hd2s9kukbrpp4q";
	}

	public static UI_CampScoreSlot CreateInstance()
	{
		return (UI_CampScoreSlot)(object)UIPackage.CreateObject("GvGWorldMap2", "CampScoreSlot");
	}

	public static UI_CampScoreSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_CampScoreSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukbrpp4q", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		CampId = ((GComponent)this).GetController("CampId");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n2 = (GLoader)((GComponent)this).GetChild("n2");
		Score = (GTextField)((GComponent)this).GetChild("Score");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://hd2s9kukbrpp4q".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
		n6 = (GGroup)((GComponent)this).GetChild("n6");
	}
}
