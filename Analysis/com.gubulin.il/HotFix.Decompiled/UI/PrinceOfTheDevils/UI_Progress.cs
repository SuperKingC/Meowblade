using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_Progress : GComponent
{
	public UI_progressBtn progressBar;

	public GGraph textSFXBack;

	public GTextField title;

	public GTextField num;

	public GGroup n4;

	public const string URL = "ui://zko5n3velkzgd";

	public static string Name = "UI_Progress";

	public static string GetURL()
	{
		return "ui://zko5n3velkzgd";
	}

	public static UI_Progress CreateInstance()
	{
		return (UI_Progress)(object)UIPackage.CreateObject("PrinceOfTheDevils", "Progress");
	}

	public static UI_Progress CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Progress).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3velkzgd", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		progressBar = (UI_progressBtn)(object)((GComponent)this).GetChild("progressBar");
		textSFXBack = (GGraph)((GComponent)this).GetChild("textSFXBack");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://zko5n3velkzgd".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		num = (GTextField)((GComponent)this).GetChild("num");
		string id2 = "ui://zko5n3velkzgd".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id2);
		n4 = (GGroup)((GComponent)this).GetChild("n4");
	}
}
