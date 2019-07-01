Imports System.Data.SqlClient
Imports System.IO

Public Class frmOption
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnFrontOffice.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Top 1 OpenID,TillDetails FROM POS_OpeningCash,Registration where POS_OpeningCash.UserID=Registration.UserID and Registration.UserID=@d1 and TillDetails=@d2 and Closed=0 order by OpenID desc"
            cmd.Parameters.AddWithValue("@d1", lblUser.Text)
            cmd.Parameters.AddWithValue("@d2", System.Net.Dns.GetHostName)
            Dim rdr1 As SqlDataReader = cmd.ExecuteReader()
            If rdr1.Read() Then
                Me.Hide()
                Dim st As String = "Successfully logged in"
                LogFunc(lblUser.Text, st)
                frmPOS.Reset()
                frmPOS.txtUID.Text = lblUser.Text
                frmPOS.txtTillCode.Text = rdr1.GetValue(1).ToString()
                frmPOS.txtOpenID.Text = rdr1.GetValue(0)
                frmPOS.Show()
            Else
                Me.Hide()
                frmPOSOpening.Show()
                frmPOSOpening.txtUserID.Text = lblUser.Text
                frmPOSOpening.txtOpeningAmount.Focus()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBackOffice_Click(sender As System.Object, e As System.EventArgs) Handles btnBackOffice.Click
        frmBackOffice.lblUser.Text = lblUser.Text
        Me.Hide()
        frmBackOffice.Show()
    End Sub
    Private Function HandleTrialRegistry() As Boolean
        Dim firstRunDate As Date
        Dim st As Date = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\IntelliSalesPOS", "Set", Nothing)
        firstRunDate = st
        If firstRunDate = Nothing Then
            firstRunDate = System.DateTime.Today.Date
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\IntelliSalesPOS", "Set", firstRunDate)
        ElseIf (Now - firstRunDate).Days > 15 Then
            Return False
        End If
        Return True
    End Function

    'Private Function HandleRenewalRegistry() As Boolean
    '    Dim firstRunDate As Date
    '    Dim st As Date = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\IntelliSalesPOSX", "Set", Nothing)
    '    firstRunDate = st
    '    If firstRunDate = Nothing Then
    '        firstRunDate = System.DateTime.Today.Date
    '        My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\IntelliSalesPOSX", "Set", firstRunDate)
    '    ElseIf (365 - (Now - firstRunDate).Days) <= 5 And (365 - (Now - firstRunDate).Days) >= 0 Then
    '        MessageBox.Show((365 - (Now - firstRunDate).Days) & " " & "days left", "Software Renewal", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    ElseIf (Now - firstRunDate).Days > 15 Then
    '        Return False
    '    End If
    '    Return True
    'End Function
    Private Sub frmOption_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BackColor = Color.Coral
        TransparencyKey = BackColor
        Dim filepath As String = Application.StartupPath & "\LC.txt"
        If Not System.IO.File.Exists(filepath) Then
            'System.IO.File.Create(filepath).Dispose()
            Using sw As StreamWriter = New StreamWriter(Application.StartupPath & "\LC.txt")
                sw.WriteLine(0)
            End Using
        End If
        If ReadLC() = 0.ToString() Then
            Dim result1 As Boolean = HandleTrialRegistry()
            If result1 = False Then 'something went wrong
                frmActivation.ShowDialog()
            End If
        Else
            Try
                Dim i As System.Management.ManagementObject
                Dim searchInfo_Processor As New System.Management.ManagementObjectSearcher("Select * from Win32_Processor")
                For Each i In searchInfo_Processor.Get()
                    txtHardwareID.Text = i("ProcessorID").ToString
                Next
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select RTRIM(ActivationID) from Activation where HardwareID=@d1"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", Encrypt(txtHardwareID.Text.Trim))
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    If ReadLC() <> rdr.GetValue(0) Then
                        frmActivation.ShowDialog()
                    End If
                End If
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
                End
            End Try
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub
End Class