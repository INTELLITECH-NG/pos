Imports System.Data.SqlClient
Imports System.IO.Ports

Public Class frmPOSClosing

    Private Sub btnChange_Click(sender As System.Object, e As System.EventArgs) Handles btnChange.Click
        Try
            If Len(Trim(txtClosingAmount.Text)) = 0 Then
                MessageBox.Show("Please enter closing amount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtClosingAmount.Focus()
                Exit Sub
            End If
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into POS_ClosingCash(ClosingID, OpenID,ClosingDate,ClosingBalance) Values (@d1,@d2,@d3,@d4)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtCloseID.Text))
            cmd.Parameters.AddWithValue("@d2", Val(txtOpenID.Text))
            cmd.Parameters.AddWithValue("@d3", dtpCloseDate.Value)
            cmd.Parameters.AddWithValue("@d4", Val(txtClosingAmount.Text))
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "Update POS_OpeningCash set Closed=1 where OpenID=" & Val(txtOpenID.Text) & ""
            cmd = New SqlCommand(cb2)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb5 As String = "Delete from POS_HoldBill where OpenID=@d1"
            cmd = New SqlCommand(cb5)
            cmd.Parameters.AddWithValue("@d1", Val(txtOpenID.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            MessageBox.Show("Successfully closed", "Tally", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearCustomerDisplay()
            End
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub auto()
        Try
            Dim Num As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = ("SELECT MAX(ClosingID) FROM POS_ClosingCash")
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            If (IsDBNull(cmd.ExecuteScalar)) Then
                Num = 1
                txtCloseID.Text = Num.ToString
            Else
                Num = cmd.ExecuteScalar + 1
                txtCloseID.Text = Num.ToString
            End If
            cmd.Dispose()
            con.Close()
            con.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub txtClosingAmount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtClosingAmount.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtClosingAmount.Text
            Dim selectionStart = Me.txtClosingAmount.SelectionStart
            Dim selectionLength = Me.txtClosingAmount.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub frmPOSClosing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        auto()
    End Sub
    Sub GetCustomerDisplayPort()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(CDPort) from POSPrinterSetting where TillID=@d1"
            cmd.Parameters.AddWithValue("@d1", txtTillDetails.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtDisplayPort.Text = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub ClearCustomerDisplay()
        Try
            GetCustomerDisplayPort()
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT * from POSPrinterSetting where TillID=@d1 and CustomerDisplay='Yes'"
            cmd.Parameters.AddWithValue("@d1", txtTillDetails.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                Dim sp As New SerialPort(txtDisplayPort.Text, 9600, Parity.None, 8, StopBits.One)
                sp.Open()
                ' to clear the display
                sp.Write(CChar(ChrW(12)))
                sp.Close()
                sp.Dispose()
                sp = Nothing
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
End Class