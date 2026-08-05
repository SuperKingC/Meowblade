using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_WorkerBubble : GComponent
{
	public GImage back;

	public GLoader icon;

	public GImage max;

	public UI_MateriaNuml MateriaNuml;

	public const string URL = "ui://kt6rg65onwjtlk";

	public static string Name = "UI_WorkerBubble";

	public static string GetURL()
	{
		return "ui://kt6rg65onwjtlk";
	}

	public static UI_WorkerBubble CreateInstance()
	{
		return (UI_WorkerBubble)(object)UIPackage.CreateObject("PublicResources", "WorkerBubble");
	}

	public static UI_WorkerBubble CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WorkerBubble).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65onwjtlk", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		max = (GImage)((GComponent)this).GetChild("max");
		MateriaNuml = (UI_MateriaNuml)(object)((GComponent)this).GetChild("MateriaNuml");
	}
}
