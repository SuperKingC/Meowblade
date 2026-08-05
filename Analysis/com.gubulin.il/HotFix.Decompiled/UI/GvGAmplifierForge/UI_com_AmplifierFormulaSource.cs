using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Helper;
using Shift.Legion.Common.Models;

namespace UI.GvGAmplifierForge;

public class UI_com_AmplifierFormulaSource : GComponent
{
	public GImage n0;

	public GTextField n1;

	public GList AmplifiersSource;

	public const string URL = "ui://fpjheycbqvpvv4g4";

	public static string Name = "UI_com_AmplifierFormulaSource";

	public static string GetURL()
	{
		return "ui://fpjheycbqvpvv4g4";
	}

	public static UI_com_AmplifierFormulaSource CreateInstance()
	{
		return (UI_com_AmplifierFormulaSource)(object)UIPackage.CreateObject("GvGAmplifierForge", "com_AmplifierFormulaSource");
	}

	public static UI_com_AmplifierFormulaSource CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AmplifierFormulaSource).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fpjheycbqvpvv4g4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://fpjheycbqvpvv4g4".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		AmplifiersSource = (GList)((GComponent)this).GetChild("AmplifiersSource");
	}

	public void Render()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		AmplifiersSource.itemRenderer = new ListItemRenderer(RenderBtn);
		AmplifiersSource.numItems = AmpConfigHelper.Configs.AmplifierJumpData_List.Count;
		static void RenderBtn(int index, GObject obj)
		{
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Expected O, but got Unknown
			UI_btn_AmplifierFormulaSource btn = obj as UI_btn_AmplifierFormulaSource;
			GvGAmplifierSourceJumpData jumpData;
			if (btn == null)
			{
				ILRuntimeDebug.LogError("UI_com_AmplifierFormulaSource.RenderBtn:obj is not UI_btn_AmplifierFormulaSource");
			}
			else
			{
				jumpData = AmpConfigHelper.Configs.AmplifierJumpData_List[index];
				((GObject)btn.Source).text = jumpData.SourceText;
				btn.GotoBtnDisplaying.SetSelectedIndex(jumpData.ShowJumpBtn ? 1 : 0);
				((GObject)btn).onClick.Set(new EventCallback0(Goto));
			}
			void Goto()
			{
				if (btn.GotoBtnDisplaying.selectedIndex != 0)
				{
					jumpData.GoToRelativeUi();
				}
			}
		}
	}
}
