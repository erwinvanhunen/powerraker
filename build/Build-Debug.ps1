Write-Host "Building PowerRaker"

$buildCmd = "dotnet build `"$PSScriptRoot/../src/powerraker.csproj`"" + "--nologo --configuration Debug"
Invoke-Expression $buildCmd

$destinationFolder = "$HOME/.local/share/powershell/Modules/PowerRaker"

if (Test-Path $destinationFolder) {
    Remove-Item $destinationFolder\* -Recurse -Force -ErrorAction SilentlyContinue
}

Write-Host "Creating target folder: $destinationFolder" -ForegroundColor Yellow

New-Item -Path $destinationFolder -ItemType Directory -Force | Out-Null

Write-Host "Copying files to $destinationFolder" -ForegroundColor Yellow

Get-ChildItem -Path "$PSScriptRoot/../src/bin/Debug/net8.0" | Where-Object { $_.Extension -in ".dll", ".pdb" } | Foreach-Object { Copy-Item -LiteralPath $_.FullName -Destination $destinationFolder }

Copy-Item -LiteralPath "$PSScriptRoot/../Resources/PowerRaker.Format.ps1xml" -Destination $destinationFolder 

$scriptBlock = {
   
   $destinationFolder = "~/.local/share/powershell/Modules/PowerRaker"
   
    Write-Host "Importing assembly" -ForegroundColor Yellow
    Import-Module -Name "$destinationFolder/powerraker.dll" -DisableNameChecking
    $cmdlets = get-command -Module powerraker | ForEach-Object { "`"$_`"" }
    $cmdlets -Join ","

	Write-Host "Updating documentation folder" -ForegroundColor Yellow
	Import-module -Name platyPS
	Update-MarkdownHelpModule -Path "$input/../documentation"
}
$cmdletsString = Start-Job -ScriptBlock $scriptBlock -InputObject $PSScriptRoot | Receive-Job -Wait

$manifest = "@{
	NestedModules =  'powerraker.dll'
	ModuleVersion = '0.0.1'
	Description = 'Moonraker PowerShell Cmdlets'
	GUID = '7727435a-7d02-4ef0-ae37-3f69a7de9a2d'
	Author = 'Erwin van Hunen'
	CompanyName = ''
	CompatiblePSEditions = @('Core')
	ProcessorArchitecture = 'None'
	FunctionsToExport = '*'  
	CmdletsToExport = @($cmdletsString)
	VariablesToExport = '*'
	AliasesToExport = '*'
	FormatsToProcess = 'PowerRaker.Format.ps1xml' 
	PrivateData = @{
		PSData = @{
			Prerelease = 'debug'
			ProjectUri = 'https://aka.ms/sppnp'
			IconUri = 'https://raw.githubusercontent.com/pnp/media/40e7cd8952a9347ea44e5572bb0e49622a102a12/parker/ms/300w/parker-ms-300.png'
		}
	}
}"

$manifest | Out-File "$destinationFolder/powerraker.psd1"

Write-Host "Generating help file" -ForegroundColor Yellow

New-ExternalHelp -Path "$PSScriptRoot/../documentation" -OutputPath $destinationFolder