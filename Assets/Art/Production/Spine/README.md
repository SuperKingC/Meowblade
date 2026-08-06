# Meowblade hero Spine projects

These editable projects were imported and exported with Spine 4.3.23
Professional:

- `cardboard_knight.spine`
- `fish_hunter.spine`
- `yarn_mage.spine`

Separate projects are used because the validated CLI path imports one skeleton
JSON source into one project. This avoids relying on a project merge operation
that was not part of the successful validation gate.

`Generated/` contains deterministic Spine 4.3 JSON sources and copies of the
manifest-declared shared `full_body` attachments. `Export/` contains the
validated JSON skeleton data, atlas files, and packed PNGs.

Regenerate and validate from the repository root:

```powershell
python Tools/Spine/generate_hero_skeleton.py `
  --output-dir Assets/Art/Production/Spine/Generated

$heroes = @('cardboard_knight', 'fish_hunter', 'yarn_mage')
foreach ($hero in $heroes) {
  & 'D:\Spine\Spine.com' `
    -i "Assets\Art\Production\Spine\Generated\$hero.json" `
    -o "Assets\Art\Production\Spine\$hero.spine" `
    -r $hero
}

powershell.exe -ExecutionPolicy Bypass `
  -File Tools/Spine/export_heroes.ps1
```

The expected CLI info contract for every hero is Spine version 4.3.23, eight
named bones, nine named slots, and seven animations:
`idle`, `move`, `attack`, `skill`, `hit`, `retreat`, and `victory`.
