using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Meowblade
{
    public sealed class FormationScreen : IGameScreen
    {
        private readonly AppBootstrap _app;
        private readonly GameSession _session;
        private readonly Button[] _slotButtons = new Button[6];
        private readonly Text[] _slotLabels = new Text[6];
        private readonly Dictionary<HeroId, Button> _heroButtons = new Dictionary<HeroId, Button>();
        private readonly Dictionary<HeroId, Text> _heroCardTexts = new Dictionary<HeroId, Text>();
        private readonly Dictionary<HeroId, SpineCharacterAnimator> _heroPreviewAnimators = new Dictionary<HeroId, SpineCharacterAnimator>();

        private StageId _stageId;
        private HeroId _selectedHero = HeroId.CardboardKnight;
        private Text _selectedText;
        private Text _warningText;
        private Text _stageTitle;
        private Text _enemyInfo;
        private Image _enemyPreviewImage;
        private float _refreshTimer;

        public GameObject Root { get; private set; }

        public FormationScreen(AppBootstrap app, StageId stageId)
        {
            _app = app;
            _session = app.Session;
            _stageId = stageId;
            Build();
            Refresh();
        }

        public void Tick(float deltaTime)
        {
            foreach (SpineCharacterAnimator previewAnimator in _heroPreviewAnimators.Values)
            {
                if (previewAnimator != null)
                {
                    previewAnimator.Tick(deltaTime, 1f);
                }
            }

            _refreshTimer -= deltaTime;
            if (_refreshTimer <= 0f)
            {
                _refreshTimer = 0.2f;
                Refresh();
            }
        }

        public void Dispose()
        {
            if (Root != null)
            {
                UnityEngine.Object.Destroy(Root);
            }
        }

        private void Build()
        {
            RectTransform root = UiFactory.CreateStretchPanel(_app.Canvas.transform, "FormationScreen", new Color(0.07f, 0.075f, 0.105f, 1f));
            Root = root.gameObject;
            Image environment = UiFactory.CreateStretchImage(root, "EnvironmentArt", ArtLibrary.HomeBackground, new Color(1f, 1f, 1f, 0.18f));
            environment.transform.SetAsFirstSibling();
            UiFactory.CreatePanel(root, "Top", new Vector2(0f, 485f), new Vector2(GameDisplay.ReferenceWidth, 110f), new Color(0.08f, 0.075f, 0.11f, 1f));
            UiFactory.CreateButton(root, "Back", "← 返回猫宅", new Vector2(-795f, 485f), new Vector2(260f, 62f), UiPalette.PanelLight, _app.ShowHome, 23);
            _stageTitle = UiFactory.CreateText(root, "StageTitle", string.Empty, new Vector2(0f, 490f), new Vector2(700f, 65f), 36, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);

            UiFactory.CreateButton(root, "StageOne", "普通关", new Vector2(650f, 485f), new Vector2(190f, 58f), UiPalette.PanelLight, delegate
            {
                _stageId = StageId.AlleyRaid;
                Refresh();
            }, 22);
            Button bossButton = UiFactory.CreateButton(root, "Boss", "Boss", new Vector2(850f, 485f), new Vector2(150f, 58f), UiPalette.Accent, delegate
            {
                if (_session.IsStageUnlocked(StageId.BoxOverlord))
                {
                    _stageId = StageId.BoxOverlord;
                    Refresh();
                }
                else
                {
                    _app.ShowToast("普通关首通后解锁 Boss");
                }
            }, 22);
            bossButton.interactable = _session.IsStageUnlocked(StageId.BoxOverlord);

            BuildFormationBoard(root);
            BuildEnemyPreview(root);
            BuildHeroCards(root);

            _warningText = UiFactory.CreateText(root, "Warning", string.Empty, new Vector2(0f, -295f), new Vector2(1050f, 45f), 22, TextAnchor.MiddleCenter, UiPalette.Accent);
            UiFactory.CreateButton(root, "Start", "开始战斗", new Vector2(690f, -455f), new Vector2(400f, 78f), UiPalette.Accent, delegate { _app.ShowBattle(_stageId); }, 31);
        }

        private void BuildFormationBoard(RectTransform root)
        {
            RectTransform board = UiFactory.CreatePanel(root, "FormationBoard", new Vector2(-430f, 65f), new Vector2(890f, 690f), new Color(0.11f, 0.115f, 0.15f, 1f));
            UiFactory.CreateText(board, "Title", "我方 3×2 阵型", new Vector2(0f, 290f), new Vector2(750f, 55f), 30, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            UiFactory.CreateText(board, "Back", "后 排", new Vector2(-190f, 240f), new Vector2(200f, 40f), 22, TextAnchor.MiddleCenter, UiPalette.Blue, FontStyle.Bold);
            UiFactory.CreateText(board, "Front", "前 排", new Vector2(190f, 240f), new Vector2(200f, 40f), 22, TextAnchor.MiddleCenter, UiPalette.Accent, FontStyle.Bold);

            Vector2[] positions =
            {
                new Vector2(-190f, 145f), new Vector2(190f, 145f),
                new Vector2(-190f, -5f), new Vector2(190f, -5f),
                new Vector2(-190f, -155f), new Vector2(190f, -155f)
            };

            for (int i = 0; i < 6; i++)
            {
                int capturedSlot = i;
                Button slot = UiFactory.CreateButton(board, "Slot" + i, "空位", positions[i], new Vector2(300f, 120f), i % 2 == 0 ? new Color(0.17f, 0.20f, 0.28f) : new Color(0.29f, 0.20f, 0.18f), delegate
                {
                    _session.MoveHeroToSlot(_selectedHero, capturedSlot);
                    Refresh();
                }, 22);
                _slotButtons[i] = slot;
                _slotLabels[i] = slot.GetComponentInChildren<Text>();
            }

            _selectedText = UiFactory.CreateText(board, "Selected", string.Empty, new Vector2(0f, -275f), new Vector2(760f, 48f), 23, TextAnchor.MiddleCenter, UiPalette.AccentGreen, FontStyle.Bold);
        }

        private void BuildEnemyPreview(RectTransform root)
        {
            RectTransform panel = UiFactory.CreatePanel(root, "EnemyPreview", new Vector2(510f, 145f), new Vector2(760f, 530f), UiPalette.Panel);
            UiFactory.CreateText(panel, "Title", "敌方情报", new Vector2(0f, 215f), new Vector2(650f, 55f), 30, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            RectTransform enemyToken = UiFactory.CreatePanel(panel, "EnemyToken", new Vector2(-235f, 55f), new Vector2(190f, 190f), new Color(0.48f, 0.21f, 0.18f, 1f));
            Sprite enemySprite = ArtLibrary.EnemyPortrait(_stageId == StageId.BoxOverlord);
            _enemyPreviewImage = UiFactory.CreateImage(enemyToken, "Portrait", Vector2.zero, new Vector2(180f, 180f), enemySprite, Color.white);
            if (_enemyPreviewImage.sprite == null)
            {
                UiFactory.CreateText(enemyToken, "GlyphFallback", "鼠", Vector2.zero, new Vector2(170f, 170f), 76, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            }
            _enemyInfo = UiFactory.CreateText(panel, "Info", string.Empty, new Vector2(100f, 30f), new Vector2(430f, 300f), 23, TextAnchor.UpperLeft, UiPalette.Muted);
            UiFactory.CreateText(panel, "Hint", "点击军团卡选择主将，再点击阵型格换位。", new Vector2(0f, -205f), new Vector2(650f, 45f), 20, TextAnchor.MiddleCenter, UiPalette.AccentGreen);
        }

        private void BuildHeroCards(RectTransform root)
        {
            HeroId[] heroes = { HeroId.CardboardKnight, HeroId.FishHunter, HeroId.YarnMage };
            float[] xs = { -470f, -85f, 300f };
            for (int i = 0; i < heroes.Length; i++)
            {
                HeroId capturedHero = heroes[i];
                Button card = UiFactory.CreateButton(root, "Hero_" + capturedHero, string.Empty, new Vector2(xs[i], -390f), new Vector2(350f, 145f), Color.Lerp(UiPalette.Panel, GameBalance.HeroColor(capturedHero), 0.20f), delegate
                {
                    _selectedHero = capturedHero;
                    SpineCharacterAnimator selectedPreview;
                    if (_heroPreviewAnimators.TryGetValue(capturedHero, out selectedPreview))
                    {
                        selectedPreview.Play(CharacterAnimationState.Selected, 0.45f);
                    }
                    Refresh();
                }, 20);
                Text label = card.GetComponentInChildren<Text>();
                label.alignment = TextAnchor.MiddleLeft;
                _heroButtons[capturedHero] = card;
                _heroCardTexts[capturedHero] = label;
                label.rectTransform.anchoredPosition = new Vector2(45f, 0f);
                label.rectTransform.sizeDelta = new Vector2(235f, 132f);
                label.alignment = TextAnchor.MiddleLeft;
                SpineCharacterAnimator preview = SpineHeroFactory.CreateBattleCharacter(
                    card.transform as RectTransform,
                    capturedHero,
                    ArtLibrary.HeroSprite(capturedHero),
                    new Vector2(112f, 132f));
                preview.transform.SetSiblingIndex(0);
                preview.SetBaseState(CharacterAnimationState.Idle);
                _heroPreviewAnimators[capturedHero] = preview;
            }
        }

        private void Refresh()
        {
            _stageTitle.text = GameBalance.StageName(_stageId);
            if (_enemyPreviewImage != null)
            {
                _enemyPreviewImage.sprite = ArtLibrary.EnemyPortrait(_stageId == StageId.BoxOverlord);
            }
            _enemyInfo.text = _stageId == StageId.AlleyRaid
                ? "两波敌人\n\n纸箱鼠 ×5\n胶带鼠 ×1\n\n推荐：纸箱侠前排\n目标时间：20～30 秒\n首通解锁纸箱侠披风"
                : "纸箱小霸王\n\n技能：箱盖重压\n半血：召唤纸箱鼠\n\n前排受到主要伤害\n预警时使用全军钻箱\n首通：全生产 +30%";

            _selectedText.text = "当前选择：" + GameBalance.HeroName(_selectedHero) + " · 点击任意格移动";
            for (int i = 0; i < 6; i++)
            {
                int heroValue = _session.GetFormationHero(i);
                if (heroValue < 0)
                {
                    _slotLabels[i].text = "空位\n<size=18>点击放入" + GameBalance.HeroName(_selectedHero) + "</size>";
                    continue;
                }

                HeroId hero = (HeroId)heroValue;
                int ready = _session.GetKittenCount(hero, KittenStatus.Ready);
                _slotLabels[i].text = string.Format("{0}\n<size=18>{1} · 小猫 {2}/{3}{4}</size>", GameBalance.HeroName(hero), GameBalance.HeroRole(hero), ready, GameBalance.MaxKittens(hero), hero == HeroId.CardboardKnight && _session.SaveData.cardboardCapeEquipped ? " · 披风✓" : string.Empty);
            }

            foreach (HeroId hero in GameBalance.AllHeroes)
            {
                _heroCardTexts[hero].text = string.Format("  {0}\n  <size=19>{1}</size>\n  <size=18>{2}{3}</size>", GameBalance.HeroName(hero), GameBalance.HeroRole(hero), _session.BuildArmySummary(hero), hero == HeroId.CardboardKnight ? (_session.SaveData.cardboardCapeEquipped ? " · 披风✓" : " · 无披风") : string.Empty);
                Image image = _heroButtons[hero].GetComponent<Image>();
                image.color = hero == _selectedHero ? Color.Lerp(GameBalance.HeroColor(hero), Color.white, 0.25f) : Color.Lerp(UiPalette.Panel, GameBalance.HeroColor(hero), 0.20f);
                SpineCharacterAnimator preview = _heroPreviewAnimators[hero];
                preview.transform.localScale = hero == _selectedHero ? new Vector3(1.08f, 1.08f, 1f) : Vector3.one;
            }

            int readyTotal = 0;
            int injuredTotal = 0;
            int emptyTotal = 0;
            foreach (HeroId hero in GameBalance.AllHeroes)
            {
                readyTotal += _session.GetKittenCount(hero, KittenStatus.Ready);
                injuredTotal += _session.GetKittenCount(hero, KittenStatus.Injured);
                emptyTotal += _session.GetKittenCount(hero, KittenStatus.Empty);
            }

            if (injuredTotal > 0 || emptyTotal > 0)
            {
                _warningText.text = string.Format("编制警告：可用小猫 {0}/8，受伤 {1}，空缺 {2}。仍可出战，但战力会下降。", readyTotal, injuredTotal, emptyTotal);
            }
            else if (_stageId == StageId.BoxOverlord && !_session.SaveData.cardboardCapeEquipped)
            {
                _warningText.text = "Boss 警告：纸箱侠尚未装备披风，箱盖重压会非常危险。";
            }
            else
            {
                _warningText.text = "军团准备完成。纸箱侠前排、小鱼干与毛线球后排是推荐阵型。";
            }
        }
    }

    public sealed class BattleScreen : IGameScreen
    {
        private sealed class UnitView
        {
            public RectTransform Root;
            public RectTransform MotionRoot;
            public Text Label;
            public Text State;
            public Image HpFill;
            public Image ShieldFill;
            public CanvasGroup CanvasGroup;
            public ICharacterAnimator Animator;
        }

        private readonly AppBootstrap _app;
        private readonly GameSession _session;
        private readonly StageId _stageId;
        private readonly BattleSimulation _simulation;
        private readonly Dictionary<int, UnitView> _unitViews = new Dictionary<int, UnitView>();
        private readonly Dictionary<int, ICharacterAnimator> _animators = new Dictionary<int, ICharacterAnimator>();
        private readonly List<string> _logLines = new List<string>();
        private readonly BattleAnimationBridge _animationBridge = new BattleAnimationBridge();

        private RectTransform _battlefield;
        private Image _battlefieldImage;
        private Image _telegraphOverlay;
        private Text _timerText;
        private Text _waveText;
        private Text _bossText;
        private Image _bossHpFill;
        private Text _telegraphText;
        private Text _countdownText;
        private Text _logText;
        private Text _speedText;
        private Button _commandButton;
        private Text _commandText;
        private Image _commandFill;
        private readonly Dictionary<HeroId, Text> _heroHudTexts = new Dictionary<HeroId, Text>();

        private float _countdown = 1.2f;
        private float _speed = 1f;
        private float _resultDelay;
        private bool _resultCommitted;
        private bool _resultShown;

        public GameObject Root { get; private set; }

        public BattleScreen(AppBootstrap app, StageId stageId)
        {
            _app = app;
            _session = app.Session;
            _stageId = stageId;
            _simulation = new BattleSimulation(_session, stageId);
            Build();
            RefreshUnitViews();
        }

        public void Tick(float deltaTime)
        {
            if (_countdown > 0f)
            {
                _countdown -= deltaTime;
                _countdownText.gameObject.SetActive(true);
                _countdownText.text = _countdown > 0.65f ? "准备" : "开战！";
            }
            else if (!_simulation.IsFinished)
            {
                _countdownText.gameObject.SetActive(false);
                _simulation.Tick(deltaTime * _speed);
            }

            ProcessEvents();
            RefreshHud();
            RefreshUnitViews();
            _animationBridge.UpdateBaseStates(_simulation.Units, _animators);

            if (_simulation.IsFinished && !_resultShown)
            {
                _resultDelay += deltaTime;
                if (_resultDelay >= 0.75f)
                {
                    _resultShown = true;
                    ShowResult();
                }
            }
        }

        public void Dispose()
        {
            if (Root != null)
            {
                UnityEngine.Object.Destroy(Root);
            }
        }

        private void Build()
        {
            RectTransform root = UiFactory.CreateStretchPanel(_app.Canvas.transform, "BattleScreen", new Color(0.06f, 0.07f, 0.09f, 1f));
            Root = root.gameObject;

            UiFactory.CreatePanel(root, "TopBar", new Vector2(0f, 485f), new Vector2(GameDisplay.ReferenceWidth, 110f), new Color(0.08f, 0.075f, 0.10f, 1f));
            _waveText = UiFactory.CreateText(root, "Wave", string.Empty, new Vector2(-720f, 485f), new Vector2(320f, 60f), 25, TextAnchor.MiddleLeft, UiPalette.Cream, FontStyle.Bold);
            _bossText = UiFactory.CreateText(root, "BossText", string.Empty, new Vector2(0f, 510f), new Vector2(700f, 38f), 24, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            UiFactory.CreateProgressBar(root, "BossHp", new Vector2(0f, 470f), new Vector2(700f, 22f), new Color(0.20f, 0.08f, 0.09f), UiPalette.Danger, out _bossHpFill);
            _timerText = UiFactory.CreateText(root, "Timer", string.Empty, new Vector2(620f, 485f), new Vector2(220f, 60f), 29, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            UiFactory.CreateButton(root, "Retreat", "撤退", new Vector2(860f, 485f), new Vector2(130f, 56f), new Color(0.35f, 0.20f, 0.22f), delegate
            {
                _app.ShowMessageModal("撤退", "撤退不会提交伤员或消耗资源。返回编队界面？", "确认撤退", delegate { _app.ShowFormation(_stageId); });
            }, 21);

            _battlefield = UiFactory.CreatePanel(root, "Battlefield", new Vector2(0f, 75f), new Vector2(1740f, 690f), new Color(0.16f, 0.13f, 0.15f, 1f));
            _battlefieldImage = _battlefield.GetComponent<Image>();
            _battlefieldImage.sprite = ArtLibrary.BattleBackground;
            _battlefieldImage.preserveAspect = true;
            _battlefieldImage.color = new Color(0.68f, 0.69f, 0.72f, 1f);
            _battlefieldImage.raycastTarget = false;
            RectTransform playerTint = UiFactory.CreatePanel(_battlefield, "PlayerTint", new Vector2(-435f, 0f), new Vector2(870f, 690f), new Color(0.04f, 0.18f, 0.27f, 0.14f));
            playerTint.GetComponent<Image>().raycastTarget = false;
            RectTransform enemyTint = UiFactory.CreatePanel(_battlefield, "EnemyTint", new Vector2(435f, 0f), new Vector2(870f, 690f), new Color(0.30f, 0.08f, 0.06f, 0.14f));
            enemyTint.GetComponent<Image>().raycastTarget = false;
            _telegraphOverlay = UiFactory.CreateStretchImage(_battlefield, "TelegraphOverlay", null, new Color(0.62f, 0.03f, 0.04f, 0f));
            UiFactory.CreateText(_battlefield, "PlayerSide", "猫宅军团", new Vector2(-690f, 290f), new Vector2(300f, 45f), 22, TextAnchor.MiddleCenter, UiPalette.Blue, FontStyle.Bold);
            UiFactory.CreateText(_battlefield, "EnemySide", "纸箱敌军", new Vector2(690f, 290f), new Vector2(300f, 45f), 22, TextAnchor.MiddleCenter, UiPalette.Danger, FontStyle.Bold);
            UiFactory.CreatePanel(_battlefield, "CenterLine", Vector2.zero, new Vector2(5f, 590f), new Color(0.85f, 0.75f, 0.55f, 0.18f));

            _telegraphText = UiFactory.CreateText(_battlefield, "Telegraph", string.Empty, new Vector2(0f, 235f), new Vector2(1150f, 70f), 34, TextAnchor.MiddleCenter, UiPalette.Danger, FontStyle.Bold);
            _telegraphText.gameObject.SetActive(false);
            _countdownText = UiFactory.CreateText(_battlefield, "Countdown", "准备", Vector2.zero, new Vector2(600f, 160f), 72, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);

            BuildBottomHud(root);
        }

        private void BuildBottomHud(RectTransform root)
        {
            UiFactory.CreatePanel(root, "BottomHud", new Vector2(0f, -420f), new Vector2(GameDisplay.ReferenceWidth, 240f), new Color(0.085f, 0.075f, 0.105f, 1f));

            HeroId[] heroes = { HeroId.CardboardKnight, HeroId.FishHunter, HeroId.YarnMage };
            float[] xs = { -660f, -330f, 0f };
            for (int i = 0; i < heroes.Length; i++)
            {
                HeroId hero = heroes[i];
                RectTransform card = UiFactory.CreatePanel(root, "Hud_" + hero, new Vector2(xs[i], -420f), new Vector2(300f, 170f), Color.Lerp(UiPalette.Panel, GameBalance.HeroColor(hero), 0.18f));
                Image portrait = UiFactory.CreateImage(card, "Portrait", new Vector2(-105f, 25f), new Vector2(92f, 118f), ArtLibrary.HeroPortrait(hero), Color.white);
                if (portrait.sprite == null)
                {
                    UiFactory.CreateCatToken(card, "TokenFallback", new Vector2(-105f, 25f), 70f, GameBalance.HeroColor(hero), "猫", false);
                }
                Text value = UiFactory.CreateText(card, "Value", string.Empty, new Vector2(50f, 5f), new Vector2(190f, 125f), 19, TextAnchor.MiddleLeft, UiPalette.Cream);
                _heroHudTexts[hero] = value;
            }

            RectTransform commandPanel = UiFactory.CreatePanel(root, "CommandPanel", new Vector2(420f, -420f), new Vector2(420f, 170f), new Color(0.14f, 0.18f, 0.25f, 1f));
            _commandButton = UiFactory.CreateButton(commandPanel, "Command", "全军钻箱", new Vector2(0f, 25f), new Vector2(330f, 80f), UiPalette.Blue, delegate
            {
                if (!_simulation.UseCommand())
                {
                    _app.ShowToast(_simulation.CommandUsed ? "本场号令已经使用" : "号令能量还没有充满");
                }
            }, 28);
            UiFactory.CreateProgressBar(commandPanel, "Energy", new Vector2(0f, -48f), new Vector2(330f, 18f), new Color(0.06f, 0.08f, 0.12f), UiPalette.Blue, out _commandFill);
            _commandText = UiFactory.CreateText(commandPanel, "EnergyText", string.Empty, new Vector2(0f, -80f), new Vector2(350f, 35f), 18, TextAnchor.MiddleCenter, UiPalette.Muted);

            RectTransform controls = UiFactory.CreatePanel(root, "Controls", new Vector2(785f, -420f), new Vector2(260f, 170f), UiPalette.Panel);
            Button speedButton = UiFactory.CreateButton(controls, "Speed", "1×", new Vector2(0f, 30f), new Vector2(180f, 65f), UiPalette.PanelLight, delegate
            {
                _speed = Mathf.Approximately(_speed, 1f) ? 2f : 1f;
                _speedText.text = _speed.ToString("0") + "×";
            }, 27);
            _speedText = speedButton.GetComponentInChildren<Text>();
            _logText = UiFactory.CreateText(controls, "Log", string.Empty, new Vector2(0f, -57f), new Vector2(230f, 85f), 15, TextAnchor.UpperCenter, UiPalette.Muted);
        }

        private void ProcessEvents()
        {
            List<BattleEvent> events = _simulation.DrainEvents();
            _animationBridge.ProcessBatch(events, _animators, _simulation.Result, _simulation.IsFinished, _simulation.Units);
            for (int i = 0; i < events.Count; i++)
            {
                BattleEvent battleEvent = events[i];
                if (!string.IsNullOrEmpty(battleEvent.Message))
                {
                    AddLog(battleEvent.Message);
                }

                if (battleEvent.Type == BattleEventType.Damage)
                {
                    UnitView targetView;
                    if (_unitViews.TryGetValue(battleEvent.TargetUnitId, out targetView))
                    {
                        SpawnFloatingText(targetView.Root, Mathf.RoundToInt(battleEvent.Value).ToString() + battleEvent.Message, battleEvent.Message.Contains("暴击") ? UiPalette.Accent : Color.white);
                    }
                }

                if (battleEvent.Type == BattleEventType.Telegraph)
                {
                    _app.ShowToast(battleEvent.Message);
                }
            }
        }

        private void RefreshHud()
        {
            _timerText.text = string.Format("{0:00.0}s", Mathf.Max(0f, _simulation.TimeLimit - _simulation.ElapsedSeconds));
            _waveText.text = _stageId == StageId.AlleyRaid
                ? string.Format("波次 {0}/{1}", _simulation.CurrentWave, _simulation.TotalWaves)
                : "Boss 战";

            BattleUnit boss = _simulation.GetBoss();
            if (boss != null)
            {
                _bossText.text = string.Format("{0}  {1:0}/{2:0}", boss.DisplayName, boss.Hp, boss.Stats.MaxHp);
                UiFactory.SetProgress(_bossHpFill, boss.Health01);
                _bossHpFill.transform.parent.gameObject.SetActive(true);
            }
            else
            {
                _bossText.text = GameBalance.StageName(_stageId);
                UiFactory.SetProgress(_bossHpFill, 0f);
            }

            bool telegraph = _simulation.BossSlamTelegraphRemaining > 0f;
            _telegraphText.gameObject.SetActive(telegraph);
            if (telegraph)
            {
                _telegraphText.text = string.Format("箱盖重压 {0:0.0}s · 现在使用全军钻箱！", _simulation.BossSlamTelegraphRemaining);
                _telegraphOverlay.color = new Color(0.62f, 0.03f, 0.04f, 0.34f);
            }
            else
            {
                _telegraphOverlay.color = new Color(0.62f, 0.03f, 0.04f, 0f);
            }

            UiFactory.SetProgress(_commandFill, _simulation.CommandEnergy / 100f);
            _commandText.text = _simulation.CommandUsed ? "本场已使用" : string.Format("号令能量 {0:0}%", _simulation.CommandEnergy);
            _commandButton.interactable = !_simulation.CommandUsed && _simulation.CommandEnergy >= 99.99f;

            foreach (HeroId hero in GameBalance.AllHeroes)
            {
                BattleUnit heroUnit = _simulation.GetHero(hero);
                int aliveKittens = 0;
                for (int i = 0; i < _simulation.Units.Count; i++)
                {
                    BattleUnit unit = _simulation.Units[i];
                    if (unit.Alive && unit.IsKitten && unit.OwnerHeroId == hero)
                    {
                        aliveKittens++;
                    }
                }

                if (heroUnit == null)
                {
                    _heroHudTexts[hero].text = GameBalance.HeroName(hero) + "\n未上阵";
                }
                else
                {
                    _heroHudTexts[hero].text = string.Format("{0}\nHP {1:0}/{2:0}\n护盾 {3:0}\n小猫 {4}/{5}", GameBalance.HeroName(hero), heroUnit.Hp, heroUnit.Stats.MaxHp, heroUnit.Shield, aliveKittens, _session.GetKittenCount(hero, KittenStatus.Ready));
                    _heroHudTexts[hero].color = heroUnit.Alive ? UiPalette.Cream : UiPalette.Danger;
                }
            }
        }

        private void RefreshUnitViews()
        {
            for (int i = 0; i < _simulation.Units.Count; i++)
            {
                BattleUnit unit = _simulation.Units[i];
                UnitView view;
                if (!_unitViews.TryGetValue(unit.Id, out view))
                {
                    view = CreateUnitView(unit);
                    _unitViews[unit.Id] = view;
                    if (view.Animator != null)
                    {
                        _animators[unit.Id] = view.Animator;
                    }
                }

                Vector2 mapped = MapBattlePosition(unit.Position);
                if (!unit.Alive)
                {
                    mapped += Vector2.down * 26f;
                }

                view.Root.anchoredPosition = Vector2.Lerp(view.Root.anchoredPosition, mapped, 0.35f);
                UiFactory.SetProgress(view.HpFill, unit.Health01);
                UiFactory.SetProgress(view.ShieldFill, unit.Stats.MaxHp <= 0f ? 0f : Mathf.Clamp01(unit.Shield / unit.Stats.MaxHp));
                view.CanvasGroup.alpha = unit.Alive ? 1f : 0.28f;
                view.State.text = unit.CommandBuffTimer > 0f ? "钻箱减伤" : unit.SlowTimer > 0f ? "缠绕" : unit.Shield > 0f ? "护盾" : unit.Alive ? string.Empty : unit.Retreated ? "撤退" : unit.IsKitten ? "受伤" : "倒下";
            }
        }

        private UnitView CreateUnitView(BattleUnit unit)
        {
            float width = unit.IsBoss ? 160f : unit.IsHero ? 126f : 94f;
            float height = unit.IsBoss ? 154f : unit.IsHero ? 130f : 100f;
            RectTransform root = UiFactory.CreateRect(_battlefield, "Unit_" + unit.Id, MapBattlePosition(unit.Position), new Vector2(width, height));
            root.gameObject.name = "UnitRoot_" + unit.Id;
            CanvasGroup group = root.gameObject.AddComponent<CanvasGroup>();

            Sprite unitSprite = unit.IsPlayer
                ? unit.IsKitten ? ArtLibrary.KittenPortrait(unit.OwnerHeroId) : ArtLibrary.HeroSprite(unit.OwnerHeroId)
                : ArtLibrary.EnemyPortrait(unit.IsBoss);

            float tokenSize = unit.IsBoss ? 126f : 84f;
            Image art;
            ICharacterAnimator animator = null;
            if (unit.IsHero)
            {
                animator = SpineHeroFactory.CreateBattleCharacter(
                    root,
                    unit.OwnerHeroId,
                    unitSprite,
                    new Vector2(138f, 150f));
                animator.SetBaseState(CharacterAnimationState.Idle);
                art = null;
            }
            else
            {
                Color factionColor = unit.IsPlayer ? UiPalette.Blue : UiPalette.Danger;
                RectTransform frame = UiFactory.CreatePanel(root, "TokenFrame", new Vector2(0f, 8f), new Vector2(tokenSize + 10f, tokenSize + 10f), factionColor);
                frame.GetComponent<Image>().raycastTarget = false;
                RectTransform inset = UiFactory.CreatePanel(frame, "Inset", Vector2.zero, new Vector2(tokenSize + 2f, tokenSize + 2f), new Color(0.08f, 0.07f, 0.09f, 1f));
                inset.GetComponent<Image>().raycastTarget = false;
                art = UiFactory.CreateImage(inset, "Art", Vector2.zero, new Vector2(tokenSize, tokenSize), unitSprite, Color.white);
            }

            if (art != null && art.sprite == null)
            {
                Color color = unit.IsPlayer ? GameBalance.HeroColor(unit.OwnerHeroId) : unit.IsBoss ? new Color(0.70f, 0.20f, 0.17f) : new Color(0.52f, 0.31f, 0.24f);
                string glyph = unit.IsPlayer ? "猫" : unit.IsBoss ? "王" : "鼠";
                UiFactory.CreateCatToken(root, "BodyFallback", new Vector2(0f, 8f), tokenSize, color, glyph, false);
            }

            Text label = UiFactory.CreateText(root, "Name", string.Empty, new Vector2(0f, height * 0.5f - 10f), new Vector2(width + 60f, 32f), unit.IsBoss ? 18 : 15, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            Image hpFill;
            UiFactory.CreateProgressBar(root, "Hp", new Vector2(0f, -height * 0.5f + 14f), new Vector2(width, 11f), new Color(0.15f, 0.04f, 0.05f), unit.IsPlayer ? UiPalette.AccentGreen : UiPalette.Danger, out hpFill);
            Image shieldFill;
            UiFactory.CreateProgressBar(root, "Shield", new Vector2(0f, -height * 0.5f + 1f), new Vector2(width, 7f), new Color(0.04f, 0.06f, 0.10f), UiPalette.Blue, out shieldFill);
            Text state = UiFactory.CreateText(root, "State", string.Empty, new Vector2(0f, -height * 0.5f - 15f), new Vector2(width + 60f, 25f), 13, TextAnchor.MiddleCenter, UiPalette.Accent);

            UnitView view = new UnitView();
            view.Root = root;
            view.Label = label;
            view.State = state;
            view.HpFill = hpFill;
            view.ShieldFill = shieldFill;
            view.CanvasGroup = group;
            view.Animator = animator ?? root.GetComponent<ICharacterAnimator>();
            return view;
        }

        private static Vector2 MapBattlePosition(Vector2 position)
        {
            float x = Mathf.Lerp(-760f, 760f, Mathf.InverseLerp(-6.5f, 6.5f, position.x));
            float y = Mathf.Lerp(-235f, 235f, Mathf.InverseLerp(-2.7f, 2.7f, position.y));
            return new Vector2(x, y);
        }

        private void SpawnFloatingText(RectTransform target, string value, Color color)
        {
            Text text = UiFactory.CreateText(_battlefield, "Damage", value, target.anchoredPosition + new Vector2(0f, 55f), new Vector2(160f, 42f), 19, TextAnchor.MiddleCenter, color, FontStyle.Bold);
            FloatingText floating = text.gameObject.AddComponent<FloatingText>();
            floating.Duration = 0.7f;
        }

        private void AddLog(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            _logLines.Add(message);
            while (_logLines.Count > 3)
            {
                _logLines.RemoveAt(0);
            }

            _logText.text = string.Join("\n", _logLines.ToArray());
        }

        private void ShowResult()
        {
            BattleResult result = _simulation.Result;
            bool firstStageClear = result.Victory && result.StageId == StageId.AlleyRaid && !_session.SaveData.stageOneCleared;
            bool firstBossClear = result.Victory && result.StageId == StageId.BoxOverlord && !_session.SaveData.bossCleared;

            if (result.Victory && !_resultCommitted)
            {
                _resultCommitted = true;
                _session.CommitBattleResult(result);
            }

            RectTransform backdrop = _app.CreateModal("BattleResult");
            RectTransform panel = UiFactory.CreatePanel(backdrop, "Panel", Vector2.zero, new Vector2(900f, 650f), result.Victory ? new Color(0.13f, 0.22f, 0.18f, 1f) : new Color(0.27f, 0.13f, 0.15f, 1f));
            UiFactory.CreateText(panel, "Title", result.Victory ? "战斗胜利" : "挑战失败", new Vector2(0f, 250f), new Vector2(720f, 80f), 48, TextAnchor.MiddleCenter, result.Victory ? UiPalette.AccentGreen : UiPalette.Danger, FontStyle.Bold);

            string body;
            if (result.Victory)
            {
                body = string.Format("通关时间：{0:0.0} 秒\n小猫受伤：{1}\n", result.ElapsedSeconds, result.InjuredKittens.Count);
                if (firstStageClear)
                {
                    body += "\n首通奖励：纸板 +10、奇箱零件 +3\n新配方：纸箱侠披风\nBoss 关已解锁";
                }
                else if (firstBossClear)
                {
                    body += "\n猫宅生产效率永久提升\n100% → 130%\n纸板 12 → 15.6/分钟\n鱼干 10 → 13/分钟\n零件 6 → 7.8/分钟";
                }
                else
                {
                    body += result.StageId == StageId.AlleyRaid ? "\n重复奖励：纸板 +2" : "\n重复奖励：鱼干 +3";
                }
            }
            else
            {
                body = result.FailureReason + "\n\n失败不会扣资源，也不会提交小猫受伤。\n返回猫宅补员、制作披风或重新调整阵型。";
            }

            UiFactory.CreateText(panel, "Body", body, new Vector2(0f, 45f), new Vector2(720f, 330f), 26, TextAnchor.MiddleCenter, UiPalette.Cream);

            if (result.Victory)
            {
                UiFactory.CreateButton(panel, "Home", "返回猫宅", new Vector2(firstStageClear ? -170f : 0f, -245f), new Vector2(280f, 72f), UiPalette.Accent, _app.ShowHome);
                if (firstStageClear)
                {
                    UiFactory.CreateButton(panel, "Boss", "查看 Boss", new Vector2(170f, -245f), new Vector2(280f, 72f), UiPalette.Blue, delegate { _app.ShowFormation(StageId.BoxOverlord); });
                }
            }
            else
            {
                UiFactory.CreateButton(panel, "Home", "返回猫宅", new Vector2(-240f, -245f), new Vector2(240f, 72f), UiPalette.PanelLight, _app.ShowHome);
                UiFactory.CreateButton(panel, "Formation", "调整阵型", new Vector2(0f, -245f), new Vector2(240f, 72f), UiPalette.Blue, delegate { _app.ShowFormation(_stageId); });
                UiFactory.CreateButton(panel, "Retry", "重新挑战", new Vector2(240f, -245f), new Vector2(240f, 72f), UiPalette.Accent, delegate { _app.ShowBattle(_stageId); });
            }
        }
    }

    public sealed class FloatingText : MonoBehaviour
    {
        public float Duration = 0.7f;

        private float _elapsed;
        private RectTransform _rect;
        private Text _text;

        private void Awake()
        {
            _rect = transform as RectTransform;
            _text = GetComponent<Text>();
        }

        private void Update()
        {
            _elapsed += Time.unscaledDeltaTime;
            if (_rect != null)
            {
                _rect.anchoredPosition += Vector2.up * 45f * Time.unscaledDeltaTime;
            }

            if (_text != null)
            {
                Color color = _text.color;
                color.a = 1f - Mathf.Clamp01(_elapsed / Duration);
                _text.color = color;
            }

            if (_elapsed >= Duration)
            {
                Destroy(gameObject);
            }
        }
    }
}
