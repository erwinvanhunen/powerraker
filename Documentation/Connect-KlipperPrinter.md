---
external help file: powerraker.dll-Help.xml
Module Name: powerraker
online version:
schema: 2.0.0
---

# Connect-KlipperPrinter

## SYNOPSIS
Connects the current PowerShell session to a printer running Klipper with the Moonraker API installed

## SYNTAX

### APIKey
```
Connect-KlipperPrinter [-Printer] <String> [-APIKey <String>] [-ReturnConnection] [<CommonParameters>]
```

### User
```
Connect-KlipperPrinter [-Printer] <String> -Username <String> -Password <SecureString> [-Source <String>]
 [-ReturnConnection] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet connects the current PowerShell session to a Klipper printer using the Moonraker API.

## EXAMPLES

### EXAMPLE 1
```
Connect-KlipperPrinter http://myprinter
Get-KlipperCurrentJob
```

Sets up the environment use the other PowerRaker cmdlets with the specified printer and returns the current ongoing job on the printer.

### EXAMPLE 2
```
Connect-KlipperPrinter http://myprinter -User myuser1
```

Sets up the environment use the other PowerRaker cmdlets with the specified printer.

### EXAMPLE 3
```
$conn1 = Connect-KlipperPrinter -Printer http://myprinter -ReturnConnection
$conn1 = Connect-KlipperPrinter -Printer http://myotherprinter -ReturnConnection
Get-KlipperCurrentJob -Connection $conn1
Get-KlipperCurrentJob -Connection $conn2
```

Sets up the environment to use the other Klipper cmdlets with the specified printer and returns ongoing jobs on both printers.

## PARAMETERS

### -APIKey
Optional API key to connect to the printer.

```yaml
Type: String
Parameter Sets: APIKey
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Password
The user password as a secure string.
When omitted you will be asked to enter it.

```yaml
Type: SecureString
Parameter Sets: User
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Printer
Url of printer

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReturnConnection
Returns the current connection as an object.
You can use this object to separate connections to multiple printers and use them with the -Connection parameter on each cmdlet.
See example 3.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Source
The source to use for authentication.
Defaults to 'moonraker'.

```yaml
Type: String
Parameter Sets: User
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Username
The username of the user to authenticate.

```yaml
Type: String
Parameter Sets: User
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
