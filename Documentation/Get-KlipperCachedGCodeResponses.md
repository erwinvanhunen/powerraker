---
Module Name: PowerRaker
schema: 2.0.0
external help file: powerraker-help.xml
title: Get-KlipperCachedGCodeResponses
---
  
# Get-KlipperCachedGCodeResponses

## SYNOPSIS
Retrieves the cached GCode responses

## SYNTAX

```powershell
Get-KlipperCachedGCodeReponses [-Count <Integer>] 
```

## DESCRIPTION
This cmdlet returns the cached GCode responses. Default count is 100.

## EXAMPLES

### EXAMPLE 1
```powershell
Get-KlipperCachedGCodeResponses
```

Returns the last 100 cached GCode responses.

## PARAMETERS

### -Count
Number of responses to return

```yaml
Type: Integer
Parameter Sets: (All)
Required: True
Position: Named
Default value: 100
Accept pipeline input: False
Accept wildcard characters: False
```