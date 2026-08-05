using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_WaitOpenEternalNight : GComponent
{
	public Controller Step;

	public GImage back;

	public GRichTextField n1;

	public UI_btn_OpenEternalNight ContinueProgress;

	public GRichTextField n3;

	public const string URL = "ui://4eq8fgd2dsasaj";

	public static string Name = "UI_com_WaitOpenEternalNight";

	public static string GetURL()
	{
		return "ui://4eq8fgd2dsasaj";
	}

	public static UI_com_WaitOpenEternalNight CreateInstance()
	{
		return (UI_com_WaitOpenEternalNight)(object)UIPackage.CreateObject("GvGWorldMap3", "com_WaitOpenEternalNight");
	}

	public static UI_com_WaitOpenEternalNight CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_WaitOpenEternalNight).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2dsasaj", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Step = ((GComponent)this).GetController("Step");
		back = (GImage)((GComponent)this).GetChild("back");
		n1 = (GRichTextField)((GComponent)this).GetChild("n1");
		string id = "ui://4eq8fgd2dsasaj".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		ContinueProgress = (UI_btn_OpenEternalNight)(object)((GComponent)this).GetChild("ContinueProgress");
		n3 = (GRichTextField)((GComponent)this).GetChild("n3");
		string id2 = "ui://4eq8fgd2dsasaj".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id2);
	}
}
