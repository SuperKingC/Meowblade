using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;
using Assets.Scripts.UI;
using FairyGUI;
using HotFix.Sources.Base.Scripts.AdReport;
using HotFix.Sources.Base.Scripts.Managers;
using HotFix.Sources.Base.Scripts.UserTrack;
using HotFix.Sources.Base.Scripts.Utils;
using HotFix.Sources.ThirdParty.SDKs.Android;
using ILRuntime.Runtime;
using RSG;
using Shift.Legion.ClientApi;
using Shift.Legion.ClientApi.Sources.Extensions;
using Shift.Legion.Common.Enums;
using Shift.Legion.Common.Helpers;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Models;
using Shift.Legion.Common.Services;
using Shift.Legion.Helpers;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.UI;

namespace HotFix;

public class HotUpdateProcess : MonoBehaviour
{
	public class ForceUpdateConfig
	{
		public string Name { get; set; }

		public string Tip { get; set; }

		public string UpdateAddress { get; set; }

		public string Version { get; set; }

		public bool ForceUpdate { get; set; }

		public string Type { get; set; }

		public int Size { get; set; }

		public string Date { get; set; }
	}

	private class CheckDllResult
	{
		private bool _isDllSame;

		public string server_hotfixdll_md5;

		public string local_hotfixdll_md5;

		public bool isValid => !string.IsNullOrEmpty(server_hotfixdll_md5);

		public bool isDllSame
		{
			get
			{
				if (string.IsNullOrEmpty(local_hotfixdll_md5) || string.IsNullOrEmpty(server_hotfixdll_md5))
				{
					_isDllSame = false;
				}
				_isDllSame = server_hotfixdll_md5.Equals(local_hotfixdll_md5);
				return _isDllSame;
			}
		}
	}

	private class CheckVersionResult
	{
		private bool _isSame;

		public string server_version_md5;

		public string local_version_md5;

		public string server_version_content;

		private Dictionary<string, HotUpdateFileInfo> _server_version_list;

		public string local_version_content;

		private Dictionary<string, HotUpdateFileInfo> _local_version_list;

		public long TotalBytes;

		public List<HotUpdateFileInfo> WaitToUpdate;

		public bool isSame
		{
			get
			{
				if (string.IsNullOrEmpty(server_version_md5) || string.IsNullOrEmpty(local_version_md5))
				{
					_isSame = false;
				}
				_isSame = server_version_md5.Equals(local_version_md5);
				return _isSame;
			}
		}

		public Dictionary<string, HotUpdateFileInfo> server_version_list
		{
			get
			{
				if (_server_version_list == null)
				{
					_server_version_list = HotFix_Utils.ParseVersionString(server_version_content);
				}
				return _server_version_list;
			}
		}

		public Dictionary<string, HotUpdateFileInfo> local_version_list
		{
			get
			{
				if (_local_version_list == null)
				{
					_local_version_list = HotFix_Utils.ParseVersionString(local_version_content);
				}
				return _local_version_list;
			}
		}

		public CheckVersionResult()
		{
			WaitToUpdate = new List<HotUpdateFileInfo>();
			TotalBytes = 0L;
			_server_version_list = null;
			_local_version_list = null;
		}

		public void AddWaitToUpdate(HotUpdateFileInfo _f)
		{
			if (WaitToUpdate == null)
			{
				WaitToUpdate = new List<HotUpdateFileInfo>();
			}
			WaitToUpdate.Add(_f);
			TotalBytes += _f.size;
		}
	}

	public static HotUpdateProcess Instance;

	public static bool Has_Fake_Story0011_BattleId = false;

	public static bool Loaded_Fake_Story0011_BattleId = false;

	public const string Fake_Story0011_BattleId = "5be0b7bd-9eb6-4da8-9c63-e5552527e890";

	public bool IsOffline = false;

	public bool IsFguiCameraChanged;

	public Dictionary<string, string> Configs;

	public const string UserAgent = "pro";

	public static string GatewayHeader = "";

	public static string GatewayCost = "";

	public static string UserSource = "";

	public static List<string> RegionUrls = new List<string>();

	public static string ChannelCode = "";

	public static string OriginChannelCode = "";

	public static bool HasPreloadBeforeUnity = false;

	public static string LanguageKey = "";

	public static string ZoneKey = "";

	public static bool RPCRecord = false;

	public RegionFileModel RegionModel = null;

	public Intl_ChannelConfig ChannelConfig = null;

	private const string UI_BG = "pic_login_bg_3.jpg";

	private const string UI_BACK_BG = "back_2.png";

	private const string UI_POP_BG = "frame_popup_black1.png";

	private const string UI_BTN_CONFIRM = "button_green1.png";

	private const string UI_BTN_CONFIRM_ZH_TC = "button_green1_zh_tc.png";

	private const string UI_BTN_CONFIRM_ENG = "button_green3_eng.png";

	private const string UI_BAR = "green_bar.png";

	private const string UI_BAR_BG = "bar_bg.png";

	private static List<string> config_urls;

	private static List<string> UI_URL_Backups;

	private const string TipTextJsonName = "HotUpdateProcessText";

	private Dictionary<string, string> TipText;

	private bool BestGatewayFound;

	private GameObject go_Canvas;

	private GameObject go_MainCamera;

	private Vector2 CanvasSize;

	private int URL_RANDOM_STAMP;

	public string DllMd5;

	private Font default_font;

	private float loginPrefabScale = 1f;

	private string BestRegionURL;

	private Dictionary<string, string> Log_FindRegionURL;

	private List<string> RegionURLResult;

	private const int PING_COUNT = 4;

	private const float PING_TIME_OUT = 3f;

	private Dictionary<string, float> PingResult;

	public GameObject Go_BarBg;

	public GameObject Go_Bar;

	public GameObject Go_BarText;

	private const string Android_ActivateFlagKey = "Android_NewActivateFlag";

	private const string iOS_ActivateFlagKey = "iOS_NewActivateFlag2";

	private const string iOS_OceanEngine_ActivateFlagKey = "iOS_OceanEngine_ActivateFlag";

	public bool IsRegionOutCN => RegionKey != "cn";

	public bool IsNewHotUpdateProcess
	{
		get
		{
			if (Configs.TryGetValue("NewHotUpdateProcess", out var value))
			{
				return value == "1";
			}
			return false;
		}
	}

	public static string SIndex => MsgSecurityClient.SIndex;

	public static string RegionKey { get; set; } = "";

	public string FeedBackUrl
	{
		get
		{
			string key = "FeedbackUrl";
			if (Configs.ContainsKey(key))
			{
				return Configs[key];
			}
			return "https://bbs-pre.gooplin.com/";
		}
	}

	public bool NeedChooseServerLocation()
	{
		if (!IsRegionOutCN)
		{
			return false;
		}
		if (RegionKey == "hmt")
		{
			ZoneKey = "hmt";
			return false;
		}
		if (RegionKey == "sea")
		{
			ZoneKey = "sea";
			return false;
		}
		return string.IsNullOrEmpty(ZoneKey);
	}

	public bool NeedChooseLanguage()
	{
		return false;
	}

	public string GetDefaultLanguage()
	{
		string regionKey = RegionKey;
		string text = regionKey;
		if (text == "hmt" || text == "sea")
		{
			return "zh_tc";
		}
		return "zh";
	}

	private void Awake()
	{
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0561: Unknown result type (might be due to invalid IL or missing references)
		//IL_0567: Invalid comparison between Unknown and I4
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		ChannelCode = HotFixManager.Instance.GetChannelCode().Replace("#ChannelCode#", "");
		OriginChannelCode = ChannelCode;
		if (ChannelCode.Equals("tapplay"))
		{
			HasPreloadBeforeUnity = true;
		}
		else if (ChannelCode.Equals("taptapprivacyreview"))
		{
			HasPreloadBeforeUnity = true;
			ChannelCode = "taptap";
		}
		else if (ChannelCode.Equals("toutiao-android"))
		{
			HasPreloadBeforeUnity = true;
		}
		else if (ChannelCode.Equals("gdt-android"))
		{
			HasPreloadBeforeUnity = true;
		}
		RegionKey = HotFixManager.Instance.GetRegionKey().Replace("#RegionKey#", "cn");
		if (string.IsNullOrEmpty(RegionKey))
		{
			ILRuntimeDebug.LogError("RegionKey is Empty, Set Default Value cn");
			RegionKey = "cn";
		}
		HotFixManager.Instance.SetDefaultThreadCurrentCulture();
		FieldInfo field = typeof(DynamicFont).GetField("OffSetFactor", BindingFlags.Static | BindingFlags.Public);
		if (field != null)
		{
			field.SetValue(null, 0f);
		}
		string text = HotFixManager.Instance.GetLanguageKey().Replace("#LanguageKey#", GetDefaultLanguage());
		string text2 = GameLocalDataManager.GetLanguagePrefer();
		if (string.IsNullOrEmpty(text2))
		{
			text2 = text;
		}
		LanguageKey = text2;
		string zonePrefer = GameLocalDataManager.GetZonePrefer();
		if (!string.IsNullOrEmpty(zonePrefer))
		{
			ZoneKey = zonePrefer;
		}
		RegionUrls = HotFixManager.Instance.GetRegionUrl().Replace("#RegionUrl#", "").Split(',')
			.ToList();
		GameObject val = GameObject.Find("ShareSDKManager");
		if ((Object)(object)val != (Object)null)
		{
			Object.Destroy((Object)(object)val.gameObject);
		}
		Screen.sleepTimeout = -1;
		Instance = this;
		Configs = new Dictionary<string, string>();
		BestGatewayFound = false;
		VersionManager.LegendItemSwitch = true;
		VersionManager.LegendItemDrawSwitch = true;
		URL_RANDOM_STAMP = Random.Range(1, 10000);
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = 1.7777778f;
		CanvasSize = default(Vector2);
		if (num >= num2)
		{
			CanvasSize.y = Screen.height;
			CanvasSize.x = 1920f * (float)Screen.height / 1080f;
		}
		else
		{
			CanvasSize.x = Screen.width;
			CanvasSize.y = (float)Screen.width / 1.7777778f;
		}
		go_MainCamera = GameObject.Find("Main Camera");
		((Object)go_MainCamera).name = "MainCamera";
		Camera component = go_MainCamera.GetComponent<Camera>();
		component.orthographic = true;
		component.orthographicSize = Mathf.Max(CanvasSize.y, (float)Screen.height) / 2f;
		((Component)component).transform.position = Vector3.zero;
		component.nearClipPlane = -100f;
		component.farClipPlane = 500f;
		component.depth = 2f;
		go_Canvas = GameObject.Find("Canvas");
		go_Canvas.transform.localScale = Vector2.op_Implicit(new Vector2(CanvasSize.x / 1920f, CanvasSize.y / 1080f));
		Canvas component2 = go_Canvas.GetComponent<Canvas>();
		component2.renderMode = (RenderMode)2;
		component2.worldCamera = component;
		go_Canvas.transform.position = Vector2.op_Implicit(Vector2.zero);
		string text3 = "LoginPrefab";
		Transform val2 = ((Component)component).transform.Find("LoginPrefab");
		if ((Object)(object)val2 == (Object)null)
		{
			IList<IResourceLocation> list = Addressables.LoadResourceLocationsAsync((object)text3, (Type)null).WaitForCompletion();
			if (list != null && list.Count > 0)
			{
				GameObject val3 = Addressables.InstantiateAsync((object)text3, (Transform)null, false, true).WaitForCompletion();
				((Object)val3).name = text3;
				val2 = val3.transform;
				val2.SetParent(((Component)component).transform);
			}
		}
		if ((Object)(object)val2 != (Object)null)
		{
			((Component)val2).gameObject.SetActive(true);
			((Component)go_Canvas.transform.Find("Image")).gameObject.SetActive(false);
			loginPrefabScale = component.orthographicSize / 5.4f;
			val2.localScale = Vector3.one * loginPrefabScale;
			val2.localPosition = new Vector3(0f, 0f, 1f);
			ParticleSystem[] componentsInChildren = ((Component)val2).GetComponentsInChildren<ParticleSystem>(true);
			ParticleSystem[] array = componentsInChildren;
			foreach (ParticleSystem val4 in array)
			{
				MainModule main = val4.main;
				((MainModule)(ref main)).gravityModifierMultiplier = ((MainModule)(ref main)).gravityModifierMultiplier * loginPrefabScale;
			}
		}
		RectTransform component3 = go_Canvas.GetComponent<RectTransform>();
		component3.sizeDelta = new Vector2(1920f, 1080f);
		default_font = Resources.Load<Font>("Fonts/SourceHanSansCN Heavy");
		if ((int)Application.platform == 0 || (int)Application.platform == 7)
		{
			RegionKey = "cn";
			RegionUrls.Clear();
			string item = ((!IsRegionOutCN) ? "https://static.gubulin.com/s" : "https://static.gooplin.com/s");
			RegionUrls.Add(item);
			Configs = new Dictionary<string, string>
			{
				{ "ML", "1" },
				{ "SCP", "0" },
				{ "SF21", "1" },
				{ "RC", "1" },
				{ "PatP", "1" },
				{ "FriP", "1" },
				{ "RFB", "1" },
				{ "SDFB", "1" },
				{ "IC", "1" },
				{ "QTE_FILTER", "1" },
				{ "PvpEntrance", "1" },
				{ "SpecialActivities", "GQ001,GQ002,GQ003,XS001,OrcTaskActivity" },
				{ "CustomerServiceOnline", "1" },
				{ "NewGuideMode", "New6" },
				{ "StoryNodeConfigVersion", "StoryLineNodeVersionV6" },
				{ "VideoUrl", "https://il-res.gubulin.com/video/" },
				{ "ClientUpgradeUrl", "https://il-res.gubulin.com/apk/IdeLegion-release-1.6.3-3531.43985-gubulin-android-8c2d2407578e10d787e999c3d01c3090.apk" },
				{ "GvGMode3Log", "https://skyisland.gubulin.com" },
				{ "ReplayStuckProcessEnabled", "1" },
				{ "PanelProfiler", "1" },
				{ "GatewayInfo", "il-pre.gubulin.com" },
				{ "SocketHost", "106.75.240.171" },
				{ "AuthServerUrl", "https://{0}/api/user/" },
				{ "GameServerUrl", "https://{0}/api/game/" },
				{ "BattleReplayServerUrl", "https://il-pre.gubulin.com/api/game_br/" },
				{ "BattleReplayDownloadUrl", "https://il-res.gubulin.com/il_preview_replays/" },
				{ "ResUrl", "http://il-res.gubulin.com/assets/17197_17200/" },
				{ "BackupResUrl", "http://il-res.gubulin.com/assets/17197_17200/" },
				{ "HotFixUrl", "http://files.test.honestwalker.com/legion/" },
				{ "BackupHotFixUrl", "http://files.test.honestwalker.com/legion/" },
				{ "UserAgent", "IL/1.3.5.98 (0; c:01234567890123456789012345678901; r:)" },
				{ "FeedbackUrl", "https://bbs-pre.gooplin.com/" },
				{ "Intl", "0" },
				{ "ClickSimulatorEnabled", "1" },
				{ "ShowFrameRateSwitch", "0" },
				{ "DebugStats", "0" }
			};
			if (IsRegionOutCN)
			{
				RegionKey = "sea";
				ZoneKey = "sea";
				ChannelCode = "TapIntl";
				LanguageKey = "zh";
				RegionModel = new RegionFileModel
				{
					Zone = new Intl_RegionConfig
					{
						code = "sea",
						name = "东南亚",
						currency = "USD",
						url = new Intl_URLConfig
						{
							domain = "gooplin.com",
							help = "https://m.gooplin.com/help.html",
							config = new List<string> { "https://static.gooplin.com/s" },
							res = new List<string> { "https://il-res.gooplin.com" }
						},
						channel = new Dictionary<string, Intl_ChannelConfig> { 
						{
							"TapIntl",
							new Intl_ChannelConfig
							{
								login = new List<Intl_SDKInfo>
								{
									new Intl_SDKInfo
									{
										sdkCode = eLoginSDKCode.TapTapIntlLoginSDK.ToString()
									},
									new Intl_SDKInfo
									{
										sdkCode = eLoginSDKCode.GuestLoginSDK.ToString()
									}
								},
								pay = new List<Intl_SDKInfo>
								{
									new Intl_SDKInfo
									{
										sdkCode = eLoginSDKCode.TapTapIntlLoginSDK.ToString()
									}
								}
							}
						} },
						locales = new List<Intl_LocaleConfig>
						{
							new Intl_LocaleConfig
							{
								code = "sea",
								name = "中文繁体",
								languages = new List<Intl_LangConfig>
								{
									new Intl_LangConfig
									{
										code = "zh_tc",
										name = "中文繁体"
									},
									new Intl_LangConfig
									{
										code = "eng",
										name = "英语"
									}
								}
							}
						}
					}
				};
			}
		}
		GameObject[] array2 = Object.FindObjectsOfType<GameObject>();
		for (int j = 0; j < array2.Length; j++)
		{
			if (((Object)array2[j].gameObject).name == "Stage Camera")
			{
				Object.DestroyImmediate((Object)(object)array2[j].gameObject);
			}
		}
		TipTextInit();
		((MonoBehaviour)this).StartCoroutine(OpenProcessBar(""));
		((MonoBehaviour)this).StartCoroutine(RealStart());
	}

	private T GetBaseResource<T>(string path) where T : Object
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (CheckIsFirst())
		{
			return Object.Instantiate<T>(Resources.Load<T>(path));
		}
		return Object.Instantiate<T>(Addressables.LoadAssetAsync<T>((object)path).WaitForCompletion());
	}

	private IEnumerator RealStart()
	{
		BestRegionURL = string.Empty;
		Log_FindRegionURL = new Dictionary<string, string>();
		RegionURLResult = new List<string>();
		CoroutineWithData cd_find_regionurl = new CoroutineWithData((MonoBehaviour)(object)this, FindRegionURL());
		yield return cd_find_regionurl.Coroutine;
		if (string.IsNullOrEmpty(BestRegionURL))
		{
			ILRuntimeDebug.LogError("[热更] 获取所有 region 文件失败！");
			Transform _ConnectionErrorPop = go_Canvas.transform.Find("ConnectionErrorPop");
			if ((Object)(object)_ConnectionErrorPop != (Object)null)
			{
				((Component)_ConnectionErrorPop).gameObject.SetActive(true);
				Text textComponent = ((Component)_ConnectionErrorPop.Find("Text")).GetComponent<Text>();
				textComponent.text = JsonHelper.ToJson(Log_FindRegionURL);
				textComponent.resizeTextForBestFit = false;
				((Graphic)textComponent).color = Color.red;
			}
			else
			{
				yield return Pop(GetTipText("TIPS_UPDATE_FAILED_0"));
			}
			((MonoBehaviour)this).StopAllCoroutines();
			yield break;
		}
		UpdateBar(1f, GetTipText("TIPS_PARSE_REGION"));
		RegionModel = JsonHelper.ToObject<RegionFileModel>(BestRegionURL);
		if (IsRegionOutCN)
		{
			bool setChannelConfigSuccess = true;
			try
			{
				if ((int)Application.platform == 8)
				{
					ChannelConfig = RegionModel.Zone.channel["Apple"];
				}
				else
				{
					ChannelConfig = RegionModel.Zone.channel[ChannelCode];
				}
			}
			catch (Exception ex)
			{
				Exception e = ex;
				ILRuntimeDebug.Exeption(e);
				setChannelConfigSuccess = false;
			}
			if (!setChannelConfigSuccess)
			{
				yield return Pop(GetTipText("TIPS_GET_REGION_INFO_FAILED"));
				((MonoBehaviour)this).StopAllCoroutines();
			}
		}
		config_urls = RegionModel.Zone.url.config.Select((string _s) => _s + "/{0}/{1}{2}{3}.json").ToList();
		UI_URL_Backups = RegionModel.Zone.url.res.Select((string _s) => _s + "/images/{0}").ToList();
		if (NeedChooseServerLocation())
		{
			yield return ((MonoBehaviour)this).StartCoroutine(SelectServerLocation());
		}
		if (NeedChooseLanguage())
		{
			yield return ((MonoBehaviour)this).StartCoroutine(SelectLanguage());
		}
		CloseAndroidBG();
		yield return ((MonoBehaviour)this).StartCoroutine(ProcessBegin());
	}

	private IEnumerator SelectLanguage()
	{
		List<Intl_LangConfig> languageConfigs = null;
		foreach (Intl_LocaleConfig localeConfig in RegionModel.Zone.locales)
		{
			if (localeConfig.code == ZoneKey)
			{
				languageConfigs = localeConfig.languages;
				break;
			}
		}
		if (languageConfigs == null)
		{
			yield break;
		}
		GameObject go_LanguageSelectDialog = GetBaseResource<GameObject>("SelectLanguage");
		if ((Object)(object)go_LanguageSelectDialog == (Object)null)
		{
			ILRuntimeDebug.LogError("Find no SelectLanguage");
			yield break;
		}
		Transform transform_LanguageSelectDialog = go_LanguageSelectDialog.transform;
		transform_LanguageSelectDialog.SetParent(go_Canvas.transform);
		transform_LanguageSelectDialog.SetAsLastSibling();
		((Component)transform_LanguageSelectDialog).gameObject.SetActive(true);
		Transform transform_OptionsContainer = transform_LanguageSelectDialog.Find("Scroll View/Viewport/Content");
		Transform transform_ConfirmBtn = transform_LanguageSelectDialog.Find("ConfirmButton");
		bool waitingForContinue = true;
		((UnityEvent)((Component)transform_ConfirmBtn).GetComponent<Button>().onClick).AddListener((UnityAction)delegate
		{
			Button[] componentsInChildren = ((Component)transform_OptionsContainer).GetComponentsInChildren<Button>();
			string text = string.Empty;
			Button[] array = componentsInChildren;
			foreach (Button val in array)
			{
				GameObject gameObject = ((Component)val).gameObject;
				if (((Component)gameObject.transform.Find("Image")).gameObject.activeSelf)
				{
					text = ((Object)gameObject).name;
					break;
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				LanguageKey = text;
				go_LanguageSelectDialog.SetActive(false);
				waitingForContinue = false;
			}
		});
		foreach (Intl_LangConfig languageConfig in languageConfigs)
		{
			GameObject go_languageOption = GetBaseResource<GameObject>("LanguageOption");
			((Object)go_languageOption).name = languageConfig.code;
			Button button = go_languageOption.GetComponent<Button>();
			((UnityEvent)button.onClick).AddListener((UnityAction)delegate
			{
				OnChooseLanguage(button);
			});
			Transform transform_LanguageOption = go_languageOption.transform;
			Transform transform_LanguageOptionText = transform_LanguageOption.Find("Text");
			((Component)transform_LanguageOptionText).GetComponent<Text>().text = languageConfig.name;
			transform_LanguageOption.SetParent(transform_OptionsContainer);
			if (languageConfig.code == LanguageKey)
			{
				((Component)transform_LanguageOption.Find("Image")).gameObject.SetActive(true);
			}
		}
		SetFittingScale(transform_LanguageSelectDialog);
		while (waitingForContinue)
		{
			yield return (object)new WaitForEndOfFrame();
		}
		void OnChooseLanguage(Button _btn)
		{
			GameObject gameObject = ((Component)_btn).gameObject;
			Button[] componentsInChildren = ((Component)transform_OptionsContainer).GetComponentsInChildren<Button>();
			Button[] array = componentsInChildren;
			foreach (Button val in array)
			{
				GameObject gameObject2 = ((Component)val).gameObject;
				((Component)gameObject2.transform.Find("Image")).gameObject.SetActive(((Object)gameObject2).name == ((Object)gameObject).name);
			}
		}
	}

	private IEnumerator SelectServerLocation()
	{
		GameObject go_ServerSelectDialog = GetBaseResource<GameObject>("SelectServerLocation");
		if ((Object)(object)go_ServerSelectDialog == (Object)null)
		{
			ILRuntimeDebug.LogError("Find no SelectServerLocation");
			yield break;
		}
		Transform transform_ServerSelectDialog = go_ServerSelectDialog.transform;
		transform_ServerSelectDialog.SetParent(go_Canvas.transform);
		transform_ServerSelectDialog.SetAsLastSibling();
		((Component)transform_ServerSelectDialog).gameObject.SetActive(true);
		Transform transform_OptionsContainer = transform_ServerSelectDialog.Find("Scroll View/Viewport/Content");
		Transform transform_ConfirmBtn = transform_ServerSelectDialog.Find("ConfirmButton");
		bool waitingForContinue = true;
		((UnityEvent)((Component)transform_ConfirmBtn).GetComponent<Button>().onClick).AddListener((UnityAction)delegate
		{
			Button[] componentsInChildren = ((Component)transform_OptionsContainer).GetComponentsInChildren<Button>();
			string text = string.Empty;
			Button[] array = componentsInChildren;
			foreach (Button val in array)
			{
				GameObject gameObject = ((Component)val).gameObject;
				if (((Component)gameObject.transform.Find("Image")).gameObject.activeSelf)
				{
					text = ((Object)gameObject).name;
					break;
				}
			}
			if (!string.IsNullOrEmpty(text))
			{
				ZoneKey = text;
				go_ServerSelectDialog.SetActive(false);
				waitingForContinue = false;
			}
		});
		foreach (Intl_LocaleConfig intlLocaleConfig in RegionModel.Zone.locales)
		{
			GameObject go_serverOption = GetBaseResource<GameObject>("ServerOption");
			((Object)go_serverOption).name = intlLocaleConfig.code;
			Button button = go_serverOption.GetComponent<Button>();
			((UnityEvent)button.onClick).AddListener((UnityAction)delegate
			{
				OnChooseServerLocation(button);
			});
			Transform transform_ServerOption = go_serverOption.transform;
			Transform transform_ServerOptionText = transform_ServerOption.Find("Text");
			((Component)transform_ServerOptionText).GetComponent<Text>().text = intlLocaleConfig.name;
			transform_ServerOption.SetParent(transform_OptionsContainer);
		}
		SetFittingScale(transform_ServerSelectDialog);
		while (waitingForContinue)
		{
			yield return (object)new WaitForEndOfFrame();
		}
		void OnChooseServerLocation(Button _btn)
		{
			GameObject gameObject = ((Component)_btn).gameObject;
			Button[] componentsInChildren = ((Component)transform_OptionsContainer).GetComponentsInChildren<Button>();
			Button[] array = componentsInChildren;
			foreach (Button val in array)
			{
				GameObject gameObject2 = ((Component)val).gameObject;
				((Component)gameObject2.transform.Find("Image")).gameObject.SetActive(((Object)gameObject2).name == ((Object)gameObject).name);
			}
		}
	}

	private IEnumerator ShowPrivacyStatement()
	{
		CoroutineWithData getStatementContentCorouten = new CoroutineWithData((MonoBehaviour)(object)this, DownloadFile($"https://m.gubulin.com/agreement.txt?{DateTimeHelper.Now_Milliseconds}", add_random: true));
		yield return getStatementContentCorouten.Coroutine;
		if (getStatementContentCorouten.Result == null)
		{
			yield break;
		}
		string content = ((DownloadHandler)getStatementContentCorouten.Result).text;
		GameObject go_PrivacyStatement = Addressables.InstantiateAsync((object)"PrivacyStatement", (Transform)null, false, true).WaitForCompletion();
		if ((Object)(object)go_PrivacyStatement == (Object)null)
		{
			ILRuntimeDebug.LogError("Find no PrivacyStatement");
			yield break;
		}
		GameObject go_PrivacyPolicyContent = Addressables.InstantiateAsync((object)"PrivacyPolicyContent", (Transform)null, false, true).WaitForCompletion();
		if ((Object)(object)go_PrivacyPolicyContent == (Object)null)
		{
			ILRuntimeDebug.LogError("Find no PrivacyPolicyContent");
			yield break;
		}
		GameObject go_UserAgreementContent = Addressables.InstantiateAsync((object)"UserAgreementContent", (Transform)null, false, true).WaitForCompletion();
		if ((Object)(object)go_UserAgreementContent == (Object)null)
		{
			ILRuntimeDebug.LogError("Find no UserAgreementContent");
			yield break;
		}
		Transform transform_PrivacyStatement = go_PrivacyStatement.transform;
		Transform transform_ConfirmBtn = transform_PrivacyStatement.Find("ConfirmBtn");
		Transform transform_RejectBtn = transform_PrivacyStatement.Find("RejectBtn");
		Transform transform_PrivacyPolicyLink = transform_PrivacyStatement.Find("PrivacyPolicy");
		Transform transform_UserAgreementLink = transform_PrivacyStatement.Find("UserAgreement");
		Transform transform_PrivacyPolicyContent = go_PrivacyPolicyContent.transform;
		Transform transform_UserAgreementContent = go_UserAgreementContent.transform;
		transform_PrivacyStatement.SetParent(go_Canvas.transform);
		transform_PrivacyPolicyContent.SetParent(go_Canvas.transform);
		transform_UserAgreementContent.SetParent(go_Canvas.transform);
		transform_PrivacyStatement.SetAsLastSibling();
		transform_PrivacyPolicyContent.SetAsLastSibling();
		transform_UserAgreementContent.SetAsLastSibling();
		((Component)transform_PrivacyStatement).gameObject.SetActive(true);
		((Component)transform_PrivacyStatement.Find("Scroll View/Viewport/Content/Text")).GetComponent<Text>().text = content;
		SetFittingScale(transform_PrivacyStatement, transform_PrivacyPolicyContent, transform_UserAgreementContent);
		bool waitingForContinue = false;
		((UnityEvent)((Component)transform_ConfirmBtn).GetComponent<Button>().onClick).AddListener((UnityAction)delegate
		{
			((UnityEventBase)((Component)transform_ConfirmBtn).GetComponent<Button>().onClick).RemoveAllListeners();
			((UnityEventBase)((Component)transform_RejectBtn).GetComponent<Button>().onClick).RemoveAllListeners();
			GameLocalDataManager.SetPrivacyAgreement(agree: true);
			((Component)transform_PrivacyStatement).gameObject.SetActive(false);
			waitingForContinue = true;
			UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.PrivacyStatement, new UserTrackData_PrivacyStatement
			{
				Accept = true
			});
		});
		((UnityEvent)((Component)transform_RejectBtn).GetComponent<Button>().onClick).AddListener((UnityAction)delegate
		{
			((UnityEventBase)((Component)transform_ConfirmBtn).GetComponent<Button>().onClick).RemoveAllListeners();
			((UnityEventBase)((Component)transform_RejectBtn).GetComponent<Button>().onClick).RemoveAllListeners();
			UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.PrivacyStatement, new UserTrackData_PrivacyStatement
			{
				Accept = false
			}, delegate
			{
				GameLocalDataManager.SetPrivacyAgreement(agree: false);
				Application.Quit();
			});
		});
		((UnityEvent)((Component)transform_PrivacyPolicyLink).GetComponent<Button>().onClick).AddListener((UnityAction)delegate
		{
			((Component)transform_PrivacyPolicyContent).gameObject.SetActive(true);
		});
		((UnityEvent)((Component)transform_UserAgreementLink).GetComponent<Button>().onClick).AddListener((UnityAction)delegate
		{
			((Component)transform_UserAgreementContent).gameObject.SetActive(true);
		});
		((UnityEvent)((Component)transform_PrivacyPolicyContent.Find("Button")).GetComponent<Button>().onClick).AddListener((UnityAction)delegate
		{
			((Component)transform_PrivacyPolicyContent).gameObject.SetActive(false);
		});
		((UnityEvent)((Component)transform_UserAgreementContent.Find("Button")).GetComponent<Button>().onClick).AddListener((UnityAction)delegate
		{
			((Component)transform_UserAgreementContent).gameObject.SetActive(false);
		});
		while (!waitingForContinue)
		{
			yield return (object)new WaitForEndOfFrame();
		}
	}

	private void SetFittingScale(params Transform[] transforms)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		Transform transform = go_Canvas.transform;
		RectTransform val = (RectTransform)(object)((transform is RectTransform) ? transform : null);
		if ((Object)(object)val == (Object)null)
		{
			ILRuntimeDebug.LogError("Get Screen Viewport Size Failed");
			return;
		}
		Rect rect = val.rect;
		Vector2 size = ((Rect)(ref rect)).size;
		float num = Math.Min(Math.Max(1f, size.y / 1080f), 1.66f);
		foreach (Transform val2 in transforms)
		{
			val2.localScale = new Vector3(num, num);
		}
	}

	private IEnumerator ProcessBegin(bool force_first = false)
	{
		Stopwatch hotFixStopWatch = new Stopwatch();
		bool need_restart = false;
		string barText1 = GetTipText("UpdateBar1");
		UpdateBar(1f, (!string.IsNullOrEmpty(barText1)) ? barText1 : "游戏启动中");
		if ((int)Application.platform == 0 || (int)Application.platform == 7)
		{
			yield return UserTrackInit();
			if ((!Configs.TryGetValue("PA", out var needShowPrivacyStatement_Editor) || needShowPrivacyStatement_Editor == "1") && (ChannelCode == "taptap" || ChannelCode == "tapplay") && !GameLocalDataManager.GetPrivacyAgreement())
			{
				HideBar();
				yield return ShowPrivacyStatement();
				ShowBar();
			}
			CoroutineWithData cd_SentryInit = new CoroutineWithData((MonoBehaviour)(object)this, SentryInit());
			yield return cd_SentryInit.Coroutine;
			yield return HotUpdateFinish();
			yield break;
		}
		Configs = null;
		for (int i = 0; i < config_urls.Count; i++)
		{
			string lang = LanguageKey;
			if (!string.IsNullOrEmpty(lang))
			{
				lang = "-" + lang;
			}
			string zone = ZoneKey;
			if (!string.IsNullOrEmpty(zone))
			{
				zone = "." + zone;
			}
			string suffix = string.Empty;
			if (zone.Length > 0 && lang.Length > 0)
			{
				suffix = zone + lang;
			}
			string _channelCode = ChannelCode;
			if (OriginChannelCode == "taptapprivacyreview")
			{
				_channelCode = OriginChannelCode;
			}
			string config_url = string.Format(config_urls[i], Application.version, "pro", _channelCode, suffix);
			CoroutineWithData cd_config_url = new CoroutineWithData((MonoBehaviour)(object)this, DownloadFile(config_url, add_random: true));
			yield return cd_config_url.Coroutine;
			if (cd_config_url.Result != null)
			{
				Configs = JsonHelper.ToObject<Dictionary<string, string>>(((DownloadHandler)cd_config_url.Result).text);
				break;
			}
		}
		if (Configs == null || !Configs.ContainsKey("BackupResUrl"))
		{
			ILRuntimeDebug.LogError("[热更] 下载配置文件失败！");
			yield return Pop(GetTipText("TIPS_UPDATE_FAILED_1"));
			((MonoBehaviour)this).StopAllCoroutines();
			yield break;
		}
		yield return UserTrackInit();
		CoroutineWithData cd_CheckForceUpdate = new CoroutineWithData((MonoBehaviour)(object)this, CheckForceUpdate());
		yield return cd_CheckForceUpdate.Coroutine;
		bool isFirst = false;
		if (force_first || CheckIsFirst())
		{
			GameLocalDataManager.MarkFirstInstallAndRegist(GameLocalDataManager.FirstInstallAndRegistFlag.Install);
			if (MainVersionUpdate())
			{
				if (File.Exists(AssetsHelper.vFile))
				{
					File.Delete(AssetsHelper.vFile);
				}
				PlayerPrefs.DeleteKey("HotUpdateFlag");
				PlayerPrefs.DeleteKey("hotfixdll_string");
				PlayerPrefs.DeleteKey("hotfixdll_md5");
				((MonoBehaviour)this).StopAllCoroutines();
				HotFix_Utils.Restart();
				yield break;
			}
			if (IsNewHotUpdateProcess)
			{
				hotFixStopWatch.Reset();
				hotFixStopWatch.Restart();
				if (Directory.Exists(AssetsHelper.AssetBundleFilePath))
				{
					need_restart = true;
					Directory.Delete(AssetsHelper.AssetBundleFilePath, recursive: true);
				}
				yield return InstallAssets();
				hotFixStopWatch.Stop();
				Addressables.InitializeAsync().WaitForCompletion();
			}
			else
			{
				hotFixStopWatch.Reset();
				hotFixStopWatch.Restart();
				CoroutineWithData cd_copyasset = new CoroutineWithData((MonoBehaviour)(object)this, InternalCopyAssetsToPersistentFolder());
				yield return cd_copyasset.Coroutine;
				if (!(bool)cd_copyasset.Result)
				{
					yield return ((MonoBehaviour)this).StartCoroutine(Pop(GetTipText("TIPS_UPDATE_FAILED_INIT_FAILED")));
					yield break;
				}
				hotFixStopWatch.Stop();
			}
			isFirst = true;
			File.WriteAllText(AssetsHelper.vFile, Application.version);
			PlayerPrefs.SetString("HotUpdateFlag", string.Empty);
			PlayerPrefs.SetString("hotfixdll_string", string.Empty);
			PlayerPrefs.SetString("hotfixdll_md5", string.Empty);
		}
		if ((!Configs.TryGetValue("PA", out var needShowPrivacyStatement) || needShowPrivacyStatement == "1") && (ChannelCode == "taptap" || ChannelCode == "tapplay") && !GameLocalDataManager.GetPrivacyAgreement() && isFirst)
		{
			HideBar();
			yield return ShowPrivacyStatement();
			ShowBar();
		}
		if (!IsRegionOutCN)
		{
			if (ChannelCode == "toutiao-android")
			{
				((ByteDanceSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.ByteDance]).Init();
			}
			else if (ChannelCode == "gdt-android")
			{
				((GDTSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.GDT]).Init();
			}
			AndroidBasicPlugInManager.Instance.PrefetchOAID(DateTimeHelper.GetTimeStamp(DateTimeHelper.Now), Configs["AuthServerUrl"]);
			AndroidBasicPlugInManager.Instance.GetIp();
		}
		RPCRecord = Configs.ContainsKey("RPCRecord");
		CoroutineWithData cd_SentryInit2 = new CoroutineWithData((MonoBehaviour)(object)this, SentryInit());
		yield return cd_SentryInit2.Coroutine;
		ReportActivateForIOS();
		if (ChannelCode == "bilibili")
		{
			((BiliBiliSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.BiliBiliSDK]).Init();
			UpdateBar(1f, GetTipText("TipsBiliBiliSDKInit"));
			while (((BiliBiliSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.BiliBiliSDK]).Initializing)
			{
				yield return (object)new WaitForSeconds(0.1f);
			}
		}
		else if (ChannelCode == "xipu")
		{
			XiPuSDK sdk = (XiPuSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.XiPuSDK];
			sdk.Init();
			UpdateBar(1f, string.Format(GetTipText("TipsChannelSDKInit"), ChannelCode));
			while (sdk.Initializing)
			{
				yield return (object)new WaitForSeconds(0.1f);
			}
		}
		hotFixStopWatch.Reset();
		hotFixStopWatch.Restart();
		UpdateBar(1f, GetTipText("UpdateBar2"));
		CoroutineWithData cd_GetResourceDiff = ((!IsNewHotUpdateProcess) ? new CoroutineWithData((MonoBehaviour)(object)this, GetResourceDiff()) : new CoroutineWithData((MonoBehaviour)(object)this, GetResourceDiff_New()));
		yield return cd_GetResourceDiff.Coroutine;
		CheckVersionResult _CheckVersionResult = (CheckVersionResult)cd_GetResourceDiff.Result;
		hotFixStopWatch.Stop();
		UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.ResourcesDiff, new UserTrackData_ResourcesDiff
		{
			TotalBytes = _CheckVersionResult.TotalBytes
		});
		if (_CheckVersionResult.WaitToUpdate.Count > 0)
		{
			need_restart = true;
			if (IsNewHotUpdateProcess)
			{
				CoroutineWithData cd_Download_NeedToUpdateFiles = new CoroutineWithData((MonoBehaviour)(object)this, Download_NeedToUpdateFiles_New(_CheckVersionResult.WaitToUpdate, _CheckVersionResult.TotalBytes));
				yield return cd_Download_NeedToUpdateFiles.Coroutine;
			}
			else
			{
				CoroutineWithData cd_Download_NeedToUpdateFiles2 = new CoroutineWithData((MonoBehaviour)(object)this, Download_NeedToUpdateFiles(_CheckVersionResult.WaitToUpdate, _CheckVersionResult.TotalBytes));
				yield return cd_Download_NeedToUpdateFiles2.Coroutine;
			}
		}
		UpdateBar(1f, GetTipText("UpdateBar3"));
		CoroutineWithData cd_CheckIsDLLSame = new CoroutineWithData((MonoBehaviour)(object)this, CheckIsDLLSame());
		yield return cd_CheckIsDLLSame.Coroutine;
		CheckDllResult _CheckDllResult = (CheckDllResult)cd_CheckIsDLLSame.Result;
		UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.CodeVersionDiff, new UserTrackData_CodeVersionDiff
		{
			IsSame = _CheckDllResult.isDllSame,
			LocalMd5 = _CheckDllResult.local_hotfixdll_md5,
			ServerMd5 = _CheckDllResult.server_hotfixdll_md5
		});
		if (!_CheckDllResult.isValid)
		{
			UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.CodeVersionUpdate, new UserTrackData_CodeVersionUpdate
			{
				Success = false
			});
			yield return ((MonoBehaviour)this).StartCoroutine(Pop(GetTipText("TIPS_UPDATE_FAILED_3")));
		}
		if (!_CheckDllResult.isDllSame)
		{
			need_restart = true;
			yield return ((MonoBehaviour)this).StartCoroutine(Download_Dll(_CheckDllResult));
			UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.CodeVersionUpdate, new UserTrackData_CodeVersionUpdate
			{
				Success = true
			});
		}
		ProcessCheckAllBar(0f);
		string local_HotUpdateFlag = PlayerPrefs.GetString("HotUpdateFlag");
		string server_HotUpdateFlag = _CheckVersionResult.server_version_md5 + "_" + _CheckDllResult.server_hotfixdll_md5;
		if (!local_HotUpdateFlag.Equals(server_HotUpdateFlag))
		{
			UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.NeedHotUpdate, new UserTrackData_NeedHotUpdate
			{
				NeedHotUpdate = true
			});
			hotFixStopWatch.Reset();
			hotFixStopWatch.Restart();
			bool fileMD5CheckResult;
			if (IsNewHotUpdateProcess)
			{
				CoroutineWithData cd_CheckUpdatedFileMD5 = new CoroutineWithData((MonoBehaviour)(object)this, CheckUpdatedFileMD5(_CheckVersionResult));
				yield return cd_CheckUpdatedFileMD5.Coroutine;
				fileMD5CheckResult = (bool)cd_CheckUpdatedFileMD5.Result;
			}
			else
			{
				CoroutineWithData cd_CheckAllFileMD5 = new CoroutineWithData((MonoBehaviour)(object)this, CheckAllFileMD5(_CheckVersionResult));
				yield return cd_CheckAllFileMD5.Coroutine;
				fileMD5CheckResult = (bool)cd_CheckAllFileMD5.Result;
			}
			hotFixStopWatch.Stop();
			if (!fileMD5CheckResult)
			{
				UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.HotUpdateResult, new UserTrackData_HotUpdateResult
				{
					Success = false
				});
				((MonoBehaviour)this).StopAllCoroutines();
				((MonoBehaviour)this).StartCoroutine(ProcessBegin(force_first: true));
				yield break;
			}
			string local_version_path = Application.persistentDataPath + "/AssetBundles/Version.xml";
			File.WriteAllText(local_version_path, _CheckVersionResult.server_version_content);
			PlayerPrefs.SetString("HotUpdateFlag", server_HotUpdateFlag);
			UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.HotUpdateResult, new UserTrackData_HotUpdateResult
			{
				Success = true
			});
			if (need_restart)
			{
				UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.RestartAfterHotUpdate);
				yield return ((MonoBehaviour)this).StartCoroutine(Pop(GetTipText("TIPS_UPDATE_SUCESS"), null, 5));
				yield break;
			}
		}
		else
		{
			UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.NeedHotUpdate, new UserTrackData_NeedHotUpdate
			{
				NeedHotUpdate = false
			});
		}
		string Android_ActivateFlag = PlayerPrefs.GetString("Android_NewActivateFlag");
		bool Android_isFirst = string.IsNullOrEmpty(Android_ActivateFlag);
		if (Android_isFirst)
		{
			PlayerPrefs.SetString("Android_NewActivateFlag", DateTimeHelper.Now.ToString());
		}
		if ((int)Application.platform == 11 && Android_isFirst)
		{
			UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_3"));
			if (ChannelCode == "taptap" || ChannelCode == "tapplay")
			{
				TapTapEventManager.Instance.RecordActivation(DateTimeHelper.GetTimeStamp(DateTimeHelper.Now), Configs["AuthServerUrl"]);
				TapTapEventManager.Instance.InvokeAction(TapTapEventManager.TapTapEventType.Activation, null);
			}
			else if (ChannelCode == "bilibili")
			{
				BiliBiliEventManager.Instance.InvokeAction(BiliBiliEventManager.BiliBiliEventType.APP_FIRST_ACTIVE);
			}
			UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_18"));
		}
		if ((int)Application.platform == 8 && SDKManager.CheckVersion())
		{
			SDKManager.Instance.SDKMap_IOS[SDKManager.eSDKName.iOS].IsHaveWxURL();
			while (!SDKManager.IsReady())
			{
				yield return (object)new WaitForEndOfFrame();
			}
		}
		UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_17"));
		yield return HotUpdateFinish();
	}

	public IEnumerator UpdateGvGConfigs()
	{
		for (int i = 0; i < config_urls.Count; i++)
		{
			string lang = ((LanguageKey == "zh") ? "" : LanguageKey);
			if (lang.Length > 0)
			{
				lang = "." + lang;
			}
			string config_url = string.Format(config_urls[i], Application.version, "pro", ChannelCode, lang);
			CoroutineWithData cd_config_url = new CoroutineWithData((MonoBehaviour)(object)this, DownloadFile(config_url, add_random: true));
			yield return cd_config_url.Coroutine;
			if (cd_config_url.Result != null)
			{
				Dictionary<string, string> config = JsonHelper.ToObject<Dictionary<string, string>>(((DownloadHandler)cd_config_url.Result).text);
				if (config.ContainsKey("GVGDisable"))
				{
					Configs["GVGDisable"] = config["GVGDisable"];
				}
				else
				{
					Configs.Remove("GVGDisable");
				}
				break;
			}
		}
	}

	public IEnumerator HotUpdateFinish()
	{
		UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.InitGameAfterHotUpdate);
		if (IsNewHotUpdateProcess)
		{
			List<string> hotFixResPathList = GameLocalDataManager.GetHotFixResPathList();
			string resourceXmlContent;
			if (hotFixResPathList.Contains("Resource.xml"))
			{
				resourceXmlContent = AssetsHelper.OpenText("Resource", ".xml").ReadToEnd();
			}
			else
			{
				CoroutineWithData cdGetIntegratedResourceXml = new CoroutineWithData((MonoBehaviour)(object)this, AssetsHelper.DownloadIntegratedResourceXml());
				yield return cdGetIntegratedResourceXml.Coroutine;
				resourceXmlContent = (string)cdGetIntegratedResourceXml.Result;
			}
			typeof(AssetsManager).GetMethod("Init", BindingFlags.Instance | BindingFlags.Public, null, new Type[2]
			{
				typeof(string),
				typeof(List<string>)
			}, null).Invoke(AssetsManager.Instance, new object[2] { resourceXmlContent, hotFixResPathList });
		}
		else
		{
			AssetsManager.Instance.Init();
		}
		UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_25"));
		AsyncOperationHandle<GameObject> res = Addressables.LoadAssetAsync<GameObject>((object)"GameScene");
		yield return res;
		GameObject _GameScene = Object.Instantiate<GameObject>(res.Result);
		int count = _GameScene.transform.childCount;
		for (int i = count - 1; i >= 0; i--)
		{
			_GameScene.transform.GetChild(i).parent = null;
		}
		Object.Destroy((Object)(object)_GameScene);
		UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_26"));
		yield return null;
		go_MainCamera.transform.position = Vector3.zero;
		go_MainCamera.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
		go_MainCamera.transform.localScale = Vector3.one;
		GameObject _BattleCameraFrame = new GameObject();
		((Object)_BattleCameraFrame).name = "BattleCameraFrame";
		_BattleCameraFrame.layer = 8;
		_BattleCameraFrame.transform.SetParent(go_MainCamera.transform);
		_BattleCameraFrame.AddComponent<SpriteRenderer>();
		_BattleCameraFrame.transform.localPosition = new Vector3(0f, -0.8f, 18.1f);
		_BattleCameraFrame.transform.localRotation = Quaternion.identity;
		_BattleCameraFrame.transform.localScale = new Vector3(7.73f, 11.1f, 1f);
		UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_27"));
		yield return null;
		UIConfig.defaultFont = "SourceHanSansCN-Bold";
		LoadFontAndRegister("SourceHanSansCN-Heavy");
		LoadFontAndRegister("SourceHanSansCN-Bold");
		UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_28"));
		yield return null;
		FGUIManager.SetIsTapTap(ChannelCode);
		if (FGUIManager.IsTapTap)
		{
			if (SDKManager.Instance.SDKMap.ContainsKey(SDKManager.eSDKName.TapTapSDK))
			{
				yield return ((TapTapSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.TapTapSDK]).InitAndWaitResult();
			}
			else
			{
				((MonoBehaviour)FGUIManager.Instance).StartCoroutine(TapTapSdkManager.Instance.TapTapSdkInitIEnumerator(ChannelCode));
			}
			UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_30"));
			yield return null;
		}
		InitSystem();
		UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_29"));
		yield return null;
		Resources.UnloadAsset((Object)(object)default_font);
		int systemMemorySize = SystemInfo.systemMemorySize;
		if ((int)Application.platform == 8)
		{
			UiHelper.DefaultFrameRate = ((systemMemorySize > 2500) ? 60 : 30);
		}
		else
		{
			UiHelper.DefaultFrameRate = ((systemMemorySize > 3500) ? 60 : 30);
		}
		Application.targetFrameRate = UiHelper.FrameRate;
		onLowMemoryWarning();
		Application.lowMemory += new LowMemoryCallback(onLowMemory);
	}

	private void onLowMemoryWarning()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 8)
		{
			MethodInfo method = ((object)HotFixManager.Instance).GetType().GetMethod("GetMmeoryUsage");
			if (method != null)
			{
				object obj = method.Invoke(HotFixManager.Instance, null);
			}
			Resources.UnloadUnusedAssets();
			GC.Collect();
			GC.Collect(1);
		}
		else if ((int)Application.platform == 11)
		{
			long memoryUsage = AndroidBasicPlugInManager.Instance.GetMemoryUsage();
		}
	}

	private void onLowMemory()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 8)
		{
			MethodInfo method = ((object)HotFixManager.Instance).GetType().GetMethod("GetMmeoryUsage");
			if (method != null)
			{
				object obj = method.Invoke(HotFixManager.Instance, null);
				if (Extensions.ToInt32(obj) > 1200000000)
				{
					ILRuntimeDebug.LogError($"IPhonePlayer LowMemoryWarning!  cur memroy = {obj} B");
				}
			}
			else
			{
				ILRuntimeDebug.LogError("IPhonePlayer LowMemoryWarning! no method");
			}
		}
		else if ((int)Application.platform == 11)
		{
			long memoryUsage = AndroidBasicPlugInManager.Instance.GetMemoryUsage();
			if (Extensions.ToInt32((object)memoryUsage) > 1500000)
			{
				ILRuntimeDebug.LogError($"Android LowMemoryWarning! cur memroy = {memoryUsage} KB");
			}
		}
		else
		{
			ILRuntimeDebug.LogError("Other LowMemoryWarning!");
		}
	}

	public static Promise<AssetBundle> LoadAssetBundle(string abName)
	{
		return AssetsManager.Instance.LoadAssetBundle(abName);
	}

	public static void UnloadAssetBundle(string abName)
	{
		AssetsManager.Instance.UnloadAssetBundle(abName);
	}

	private void TipTextInit()
	{
		TipText = HotUpdateProcessTips.Tips;
	}

	private string GetTipText(string textKey)
	{
		if (TipText != null && TipText.TryGetValue(textKey, out var value))
		{
			return value;
		}
		return textKey;
	}

	public void LoadFontAndRegister(string fontName)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		Font val = Addressables.LoadAssetAsync<Font>((object)fontName).WaitForCompletion();
		FontManager.RegisterFont((BaseFont)new DynamicFont(fontName, val), fontName);
	}

	public void CheckFguiRootPos()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (!IsFguiCameraChanged)
		{
			((GObject)GRoot.inst).position = Vector3.one * 100000f;
		}
		else
		{
			((GObject)GRoot.inst).position = Vector3.zero;
		}
	}

	public void ChangeUIToFGUI()
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		IsFguiCameraChanged = true;
		CheckFguiRootPos();
		Camera component = ((Component)Camera.main).GetComponent<Camera>();
		component.clearFlags = (CameraClearFlags)2;
		component.cullingMask &= -33;
		component.cullingMask &= -257;
		component.orthographic = true;
		component.orthographicSize = 5.4f;
		component.nearClipPlane = 0.3f;
		component.farClipPlane = 500f;
		component.depth = -1f;
		Singleton<CameraService>.Instance.FitCamera(component);
		Transform val = ((Component)component).transform.Find("LoginPrefab");
		if ((Object)(object)val != (Object)null)
		{
			val.localScale = Vector3.one;
			val.localPosition = new Vector3(0f, 0f, 1f);
			ParticleSystem[] componentsInChildren = ((Component)val).GetComponentsInChildren<ParticleSystem>(true);
			ParticleSystem[] array = componentsInChildren;
			foreach (ParticleSystem val2 in array)
			{
				MainModule main = val2.main;
				((MainModule)(ref main)).gravityModifierMultiplier = ((MainModule)(ref main)).gravityModifierMultiplier / loginPrefabScale;
			}
		}
		if (Object.op_Implicit((Object)(object)go_Canvas))
		{
			Object.Destroy((Object)(object)go_Canvas);
		}
	}

	private IEnumerator SentryInit()
	{
		Type _type = typeof(SentryController);
		GameObject obj = GameObject.Find(_type.FullName);
		if ((Object)(object)obj == (Object)null)
		{
			obj = new GameObject();
			((Object)obj).name = _type.FullName;
			obj.AddComponent(_type);
			Object.DontDestroyOnLoad((Object)(object)obj);
		}
		else if ((Object)(object)obj.GetComponent(_type) == (Object)null)
		{
			obj.AddComponent(_type);
			Object.DontDestroyOnLoad((Object)(object)obj);
		}
		UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.SentryInit);
		yield return null;
	}

	private IEnumerator UserTrackInit()
	{
		((Component)this).gameObject.AddComponent<UserTrackHelper>();
		CoroutineWithData cd_find_bestgateway = new CoroutineWithData((MonoBehaviour)(object)this, FindBestGateway());
		yield return cd_find_bestgateway.Coroutine;
		UserTrackHelper.Instance?.SetTrackUrl(Configs["AuthServerUrl"]);
		string userTrackLevel;
		int trackLevel = (Configs.TryGetValue("UserTrackLevel", out userTrackLevel) ? int.Parse(userTrackLevel) : 0);
		UserTrackHelper.Instance?.SetTrackLevel((UserTrackLevel)trackLevel);
	}

	public void InitSystem()
	{
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Invalid comparison between Unknown and I4
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Invalid comparison between Unknown and I4
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Invalid comparison between Unknown and I4
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected O, but got Unknown
		List<Type> list = new List<Type>();
		list.Add(typeof(CacheManager));
		list.Add(typeof(UnityUiService));
		list.Add(typeof(UiAudioManager));
		list.Add(typeof(TopUiCanvas));
		list.Add(typeof(FGUIManager));
		list.Add(typeof(GameController));
		list.Add(typeof(SpawnManager));
		list.Add(typeof(GameDataService));
		list.Add(typeof(ThinkingDataHelper));
		list.Add(typeof(CaptureScreenshotManager));
		list.Add(typeof(UnityRequestHelper));
		list.Add(typeof(QuickPlayReplayService));
		List<Type> list2 = list;
		if (IsRegionOutCN)
		{
			if ((int)Application.platform == 11)
			{
				foreach (Intl_SDKInfo item in RegionModel.Zone.channel[ChannelCode].login)
				{
					if (item.sdkCode == eLoginSDKCode.GoogleLoginSDK.ToString())
					{
						((GoogleSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.GoogleSDK]).Init("");
					}
					else if (item.sdkCode == eLoginSDKCode.TapTapIntlLoginSDK.ToString())
					{
						((TapTapIntlSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.TapIntlSDK]).Init();
					}
					else if (!(item.sdkCode == eLoginSDKCode.FacebookLoginSDK.ToString()))
					{
						if (item.sdkCode == eLoginSDKCode.TwitterLoginSDK.ToString())
						{
							((TwitterSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.Twitter]).Init();
						}
						else if (!(item.sdkCode == eLoginSDKCode.AppleLoginSDK.ToString()) && !(item.sdkCode == eLoginSDKCode.AppleOriginalLoginSDK.ToString()) && !(item.sdkCode == eLoginSDKCode.GuestLoginSDK.ToString()))
						{
							ILRuntimeDebug.LogError("No Definition For SdkCode " + item.sdkCode);
						}
					}
				}
			}
			if ((int)Application.platform == 8)
			{
			}
			list2.Add(typeof(EventManager));
			list2.Add(typeof(PurchaseBehavior_Intl));
		}
		else
		{
			if ((int)Application.platform == 8)
			{
				list2.Add(typeof(AdReportHelper));
			}
			list2.Add(typeof(PurchaseBehavior));
		}
		if (Configs.TryGetValue("DebugStats", out var value) && value == "1")
		{
			list2.Add(typeof(CustomPerformanceMonitor));
		}
		if (Configs.TryGetValue("ReplayStuckProcessEnabled", out var value2) && value2 == "1")
		{
			list2.Add(typeof(ReplayEventManager));
		}
		for (int i = 0; i < list2.Count; i++)
		{
			Type type = list2[i];
			GameObject val = GameObject.Find(type.FullName);
			if ((Object)(object)val == (Object)null)
			{
				val = new GameObject();
				((Object)val).name = type.FullName;
				val.AddComponent(type);
				Object.DontDestroyOnLoad((Object)(object)val);
			}
			else if ((Object)(object)val.GetComponent(type) == (Object)null)
			{
				val.AddComponent(type);
				Object.DontDestroyOnLoad((Object)(object)val);
			}
		}
		GDMgr.LoadLanguageData();
		GDMgr.LoadData();
		ILRequestHelper.GetUiService = () => Contexts.sharedInstance.Service<IUiService>();
		ILRequestHelper.ShowWaitingAnimationWithDelay = delegate(ILRequestHelper.WaitingAnimParam animParam)
		{
			float delay = animParam.Delay;
			object task = animParam.Task;
			((MonoBehaviour)this).StartCoroutine(EffectHelper.Delay(delay, delegate
			{
				if (task is Task { IsCompleted: false })
				{
					animParam.Service.ShowWaitingAnimation(show: true);
				}
			}));
		};
		ThinkingDataHelper.Instance.ThinkingApiLogout();
		InitOpenBattle_STORY0011();
		if (Define.GvGMode3UnderDevelopment())
		{
			_ = SocketManager.Instance;
		}
	}

	private void InitOpenBattle_STORY0011()
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		string unzipPath = Path.Combine(Path.Combine(Application.persistentDataPath, "replays"), "5be0b7bd-9eb6-4da8-9c63-e5552527e890");
		if (Directory.Exists(unzipPath))
		{
			Loaded_Fake_Story0011_BattleId = true;
			Has_Fake_Story0011_BattleId = true;
			return;
		}
		Loaded_Fake_Story0011_BattleId = false;
		string text = "STORY0011";
		AsyncOperationHandle<IList<IResourceLocation>> locationHandle = Addressables.LoadResourceLocationsAsync((object)text, typeof(TextAsset));
		IList<IResourceLocation> list = locationHandle.WaitForCompletion();
		if (list.Count > 0)
		{
			Directory.CreateDirectory(unzipPath);
			AsyncOperationHandle<IList<TextAsset>> val = Addressables.LoadAssetsAsync<TextAsset>(list, (Action<TextAsset>)null);
			val.Completed += delegate(AsyncOperationHandle<IList<TextAsset>> _handler)
			{
				//IL_000e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0013: Unknown result type (might be due to invalid IL or missing references)
				((MonoBehaviour)this).StartCoroutine(WriteStory0011(locationHandle, _handler, unzipPath));
			};
		}
		else
		{
			Has_Fake_Story0011_BattleId = false;
			Loaded_Fake_Story0011_BattleId = false;
		}
	}

	private IEnumerator WriteStory0011(AsyncOperationHandle<IList<IResourceLocation>> _locationHandle, AsyncOperationHandle<IList<TextAsset>> _handler, string unzipPath)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		int i = 0;
		foreach (TextAsset _asset in _handler.Result)
		{
			string filePath = Path.Combine(unzipPath, Path.GetFileNameWithoutExtension(((Object)_asset).name));
			File.WriteAllBytes(filePath, _asset.bytes);
			i++;
			if (i % 3 == 0)
			{
				yield return null;
			}
		}
		Addressables.Release<IList<TextAsset>>(_handler);
		Addressables.Release<IList<IResourceLocation>>(_locationHandle);
		Loaded_Fake_Story0011_BattleId = true;
		Has_Fake_Story0011_BattleId = true;
	}

	private IEnumerator CheckAllFileMD5(CheckVersionResult _result)
	{
		List<string> _list_file_key = _result.server_version_list.Keys.ToList();
		for (int i = 0; i < _list_file_key.Count; i++)
		{
			HotUpdateFileInfo _fileinfo = _result.server_version_list[_list_file_key[i]];
			if (!(_fileinfo.key == "Version.xml"))
			{
				string md5 = HotFixUtils.GetFileMD5(AssetsHelper.AssetBundleFilePath + _fileinfo.key);
				if (string.IsNullOrEmpty(md5) || md5.ToLower() != _fileinfo.md5)
				{
					ILRuntimeDebug.LogError("资源文件校验失败 {0} {1} {2}", _fileinfo.local_path, _fileinfo.md5, md5);
					PlayerPrefs.SetString("HotUpdateFlag", string.Empty);
					yield return ((MonoBehaviour)this).StartCoroutine(Pop(GetTipText("TIPS_UPDATE_CHECKSUM_FAILED")));
					yield return false;
					yield break;
				}
				if (i % 5 == 0)
				{
					yield return ((MonoBehaviour)this).StartCoroutine(ProcessCheckAllBar((float)i / (float)_list_file_key.Count));
				}
			}
		}
		yield return ((MonoBehaviour)this).StartCoroutine(ProcessCheckAllBar(1f));
		yield return true;
	}

	private IEnumerator CheckUpdatedFileMD5(CheckVersionResult _result)
	{
		List<HotUpdateFileInfo> checkList = _result.WaitToUpdate;
		int totalCheck = checkList.Count;
		for (int i = 0; i < totalCheck; i++)
		{
			HotUpdateFileInfo _fileInfo = checkList[i];
			if (!(_fileInfo.key == "Version.xml"))
			{
				string filePath = AssetsHelper.AssetBundleFilePath + _fileInfo.key;
				bool fileExists = File.Exists(filePath);
				string localFileMd5 = (fileExists ? HotFixUtils.GetFileMD5(filePath) : null);
				if (!fileExists || localFileMd5?.ToLower() != _fileInfo.md5)
				{
					ILRuntimeDebug.LogError("[热更] " + _fileInfo.key + " 资源文件校验失败 LocalVersionMd5=" + localFileMd5 + ", ServerVersionMd5=" + _fileInfo.md5);
					PlayerPrefs.SetString("HotUpdateFlag", string.Empty);
					yield return ((MonoBehaviour)this).StartCoroutine(Pop(GetTipText("TIPS_UPDATE_CHECKSUM_FAILED")));
					yield return false;
					yield break;
				}
				if (i % 5 == 0)
				{
					yield return ProcessCheckAllBar((float)i / (float)totalCheck);
				}
			}
		}
		yield return ProcessCheckAllBar(1f);
		yield return true;
	}

	private IEnumerator Download_NeedToUpdateFiles(List<HotUpdateFileInfo> file_list, long total_bytes)
	{
		int download_size = 0;
		for (int i = 0; i < file_list.Count; i++)
		{
			int last_downloadedBytes = 0;
			HotUpdateFileInfo _finfo = file_list[i];
			UnityWebRequest uwr = UnityWebRequest.Get(_finfo.server_path);
			uwr.SendWebRequest();
			while (uwr.downloadProgress < 1f || uwr.isNetworkError || uwr.isHttpError)
			{
				if (uwr.isNetworkError || uwr.isHttpError)
				{
					uwr.Dispose();
					uwr = UnityWebRequest.Get(_finfo.backup_server_path);
					uwr.SendWebRequest();
					while (uwr.downloadProgress < 1f)
					{
						if (uwr.isNetworkError || uwr.isHttpError)
						{
							ILRuntimeDebug.LogError(uwr.error);
							ILRuntimeDebug.LogError("[热更] Download_NeedToUpdateFiles  error=" + uwr.error + " , URL = " + _finfo.backup_server_path);
							UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.ResourcesUpdate, new UserTrackData_ResourcesUpdate
							{
								Success = false
							});
							yield return ((MonoBehaviour)this).StartCoroutine(Pop(string.Format(GetTipText("TIPS_UPDATE_FAILED_6"), uwr.error)));
							((MonoBehaviour)this).StopAllCoroutines();
							yield break;
						}
					}
				}
				download_size += (int)uwr.downloadedBytes - last_downloadedBytes;
				last_downloadedBytes = (int)uwr.downloadedBytes;
				yield return ((MonoBehaviour)this).StartCoroutine(ProcessResourceBar(download_size, total_bytes));
			}
			if (uwr.downloadProgress >= 1f)
			{
				download_size += (int)uwr.downloadedBytes - last_downloadedBytes;
			}
			string localPath = AssetsHelper.AssetBundleFilePath + _finfo.key;
			AssetsHelper.CheckFolder(AssetsHelper.GetPath(localPath));
			FileStream stream = new FileStream(localPath, FileMode.OpenOrCreate);
			stream.SetLength(0L);
			stream.Flush();
			stream.Write(uwr.downloadHandler.data, 0, uwr.downloadHandler.data.Length);
			stream.Flush();
			stream.Close();
			stream.Dispose();
			uwr.Dispose();
		}
		UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.ResourcesUpdate, new UserTrackData_ResourcesUpdate
		{
			Success = true
		});
		yield return ((MonoBehaviour)this).StartCoroutine(ProcessResourceBar(download_size, total_bytes));
	}

	private IEnumerator Download_NeedToUpdateFiles_New(List<HotUpdateFileInfo> file_list, long total_bytes)
	{
		int download_size = 0;
		for (int i = 0; i < file_list.Count; i++)
		{
			int last_downloadedBytes = 0;
			HotUpdateFileInfo _finfo = file_list[i];
			UnityWebRequest uwr = UnityWebRequest.Get(_finfo.server_path);
			uwr.SendWebRequest();
			while (uwr.downloadProgress < 1f || uwr.isNetworkError || uwr.isHttpError)
			{
				if (uwr.isNetworkError || uwr.isHttpError)
				{
					uwr.Dispose();
					uwr = UnityWebRequest.Get(_finfo.backup_server_path);
					uwr.SendWebRequest();
					while (uwr.downloadProgress < 1f)
					{
						if (uwr.isNetworkError || uwr.isHttpError)
						{
							ILRuntimeDebug.LogError(uwr.error);
							ILRuntimeDebug.LogError("[热更] Download_NeedToUpdateFiles  error=" + uwr.error + " , URL = " + _finfo.backup_server_path);
							UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.ResourcesUpdate, new UserTrackData_ResourcesUpdate
							{
								Success = false
							});
							yield return ((MonoBehaviour)this).StartCoroutine(Pop(string.Format(GetTipText("TIPS_UPDATE_FAILED_6"), uwr.error)));
							((MonoBehaviour)this).StopAllCoroutines();
							yield break;
						}
					}
				}
				download_size += (int)uwr.downloadedBytes - last_downloadedBytes;
				last_downloadedBytes = (int)uwr.downloadedBytes;
				yield return ((MonoBehaviour)this).StartCoroutine(ProcessResourceBar(download_size, total_bytes));
			}
			if (uwr.downloadProgress >= 1f)
			{
				download_size += (int)uwr.downloadedBytes - last_downloadedBytes;
			}
			string localPath = AssetsHelper.AssetBundleFilePath + _finfo.key;
			AssetsHelper.CheckFolder(AssetsHelper.GetPath(localPath));
			FileStream stream = new FileStream(localPath, FileMode.OpenOrCreate);
			stream.SetLength(0L);
			stream.Flush();
			stream.Write(uwr.downloadHandler.data, 0, uwr.downloadHandler.data.Length);
			stream.Flush();
			stream.Close();
			stream.Dispose();
			uwr.Dispose();
		}
		UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.ResourcesUpdate, new UserTrackData_ResourcesUpdate
		{
			Success = true
		});
		yield return ((MonoBehaviour)this).StartCoroutine(ProcessResourceBar(download_size, total_bytes));
	}

	private IEnumerator Download_Dll(CheckDllResult _CheckDllResult)
	{
		string floder_path = Application.persistentDataPath + "/IdleLegionHotFixDll_" + _CheckDllResult.server_hotfixdll_md5 + "/";
		string last_floder_path = Application.persistentDataPath + "/IdleLegionHotFixDll_" + _CheckDllResult.local_hotfixdll_md5 + "/";
		UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_5"));
		if (!Directory.Exists(floder_path))
		{
			Directory.CreateDirectory(floder_path);
		}
		bool isDownloadSucess = true;
		string download_hotfixdll_path = floder_path + "HotFix.dll.bin";
		UnityWebRequest req_dll = UnityWebRequest.Get(AssetsHelper.HotFix_dll);
		req_dll.SendWebRequest();
		while (req_dll.downloadProgress < 1f)
		{
			yield return ((MonoBehaviour)this).StartCoroutine(ProcessDLlBar(req_dll.downloadProgress));
			if (req_dll.isNetworkError || req_dll.isHttpError)
			{
				ILRuntimeDebug.LogError("[热更] 获取热更DLL失败!  error=" + req_dll.error + " , URL = " + AssetsHelper.HotFix_dll);
				UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_6"));
				isDownloadSucess = false;
				break;
			}
		}
		if (!isDownloadSucess)
		{
			ILRuntimeDebug.LogError("[热更] 再尝试一次备用CDN! , URL = " + AssetsHelper.BackupHotFix_dll);
			req_dll.Dispose();
			req_dll = UnityWebRequest.Get(AssetsHelper.BackupHotFix_dll);
			req_dll.SendWebRequest();
			while (req_dll.downloadProgress < 1f)
			{
				yield return ((MonoBehaviour)this).StartCoroutine(ProcessDLlBar(req_dll.downloadProgress));
				if (req_dll.isNetworkError || req_dll.isHttpError)
				{
					ILRuntimeDebug.LogError("[热更] 获取备用CDN热更DLL失败!  error=" + req_dll.error + " , URL = " + AssetsHelper.BackupHotFix_dll);
					UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_7"));
					yield return ((MonoBehaviour)this).StartCoroutine(Pop(GetTipText("TIPS_UPDATE_FAILED_7")));
					((MonoBehaviour)this).StopAllCoroutines();
					yield break;
				}
			}
		}
		yield return ((MonoBehaviour)this).StartCoroutine(ProcessDLlBar(req_dll.downloadProgress));
		FileStream stream = new FileStream(download_hotfixdll_path, FileMode.OpenOrCreate);
		stream.SetLength(0L);
		stream.Flush();
		stream.Write(req_dll.downloadHandler.data, 0, req_dll.downloadHandler.data.Length);
		stream.Flush();
		stream.Close();
		stream.Dispose();
		string save_path = "file://" + download_hotfixdll_path;
		string download_md5 = HotFix_Utils.CreateMD5(req_dll.downloadHandler.data);
		UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_8"));
		if (!download_md5.Equals(_CheckDllResult.server_hotfixdll_md5))
		{
			yield return ((MonoBehaviour)this).StartCoroutine(Pop(GetTipText("TIPS_UPDATE_FAILED_8")));
			yield break;
		}
		PlayerPrefs.SetString("hotfixdll_string", save_path);
		PlayerPrefs.SetString("hotfixdll_md5", download_md5);
		UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_9"));
		string need_to_del = PlayerPrefs.GetString("hotfix_last_dll_need_to_delete");
		if (Directory.Exists(need_to_del))
		{
			Directory.Delete(need_to_del, recursive: true);
		}
		PlayerPrefs.SetString("hotfix_last_dll_need_to_delete", last_floder_path);
	}

	private IEnumerator CheckForceUpdate()
	{
		string resbase_path = Instance.Configs["ResUrl"];
		string backresbase_path = Instance.Configs["BackupResUrl"];
		CoroutineWithData cd_force_update = new CoroutineWithData((MonoBehaviour)(object)this, DownloadFile(resbase_path + "version.json", add_random: true));
		yield return cd_force_update.Coroutine;
		if (cd_force_update.Result == null)
		{
			cd_force_update = new CoroutineWithData((MonoBehaviour)(object)this, DownloadFile(backresbase_path + "version.json", add_random: true));
			yield return cd_force_update.Coroutine;
			if (cd_force_update.Result == null)
			{
				UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.NeedForceUpdate, new UserTrackData_NeedForceUpdate
				{
					ForceUpdate = false,
					CheckSuccess = false
				});
				ILRuntimeDebug.LogError("[热更] 没有version.json文件");
				yield return Pop(GetTipText("TIPS_UPDATE_FAILED_9"));
				((MonoBehaviour)this).StopAllCoroutines();
				yield break;
			}
		}
		string json = ((DownloadHandler)cd_force_update.Result).text;
		List<ForceUpdateConfig> _updates = JsonHelper.ToObject<List<ForceUpdateConfig>>(json);
		ForceUpdateConfig _update = _updates[0];
		if (_update.ForceUpdate && _update.Version != Application.version)
		{
			UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.NeedForceUpdate, new UserTrackData_NeedForceUpdate
			{
				ForceUpdate = true,
				CheckSuccess = true
			});
			string tip = _update.Tip;
			if (tip.StartsWith("{"))
			{
				Dictionary<string, string> dic = JsonHelper.ToObject<Dictionary<string, string>>(tip);
				tip = ((!dic.TryGetValue(LanguageKey, out var value)) ? dic["eng"] : value);
			}
			yield return Pop(tip, delegate
			{
				if (!JumpInternationalStore())
				{
					if (ChannelCode == "tapplay")
					{
						UiHelper.OpenUrl(_update.UpdateAddress);
					}
					else if (ChannelCode == "taptap")
					{
						UiHelper.OpenUrl(_update.UpdateAddress);
					}
					else
					{
						UiHelper.OpenUrl(_update.UpdateAddress);
					}
				}
			});
			((MonoBehaviour)this).StopAllCoroutines();
		}
		else
		{
			UserTrackHelper.Instance?.TrackEvent(UserTrackEvent.NeedForceUpdate, new UserTrackData_NeedForceUpdate
			{
				ForceUpdate = false,
				CheckSuccess = true
			});
		}
	}

	private IEnumerator GetResourceDiff()
	{
		CheckVersionResult result = new CheckVersionResult();
		CoroutineWithData cd_server_version = new CoroutineWithData((MonoBehaviour)(object)this, DownloadFile(AssetsHelper.GetServerPath("Version.xml")));
		yield return cd_server_version.Coroutine;
		if (cd_server_version.Result == null)
		{
			ILRuntimeDebug.LogError("[热更] 尝试备份CDN , 开始下载 Version.XML");
			cd_server_version = new CoroutineWithData((MonoBehaviour)(object)this, DownloadFile(AssetsHelper.GetBackupServerPath("Version.xml")));
			yield return cd_server_version.Coroutine;
			if (cd_server_version.Result == null)
			{
				ILRuntimeDebug.LogError("[热更] 下载Version文件失败！");
				yield return Pop(string.Format(GetTipText("TIPS_UPDATE_FAILED_2")));
				((MonoBehaviour)this).StopAllCoroutines();
				yield break;
			}
		}
		result.server_version_content = ((DownloadHandler)cd_server_version.Result).text;
		result.server_version_md5 = HotFix_Utils.CreateMD5(result.server_version_content);
		string local_version_path = AssetsHelper.GetLocalPath("Version.xml");
		CoroutineWithData cd_local_version = new CoroutineWithData((MonoBehaviour)(object)this, DownloadFile(local_version_path));
		yield return cd_local_version.Coroutine;
		result.local_version_content = ((DownloadHandler)cd_local_version.Result).text;
		result.local_version_md5 = HotFix_Utils.CreateMD5(result.local_version_content);
		if (!result.isSame)
		{
			foreach (string _server_fpath in result.server_version_list.Keys)
			{
				if (result.local_version_list.ContainsKey(_server_fpath))
				{
					if (result.local_version_list[_server_fpath].md5 != result.server_version_list[_server_fpath].md5)
					{
						result.AddWaitToUpdate(result.server_version_list[_server_fpath]);
					}
				}
				else
				{
					result.AddWaitToUpdate(result.server_version_list[_server_fpath]);
				}
			}
		}
		yield return result;
	}

	private IEnumerator GetResourceDiff_New()
	{
		CheckVersionResult result = new CheckVersionResult();
		CoroutineWithData cd_server_version = new CoroutineWithData((MonoBehaviour)(object)this, DownloadFile(AssetsHelper.GetServerPath("Version.xml")));
		yield return cd_server_version.Coroutine;
		if (cd_server_version.Result == null)
		{
			ILRuntimeDebug.LogError("[热更] 尝试备份CDN , 开始下载 Version.XML");
			cd_server_version = new CoroutineWithData((MonoBehaviour)(object)this, DownloadFile(AssetsHelper.GetBackupServerPath("Version.xml")));
			yield return cd_server_version.Coroutine;
			if (cd_server_version.Result == null)
			{
				ILRuntimeDebug.LogError("[热更] 下载Version文件失败！");
				yield return Pop(string.Format(GetTipText("TIPS_UPDATE_FAILED_2")));
				((MonoBehaviour)this).StopAllCoroutines();
				yield break;
			}
		}
		result.server_version_content = ((DownloadHandler)cd_server_version.Result).text;
		result.server_version_md5 = HotFix_Utils.CreateMD5(result.server_version_content);
		CoroutineWithData cd_local_version = new CoroutineWithData((MonoBehaviour)(object)this, AssetsHelper.DownloadIntegratedVersionXml());
		yield return cd_local_version.Coroutine;
		result.local_version_content = (string)cd_local_version.Result;
		result.local_version_md5 = HotFix_Utils.CreateMD5(result.local_version_content);
		bool isAddressablesSame = false;
		string catalogHashPathKey = "Addressables/catalog_1.hash";
		if (result.server_version_list.TryGetValue(catalogHashPathKey, out var serverCatalogHashFileInfo))
		{
			string localCatalogHashPath = AssetsHelper.AssetBundleFilePath + catalogHashPathKey;
			if (File.Exists(localCatalogHashPath))
			{
				string localCatalogHashMd5 = HotFixUtils.GetFileMD5(localCatalogHashPath).ToLower();
				isAddressablesSame = localCatalogHashMd5 == serverCatalogHashFileInfo.md5;
			}
		}
		List<string> hotfixResPathList = new List<string>();
		if (!result.isSame || !isAddressablesSame)
		{
			foreach (KeyValuePair<string, HotUpdateFileInfo> serverFileInfoKv in result.server_version_list)
			{
				string fpath = serverFileInfoKv.Key;
				HotUpdateFileInfo serverFileInfo = serverFileInfoKv.Value;
				if (fpath.StartsWith("Addressables/"))
				{
					string localFilePath = AssetsHelper.AssetBundleFilePath + fpath;
					string localFileMd5 = (File.Exists(localFilePath) ? HotFixUtils.GetFileMD5(localFilePath).ToLower() : null);
					if (localFileMd5 != serverFileInfo.md5)
					{
						result.AddWaitToUpdate(serverFileInfo);
					}
					continue;
				}
				HotUpdateFileInfo internalFileInfo = null;
				if (result.local_version_list.TryGetValue(fpath, out internalFileInfo) && !(internalFileInfo.md5 != serverFileInfo.md5))
				{
					continue;
				}
				hotfixResPathList.Add(fpath);
				string localFilePath2 = AssetsHelper.AssetBundleFilePath + fpath;
				if (!File.Exists(localFilePath2))
				{
					result.AddWaitToUpdate(serverFileInfo);
					continue;
				}
				string localFileMd6 = HotFixUtils.GetFileMD5(localFilePath2).ToLower();
				if (serverFileInfo.md5 != localFileMd6)
				{
					result.AddWaitToUpdate(serverFileInfo);
				}
			}
		}
		GameLocalDataManager.SetHotFixResPathList(hotfixResPathList);
		yield return result;
	}

	private IEnumerator CheckIsDLLSame()
	{
		CheckDllResult result = new CheckDllResult
		{
			server_hotfixdll_md5 = string.Empty,
			local_hotfixdll_md5 = PlayerPrefs.GetString("hotfixdll_md5")
		};
		string local_hotfixdll_string = PlayerPrefs.GetString("hotfixdll_string");
		if ((int)Application.platform == 8 && local_hotfixdll_string.StartsWith(Application.persistentDataPath))
		{
			string local_hotfixdll_path = Application.persistentDataPath + "/IdleLegionHotFixDll_" + result.local_hotfixdll_md5 + "/";
			UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_1"));
			if (!Directory.Exists(local_hotfixdll_path))
			{
				yield return result;
				yield break;
			}
		}
		UnityWebRequest req = UnityWebRequest.Get(AssetsHelper.HotFix_CodeVersion);
		yield return req.SendWebRequest();
		if (req.isNetworkError || req.isHttpError)
		{
			ILRuntimeDebug.LogError("[热更] 获取热更MD5失败!  error=" + req.error + " , URL = " + AssetsHelper.HotFix_CodeVersion);
			ILRuntimeDebug.LogError("[热更] 尝试备用CDN , URL = " + AssetsHelper.BackupHotFix_CodeVersion);
			UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_10"));
			req.Dispose();
			req = UnityWebRequest.Get(AssetsHelper.BackupHotFix_CodeVersion);
			yield return req.SendWebRequest();
			if (req.isNetworkError || req.isHttpError)
			{
				ILRuntimeDebug.LogError("[热更] 尝试备用CDN失败  error=" + req.error + " , URL = " + AssetsHelper.BackupHotFix_CodeVersion);
				UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_11"));
				yield return result;
				yield break;
			}
		}
		string remote_md5 = req.downloadHandler.text;
		result.server_hotfixdll_md5 = remote_md5.Replace("\n", "").Replace("\r", "").Replace(" ", "");
		bool isLocalDLL = false;
		if (string.IsNullOrEmpty(result.local_hotfixdll_md5))
		{
			string local_version_ver_path = HotFix_Utils.GetLocalVersionVerURL();
			UnityWebRequest req_version_ver_path = UnityWebRequest.Get(local_version_ver_path);
			yield return req_version_ver_path.SendWebRequest();
			if (req_version_ver_path.isNetworkError || req_version_ver_path.isHttpError)
			{
				result.local_hotfixdll_md5 = string.Empty;
				UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_12"));
				yield return result;
				yield break;
			}
			result.local_hotfixdll_md5 = req_version_ver_path.downloadHandler.text;
			result.local_hotfixdll_md5 = result.local_hotfixdll_md5.Replace("\n", "").Replace("\r", "").Replace(" ", "");
			isLocalDLL = true;
			DllMd5 = result.local_hotfixdll_md5;
			UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_13"));
		}
		if (!string.IsNullOrEmpty(result.local_hotfixdll_md5) && !isLocalDLL)
		{
			DllMd5 = result.local_hotfixdll_md5;
			string floder_path = Application.persistentDataPath + "/IdleLegionHotFixDll_" + result.local_hotfixdll_md5 + "/";
			string download_hotfixdll_path = floder_path + "HotFix.dll.bin";
			string cur_MD5 = "file://" + download_hotfixdll_path;
			UnityWebRequest req_cur_MD5 = UnityWebRequest.Get(cur_MD5);
			yield return req_cur_MD5.SendWebRequest();
			if (req_cur_MD5.isNetworkError || req_cur_MD5.isHttpError)
			{
				result.local_hotfixdll_md5 = string.Empty;
				ILRuntimeDebug.LogError("[热更] 获取本地热更dll失败 ", cur_MD5);
				UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_14"));
				yield return result;
				yield break;
			}
			string cur_use_md5 = HotFix_Utils.CreateMD5(req_cur_MD5.downloadHandler.data);
			UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_15"));
			if (!cur_use_md5.Equals(result.local_hotfixdll_md5))
			{
				ILRuntimeDebug.LogError("[热更] 本地使用的dll的MD5 和 本地记录的MD5 不匹配");
				UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_16"));
				yield return result;
				yield break;
			}
		}
		yield return result;
	}

	private bool MainVersionUpdate()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		if ((int)Application.platform == 0 || (int)Application.platform == 7)
		{
			return false;
		}
		string value = PlayerPrefs.GetString("hotfixdll_string");
		if (!string.IsNullOrEmpty(value))
		{
			return true;
		}
		string value2 = PlayerPrefs.GetString("hotfixpdb_string");
		if (!string.IsNullOrEmpty(value2))
		{
			return true;
		}
		string value3 = PlayerPrefs.GetString("HotUpdateFlag");
		if (!string.IsNullOrEmpty(value3))
		{
			return true;
		}
		if (File.Exists(AssetsHelper.vFile))
		{
			string text = File.ReadAllText(AssetsHelper.vFile).Trim();
			if (Application.version != text)
			{
				return true;
			}
		}
		return false;
	}

	private bool CheckIsFirst()
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Invalid comparison between Unknown and I4
		if (HasPreloadBeforeUnity)
		{
			if ("taptap" == ChannelCode || "tapplay" == ChannelCode)
			{
				return IsTapTapFirst();
			}
			if ("toutiao-android" == ChannelCode)
			{
				return IsToutiaoFirst();
			}
			if ("gdt-android" == ChannelCode)
			{
				return IsGDTFirst();
			}
		}
		if ((int)Application.platform == 0 || (int)Application.platform == 7)
		{
			return false;
		}
		if (string.IsNullOrEmpty(PlayerPrefs.GetString("HotUpdateFlag", string.Empty)))
		{
			return true;
		}
		if (!Directory.Exists(AssetsHelper.AssetBundleFilePath))
		{
			return true;
		}
		if (!File.Exists(AssetsHelper.vFile))
		{
			return true;
		}
		string text = File.ReadAllText(AssetsHelper.vFile).Trim();
		if (Application.version != text)
		{
			return true;
		}
		return false;
	}

	private IEnumerator InstallAssets()
	{
		UpdateBar(0f, GetTipText("TIPS_INSTALL_RESOURCES") + " 0%");
		yield return null;
		yield return InstallAddressables();
		UpdateBar(1f, GetTipText("TIPS_INSTALL_RESOURCES") + " 100%");
		yield return null;
	}

	private IEnumerator InstallAddressables()
	{
		AssetsHelper.CheckFolder(AssetsHelper.AssetBundleFilePath + "Addressables/");
		CoroutineWithData downloadCoroutine = new CoroutineWithData((MonoBehaviour)(object)this, AssetsHelper.DownloadIntegratedVersionXml());
		yield return downloadCoroutine.Coroutine;
		XmlDocument doc = new XmlDocument();
		doc.LoadXml((string)downloadCoroutine.Result);
		XmlNodeList fileElements = doc.DocumentElement.GetElementsByTagName("file");
		int totalElements = fileElements.Count;
		int i = 0;
		while (i < totalElements)
		{
			XmlNode fileEle = fileElements[i];
			i++;
			if (i % 10 == 0)
			{
				yield return ProcessInstallResBar(i, totalElements);
			}
			if (fileEle is XmlElement ele)
			{
				string path = ele.GetAttribute("fpath");
				if (path.StartsWith("Addressables/"))
				{
					yield return CopyStreamingAssetToPersistentDataPath(path);
				}
			}
		}
	}

	private IEnumerator CopyStreamingAssetToPersistentDataPath(string fileName)
	{
		string oldFilePath = (((int)Application.platform != 11) ? ("file://" + Application.streamingAssetsPath + "/AssetBundles/" + fileName) : (Application.streamingAssetsPath + "/AssetBundles/" + fileName));
		string newFilePath = Application.persistentDataPath + "/AssetBundles/" + fileName;
		UnityWebRequest uwr = UnityWebRequest.Get(oldFilePath);
		yield return uwr.SendWebRequest();
		if (!uwr.isNetworkError && !uwr.isHttpError)
		{
			FileStream fs = new FileStream(newFilePath, FileMode.OpenOrCreate);
			fs.SetLength(0L);
			fs.Flush();
			fs.Write(uwr.downloadHandler.data, 0, uwr.downloadHandler.data.Length);
			fs.Flush();
			fs.Close();
			fs.Dispose();
			uwr.Dispose();
		}
	}

	private IEnumerator InternalCopyAssetsToPersistentFolder()
	{
		bool result = false;
		Action<float> Unzip_Action = delegate(float _per)
		{
			string tipText = GetTipText("UpdateBar4");
			float num = _per * 100f;
			UpdateBar(_per, string.Format(tipText, num));
		};
		string targetPath = Application.persistentDataPath + "/AssetBundles";
		string sourcePkg = Application.streamingAssetsPath + "/AssetBundles.zip";
		if ((int)Application.platform == 0 || (int)Application.platform == 7 || (int)Application.platform == 2)
		{
			string folder = string.Empty;
			if ((int)Application.platform == 0)
			{
				folder = "MacOS";
			}
			else if ((int)Application.platform == 7 || (int)Application.platform == 2)
			{
				folder = "PC";
			}
			else
			{
				ILRuntimeDebug.LogError("不支持的平台");
			}
			sourcePkg = Path.Combine(Application.dataPath, "..", "AssetBundles", folder);
			HotFix_Utils.CloneDirectory(sourcePkg, targetPath);
			yield return null;
		}
		else if ((int)Application.platform == 11)
		{
			string tmpPkg = Application.persistentDataPath + "/AssetBundles.zip";
			UnityWebRequest uwr = new UnityWebRequest(sourcePkg);
			uwr.method = "GET";
			bool ctrateZipFileSuccess = true;
			try
			{
				DownloadHandlerFile dh = new DownloadHandlerFile(tmpPkg);
				dh.removeFileOnAbort = true;
				uwr.downloadHandler = (DownloadHandler)(object)dh;
			}
			catch (Exception)
			{
				ILRuntimeDebug.LogError("创建DownloadHandlerFile失败！");
				ctrateZipFileSuccess = false;
				if (File.Exists(tmpPkg))
				{
					File.Delete(tmpPkg);
				}
			}
			if (ctrateZipFileSuccess)
			{
				yield return uwr.SendWebRequest();
				if (uwr.isNetworkError || uwr.isHttpError)
				{
					yield return false;
					yield break;
				}
				CoroutineWithData cd_unzip = new CoroutineWithData((MonoBehaviour)(object)this, ZipHelper.AsyncUnZip(tmpPkg, targetPath, Unzip_Action));
				yield return cd_unzip.Coroutine;
				result = (bool)cd_unzip.Result;
				File.Delete(tmpPkg);
			}
			else
			{
				uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
				yield return uwr.SendWebRequest();
				if (uwr.isNetworkError || uwr.isHttpError)
				{
					yield return false;
					yield break;
				}
				CoroutineWithData cd_unzip2 = new CoroutineWithData((MonoBehaviour)(object)this, ZipHelper.AsyncUnZip(uwr.downloadHandler.data, targetPath, Unzip_Action));
				yield return cd_unzip2.Coroutine;
				result = (bool)cd_unzip2.Result;
			}
		}
		else
		{
			if (!File.Exists(sourcePkg))
			{
				yield return false;
				yield break;
			}
			CoroutineWithData cd_unzip3 = new CoroutineWithData((MonoBehaviour)(object)this, ZipHelper.AsyncUnZip(sourcePkg, targetPath, Unzip_Action));
			yield return cd_unzip3.Coroutine;
			result = (bool)cd_unzip3.Result;
		}
		yield return result;
	}

	private IEnumerator DownloadFile(string url, bool add_random = false, int timeout = 60)
	{
		if (add_random)
		{
			url = url + "?t=" + URL_RANDOM_STAMP;
		}
		UnityWebRequest request = UnityWebRequest.Get(url);
		request.timeout = timeout;
		yield return request.SendWebRequest();
		Result result = request.result;
		Result val = result;
		switch (val - 1)
		{
		case 0:
			yield return request.downloadHandler;
			break;
		case 1:
			ILRuntimeDebug.LogError("[热更] 网络连接错误！地址：" + url + ", 错误：" + request.error);
			request.Dispose();
			yield return null;
			break;
		case 2:
			ILRuntimeDebug.LogError($"[热更] HTTP协议错误！地址：{url}, 状态码：{request.responseCode}, 错误：{request.error}");
			request.Dispose();
			yield return null;
			break;
		case 3:
			ILRuntimeDebug.LogError("[热更] 数据处理错误！地址：" + url + ", 错误：" + request.error);
			request.Dispose();
			yield return null;
			break;
		default:
			ILRuntimeDebug.LogError("[热更] 未知下载错误！地址：" + url + ", 错误：" + request.error);
			request.Dispose();
			yield return null;
			break;
		}
	}

	private IEnumerator HealthCheck(string addr)
	{
		float total_ping_cost = 0f;
		yield return null;
		string url_healthcheck = $"https://{addr}/Server/HealthCheck";
		int avg_cnt = 4;
		for (int i = 0; i < 4; i++)
		{
			long ms = DateTimeHelper.Now.ToUnixTimeMilliseconds();
			UnityWebRequest uwr = UnityWebRequest.Get(url_healthcheck);
			uwr.timeout = 3;
			yield return uwr.SendWebRequest();
			if (uwr.isNetworkError || uwr.isHttpError)
			{
				total_ping_cost += 3000f;
				continue;
			}
			if (i == 0)
			{
				avg_cnt--;
				continue;
			}
			float diff = DateTimeHelper.Now.ToUnixTimeMilliseconds() - ms;
			total_ping_cost += diff;
		}
		float avg = total_ping_cost / (float)avg_cnt;
		if (!PingResult.ContainsKey(addr))
		{
			PingResult.Add(addr, avg);
		}
		else
		{
			PingResult[addr] = avg;
		}
	}

	private IEnumerator FindBestGateway()
	{
		UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_19"));
		if (BestGatewayFound)
		{
			UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_24"));
			yield break;
		}
		if (!Configs.ContainsKey("GatewayInfo"))
		{
			GatewayHeader = "";
			GatewayCost = "";
			BestGatewayFound = true;
			UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_20"));
			yield break;
		}
		string GatewayInfos = Configs["GatewayInfo"];
		string[] dict_ip_domain = GatewayInfos.Split(',');
		PingResult = new Dictionary<string, float>();
		List<Coroutine> list_Coroutine = new List<Coroutine>();
		if (dict_ip_domain.Length == 1)
		{
			string gateway = dict_ip_domain[0];
			Configs["AuthServerUrl"] = string.Format(Configs["AuthServerUrl"], gateway);
			Configs["GameServerUrl"] = string.Format(Configs["GameServerUrl"], gateway);
			GatewayHeader = gateway.Split('.')[0];
			GatewayCost = "";
			BestGatewayFound = true;
			UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_21"));
			yield break;
		}
		string[] array = dict_ip_domain;
		foreach (string _addr in array)
		{
			list_Coroutine.Add(((MonoBehaviour)this).StartCoroutine(HealthCheck(_addr)));
		}
		UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_22"));
		while (PingResult.Count == 0)
		{
			yield return null;
		}
		foreach (Coroutine coroutine in list_Coroutine)
		{
			((MonoBehaviour)this).StopCoroutine(coroutine);
		}
		float min = 99999f;
		string min_addr = "";
		foreach (string addr in PingResult.Keys)
		{
			if (PingResult[addr] < min)
			{
				min = PingResult[addr];
				min_addr = addr;
			}
		}
		UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_23"));
		Configs["AuthServerUrl"] = string.Format(Configs["AuthServerUrl"], min_addr);
		Configs["GameServerUrl"] = string.Format(Configs["GameServerUrl"], min_addr);
		GatewayHeader = min_addr.Split('.')[0];
		GatewayCost = $"{min:N2}";
		BestGatewayFound = true;
		UpdateBar(1f, GetTipText("TIPS_UPDATE_CHECK_TEXT_2"));
	}

	private IEnumerator FindRegionURL()
	{
		int wait = 0;
		List<Coroutine> list_Coroutine = new List<Coroutine>();
		foreach (string _regionUrl in RegionUrls)
		{
			list_Coroutine.Add(((MonoBehaviour)this).StartCoroutine(_findRegionURL(_regionUrl, hasJsonSuffix: true)));
			list_Coroutine.Add(((MonoBehaviour)this).StartCoroutine(_findRegionURL(_regionUrl, hasJsonSuffix: false)));
		}
		while (RegionURLResult.Count == 0)
		{
			yield return (object)new WaitForSeconds(1f);
			wait++;
			int countDot = wait % 4;
			string str = GetTipText("TIPS_FINDING_REGIONURL");
			while (countDot > 0)
			{
				str += ".";
				countDot--;
			}
			UpdateBar(1f, str);
			if (wait > 35)
			{
				Log_FindRegionURL.Add("TimeOut", "TimeOut 30 seconds,but NoURLGet");
				yield break;
			}
			if (Log_FindRegionURL.Count == RegionUrls.Count * 2)
			{
				Log_FindRegionURL.Add("TimeOut", "All Region Error");
				yield break;
			}
		}
		foreach (Coroutine cor in list_Coroutine)
		{
			if (cor != null)
			{
				((MonoBehaviour)this).StopCoroutine(cor);
			}
		}
		BestRegionURL = RegionURLResult[0];
	}

	private IEnumerator _findRegionURL(string _regionUrl, bool hasJsonSuffix)
	{
		string regionFilePath = _regionUrl + "/zone/" + RegionKey + "_pro";
		if (!IsRegionOutCN)
		{
			regionFilePath = _regionUrl + "/zone/" + RegionKey;
		}
		if (hasJsonSuffix)
		{
			regionFilePath += ".json";
		}
		CoroutineWithData cd_regionFile = new CoroutineWithData((MonoBehaviour)(object)this, DownloadFile(regionFilePath, add_random: true, 30));
		yield return cd_regionFile.Coroutine;
		if (cd_regionFile.Result == null)
		{
			Log_FindRegionURL.Add(regionFilePath, "TimeOut for 30s");
		}
		else
		{
			RegionURLResult.Add(((DownloadHandler)cd_regionFile.Result).text);
		}
	}

	private IEnumerator GetBG()
	{
		string png_path = HotFix_Utils.GetpPrsistentDataURL("pic_login_bg_3.jpg");
		yield return ((MonoBehaviour)this).StartCoroutine(EnsureUIExist("pic_login_bg_3.jpg"));
		CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)this, HotFix_Utils.getTextureByPath(png_path));
		yield return cd.Coroutine;
		Texture2D _texture = (Texture2D)cd.Result;
		AddImageToCanvas(_texture, Vector2.zero, isBG: true, ((Texture)_texture).width, ((Texture)_texture).height, Vector3.one);
	}

	private GameObject AddImageToCanvas(Texture2D _texture, Vector2 pos, bool isBG, int width, int height, Vector3 scale)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject();
		val.transform.SetParent(go_Canvas.transform);
		val.transform.localScale = scale;
		Image val2 = val.AddComponent<Image>();
		val2.sprite = Sprite.Create(_texture, new Rect(0f, 0f, (float)width, (float)height), Vector2.zero);
		RectTransform component = val.GetComponent<RectTransform>();
		if (isBG)
		{
			component.anchorMin = new Vector2(0.5f, 0.5f);
			component.anchorMax = new Vector2(0.5f, 0.5f);
			component.pivot = new Vector2(0.5f, 0.5f);
			component.sizeDelta = new Vector2((float)width, (float)height);
			val.transform.localPosition = Vector2.op_Implicit(pos);
		}
		else
		{
			component.sizeDelta = new Vector2((float)width, (float)height);
			val.transform.localPosition = Vector2.op_Implicit(pos);
		}
		return val;
	}

	private GameObject AddImageToCanvas(Texture2D _texture, Vector2 pos, bool isBG, int width, int height, Vector4 border)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = new GameObject();
		val.transform.SetParent(go_Canvas.transform);
		val.transform.localScale = Vector3.one;
		Image val2 = val.AddComponent<Image>();
		val2.sprite = Sprite.Create(_texture, new Rect(0f, 0f, (float)width, (float)height), Vector2.zero, 100f, 0u, (SpriteMeshType)0, border);
		RectTransform component = val.GetComponent<RectTransform>();
		if (isBG)
		{
			component.anchorMin = new Vector2(0f, 0f);
			component.anchorMax = new Vector2(1f, 1f);
			component.pivot = new Vector2(0.5f, 0.5f);
			component.offsetMin = Vector2.zero;
			component.offsetMax = Vector2.zero;
		}
		else
		{
			component.sizeDelta = new Vector2((float)width, (float)height);
			val.transform.localPosition = Vector2.op_Implicit(pos);
		}
		return val;
	}

	private void ShowBar()
	{
		Go_BarBg.SetActive(true);
		Go_Bar.SetActive(true);
		Go_BarText.SetActive(true);
	}

	private void HideBar()
	{
		Go_BarBg.SetActive(false);
		Go_Bar.SetActive(false);
		Go_BarText.SetActive(false);
	}

	private void UpdateBar(float per, string str)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (!((Object)(object)Go_Bar == (Object)null) && Go_Bar.activeSelf)
		{
			Go_Bar.GetComponent<RectTransform>().sizeDelta = new Vector2(per * 0.9f * 1920f - 8f, 36f);
			Go_BarText.GetComponent<Text>().text = str;
		}
	}

	private IEnumerator OpenProcessBar(string str)
	{
		string bar_bg_path = HotFix_Utils.GetpPrsistentDataURL("bar_bg.png");
		yield return ((MonoBehaviour)this).StartCoroutine(EnsureUIExist("bar_bg.png"));
		CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)this, HotFix_Utils.getTextureByPath(bar_bg_path));
		yield return cd.Coroutine;
		Texture2D _texture_bar_bg = (Texture2D)cd.Result;
		Go_BarBg = AddImageToCanvas(_texture_bar_bg, Vector2.zero, isBG: false, 504, 40, new Vector4(9f, 9f, 8f, 10f));
		Go_BarBg.GetComponent<RectTransform>().sizeDelta = new Vector2(1728f, 40f);
		Go_BarBg.transform.localPosition = new Vector3(0f, -397f, 0f);
		string bar_path = HotFix_Utils.GetpPrsistentDataURL("green_bar.png");
		yield return ((MonoBehaviour)this).StartCoroutine(EnsureUIExist("green_bar.png"));
		CoroutineWithData cd_texture_bar = new CoroutineWithData((MonoBehaviour)(object)this, HotFix_Utils.getTextureByPath(bar_path));
		yield return cd_texture_bar.Coroutine;
		Texture2D _texture_bar = (Texture2D)cd_texture_bar.Result;
		Go_Bar = AddImageToCanvas(_texture_bar, Vector2.zero, isBG: false, 20, 36, new Vector4(9f, 9f, 8f, 10f));
		Go_Bar.GetComponent<Image>().type = (Type)1;
		Go_Bar.transform.SetParent(Go_BarBg.transform);
		RectTransform _rect_transform = Go_Bar.GetComponent<RectTransform>();
		_rect_transform.anchorMin = new Vector2(0f, 0.5f);
		_rect_transform.anchorMax = new Vector2(0f, 0.5f);
		_rect_transform.pivot = new Vector2(0f, 0.5f);
		_rect_transform.anchoredPosition = new Vector2(4f, 0f);
		Go_BarText = new GameObject();
		Text _text = Go_BarText.AddComponent<Text>();
		_text.text = str;
		_text.font = default_font;
		_text.fontSize = 30;
		_text.fontStyle = (FontStyle)0;
		((Graphic)_text).color = Color.white;
		Go_BarText.transform.SetParent(Go_BarBg.transform);
		Go_BarText.transform.localScale = Vector2.op_Implicit(Vector2.one);
		Go_BarText.transform.localPosition = new Vector3(0f, 45f, 0f);
		Go_BarText.GetComponent<RectTransform>().sizeDelta = new Vector2(1728f, Go_BarText.transform.localPosition.y);
	}

	private IEnumerator Pop(string str, Action action = null, int countdown = -1)
	{
		string back_bg_path = HotFix_Utils.GetpPrsistentDataURL("back_2.png");
		yield return ((MonoBehaviour)this).StartCoroutine(EnsureUIExist("back_2.png"));
		CoroutineWithData cd = new CoroutineWithData((MonoBehaviour)(object)this, HotFix_Utils.getTextureByPath(back_bg_path));
		yield return cd.Coroutine;
		Texture2D _texture_back_bg = (Texture2D)cd.Result;
		AddImageToCanvas(_texture_back_bg, Vector2.zero, isBG: true, ((Texture)_texture_back_bg).width, ((Texture)_texture_back_bg).height, new Vector3(2f, 2f, 1f));
		string pop_bg_path = HotFix_Utils.GetpPrsistentDataURL("frame_popup_black1.png");
		yield return ((MonoBehaviour)this).StartCoroutine(EnsureUIExist("frame_popup_black1.png"));
		CoroutineWithData cd_texture_pop_bg = new CoroutineWithData((MonoBehaviour)(object)this, HotFix_Utils.getTextureByPath(pop_bg_path));
		yield return cd_texture_pop_bg.Coroutine;
		Texture2D _texture_pop_bg = (Texture2D)cd_texture_pop_bg.Result;
		string confirmPath = "button_green1.png";
		if (IsRegionOutCN)
		{
			if (LanguageKey == "eng")
			{
				confirmPath = "button_green3_eng.png";
			}
			else if (LanguageKey == "zh_tc")
			{
				confirmPath = "button_green1_zh_tc.png";
			}
		}
		string btn_confirm_path = HotFix_Utils.GetpPrsistentDataURL(confirmPath);
		yield return ((MonoBehaviour)this).StartCoroutine(EnsureUIExist(confirmPath));
		CoroutineWithData cd__texture_btn_confirm = new CoroutineWithData((MonoBehaviour)(object)this, HotFix_Utils.getTextureByPath(btn_confirm_path));
		yield return cd__texture_btn_confirm.Coroutine;
		Texture2D _texture_btn_confirm = (Texture2D)cd__texture_btn_confirm.Result;
		GameObject go_pop = AddImageToCanvas(_texture_pop_bg, Vector2.zero, isBG: false, 888, 390, Vector3.one);
		GameObject go_text = new GameObject();
		go_text.transform.SetParent(go_pop.transform);
		go_text.transform.localScale = Vector2.op_Implicit(Vector2.one);
		UpdateBar(1f, GetTipText("UpdateBar6"));
		Text _text = go_text.AddComponent<Text>();
		_text.font = default_font;
		_text.resizeTextForBestFit = true;
		_text.fontSize = 46;
		_text.resizeTextMinSize = 40;
		_text.resizeTextMaxSize = 46;
		_text.alignment = (TextAnchor)4;
		_text.fontStyle = (FontStyle)0;
		((Graphic)_text).color = Color.white;
		_text.text = str;
		go_text.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 60f);
		go_text.GetComponent<RectTransform>().sizeDelta = new Vector2(800f, 190f);
		if (IsRegionOutCN && LanguageKey == "eng")
		{
			_text.resizeTextMinSize = 24;
			_text.resizeTextMaxSize = 46;
			_text.alignment = (TextAnchor)3;
			go_text.GetComponent<RectTransform>().anchoredPosition = new Vector2(13f, 60f);
			go_text.GetComponent<RectTransform>().sizeDelta = new Vector2(800f, 190f);
		}
		GameObject go_btn_confirm = AddImageToCanvas(_texture_btn_confirm, new Vector2(0f, -100f), isBG: false, 171, 92, Vector3.one);
		Button btn = go_btn_confirm.AddComponent<Button>();
		UpdateBar(1f, GetTipText("UpdateBar7"));
		UnityAction _click_event = (UnityAction)delegate
		{
			go_pop.SetActive(false);
			go_btn_confirm.SetActive(false);
			Object.DestroyImmediate((Object)(object)go_text);
			if ((Object)(object)_text != (Object)null)
			{
				_text.font = null;
			}
			if (action != null)
			{
				action();
			}
			else
			{
				HotFix_Utils.Restart();
			}
		};
		((UnityEvent)btn.onClick).AddListener(_click_event);
		((MonoBehaviour)this).StartCoroutine(AutoClickCountDown(countdown, go_pop, _click_event));
	}

	private IEnumerator AutoClickCountDown(int countdown, GameObject go_pop, UnityAction _click_event)
	{
		if (countdown <= 0)
		{
			yield break;
		}
		GameObject go_countdown_text = new GameObject();
		go_countdown_text.transform.SetParent(go_pop.transform);
		go_countdown_text.transform.localScale = Vector2.op_Implicit(Vector2.one);
		Text _countdown_text = go_countdown_text.AddComponent<Text>();
		_countdown_text.font = default_font;
		_countdown_text.resizeTextForBestFit = true;
		_countdown_text.fontSize = 28;
		_countdown_text.resizeTextMinSize = 28;
		_countdown_text.resizeTextMaxSize = 28;
		_countdown_text.alignment = (TextAnchor)4;
		_countdown_text.fontStyle = (FontStyle)0;
		((Graphic)_countdown_text).color = Color.red;
		go_countdown_text.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -25f);
		go_countdown_text.GetComponent<RectTransform>().sizeDelta = new Vector2(800f, 190f);
		string tip = GetTipText("UpdateBar8");
		for (int i = 0; i < countdown; i++)
		{
			if (tip.Contains("{0}"))
			{
				_countdown_text.text = string.Format(tip, countdown - i);
			}
			else
			{
				_countdown_text.text = $"{countdown - i}{tip}";
			}
			yield return (object)new WaitForSeconds(1f);
		}
		_countdown_text.font = null;
		_click_event.Invoke();
	}

	private IEnumerator ProcessInstallResBar(int installed, int total)
	{
		float rate = (float)installed / (float)total;
		string tipText = string.Format("{0} {1:N2}%", GetTipText("TIPS_INSTALL_RESOURCES"), rate * 100f);
		UpdateBar(rate, tipText);
		yield return null;
	}

	private IEnumerator ProcessResourceBar(int size, long total)
	{
		double kb_size = (double)size / 1048576.0;
		UpdateBar(str: string.Format(arg1: (double)total / 1048576.0, format: GetTipText("UpdateBar9"), arg0: kb_size), per: (float)size / (float)total);
		yield return (object)new WaitForSeconds(0.2f);
	}

	private IEnumerator ProcessDLlBar(float per)
	{
		string tipText = GetTipText("UpdateBar10");
		float arg0 = per * 100f;
		UpdateBar(per, string.Format(tipText, arg0));
		yield return (object)new WaitForSeconds(0.2f);
	}

	private IEnumerator ProcessCheckAllBar(float per)
	{
		string tipText = GetTipText("UpdateBar11");
		float arg0 = per * 100f;
		UpdateBar(per, string.Format(tipText, arg0));
		yield return null;
	}

	private IEnumerator EnsureUIExist(string ui)
	{
		string local_path = Application.persistentDataPath + "/" + ui;
		if (File.Exists(local_path))
		{
			yield break;
		}
		bool isSucess = false;
		Texture2D uiTexture = Resources.Load<Texture2D>("Image/LoginImage/" + ui.Replace(".png", ""));
		if ((Object)(object)uiTexture != (Object)null)
		{
			try
			{
				Texture2D newTexture = new Texture2D(((Texture)uiTexture).width, ((Texture)uiTexture).height, (TextureFormat)4, false);
				newTexture.SetPixels(uiTexture.GetPixels());
				newTexture.Apply();
				File.WriteAllBytes(local_path, ImageConversion.EncodeToPNG(newTexture));
			}
			catch (Exception ex)
			{
				Exception e = ex;
				ILRuntimeDebug.LogError($"[GameInitDebug]EnsureUIExist {ui}: {e}");
			}
			yield break;
		}
		for (int i = 0; i < UI_URL_Backups.Count; i++)
		{
			string URL_FMT = UI_URL_Backups[i];
			string ui_url = string.Format(URL_FMT, ui);
			UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(ui_url);
			yield return uwr.SendWebRequest();
			if (uwr.isNetworkError || uwr.isHttpError)
			{
				ILRuntimeDebug.LogError("[热更] 下载资源失败 " + ui + "，URL = " + ui_url + ", Error = " + uwr.error);
				continue;
			}
			File.WriteAllBytes(local_path, uwr.downloadHandler.data);
			isSucess = true;
			break;
		}
		if (!isSucess)
		{
			ILRuntimeDebug.LogError("[热更] 所有资源备份路径已尝试完毕，均下载失败");
			Text _connectionErrorText = ((Component)go_Canvas.transform.Find("ConnectionErrorTip")).GetComponent<Text>();
			((Component)_connectionErrorText).gameObject.SetActive(true);
			_connectionErrorText.text = GetTipText("TIPS_UPDATE_FAILED_10") + ui;
			if (SystemInfo.deviceModel.Contains("Xiaomi"))
			{
				_connectionErrorText.text = GetTipText("TIPS_UPDATE_FAILED_10_MIUI13");
			}
			Transform RestartBtn = go_Canvas.transform.Find("RestartBtn");
			((Component)RestartBtn).gameObject.SetActive(true);
			RestartBtn.position = new Vector3(0f, -370f, 0f);
			((UnityEvent)((Component)RestartBtn).GetComponent<Button>().onClick).AddListener((UnityAction)delegate
			{
				HotFix_Utils.Restart();
				((Component)RestartBtn).gameObject.SetActive(false);
			});
			((MonoBehaviour)this).StopAllCoroutines();
		}
	}

	private bool IsTapTapFirst()
	{
		if (!File.Exists(AssetsHelper.vFile))
		{
			if (HasTapAcceptTapPrivacy() && HasTapUnzip())
			{
				File.WriteAllText(AssetsHelper.vFile, Application.version);
				PlayerPrefs.SetString("HotUpdateFlag", string.Empty);
				PlayerPrefs.SetString("hotfixdll_string", string.Empty);
				PlayerPrefs.SetString("hotfixdll_md5", string.Empty);
				return false;
			}
			return true;
		}
		return false;
	}

	private bool HasTapAcceptTapPrivacy()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		if ((!ChannelCode.Equals("taptap") && !ChannelCode.Equals("tapplay")) || (int)Application.platform != 11)
		{
			return false;
		}
		if (File.Exists(AssetsHelper.AndroidAcceptPrivacyFlagFile))
		{
			return true;
		}
		return false;
	}

	private bool HasTapUnzip()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		if ((!ChannelCode.Equals("taptap") && !ChannelCode.Equals("tapplay")) || (int)Application.platform != 11)
		{
			return false;
		}
		if (File.Exists(AssetsHelper.AndroidUnzipFlagFile))
		{
			return true;
		}
		return false;
	}

	private bool IsToutiaoFirst()
	{
		if (!File.Exists(AssetsHelper.vFile))
		{
			if (HasToutiaoAcceptPrivacy() && HasToutiaoUnzip())
			{
				File.WriteAllText(AssetsHelper.vFile, Application.version);
				PlayerPrefs.SetString("HotUpdateFlag", string.Empty);
				PlayerPrefs.SetString("hotfixdll_string", string.Empty);
				PlayerPrefs.SetString("hotfixdll_md5", string.Empty);
				return false;
			}
			return true;
		}
		return false;
	}

	private bool HasToutiaoAcceptPrivacy()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		if (!ChannelCode.Equals("toutiao-android") || (int)Application.platform != 11)
		{
			return false;
		}
		if (File.Exists(AssetsHelper.AndroidAcceptPrivacyFlagFile))
		{
			return true;
		}
		return false;
	}

	private bool HasToutiaoUnzip()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		if (!ChannelCode.Equals("toutiao-android") || (int)Application.platform != 11)
		{
			return false;
		}
		if (File.Exists(AssetsHelper.AndroidUnzipFlagFile))
		{
			return true;
		}
		return false;
	}

	private bool IsGDTFirst()
	{
		if (!File.Exists(AssetsHelper.vFile))
		{
			if (HasGDTAcceptPrivacy() && HasGDTUnzip())
			{
				File.WriteAllText(AssetsHelper.vFile, Application.version);
				PlayerPrefs.SetString("HotUpdateFlag", string.Empty);
				PlayerPrefs.SetString("hotfixdll_string", string.Empty);
				PlayerPrefs.SetString("hotfixdll_md5", string.Empty);
				return false;
			}
			return true;
		}
		return false;
	}

	private bool HasGDTAcceptPrivacy()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		if (!ChannelCode.Equals("gdt-android") || (int)Application.platform != 11)
		{
			return false;
		}
		if (File.Exists(AssetsHelper.AndroidAcceptPrivacyFlagFile))
		{
			return true;
		}
		return false;
	}

	private bool HasGDTUnzip()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		if (!ChannelCode.Equals("gdt-android") || (int)Application.platform != 11)
		{
			return false;
		}
		if (File.Exists(AssetsHelper.AndroidUnzipFlagFile))
		{
			return true;
		}
		return false;
	}

	private void CloseAndroidBG()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		try
		{
			AndroidJavaClass val = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject val2 = ((AndroidJavaObject)val).GetStatic<AndroidJavaObject>("currentActivity");
			if (val2 != null)
			{
				val2.Call("CloseBG", Array.Empty<object>());
			}
		}
		catch (Exception)
		{
		}
	}

	private bool JumpInternationalStore()
	{
		bool result = false;
		if (IsRegionOutCN)
		{
			string version = Application.version;
			if (version.StartsWith("1001.5.9") || version.StartsWith("1001.6.0") || version.StartsWith("101."))
			{
				return false;
			}
			string identifier = Application.identifier;
			if (ChannelCode == "TapIntl")
			{
				TapTapIntlSDK tapTapIntlSDK = (TapTapIntlSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.TapIntlSDK];
				tapTapIntlSDK.JumpTapTap(identifier);
				result = true;
			}
			else if (ChannelCode == "Google")
			{
				GoogleSDK googleSDK = (GoogleSDK)SDKManager.Instance.SDKMap[SDKManager.eSDKName.GoogleSDK];
				googleSDK.JumpGooglePlay(identifier);
				result = true;
			}
		}
		return result;
	}

	public static void ReportActivateForAndroid()
	{
		((MonoBehaviour)Instance).StartCoroutine(_RealReportActivateForAndroid());
	}

	private static IEnumerator _RealReportActivateForAndroid()
	{
		string Android_ActivateFlag = PlayerPrefs.GetString("Android_NewActivateFlag");
		bool Android_isFirst = string.IsNullOrEmpty(Android_ActivateFlag);
		if (Android_isFirst)
		{
			PlayerPrefs.SetString("Android_NewActivateFlag", DateTimeHelper.Now.ToString());
		}
		if ((int)Application.platform == 11 && Android_isFirst)
		{
			if (ChannelCode == "taptap" || ChannelCode == "tapplay")
			{
				TapTapEventManager.Instance.RecordActivation(DateTimeHelper.GetTimeStamp(DateTimeHelper.Now), Instance.Configs["AuthServerUrl"]);
				TapTapEventManager.Instance.InvokeAction(TapTapEventManager.TapTapEventType.Activation, null);
			}
			else if (ChannelCode == "bilibili")
			{
				BiliBiliEventManager.Instance.InvokeAction(BiliBiliEventManager.BiliBiliEventType.APP_FIRST_ACTIVE);
			}
		}
		yield return null;
	}

	public static void ReportActivateForIOS()
	{
		((MonoBehaviour)Instance).StartCoroutine(_RealReportActivateForIOS());
	}

	public static IEnumerator _RealReportActivateForIOS()
	{
		string iOS_ActivateFlag = PlayerPrefs.GetString("iOS_NewActivateFlag2");
		bool iOS_isFirst = string.IsNullOrEmpty(iOS_ActivateFlag);
		if (iOS_isFirst)
		{
			PlayerPrefs.SetString("iOS_NewActivateFlag2", DateTimeHelper.Now.ToString());
		}
		if ((int)Application.platform == 8 && iOS_isFirst)
		{
			OceanEngineEventManager.Instance.InvokeAction(OceanEngineEventManager.eventType.Activation, null);
			TapTapEventManager.Instance.RecordActivation(DateTimeHelper.GetTimeStamp(DateTimeHelper.Now), Instance.Configs["AuthServerUrl"]);
			TapTapEventManager.Instance.InvokeAction_IOS(TapTapEventManager.TapTapEventType.Activation, null);
			BiliBiliEventManager.Instance.InvokeAction(BiliBiliEventManager.BiliBiliEventType.APP_FIRST_ACTIVE);
		}
		yield return null;
	}
}
