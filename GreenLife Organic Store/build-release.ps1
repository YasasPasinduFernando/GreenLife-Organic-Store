# GreenLife Organic Store - Release Build Script
# Creates a self-contained Windows executable that works without .NET 8 installation

Write-Host "========================================" -ForegroundColor Green
Write-Host "GreenLife Organic Store - Release Build" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Green
Write-Host ""

# Get the project directory
$projectDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$projectFile = Join-Path $projectDir "GreenLife Organic Store.csproj"
$outputDir = Join-Path $projectDir "bin\Release\win-x64\publish"

Write-Host "[1/4] Cleaning previous builds..." -ForegroundColor Cyan
Remove-Item -Path (Join-Path $projectDir "bin\Release") -Recurse -Force -ErrorAction SilentlyContinue
Write-Host "      ? Cleaned" -ForegroundColor Green

Write-Host ""
Write-Host "[2/4] Restoring NuGet packages..." -ForegroundColor Cyan
dotnet restore "$projectFile"
if ($LASTEXITCODE -ne 0) {
    Write-Host "      ? Restore failed!" -ForegroundColor Red
    exit 1
}
Write-Host "      ? Restored" -ForegroundColor Green

Write-Host ""
Write-Host "[3/4] Publishing self-contained release build..." -ForegroundColor Cyan
Write-Host "      Configuration: Release" -ForegroundColor White
Write-Host "      Runtime: Windows x64 (win-x64)" -ForegroundColor White
Write-Host "      Self-contained: Yes (includes .NET 8 runtime)" -ForegroundColor White
Write-Host ""

dotnet publish "$projectFile" `
    -c Release `
    -r win-x64 `
    --self-contained `
    --no-restore `
    /p:PublishSingleFile=true `
    /p:SelfContained=true

if ($LASTEXITCODE -ne 0) {
    Write-Host "      ? Publish failed!" -ForegroundColor Red
    exit 1
}
Write-Host "      ? Published" -ForegroundColor Green

Write-Host ""
Write-Host "[4/4] Build artifacts..." -ForegroundColor Cyan
$publishSize = (Get-ChildItem -Path $outputDir -Recurse | Measure-Object -Property Length -Sum).Sum
$publishSizeMB = [math]::Round($publishSize / 1MB, 2)
Write-Host "      Output: $outputDir" -ForegroundColor White
Write-Host "      Size: $publishSizeMB MB" -ForegroundColor White
Write-Host "      ? Complete" -ForegroundColor Green

Write-Host ""
Write-Host "========================================" -ForegroundColor Green
Write-Host "BUILD SUCCESSFUL!" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Green
Write-Host ""
Write-Host "?? Distribution Package Ready!" -ForegroundColor Yellow
Write-Host ""
Write-Host "Location: $outputDir" -ForegroundColor Cyan
Write-Host ""
Write-Host "To share with others:" -ForegroundColor Yellow
Write-Host "  1. Zip the entire 'publish' folder" -ForegroundColor White
Write-Host "  2. Send to any Windows computer" -ForegroundColor White
Write-Host "  3. Extract and run: GreenLife Organic Store.exe" -ForegroundColor White
Write-Host ""
Write-Host "Requirements:" -ForegroundColor Yellow
Write-Host "  - Windows 7 SP1 or later" -ForegroundColor White
Write-Host "  - .NET 8 runtime is INCLUDED (self-contained)" -ForegroundColor White
Write-Host "  - No installation needed!" -ForegroundColor White
Write-Host ""
