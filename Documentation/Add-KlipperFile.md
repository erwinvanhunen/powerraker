---
external help file: powerraker.dll-Help.xml
Module Name: powerraker
online version:
schema: 2.0.0
---

# Add-KlipperFile

## SYNOPSIS
Upload a file to the printer

## SYNTAX

```
Add-KlipperFile -Filename <String> [-Connection <PrinterContext>] [<CommonParameters>]
```

## DESCRIPTION
Uploads a file, like a gcode file, to the printer.

## EXAMPLES

### Example 1
```
PS C:\> Add-KlipperFile -Filename ./myfile.gcode
```

Uploads the file called myfile.gcode to the printer.

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

### -Filename
{{ Fill Filename Description }}

```yaml
Type: String
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