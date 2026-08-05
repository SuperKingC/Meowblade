using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FairyGUI;
using FairyGUI.Utils;
using Shift.Legion.Common.Services;

namespace UI.GvGOuterTech;

public class UI_main_OutTechHelpPanel : GComponent, IUiController
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static EventCallback0 _003C_003E9__9_0;

		internal void _003CRegisterUiEventListeners_003Eb__9_0()
		{
			GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
		}
	}

	public GGraph Mask;

	public UI_com_OutTechHelpDialog Dialog;

	public Transition ShowDialog;

	public const string URL = "ui://th385mttrp3co7r";

	public static string Name = "UI_main_OutTechHelpPanel";

	public static string GetURL()
	{
		return "ui://th385mttrp3co7r";
	}

	public static UI_main_OutTechHelpPanel CreateInstance()
	{
		return (UI_main_OutTechHelpPanel)(object)UIPackage.CreateObject("GvGOuterTech", "main_OutTechHelpPanel");
	}

	public static UI_main_OutTechHelpPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_OutTechHelpPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://th385mttrp3co7r", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_com_OutTechHelpDialog)(object)((GComponent)this).GetChild("Dialog");
		ShowDialog = ((GComponent)this).GetTransition("ShowDialog");
	}

	public void RegisterUiEventListeners()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		EventListener onClick = ((GObject)Mask).onClick;
		object obj = _003C_003Ec._003C_003E9__9_0;
		if (obj == null)
		{
			EventCallback0 val = delegate
			{
				GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
			};
			_003C_003Ec._003C_003E9__9_0 = val;
			obj = (object)val;
		}
		onClick.Set((EventCallback0)obj);
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Mask).onClick.Clear();
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
	}

	public void OnShow()
	{
		ShowDialog.Play();
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
	}
}
