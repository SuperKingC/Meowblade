using System;
using System.Collections.Generic;
using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using HotFix.Sources.Base.Scripts.UI.LoadWebImage;
using Shift.Legion.ClientApi.RPC.Api;
using Shift.Legion.Common.Services;
using UnityEngine;

namespace UI.AccountInfo;

public class UI_DataBackUpPanel : GComponent, IUiController
{
	public enum DataBackUpPanelType
	{
		Optional,
		ForceDeletion
	}

	private class CredentialUiData
	{
		public int CredentialBtnTypeIndex { get; set; }

		public int UserId { get; set; }

		public int UserLevel { get; set; }
	}

	public GGraph Mask;

	public UI_DataBackUpDialog Dialog;

	public const string URL = "ui://b9yxt7u0k38947";

	public static string Name = "UI_DataBackUpPanel";

	private UserLoginCredentialsResult userLoginCredentials;

	private DataBackUpPanelType panelType;

	private LoadWebImageTaskQueue loadWebImageTaskQueue;

	public static string GetURL()
	{
		return "ui://b9yxt7u0k38947";
	}

	public static UI_DataBackUpPanel CreateInstance()
	{
		return (UI_DataBackUpPanel)(object)UIPackage.CreateObject("AccountInfo", "DataBackUpPanel");
	}

	public static UI_DataBackUpPanel CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DataBackUpPanel).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0k38947", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		Dialog = (UI_DataBackUpDialog)(object)((GComponent)this).GetChild("Dialog");
	}

	public void BeforeDestroy()
	{
	}

	public void Destroy()
	{
		FGUIManager.Instance.ReleaseGloaderTexture2D(Name);
	}

	public void Init(Dictionary<string, object> parameters)
	{
		FGUIManager.SetUiPanelSizeAndXy((GObject)(object)this);
		if (parameters.TryGetValue("DataBackUpPanelType", out var value))
		{
			panelType = (DataBackUpPanelType)value;
			ShowUserLoginCredentials();
		}
	}

	public void OnShow()
	{
	}

	public void RegisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Add(new EventCallback0(End));
	}

	public void UnregisterUiEventListeners()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		((GObject)Mask).onClick.Remove(new EventCallback0(End));
	}

	public void End()
	{
		GameController.Contexts.Service<IUiService>().ClosePanel(Name, reservePackageRes: true);
	}

	private async void ShowUserLoginCredentials()
	{
		userLoginCredentials = await UiHelper.GetUserCredentials();
		if (userLoginCredentials != null)
		{
			RenderMainDialog();
		}
	}

	private void RenderMainDialog()
	{
		if (panelType == DataBackUpPanelType.ForceDeletion)
		{
			Dialog.Type.selectedIndex = 2;
		}
		else
		{
			Dialog.Type.selectedIndex = ((userLoginCredentials.Infos.Count > 1) ? 1 : 0);
		}
		RenderAllArchives();
	}

	private void RenderAllArchives()
	{
		loadWebImageTaskQueue?.Clear();
		loadWebImageTaskQueue = new LoadWebImageTaskQueue();
		for (int i = 0; i < userLoginCredentials.Infos.Count; i++)
		{
			if (userLoginCredentials.Infos[i].UserId == userLoginCredentials.CurrentUserId)
			{
				if (((GComponent)Dialog.UserArchives).GetChildAt(0) is UI_BackUpData obj)
				{
					RenderUserArchive(userLoginCredentials.Infos[i], obj, 1);
					userLoginCredentials.Infos.RemoveAt(i);
				}
				break;
			}
		}
		for (int j = 0; j < 2; j++)
		{
			if (((GComponent)Dialog.UserArchives).GetChildAt(j + 1) is UI_BackUpData obj2)
			{
				if (j + 1 > userLoginCredentials.Infos.Count)
				{
					RenderUserArchive(null, obj2, 0);
					continue;
				}
				int btnTypeIndex = Dialog.Type.selectedIndex + 1;
				RenderUserArchive(userLoginCredentials.Infos[j], obj2, btnTypeIndex);
			}
		}
		loadWebImageTaskQueue?.Start();
	}

	private void RenderUserArchive(UserLoginCredentialsProto credentialsProto, UI_BackUpData obj, int btnTypeIndex)
	{
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		if (credentialsProto == null)
		{
			obj.Type.selectedIndex = 0;
			return;
		}
		Coroutine work = ((MonoBehaviour)FGUIManager.Instance).StartCoroutine(FGUIManager.Instance.GetImageByWebRequestAndStorage(Name, credentialsProto.UserId, obj.Avatar.HeadPortrait.icon, obj.UserName));
		loadWebImageTaskQueue?.AddTask(work);
		((GObject)obj.UserId).text = string.Format("({0}ID：{1})", LanguagesManager.GetDesc("CsharpCodeZhTcText95"), credentialsProto.UserId);
		((GObject)obj.UserLevel).text = (string.IsNullOrEmpty(credentialsProto.UserLevel) ? "0" : credentialsProto.UserLevel);
		((GObject)obj.UserName).text = credentialsProto.NickName;
		((GObject)obj.UserTotalCombatPower).text = (string.IsNullOrEmpty(credentialsProto.CurrentMaxLegionPower) ? "0" : credentialsProto.CurrentMaxLegionPower);
		((GObject)obj.UserWorkerNum).text = $"{credentialsProto.ManPowerValue.Stock}";
		((GObject)obj.UserGemNum).text = credentialsProto.GemValue.Stock.ShortNumberFormat() ?? "";
		((GObject)obj.UserMtgNum).text = $"{credentialsProto.MTGValue.Stock}";
		obj.Type.selectedIndex = btnTypeIndex;
		((GObject)obj).data = new CredentialUiData
		{
			CredentialBtnTypeIndex = btnTypeIndex,
			UserId = credentialsProto.UserId,
			UserLevel = int.Parse(((GObject)obj.UserLevel).text)
		};
		((GObject)obj).onClick.Set(new EventCallback1(CredentialBtnClick));
	}

	private void CredentialBtnClick(EventContext context)
	{
		UI_BackUpData _btn = (UI_BackUpData)(object)context.sender;
		object data = ((GObject)_btn).data;
		CredentialUiData credentialUiData = data as CredentialUiData;
		if (credentialUiData == null || credentialUiData.CredentialBtnTypeIndex == 0 || credentialUiData.CredentialBtnTypeIndex == 1)
		{
			return;
		}
		if (credentialUiData.CredentialBtnTypeIndex == 2)
		{
			Action confirmAction = delegate
			{
				UiHelper.ChangeUserArchive(credentialUiData.UserId);
			};
			UiHelper.ShowConfirmAndCancelDialog(UiHelper.ChangeUserArchiveTip, confirmAction, delegate
			{
			}, mirror: false);
			return;
		}
		Action updateCredentialsList = delegate
		{
			RenderUserArchive(null, _btn, 0);
			End();
		};
		Action deleteUserArchiveAction = delegate
		{
			UiHelper.DeleteUserArchive(credentialUiData.UserId, updateCredentialsList);
		};
		Action action = delegate
		{
			string message2 = string.Format(UiHelper.DeleteUserArchiveTip2, ((GObject)_btn.UserName).text, credentialUiData.UserId, credentialUiData.UserLevel);
			UiHelper.ShowConfirmAndCancelDialog(message2, deleteUserArchiveAction, delegate
			{
			}, mirror: false);
		};
		string message = string.Format(UiHelper.DeleteUserArchiveTip, ((GObject)_btn.UserName).text, credentialUiData.UserId, credentialUiData.UserLevel);
		UiHelper.ShowConfirmAndCancelDialog(message, deleteUserArchiveAction, delegate
		{
		}, mirror: false);
	}
}
