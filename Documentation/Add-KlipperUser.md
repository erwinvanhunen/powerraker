---
external help file: powerraker.dll-Help.xml
Module Name: powerraker
online version:
schema: 2.0.0
---

# Add-KlipperUser

## SYNOPSIS
Adds a user to the printer configuration

## SYNTAX

```
Add-KlipperUser -Username <String> -Password <SecureString> [-Connection <PrinterContext>] [<CommonParameters>]
```

## DESCRIPTION
Adds a user to the printer configuration, allowing the user to login using the Moonraker API and subsequently use the commandlets.

## EXAMPLES

### Example 1
```
PS C:\> Add-KlipperUser -Username "TestUser1" -Password (Read-Host -AsSecureString -Prompt "Enter Password")
```

This will prompt you to enter a password. A new user, "TestUser1" will be added to the configuration and the password entered will be set for that user.

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

### -Password
The password for the user.

```yaml
Type: SecureString
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Username
The username for the user.

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
