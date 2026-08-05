using System.Collections.Generic;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model.OuterTech;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using Shift.Legion.GvGServer.Models.GvGMode3IslandManagerSocket.OuterTech;

namespace UI.GvGWorldMap3;

public class UI_main_GreenChannelConfirmPanel : GComponent, IUiController
{
	public GGraph back;

	public UI_com_GreenChannelConfirmDialog Dialog;

	public const string URL = "ui://4eq8fgd2d0fus9u";

	public static string Name = "UI_main_GreenChannelConfirmPanel";

	public static string GetURL()
	{
		return "ui://4eq8fgd2d0fus9u";
	}

	public static UI_main_GreenChannelConfirmPanel CreateInstance()
	{
		return (UI_main_GreenChannelConfirmPanel)(object)UIPackage.CreateObject("GvGWorldMap3", "main_GreenChannelConfirmPanel");
	}

	public static UI_main_GreenChannelConfirmPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_main_GreenChannelConfirmPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2d0fus9u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GGraph)((GComponent)this).GetChild("back");
		Dialog = (UI_com_GreenChannelConfirmDialog)(object)((GComponent)this).GetChild("Dialog");
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this, scaleAdaption: true);
		int 绿色通道MaxUseTime = OuterTechHelper.Get_绿色通道MaxUseTime();
		int o绿色通道_LimitTime = OuterTechHelper.GetTechState().o绿色通道_LimitTime;
		string arg = ((o绿色通道_LimitTime > 0) ? "#009900" : "#990000");
		((GObject)Dialog.Count).text = $"[color={arg}]{o绿色通道_LimitTime}[/color]/{绿色通道MaxUseTime}";
		((GObject)Dialog.ConfirmBtn).enabled = o绿色通道_LimitTime > 0;
	}

	public void RegisterUiEventListeners()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		((GObject)Dialog.ConfirmBtn).onClick.Set(new EventCallback0(OnClickConfirm));
		((GObject)Dialog.CancelBtn).onClick.Set(new EventCallback0(End));
		((GObject)Dialog.back).onClick.Set(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		((GObject)Dialog.ConfirmBtn).onClick.Clear();
		((GObject)Dialog.CancelBtn).onClick.Clear();
		((GObject)Dialog.back).onClick.Clear();
	}

	private void OnClickConfirm()
	{
		SocketManager.Instance.GetConnection(eConType.GvGMode3IslandManager).Request(new C2S_OuterTech_UseGreenWay
		{
			Req = new C2S_OuterTech_UseGreenWay.Request()
		}, delegate(SocketManager.BaseSocketPackageBodyContext contextResponse)
		{
			C2S_OuterTech_UseGreenWay.Response response = (C2S_OuterTech_UseGreenWay.Response)contextResponse.Resp;
			if (response.ErrorCode != 0)
			{
				ILRequestHelper.ShowErrorCode(response.ErrorCode);
			}
			else
			{
				OuterTechHelper.GetTechState().o绿色通道_LimitTime = response.LimitTime;
				OuterTechHelper.GetTechState().o绿色通道_EndTime = response.EndTime;
				End();
			}
		});
	}

	private static void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	public void OnShow()
	{
	}

	public void Destroy()
	{
	}

	public void BeforeDestroy()
	{
	}
}
