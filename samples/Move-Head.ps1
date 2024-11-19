[CmdletBinding(DefaultParameterSetName = 'Step')]
param(
    [Parameter(Mandatory, ParameterSetName = 'Step')]
    [Parameter(Mandatory, ParameterSetName = 'Absolute')]
    [ValidateSet('X', 'Y', 'Z')]
    [String] $Axe,

    [Parameter(ParameterSetName = 'Step')]
    [Single] $Step = 10,

    [Parameter(ParameterSetName = 'Absolute')]
    [Single] $Position = 10
)

if ($PSCmdlet.ParameterSetName -eq "Step") {
    $move = {
        Invoke-KlipperGCode -Code "G91" 
        Invoke-KlipperGcode -Code "G1 $Axe$Step F7800" 
        Invoke-KlipperGcode -Code "G90"
    }
}
else {
    $move = {
        Invoke-KlipperGCode -Code "G90"
        Invoke-KlipperGCode -Code "G1 $Axe$Position F7800"
    }
}
Invoke-Command -ScriptBlock $move | Out-Null
