Imports System.Data.SqlClient
Public Class frmCreditCustomerBalance
    Dim str As String
    Sub Reset()
        txtContactNo.Text = ""
        txtCustomerName.Text = ""
        GetData()
    End Sub
    Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT CC_ID,CreditCustomer.CreditCustomerID,RTRIM(CreditCustomer.Name),RTRIM(ContactNo),IsNull(sum(Credit)-sum(Debit),0) FROM CreditCustomer Left join LedgerBook on CreditCustomer.CreditCustomerID=LedgerBook.PartyID where Active='Yes' group by CC_ID, CreditCustomerID,CreditCustomer.name,ContactNo order by CreditCustomer.Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmMemberBalance_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                Me.Hide()
                frmPOS.Show()
                lblSet.Text = ""
                frmPOS.txtPaymentMode.Text = "Credit Customer"
                frmPOS.txtMemberID.Text = dr.Cells(1).Value
                frmPOS.txtCC_ID.Text = dr.Cells(0).Value
                frmPOS.lblDateTime.Visible = False
                frmPOS.lblCustomer.Visible = True
                frmPOS.lblCustomerName.Visible = True
                frmPOS.TableLayoutPanel1.Enabled = False
                frmPOS.btnCash.Enabled = False
                frmPOS.btnCreditCard.Enabled = False
                frmPOS.btnDebitCard.Enabled = False
                frmPOS.btnWallet.Enabled = False
                frmPOS.btnBillDiscount.Enabled = False
                frmPOS.lblBalance.Visible = True
                frmPOS.lblBalanceVal.Visible = True
                frmPOS.txtCash.Text = "0.00"
                frmPOS.txtChange.Text = "0.00"
                If dr.Cells(4).Value >= 0 Then
                    str = "CR"
                ElseIf dr.Cells(4).Value < 0 Then
                    str = "DR"
                End If
                dr.Cells(4).Value = Math.Abs(dr.Cells(4).Value)
                lblSet.Text = (dr.Cells(4).Value & " " & str).ToString()
                frmPOS.lblCustomerName.Text = dr.Cells(2).Value
                frmPOS.lblBalanceVal.Text = lblSet.Text
                frmPOS.txtCash.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))
    End Sub

    Private Sub txtCustomerName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCustomerName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT CC_ID,CreditCustomer.CreditCustomerID,RTRIM(CreditCustomer.Name),RTRIM(ContactNo),IsNull(sum(Credit)-sum(Debit),0) FROM CreditCustomer Left join LedgerBook on CreditCustomer.CreditCustomerID=LedgerBook.PartyID where Active='Yes' and CreditCustomer.Name like '%" & txtCustomerName.Text & "%' group by CC_ID, CreditCustomerID,CreditCustomer.name,ContactNo order by CreditCustomer.Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtContactNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtContactNo.TextChanged
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT CC_ID,CreditCustomer.CreditCustomerID,RTRIM(CreditCustomer.Name),RTRIM(ContactNo),IsNull(sum(Credit)-sum(Debit),0) FROM CreditCustomer Left join LedgerBook on CreditCustomer.CreditCustomerID=LedgerBook.PartyID where Active='Yes' and ContactNo like '%" & txtContactNo.Text & "%' group by CC_ID, CreditCustomerID,CreditCustomer.name,ContactNo order by CreditCustomer.Name", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class