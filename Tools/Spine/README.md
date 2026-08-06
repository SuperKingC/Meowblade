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
