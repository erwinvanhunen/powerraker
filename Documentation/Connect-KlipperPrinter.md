---
Module Name: PowerRaker
schema: 2.0.0
external help file: powerraker-help.xml
title: Connect-KlipperPrinter
---
  
# Connect-KlipperPrinter

## SYNOPSIS
Connects the current PowerShell session to a printer running Klipper with the Moonraker API installed

## SYNTAX

```powershell
Connect-KlipperPrinter [-Printer] <ListPipeBind> [-APIKey <String>] 
```

## DESCRIPTION
This cmdlet connects the current PowerShell session to a Klipper printer using the Moonraker API.

## EXAMPLES

### EXAMPLE 1
```powershell
Connect-KlipperPrinter http://myprinter
```

Sets up the environment use the other PowerRaker cmdlets with the specified printer.

## PARAMETERS

### -Printer
Url of printer

```yaml
Type: String
Parameter Sets: (All)
Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -APIKey
Optional API key to connect to the printer.

```yaml
Type: String
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```