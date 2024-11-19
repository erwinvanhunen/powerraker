---
external help file: powerraker.dll-Help.xml
Module Name: powerraker
online version:
schema: 2.0.0
---

# Get-KlipperDatabaseInfo

## SYNOPSIS
Lists all namespaces with read and/or write access. Also lists database backup files.

## SYNTAX

```
Get-KlipperDatabaseInfo [-Connection <PrinterContext>] [<CommonParameters>]
```

## DESCRIPTION
Lists all namespaces with read and/or write access. Also lists database backup files.

## EXAMPLES

### Example 1
```
PS C:\> Get-KlipperDatabaseInfo
```

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
