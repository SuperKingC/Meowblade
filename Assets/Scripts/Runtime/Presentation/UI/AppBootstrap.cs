using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Meowblade
{
    public interface IGameScreen
    {
        GameObject Root { get; }
        void Tick(float deltaTime);
        void Dispose();
    }

    public sealed class AppBootstrap : MonoBehaviour
    {
        private Canvas _canvas;
        private IGameScreen _screen;
        private RectTransform _toastRoot;
        private Text _toastText;
        private float _toastTimer;
        private bool _offlineShown;

        public GameSession Session { get; private set; }
        public Canvas Canvas { get { return _canvas; } }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void EnsureBootstrapExists()
        {
            EnsureMainCameraExists();
            if (FindObjectOfType<AppBootstrap>() == null)
            {
                GameObject root = new GameObject("MeowbladeBootstrap");
                root.AddComponent<AppBootstrap>();
            }
        }

        private void Awake()
        {
            AppBootstrap[] instances = FindObjectsOfType<AppBootstrap>();
            if (instances.Length > 1)
            {
                Destroy(gameObject);
                return;
            }

            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
            EnsureMainCameraExists();
            Session = GameContext.CreateDefault().Session;
            Session.StateChanged += OnSessionStateChanged;
            Session.ToastRequested += ShowToast;
            Session.Initialize();

            _canvas = UiFactory.CreateCanvas("MeowbladeCanvas");
            DontDestroyOnLoad(_canvas.gameObject);
            CreateToastLayer();
            ShowHome();
        }

        private void Start()
        {
            string[] arguments = Environment.GetCommandLineArgs();
            for (int i = 0; i < arguments.Length; i++)
            {
                if (string.Equals(arguments[i], "-meowbladeVisualTest", StringComparison.OrdinalIgnoreCase))
                {
                    StartCoroutine(RunAutomatedVisualTest(arguments));
                    return;
                }

                if (string.Equals(arguments[i], "-meowbladeSmokeTest", StringComparison.OrdinalIgnoreCase))
                {
                    StartCoroutine(RunAutomatedSmokeTest());
                    return;
                }
            }
        }

        private void Update()
        {
            if (Session != null)
            {
                Session.Tick(Time.unscaledDeltaTime);
            }

            if (_screen != null)
            {
                _screen.Tick(Time.unscaledDeltaTime);
            }

            if (_toastTimer > 0f)
            {
                _toastTimer -= Time.unscaledDeltaTime;
                if (_toastRoot != null)
                {
                    CanvasGroup group = _toastRoot.GetComponent<CanvasGroup>();
                    if (group != null)
                    {
                        group.alpha = Mathf.Clamp01(_toastTimer * 2f);
                    }
                }

                if (_toastTimer <= 0f && _toastRoot != null)
                {
                    _toastRoot.gameObject.SetActive(false);
                }
            }
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus && Session != null)
            {
                Session.SaveNow();
            }
        }

        private void OnApplicationQuit()
        {
            if (Session != null)
            {
                Session.SaveNow();
            }
        }

        private void OnDestroy()
        {
            if (Session != null)
            {
                Session.StateChanged -= OnSessionStateChanged;
                Session.ToastRequested -= ShowToast;
            }
        }

        public void ShowHome()
        {
            ReplaceScreen(new HomeScreen(this));
            if (!_offlineShown && !string.IsNullOrEmpty(Session.OfflineSummary))
            {
                _offlineShown = true;
                ShowMessageModal("离线收益", Session.OfflineSummary, "收下");
            }
        }

        public void ShowFormation(StageId stageId)
        {
            if (!Session.IsStageUnlocked(stageId))
            {
                ShowToast("先通关普通关，才能挑战纸箱小霸王");
                return;
            }

            ReplaceScreen(new FormationScreen(this, stageId));
        }

        public void ShowBattle(StageId stageId)
        {
            ReplaceScreen(new BattleScreen(this, stageId));
        }

        public void ShowToast(string message)
        {
            if (_toastRoot == null || _toastText == null)
            {
                return;
            }

            _toastText.text = message;
            _toastRoot.gameObject.SetActive(true);
            _toastRoot.SetAsLastSibling();
            CanvasGroup group = _toastRoot.GetComponent<CanvasGroup>();
            if (group != null)
            {
                group.alpha = 1f;
            }

            _toastTimer = 2.5f;
        }

        public RectTransform ShowMessageModal(string title, string message, string confirmLabel, Action confirm = null)
        {
            RectTransform backdrop = UiFactory.CreateModalBackdrop(_canvas.transform, "MessageModal");
            RectTransform panel = UiFactory.CreatePanel(backdrop, "Panel", Vector2.zero, new Vector2(760f, 470f), UiPalette.Panel);
            UiFactory.CreateText(panel, "Title", title, new Vector2(0f, 165f), new Vector2(680f, 70f), 38, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            UiFactory.CreateText(panel, "Message", message, new Vector2(0f, 15f), new Vector2(650f, 230f), 27, TextAnchor.MiddleCenter, UiPalette.Muted);
            UiFactory.CreateButton(panel, "Confirm", confirmLabel, new Vector2(0f, -165f), new Vector2(260f, 70f), UiPalette.Accent, delegate
            {
                if (confirm != null)
                {
                    confirm();
                }

                Destroy(backdrop.gameObject);
            });
            return backdrop;
        }

        public RectTransform CreateModal(string name)
        {
            return UiFactory.CreateModalBackdrop(_canvas.transform, name);
        }

        private void ReplaceScreen(IGameScreen next)
        {
            if (_screen != null)
            {
                _screen.Dispose();
            }

            _screen = next;
            if (_toastRoot != null)
            {
                _toastRoot.SetAsLastSibling();
            }
        }

        private void OnSessionStateChanged()
        {
            // Screens pull the latest state during Tick. This event keeps the session/UI boundary explicit.
        }

        private void CreateToastLayer()
        {
            _toastRoot = UiFactory.CreatePanel(_canvas.transform, "Toast", new Vector2(0f, 390f), new Vector2(760f, 68f), new Color(0.05f, 0.04f, 0.06f, 0.94f));
            _toastRoot.gameObject.AddComponent<CanvasGroup>();
            _toastText = UiFactory.CreateText(_toastRoot, "Text", string.Empty, Vector2.zero, new Vector2(720f, 58f), 26, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            _toastRoot.gameObject.SetActive(false);
        }

        private static Camera EnsureMainCameraExists()
        {
            Camera camera = Camera.main;
            if (camera == null)
            {
                camera = FindObjectOfType<Camera>();
            }

            if (camera == null)
            {
                GameObject cameraObject = new GameObject("Main Camera");
                cameraObject.tag = "MainCamera";
                camera = cameraObject.AddComponent<Camera>();
                cameraObject.transform.position = new Vector3(0f, 0f, -10f);
                DontDestroyOnLoad(cameraObject);
            }

            camera.enabled = true;
            camera.targetDisplay = 0;
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = UiPalette.Background;
            camera.orthographic = true;

            if (FindObjectOfType<AudioListener>() == null)
            {
                camera.gameObject.AddComponent<AudioListener>();
            }

            return camera;
        }

        private IEnumerator RunAutomatedSmokeTest()
        {
            yield return null;
            yield return null;

            bool homeReady = _canvas != null && _canvas.transform.Find("HomeScreen") != null;
            bool cameraReady = Camera.main != null && Camera.main.enabled && Camera.main.targetDisplay == 0;
            int homeButtonCount = _canvas == null ? 0 : _canvas.GetComponentsInChildren<Button>(true).Length;
            int homeTextCount = _canvas == null ? 0 : _canvas.GetComponentsInChildren<Text>(true).Length;

            UiFactory.Font.RequestCharactersInTexture("喵剑奇箱猫宅军团");
            bool chineseFontReady = UiFactory.Font.HasCharacter('喵') && UiFactory.Font.HasCharacter('剑');
            string artIssue;
            bool artReady = ArtLibrary.ValidateRuntimeAssets(out artIssue);

            ShowFormation(StageId.AlleyRaid);
            yield return null;
            bool formationReady = _canvas.transform.Find("FormationScreen") != null;

            ShowBattle(StageId.AlleyRaid);
            yield return null;
            bool battleReady = _canvas.transform.Find("BattleScreen") != null;

            bool passed = homeReady && cameraReady && formationReady && battleReady && chineseFontReady && artReady &&
                          homeButtonCount >= 10 && homeTextCount >= 20;
            string summary = string.Format(
                "camera={0}, home={1}, formation={2}, battle={3}, chineseFont={4}, art={5}, homeButtons={6}, homeTexts={7}",
                cameraReady,
                homeReady,
                formationReady,
                battleReady,
                chineseFontReady,
                artReady ? "ready" : artIssue,
                homeButtonCount,
                homeTextCount);

            if (passed)
            {
                Debug.Log("[Meowblade Demo Smoke Test] PASSED: " + summary);
                Application.Quit(0);
            }
            else
            {
                Debug.LogError("[Meowblade Demo Smoke Test] FAILED: " + summary);
                Application.Quit(2);
            }
        }

        private IEnumerator RunAutomatedVisualTest(string[] arguments)
        {
            string outputDirectory = GetArgumentValue(arguments, "-meowbladeScreenshotDir");
            if (string.IsNullOrEmpty(outputDirectory))
            {
                outputDirectory = Path.Combine(Application.persistentDataPath, "VisualTests");
            }

            Directory.CreateDirectory(outputDirectory);
            Screen.SetResolution(GameDisplay.ReferenceWidth, GameDisplay.ReferenceHeight, false);
            yield return null;
            Transform messageModal = _canvas.transform.Find("MessageModal");
            if (messageModal != null)
            {
                Destroy(messageModal.gameObject);
            }

            yield return new WaitForEndOfFrame();

            ScreenCapture.CaptureScreenshot(Path.Combine(outputDirectory, "01_home_1920x1080.png"));
            yield return new WaitForSecondsRealtime(1f);

            ShowFormation(StageId.AlleyRaid);
            yield return null;
            yield return new WaitForEndOfFrame();
            ScreenCapture.CaptureScreenshot(Path.Combine(outputDirectory, "02_formation_1920x1080.png"));
            yield return new WaitForSecondsRealtime(1f);

            ShowBattle(StageId.AlleyRaid);
            yield return new WaitForSecondsRealtime(2f);
            yield return new WaitForEndOfFrame();
            ScreenCapture.CaptureScreenshot(Path.Combine(outputDirectory, "03_battle_1920x1080.png"));
            yield return new WaitForSecondsRealtime(1f);

            Debug.Log("[Meowblade Visual Test] Screenshots: " + outputDirectory);
            Application.Quit(0);
        }

        private static string GetArgumentValue(string[] arguments, string key)
        {
            for (int i = 0; i < arguments.Length - 1; i++)
            {
                if (string.Equals(arguments[i], key, StringComparison.OrdinalIgnoreCase))
                {
                    return arguments[i + 1];
                }
            }

            return string.Empty;
        }
    }
}
