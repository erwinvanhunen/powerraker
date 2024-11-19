---
external help file: powerraker.dll-Help.xml
Module Name: powerraker
online version:
schema: 2.0.0
---

# Get-KlipperConnection

## SYNOPSIS
Returns the current connection as an object. Notice that this is only needed if you want to use multiple connections to different printers in a single script.

## SYNTAX

```
Get-KlipperConnection [-Connection <PrinterContext>] [<CommonParameters>]
```

## DESCRIPTION
Returns the current connection as an object. This allows you use to use the connection with multiple printers. See examples for usage. Also see the help for Connect-KlipperPrinter as that cmdlet can return the connection at connection time.

## EXAMPLES

### Example 1
```powershell
PS C:\> Connect-KlipperPrinter -Url http://printer1
PS C:\> $connection1 = Get-KlipperConnection
PS C:\> Connect-KlipperPrinter -Url http://printer2
PS C:\> $connection2 = Get-KlipperConnection
PS C:\> Get-KlipperJob -Connection $connection1
PS C:\> Get-KlipperJob -Connection $connection2
```

This example connects to two printers and retrieves the current jobs of those printers.

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## PARAMETERS

### -Connection
{{ Fill Connection Description }}

```yaml
Type: PrinterContext
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS
