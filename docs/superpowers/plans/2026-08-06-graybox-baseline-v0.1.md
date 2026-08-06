# Graybox Baseline v0.1 Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (\`- [ ]\`) syntax for tracking.

**Goal:** Turn the existing Meowblade graybox into a Git-recoverable, regression-tested, repeatably built Windows baseline that is ready for controlled core-loop playtesting.

**Architecture:** Preserve the existing Core/Application/Infrastructure/Gameplay/Presentation split and the art-enhanced graybox currently present in the workspace. Add settlement idempotency at the save/session boundary, add focused EditMode tests around the existing pure-C# seams, then strengthen launch options, isolated Player smoke tests, and editor build automation without splitting GameSession or replacing the current UI architecture.

**Tech Stack:** Unity 2022.3.62f3, C#, UGUI, Unity Test Framework 1.1.33, NUnit, PowerShell 7/Windows PowerShell, JSON persistence through Unity JsonUtility, Windows x64 Player.

## Global Constraints

- Unity Editor version is exactly 2022.3.62f3.
- Preserve all pre-existing user changes, including the current Resources-based art integration, Tools/Art pipeline, and Unity MCP editor tooling; do not revert or recreate them.
- Do not add gameplay content, formal art production, Spine, audio, Addressables, ScriptableObject migrations, DI containers, ECS, or service-layer rewrites.
- All EditMode tests, editor self-checks, and Player smoke tests must use isolated save paths and must not read or overwrite the normal player save.
- Builds, Logs, Library, Temp, UserSettings, and .unitycowork remain untracked generated/local content.
- Battle idempotency is keyed by SettlementId, not StageId; different battles of the same stage continue to receive normal repeat-clear rewards.
- Use test-first red/green cycles for every behavior change. Characterization-only tasks explicitly expect the first run to pass against existing behavior.
- Each commit stages only the files listed by its task. Stop if a new unrelated path appears during staging.
- Do not claim build or test success from the 2026-08-05 logs; completion requires fresh commands and fresh results.

---

### Task 1: Preserve the Current Workspace as the Pre-Implementation Baseline

**Files:**
- Add existing: .gitignore
- Add existing: Assets/Art.meta
- Add existing: Assets/Art/**
- Add existing: Assets/Meowblade.meta
- Add existing: Assets/Meowblade/**
- Add existing: Assets/Resources.meta
- Add existing: Assets/Resources/**
- Add existing: Assets/Scripts.meta
- Add existing: Assets/Scripts/**
- Add existing: Doc/*.md
- Add existing: Packages/manifest.json
- Add existing: Packages/packages-lock.json
- Add existing: ProjectSettings/EditorBuildSettings.asset
- Add existing: ProjectSettings/ProjectSettings.asset
- Add existing: ProjectSettings/ShaderGraphSettings.asset
- Add existing: Tools/Art/**

**Interfaces:**
- Consumes: the approved design at docs/superpowers/specs/2026-08-05-graybox-baseline-v0.1-design.md.
- Produces: a committed checkpoint containing the currently working graybox, current generated art assets, their source concepts and derivation tool, scene, project settings, and required Unity MCP dependency.

This task must run in the current workspace before creating an isolated worktree. The existing runtime and editor source is still untracked, so a new worktree cannot contain it until this checkpoint exists.

- [ ] **Step 1: Record the exact starting status**

Run:

~~~powershell
git status --short
git diff --check
git diff -- .gitignore Packages/manifest.json Packages/packages-lock.json ProjectSettings/EditorBuildSettings.asset ProjectSettings/ProjectSettings.asset
~~~

Expected:

- the approved specification is already committed at b6af777;
- the source, scene, runtime art, art tooling, and Demo documents are untracked or modified;
- Builds, Logs, Library, Temp, UserSettings, and .unitycowork are absent from status;
- git diff --check reports no error that will be included in the checkpoint. Fix only whitespace in files listed by this task if it reports one.

- [ ] **Step 2: Verify scene-to-script binding before the checkpoint**

Run:

~~~powershell
$bootstrapGuid = (Select-String -Path Assets\Scripts\Runtime\Presentation\UI\AppBootstrap.cs.meta -Pattern '^guid:').Line.Split(':')[1].Trim()
$sceneReferences = @(Select-String -Path Assets\Meowblade\Scenes\MeowbladeDemo.unity -Pattern $bootstrapGuid)
"BOOTSTRAP_GUID=$bootstrapGuid"
"SCENE_REFERENCE_COUNT=$($sceneReferences.Count)"
~~~

Expected:

~~~text
BOOTSTRAP_GUID=542ebc9f8a5c5c048b2679083becad91
SCENE_REFERENCE_COUNT=1
~~~

- [ ] **Step 3: Run a fresh editor import/compile without changing the scene**

Close interactive Unity instances that have this project open, then run:

~~~powershell
& 'C:\Program Files\Unity2022.3.62f3\Editor\Unity.exe' -batchmode -nographics -quit -projectPath 'D:\UnityProject\Meowblade' -logFile 'D:\UnityProject\Meowblade\Logs\GrayboxBaselineCompile.log'
$compileExit = $LASTEXITCODE
Select-String -Path Logs\GrayboxBaselineCompile.log -Pattern 'error CS\d+|Unhandled Exception|Compilation failed'
if ($compileExit -ne 0) { throw "Baseline compile exited with $compileExit" }
~~~

Expected: Unity exits 0 and the pattern scan returns no match.

- [ ] **Step 4: Stage only the approved checkpoint paths**

Run:

~~~powershell
git add -- .gitignore Assets/Art.meta Assets/Art Assets/Meowblade.meta Assets/Meowblade Assets/Resources.meta Assets/Resources Assets/Scripts.meta Assets/Scripts Doc/*.md Packages/manifest.json Packages/packages-lock.json ProjectSettings/EditorBuildSettings.asset ProjectSettings/ProjectSettings.asset ProjectSettings/ShaderGraphSettings.asset Tools/Art
git diff --cached --name-status
git diff --cached --check
~~~

Expected: every staged path is in the Files list for this task; no Build, Log, Library, Temp, UserSettings, .unitycowork, docs/superpowers/plans, or unrelated local file is staged.

- [ ] **Step 5: Commit the current graybox checkpoint**

Run:

~~~powershell
git commit -m "chore: checkpoint current meowblade graybox"
~~~

Expected: one checkpoint commit containing only the staged current-state files.

---

### Task 2: Add the EditMode Test Foundation

**Files:**
- Modify: Packages/manifest.json
- Modify after Unity resolves: Packages/packages-lock.json
- Create: Assets/Tests.meta
- Create: Assets/Tests/EditMode.meta
- Create: Assets/Tests/EditMode/Meowblade.EditModeTests.asmdef
- Create: Assets/Tests/EditMode/Meowblade.EditModeTests.asmdef.meta
- Create: Assets/Tests/EditMode/TestDoubles.cs
- Create: Assets/Tests/EditMode/TestDoubles.cs.meta
- Create: Assets/Tests/EditMode/TestFoundationTests.cs
- Create: Assets/Tests/EditMode/TestFoundationTests.cs.meta

**Interfaces:**
- Consumes: Meowblade.IClock, Meowblade.ISaveRepository, GameSaveData, and GameSession from Meowblade.Runtime.
- Produces: FakeClock, InMemorySaveRepository, SessionHarness, and TestData helpers used by Tasks 3 through 7.

- [ ] **Step 1: Pin Unity Test Framework as a direct dependency**

Add this direct dependency beside the other com.unity entries in Packages/manifest.json:

~~~json
"com.unity.test-framework": "1.1.33",
~~~

Run the Unity import command from Task 1 once so packages-lock.json resolves com.unity.test-framework at depth 0.

Expected: manifest and lock both resolve 1.1.33; the existing Unity MCP Git dependency and its lock entry remain unchanged.

- [ ] **Step 2: Create the EditMode test assembly**

Create Assets/Tests/EditMode/Meowblade.EditModeTests.asmdef:

~~~json
{
  "name": "Meowblade.EditModeTests",
  "rootNamespace": "Meowblade.Tests",
  "references": [
    "Meowblade.Runtime"
  ],
  "includePlatforms": [
    "Editor"
  ],
  "excludePlatforms": [],
  "allowUnsafeCode": false,
  "overrideReferences": false,
  "precompiledReferences": [],
  "autoReferenced": false,
  "defineConstraints": [],
  "versionDefines": [],
  "noEngineReferences": false,
  "optionalUnityReferences": [
    "TestAssemblies"
  ]
}
~~~

Let Unity generate the four new .meta files listed by this task; do not invent GUIDs manually.

- [ ] **Step 3: Add deterministic test doubles**

Create Assets/Tests/EditMode/TestDoubles.cs:

~~~csharp
using System;
using UnityEngine;

namespace Meowblade.Tests
{
    internal sealed class FakeClock : IClock
    {
        public long UtcNowUnixSeconds { get; set; }

        public FakeClock(long utcNowUnixSeconds)
        {
            UtcNowUnixSeconds = utcNowUnixSeconds;
        }
    }

    internal sealed class InMemorySaveRepository : ISaveRepository
    {
        private GameSaveData _stored;

        public int SaveCount { get; private set; }

        public InMemorySaveRepository(GameSaveData initial)
        {
            _stored = Clone(initial);
        }

        public GameSaveData Load()
        {
            return Clone(_stored);
        }

        public void Save(GameSaveData data)
        {
            _stored = Clone(data);
            SaveCount++;
        }

        public GameSaveData Snapshot()
        {
            return Clone(_stored);
        }

        private static GameSaveData Clone(GameSaveData data)
        {
            if (data == null)
            {
                return null;
            }

            return JsonUtility.FromJson<GameSaveData>(JsonUtility.ToJson(data));
        }
    }

    internal sealed class SessionHarness
    {
        public FakeClock Clock { get; private set; }
        public InMemorySaveRepository Repository { get; private set; }
        public GameSession Session { get; private set; }

        public static SessionHarness Create(long now, GameSaveData save = null)
        {
            GameSaveData initial = save ?? TestData.DefaultAt(now);
            InMemorySaveRepository repository = new InMemorySaveRepository(initial);
            FakeClock clock = new FakeClock(now);
            GameSession session = new GameSession(repository, clock);
            session.Initialize();
            return new SessionHarness
            {
                Clock = clock,
                Repository = repository,
                Session = session
            };
        }
    }

    internal static class TestData
    {
        public static GameSaveData DefaultAt(long timestamp)
        {
            GameSaveData save = GameSaveData.CreateDefault();
            save.lastSaveUnixSeconds = timestamp;
            return save;
        }

        public static void SetResource(GameSaveData save, ResourceId id, int amount)
        {
            for (int i = 0; i < save.resources.Count; i++)
            {
                if (save.resources[i].id == id)
                {
                    save.resources[i].amount = amount;
                    return;
                }
            }

            save.resources.Add(new ResourceAmountData(id, amount));
        }

        public static void SetAllocation(GameSaveData save, StationId id, int workers)
        {
            for (int i = 0; i < save.allocations.Count; i++)
            {
                if (save.allocations[i].id == id)
                {
                    save.allocations[i].workers = workers;
                    return;
                }
            }

            save.allocations.Add(new StationAllocationData(id, workers));
        }

        public static void SetAllKittens(GameSaveData save, KittenStatus status)
        {
            for (int armyIndex = 0; armyIndex < save.armies.Count; armyIndex++)
            {
                for (int kittenIndex = 0; kittenIndex < save.armies[armyIndex].kittens.Count; kittenIndex++)
                {
                    save.armies[armyIndex].kittens[kittenIndex].status = status;
                }
            }
        }

        public static void Tick(GameSession session, int steps, float deltaTime = 0.2f)
        {
            for (int i = 0; i < steps; i++)
            {
                session.Tick(deltaTime);
            }
        }
    }
}
~~~

- [ ] **Step 4: Add and run the foundation test**

Create Assets/Tests/EditMode/TestFoundationTests.cs:

~~~csharp
using NUnit.Framework;

namespace Meowblade.Tests
{
    public sealed class TestFoundationTests
    {
        [Test]
        public void Harness_InitializesDefaultStateAtControlledTime()
        {
            SessionHarness harness = SessionHarness.Create(1000);

            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.EqualTo(4));
            Assert.That(harness.Session.GetAssignedWorkerTotal(), Is.EqualTo(3));
            Assert.That(harness.Repository.Snapshot().lastSaveUnixSeconds, Is.EqualTo(1000));
            Assert.That(harness.Repository.SaveCount, Is.EqualTo(1));
        }
    }
}
~~~

Run:

~~~powershell
& 'C:\Program Files\Unity2022.3.62f3\Editor\Unity.exe' -batchmode -nographics -projectPath 'D:\UnityProject\Meowblade' -runTests -testPlatform EditMode -testResults 'D:\UnityProject\Meowblade\Logs\EditMode-Task2.xml' -logFile 'D:\UnityProject\Meowblade\Logs\EditMode-Task2.log'
~~~

Expected: 1 test passes, 0 fails, and Unity generates all listed .meta files.

- [ ] **Step 5: Commit the test foundation**

Run:

~~~powershell
git add -- Packages/manifest.json Packages/packages-lock.json Assets/Tests.meta Assets/Tests/EditMode.meta Assets/Tests/EditMode/Meowblade.EditModeTests.asmdef Assets/Tests/EditMode/Meowblade.EditModeTests.asmdef.meta Assets/Tests/EditMode/TestDoubles.cs Assets/Tests/EditMode/TestDoubles.cs.meta Assets/Tests/EditMode/TestFoundationTests.cs Assets/Tests/EditMode/TestFoundationTests.cs.meta
git commit -m "test: add edit mode test foundation"
~~~

---

### Task 3: Make Battle Settlement Submission Idempotent

**Files:**
- Create: Assets/Tests/EditMode/BattleSettlementTests.cs
- Create after Unity import: Assets/Tests/EditMode/BattleSettlementTests.cs.meta
- Modify: Assets/Scripts/Runtime/Core/GameDomain.cs:117-160
- Modify: Assets/Scripts/Runtime/Gameplay/Battle/BattleSimulation.cs:48-55, 94-139, 827-853
- Modify: Assets/Scripts/Runtime/Application/GameSession.cs:372-420, 549-610

**Interfaces:**
- Consumes: SessionHarness and TestData from Task 2.
- Produces: BattleResult.SettlementId, GameSaveData.committedSettlementIds, and bool GameSession.CommitBattleResult(BattleResult result).

- [ ] **Step 1: Write failing settlement tests**

Create Assets/Tests/EditMode/BattleSettlementTests.cs:

~~~csharp
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Meowblade.Tests
{
    public sealed class BattleSettlementTests
    {
        [Test]
        public void CommitBattleResult_SameSettlementOnlyMutatesStateOnce()
        {
            SessionHarness harness = SessionHarness.Create(1000);
            BattleResult result = Victory("alley-one", StageId.AlleyRaid);
            result.InjuredKittens.Add(new InjuredKitten(HeroId.CardboardKnight, 0));

            Assert.That(harness.Session.CommitBattleResult(result), Is.True);
            int cardboardAfterFirstCommit = harness.Session.GetResource(ResourceId.Cardboard);
            int partsAfterFirstCommit = harness.Session.GetResource(ResourceId.MysticPart);
            Assert.That(harness.Session.GetArmy(HeroId.CardboardKnight).kittens[0].status, Is.EqualTo(KittenStatus.Injured));

            Assert.That(harness.Session.CommitBattleResult(result), Is.False);
            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.EqualTo(cardboardAfterFirstCommit));
            Assert.That(harness.Session.GetResource(ResourceId.MysticPart), Is.EqualTo(partsAfterFirstCommit));
            Assert.That(harness.Session.SaveData.committedSettlementIds, Has.Count.EqualTo(1));
        }

        [Test]
        public void CommitBattleResult_DifferentSettlementReceivesRepeatClearReward()
        {
            SessionHarness harness = SessionHarness.Create(1000);

            Assert.That(harness.Session.CommitBattleResult(Victory("alley-one", StageId.AlleyRaid)), Is.True);
            int afterFirstClear = harness.Session.GetResource(ResourceId.Cardboard);
            Assert.That(harness.Session.CommitBattleResult(Victory("alley-two", StageId.AlleyRaid)), Is.True);

            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.EqualTo(afterFirstClear + 2));
            Assert.That(harness.Session.SaveData.committedSettlementIds, Has.Count.EqualTo(2));
        }

        [Test]
        public void CommitBattleResult_FailureDoesNotRecordOrMutate()
        {
            SessionHarness harness = SessionHarness.Create(1000);
            BattleResult result = new BattleResult
            {
                SettlementId = "failed-one",
                StageId = StageId.AlleyRaid,
                Victory = false
            };

            Assert.That(harness.Session.CommitBattleResult(result), Is.False);
            Assert.That(harness.Session.SaveData.stageOneCleared, Is.False);
            Assert.That(harness.Session.SaveData.committedSettlementIds, Is.Empty);
        }

        [Test]
        public void CommitBattleResult_EmptySettlementIdIsRejected()
        {
            SessionHarness harness = SessionHarness.Create(1000);
            LogAssert.Expect(LogType.Error, "Battle result is missing SettlementId.");

            Assert.That(harness.Session.CommitBattleResult(Victory(string.Empty, StageId.AlleyRaid)), Is.False);
            Assert.That(harness.Session.SaveData.stageOneCleared, Is.False);
        }

        [Test]
        public void CommitBattleResult_DuplicateBossSettlementDoesNotStackMultiplier()
        {
            GameSaveData save = TestData.DefaultAt(1000);
            save.stageOneCleared = true;
            SessionHarness harness = SessionHarness.Create(1000, save);
            BattleResult result = Victory("boss-one", StageId.BoxOverlord);

            Assert.That(harness.Session.CommitBattleResult(result), Is.True);
            int fishAfterFirstCommit = harness.Session.GetResource(ResourceId.DriedFish);
            Assert.That(harness.Session.CommitBattleResult(result), Is.False);

            Assert.That(harness.Session.GetResource(ResourceId.DriedFish), Is.EqualTo(fishAfterFirstCommit));
            Assert.That(harness.Session.SaveData.globalProductionMultiplier, Is.EqualTo(1.3f).Within(0.001f));
        }

        private static BattleResult Victory(string settlementId, StageId stageId)
        {
            return new BattleResult
            {
                SettlementId = settlementId,
                StageId = stageId,
                Victory = true,
                ElapsedSeconds = 10f
            };
        }
    }
}
~~~

- [ ] **Step 2: Run the tests and verify the red state**

Run the Task 2 Unity test command with result paths EditMode-Task3-Red.xml and EditMode-Task3-Red.log.

Expected: compilation fails because BattleResult.SettlementId and GameSaveData.committedSettlementIds do not exist and CommitBattleResult currently returns void.

- [ ] **Step 3: Add the save and result data contracts**

In GameSaveData:

~~~csharp
public int saveVersion = 2;
public List<string> committedSettlementIds = new List<string>();
~~~

In BattleResult:

~~~csharp
public string SettlementId;
~~~

In BattleSimulation add:

~~~csharp
private readonly string _settlementId;
~~~

Initialize it once in the constructor before spawning units:

~~~csharp
_settlementId = Guid.NewGuid().ToString("N");
~~~

Assign it in Finish:

~~~csharp
result.SettlementId = _settlementId;
~~~

The ID must not be added to the fixed combat seed and must not affect any combat calculation.

- [ ] **Step 4: Implement idempotent session submission**

Change the signature and leading guards to:

~~~csharp
public bool CommitBattleResult(BattleResult result)
{
    if (result == null || !result.Victory)
    {
        return false;
    }

    if (string.IsNullOrWhiteSpace(result.SettlementId))
    {
        Debug.LogError("Battle result is missing SettlementId.");
        return false;
    }

    if (_save.committedSettlementIds.Contains(result.SettlementId))
    {
        return false;
    }

    _save.committedSettlementIds.Add(result.SettlementId);
~~~

Keep the existing injury and stage reward code after these guards. End the method with:

~~~csharp
SaveNow();
RaiseChanged();
return true;
~~~

In EnsureStateIsValid add:

~~~csharp
if (_save.committedSettlementIds == null)
{
    _save.committedSettlementIds = new List<string>();
}

_save.saveVersion = Mathf.Max(2, _save.saveVersion);
~~~

- [ ] **Step 5: Run settlement tests and the full EditMode suite**

Run the Task 2 Unity command with result paths EditMode-Task3-Green.xml and EditMode-Task3-Green.log.

Expected: 6 tests pass, 0 fail: the five settlement tests plus the foundation test.

- [ ] **Step 6: Commit settlement idempotency**

Run:

~~~powershell
git add -- Assets/Scripts/Runtime/Core/GameDomain.cs Assets/Scripts/Runtime/Gameplay/Battle/BattleSimulation.cs Assets/Scripts/Runtime/Application/GameSession.cs Assets/Tests/EditMode/BattleSettlementTests.cs Assets/Tests/EditMode/BattleSettlementTests.cs.meta
git commit -m "fix: make battle settlement idempotent"
~~~

---

### Task 4: Characterize Inventory, Worker Allocation, and Online Production

**Files:**
- Create: Assets/Tests/EditMode/ProductionAndAllocationTests.cs
- Create after Unity import: Assets/Tests/EditMode/ProductionAndAllocationTests.cs.meta

**Interfaces:**
- Consumes: SessionHarness and TestData from Task 2.
- Produces: regression coverage for capacity, atomic spending, allocation validation, production previews, and full-storage recovery.

This is a characterization task. The first run is expected to pass against the current implementation; no runtime file should change.

- [ ] **Step 1: Add production and allocation tests**

Create Assets/Tests/EditMode/ProductionAndAllocationTests.cs:

~~~csharp
using NUnit.Framework;

namespace Meowblade.Tests
{
    public sealed class ProductionAndAllocationTests
    {
        [Test]
        public void AddResource_ClampsToCapacityAndReturnsActualAdded()
        {
            SessionHarness harness = SessionHarness.Create(1000);

            int added = harness.Session.AddResource(ResourceId.Cardboard, 1000);

            Assert.That(added, Is.EqualTo(56));
            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.EqualTo(60));
        }

        [Test]
        public void TrySpend_InsufficientMultiResourceCostDoesNotPartiallyDeduct()
        {
            SessionHarness harness = SessionHarness.Create(1000);

            Assert.That(harness.Session.TrySpend(GameBalance.RecruitKittenCosts), Is.False);
            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.EqualTo(4));
            Assert.That(harness.Session.GetResource(ResourceId.DriedFish), Is.EqualTo(4));
        }

        [Test]
        public void TryApplyAllocation_RejectsInvalidValuesWithoutChangingState()
        {
            SessionHarness harness = SessionHarness.Create(1000);

            Assert.That(harness.Session.TryApplyAllocation(-1, 1, 1), Is.False);
            Assert.That(harness.Session.TryApplyAllocation(4, 0, 0), Is.False);
            Assert.That(harness.Session.TryApplyAllocation(2, 2, 0), Is.False);
            Assert.That(harness.Session.GetWorkers(StationId.Cardboard), Is.EqualTo(1));
            Assert.That(harness.Session.GetWorkers(StationId.Fish), Is.EqualTo(1));
            Assert.That(harness.Session.GetWorkers(StationId.Parts), Is.EqualTo(1));
        }

        [Test]
        public void TryApplyAllocation_AllowsThreeZeroZero()
        {
            SessionHarness harness = SessionHarness.Create(1000);

            Assert.That(harness.Session.TryApplyAllocation(3, 0, 0), Is.True);
            Assert.That(harness.Session.GetAssignedWorkerTotal(), Is.EqualTo(3));
            Assert.That(harness.Session.GetRatePerMinute(StationId.Cardboard), Is.EqualTo(36f).Within(0.001f));
        }

        [TestCase(1, 16)]
        [TestCase(2, 28)]
        [TestCase(3, 40)]
        public void CardboardProduction_MatchesPreviewForSixtySeconds(int workers, int expectedAmount)
        {
            SessionHarness harness = SessionHarness.Create(1000);
            Assert.That(harness.Session.TryApplyAllocation(workers, 0, 0), Is.True);

            TestData.Tick(harness.Session, 300);

            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.EqualTo(expectedAmount));
        }

        [Test]
        public void FullStorage_DoesNotAccumulateHiddenIntegerBurst()
        {
            SessionHarness harness = SessionHarness.Create(1000);
            Assert.That(harness.Session.TryApplyAllocation(3, 0, 0), Is.True);
            harness.Session.AddResource(ResourceId.Cardboard, 1000);
            TestData.Tick(harness.Session, 300);

            Assert.That(harness.Session.TrySpend(new[] { new ResourceCost(ResourceId.Cardboard, 1) }), Is.True);
            TestData.Tick(harness.Session, 1);
            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.EqualTo(59));

            TestData.Tick(harness.Session, 9);
            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.EqualTo(60));
        }
    }
}
~~~

- [ ] **Step 2: Run the characterization tests**

Run the Task 2 Unity command with result paths EditMode-Task4.xml and EditMode-Task4.log.

Expected: 14 tests pass, 0 fail: 8 generated cases in this file, 5 settlement tests, and 1 foundation test.

- [ ] **Step 3: Commit production characterization**

Run:

~~~powershell
git add -- Assets/Tests/EditMode/ProductionAndAllocationTests.cs Assets/Tests/EditMode/ProductionAndAllocationTests.cs.meta
git commit -m "test: cover production and worker allocation"
~~~

---

### Task 5: Characterize Offline Production

**Files:**
- Create: Assets/Tests/EditMode/OfflineProductionTests.cs
- Create after Unity import: Assets/Tests/EditMode/OfflineProductionTests.cs.meta

**Interfaces:**
- Consumes: FakeClock, InMemorySaveRepository, SessionHarness, and TestData from Task 2.
- Produces: deterministic regression coverage for clock rollback, five-second display threshold, 30-minute cap, saved allocation/multiplier, full storage, and duplicate initialization.

This is a characterization task. The current ApplyOfflineProduction implementation is expected to pass.

- [ ] **Step 1: Add offline tests**

Create Assets/Tests/EditMode/OfflineProductionTests.cs:

~~~csharp
using NUnit.Framework;

namespace Meowblade.Tests
{
    public sealed class OfflineProductionTests
    {
        [Test]
        public void Initialize_TimeWentBackward_GrantsNothing()
        {
            GameSaveData save = EmptyResourcesAt(1000);
            SessionHarness harness = SessionHarness.Create(900, save);

            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.Zero);
            Assert.That(harness.Session.OfflineSummary, Is.Empty);
        }

        [Test]
        public void Initialize_LessThanFiveSeconds_DoesNotShowOrGrant()
        {
            GameSaveData save = EmptyResourcesAt(1000);
            SessionHarness harness = SessionHarness.Create(1004, save);

            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.Zero);
            Assert.That(harness.Session.OfflineSummary, Is.Empty);
        }

        [Test]
        public void Initialize_UsesSavedWorkersAndMultiplier()
        {
            GameSaveData save = EmptyResourcesAt(1000);
            TestData.SetAllocation(save, StationId.Cardboard, 2);
            TestData.SetAllocation(save, StationId.Fish, 0);
            TestData.SetAllocation(save, StationId.Parts, 1);
            save.globalProductionMultiplier = 1.3f;

            SessionHarness harness = SessionHarness.Create(1060, save);

            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.EqualTo(31));
            Assert.That(harness.Session.GetResource(ResourceId.DriedFish), Is.Zero);
            Assert.That(harness.Session.GetResource(ResourceId.MysticPart), Is.EqualTo(7));
        }

        [Test]
        public void Initialize_ClampsOfflineTimeToThirtyMinutesAndCapacity()
        {
            GameSaveData save = EmptyResourcesAt(1000);
            TestData.SetAllocation(save, StationId.Cardboard, 1);
            TestData.SetAllocation(save, StationId.Fish, 0);
            TestData.SetAllocation(save, StationId.Parts, 0);

            SessionHarness harness = SessionHarness.Create(1000 + 7200, save);

            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.EqualTo(60));
            StringAssert.Contains("已满仓", harness.Session.OfflineSummary);
        }

        [Test]
        public void Initialize_SameOfflineWindowCannotBeSettledTwice()
        {
            GameSaveData save = EmptyResourcesAt(1000);
            TestData.SetAllocation(save, StationId.Cardboard, 1);
            InMemorySaveRepository repository = new InMemorySaveRepository(save);
            FakeClock clock = new FakeClock(1060);
            GameSession first = new GameSession(repository, clock);
            first.Initialize();
            int afterFirst = first.GetResource(ResourceId.Cardboard);

            GameSession second = new GameSession(repository, clock);
            second.Initialize();

            Assert.That(afterFirst, Is.EqualTo(12));
            Assert.That(second.GetResource(ResourceId.Cardboard), Is.EqualTo(afterFirst));
            Assert.That(second.OfflineSummary, Is.Empty);
        }

        private static GameSaveData EmptyResourcesAt(long timestamp)
        {
            GameSaveData save = TestData.DefaultAt(timestamp);
            TestData.SetResource(save, ResourceId.Cardboard, 0);
            TestData.SetResource(save, ResourceId.DriedFish, 0);
            TestData.SetResource(save, ResourceId.MysticPart, 0);
            return save;
        }
    }
}
~~~

- [ ] **Step 2: Run offline characterization**

Run the Task 2 Unity command with result paths EditMode-Task5.xml and EditMode-Task5.log.

Expected: 19 tests pass, 0 fail.

- [ ] **Step 3: Commit offline characterization**

Run:

~~~powershell
git add -- Assets/Tests/EditMode/OfflineProductionTests.cs Assets/Tests/EditMode/OfflineProductionTests.cs.meta
git commit -m "test: cover offline production boundaries"
~~~

---

### Task 6: Cover Cat Care, Crafting, Save Recovery, and Old-Save Repair

**Files:**
- Create: Assets/Tests/EditMode/CareAndCraftingTests.cs
- Create after Unity import: Assets/Tests/EditMode/CareAndCraftingTests.cs.meta
- Create: Assets/Tests/EditMode/PersistenceTests.cs
- Create after Unity import: Assets/Tests/EditMode/PersistenceTests.cs.meta

**Interfaces:**
- Consumes: committedSettlementIds and saveVersion 2 from Task 3 plus test helpers from Task 2.
- Produces: regression coverage for healing, recruitment, cape costs, JSON backup recovery, semantic state repair, and v1-to-v2 save migration.

- [ ] **Step 1: Add cat-care and crafting characterization tests**

Create Assets/Tests/EditMode/CareAndCraftingTests.cs:

~~~csharp
using NUnit.Framework;

namespace Meowblade.Tests
{
    public sealed class CareAndCraftingTests
    {
        [Test]
        public void Heal_OnlyInjuredKittenAndDeductsExactCost()
        {
            GameSaveData save = TestData.DefaultAt(1000);
            save.armies[0].kittens[0].status = KittenStatus.Injured;
            TestData.SetResource(save, ResourceId.Cardboard, 10);
            TestData.SetResource(save, ResourceId.DriedFish, 10);
            SessionHarness harness = SessionHarness.Create(1000, save);

            Assert.That(harness.Session.TryHealOne(HeroId.CardboardKnight), Is.True);
            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.EqualTo(8));
            Assert.That(harness.Session.GetResource(ResourceId.DriedFish), Is.EqualTo(7));
            Assert.That(harness.Session.TryHealOne(HeroId.CardboardKnight), Is.False);
        }

        [Test]
        public void Recruit_OnlyEmptySlotAndDeductsExactCost()
        {
            GameSaveData save = TestData.DefaultAt(1000);
            TestData.SetResource(save, ResourceId.Cardboard, 10);
            TestData.SetResource(save, ResourceId.DriedFish, 10);
            SessionHarness harness = SessionHarness.Create(1000, save);

            Assert.That(harness.Session.TryRecruitOne(HeroId.CardboardKnight), Is.True);
            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.EqualTo(6));
            Assert.That(harness.Session.GetResource(ResourceId.DriedFish), Is.EqualTo(4));
            Assert.That(harness.Session.GetKittenCount(HeroId.CardboardKnight, KittenStatus.Ready), Is.EqualTo(3));
            Assert.That(harness.Session.TryRecruitOne(HeroId.CardboardKnight), Is.False);
        }

        [Test]
        public void CraftCape_BeforeStageClearDoesNotSpend()
        {
            GameSaveData save = TestData.DefaultAt(1000);
            TestData.SetResource(save, ResourceId.Cardboard, 20);
            TestData.SetResource(save, ResourceId.MysticPart, 10);
            SessionHarness harness = SessionHarness.Create(1000, save);

            Assert.That(harness.Session.TryCraftAndEquipCape(), Is.False);
            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.EqualTo(20));
            Assert.That(harness.Session.GetResource(ResourceId.MysticPart), Is.EqualTo(10));
        }

        [Test]
        public void CraftCape_ChargesOnlyOnFirstCraft()
        {
            GameSaveData save = TestData.DefaultAt(1000);
            save.stageOneCleared = true;
            TestData.SetResource(save, ResourceId.Cardboard, 20);
            TestData.SetResource(save, ResourceId.MysticPart, 10);
            SessionHarness harness = SessionHarness.Create(1000, save);

            Assert.That(harness.Session.TryCraftAndEquipCape(), Is.True);
            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.EqualTo(12));
            Assert.That(harness.Session.GetResource(ResourceId.MysticPart), Is.EqualTo(7));
            Assert.That(harness.Session.TryCraftAndEquipCape(), Is.True);
            Assert.That(harness.Session.GetResource(ResourceId.Cardboard), Is.EqualTo(12));
            Assert.That(harness.Session.GetResource(ResourceId.MysticPart), Is.EqualTo(7));
        }
    }
}
~~~

- [ ] **Step 2: Add persistence and state-repair tests**

Create Assets/Tests/EditMode/PersistenceTests.cs:

~~~csharp
using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace Meowblade.Tests
{
    public sealed class PersistenceTests
    {
        private string _directory;
        private string _savePath;

        [SetUp]
        public void SetUp()
        {
            string tempRoot = Path.GetFullPath(Path.GetTempPath());
            _directory = Path.Combine(tempRoot, "MeowbladeTests", Guid.NewGuid().ToString("N"));
            _savePath = Path.Combine(_directory, "save.json");
        }

        [TearDown]
        public void TearDown()
        {
            string tempRoot = Path.GetFullPath(Path.GetTempPath()).TrimEnd(Path.DirectorySeparatorChar) + Path.DirectorySeparatorChar;
            string target = Path.GetFullPath(_directory);
            if (Directory.Exists(target) && target.StartsWith(tempRoot, StringComparison.OrdinalIgnoreCase))
            {
                Directory.Delete(target, true);
            }
        }

        [Test]
        public void JsonRepository_CorruptPrimaryFallsBackToBackup()
        {
            JsonSaveRepository repository = new JsonSaveRepository(_savePath);
            GameSaveData first = TestData.DefaultAt(1000);
            TestData.SetResource(first, ResourceId.Cardboard, 7);
            repository.Save(first);

            GameSaveData second = TestData.DefaultAt(1100);
            TestData.SetResource(second, ResourceId.Cardboard, 20);
            repository.Save(second);
            File.WriteAllText(_savePath, "{corrupt-json");

            GameSaveData loaded = repository.Load();

            Assert.That(loaded, Is.Not.Null);
            Assert.That(loaded.resources.Find(item => item.id == ResourceId.Cardboard).amount, Is.EqualTo(7));
        }

        [Test]
        public void Initialize_RepairsMissingCollectionsAndInvalidAllocation()
        {
            GameSaveData save = TestData.DefaultAt(1000);
            save.resources = null;
            save.productionProgress = null;
            save.armies = null;
            save.formationSlots = new List<int> { (int)HeroId.CardboardKnight };
            save.committedSettlementIds = null;
            TestData.SetAllocation(save, StationId.Cardboard, 3);
            TestData.SetAllocation(save, StationId.Fish, 3);
            TestData.SetAllocation(save, StationId.Parts, 3);

            SessionHarness harness = SessionHarness.Create(1000, save);

            Assert.That(harness.Session.GetAssignedWorkerTotal(), Is.EqualTo(3));
            Assert.That(harness.Session.SaveData.resources, Has.Count.EqualTo(3));
            Assert.That(harness.Session.SaveData.productionProgress, Has.Count.EqualTo(3));
            Assert.That(harness.Session.SaveData.armies, Has.Count.EqualTo(3));
            Assert.That(harness.Session.SaveData.formationSlots, Has.Count.EqualTo(6));
            Assert.That(harness.Session.SaveData.committedSettlementIds, Is.Not.Null);
        }

        [Test]
        public void Initialize_UpgradesVersionOneSaveWithoutLosingProgress()
        {
            GameSaveData save = TestData.DefaultAt(1000);
            save.saveVersion = 1;
            save.stageOneCleared = true;
            save.committedSettlementIds = null;

            SessionHarness harness = SessionHarness.Create(1000, save);

            Assert.That(harness.Session.SaveData.saveVersion, Is.EqualTo(2));
            Assert.That(harness.Session.SaveData.stageOneCleared, Is.True);
            Assert.That(harness.Session.SaveData.committedSettlementIds, Is.Empty);
        }
    }
}
~~~

- [ ] **Step 3: Run care and persistence tests**

Run the Task 2 Unity command with result paths EditMode-Task6.xml and EditMode-Task6.log.

Expected: 26 tests pass, 0 fail.

- [ ] **Step 4: Commit care and persistence coverage**

Run:

~~~powershell
git add -- Assets/Tests/EditMode/CareAndCraftingTests.cs Assets/Tests/EditMode/CareAndCraftingTests.cs.meta Assets/Tests/EditMode/PersistenceTests.cs Assets/Tests/EditMode/PersistenceTests.cs.meta
git commit -m "test: cover care crafting and save recovery"
~~~

---

### Task 7: Cover Deterministic Battles and Strengthen the Editor Self-Check

**Files:**
- Create: Assets/Tests/EditMode/BattleSimulationTests.cs
- Create after Unity import: Assets/Tests/EditMode/BattleSimulationTests.cs.meta
- Modify: Assets/Scripts/Editor/ProjectTools.cs:114-191

**Interfaces:**
- Consumes: BattleResult.SettlementId and bool CommitBattleResult from Task 3.
- Produces: deterministic default-stage tests and an editor self-check that proves duplicate settlement submission is rejected.

- [ ] **Step 1: Add deterministic battle tests**

Create Assets/Tests/EditMode/BattleSimulationTests.cs:

~~~csharp
using NUnit.Framework;

namespace Meowblade.Tests
{
    public sealed class BattleSimulationTests
    {
        [Test]
        public void PreparedArmy_ClearsAlleyAndProducesStableSettlementId()
        {
            SessionHarness harness = PreparedSession(false);
            BattleSimulation battle = Run(harness.Session, StageId.AlleyRaid);

            Assert.That(battle.Result.Victory, Is.True);
            Assert.That(battle.Result.ElapsedSeconds, Is.LessThanOrEqualTo(45f));
            string settlementId = battle.Result.SettlementId;
            Assert.That(settlementId, Is.Not.Null.And.Not.Empty);
            battle.Tick(1f);
            Assert.That(battle.Result.SettlementId, Is.EqualTo(settlementId));
        }

        [Test]
        public void PreparedArmy_WithCapeAndCommandClearsBoss()
        {
            SessionHarness harness = PreparedSession(true);
            BattleSimulation battle = Run(harness.Session, StageId.BoxOverlord);

            Assert.That(battle.Result.Victory, Is.True);
            Assert.That(battle.CommandUsed, Is.True);
            Assert.That(battle.Result.ElapsedSeconds, Is.LessThanOrEqualTo(60f));
        }

        [Test]
        public void SeparateBattlesProduceDifferentSettlementIds()
        {
            SessionHarness harness = PreparedSession(false);
            BattleSimulation first = Run(harness.Session, StageId.AlleyRaid);
            BattleSimulation second = Run(harness.Session, StageId.AlleyRaid);

            Assert.That(first.Result.SettlementId, Is.Not.EqualTo(second.Result.SettlementId));
        }

        private static SessionHarness PreparedSession(bool boss)
        {
            GameSaveData save = TestData.DefaultAt(1000);
            TestData.SetAllKittens(save, KittenStatus.Ready);
            save.stageOneCleared = boss;
            save.cardboardCapeCrafted = boss;
            save.cardboardCapeEquipped = boss;
            return SessionHarness.Create(1000, save);
        }

        private static BattleSimulation Run(GameSession session, StageId stage)
        {
            BattleSimulation battle = new BattleSimulation(session, stage);
            int guard = 0;
            while (!battle.IsFinished && guard < 4000)
            {
                battle.Tick(0.05f);
                if (battle.CommandEnergy >= 100f &&
                    (stage == StageId.AlleyRaid || battle.BossSlamTelegraphRemaining > 0f || battle.ElapsedSeconds >= 15f))
                {
                    battle.UseCommand();
                }

                guard++;
            }

            Assert.That(battle.IsFinished, Is.True, "Battle exceeded deterministic guard.");
            return battle;
        }
    }
}
~~~

- [ ] **Step 2: Run battle tests**

Run the Task 2 Unity command with result paths EditMode-Task7-BeforeSelfCheck.xml and EditMode-Task7-BeforeSelfCheck.log.

Expected: 29 tests pass, 0 fail.

- [ ] **Step 3: Make the editor self-check assert settlement idempotency**

Replace the alley commit statement with:

~~~csharp
Assert(session.CommitBattleResult(battle.Result), "First alley result submission should commit.");
int cardboardAfterAlleyCommit = session.GetResource(ResourceId.Cardboard);
int partsAfterAlleyCommit = session.GetResource(ResourceId.MysticPart);
Assert(!session.CommitBattleResult(battle.Result), "Duplicate alley result submission should be rejected.");
Assert(session.GetResource(ResourceId.Cardboard) == cardboardAfterAlleyCommit, "Duplicate alley result should not add cardboard.");
Assert(session.GetResource(ResourceId.MysticPart) == partsAfterAlleyCommit, "Duplicate alley result should not add parts.");
~~~

Replace the Boss commit statement with:

~~~csharp
Assert(session.CommitBattleResult(bossBattle.Result), "First boss result submission should commit.");
int fishAfterBossCommit = session.GetResource(ResourceId.DriedFish);
Assert(!session.CommitBattleResult(bossBattle.Result), "Duplicate boss result submission should be rejected.");
Assert(session.GetResource(ResourceId.DriedFish) == fishAfterBossCommit, "Duplicate boss result should not add fish.");
~~~

Add this report line after the Boss checks:

~~~csharp
checks.Add("PASS  Duplicate battle settlement IDs are rejected without extra rewards");
~~~

- [ ] **Step 4: Run the full EditMode suite and editor self-check**

Run the Task 2 test command with result paths EditMode-Task7.xml and EditMode-Task7.log.

Then run:

~~~powershell
& 'C:\Program Files\Unity2022.3.62f3\Editor\Unity.exe' -batchmode -nographics -quit -projectPath 'D:\UnityProject\Meowblade' -executeMethod Meowblade.Editor.ProjectTools.RunSelfChecks -logFile 'D:\UnityProject\Meowblade\Logs\SelfCheck-Task7.log'
Select-String -Path Logs\MeowbladeSelfCheck.log -Pattern 'RESULT: PASSED|Duplicate battle settlement'
~~~

Expected: 29 EditMode tests pass; the self-check report contains RESULT: PASSED and the new duplicate-settlement pass line.

- [ ] **Step 5: Commit battle and self-check coverage**

Run:

~~~powershell
git add -- Assets/Tests/EditMode/BattleSimulationTests.cs Assets/Tests/EditMode/BattleSimulationTests.cs.meta Assets/Scripts/Editor/ProjectTools.cs
git commit -m "test: verify deterministic battle settlements"
~~~

---

### Task 8: Isolate Automated Player Saves and Exercise Allocation UI

**Files:**
- Create: Assets/Scripts/Runtime/Application/PlayerLaunchOptions.cs
- Create after Unity import: Assets/Scripts/Runtime/Application/PlayerLaunchOptions.cs.meta
- Create: Assets/Tests/EditMode/PlayerLaunchOptionsTests.cs
- Create after Unity import: Assets/Tests/EditMode/PlayerLaunchOptionsTests.cs.meta
- Modify: Assets/Scripts/Runtime/Presentation/UI/AppBootstrap.cs:39-79, 263-360

**Interfaces:**
- Consumes: GameContext.CreateForSavePath and existing AppBootstrap smoke/visual modes.
- Produces: PlayerLaunchOptions.Parse(string[] args), support for -meowbladeSavePath, and a smoke test that opens the allocation modal and commits 3/0/0 through its real buttons.

- [ ] **Step 1: Write failing launch-option tests**

Create Assets/Tests/EditMode/PlayerLaunchOptionsTests.cs:

~~~csharp
using NUnit.Framework;

namespace Meowblade.Tests
{
    public sealed class PlayerLaunchOptionsTests
    {
        [Test]
        public void Parse_DefaultsToNormalLaunch()
        {
            PlayerLaunchOptions options = PlayerLaunchOptions.Parse(new string[0]);

            Assert.That(options.SmokeTest, Is.False);
            Assert.That(options.VisualTest, Is.False);
            Assert.That(options.SavePath, Is.Empty);
            Assert.That(options.ScreenshotDirectory, Is.Empty);
        }

        [Test]
        public void Parse_ReadsSmokeAndIsolatedSavePathCaseInsensitively()
        {
            PlayerLaunchOptions options = PlayerLaunchOptions.Parse(new[]
            {
                "-MEOWBLADESMOKETEST",
                "-meowbladeSavePath",
                @"D:\UnityProject\Meowblade\Temp\smoke.json"
            });

            Assert.That(options.SmokeTest, Is.True);
            Assert.That(options.SavePath, Is.EqualTo(@"D:\UnityProject\Meowblade\Temp\smoke.json"));
        }

        [Test]
        public void Parse_ReadsVisualScreenshotDirectory()
        {
            PlayerLaunchOptions options = PlayerLaunchOptions.Parse(new[]
            {
                "-meowbladeVisualTest",
                "-meowbladeScreenshotDir",
                @"D:\UnityProject\Meowblade\Logs\Screenshots"
            });

            Assert.That(options.VisualTest, Is.True);
            Assert.That(options.ScreenshotDirectory, Is.EqualTo(@"D:\UnityProject\Meowblade\Logs\Screenshots"));
        }

        [Test]
        public void Parse_MissingValueLeavesOptionEmpty()
        {
            PlayerLaunchOptions options = PlayerLaunchOptions.Parse(new[] { "-meowbladeSavePath" });

            Assert.That(options.SavePath, Is.Empty);
        }
    }
}
~~~

- [ ] **Step 2: Run launch-option tests and verify the red state**

Run the Task 2 Unity command with result paths EditMode-Task8-Red.xml and EditMode-Task8-Red.log.

Expected: compilation fails because PlayerLaunchOptions does not exist.

- [ ] **Step 3: Implement the pure launch-option parser**

Create Assets/Scripts/Runtime/Application/PlayerLaunchOptions.cs:

~~~csharp
using System;

namespace Meowblade
{
    public sealed class PlayerLaunchOptions
    {
        public bool SmokeTest { get; private set; }
        public bool VisualTest { get; private set; }
        public string SavePath { get; private set; }
        public string ScreenshotDirectory { get; private set; }

        private PlayerLaunchOptions()
        {
            SavePath = string.Empty;
            ScreenshotDirectory = string.Empty;
        }

        public static PlayerLaunchOptions Parse(string[] arguments)
        {
            PlayerLaunchOptions options = new PlayerLaunchOptions();
            string[] values = arguments ?? new string[0];
            for (int i = 0; i < values.Length; i++)
            {
                if (string.Equals(values[i], "-meowbladeSmokeTest", StringComparison.OrdinalIgnoreCase))
                {
                    options.SmokeTest = true;
                }
                else if (string.Equals(values[i], "-meowbladeVisualTest", StringComparison.OrdinalIgnoreCase))
                {
                    options.VisualTest = true;
                }
                else if (string.Equals(values[i], "-meowbladeSavePath", StringComparison.OrdinalIgnoreCase) && i + 1 < values.Length)
                {
                    options.SavePath = values[++i];
                }
                else if (string.Equals(values[i], "-meowbladeScreenshotDir", StringComparison.OrdinalIgnoreCase) && i + 1 < values.Length)
                {
                    options.ScreenshotDirectory = values[++i];
                }
            }

            return options;
        }
    }
}
~~~

- [ ] **Step 4: Use launch options before session initialization**

Add an AppBootstrap field:

~~~csharp
private PlayerLaunchOptions _launchOptions;
~~~

At the start of Awake, after the duplicate-instance guard, parse arguments and choose the context:

~~~csharp
_launchOptions = PlayerLaunchOptions.Parse(Environment.GetCommandLineArgs());
GameContext context = string.IsNullOrWhiteSpace(_launchOptions.SavePath)
    ? GameContext.CreateDefault()
    : GameContext.CreateForSavePath(_launchOptions.SavePath);
Session = context.Session;
~~~

Remove the existing unconditional GameContext.CreateDefault assignment.

Replace Start with:

~~~csharp
private void Start()
{
    if (_launchOptions.VisualTest)
    {
        StartCoroutine(RunAutomatedVisualTest(_launchOptions.ScreenshotDirectory));
        return;
    }

    if (_launchOptions.SmokeTest)
    {
        StartCoroutine(RunAutomatedSmokeTest());
    }
}
~~~

Change RunAutomatedVisualTest to accept the already-parsed directory string and remove GetArgumentValue from AppBootstrap.

- [ ] **Step 5: Exercise allocation through the real smoke-test buttons**

In RunAutomatedSmokeTest, after art validation and before ShowFormation, invoke these exact UI paths in order:

~~~csharp
bool allocationUiReady =
    TryInvokeButton("HomeScreen/Allocation") &&
    TryInvokeButton("AllocationModal/Panel/Row_Fish/Minus") &&
    TryInvokeButton("AllocationModal/Panel/Row_Parts/Minus") &&
    TryInvokeButton("AllocationModal/Panel/Row_Cardboard/Plus") &&
    TryInvokeButton("AllocationModal/Panel/Row_Cardboard/Plus") &&
    TryInvokeButton("AllocationModal/Panel/Confirm");
yield return null;

bool allocationCommitted =
    Session.GetWorkers(StationId.Cardboard) == 3 &&
    Session.GetWorkers(StationId.Fish) == 0 &&
    Session.GetWorkers(StationId.Parts) == 0;
~~~

Add:

~~~csharp
private bool TryInvokeButton(string path)
{
    Transform target = _canvas == null ? null : _canvas.transform.Find(path);
    Button button = target == null ? null : target.GetComponent<Button>();
    if (button == null)
    {
        return false;
    }

    button.onClick.Invoke();
    return true;
}
~~~

Include allocationUiReady and allocationCommitted in the passed expression and smoke summary. A smoke pass must therefore prove the modal opened and a legal allocation was committed through UI callbacks.

- [ ] **Step 6: Run all EditMode tests**

Run the Task 2 Unity command with result paths EditMode-Task8-Green.xml and EditMode-Task8-Green.log.

Expected: 33 tests pass, 0 fail.

- [ ] **Step 7: Commit launch isolation and smoke interaction**

Run:

~~~powershell
git add -- Assets/Scripts/Runtime/Application/PlayerLaunchOptions.cs Assets/Scripts/Runtime/Application/PlayerLaunchOptions.cs.meta Assets/Scripts/Runtime/Presentation/UI/AppBootstrap.cs Assets/Tests/EditMode/PlayerLaunchOptionsTests.cs Assets/Tests/EditMode/PlayerLaunchOptionsTests.cs.meta
git commit -m "test: isolate and strengthen player smoke checks"
~~~

---

### Task 9: Add Scene Integrity Tests and the Repeatable Windows Verification Script

**Files:**
- Create: Assets/Tests/EditMode/ProjectIntegrityTests.cs
- Create after Unity import: Assets/Tests/EditMode/ProjectIntegrityTests.cs.meta
- Modify: Assets/Scripts/Editor/ProjectTools.cs:223-254
- Modify: Assets/Scripts/Editor/UnityMcpBootstrap.cs:21-44
- Create: Tools/Verify-Graybox.ps1

**Interfaces:**
- Consumes: Player -meowbladeSavePath support from Task 8 and the editor build method already present in ProjectTools.
- Produces: a scene missing-component guard, batch-safe Unity MCP behavior, RunSelfChecksFromCommandLine, a clean non-regenerating Windows build, and Tools/Verify-Graybox.ps1.

- [ ] **Step 1: Add a scene integrity characterization test**

Create Assets/Tests/EditMode/ProjectIntegrityTests.cs:

~~~csharp
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Meowblade.Tests
{
    public sealed class ProjectIntegrityTests
    {
        private const string ScenePath = "Assets/Meowblade/Scenes/MeowbladeDemo.unity";

        [Test]
        public void GameScene_HasNoMissingComponents()
        {
            Scene scene = EditorSceneManager.OpenScene(ScenePath, OpenSceneMode.Additive);
            try
            {
                GameObject[] roots = scene.GetRootGameObjects();
                for (int rootIndex = 0; rootIndex < roots.Length; rootIndex++)
                {
                    Component[] components = roots[rootIndex].GetComponentsInChildren<Component>(true);
                    for (int componentIndex = 0; componentIndex < components.Length; componentIndex++)
                    {
                        Assert.That(
                            components[componentIndex],
                            Is.Not.Null,
                            "Missing component under scene root " + roots[rootIndex].name);
                    }
                }
            }
            finally
            {
                EditorSceneManager.CloseScene(scene, true);
            }
        }
    }
}
~~~

Run the Task 2 Unity command with result paths EditMode-Task9-Integrity.xml and EditMode-Task9-Integrity.log.

Expected: 34 tests pass, 0 fail. If this test reports a missing component, run Meowblade.Editor.ProjectTools.GenerateFromCommandLine once, inspect that the scene still contains only MeowbladeBootstrap and Main Camera, then rerun the test before continuing.

- [ ] **Step 2: Prevent Unity MCP from starting during batch verification**

At the beginning of the UnityMcpBootstrap static constructor add:

~~~csharp
if (Application.isBatchMode)
{
    return;
}
~~~

Interactive Editor behavior remains unchanged; only batch imports, tests, and builds skip local HTTP server startup.

- [ ] **Step 3: Separate self-check and build entry points from scene generation**

Add to ProjectTools:

~~~csharp
public static void RunSelfChecksFromCommandLine()
{
    RunSelfChecks();
}
~~~

Replace the first line of BuildWindowsFromCommandLine with:

~~~csharp
if (!File.Exists(ScenePath))
{
    throw new FileNotFoundException("Required game scene is missing.", ScenePath);
}
~~~

Set build options to:

~~~csharp
options.options = BuildOptions.Development | BuildOptions.CleanBuildCache;
~~~

Do not call GenerateGameScene from either verification entry point. GenerateGameScene remains available as an explicit repair/setup command.

- [ ] **Step 4: Create the unified PowerShell verification script**

Create Tools/Verify-Graybox.ps1:

~~~powershell
[CmdletBinding()]
param(
    [string]$UnityPath = 'C:\Program Files\Unity2022.3.62f3\Editor\Unity.exe'
)

$ErrorActionPreference = 'Stop'
$projectRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..'))
$logsRoot = Join-Path $projectRoot 'Logs'
$buildRoot = [IO.Path]::GetFullPath((Join-Path $projectRoot 'Builds\Windows'))
$tempRoot = [IO.Path]::GetFullPath((Join-Path $projectRoot 'Temp\GrayboxVerify'))
$playerPath = Join-Path $buildRoot 'MeowbladeDemo.exe'

if (-not (Test-Path -LiteralPath $UnityPath -PathType Leaf)) {
    throw "Unity Editor not found: $UnityPath"
}

$workspacePrefix = $projectRoot.TrimEnd([IO.Path]::DirectorySeparatorChar) + [IO.Path]::DirectorySeparatorChar
if (-not $buildRoot.StartsWith($workspacePrefix, [StringComparison]::OrdinalIgnoreCase)) {
    throw "Refusing to clean build path outside workspace: $buildRoot"
}

New-Item -ItemType Directory -Force -Path $logsRoot, $tempRoot | Out-Null
if (Test-Path -LiteralPath $buildRoot) {
    Remove-Item -LiteralPath $buildRoot -Recurse -Force
}
New-Item -ItemType Directory -Force -Path $buildRoot | Out-Null

function Invoke-Unity {
    param(
        [string]$Label,
        [string[]]$Arguments
    )

    & $UnityPath @Arguments
    if ($LASTEXITCODE -ne 0) {
        throw "$Label failed with exit code $LASTEXITCODE"
    }
}

function Assert-CleanLog {
    param([string]$Path)

    $forbidden = Select-String -Path $Path -Pattern 'The referenced script.*is missing|MissingReferenceException|NullReferenceException|error CS\d+|\[Meowblade Demo Smoke Test\] FAILED'
    if ($forbidden) {
        $forbidden | ForEach-Object { Write-Error $_.Line }
        throw "Forbidden log entry found in $Path"
    }
}

$testResults = Join-Path $logsRoot 'GrayboxEditMode.xml'
$testLog = Join-Path $logsRoot 'GrayboxEditMode.log'
Invoke-Unity 'EditMode tests' @(
    '-batchmode', '-nographics',
    '-projectPath', $projectRoot,
    '-runTests', '-testPlatform', 'EditMode',
    '-testResults', $testResults,
    '-logFile', $testLog
)

[xml]$testXml = Get-Content -LiteralPath $testResults
if ([int]$testXml.'test-run'.failed -ne 0) {
    throw "EditMode tests reported $($testXml.'test-run'.failed) failures"
}

$selfCheckLog = Join-Path $logsRoot 'GrayboxSelfCheckEditor.log'
Invoke-Unity 'Editor self-check' @(
    '-batchmode', '-nographics', '-quit',
    '-projectPath', $projectRoot,
    '-executeMethod', 'Meowblade.Editor.ProjectTools.RunSelfChecksFromCommandLine',
    '-logFile', $selfCheckLog
)

$selfCheckReport = Join-Path $logsRoot 'MeowbladeSelfCheck.log'
if (-not (Select-String -Path $selfCheckReport -Pattern '^RESULT: PASSED$')) {
    throw 'Editor self-check report did not pass.'
}

$buildLog = Join-Path $logsRoot 'GrayboxWindowsBuild.log'
Invoke-Unity 'Windows build' @(
    '-batchmode', '-nographics', '-quit',
    '-projectPath', $projectRoot,
    '-executeMethod', 'Meowblade.Editor.ProjectTools.BuildWindowsFromCommandLine',
    '-meowbladeBuildPath', $playerPath,
    '-logFile', $buildLog
)

Assert-CleanLog $buildLog
if (-not (Test-Path -LiteralPath $playerPath -PathType Leaf)) {
    throw "Player was not created: $playerPath"
}

$matrix = @(
    [pscustomobject]@{ Name = '720p'; Width = 1280; Height = 720 },
    [pscustomobject]@{ Name = '1080p'; Width = 1920; Height = 1080 },
    [pscustomobject]@{ Name = '1440p'; Width = 2560; Height = 1440 },
    [pscustomobject]@{ Name = 'UltraWide'; Width = 2340; Height = 1080 }
)

$runStamp = Get-Date -Format 'yyyyMMdd-HHmmss'
foreach ($case in $matrix) {
    $playerLog = Join-Path $logsRoot ("GrayboxSmoke-{0}.log" -f $case.Name)
    $savePath = Join-Path $tempRoot ("smoke-{0}-{1}.json" -f $runStamp, $case.Name)
    $arguments = @(
        '-batchmode',
        '-screen-fullscreen', '0',
        '-screen-width', [string]$case.Width,
        '-screen-height', [string]$case.Height,
        '-logFile', $playerLog,
        '-meowbladeSmokeTest',
        '-meowbladeSavePath', $savePath
    )

    $process = Start-Process -FilePath $playerPath -ArgumentList $arguments -Wait -PassThru -WindowStyle Hidden
    if ($process.ExitCode -ne 0) {
        throw "Player smoke $($case.Name) failed with exit code $($process.ExitCode)"
    }

    Assert-CleanLog $playerLog
    if (-not (Select-String -Path $playerLog -Pattern '\[Meowblade Demo Smoke Test\] PASSED:')) {
        throw "Player smoke $($case.Name) did not emit PASSED."
    }
}

Write-Host "Graybox verification passed: $($testXml.'test-run'.passed) EditMode tests, editor self-check, Windows build, and 4 Player smoke cases."
~~~

- [ ] **Step 5: Run the unified script**

Close interactive Unity instances for this project, then run:

~~~powershell
powershell -ExecutionPolicy Bypass -File Tools\Verify-Graybox.ps1
~~~

Expected:

- 34 EditMode tests pass, 0 fail;
- editor self-check report says PASSED;
- a fresh Windows x64 Player is built;
- all four Player runs exit 0 and emit PASSED;
- no scanned log contains missing script, NullReferenceException, MissingReferenceException, C# compilation error, or smoke FAILED;
- each smoke run uses its own Temp/GrayboxVerify save.

- [ ] **Step 6: Commit repeatable verification**

Run:

~~~powershell
git add -- Assets/Tests/EditMode/ProjectIntegrityTests.cs Assets/Tests/EditMode/ProjectIntegrityTests.cs.meta Assets/Scripts/Editor/ProjectTools.cs Assets/Scripts/Editor/UnityMcpBootstrap.cs Tools/Verify-Graybox.ps1
git commit -m "build: add repeatable graybox verification"
~~~

---

### Task 10: Publish Fresh Verification Evidence and the Playtest 01 Worksheet

**Files:**
- Modify: Doc/喵剑奇箱_Demo运行说明.md
- Create: Doc/Playtest/Graybox_Playtest_01.md

**Interfaces:**
- Consumes: fresh Logs/GrayboxEditMode.xml, Logs/MeowbladeSelfCheck.log, Logs/GrayboxWindowsBuild.log, and the four Logs/GrayboxSmoke-*.log files from Task 9.
- Produces: reproducible operator instructions and a human-playtest worksheet. It does not claim the core loop is validated before sessions occur.

- [ ] **Step 1: Extract fresh evidence from generated outputs**

Run:

~~~powershell
[xml]$results = Get-Content -LiteralPath Logs\GrayboxEditMode.xml
"EDITMODE_TOTAL=$($results.'test-run'.total)"
"EDITMODE_PASSED=$($results.'test-run'.passed)"
"EDITMODE_FAILED=$($results.'test-run'.failed)"
Get-Content -Encoding utf8 Logs\MeowbladeSelfCheck.log
Select-String -Path Logs\GrayboxSmoke-*.log -Pattern '\[Meowblade Demo Smoke Test\] PASSED:'
Get-Item Builds\Windows\MeowbladeDemo.exe | Select-Object FullName,Length,LastWriteTime
~~~

Expected: values match the successful Task 9 run. Do not copy counts or timestamps from older logs.

- [ ] **Step 2: Update the Demo run guide**

In Doc/喵剑奇箱_Demo运行说明.md:

- change the current verification section to identify the fresh verification date as 2026-08-06;
- record the actual EditMode total/passed/failed values extracted in Step 1;
- record the current self-check alley and Boss times from Logs/MeowbladeSelfCheck.log;
- record all four current smoke summaries;
- document the one-command entry:

~~~powershell
powershell -ExecutionPolicy Bypass -File Tools\Verify-Graybox.ps1
~~~

- state that Unity must not already have this project open;
- state that test saves are created under Temp/GrayboxVerify and normal Application.persistentDataPath saves are not used;
- state that Builds and Logs are local generated outputs and are not committed;
- retain Android as unverified and outside Graybox Baseline v0.1;
- replace any claim that the graybox proves the 6–8 minute player loop with the narrower statement that the engineering baseline is ready for Playtest 01.

- [ ] **Step 3: Create the playtest worksheet**

Create Doc/Playtest/Graybox_Playtest_01.md:

~~~markdown
# Graybox Playtest 01 记录表

## 研究口径

- 参与者未阅读设计文档；
- 使用重置后的独立存档；
- 不口头讲解玩法；
- 从首次进入猫宅开始；
- 到击败 Boss 回城、明确放弃或研究者因阻断错误终止为止；
- 观察者只记录，不在过程中纠正。

## 单次记录

参与者编号：

开始时间：

结束时间：

结果：完成 Boss 回城 / 主动放弃 / 阻断错误

### 关键时间点

| 事件 | 时间 | 观察 |
|---|---:|---|
| 看出猫在生产资源 | | |
| 第一次打开分工 | | |
| 完成第一次分工修改 | | |
| 进入普通关 | | |
| 普通关结束 | | |
| 第一次治疗、补员或查看披风 | | |
| 进入 Boss | | |
| 第一次使用号令 | | |
| Boss 结束 | | |
| 返回升级后的猫宅 | | |

### 理解检查

- 10 秒内理解猫在生产：是 / 否
- 理解工人总数只有 3：是 / 否
- 能预测重新分工后的资源变化：是 / 否
- 普通关后主动治疗、补员或制作：是 / 否
- 能说出披风、前后排或号令的一种 Boss 克制作用：是 / 否

### 等待与阻塞

记录所有超过 15 秒且没有观察价值或决策的等待：

记录所有误触、文本误解、无法继续和研究者解释：

### 参与者原话

记录对生产、战损、披风、Boss 和回城成长的原话：

## 批次汇总

| 指标 | 结果 |
|---|---:|
| 有效参与者数 | |
| 无讲解完成分工人数 | |
| 能解释资源速度变化人数 | |
| 普通关后主动完成整备人数 | |
| 理解至少一种 Boss 克制人数 | |
| 成功流程中位时长 | |
| 存在系统性 15 秒无意义等待 | 是 / 否 |
| 存在阻断流程错误 | 是 / 否 |

## 进入视觉切片的门槛

- 至少 4 名有效参与者，或 3 名参与者给出高度一致的结果；
- 多数玩家无需讲解即可完成一次工人重新分配；
- 多数玩家能说出重新分配对至少一种资源速度的影响；
- 多数玩家在第一关后主动完成治疗、补员或披风制作中的至少一项；
- 多数玩家理解至少一种 Boss 克制手段；
- 完整成功流程中位数为 6～8 分钟；
- 不存在系统性超过 15 秒的无意义等待；
- 没有阻断流程的存档、结算或界面错误。

## 决策

- 进入正式视觉切片；
- 继续调整生产节奏、信息层级、操作反馈、战损包装或 Boss 克制；
- 样本不足，只形成下一轮假设。

不得用新系统、新资源或新关卡补偿本轮暴露的问题。
~~~

- [ ] **Step 4: Verify documentation consistency**

Run:

~~~powershell
rg -n -i '\x54\x4f\x44\x4f|\x54\x42\x44|尚未执行.*已完成|Android.*已验证' Doc\喵剑奇箱_Demo运行说明.md Doc\Playtest\Graybox_Playtest_01.md
git diff --check
git status --short
~~~

Expected: no unfinished-marker hit, no Android-complete claim, no whitespace errors, and only the run guide plus playtest worksheet remain uncommitted from this task. Unity does not create .meta files outside Assets.

- [ ] **Step 5: Commit documentation and worksheet**

Run:

~~~powershell
git add -- Doc/喵剑奇箱_Demo运行说明.md Doc/Playtest/Graybox_Playtest_01.md
git commit -m "docs: publish graybox verification and playtest guide"
~~~

- [ ] **Step 6: Perform the final baseline audit**

Run:

~~~powershell
powershell -ExecutionPolicy Bypass -File Tools\Verify-Graybox.ps1
git diff --check HEAD^ HEAD
git status --short --branch
git log -10 --oneline
~~~

Expected:

- the full verification script passes again;
- no intended source, scene, test, tool, package, project-setting, or document file is untracked;
- generated Builds, Logs, Library, Temp, UserSettings, and .unitycowork remain ignored;
- the branch contains the approved spec, pre-implementation checkpoint, scoped implementation commits, and documentation evidence;
- the engineering baseline is complete, while Playtest 01 remains a human activity and is not falsely reported as passed.
