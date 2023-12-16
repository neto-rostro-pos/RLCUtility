'€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€
' Guanzon Software Engineering Group
' Guanzon Group of Companies
' Perez Blvd., Dagupan City
'
'    RLC Utility
'
' Copyright 2021 and Beyond
' All Rights Reserved
' ºººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººº
' €  All  rights reserved. No part of this  software  €€  This Software is Owned by        €
' €  may be reproduced or transmitted in any form or  €€                                   €
' €  by   any   means,  electronic   or  mechanical,  €€    GUANZON MERCHANDISING CORP.    €
' €  including recording, or by information  storage  €€     Guanzon Bldg. Perez Blvd.     €
' €  and  retrieval  systems, without  prior written  €€           Dagupan City            €
' €  from the author.                                 €€  Tel No. 522-1085 ; 522-9275      €
' ºººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººººº
'
' ==========================================================================================
'  Jheff [ 10/21/2021 11:53 am ]
'       start creasting this object
'€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€€

Option Explicit On
Imports ggcAppDriver
Imports ggcReceipt

Module modMain
    Private p_oApp As New GRider("GRider")

    Sub Main()
        p_oApp = New GRider("RetMgtSys")

        If Not p_oApp.LoadEnv() Then
            MsgBox("Unable to load configuration file!")
            Exit Sub
        End If

        Call sendFile()
        'Call generatefile()
    End Sub

    Private Sub sendFile()
        Dim loRLC As PRN_RLC_Reading

        loRLC = New PRN_RLC_Reading(p_oApp)
        If Not loRLC.IsConnectionAvailable Then Exit Sub

        loRLC.uploadSFTPUnsent(Environment.GetEnvironmentVariable("RLC-XPATH"))
    End Sub

    Private Sub generatefile()
        Dim loRLC As PRN_RLC_Reading

        loRLC = New PRN_RLC_Reading(p_oApp)
        loRLC.createRLC("20220424", "20220424", "22010313392685364")
    End Sub
End Module