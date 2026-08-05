using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_MeleeStore : GButton
{
	public Controller button;

	public GImage n3;

	public GTextField n5;

	public const string URL = "ui://4eq8fgd2bqhp1o";

	public static string Name = "UI_btn_MeleeStore";

	public static string GetURL()
	{
		return "ui://4eq8fgd2bqhp1o";
	}

	public static UI_btn_MeleeStore CreateInstance()
	{
		return (UI_btn_MeleeStore)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_MeleeStore");
	}

	public static UI_btn_MeleeStore CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_MeleeStore).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2bqhp1o", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://4eq8fgd2bqhp1o".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}
