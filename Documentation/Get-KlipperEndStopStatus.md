---
external help file: powerraker.dll-Help.xml
Module Name: powerraker
online version:
schema: 2.0.0
---

# Get-KlipperEndStopStatus

## SYNOPSIS
Retrieves the current endstop status.

## SYNTAX

```
Get-KlipperEndStopStatus [-Connection <PrinterContext>] [<CommonParameters>]
```

## DESCRIPTION
Retrieves the current endstop status, where the values can be "open" or "triggered".

## EXAMPLES

### Example 1
```
PS C:\> Get-KlipperEndStopStatus
```

{{ Add example description here }}

## PARAMETERS

### -Connection
Optional connection object to handle connections with multiple printers.

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
