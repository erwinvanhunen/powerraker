---
external help file: powerraker.dll-Help.xml
Module Name: powerraker
online version:
schema: 2.0.0
---

# Disconnect-KlipperPrinter

## SYNOPSIS
Disconnects the current session from the printer.

## SYNTAX

```
Disconnect-KlipperPrinter [-Connection <PrinterContext>] [<CommonParameters>]
```

## DESCRIPTION
Disconnects the current session from the printer and subsequent cmdlet calls to your printer will fail.
If the connection was made with a username and password, you will have to connect again.

## EXAMPLES

### Example 1
```
PS C:\> Disconnect-KlipperPrinter
```

Disconnects the current session

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
