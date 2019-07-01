Imports System.Data.SqlClient
Public Class frmPOSOpening


    Private Sub frmDropandPayout_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtTillDetails.Text = System.Net.Dns.GetHostName
        auto()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        End
    End Sub

    Private Sub btnChange_Click(sender As System.Object, e As System.EventArgs) Handles btnChange.Click
        Try
            If Len(Trim(txtOpeningAmount.Text)) = 0 Then
                MessageBox.Show("Please enter opening/drop amount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtOpeningAmount.Focus()
                Exit Sub
            End If
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into POS_OpeningCash(OpenID,TillDetails, UserID, OpeningDate,OpeningCash, Closed) VALUES (@d1,@d2,@d3,@d4,@d5,0)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtOpenID.Text))
            cmd.Parameters.AddWithValue("@d2", txtTillDetails.Text)
            cmd.Parameters.AddWithValue("@d3", txtUserID.Text)
            cmd.Parameters.AddWithValue("@d4", dtpOpenDate.Value)
            cmd.Parameters.AddWithValue("@d5", Val(txtOpeningAmount.Text))
            cmd.ExecuteReader()
            con.Close()
            Me.Hide()
            frmPOS.Reset()
            frmPOS.txtUID.Text = txtUserID.Text
            frmPOS.txtTillCode.Text = txtTillDetails.Text
            frmPOS.txtOpenID.Text = txtOpenID.Text
            frmPOS.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtOpeningAmount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOpeningAmount.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtOpeningAmount.Text
            Dim selectionStart = Me.txtOpeningAmount.SelectionStart
            Dim selectionLength = Me.txtOpeningAmount.SelectionLength

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

    Private Sub auto()
        Try
            Dim Num As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = ("SELECT MAX(OpenID) FROM POS_OpeningCash")
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            If (IsDBNull(cmd.ExecuteScalar)) Then
                Num = 1
                txtOpenID.Text = Num.ToString
            Else
                Num = cmd.ExecuteScalar + 1
                txtOpenID.Text = Num.ToString
            End If
            cmd.Dispose()
            con.Close()
            con.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class