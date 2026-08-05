using FairyGUI;
using FairyGUI.Utils;

namespace UI.PublicResources;

public class UI_MateriaNuml : GComponent
{
	public GGraph n3;

	public GTextField curNum;

	public GTextField sprit;

	public GTextField requireNum;

	public const string URL = "ui://kt6rg65onwjtlo";

	public static string Name = "UI_MateriaNuml";

	public static string GetURL()
	{
		return "ui://kt6rg65onwjtlo";
	}

	public static UI_MateriaNuml CreateInstance()
	{
		return (UI_MateriaNuml)(object)UIPackage.CreateObject("PublicResources", "MateriaNuml");
	}

	public static UI_MateriaNuml CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MateriaNuml).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65onwjtlo", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n3 = (GGraph)((GComponent)this).GetChild("n3");
		curNum = (GTextField)((GComponent)this).GetChild("curNum");
		sprit = (GTextField)((GComponent)this).GetChild("sprit");
		requireNum = (GTextField)((GComponent)this).GetChild("requireNum");
	}
}
