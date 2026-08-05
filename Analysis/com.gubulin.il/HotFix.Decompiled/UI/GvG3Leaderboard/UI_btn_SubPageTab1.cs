using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Leaderboard;

public class UI_btn_SubPageTab1 : GButton
{
	public Controller button;

	public GImage n159;

	public GTextField n160;

	public GTextField Date;

	public GGroup n162;

	public GImage n158;

	public const string URL = "ui://ylvfgf90uya75i";

	public static string Name = "UI_btn_SubPageTab1";

	public static string GetURL()
	{
		return "ui://ylvfgf90uya75i";
	}

	public static UI_btn_SubPageTab1 CreateInstance()
	{
		return (UI_btn_SubPageTab1)(object)UIPackage.CreateObject("GvG3Leaderboard", "btn_SubPageTab1");
	}

	public static UI_btn_SubPageTab1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SubPageTab1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ylvfgf90uya75i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n159 = (GImage)((GComponent)this).GetChild("n159");
		n160 = (GTextField)((GComponent)this).GetChild("n160");
		string id = "ui://ylvfgf90uya75i".Replace("ui://", "") + "-" + ((GObject)n160).id;
		((GObject)n160).text = LanguagesManager.GetDesc(id);
		Date = (GTextField)((GComponent)this).GetChild("Date");
		n162 = (GGroup)((GComponent)this).GetChild("n162");
		n158 = (GImage)((GComponent)this).GetChild("n158");
	}
}
