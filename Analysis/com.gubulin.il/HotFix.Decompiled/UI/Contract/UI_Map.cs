using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_Map : GComponent
{
	public UI_point target0;

	public UI_point target1;

	public UI_point target2;

	public UI_point target3;

	public UI_point target4;

	public UI_point target5;

	public UI_point target6;

	public UI_point target7;

	public UI_point target8;

	public UI_point target9;

	public UI_point target10;

	public UI_point target11;

	public UI_point target12;

	public UI_point target13;

	public UI_point target14;

	public UI_point target15;

	public UI_point target16;

	public UI_point target17;

	public UI_point target18;

	public UI_point target19;

	public UI_point target20;

	public UI_point target21;

	public UI_point target22;

	public UI_point target23;

	public UI_point target24;

	public UI_point target25;

	public UI_point target26;

	public UI_point target27;

	public UI_point target28;

	public UI_point target29;

	public UI_point target30;

	public UI_point target31;

	public UI_point target32;

	public UI_point target33;

	public UI_point target34;

	public UI_point target35;

	public UI_point target36;

	public UI_point target37;

	public UI_point target38;

	public UI_point target39;

	public const string URL = "ui://avplaivdkpq618";

	public static string Name = "UI_Map";

	public static string GetURL()
	{
		return "ui://avplaivdkpq618";
	}

	public static UI_Map CreateInstance()
	{
		return (UI_Map)(object)UIPackage.CreateObject("Contract", "Map");
	}

	public static UI_Map CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Map).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdkpq618", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		((GComponent)this).ConstructFromXML(xml);
		target0 = (UI_point)(object)((GComponent)this).GetChild("target0");
		target1 = (UI_point)(object)((GComponent)this).GetChild("target1");
		target2 = (UI_point)(object)((GComponent)this).GetChild("target2");
		target3 = (UI_point)(object)((GComponent)this).GetChild("target3");
		target4 = (UI_point)(object)((GComponent)this).GetChild("target4");
		target5 = (UI_point)(object)((GComponent)this).GetChild("target5");
		target6 = (UI_point)(object)((GComponent)this).GetChild("target6");
		target7 = (UI_point)(object)((GComponent)this).GetChild("target7");
		target8 = (UI_point)(object)((GComponent)this).GetChild("target8");
		target9 = (UI_point)(object)((GComponent)this).GetChild("target9");
		target10 = (UI_point)(object)((GComponent)this).GetChild("target10");
		target11 = (UI_point)(object)((GComponent)this).GetChild("target11");
		target12 = (UI_point)(object)((GComponent)this).GetChild("target12");
		target13 = (UI_point)(object)((GComponent)this).GetChild("target13");
		target14 = (UI_point)(object)((GComponent)this).GetChild("target14");
		target15 = (UI_point)(object)((GComponent)this).GetChild("target15");
		target16 = (UI_point)(object)((GComponent)this).GetChild("target16");
		target17 = (UI_point)(object)((GComponent)this).GetChild("target17");
		target18 = (UI_point)(object)((GComponent)this).GetChild("target18");
		target19 = (UI_point)(object)((GComponent)this).GetChild("target19");
		target20 = (UI_point)(object)((GComponent)this).GetChild("target20");
		target21 = (UI_point)(object)((GComponent)this).GetChild("target21");
		target22 = (UI_point)(object)((GComponent)this).GetChild("target22");
		target23 = (UI_point)(object)((GComponent)this).GetChild("target23");
		target24 = (UI_point)(object)((GComponent)this).GetChild("target24");
		target25 = (UI_point)(object)((GComponent)this).GetChild("target25");
		target26 = (UI_point)(object)((GComponent)this).GetChild("target26");
		target27 = (UI_point)(object)((GComponent)this).GetChild("target27");
		target28 = (UI_point)(object)((GComponent)this).GetChild("target28");
		target29 = (UI_point)(object)((GComponent)this).GetChild("target29");
		target30 = (UI_point)(object)((GComponent)this).GetChild("target30");
		target31 = (UI_point)(object)((GComponent)this).GetChild("target31");
		target32 = (UI_point)(object)((GComponent)this).GetChild("target32");
		target33 = (UI_point)(object)((GComponent)this).GetChild("target33");
		target34 = (UI_point)(object)((GComponent)this).GetChild("target34");
		target35 = (UI_point)(object)((GComponent)this).GetChild("target35");
		target36 = (UI_point)(object)((GComponent)this).GetChild("target36");
		target37 = (UI_point)(object)((GComponent)this).GetChild("target37");
		target38 = (UI_point)(object)((GComponent)this).GetChild("target38");
		target39 = (UI_point)(object)((GComponent)this).GetChild("target39");
	}
}
