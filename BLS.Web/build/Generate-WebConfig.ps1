param(
  [Parameter(Mandatory=$true)][string]$TemplatePath,
  [Parameter(Mandatory=$true)][string]$OutputPath,

  # Opcional: puedes pasarlos por parámetro o por variables de entorno
  [string]$CONNECTIONSTRING,
  [string]$SMTPHOST,
  [string]$SMTPPORT,
  [string]$SMTPUSER,
  [string]$FROMEMAIL,
  [string]$SMTPPASS,
  [string]$SMTPENABLESSL,
  [string]$FROMNAME
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

function Get-Value([string]$paramValue, [string]$envName, [string]$friendlyName) {
    if ($paramValue -and $paramValue.Trim().Length -gt 0) { return $paramValue }
    $envValue = [Environment]::GetEnvironmentVariable($envName)
    if ($envValue -and $envValue.Trim().Length -gt 0) { return $envValue }
    throw "Falta valor para '$friendlyName'. Proporciónalo como parámetro (-$envName) o variable de entorno '$envName'."
}

# 1) Validaciones
if (-not (Test-Path -LiteralPath $TemplatePath)) {
    throw "No existe el template: $TemplatePath"
}

$template = Get-Content -LiteralPath $TemplatePath -Raw

# 2) Cargar valores (param -> env)
$valConn   = Get-Value $CONNECTIONSTRING "CONNECTIONSTRING" "CONNECTIONSTRING"
$valHost   = Get-Value $SMTPHOST         "SMTPHOST"         "SMTPHOST"
$valPort   = Get-Value $SMTPPORT         "SMTPPORT"         "SMTPPORT"
$valUser   = Get-Value $SMTPUSER         "SMTPUSER"         "SMTPUSER"
$valFromE  = Get-Value $FROMEMAIL        "FROMEMAIL"        "FROMEMAIL"
$valPass   = Get-Value $SMTPPASS         "SMTPPASS"         "SMTPPASS"
$valSsl    = Get-Value $SMTPENABLESSL    "SMTPENABLESSL"    "SMTPENABLESSL"
$valFromN  = Get-Value $FROMNAME         "FROMNAME"         "FROMNAME"

# 3) Normaliza SSL a true/false (por si viene 1/0, yes/no, etc.)
switch ($valSsl.Trim().ToLowerInvariant()) {
    "1" { $valSsl = "true" }
    "0" { $valSsl = "false" }
    "yes" { $valSsl = "true" }
    "no"  { $valSsl = "false" }
    "true" { $valSsl = "true" }
    "false" { $valSsl = "false" }
    default { throw "SMTPENABLESSL inválido: '$valSsl'. Usa true/false (o 1/0)." }
}

# 4) Reemplazo de placeholders
$replacements = @{
    "SECRET_CONNECTIONSTRING" = $valConn
    "SECRET_SMTPHOST"         = $valHost
    "SECRET_SMTPPORT"         = $valPort
    "SECRET_SMTPUSER"         = $valUser
    "SECRET_FROMEMAIL"        = $valFromE
    "SECRET_SMTPPASS"         = $valPass
    "SECRET_SMTPENABLESSL"    = $valSsl
    "SECRET_FROMNAME"         = $valFromN
}

foreach ($k in $replacements.Keys) {
    if ($template -notmatch [Regex]::Escape($k)) {
        Write-Warning "No encontré el placeholder '$k' en el template. (Ojo si el texto no coincide exactamente.)"
    }
    $template = $template.Replace($k, $replacements[$k])
}

# 5) Seguridad mínima: evita loggear secretos
# (solo mostramos que se generó)
$outDir = Split-Path -Parent $OutputPath
if ($outDir -and -not (Test-Path -LiteralPath $outDir)) {
    New-Item -ItemType Directory -Path $outDir | Out-Null
}

Set-Content -LiteralPath $OutputPath -Value $template -Encoding UTF8
Write-Host "OK: web.config generado -> $OutputPath"
