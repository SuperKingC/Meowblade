#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Meowblade.Editor
{
    [InitializeOnLoad]
    public static class ProjectTools
    {
        private const string SceneDirectory = "Assets/Meowblade/Scenes";
        private const string ScenePath = SceneDirectory + "/MeowbladeDemo.unity";
        private const string SelfCheckRequestPath = "Temp/MeowbladeSelfCheck.request";
        private const string SelfCheckReportPath = "Logs/MeowbladeSelfCheck.log";
        private const string SelfCheckSavePath = "Temp/MeowbladeSelfCheckSave.json";

        static ProjectTools()
        {
            EditorApplication.delayCall += AutoGenerateIfNeeded;
        }

        [MenuItem("Meowblade/Generate Game Scene")]
        public static void GenerateGameScene()
        {
            if (!Directory.Exists(SceneDirectory))
            {
                Directory.CreateDirectory(SceneDirectory);
            }

            Scene previousScene = SceneManager.GetActiveScene();
            NewSceneMode createMode = Application.isBatchMode ? NewSceneMode.Single : NewSceneMode.Additive;
            Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, createMode);
            SceneManager.SetActiveScene(scene);
            GameObject bootstrapObject = new GameObject("MeowbladeBootstrap");
            bootstrapObject.AddComponent<AppBootstrap>();

            GameObject cameraObject = new GameObject("Main Camera", typeof(Camera), typeof(AudioListener));
            cameraObject.tag = "MainCamera";
            Camera camera = cameraObject.GetComponent<Camera>();
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = new Color(0.07f, 0.06f, 0.085f, 1f);
            camera.orthographic = true;
            cameraObject.transform.position = new Vector3(0f, 0f, -10f);

            EditorSceneManager.SaveScene(scene, ScenePath);
            if (!Application.isBatchMode)
            {
                EditorSceneManager.CloseScene(scene, true);
                if (previousScene.IsValid() && previousScene.isLoaded)
                {
                    SceneManager.SetActiveScene(previousScene);
                }
            }

            EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene(ScenePath, true) };

            PlayerSettings.companyName = "Meowblade Studio";
            PlayerSettings.productName = "喵剑奇箱 Demo";
            PlayerSettings.defaultScreenWidth = GameDisplay.ReferenceWidth;
            PlayerSettings.defaultScreenHeight = GameDisplay.ReferenceHeight;
            PlayerSettings.defaultInterfaceOrientation = UIOrientation.LandscapeLeft;
            PlayerSettings.allowedAutorotateToLandscapeLeft = true;
            PlayerSettings.allowedAutorotateToLandscapeRight = true;
            PlayerSettings.allowedAutorotateToPortrait = false;
            PlayerSettings.allowedAutorotateToPortraitUpsideDown = false;

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log("[Meowblade Demo] Scene generated: " + ScenePath);
        }

        [MenuItem("Meowblade/Run Self Checks")]
        public static void RunSelfChecks()
        {
            Directory.CreateDirectory(ProjectPath("Temp"));
            Directory.CreateDirectory(ProjectPath("Logs"));
            DeleteSelfCheckSaves();

            List<string> checks = new List<string>();
            GameSession session = GameContext.CreateForSavePath(ProjectPath(SelfCheckSavePath)).Session;

            try
            {
                session.Initialize();
                session.ResetSave();
                Assert(session.GetResource(ResourceId.Cardboard) == 4, "Initial cardboard should be 4.");
                Assert(session.GetWorkers(StationId.Cardboard) == 1, "Initial cardboard workers should be 1.");
                Assert(session.GetAssignedWorkerTotal() == 3, "Initial worker allocation should use all 3 cats.");
                checks.Add("PASS  Initial resources, three workers and 1/1/1 allocation");

                bool allocationApplied = session.TryApplyAllocation(3, 0, 0);
                Assert(allocationApplied, "3/0/0 allocation should be legal.");
                Assert(Mathf.Approximately(session.GetRatePerMinute(StationId.Cardboard), 36f), "3 cardboard workers should produce 36/min.");
                for (int i = 0; i < 300; i++)
                {
                    session.Tick(0.2f);
                }

                Assert(session.GetResource(ResourceId.Cardboard) == 40, "60 seconds at 36/min should move cardboard from 4 to 40.");
                checks.Add("PASS  Worker reassignment and deterministic 60-second production");

                session.ResetSave();
                Assert(!session.TryRecruitOne(HeroId.CardboardKnight), "Recruit should fail with only 4 fish.");
                session.AddResource(ResourceId.DriedFish, 2);
                Assert(session.TryRecruitOne(HeroId.CardboardKnight), "Recruit should succeed after adding 2 fish.");
                Assert(session.GetKittenCount(HeroId.CardboardKnight, KittenStatus.Ready) == 3, "Cardboard squad should be full after recruit.");
                checks.Add("PASS  Atomic material spending and kitten recruitment");

                BattleSimulation battle = new BattleSimulation(session, StageId.AlleyRaid);
                int guard = 0;
                while (!battle.IsFinished && guard < 4000)
                {
                    battle.Tick(0.05f);
                    if (battle.CommandEnergy >= 100f)
                    {
                        battle.UseCommand();
                    }

                    guard++;
                }

                Assert(battle.IsFinished, "Alley battle should finish within the guard limit.");
                Assert(battle.Result.Victory, "A full default squad should clear the alley stage.");
                Assert(battle.Result.ElapsedSeconds <= 45f, "Alley battle should finish before timeout.");
                checks.Add(string.Format("PASS  Alley battle victory in {0:0.0}s", battle.Result.ElapsedSeconds));

                session.CommitBattleResult(battle.Result);
                Assert(session.SaveData.stageOneCleared, "Alley victory should unlock the boss stage.");
                Assert(session.IsStageUnlocked(StageId.BoxOverlord), "Boss stage should be available after alley victory.");
                checks.Add("PASS  Victory commit, stage unlock and battle rewards");

                session.AddResource(ResourceId.Cardboard, session.GetCapacity(ResourceId.Cardboard));
                session.AddResource(ResourceId.DriedFish, session.GetCapacity(ResourceId.DriedFish));
                session.AddResource(ResourceId.MysticPart, session.GetCapacity(ResourceId.MysticPart));
                foreach (HeroId hero in GameBalance.AllHeroes)
                {
                    while (session.GetKittenCount(hero, KittenStatus.Injured) > 0)
                    {
                        Assert(session.TryHealOne(hero), "All injured kittens should be healable with refilled storage.");
                    }

                    while (session.GetKittenCount(hero, KittenStatus.Empty) > 0)
                    {
                        Assert(session.TryRecruitOne(hero), "All empty kitten slots should be recruitable with refilled storage.");
                    }
                }

                Assert(session.TryCraftAndEquipCape(), "Cardboard cape should be craftable after the alley clear.");
                Assert(session.SaveData.cardboardCapeEquipped, "Crafted cardboard cape should be equipped.");
                checks.Add("PASS  Injury healing, replenishment and cardboard cape crafting");

                BattleSimulation bossBattle = new BattleSimulation(session, StageId.BoxOverlord);
                guard = 0;
                while (!bossBattle.IsFinished && guard < 4000)
                {
                    bossBattle.Tick(0.05f);
                    if (bossBattle.CommandEnergy >= 100f &&
                        (bossBattle.BossSlamTelegraphRemaining > 0f || bossBattle.ElapsedSeconds >= 15f))
                    {
                        bossBattle.UseCommand();
                    }

                    guard++;
                }

                Assert(bossBattle.IsFinished, "Boss battle should finish within the guard limit.");
                checks.Add(DescribeBattle("Boss diagnostic", bossBattle));
                Assert(bossBattle.Result.Victory, "A prepared full squad should defeat the box overlord.");
                Assert(bossBattle.CommandUsed, "The boss clear should exercise the manual legion command.");
                Assert(bossBattle.Result.ElapsedSeconds <= 60f, "Boss battle should finish before timeout.");
                checks.Add(string.Format("PASS  Boss victory with legion command in {0:0.0}s", bossBattle.Result.ElapsedSeconds));

                session.CommitBattleResult(bossBattle.Result);
                Assert(session.SaveData.bossCleared, "Boss victory should be persisted.");
                Assert(Mathf.Approximately(session.SaveData.globalProductionMultiplier, GameBalance.BossProductionMultiplier),
                    "Boss first clear should raise global production to 130%.");
                Assert(session.SaveData.homeVisualLevel == 2, "Boss first clear should upgrade the home visual level.");
                checks.Add("PASS  Boss first-clear reward and 130% global production multiplier");

                session.SaveNow();
                GameSession reloaded = GameContext.CreateForSavePath(ProjectPath(SelfCheckSavePath)).Session;
                reloaded.Initialize();
                Assert(reloaded.SaveData.stageOneCleared && reloaded.SaveData.bossCleared, "Completed stages should survive reload.");
                Assert(Mathf.Approximately(reloaded.SaveData.globalProductionMultiplier, GameBalance.BossProductionMultiplier),
                    "Production multiplier should survive reload.");
                checks.Add("PASS  JSON save/reload persistence");

                string artIssue;
                Assert(ArtLibrary.ValidateRuntimeAssets(out artIssue), artIssue);
                checks.Add("PASS  Runtime art resources load through Resources and meet minimum dimensions");

                List<string> report = new List<string>();
                report.Add("Meowblade Self Check");
                report.Add("UTC: " + DateTime.UtcNow.ToString("O"));
                report.Add("RESULT: PASSED");
                report.AddRange(checks);
                File.WriteAllLines(ProjectPath(SelfCheckReportPath), report.ToArray());

                Debug.Log("[Meowblade Demo] All self checks passed.");
            }
            catch (Exception exception)
            {
                List<string> report = new List<string>();
                report.Add("Meowblade Self Check");
                report.Add("UTC: " + DateTime.UtcNow.ToString("O"));
                report.Add("RESULT: FAILED");
                report.AddRange(checks);
                report.Add(exception.ToString());
                File.WriteAllLines(ProjectPath(SelfCheckReportPath), report.ToArray());
                throw;
            }
            finally
            {
                DeleteSelfCheckSaves();
            }
        }

        public static void GenerateFromCommandLine()
        {
            GenerateGameScene();
            RunSelfChecks();
            EditorApplication.Exit(0);
        }

        public static void BuildWindowsFromCommandLine()
        {
            GenerateGameScene();
            string buildPath = GetCommandLineValue("-meowbladeBuildPath");
            if (string.IsNullOrEmpty(buildPath))
            {
                buildPath = ProjectPath("Builds/Windows/MeowbladeDemo.exe");
            }

            Directory.CreateDirectory(Path.GetDirectoryName(buildPath));
            BuildPlayerOptions options = new BuildPlayerOptions();
            options.scenes = new[] { ScenePath };
            options.locationPathName = buildPath;
            options.target = BuildTarget.StandaloneWindows64;
            options.options = BuildOptions.Development;

            BuildReport report = BuildPipeline.BuildPlayer(options);
            if (report.summary.result != UnityEditor.Build.Reporting.BuildResult.Succeeded)
            {
                throw new InvalidOperationException("Windows build failed: " + report.summary.result);
            }

            Debug.Log(string.Format("[Meowblade Demo] Windows build generated: {0} ({1} bytes)", buildPath, report.summary.totalSize));
            EditorApplication.Exit(0);
        }

        private static void AutoGenerateIfNeeded()
        {
            if (Application.isBatchMode)
            {
                return;
            }

            if (!File.Exists(ScenePath))
            {
                try
                {
                    GenerateGameScene();
                    RunSelfChecks();
                }
                catch (Exception exception)
                {
                    Debug.LogException(exception);
                }
            }
            else
            {
                EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene(ScenePath, true) };
            }

            string requestPath = ProjectPath(SelfCheckRequestPath);
            if (File.Exists(requestPath))
            {
                File.Delete(requestPath);
                try
                {
                    RunSelfChecks();
                }
                catch (Exception exception)
                {
                    Debug.LogException(exception);
                }
            }
        }

        private static void DeleteSelfCheckSaves()
        {
            string absolutePath = ProjectPath(SelfCheckSavePath);
            string[] paths = { absolutePath, absolutePath + ".tmp", absolutePath + ".bak" };
            for (int i = 0; i < paths.Length; i++)
            {
                if (File.Exists(paths[i]))
                {
                    File.Delete(paths[i]);
                }
            }
        }

        private static string ProjectPath(string relativePath)
        {
            string projectRoot = Directory.GetParent(Application.dataPath).FullName;
            return Path.Combine(projectRoot, relativePath.Replace('/', Path.DirectorySeparatorChar));
        }

        private static string GetCommandLineValue(string key)
        {
            string[] arguments = Environment.GetCommandLineArgs();
            for (int i = 0; i < arguments.Length - 1; i++)
            {
                if (string.Equals(arguments[i], key, StringComparison.OrdinalIgnoreCase))
                {
                    return arguments[i + 1];
                }
            }

            return string.Empty;
        }

        private static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                throw new InvalidOperationException("[Meowblade Self Check] " + message);
            }
        }

        private static string DescribeBattle(string label, BattleSimulation battle)
        {
            string result = battle.Result == null
                ? "unfinished"
                : battle.Result.Victory ? "victory" : "failure: " + battle.Result.FailureReason;
            List<string> survivors = new List<string>();
            for (int i = 0; i < battle.Units.Count; i++)
            {
                BattleUnit unit = battle.Units[i];
                if (unit.IsHero || unit.IsBoss)
                {
                    survivors.Add(string.Format("{0}={1:0}/{2:0}", unit.DisplayName, unit.Hp, unit.Stats.MaxHp));
                }
            }

            return string.Format("INFO  {0}: {1}, {2:0.0}s, command={3}, energy={4:0}; {5}",
                label,
                result,
                battle.ElapsedSeconds,
                battle.CommandUsed,
                battle.CommandEnergy,
                string.Join(", ", survivors.ToArray()));
        }
    }
}
#endif
