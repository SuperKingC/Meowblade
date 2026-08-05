using System.Text.RegularExpressions;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;

namespace UI.GvGExchange3;

public class UI_com_FormulaName : GComponent
{
	public Controller Rarity;

	public GTextField FormulaName;

	public const string URL = "ui://tt2iq07oxxgp55";

	public static string Name = "UI_com_FormulaName";

	public static string GetURL()
	{
		return "ui://tt2iq07oxxgp55";
	}

	public static UI_com_FormulaName CreateInstance()
	{
		return (UI_com_FormulaName)(object)UIPackage.CreateObject("GvGExchange3", "com_FormulaName");
	}

	public static UI_com_FormulaName CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FormulaName).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07oxxgp55", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Rarity = ((GComponent)this).GetController("Rarity");
		FormulaName = (GTextField)((GComponent)this).GetChild("FormulaName");
	}

	public void Render(int ampIdx, bool newLine = true)
	{
		OemMissionAmplifier oemMissionAmplifier = OemMissionAmplifierConfigHelper.GetOemMissionAmplifier(ampIdx);
		string reelItemId = oemMissionAmplifier.AmplifierFormulaModel.ReelItemId;
		string text = Item.Name(GameManagers.Instance, reelItemId);
		((GObject)FormulaName).text = (newLine ? text : Regex.Replace(text, "\\r?\\n", string.Empty));
		Rarity.SetSelectedIndex(Item.Rarity(reelItemId));
	}
}
