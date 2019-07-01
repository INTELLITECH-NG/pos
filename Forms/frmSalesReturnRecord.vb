Imports System.Data.SqlClient

Imports System.IO

Public Class frmSalesReturnRecord

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT SalesReturn.SR_ID, RTRIM(SalesReturn.SRNo), SalesReturn.Date, SalesReturn.SalesID, RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.PaymentMode),CC_ID,RTRIM(CreditCustomerID),RTRIM(Name), RTRIM(InvoiceInfo.TaxType), SalesReturn.SubTotal,SalesReturn.VAT, SalesReturn.GrandTotal FROM SalesReturn LEFT OUTER JOIN InvoiceInfo ON InvoiceInfo.Inv_ID=SalesReturn.SalesID LEFT OUTER JOIN CreditCustomer ON InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID  order by SalesReturn.Date", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then

                If lblSet.Text = "SR" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    'frmSalesReturn.Reset()
                    frmSalesReturn.Show()
                    Me.Hide()
                    frmSalesReturn.txtSRID.Text = dr.Cells(0).Value.ToString()
                    frmSalesReturn.txtSRNO.Text = dr.Cells(1).Value.ToString()
                    frmSalesReturn.dtpSRDate.Text = dr.Cells(2).Value.ToString()
                    frmSalesReturn.txtSalesID.Text = dr.Cells(3).Value.ToString()
                    frmSalesReturn.txtSalesInvoiceNo.Text = dr.Cells(4).Value.ToString()
                    frmSalesReturn.txtSalesDate.Text = dr.Cells(5).Value.ToString()
                    frmSalesReturn.txtPaymentMode.Text = dr.Cells(6).Value.ToString()
                    frmSalesReturn.txtCC_ID.Text = dr.Cells(7).Value.ToString()
                    frmSalesReturn.lblCustomerName.Text = dr.Cells(9).Value.ToString()
                    frmSalesReturn.txtTaxType.Text = dr.Cells(10).Value.ToString()
                    frmSalesReturn.txtSubTotal.Text = dr.Cells(11).Value.ToString()
                    frmSalesReturn.txtVAT.Text = dr.Cells(12).Value.ToString()
                    frmSalesReturn.txtGrandTotal.Text = dr.Cells(13).Value.ToString()
                    frmSalesReturn.DataGridView1.Enabled = True
                    frmSalesReturn.btnAdd.Enabled = False
                    frmSalesReturn.btnRemove.Enabled = False
                    frmSalesReturn.lblSet.Text = "Not Allowed"
                    frmSalesReturn.pnlCalc.Enabled = False
                    frmSalesReturn.btnDelete.Enabled = True
                    frmSalesReturn.btnSelection.Enabled = False
                    frmSalesReturn.btnSave.Enabled = False
                    If dr.Cells(6).Value.ToString() = "Credit Customer" Then
                        frmSalesReturn.lblCustomer.Visible = True
                        frmSalesReturn.lblCustomerName.Visible = True
                    Else
                        frmSalesReturn.lblCustomer.Visible = False
                        frmSalesReturn.lblCustomerName.Visible = False
                    End If
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "SELECT Product.PID, RTRIM(Product.ProductCode), RTRIM(Product.ProductName), RTRIM(SalesReturn_Join.Barcode), RTRIM(SalesReturn_Join.ManufacturingDate), RTRIM(SalesReturn_Join.ExpiryDate), Qty,RTRIM(SalesUnit), SalesReturn_Join.SalesCost, SalesReturn_Join.DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.ReturnQty, SalesReturn_Join.TotalAmount FROM SalesReturn INNER JOIN SalesReturn_Join ON SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID INNER JOIN Product ON SalesReturn_Join.ProductID = Product.PID and SR_ID=" & Val(dr.Cells(0).Value) & ""
                    cmd = New SqlCommand(sql, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmSalesReturn.DataGridView2.Rows.Clear()
                    While (rdr.Read() = True)
                        frmSalesReturn.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14))
                    End While
                    con.Close()
                    frmSalesReturn.txtSRNO.ReadOnly = True
                    frmSalesReturn.txtSRNO.BackColor = System.Drawing.SystemColors.Control
                    frmSalesReturn.btnCreditNote.Enabled = True
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgw_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgw.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If dgw.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            dgw.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
    Sub Reset()
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        Getdata()
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT SalesReturn.SR_ID, RTRIM(SalesReturn.SRNo), SalesReturn.Date, SalesReturn.SalesID, RTRIM(InvoiceInfo.InvoiceNo), InvoiceInfo.InvoiceDate, RTRIM(InvoiceInfo.PaymentMode),CC_ID,RTRIM(CreditCustomerID),RTRIM(Name), RTRIM(InvoiceInfo.TaxType), SalesReturn.SubTotal,SalesReturn.VAT, SalesReturn.GrandTotal FROM SalesReturn LEFT OUTER JOIN InvoiceInfo ON InvoiceInfo.Inv_ID=SalesReturn.SalesID LEFT OUTER JOIN CreditCustomer ON InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID  where SalesReturn.Date between @d1 and @d2 order by SalesReturn.Date", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

End Class
