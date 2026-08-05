using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;

namespace UI.PublicResources;

public class UI_com_FormulaOem : GComponent
{
	public Controller showCount;

	public GLoader FormulaIcon;

	public UI_com_AmpAffectedRange AffectedRange;

	public GTextField FormulaCount;

	public const string URL = "ui://kt6rg65oj1h8v4sm";

	public static string Name = "UI_com_FormulaOem";

	public static string GetURL()
	{
		return "ui://kt6rg65oj1h8v4sm";
	}

	public static UI_com_FormulaOem CreateInstance()
	{
		return (UI_com_FormulaOem)(object)UIPackage.CreateObject("PublicResources", "com_FormulaOem");
	}

	public static UI_com_FormulaOem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaOem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kt6rg65oj1h8v4sm", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		showCount = ((GComponent)this).GetController("showCount");
		FormulaIcon = (GLoader)((GComponent)this).GetChild("FormulaIcon");
		AffectedRange = (UI_com_AmpAffectedRange)(object)((GComponent)this).GetChild("AffectedRange");
		FormulaCount = (GTextField)((GComponent)this).GetChild("FormulaCount");
	}

	public void Render(int ampIdx)
	{
		OemMissionAmplifier oemMissionAmplifier = OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(ampIdx);
		string reelItemId = oemMissionAmplifier.AmplifierFormulaModel.ReelItemId;
		FGUIManager.Instance.SetItemIconAndFrame(FormulaIcon, reelItemId, null, "", frameVisible: false);
		RenderHelper_AmpAffectedRange.RenderAmplifierAffectedSoldier((GComponent)(object)AffectedRange, ampIdx);
	}

	public void RenderWithItemId(string itemId, int count = -1)
	{
		FGUIManager.Instance.SetItemIconAndFrame(FormulaIcon, itemId, null, "", frameVisible: false);
		bool flag = count > 0;
		showCount.SetSelectedIndex(flag ? 1 : 0);
		if (flag)
		{
			((GObject)FormulaCount).text = $"x{count}";
		}
		((GObject)AffectedRange).visible = false;
	}
}
