﻿Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Public Class frmActivation

    Private Sub frmActivation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim i As System.Management.ManagementObject
            Dim searchInfo_Processor As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
            For Each i In searchInfo_Processor.Get()
                txtHardwareID.Text = i("ProcessorID").ToString
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
            End
        End Try
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If txtActivationID.Text = "" Then
                MessageBox.Show("Please enter activation id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtActivationID.Focus()
                Exit Sub
            End If
            Dim st As String = (txtHardwareID.Text)
            TextBox1.Text = Encryption.MakePassword(st, 653)
            If txtActivationID.Text = TextBox1.Text Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb1 As String = "insert into Activation(HardwareID,ActivationID) VALUES (@d1,@d3)"
                cmd = New SqlCommand(cb1)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", Encrypt(txtHardwareID.Text.Trim))
                cmd.Parameters.AddWithValue("@d3", Encrypt(txtActivationID.Text.Trim()))
                cmd.ExecuteReader()
                con.Close()
                System.IO.File.WriteAllText(Application.StartupPath & "\LC.txt", "")
                Using sw As StreamWriter = New StreamWriter(Application.StartupPath & "\LC.txt")
                    sw.WriteLine(Encrypt(txtActivationID.Text.Trim()))
                    sw.Close()
                End Using
                MessageBox.Show("Successfully activated", "Software", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()
            Else
                MessageBox.Show("Invalid activation id...Please contact software provider for buying full licence" & vbCrLf & "Contact us at :" & vbCrLf & "Intellitech Technologies Ltd." & vbCrLf & "Email- Info@intellitech.ng", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        End
    End Sub
End Class
