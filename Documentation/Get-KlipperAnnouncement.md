---
external help file: powerraker.dll-Help.xml
Module Name: powerraker
online version:
schema: 2.0.0
---

# Get-KlipperAnnouncement

## SYNOPSIS
Retrieves a list of current announcements

## SYNTAX

```
Get-KlipperAnnouncement [-IncludeDismissed] [-Connection <PrinterContext>] [<CommonParameters>]
```

## DESCRIPTION
Retrieves a list of current announcements.

## EXAMPLES

### Example 1
```
PS C:\> Get-KlipperAnnouncement -IncludedDismissed
```

Retrieves a list of current announcements, including the already dismissed announcements.

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

### -IncludeDismissed
Specify to include already dismissed announcements.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
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
