# Spine-ready hero art

Generate the first-pass hero layers from the approved lineup source:

```powershell
python Tools/Art/process_concept_assets.py --spine-ready
```

The command reads `Assets/Art/art_master_heroes_lineup_v01.png` and writes only
`Assets/Art/Production/SpineReady/`. It does not regenerate existing runtime
art.

Each hero currently has one transparent `full_body.png`. The manifest exposes
stable entries for `body`, `head`, `arm_front`, `arm_back`, `weapon`,
`equipment_front`, `equipment_back`, `tail`, and `effect_anchor`. Because the
approved concept does not contain hidden or separately painted anatomy, these
entries intentionally reference the same full-body image and use
`"shared": true`. Replace an entry only when approved separated artwork exists;
do not invent covered anatomy.

`hero_layer_manifest.json` records the source crop, output dimensions, alpha
bounding box, stable layer names, and relative asset paths. Outputs are RGBA,
have non-empty alpha, and are limited to 2048 x 2048. Fish hunter generation
also rejects an extracted alpha width below 55% of the output crop width to
catch accidental inclusion of neighboring lineup art.

## Task 3: Spine 4.3 hero projects and exports

Task 3 uses one Spine project per hero:

- `Assets/Art/Production/Spine/cardboard_knight.spine`
- `Assets/Art/Production/Spine/fish_hunter.spine`
- `Assets/Art/Production/Spine/yarn_mage.spine`

Separate projects are intentional. Spine CLI imports one skeleton JSON source at
a time, and keeping the already validated one-source/one-project format avoids
an unsafe merge step. All three sources share the same bones, slots, attachment
names, effect points, and seven animation names.

Generate the deterministic Spine 4.3 JSON sources and shared `full_body` image
copies:

```powershell
python Tools/Spine/generate_hero_skeleton.py `
  --output-dir Assets/Art/Production/Spine/Generated
```

Import each source with Spine 4.3.23 Professional:

```powershell
$heroes = @('cardboard_knight', 'fish_hunter', 'yarn_mage')
foreach ($hero in $heroes) {
  & 'D:\Spine\Spine.com' `
    -i "Assets\Art\Production\Spine\Generated\$hero.json" `
    -o "Assets\Art\Production\Spine\$hero.spine" `
    -r $hero
}
```

Export and validate all projects:

```powershell
powershell.exe -ExecutionPolicy Bypass `
  -File Tools/Spine/export_heroes.ps1
```

The wrapper asserts that `D:\Spine\Spine.com --version` contains
`Spine 4.3.23 Professional`, runs CLI info for each project, exports
`json+pack`, and checks every hero has a non-empty `.json`, `.atlas`, and `.png`
plus exactly these animations:

```text
idle, move, attack, skill, hit, retreat, victory
```

Validated CLI output on August 6, 2026:

```text
Project import: cardboard_knight.json into cardboard_knight
Complete.
Project import: fish_hunter.json into fish_hunter
Complete.
Project import: yarn_mage.json into yarn_mage
Complete.

Spine version: 4.3.23
Bones (8): root, body, head, arm_back, arm_front, weapon, tail, effects
Slots (9): equipment_back, tail, body, arm_back, arm_front, head, weapon, equipment_front, effects
Animations (7): attack, hit, idle, move, retreat, skill, victory

JSON export: <hero>
Pack: <hero> (attachments)
Complete.
```
