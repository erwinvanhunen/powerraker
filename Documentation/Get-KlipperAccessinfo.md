---
external help file: powerraker.dll-Help.xml
Module Name: powerraker
online version:
schema: 2.0.0
---

# Get-KlipperAccessinfo

## SYNOPSIS
Retrieves information about the authorization endpoints.

## SYNTAX

```
Get-KlipperAccessinfo [-Connection <PrinterContext>] [<CommonParameters>]
```

## DESCRIPTION
Returns information about authorization endpoints, such as default_source and available_sources.

## EXAMPLES

### Example 1
```
PS C:\> Get-KlipperAccessInfo
```

Returns information about authorization endpoints, such as default_source and available_sources.

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
