Imports System.Data.SqlClient
Public Class frmSplash

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Try
            Label3.Visible = Not Label3.Visible

            If System.IO.File.Exists(Application.StartupPath & "\SQLSettings.dat") Then
                    ProgressBar1.Value = ProgressBar1.Value + 2
                    If (ProgressBar1.Value = 10) Then
                        Label3.Text = "Loading..."
                    ElseIf (ProgressBar1.Value = 20) Then
                        Label3.Text = "Loading..."
                    ElseIf (ProgressBar1.Value = 40) Then
                        Label3.Text = "Loading..."
                    ElseIf (ProgressBar1.Value = 60) Then
                        Label3.Text = "Loading..."
                    ElseIf (ProgressBar1.Value = 80) Then
                        Label3.Text = "Loading..."
                    ElseIf (ProgressBar1.Value = 100) Then
                        frmLogin.Show()
                        Timer2.Enabled = False
                        Me.Hide()
                    End If
            Else

                ProgressBar1.Value = ProgressBar1.Value + 2
                If (ProgressBar1.Value = 10) Then
                    Label3.Text = "Loading..."
                ElseIf (ProgressBar1.Value = 20) Then
                    Label3.Text = "Loading..."
                ElseIf (ProgressBar1.Value = 40) Then
                    Label3.Text = "Loading..."
                ElseIf (ProgressBar1.Value = 60) Then
                    Label3.Text = "Loading..."
                ElseIf (ProgressBar1.Value = 80) Then
                    Label3.Text = "Loading..."
                ElseIf (ProgressBar1.Value = 100) Then
                    frmSqlServerSetting.Reset()
                    frmSqlServerSetting.Show()
                    Timer2.Enabled = False
                    Me.Hide()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
            Panel1.Location = New Point(Me.ClientSize.Width / 2 - Panel1.Size.Width / 2, Me.ClientSize.Height / 2 - Panel1.Size.Height / 2)
            Panel1.Anchor = AnchorStyles.None
    End Sub
End Class