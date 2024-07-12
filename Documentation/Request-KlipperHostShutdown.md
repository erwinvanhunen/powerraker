---
external help file: powerraker.dll-Help.xml
Module Name: powerraker
online version:
schema: 2.0.0
---

# Request-KlipperHostShutdown

## SYNOPSIS
Shuts down the current host.

## SYNTAX

```
Request-KlipperHostShutdown [-Force] [-Connection <PrinterContext>] [<CommonParameters>]
```

## DESCRIPTION
Shuts down the current host.

## EXAMPLES

### Example 1
```powershell
Request-KlipperHostShutdown
```

After confirmation the host will be requested to shut down.

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

### -Force
If specified no confirmation will be asked.

```yaml
Type: SwitchParameter
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
