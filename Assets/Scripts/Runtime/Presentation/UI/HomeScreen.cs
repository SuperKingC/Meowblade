using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Meowblade
{
    public sealed class HomeScreen : IGameScreen
    {
        private sealed class StationView
        {
            public StationId Id;
            public Text RateText;
            public Text StatusText;
            public Text WorkerText;
            public Image ProgressFill;
            public RectTransform WorkerRoot;
            public int LastWorkerCount = -1;
        }

        private readonly AppBootstrap _app;
        private readonly GameSession _session;
        private readonly Dictionary<ResourceId, Text> _resourceTexts = new Dictionary<ResourceId, Text>();
        private readonly Dictionary<StationId, StationView> _stationViews = new Dictionary<StationId, StationView>();

        private Text _stageTitle;
        private Text _stageHint;
        private Text _homeLevelText;
        private Text _catNestSummary;
        private Text _workshopSummary;
        private Text _workerPoolText;
        private RectTransform _homePanel;
        private float _refreshTimer;

        public GameObject Root { get; private set; }

        public HomeScreen(AppBootstrap app)
        {
            _app = app;
            _session = app.Session;
            Build();
            RefreshAll();
        }

        public void Tick(float deltaTime)
        {
            _refreshTimer -= deltaTime;
            if (_refreshTimer <= 0f)
            {
                _refreshTimer = 0.12f;
                RefreshAll();
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
            RectTransform root = UiFactory.CreateStretchPanel(_app.Canvas.transform, "HomeScreen", UiPalette.Background);
            Root = root.gameObject;

            Image environment = UiFactory.CreateStretchImage(root, "EnvironmentArt", ArtLibrary.HomeBackground, new Color(1f, 1f, 1f, 0.72f));
            environment.transform.SetAsFirstSibling();

            UiFactory.CreatePanel(root, "TopBar", new Vector2(0f, 490f), new Vector2(GameDisplay.ReferenceWidth, 100f), new Color(0.09f, 0.07f, 0.105f, 1f));
            UiFactory.CreateText(root, "Title", "喵剑奇箱 · 猫宅军团", new Vector2(-715f, 490f), new Vector2(430f, 70f), 34, TextAnchor.MiddleLeft, UiPalette.Cream, FontStyle.Bold);

            int resourceIndex = 0;
            foreach (ResourceId resource in GameBalance.AllResources)
            {
                float x = -210f + resourceIndex * 365f;
                RectTransform panel = UiFactory.CreatePanel(root, "Resource_" + resource, new Vector2(x, 490f), new Vector2(335f, 68f), new Color(0.18f, 0.15f, 0.20f, 1f));
                Image icon = UiFactory.CreateImage(panel, "Icon", new Vector2(-135f, 0f), new Vector2(54f, 54f), ArtLibrary.ResourceIcon(resource), Color.white);
                if (icon.sprite == null)
                {
                    UiFactory.CreateText(panel, "GlyphFallback", GameBalance.ResourceGlyph(resource), new Vector2(-135f, 0f), new Vector2(50f, 54f), 34, TextAnchor.MiddleCenter, GameBalance.ResourceColor(resource), FontStyle.Bold);
                }
                Text text = UiFactory.CreateText(panel, "Value", string.Empty, new Vector2(25f, 0f), new Vector2(250f, 54f), 25, TextAnchor.MiddleLeft, UiPalette.Cream, FontStyle.Bold);
                _resourceTexts[resource] = text;
                resourceIndex++;
            }

            UiFactory.CreateButton(root, "Reset", "重置", new Vector2(875f, 490f), new Vector2(105f, 56f), new Color(0.34f, 0.20f, 0.23f), OpenResetConfirm, 20);

            BuildStageCard(root);
            BuildHomePanel(root);
            BuildRightActions(root);
            BuildBottomBar(root);
        }

        private void BuildStageCard(RectTransform root)
        {
            RectTransform panel = UiFactory.CreatePanel(root, "StageCard", new Vector2(-785f, 70f), new Vector2(310f, 700f), UiPalette.Panel);
            UiFactory.CreateText(panel, "Header", "当前目标", new Vector2(0f, 300f), new Vector2(270f, 60f), 28, TextAnchor.MiddleCenter, UiPalette.Accent, FontStyle.Bold);
            _stageTitle = UiFactory.CreateText(panel, "StageTitle", string.Empty, new Vector2(0f, 225f), new Vector2(260f, 80f), 30, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            _stageHint = UiFactory.CreateText(panel, "StageHint", string.Empty, new Vector2(0f, 70f), new Vector2(250f, 220f), 23, TextAnchor.UpperLeft, UiPalette.Muted);

            RectTransform rewardPanel = UiFactory.CreatePanel(panel, "Reward", new Vector2(0f, -95f), new Vector2(260f, 135f), new Color(0.21f, 0.17f, 0.22f, 1f));
            UiFactory.CreateText(rewardPanel, "RewardTitle", "关键奖励", new Vector2(0f, 42f), new Vector2(220f, 42f), 22, TextAnchor.MiddleCenter, UiPalette.AccentGreen, FontStyle.Bold);
            UiFactory.CreateText(rewardPanel, "RewardValue", "普通关：披风配方\nBoss：全生产 +30%", new Vector2(0f, -20f), new Vector2(230f, 80f), 21, TextAnchor.MiddleCenter, UiPalette.Cream);

            _homeLevelText = UiFactory.CreateText(panel, "HomeLevel", string.Empty, new Vector2(0f, -225f), new Vector2(250f, 55f), 24, TextAnchor.MiddleCenter, UiPalette.Blue, FontStyle.Bold);
            UiFactory.CreateButton(panel, "Prepare", "军团整备", new Vector2(0f, -305f), new Vector2(245f, 68f), UiPalette.PanelLight, delegate { _app.ShowFormation(_session.SuggestedStage); }, 25);
        }

        private void BuildHomePanel(RectTransform root)
        {
            Color homeColor = _session.SaveData.homeVisualLevel >= 2
                ? new Color(0.22f, 0.16f, 0.19f, 1f)
                : new Color(0.16f, 0.12f, 0.16f, 1f);
            _homePanel = UiFactory.CreatePanel(root, "HomePanel", new Vector2(-55f, 70f), new Vector2(1110f, 700f), homeColor);

            UiFactory.CreateText(_homePanel, "Roof", _session.SaveData.homeVisualLevel >= 2 ? "✦  升级猫宅 · 暖灯全开  ✦" : "纸 箱 猫 宅", new Vector2(0f, 305f), new Vector2(1000f, 60f), 31, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            _workerPoolText = UiFactory.CreateText(_homePanel, "WorkerPool", string.Empty, new Vector2(0f, 255f), new Vector2(800f, 45f), 22, TextAnchor.MiddleCenter, UiPalette.Muted);

            float[] xs = { -360f, 0f, 360f };
            int index = 0;
            foreach (StationId station in GameBalance.AllStations)
            {
                BuildStationCard(_homePanel, station, new Vector2(xs[index], -20f));
                index++;
            }

            UiFactory.CreateText(_homePanel, "FloorHint", "资源自动入仓 · 满仓会停工 · 点击任意岗位调整分工", new Vector2(0f, -312f), new Vector2(1000f, 45f), 21, TextAnchor.MiddleCenter, UiPalette.Muted);
        }

        private void BuildStationCard(RectTransform parent, StationId station, Vector2 position)
        {
            ResourceId output = GameBalance.StationOutput(station);
            Color stationColor = Color.Lerp(UiPalette.PanelWarm, GameBalance.ResourceColor(output), 0.22f);
            RectTransform panel = UiFactory.CreatePanel(parent, "Station_" + station, position, new Vector2(320f, 470f), stationColor);
            Button click = panel.gameObject.AddComponent<Button>();
            click.onClick.AddListener(OpenAllocationPanel);

            Image stationArt = UiFactory.CreateImage(panel, "StationArt", new Vector2(0f, 145f), new Vector2(285f, 125f), ArtLibrary.StationThumbnail(station), Color.white);
            if (stationArt.sprite == null)
            {
                UiFactory.CreateText(panel, "GlyphFallback", GameBalance.ResourceGlyph(output), new Vector2(0f, 175f), new Vector2(90f, 75f), 52, TextAnchor.MiddleCenter, GameBalance.ResourceColor(output), FontStyle.Bold).raycastTarget = false;
            }
            HeroId stationHero = station == StationId.Cardboard
                ? HeroId.CardboardKnight
                : station == StationId.Fish ? HeroId.FishHunter : HeroId.YarnMage;
            SpineCharacterAnimator heroPreview = SpineHeroFactory.CreateBattleCharacter(
                panel,
                stationHero,
                ArtLibrary.HeroSprite(stationHero),
                new Vector2(130f, 175f));
            heroPreview.transform.SetSiblingIndex(1);
            heroPreview.SetBaseState(CharacterAnimationState.Idle);
            UiFactory.CreateText(panel, "Name", GameBalance.StationName(station), new Vector2(0f, 73f), new Vector2(280f, 50f), 27, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold).raycastTarget = false;
            UiFactory.CreateText(panel, "Action", GameBalance.StationAction(station), new Vector2(0f, 35f), new Vector2(280f, 40f), 18, TextAnchor.MiddleCenter, UiPalette.Muted).raycastTarget = false;

            RectTransform workerRoot = UiFactory.CreateRect(panel, "Workers", new Vector2(0f, -30f), new Vector2(280f, 85f));
            Text workerText = UiFactory.CreateText(panel, "WorkerText", string.Empty, new Vector2(0f, -92f), new Vector2(280f, 38f), 20, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            Text rateText = UiFactory.CreateText(panel, "Rate", string.Empty, new Vector2(0f, -134f), new Vector2(280f, 42f), 23, TextAnchor.MiddleCenter, UiPalette.AccentGreen, FontStyle.Bold);
            Text statusText = UiFactory.CreateText(panel, "Status", string.Empty, new Vector2(0f, -174f), new Vector2(280f, 42f), 20, TextAnchor.MiddleCenter, UiPalette.Muted);
            Image progressFill;
            UiFactory.CreateProgressBar(panel, "Progress", new Vector2(0f, -215f), new Vector2(260f, 14f), new Color(0.08f, 0.07f, 0.09f), GameBalance.ResourceColor(output), out progressFill);

            StationView view = new StationView();
            view.Id = station;
            view.RateText = rateText;
            view.StatusText = statusText;
            view.WorkerText = workerText;
            view.ProgressFill = progressFill;
            view.WorkerRoot = workerRoot;
            _stationViews[station] = view;
        }

        private void BuildRightActions(RectTransform root)
        {
            RectTransform panel = UiFactory.CreatePanel(root, "RightActions", new Vector2(770f, 70f), new Vector2(330f, 700f), UiPalette.Panel);
            UiFactory.CreateText(panel, "Header", "猫宅事务", new Vector2(0f, 300f), new Vector2(280f, 55f), 28, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);

            RectTransform nest = UiFactory.CreatePanel(panel, "NestCard", new Vector2(0f, 155f), new Vector2(280f, 205f), new Color(0.26f, 0.18f, 0.20f, 1f));
            UiFactory.CreateText(nest, "Title", "猫窝 · 治疗与补员", new Vector2(0f, 70f), new Vector2(250f, 45f), 23, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            _catNestSummary = UiFactory.CreateText(nest, "Summary", string.Empty, new Vector2(0f, 15f), new Vector2(250f, 65f), 19, TextAnchor.MiddleCenter, UiPalette.Muted);
            UiFactory.CreateButton(nest, "Open", "打开猫窝", new Vector2(0f, -65f), new Vector2(220f, 55f), UiPalette.Accent, OpenCatNest, 22);

            RectTransform workshop = UiFactory.CreatePanel(panel, "WorkshopCard", new Vector2(0f, -85f), new Vector2(280f, 225f), new Color(0.17f, 0.23f, 0.26f, 1f));
            UiFactory.CreateText(workshop, "Title", "奇箱工坊", new Vector2(0f, 78f), new Vector2(250f, 45f), 23, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            _workshopSummary = UiFactory.CreateText(workshop, "Summary", string.Empty, new Vector2(0f, 18f), new Vector2(250f, 75f), 19, TextAnchor.MiddleCenter, UiPalette.Muted);
            UiFactory.CreateButton(workshop, "Open", "查看披风", new Vector2(0f, -72f), new Vector2(220f, 55f), UiPalette.Blue, OpenWorkshop, 22);

            UiFactory.CreateText(panel, "Tip", "提示：第一关后会出现伤员和披风配方。Boss 首通会让整个猫宅永久加速。", new Vector2(0f, -260f), new Vector2(270f, 120f), 18, TextAnchor.MiddleCenter, UiPalette.Muted);
        }

        private void BuildBottomBar(RectTransform root)
        {
            UiFactory.CreatePanel(root, "BottomBar", new Vector2(0f, -490f), new Vector2(GameDisplay.ReferenceWidth, 100f), new Color(0.09f, 0.07f, 0.105f, 1f));
            UiFactory.CreateButton(root, "Allocation", "猫猫分工", new Vector2(-500f, -490f), new Vector2(260f, 68f), UiPalette.PanelLight, OpenAllocationPanel);
            UiFactory.CreateButton(root, "Nest", "猫窝", new Vector2(-205f, -490f), new Vector2(220f, 68f), UiPalette.PanelLight, OpenCatNest);
            UiFactory.CreateButton(root, "Battle", "出 战", new Vector2(150f, -490f), new Vector2(360f, 78f), UiPalette.Accent, delegate { _app.ShowFormation(_session.SuggestedStage); }, 32);
            UiFactory.CreateButton(root, "Workshop", "奇箱工坊", new Vector2(500f, -490f), new Vector2(260f, 68f), UiPalette.PanelLight, OpenWorkshop);
        }

        private void RefreshAll()
        {
            foreach (ResourceId resource in GameBalance.AllResources)
            {
                float rate = 0f;
                foreach (StationId station in GameBalance.AllStations)
                {
                    if (GameBalance.StationOutput(station) == resource)
                    {
                        rate += _session.GetRatePerMinute(station);
                    }
                }

                int amount = _session.GetResource(resource);
                int capacity = _session.GetCapacity(resource);
                Text text = _resourceTexts[resource];
                text.text = string.Format("{0}  {1}/{2}\n<size=18>+{3}/分钟</size>", GameBalance.ResourceName(resource), amount, capacity, GameBalance.FormatRate(rate));
                text.color = amount >= capacity ? UiPalette.Danger : amount >= capacity * 0.8f ? UiPalette.Accent : UiPalette.Cream;
            }

            foreach (StationId station in GameBalance.AllStations)
            {
                RefreshStation(_stationViews[station]);
            }

            StageId stage = _session.SuggestedStage;
            _stageTitle.text = GameBalance.StageName(stage);
            _stageHint.text = GameBalance.StageHint(stage);
            _homeLevelText.text = string.Format("猫宅 Lv.{0}  ·  生产倍率 {1:0}%", _session.SaveData.homeVisualLevel, _session.SaveData.globalProductionMultiplier * 100f);
            int idle = GameBalance.TotalWorkers - _session.GetAssignedWorkerTotal();
            _workerPoolText.text = string.Format("工人猫：已分配 {0}/{1}  ·  空闲 {2}  ·  当前全局效率 {3:0}%", _session.GetAssignedWorkerTotal(), GameBalance.TotalWorkers, idle, _session.SaveData.globalProductionMultiplier * 100f);

            int injured = 0;
            int empty = 0;
            foreach (HeroId hero in GameBalance.AllHeroes)
            {
                injured += _session.GetKittenCount(hero, KittenStatus.Injured);
                empty += _session.GetKittenCount(hero, KittenStatus.Empty);
            }

            _catNestSummary.text = string.Format("受伤小猫 {0}\n编制空缺 {1}", injured, empty);
            _workshopSummary.text = !_session.SaveData.stageOneCleared
                ? "纸箱侠披风尚未解锁\n通关普通关后获得配方"
                : _session.SaveData.cardboardCapeCrafted
                    ? "纸箱侠披风已装备\n前排军团受伤 -20%"
                    : "配方已解锁\n8纸板 + 3零件";
        }

        private void RefreshStation(StationView view)
        {
            int workers = _session.GetWorkers(view.Id);
            float rate = _session.GetRatePerMinute(view.Id);
            ResourceId output = GameBalance.StationOutput(view.Id);
            view.WorkerText.text = string.Format("工人猫 {0}/3", workers);
            view.RateText.text = string.Format("+{0} {1}/分钟", GameBalance.FormatRate(rate), GameBalance.ResourceName(output));

            WorkstationStatus status = _session.GetStationStatus(view.Id);
            switch (status)
            {
                case WorkstationStatus.NoWorker:
                    view.StatusText.text = "未分配猫猫 · 岗位停工";
                    view.StatusText.color = UiPalette.Muted;
                    break;
                case WorkstationStatus.WaitingStorage:
                    view.StatusText.text = "仓库已满 · 猫猫正在发呆";
                    view.StatusText.color = UiPalette.Danger;
                    break;
                default:
                    view.StatusText.text = "生产中 · 自动搬运入仓";
                    view.StatusText.color = UiPalette.AccentGreen;
                    break;
            }

            UiFactory.SetProgress(view.ProgressFill, _session.GetProgress(view.Id));
            if (view.LastWorkerCount != workers)
            {
                view.LastWorkerCount = workers;
                RebuildWorkers(view, output, workers);
            }
        }

        private static void RebuildWorkers(StationView view, ResourceId output, int workers)
        {
            for (int i = view.WorkerRoot.childCount - 1; i >= 0; i--)
            {
                UnityEngine.Object.Destroy(view.WorkerRoot.GetChild(i).gameObject);
            }

            if (workers <= 0)
            {
                UiFactory.CreateText(view.WorkerRoot, "Empty", "猫窝里睡觉中…", Vector2.zero, new Vector2(250f, 80f), 19, TextAnchor.MiddleCenter, UiPalette.Muted);
                return;
            }

            for (int i = 0; i < workers; i++)
            {
                float x = (i - (workers - 1) * 0.5f) * 76f;
                UiFactory.CreateCatToken(view.WorkerRoot, "Worker" + i, new Vector2(x, 0f), 58f, Color.Lerp(GameBalance.ResourceColor(output), UiPalette.Cream, 0.25f), "猫", true);
            }
        }

        private void OpenAllocationPanel()
        {
            RectTransform backdrop = _app.CreateModal("AllocationModal");
            RectTransform panel = UiFactory.CreatePanel(backdrop, "Panel", Vector2.zero, new Vector2(1100f, 760f), UiPalette.Panel);
            UiFactory.CreateText(panel, "Title", "猫猫分工", new Vector2(0f, 315f), new Vector2(800f, 65f), 38, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            Text availableText = UiFactory.CreateText(panel, "Available", string.Empty, new Vector2(0f, 260f), new Vector2(800f, 45f), 23, TextAnchor.MiddleCenter, UiPalette.Muted);

            int[] draft =
            {
                _session.GetWorkers(StationId.Cardboard),
                _session.GetWorkers(StationId.Fish),
                _session.GetWorkers(StationId.Parts)
            };
            Text[] workerTexts = new Text[3];
            Text[] rateTexts = new Text[3];
            StationId[] stations = { StationId.Cardboard, StationId.Fish, StationId.Parts };
            float[] ys = { 150f, 0f, -150f };

            Action refresh = delegate
            {
                int total = draft[0] + draft[1] + draft[2];
                availableText.text = string.Format("已分配 {0}/3  ·  空闲 {1}", total, GameBalance.TotalWorkers - total);
                for (int i = 0; i < stations.Length; i++)
                {
                    workerTexts[i].text = draft[i].ToString();
                    float oldRate = _session.GetRatePerMinute(stations[i]);
                    float newRate = _session.GetRatePerMinute(stations[i], draft[i]);
                    string arrow = Mathf.Abs(oldRate - newRate) < 0.01f ? "=" : "→";
                    rateTexts[i].text = string.Format("{0} {1} {2}/分钟", GameBalance.FormatRate(oldRate), arrow, GameBalance.FormatRate(newRate));
                    rateTexts[i].color = newRate > oldRate ? UiPalette.AccentGreen : newRate < oldRate ? UiPalette.Accent : UiPalette.Muted;
                }
            };

            for (int i = 0; i < stations.Length; i++)
            {
                int capturedIndex = i;
                StationId capturedStation = stations[i];
                RectTransform row = UiFactory.CreatePanel(panel, "Row_" + capturedStation, new Vector2(0f, ys[i]), new Vector2(930f, 125f), UiPalette.PanelLight);
                UiFactory.CreateText(row, "Name", GameBalance.StationName(capturedStation), new Vector2(-320f, 15f), new Vector2(250f, 45f), 25, TextAnchor.MiddleLeft, UiPalette.Cream, FontStyle.Bold);
                rateTexts[i] = UiFactory.CreateText(row, "Rate", string.Empty, new Vector2(-275f, -30f), new Vector2(340f, 40f), 20, TextAnchor.MiddleLeft, UiPalette.Muted);
                UiFactory.CreateButton(row, "Minus", "−", new Vector2(105f, 0f), new Vector2(72f, 72f), new Color(0.35f, 0.23f, 0.25f), delegate
                {
                    if (draft[capturedIndex] > 0)
                    {
                        draft[capturedIndex]--;
                        refresh();
                    }
                }, 34);
                workerTexts[i] = UiFactory.CreateText(row, "Count", string.Empty, new Vector2(205f, 0f), new Vector2(80f, 70f), 34, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
                UiFactory.CreateButton(row, "Plus", "+", new Vector2(305f, 0f), new Vector2(72f, 72f), UiPalette.Accent, delegate
                {
                    int total = draft[0] + draft[1] + draft[2];
                    if (total >= GameBalance.TotalWorkers)
                    {
                        _app.ShowToast("没有空闲工人猫，请先从其他岗位减一只");
                        return;
                    }

                    draft[capturedIndex]++;
                    refresh();
                }, 32);
            }

            UiFactory.CreateButton(panel, "Cancel", "取消", new Vector2(-170f, -315f), new Vector2(260f, 68f), UiPalette.PanelLight, delegate { UnityEngine.Object.Destroy(backdrop.gameObject); });
            UiFactory.CreateButton(panel, "Confirm", "确认分工", new Vector2(170f, -315f), new Vector2(280f, 68f), UiPalette.Accent, delegate
            {
                if (_session.TryApplyAllocation(draft[0], draft[1], draft[2]))
                {
                    UnityEngine.Object.Destroy(backdrop.gameObject);
                }
            });
            refresh();
        }

        private void OpenCatNest()
        {
            RectTransform backdrop = _app.CreateModal("CatNestModal");
            RectTransform panel = UiFactory.CreatePanel(backdrop, "Panel", Vector2.zero, new Vector2(1250f, 780f), UiPalette.Panel);
            UiFactory.CreateText(panel, "Title", "猫窝 · 治疗与补员", new Vector2(0f, 325f), new Vector2(900f, 60f), 37, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);
            UiFactory.CreateText(panel, "Hint", "战斗胜利后，倒下的小猫会受伤。治疗比补充新编制更便宜。", new Vector2(0f, 275f), new Vector2(950f, 42f), 21, TextAnchor.MiddleCenter, UiPalette.Muted);

            HeroId[] heroes = { HeroId.CardboardKnight, HeroId.FishHunter, HeroId.YarnMage };
            float[] ys = { 150f, 0f, -150f };
            for (int i = 0; i < heroes.Length; i++)
            {
                HeroId capturedHero = heroes[i];
                RectTransform row = UiFactory.CreatePanel(panel, "Army_" + capturedHero, new Vector2(0f, ys[i]), new Vector2(1080f, 125f), Color.Lerp(UiPalette.PanelLight, GameBalance.HeroColor(capturedHero), 0.12f));
                Image heroPortrait = UiFactory.CreateImage(
                    row,
                    "HeroPortrait",
                    new Vector2(-460f, 0f),
                    new Vector2(96f, 96f),
                    ArtLibrary.HeroPortrait(capturedHero),
                    Color.white);
                if (heroPortrait.sprite == null)
                {
                    UiFactory.CreateCatToken(row, "HeroFallback", new Vector2(-460f, 0f), 74f, GameBalance.HeroColor(capturedHero), "猫", false);
                }
                UiFactory.CreateText(row, "Name", GameBalance.HeroName(capturedHero), new Vector2(-350f, 22f), new Vector2(180f, 40f), 25, TextAnchor.MiddleLeft, UiPalette.Cream, FontStyle.Bold);
                UiFactory.CreateText(row, "Summary", _session.BuildArmySummary(capturedHero), new Vector2(-230f, -25f), new Vector2(420f, 38f), 19, TextAnchor.MiddleLeft, UiPalette.Muted);

                bool hasInjured = _session.GetKittenCount(capturedHero, KittenStatus.Injured) > 0;
                bool hasEmpty = _session.GetKittenCount(capturedHero, KittenStatus.Empty) > 0;
                Button heal = UiFactory.CreateButton(row, "Heal", "治疗 " + UiFactory.FormatCosts(GameBalance.HealKittenCosts), new Vector2(215f, 0f), new Vector2(250f, 60f), UiPalette.AccentGreen, delegate
                {
                    if (_session.TryHealOne(capturedHero))
                    {
                        UnityEngine.Object.Destroy(backdrop.gameObject);
                        OpenCatNest();
                    }
                }, 20);
                heal.interactable = hasInjured;

                Button recruit = UiFactory.CreateButton(row, "Recruit", "补员 " + UiFactory.FormatCosts(GameBalance.RecruitKittenCosts), new Vector2(445f, 0f), new Vector2(190f, 60f), UiPalette.Accent, delegate
                {
                    if (_session.TryRecruitOne(capturedHero))
                    {
                        UnityEngine.Object.Destroy(backdrop.gameObject);
                        OpenCatNest();
                    }
                }, 19);
                recruit.interactable = hasEmpty;
            }

            UiFactory.CreateButton(panel, "Close", "返回猫宅", new Vector2(0f, -325f), new Vector2(280f, 68f), UiPalette.PanelLight, delegate { UnityEngine.Object.Destroy(backdrop.gameObject); });
        }

        private void OpenWorkshop()
        {
            RectTransform backdrop = _app.CreateModal("WorkshopModal");
            RectTransform panel = UiFactory.CreatePanel(backdrop, "Panel", Vector2.zero, new Vector2(980f, 690f), UiPalette.Panel);
            UiFactory.CreateText(panel, "Title", "奇箱工坊", new Vector2(0f, 275f), new Vector2(800f, 65f), 38, TextAnchor.MiddleCenter, UiPalette.Cream, FontStyle.Bold);

            RectTransform gear = UiFactory.CreatePanel(panel, "Gear", new Vector2(0f, 35f), new Vector2(780f, 390f), new Color(0.19f, 0.23f, 0.27f, 1f));
            UiFactory.CreateText(gear, "Icon", "▰", new Vector2(-275f, 55f), new Vector2(160f, 160f), 90, TextAnchor.MiddleCenter, UiPalette.Accent, FontStyle.Bold);
            UiFactory.CreateText(gear, "Name", "纸箱侠披风", new Vector2(80f, 120f), new Vector2(420f, 55f), 31, TextAnchor.MiddleLeft, UiPalette.Cream, FontStyle.Bold);
            UiFactory.CreateText(gear, "Effect", "纸箱侠所在军团受到的最终伤害 -20%\nBoss 重压时会出现明显的纸屑护盾。", new Vector2(100f, 35f), new Vector2(470f, 105f), 23, TextAnchor.MiddleLeft, UiPalette.Muted);
            UiFactory.CreateText(gear, "Cost", "制作：" + UiFactory.FormatCosts(GameBalance.CraftCapeCosts), new Vector2(50f, -80f), new Vector2(390f, 50f), 24, TextAnchor.MiddleLeft, UiPalette.AccentGreen, FontStyle.Bold);

            string buttonLabel;
            if (!_session.SaveData.stageOneCleared)
            {
                buttonLabel = "普通关首通后解锁";
            }
            else if (_session.SaveData.cardboardCapeCrafted)
            {
                buttonLabel = "已制作并装备";
            }
            else
            {
                buttonLabel = "制作并装备";
            }

            Button craft = UiFactory.CreateButton(panel, "Craft", buttonLabel, new Vector2(150f, -260f), new Vector2(310f, 70f), UiPalette.Blue, delegate
            {
                if (_session.TryCraftAndEquipCape())
                {
                    UnityEngine.Object.Destroy(backdrop.gameObject);
                    OpenWorkshop();
                }
            });
            craft.interactable = _session.SaveData.stageOneCleared && !_session.SaveData.cardboardCapeCrafted;
            UiFactory.CreateButton(panel, "Close", "返回", new Vector2(-190f, -260f), new Vector2(230f, 70f), UiPalette.PanelLight, delegate { UnityEngine.Object.Destroy(backdrop.gameObject); });
        }

        private void OpenResetConfirm()
        {
            _app.ShowMessageModal("重置 Demo", "将清除当前 Demo 资源、关卡、披风和军团状态。这个操作不能撤销。", "确认重置", delegate
            {
                _session.ResetSave();
                RefreshAll();
            });
        }
    }
}
