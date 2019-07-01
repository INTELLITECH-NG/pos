Imports System.Data.SqlClient
Public Class frmHoldBill
    Sub GetData(ByVal a As Integer)
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select POS_HoldBill.Hold_ID,POS_HoldBill.Date,POS_OpeningCash.OpenID,RTRIM(TillDetails),RTRIM(POS_OpeningCash.UserID),DiscPer,DiscAmt from POS_HoldBill,POS_OpeningCash where POS_HoldBill.OpenID=POS_OpeningCash.OpenID and POS_HoldBill.OpenID=" & Val(a) & " order by POS_HoldBill.Date"
            cmd = New SqlCommand(sql, con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DataGridView1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                Me.Hide()
                frmPOS.Show()
                frmPOS.txtHoldID.Text = dr.Cells(0).Value
                frmPOS.txtDiscPer.Text = dr.Cells(5).Value.ToString()
                frmPOS.txtDiscAmt.Text = dr.Cells(6).Value.ToString()
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "SELECT ProductID,RTRIM(ProductCode),RTRIM(ProductName),RTRIM(POS_HoldBillItems.Barcode),Qty,RTRIM(MfgDate),RTRIM(ExpiryDate), POS_HoldBillItems.SalesRate,POS_HoldBillItems.DiscountPer, POS_HoldBillItems.Discount, VATPer, VAT,RTRIM(SalesUnit),POS_HoldBillItems.TotalAmount,POS_HoldBillItems.PurchaseRate,POS_HoldBillItems.Margin from POS_HoldBill,POS_HoldBillItems,Product where POS_HoldBill.Hold_ID=POS_HoldBillItems.HoldID and Product.PID=POS_HoldBillItems.ProductID and Hold_ID=@d1 order by ProductName"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@d1", dr.Cells(0).Value)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                frmPOS.DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    frmPOS.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
                End While
                con.Close()
                frmPOS.auto()
                frmPOS.Calc()
                frmPOS.Calc1()
                frmPOS.Compute()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class