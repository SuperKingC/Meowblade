# Spine Character Animation Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Replace the prototype's static hero sprites with three Spine 4.3.23 character rigs and connect their animations to battle, formation, and home-screen presentation.

**Architecture:** Keep `BattleSimulation` and game rules unchanged. Add a presentation abstraction (`ICharacterAnimator`) and a Spine-backed implementation that consumes animation commands from a bridge; UI screens depend on the abstraction, not on Spine APIs. Generate Spine-ready layered PNGs from the approved lineup image, create a first-pass `.spine` project with the installed Spine CLI, export matching Spine 4.3 data, and validate the result in Unity 2022.3.62f3.

**Tech Stack:** Unity 2022.3.62f3, UGUI, Spine Editor 4.3.23 Professional, spine-unity 4.3.x, C#, Unity Test Framework 1.1.33, Python 3 + Pillow + NumPy, PowerShell.

## Global Constraints

- Use the installed Spine CLI at `D:\Spine\Spine.com`; its local version is Spine Editor 4.3.23 Professional.
- Keep Spine Editor, exported skeleton data, and `spine-unity` on the same 4.3 major/minor line.
- Do not modify `BattleSimulation` rules, damage values, cooldowns, movement logic, saves, or win/loss computation.
- Use the approved master image `Assets/Art/art_master_heroes_lineup_v01.png` as the source for the three hero appearances.
- The three heroes must support `idle`, `move`, `attack`, `skill`, `hit`, `retreat`, and `victory`.
- Use `SkeletonGraphic` for UGUI screens and keep the existing `UnitRoot` responsible for battlefield position and HUD layout.
- Animation failures must fall back to static sprites and must not stop battle ticking or settlement.
- Do not commit user-owned unrelated changes already present in the working tree.
- Run tests and compile checks before claiming completion.

---

## File Map

### Assets and tooling

- Create: `Assets/Art/Production/SpineReady/` — source layered PNGs and extraction preview.
- Create: `Assets/Art/Production/Spine/MeowbladeHeroes.spine` — editable Spine project generated and validated by Spine 4.3.23.
- Create: `Assets/Art/Production/Spine/Export/` — exported `.json` or `.skel.bytes`, `.atlas.txt`, and packed PNGs.
- Modify: `Tools/Art/process_concept_assets.py` — add master-sheet extraction for Spine-ready assets without changing existing runtime derivatives.
- Create: `Tools/Spine/generate_hero_skeleton.py` — deterministic first-pass skeleton/animation data generator used by Spine CLI.
- Create: `Tools/Spine/export_heroes.ps1` — version-checked Spine CLI export wrapper.

### Runtime presentation

- Create: `Assets/Scripts/Runtime/Presentation/Animation/ICharacterAnimator.cs` — presentation-neutral animation interface.
- Create: `Assets/Scripts/Runtime/Presentation/Animation/CharacterAnimationCommand.cs` — states, priorities, effects, and command data.
- Create: `Assets/Scripts/Runtime/Presentation/Animation/CharacterAnimationProfile.cs` — per-hero timing and effect configuration.
- Create: `Assets/Scripts/Runtime/Presentation/Animation/CharacterAnimationProfiles.cs` — profile registry and fallback profile.
- Create: `Assets/Scripts/Runtime/Presentation/Animation/SpineCharacterAnimator.cs` — Spine `SkeletonGraphic` wrapper and safe fallback behavior.
- Create: `Assets/Scripts/Runtime/Presentation/Animation/CharacterEffectPlayer.cs` — lightweight UGUI effects and bounded pooling.
- Create: `Assets/Scripts/Runtime/Presentation/Animation/BattleAnimationBridge.cs` — event-batch-to-animation command translation.
- Modify: `Assets/Scripts/Runtime/Presentation/UI/ArtLibrary.cs` — exported Spine asset lookup, runtime Sprite fallback, and validation.
- Modify: `Assets/Scripts/Runtime/Presentation/UI/BattleScreens.cs` — create Spine unit hierarchy, tick bridge, process grouped events, and preserve HUD layout.
- Modify: `Assets/Scripts/Runtime/Presentation/UI/HomeScreen.cs` — add hero Spine previews to station cards without covering station text or buttons.
- Modify: `Assets/Scripts/Runtime/Presentation/UI/FormationScreen.cs` in `BattleScreens.cs` — add selected/idle hero card previews.
- Modify: `Assets/Scripts/Editor/ProjectTools.cs` — validate Spine exports and include Spine assets in self-check diagnostics.
- Modify: `Packages/manifest.json` and `Packages/packages-lock.json` — pin the official spine-unity 4.3 package source/version once located.

### Tests

- Create: `Assets/Tests.meta`.
- Create: `Assets/Tests/EditMode.meta`.
- Create: `Assets/Tests/EditMode/Meowblade.EditModeTests.asmdef`.
- Create: `Assets/Tests/EditMode/CharacterAnimationTests.cs` — pure state-machine tests.
- Create: `Assets/Tests/EditMode/BattleAnimationBridgeTests.cs` — grouped event translation tests.
- Create: `Assets/Tests/EditMode/SpineAssetContractTests.cs` — asset naming and fallback contract tests.

---

## Task 1: Pin the Spine Runtime and establish a compile-safe adapter

**Files:**

- Modify: `Packages/manifest.json`
- Modify: `Packages/packages-lock.json`
- Create: `Assets/Scripts/Runtime/Presentation/Animation/ICharacterAnimator.cs`
- Create: `Assets/Scripts/Runtime/Presentation/Animation/CharacterAnimationCommand.cs`
- Create: `Assets/Scripts/Runtime/Presentation/Animation/CharacterAnimationProfile.cs`
- Create: `Assets/Scripts/Runtime/Presentation/Animation/CharacterAnimationProfiles.cs`

**Interfaces:**

- `ICharacterAnimator` exposes `Play(CharacterAnimationCommand command)`, `SetBaseState(CharacterAnimationState state)`, `Tick(float deltaTime, float playbackSpeed)`, `ResetVisualState()`, and `IsTerminated`.
- `CharacterAnimationState` values are `Idle`, `Move`, `Attack`, `Skill`, `Hit`, `Retreat`, `Victory`, `Down`, and `Selected`.
- `CharacterAnimationCommand` carries state, source unit ID, target unit ID, effect kind, and optional value.
- The command/profile types must not reference Spine namespaces, so EditMode tests compile even when the Runtime package is temporarily unavailable.

- [ ] **Step 1: Add the direct spine-unity dependency only after locating the official 4.3 package**

  Search the installed Spine directory and Unity package cache for the official `spine-unity` 4.3 package. If no package is present, record the exact missing path in the plan execution log and obtain the official package through Spine's normal installation flow; do not substitute an unofficial fork. Add the package using the project's existing package convention and keep the package version aligned with Spine 4.3.23.

- [ ] **Step 2: Create the presentation-neutral command and profile contracts**

  Define a small enum-based API. `CharacterAnimationProfile` stores durations, amplitudes, and `HeroId`; `CharacterAnimationProfiles.ForHero(HeroId)` returns a deterministic profile and `Fallback` for unknown IDs. Keep all public types in namespace `Meowblade`.

- [ ] **Step 3: Add the EditMode assembly and write failing contract tests**

  Add `Meowblade.EditModeTests.asmdef` referencing `Meowblade.Runtime`, `UnityEngine.TestRunner`, and `UnityEditor.TestRunner`. Write tests asserting all required states exist, hero profiles exist for all `GameBalance.AllHeroes`, and every one-shot state has a positive duration.

- [ ] **Step 4: Run the focused EditMode tests**

  Run:

  ```powershell
  & 'C:\Program Files\Unity2022.3.62f3\Editor\Unity.exe' -batchmode -nographics -projectPath 'D:\UnityProject\Meowblade' -runTests -testPlatform EditMode -testResults 'D:\UnityProject\Meowblade\Logs\SpineAnimation-Task1.xml' -logFile 'D:\UnityProject\Meowblade\Logs\SpineAnimation-Task1.log'
  ```

  Expected before implementation: the new tests fail because the command/profile types are absent. Expected after the minimal contracts are added: PASS.

- [ ] **Step 5: Commit the adapter foundation**

  ```powershell
  git add -- Packages/manifest.json Packages/packages-lock.json Assets/Scripts/Runtime/Presentation/Animation Assets/Tests
  git commit -m "feat: add spine animation contracts"
  ```

## Task 2: Produce and validate Spine-ready layered hero assets

**Files:**

- Modify: `Tools/Art/process_concept_assets.py`
- Create: `Tools/Spine/README.md`
- Create: `Assets/Art/Production/SpineReady/cardboard_knight/`
- Create: `Assets/Art/Production/SpineReady/fish_hunter/`
- Create: `Assets/Art/Production/SpineReady/yarn_mage/`
- Create: `Assets/Art/Production/SpineReady/hero_layer_manifest.json`

**Interfaces:**

- The layer manifest maps each hero to `root`, `body`, `head`, `arm_front`, `arm_back`, `weapon`, `equipment_front`, `equipment_back`, `tail`, and `effect_anchor`.
- PNG layer names must remain stable because the skeleton generator and Spine project reference them.
- Existing runtime derivative filenames must remain unchanged.

- [ ] **Step 1: Write a deterministic extraction validation script**

  Extend the art pipeline with a `build_spine_ready_layers()` function that reads `Assets/Art/art_master_heroes_lineup_v01.png`, writes transparent 2048-safe layer PNGs, and emits a manifest containing source crop, output dimensions, alpha bounding box, and layer names. Fail when a required layer is empty or has no alpha pixels.

- [ ] **Step 2: Generate the first layer set and preview**

  Run:

  ```powershell
  python Tools/Art/process_concept_assets.py --spine-ready
  ```

  Generate `Assets/Art/Production/SpineReady/spine_ready_preview_v01.png`. Keep source concept art untouched. The first pass may reuse masked full-body regions where true separation is impossible; mark those regions in the manifest as `shared` so Spine does not receive fabricated hidden geometry.

- [ ] **Step 3: Review image dimensions and alpha bounds**

  Run a PowerShell/Python validation that every manifest path exists, every PNG is RGBA, alpha bounding boxes are non-empty, and no output exceeds 2048×2048. Open the preview and check that the three hero silhouettes, weapons, and color identity match the approved lineup.

- [ ] **Step 4: Commit only the new Spine-ready asset set**

  ```powershell
  git add -- Tools/Art/process_concept_assets.py Tools/Spine/README.md Assets/Art/Production/SpineReady
  git commit -m "art: prepare spine-ready hero layers"
  ```

## Task 3: Generate, open, and export the first Spine 4.3.23 project

**Files:**

- Create: `Tools/Spine/generate_hero_skeleton.py`
- Create: `Tools/Spine/export_heroes.ps1`
- Create: `Assets/Art/Production/Spine/MeowbladeHeroes.spine`
- Create: `Assets/Art/Production/Spine/Export/`
- Modify: `Assets/Art/Production/Spine/README.md`

**Interfaces:**

- The skeleton generator consumes `hero_layer_manifest.json` and emits a Spine 4.3-compatible skeleton source with bones, slots, skins, attachments, animations, and named event/attachment points.
- The export wrapper accepts no credentials, checks `Spine.com --version` contains `Spine 4.3.23 Professional`, and exports `json+pack` or `binary+pack` into the project export folder.
- All three skeletons use the same animation names and attachment naming convention.

- [ ] **Step 1: Write the skeleton source generator**

  Generate one skeleton per hero with this bone hierarchy:

  ```text
  root
  ├─ body
  │  ├─ head
  │  ├─ arm_back
  │  ├─ arm_front
  │  ├─ weapon
  │  └─ tail
  └─ effects
  ```

  Create slots in draw order `equipment_back`, `tail`, `body`, `arm_back`, `arm_front`, `head`, `weapon`, `equipment_front`, `effects`. Use attachment paths from the manifest and add empty named effect attachment points for `shield_anchor`, `fishbone_anchor`, `yarn_anchor`, and `hit_anchor`.

- [ ] **Step 2: Add the first-pass animation timelines**

  Emit simple, deterministic timelines for every hero:

  - `idle`: 2-second looping body scale/translation and head rotation.
  - `move`: 0.6-second looping body bob and forward lean.
  - `attack`: 0.45-second anticipation, strike, and recovery on weapon/arm bones.
  - `skill`: 0.8-second cast pose and effect-anchor scale.
  - `hit`: 0.25-second recoil.
  - `retreat`: 0.6-second crouch and fade.
  - `victory`: 1.2-second looping celebration pose.

  Keep timing and amplitudes in the generated source, not in `BattleScreens.cs`.

- [ ] **Step 3: Import the generated source through the installed Spine CLI**

  Run:

  ```powershell
  & 'D:\Spine\Spine.com' -i 'D:\UnityProject\Meowblade\Assets\Art\Production\Spine\generated_heroes.json' -o 'D:\UnityProject\Meowblade\Assets\Art\Production\Spine\MeowbladeHeroes.spine' -r
  ```

  Then run `& 'D:\Spine\Spine.com' -i 'D:\UnityProject\Meowblade\Assets\Art\Production\Spine\MeowbladeHeroes.spine'` in a smoke-open step and inspect the project in Spine Editor. If the import reports a schema/version problem, regenerate using the exact 4.3.23 export schema shown by the installed CLI rather than silently downgrading.

- [ ] **Step 4: Export Unity data and atlas**

  Use `export_heroes.ps1` to verify the version, export `json+pack` (or `binary+pack` if Unity import validation prefers it), and assert that each hero has skeleton data, atlas text, packed PNG, and all seven animations.

- [ ] **Step 5: Commit the validated Spine project and export**

  ```powershell
  git add -- Tools/Spine Assets/Art/Production/Spine
  git commit -m "art: create hero spine project and exports"
  ```

## Task 4: Implement the Spine runtime animator and effects

**Files:**

- Create: `Assets/Scripts/Runtime/Presentation/Animation/SpineCharacterAnimator.cs`
- Create: `Assets/Scripts/Runtime/Presentation/Animation/CharacterEffectPlayer.cs`
- Modify: `Assets/Scripts/Runtime/Presentation/Animation/CharacterAnimationProfile.cs`
- Test: `Assets/Tests/EditMode/CharacterAnimationTests.cs`

**Interfaces:**

- `SpineCharacterAnimator : MonoBehaviour, ICharacterAnimator` owns a `SkeletonGraphic`, a `CanvasGroup`, and a fallback `Image`.
- `Play(CharacterAnimationCommand command)` maps states to exact Spine animation names in lower-case.
- `SetBaseState(CharacterAnimationState state)` selects `idle` or `move` on the base track.
- `Tick(float deltaTime, float playbackSpeed)` advances presentation timing without touching simulation time.
- `ResetVisualState()` restores skeleton color, local transform, and fallback visibility.
- `CharacterEffectPlayer.Play(CharacterEffectKind kind, Transform source, Transform target, float playbackSpeed)` handles bounded decorative effects.

- [ ] **Step 1: Add failing pure state-machine tests**

  Test these exact cases:

  ```csharp
  [Test] public void SkillSuppressesAttackOnSameBatch() { ... }
  [Test] public void HitCanInterruptAttack() { ... }
  [Test] public void RetreatTerminatesFurtherCommands() { ... }
  [Test] public void OneShotReturnsToMoveWhenBaseStateIsMove() { ... }
  [Test] public void ResetVisualStateClearsAlphaAndTransform() { ... }
  ```

  Use a fake animator recorder implementing `ICharacterAnimator`; do not instantiate `SkeletonGraphic` in EditMode tests.

- [ ] **Step 2: Implement the minimal Spine-backed adapter**

  Resolve Spine components in `Awake`, set the skeleton to setup pose, and use `AnimationState.SetAnimation` / `AddAnimation` only through a small private adapter. Catch missing `SkeletonGraphic` or missing animation names, log one warning per character/state, show the fallback `Image`, and continue ticking.

- [ ] **Step 3: Implement effect anchors and bounded effects**

  Resolve named Spine slots/bones by `shield_anchor`, `fishbone_anchor`, `yarn_anchor`, and `hit_anchor`. Effects are UGUI child objects with `RectTransform`, `Image`, and `CanvasGroup`; reuse a fixed pool and skip only decorative effects when exhausted.

- [ ] **Step 4: Run focused EditMode tests**

  ```powershell
  & 'C:\Program Files\Unity2022.3.62f3\Editor\Unity.exe' -batchmode -nographics -projectPath 'D:\UnityProject\Meowblade' -runTests -testPlatform EditMode -testResults 'D:\UnityProject\Meowblade\Logs\SpineAnimation-Task4.xml' -logFile 'D:\UnityProject\Meowblade\Logs\SpineAnimation-Task4.log'
  ```

  Expected: PASS, with no dependency on a live Unity scene.

- [ ] **Step 5: Commit the runtime animator**

  ```powershell
  git add -- Assets/Scripts/Runtime/Presentation/Animation Assets/Tests/EditMode/CharacterAnimationTests.cs
  git commit -m "feat: add spine character animator"
  ```

## Task 5: Bridge grouped battle events to Spine animations

**Files:**

- Create: `Assets/Scripts/Runtime/Presentation/Animation/BattleAnimationBridge.cs`
- Modify: `Assets/Scripts/Runtime/Presentation/UI/BattleScreens.cs`
- Test: `Assets/Tests/EditMode/BattleAnimationBridgeTests.cs`

**Interfaces:**

- `BattleAnimationBridge.ProcessBatch(IReadOnlyList<BattleEvent> events, IReadOnlyDictionary<int, ICharacterAnimator> animators, BattleResult result, bool finished)` processes a complete drained event batch.
- `BattleAnimationBridge.UpdateBaseStates(IReadOnlyList<BattleUnit> units, IReadOnlyDictionary<int, ICharacterAnimator> animators)` chooses `Idle` or `Move` from position deltas.
- The bridge reads `BattleResult.Victory` when the simulation first becomes finished; it never parses localized event messages.

- [ ] **Step 1: Write failing grouped-event tests**

  Assert that a batch containing `Skill` and `Damage` from the same source emits one `Skill` and no `Attack`; `Damage` emits `Hit` on the target; `UnitDown` emits `Retreat` for player units; `Command` emits the command effect for alive player units; and a finished victorious result emits `Victory` only for alive player heroes.

- [ ] **Step 2: Implement event grouping**

  First collect all `Skill.SourceUnitId` values. Process `Damage` with floating-text responsibility left in `BattleScreen`; then process `Skill`, `UnitDown`, `Command`, and structured finish state in stable event order.

- [ ] **Step 3: Integrate the bridge into `BattleScreen.ProcessEvents`**

  Keep existing logs, damage numbers, telegraph overlay, and toast behavior. Add a `Dictionary<int, ICharacterAnimator>` alongside each `UnitView`; ensure unit creation happens before event processing so targets are available.

- [ ] **Step 4: Run bridge tests and self-check**

  Run the focused EditMode command from Task 4, then run the editor self-check menu or its existing batch entry point. Expected: battle simulation outputs and existing self-check diagnostics remain unchanged.

- [ ] **Step 5: Commit event integration**

  ```powershell
  git add -- Assets/Scripts/Runtime/Presentation/Animation/BattleAnimationBridge.cs Assets/Scripts/Runtime/Presentation/UI/BattleScreens.cs Assets/Tests/EditMode/BattleAnimationBridgeTests.cs
  git commit -m "feat: bridge battle events to spine animation"
  ```

## Task 6: Replace hero presentation in battle, formation, and home

**Files:**

- Modify: `Assets/Scripts/Runtime/Presentation/UI/ArtLibrary.cs`
- Modify: `Assets/Scripts/Runtime/Presentation/UI/BattleScreens.cs`
- Modify: `Assets/Scripts/Runtime/Presentation/UI/HomeScreen.cs`
- Modify: `Assets/Scripts/Editor/ProjectTools.cs`
- Test: `Assets/Tests/EditMode/SpineAssetContractTests.cs`

**Interfaces:**

- `ArtLibrary.HeroSkeletonData(HeroId)` returns the Spine skeleton resource root or `null`.
- `ArtLibrary.HeroSprite(HeroId)` remains the static fallback.
- `SpineCharacterAnimator.CreatePreview(RectTransform parent, HeroId hero, CharacterAnimationProfile profile)` creates a `SkeletonGraphic` preview without making the card button non-interactable.

- [ ] **Step 1: Write failing asset contract tests**

  Assert that every hero has a Spine export root, all seven animation names are declared in the export manifest, static Sprite fallback remains available, and missing Spine data does not cause `ArtLibrary.ValidateRuntimeAssets` to fail when fallback Sprite exists.

- [ ] **Step 2: Create the battle MotionRoot hierarchy**

  Change `UnitView` to hold `UnitRoot`, `MotionRoot`, `SkeletonGraphic`, fallback `Image`, `CanvasGroup`, bars, labels, and animator. `RefreshUnitViews` updates only `UnitRoot`; `SpineCharacterAnimator` owns `MotionRoot` and visual alpha.

- [ ] **Step 3: Add Spine hero previews to formation cards**

  Replace the static full-body hero card image with a `SkeletonGraphic` when the hero export is present. Keep the existing `Button` as the input owner and route selection to `Selected`; use the static portrait only if the Spine preview cannot initialize.

- [ ] **Step 4: Add three lightweight hero previews to home station cards**

  Add a small non-raycast `SkeletonGraphic` at the station art safe area. Map `StationId.Cardboard` to `CardboardKnight`, `StationId.Fish` to `FishHunter`, and `StationId.Parts` to `YarnMage`; play only `idle` with different phase offsets.

- [ ] **Step 5: Extend self-check asset validation**

  Validate the Spine export folder, atlas, packed PNG, skeleton data, and required animation names. Treat a missing Spine export as a warning only when the corresponding static Sprite fallback exists; treat malformed or mismatched version data as a failure in the Spine-enabled path.

- [ ] **Step 6: Run EditMode tests, compile, and visual smoke test**

  Run:

  ```powershell
  & 'C:\Program Files\Unity2022.3.62f3\Editor\Unity.exe' -batchmode -nographics -projectPath 'D:\UnityProject\Meowblade' -runTests -testPlatform EditMode -testResults 'D:\UnityProject\Meowblade\Logs\SpineAnimation-Task6.xml' -logFile 'D:\UnityProject\Meowblade\Logs\SpineAnimation-Task6.log'
  & 'C:\Program Files\Unity2022.3.62f3\Editor\Unity.exe' -batchmode -nographics -quit -projectPath 'D:\UnityProject\Meowblade' -logFile 'D:\UnityProject\Meowblade\Logs\SpineAnimation-Compile-Task6.log'
  ```

  Run the existing automated visual test with `-meowbladeScreenshotDir` and inspect `01_home_1920x1080.png`, `02_formation_1920x1080.png`, and `03_battle_1920x1080.png`.

- [ ] **Step 7: Commit screen integration**

  ```powershell
  git add -- Assets/Scripts/Runtime/Presentation/UI/ArtLibrary.cs Assets/Scripts/Runtime/Presentation/UI/BattleScreens.cs Assets/Scripts/Runtime/Presentation/UI/HomeScreen.cs Assets/Scripts/Editor/ProjectTools.cs Assets/Tests/EditMode/SpineAssetContractTests.cs
  git commit -m "feat: show spine heroes across game screens"
  ```

## Task 7: Verify Spine export, Unity import, and runtime behavior

**Files:**

- Modify: `Tools/Spine/export_heroes.ps1`
- Modify: `Tools/Spine/README.md`
- Create: `Logs/SpineAnimation-Verification.txt` only as a local ignored report if the existing project convention requires it.

- [ ] **Step 1: Run the version and export contract**

  ```powershell
  & 'D:\Spine\Spine.com' --version
  & 'D:\Spine\Spine.com' -i 'D:\UnityProject\Meowblade\Assets\Art\Production\Spine\MeowbladeHeroes.spine' -o 'D:\UnityProject\Meowblade\Assets\Art\Production\Spine\Export' -e 'json+pack'
  ```

  Assert output contains all three skeletons, their atlases, packed PNGs, and seven required animations.

- [ ] **Step 2: Run Unity import and compile**

  ```powershell
  & 'C:\Program Files\Unity2022.3.62f3\Editor\Unity.exe' -batchmode -nographics -quit -projectPath 'D:\UnityProject\Meowblade' -logFile 'D:\UnityProject\Meowblade\Logs\SpineAnimation-FinalCompile.log'
  ```

  Search the log for `error CS`, `Exception`, `Spine version`, and `Could not load SkeletonData`. Any match fails this task until corrected.

- [ ] **Step 3: Run EditMode tests**

  ```powershell
  & 'C:\Program Files\Unity2022.3.62f3\Editor\Unity.exe' -batchmode -nographics -projectPath 'D:\UnityProject\Meowblade' -runTests -testPlatform EditMode -testResults 'D:\UnityProject\Meowblade\Logs\SpineAnimation-Final.xml' -logFile 'D:\UnityProject\Meowblade\Logs\SpineAnimation-FinalTests.log'
  ```

  Expected: all animation contract, state, bridge, and asset tests pass.

- [ ] **Step 4: Run the game's self-check and visual screenshots**

  Use the existing `Meowblade/Run Self Checks` path and automated visual test. Confirm:

  - `idle` is visibly different for all three heroes.
  - attack and skill animations play once per logical event.
  - hit and retreat do not move bars or labels.
  - victory does not trigger on failure.
  - formation and home previews do not block buttons.
  - `1x` and `2x` preserve animation timing relationships.

- [ ] **Step 5: Commit verification documentation only**

  Commit only reproducible scripts or documentation. Do not commit transient Unity logs, screenshots, license files, or user credentials.

  ```powershell
  git add -- Tools/Spine/export_heroes.ps1 Tools/Spine/README.md
  git commit -m "test: verify spine hero pipeline"
  ```

## Self-Review Checklist

- [ ] The plan covers Spine 4.3.23 project generation, export, and Unity import.
- [ ] The plan keeps the game rules independent of Spine.
- [ ] The plan includes a static Sprite fallback for missing or malformed Spine data.
- [ ] The plan covers all seven hero animations and all three requested screens.
- [ ] The plan tests grouped event behavior, especially Skill plus Damage deduplication.
- [ ] The plan does not require a manual `.spine` file to be fabricated without Spine Editor validation.
- [ ] No task depends on parsing localized text for battle results.
- [ ] No task instructs deletion or overwriting of unrelated user changes.
