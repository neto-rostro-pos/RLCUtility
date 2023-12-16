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
Imports System.Timers

Module modMainTimer
    Private p_oApp As New GRider("GRider")
    Private WithEvents m_oTimer As Timers.Timer = Nothing
    Private m_oWaitHandle_TimerHasCompleted As System.Threading.AutoResetEvent = Nothing

    Sub MainTimer()
        p_oApp = New GRider("RetMgtSys")

        If Not p_oApp.LoadEnv() Then
            MsgBox("Unable to load configuration file!")
            Exit Sub
        End If
        Call sendFile()
        'Call generatefile()

        'Try
        '    'Application Entry point ...

        '    'Create the global timer
        '    m_oTimer = New Timers.Timer
        '    With m_oTimer
        '        .AutoReset = True
        '        '.Interval = 30000 = 30 seconds
        '        .Interval = 30000

        '        .Start()
        '    End With
        '    'Create the WaitHandle
        '    m_oWaitHandle_TimerHasCompleted = New System.Threading.AutoResetEvent(False)

        '    'Wait for the timer to also indicate that it has finished before exiting
        '    m_oWaitHandle_TimerHasCompleted.WaitOne()
        'Catch ex As Exception
        '    'Error Handling here ...
        'End Try
    End Sub

    Private Sub m_oTimer_Elapsed(sender As Object, e As ElapsedEventArgs) Handles m_oTimer.Elapsed
        'Timer will fire here ...
        Try
            If 1 = 2 Then
                m_oWaitHandle_TimerHasCompleted.Set()
            End If
            Console.WriteLine(Now)
            Call sendFile()
        Catch ex As Exception
            'Error Handling ...
        End Try
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
        loRLC.createRLC("20220420", "20220420", "22010313392685364")
    End Sub
End Module