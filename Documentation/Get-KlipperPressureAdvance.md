---
external help file: powerraker.dll-Help.xml
Module Name: powerraker
online version:
schema: 2.0.0
---

# Get-KlipperPressureAdvance

## SYNOPSIS
Returns the pressure advance and smooth time values.

## SYNTAX

```
Get-KlipperPressureAdvance [-Connection <PrinterContext>] [<CommonParameters>]
```

## DESCRIPTION
Returns the pressure advance and smooth time values.

## EXAMPLES

### Example 1
```powershell
PS> Get-KlipperPressureAdvance
```

Returns the current pressure advance and smooth time values set. 

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
