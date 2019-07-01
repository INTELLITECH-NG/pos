Public Class frmSetBillDiscount
    Dim sign_Indicator As Integer = 0
    Dim variable1 As Double
    Dim variable2 As Double
    Dim fl As Boolean = False
    Dim s, x As String
    Private Sub btnOkay_Click(sender As System.Object, e As System.EventArgs) Handles btnOkay.Click
        Try
            If txtDiscount.Text = "" Then
                MessageBox.Show("Please enter the discount ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDiscount.Focus()
                Exit Sub
            End If
            If frmPOS.cmbDiscountType.SelectedIndex = 0 Then
                frmPOS.txtDiscPer.Text = txtDiscount.Text
            End If
            If frmPOS.cmbDiscountType.SelectedIndex = 1 Then
                frmPOS.txtDiscAmt.Text = txtDiscount.Text
            End If
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub txtRate_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscount.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtDiscount.Text
            Dim selectionStart = Me.txtDiscount.SelectionStart
            Dim selectionLength = Me.txtDiscount.SelectionLength

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

    Private Sub frmChangeRate_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnTA1_Click(sender As System.Object, e As System.EventArgs) Handles btnTA1.Click
        If sign_Indicator = 0 Then
            txtDiscount.Text = txtDiscount.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            txtDiscount.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA2_Click(sender As System.Object, e As System.EventArgs) Handles btnTA2.Click
        If sign_Indicator = 0 Then
            txtDiscount.Text = txtDiscount.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            txtDiscount.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA3_Click(sender As System.Object, e As System.EventArgs) Handles btnTA3.Click
        If sign_Indicator = 0 Then
            txtDiscount.Text = txtDiscount.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            txtDiscount.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA4_Click(sender As System.Object, e As System.EventArgs) Handles btnTA4.Click
        If sign_Indicator = 0 Then
            txtDiscount.Text = txtDiscount.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            txtDiscount.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA5_Click(sender As System.Object, e As System.EventArgs) Handles btnTA5.Click
        If sign_Indicator = 0 Then
            txtDiscount.Text = txtDiscount.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            txtDiscount.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA6_Click(sender As System.Object, e As System.EventArgs) Handles btnTA6.Click
        If sign_Indicator = 0 Then
            txtDiscount.Text = txtDiscount.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            txtDiscount.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA7_Click(sender As System.Object, e As System.EventArgs) Handles btnTA7.Click
        If sign_Indicator = 0 Then
            txtDiscount.Text = txtDiscount.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            txtDiscount.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA8_Click(sender As System.Object, e As System.EventArgs) Handles btnTA8.Click
        If sign_Indicator = 0 Then
            txtDiscount.Text = txtDiscount.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            txtDiscount.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA9_Click(sender As System.Object, e As System.EventArgs) Handles btnTA9.Click
        If sign_Indicator = 0 Then
            txtDiscount.Text = txtDiscount.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            txtDiscount.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTAComma_Click(sender As System.Object, e As System.EventArgs) Handles btnTAComma.Click
        Dim i As Integer = 0
        Dim chr As Char = ControlChars.NullChar
        Dim decimal_Indicator As Integer = 0
        Dim l As Integer = txtDiscount.Text.Length - 1
        If sign_Indicator <> 1 Then
            For i = 0 To l
                chr = txtDiscount.Text(i)
                If chr = "."c Then
                    decimal_Indicator = 1
                End If
            Next

            If decimal_Indicator <> 1 Then
                txtDiscount.Text = txtDiscount.Text + Convert.ToString(".")
            End If
        End If
    End Sub

    Private Sub btnTA0_Click(sender As System.Object, e As System.EventArgs) Handles btnTA0.Click
        If sign_Indicator = 0 Then
            txtDiscount.Text = txtDiscount.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            txtDiscount.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTAx_Click(sender As System.Object, e As System.EventArgs) Handles btnTAx.Click
        s = txtDiscount.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        txtDiscount.Text = x
        x = ""
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        txtDiscount.Text = ""
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class