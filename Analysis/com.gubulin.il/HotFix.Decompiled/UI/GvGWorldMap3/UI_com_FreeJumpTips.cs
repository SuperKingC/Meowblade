using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_FreeJumpTips : GComponent
{
	public GTextField Free;

	public GButton JumpBuff;

	public const string URL = "ui://4eq8fgd2v6f59s";

	public static string Name = "UI_com_FreeJumpTips";

	public static string GetURL()
	{
		return "ui://4eq8fgd2v6f59s";
	}

	public static UI_com_FreeJumpTips CreateInstance()
	{
		return (UI_com_FreeJumpTips)(object)UIPackage.CreateObject("GvGWorldMap3", "com_FreeJumpTips");
	}

	public static UI_com_FreeJumpTips CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FreeJumpTips).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2v6f59s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Free = (GTextField)((GComponent)this).GetChild("Free");
		string id = "ui://4eq8fgd2v6f59s".Replace("ui://", "") + "-" + ((GObject)Free).id;
		((GObject)Free).text = LanguagesManager.GetDesc(id);
		JumpBuff = (GButton)((GComponent)this).GetChild("JumpBuff");
	}
}
