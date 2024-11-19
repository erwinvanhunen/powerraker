---
external help file: powerraker.dll-Help.xml
Module Name: powerraker
online version:
schema: 2.0.0
---

# Get-KlipperDatabaseItem

## SYNOPSIS
Retrieves an item from a specified namespace. 

## SYNTAX

```
Get-KlipperDatabaseItem -Namespace <String> [-Key <String>] [-Connection <PrinterContext>] [<CommonParameters>]
```

## DESCRIPTION
Retrieves an item from a specified namespace. The key parameter may be omitted, in which case an object representing the entire namespace will be returned in the value field. If the key is provided and does not exist in the database an error will be returned.

## EXAMPLES

### Example 1
```
PS C:\> $i = Get-KlipperDatabaseItem -Namespace "webcams"
PS C:> $i.Value.'27da54de-102d-4d3a-ad5b-0adce9034762'.name
```

Returns the name of the first webcam. Notice that ID will be different on your environment.

### Example 2
```
PS C:\> $i = Get-KlipperDatabaseItem -Namespace "webcams" -Key '27da54de-102d-4d3a-ad5b-0adce9034762'
PS C:> $i.Value.name
```

Returns the name of the first webcam. Notice that ID will be different on your environment.

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

### -Key
The key to retrieve from the namepace

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Namespace
{{ Fill Namespace Description }}

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
