---
external help file: powerraker.dll-Help.xml
Module Name: powerraker
online version:
schema: 2.0.0
---

# Request-KlipperHostReboot

## SYNOPSIS
Reboots the host machine.

## SYNTAX

```
Request-KlipperHostReboot [-Force] [-Connection <PrinterContext>] [<CommonParameters>]
```

## DESCRIPTION
Reboots the host machine.

## EXAMPLES

### Example 1
```powershell
PS> Request-KlipperHostReboot
```

Reboots the current host machine.

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
