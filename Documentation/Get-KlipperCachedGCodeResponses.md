---
external help file: powerraker.dll-Help.xml
Module Name: powerraker
online version:
schema: 2.0.0
---

# Get-KlipperCachedGCodeResponses

## SYNOPSIS
Retrieves the cached GCode responses

## SYNTAX

```
Get-KlipperCachedGCodeResponses [-Connection <PrinterContext>] [-Count <Int32>] [<CommonParameters>]
```

## DESCRIPTION
This cmdlet returns the cached GCode responses.
Default count is 100.

## EXAMPLES

### EXAMPLE 1
```
Get-KlipperCachedGCodeResponses
```

Returns the last 100 cached GCode responses.

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

### -Count
Number of responses to return

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: 100
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS
