[CmdletBinding()]
param()

$ErrorActionPreference = 'Stop'

$SpineCli = 'D:\Spine\Spine.com'
$ExpectedVersion = 'Spine 4.3.23 Professional'
$RepositoryRoot = (Resolve-Path (Join-Path $PSScriptRoot '..\..')).Path
$ProjectDirectory = Join-Path $RepositoryRoot 'Assets\Art\Production\Spine'
$ExportDirectory = Join-Path $ProjectDirectory 'Export'
$Heroes = @('cardboard_knight', 'fish_hunter', 'yarn_mage')
$Animations = @('idle', 'move', 'attack', 'skill', 'hit', 'retreat', 'victory')

if (-not (Test-Path -LiteralPath $SpineCli -PathType Leaf)) {
    throw "Spine CLI not found: $SpineCli"
}

$VersionOutput = (& $SpineCli --version 2>&1 | Out-String)
if ($LASTEXITCODE -ne 0) {
    throw "Spine version check failed with exit code $LASTEXITCODE.`n$VersionOutput"
}
if ($VersionOutput -notmatch [regex]::Escape($ExpectedVersion)) {
    throw "Expected '$ExpectedVersion' but received:`n$VersionOutput"
}
Write-Output "VERSION OK: $ExpectedVersion"

New-Item -ItemType Directory -Force -Path $ExportDirectory | Out-Null

foreach ($Hero in $Heroes) {
    $ProjectPath = Join-Path $ProjectDirectory "$Hero.spine"
    if (-not (Test-Path -LiteralPath $ProjectPath -PathType Leaf)) {
        throw "Missing Spine project: $ProjectPath"
    }

    Write-Output "INFO $Hero"
    & $SpineCli -i $ProjectPath
    if ($LASTEXITCODE -ne 0) {
        throw "Spine info failed for $Hero with exit code $LASTEXITCODE"
    }

    Write-Output "EXPORT $Hero"
    & $SpineCli -i $ProjectPath -o $ExportDirectory -e json+pack
    if ($LASTEXITCODE -ne 0) {
        throw "Spine export failed for $Hero with exit code $LASTEXITCODE"
    }

    $JsonPath = Join-Path $ExportDirectory "$Hero.json"
    $AtlasPath = Join-Path $ExportDirectory "$Hero.atlas"
    $PngPath = Join-Path $ExportDirectory "$Hero.png"
    foreach ($RequiredPath in @($JsonPath, $AtlasPath, $PngPath)) {
        if (-not (Test-Path -LiteralPath $RequiredPath -PathType Leaf)) {
            throw "Missing export for ${Hero}: $RequiredPath"
        }
        if ((Get-Item -LiteralPath $RequiredPath).Length -le 0) {
            throw "Empty export for ${Hero}: $RequiredPath"
        }
    }

    $Skeleton = Get-Content -LiteralPath $JsonPath -Raw | ConvertFrom-Json
    $ActualAnimations = @($Skeleton.animations.PSObject.Properties.Name)
    foreach ($Animation in $Animations) {
        if ($Animation -notin $ActualAnimations) {
            throw "$Hero export is missing animation '$Animation'"
        }
    }
    if (@($ActualAnimations | Where-Object { $_ -notin $Animations }).Count -ne 0) {
        throw "$Hero export contains unexpected animations: $($ActualAnimations -join ', ')"
    }

    Write-Output "VALIDATED ${Hero}: json, atlas, png, animations=$($Animations -join ',')"
}

Write-Output "ALL HERO EXPORTS VALIDATED: $ExportDirectory"
