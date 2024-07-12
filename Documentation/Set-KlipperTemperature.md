---
external help file: powerraker.dll-Help.xml
Module Name: powerraker
online version:
schema: 2.0.0
---

# Set-KlipperTemperature

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### Heaters
```
Set-KlipperTemperature -TargetTemperature <Double> [-Connection <PrinterContext>] [-Heater <String>]
 [<CommonParameters>]
```

### Fans
```
Set-KlipperTemperature -TargetTemperature <Double> [-Connection <PrinterContext>] [-Fan <String>]
 [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```
PS C:\> {{ Add example code here }}
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

### -Fan
{{ Fill Fan Description }}

```yaml
Type: String
Parameter Sets: Fans
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Heater
{{ Fill Heater Description }}

```yaml
Type: String
Parameter Sets: Heaters
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetTemperature
{{ Fill TargetTemperature Description }}

```yaml
Type: Double
Parameter Sets: (All)
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

### None
## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS