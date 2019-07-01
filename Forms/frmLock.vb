Imports System.Data.SqlClient
Public Class frmLock
    Dim frm As New frmOption
    Dim sign_Indicator As Integer = 0
    Dim variable1 As Double
    Dim variable2 As Double
    Dim fl As Boolean = False
    Dim s, x As String
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try
            GetData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTA0_Click(sender As System.Object, e As System.EventArgs) Handles btnTA0.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnX_Click(sender As System.Object, e As System.EventArgs) Handles btnX.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        s = Password.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        Password.Text = x
        x = ""
    End Sub
    Private Sub btnTA9_Click(sender As System.Object, e As System.EventArgs) Handles btnTA9.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA8_Click(sender As System.Object, e As System.EventArgs) Handles btnTA8.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA7_Click(sender As System.Object, e As System.EventArgs) Handles btnTA7.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA6_Click(sender As System.Object, e As System.EventArgs) Handles btnTA6.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA5_Click(sender As System.Object, e As System.EventArgs) Handles btnTA5.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA4_Click(sender As System.Object, e As System.EventArgs) Handles btnTA4.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA3_Click(sender As System.Object, e As System.EventArgs) Handles btnTA3.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA2_Click(sender As System.Object, e As System.EventArgs) Handles btnTA2.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        fl = True
    End Sub
    Private Sub btnTA1_Click(sender As System.Object, e As System.EventArgs) Handles btnTA1.Click
        If Password.Text = "ENTER PIN" Then
            Password.Text = ""
        End If
        Password.PasswordChar = "•"
        If sign_Indicator = 0 Then
            Password.Text = Password.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            Password.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA1_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnTA1.MouseHover
        btnTA1.BackColor = Color.Firebrick
        btnTA1.ForeColor = Color.White
    End Sub

    Private Sub btnTA1_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnTA1.MouseLeave
        btnTA1.BackColor = Color.White
        btnTA1.ForeColor = Color.Black
    End Sub

    Private Sub btnTA0_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA0.MouseHover
        btnTA0.BackColor = Color.Firebrick
        btnTA0.ForeColor = Color.White
    End Sub

    Private Sub btnTA0_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA0.MouseLeave
        btnTA0.BackColor = Color.White
        btnTA0.ForeColor = Color.Black
    End Sub

    Private Sub btnTA2_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA2.MouseHover
        btnTA2.BackColor = Color.Firebrick
        btnTA2.ForeColor = Color.White
    End Sub

    Private Sub btnTA2_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA2.MouseLeave
        btnTA2.BackColor = Color.White
        btnTA2.ForeColor = Color.Black
    End Sub

    Private Sub btnTA3_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA3.MouseHover
        btnTA3.BackColor = Color.Firebrick
        btnTA3.ForeColor = Color.White
    End Sub

    Private Sub btnTA3_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA3.MouseLeave
        btnTA3.BackColor = Color.White
        btnTA3.ForeColor = Color.Black
    End Sub

    Private Sub btnTA4_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA4.MouseHover
        btnTA4.BackColor = Color.Firebrick
        btnTA4.ForeColor = Color.White
    End Sub

    Private Sub btnTA4_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA4.MouseLeave
        btnTA4.BackColor = Color.White
        btnTA4.ForeColor = Color.Black
    End Sub

    Private Sub btnTA5_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA5.MouseHover
        btnTA5.BackColor = Color.Firebrick
        btnTA5.ForeColor = Color.White
    End Sub

    Private Sub btnTA5_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA5.MouseLeave
        btnTA5.BackColor = Color.White
        btnTA5.ForeColor = Color.Black
    End Sub

    Private Sub btnTA6_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA6.MouseHover
        btnTA6.BackColor = Color.Firebrick
        btnTA6.ForeColor = Color.White
    End Sub

    Private Sub btnTA6_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA6.MouseLeave
        btnTA6.BackColor = Color.White
        btnTA6.ForeColor = Color.Black
    End Sub

    Private Sub btnTA7_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA7.MouseHover
        btnTA7.BackColor = Color.Firebrick
        btnTA7.ForeColor = Color.White
    End Sub

    Private Sub btnTA7_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA7.MouseLeave
        btnTA7.BackColor = Color.White
        btnTA7.ForeColor = Color.Black
    End Sub

    Private Sub btnTA8_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA8.MouseHover
        btnTA8.BackColor = Color.Firebrick
        btnTA8.ForeColor = Color.White
    End Sub

    Private Sub btnTA8_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA8.MouseLeave
        btnTA8.BackColor = Color.White
        btnTA8.ForeColor = Color.Black
    End Sub

    Private Sub btnTA9_MouseHover(sender As Object, e As System.EventArgs) Handles btnTA9.MouseHover
        btnTA9.BackColor = Color.Firebrick
        btnTA9.ForeColor = Color.White
    End Sub

    Private Sub btnTA9_MouseLeave(sender As Object, e As System.EventArgs) Handles btnTA9.MouseLeave
        btnTA9.BackColor = Color.White
        btnTA9.ForeColor = Color.Black
    End Sub

    Private Sub btnX_MouseHover(sender As Object, e As System.EventArgs) Handles btnX.MouseHover
        btnX.BackColor = Color.Firebrick
        btnX.ForeColor = Color.White
    End Sub

    Private Sub btnX_MouseLeave(sender As Object, e As System.EventArgs) Handles btnX.MouseLeave
        btnX.BackColor = Color.White
        btnX.ForeColor = Color.Black
    End Sub



    Private Sub OK_MouseHover(sender As System.Object, e As System.EventArgs) Handles btnLogin.MouseHover
        btnLogin.BackColor = Color.Yellow

    End Sub

    Private Sub OK_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnLogin.MouseLeave
        btnLogin.BackColor = Color.Transparent
    End Sub

    Private Sub Password_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Password.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Password_TextChanged(sender As System.Object, e As System.EventArgs) Handles Password.TextChanged

        Try
            If Password.TextLength = 4 Then
                GetData()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(Password) FROM Registration where Password=@d2 and Active='Yes' and UserID=@d1"
            cmd.Parameters.AddWithValue("@d1", txtUserID.Text)
            cmd.Parameters.AddWithValue("@d2", Encrypt(Password.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                Me.Close()
            Else
                Password.PasswordChar = ""
                Password.Text = "ENTER PIN"
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class
