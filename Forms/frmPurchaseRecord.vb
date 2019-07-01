Imports System.Data.SqlClient

Imports System.IO

Public Class frmPurchaseRecord

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ST_ID, RTRIM(InvoiceNo), Date,RTRIM(ReferenceNo1),RTRIM(ReferenceNo2),RTRIM(PurchaseType),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate, SubTotal, DiscountPer, Discount,VATPer,VAT, FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Purchase.Remarks),RTRIM(TaxType) from Supplier,Purchase where Supplier.ID=Purchase.Supplier_ID order by [Date]", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17), rdr(18), rdr(19), rdr(20), rdr(21), rdr(22), rdr(23), rdr(24), rdr(25))
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
                If lblSet.Text = "Purchase" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    frmPurchaseEntry.Reset()
                    frmPurchaseEntry.Show()
                    Me.Hide()
                    frmPurchaseEntry.txtST_ID.Text = dr.Cells(0).Value.ToString()
                    frmPurchaseEntry.txtInvoiceNo.Text = dr.Cells(1).Value.ToString()
                    frmPurchaseEntry.dtpDate.Value = dr.Cells(2).Value.ToString()
                    frmPurchaseEntry.txtReferenceNo1.Text = dr.Cells(3).Value.ToString()
                    frmPurchaseEntry.txtReferenceNo2.Text = dr.Cells(4).Value.ToString()
                    frmPurchaseEntry.cmbPurchaseType.Text = dr.Cells(5).Value.ToString()
                    frmPurchaseEntry.txtSup_ID.Text = dr.Cells(6).Value.ToString()
                    frmPurchaseEntry.txtSupplierID.Text = dr.Cells(7).Value.ToString()
                    frmPurchaseEntry.txtSupplierName.Text = dr.Cells(8).Value.ToString()
                    frmPurchaseEntry.txtSupplierInvoiceNo.Text = dr.Cells(9).Value.ToString()
                    frmPurchaseEntry.dtpSupplierInvoiceDate.Text = dr.Cells(10).Value.ToString()
                    frmPurchaseEntry.txtSubTotal.Text = dr.Cells(11).Value.ToString()
                    frmPurchaseEntry.txtDiscPer.Text = dr.Cells(12).Value.ToString()
                    frmPurchaseEntry.txtDisc.Text = dr.Cells(13).Value.ToString()
                    frmPurchaseEntry.txtVAT.Text = dr.Cells(14).Value.ToString()
                    frmPurchaseEntry.txtVATAmt.Text = dr.Cells(15).Value.ToString()
                    frmPurchaseEntry.txtFreightCharges.Text = dr.Cells(16).Value.ToString()
                    frmPurchaseEntry.txtOtherCharges.Text = dr.Cells(17).Value.ToString()
                    frmPurchaseEntry.txtPreviousDue.Text = dr.Cells(18).Value.ToString()
                    frmPurchaseEntry.txtTotal.Text = dr.Cells(19).Value.ToString()
                    frmPurchaseEntry.txtRoundOff.Text = dr.Cells(20).Value.ToString()
                    frmPurchaseEntry.txtGrandTotal.Text = dr.Cells(21).Value.ToString()
                    frmPurchaseEntry.txtTotalPaid.Text = dr.Cells(22).Value.ToString()
                    frmPurchaseEntry.txtBalance.Text = dr.Cells(23).Value.ToString()
                    frmPurchaseEntry.txtRemarks.Text = dr.Cells(24).Value.ToString()
                    frmPurchaseEntry.cmbTaxType.Text = dr.Cells(25).Value.ToString()
                    frmPurchaseEntry.btnSave.Enabled = False
                    frmPurchaseEntry.DataGridView1.Enabled = True
                    frmPurchaseEntry.btnAdd.Enabled = False
                    frmPurchaseEntry.btnRemove.Enabled = False
                    frmPurchaseEntry.lblSet.Text = "Not Allowed"
                    frmPurchaseEntry.pnlCalc.Enabled = False
                    frmPurchaseEntry.btnDelete.Enabled = True
                    frmPurchaseEntry.GetSupplierInfo()
                    frmPurchaseEntry.btnSelection.Enabled = False
                    frmPurchaseEntry.cmbTaxType.Enabled = False
                    frmPurchaseEntry.txtInvoiceNo.ReadOnly = True
                    frmPurchaseEntry.txtInvoiceNo.BackColor = System.Drawing.SystemColors.Control
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "SELECT ProductID,RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Purchase_Join.Barcode),RTRIM(Warehouse_Store), Qty, Price,TotalAmount, Purchase_Join.SalesCost,RTRIM(ManufacturingDate), RTRIM(ExpiryDate),RTRIM(StorageType) from Purchase,Purchase_Join,Product where Purchase.ST_ID=Purchase_Join.PurchaseID and Purchase_Join.ProductID=Product.PID and ST_ID=" & Val(dr.Cells(0).Value) & ""
                    cmd = New SqlCommand(sql, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmPurchaseEntry.DataGridView1.Rows.Clear()
                    While (rdr.Read() = True)
                        frmPurchaseEntry.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
                    End While
                    con.Close()
                    frmPurchaseEntry.GetSupplierBalance1()
                    frmPurchaseEntry.Compute()
                End If
                If lblSet.Text = "PR" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    ' frmPurchaseReturn.Reset()
                    frmPurchaseReturn.Show()
                    Me.Hide()
                    frmPurchaseReturn.txtPurchaseID.Text = dr.Cells(0).Value.ToString()
                    frmPurchaseReturn.txtPurchaseInvoiceNo.Text = dr.Cells(1).Value.ToString()
                    frmPurchaseReturn.txtPurchaseDate.Text = dr.Cells(2).Value.ToString()
                    frmPurchaseReturn.cmbPurchaseType.Text = dr.Cells(5).Value.ToString()
                    frmPurchaseReturn.txtSup_ID.Text = dr.Cells(6).Value.ToString()
                    frmPurchaseReturn.txtSupplierID.Text = dr.Cells(7).Value.ToString()
                    frmPurchaseReturn.txtSupplierName.Text = dr.Cells(8).Value.ToString()
                    frmPurchaseReturn.txtDiscPer.Text = dr.Cells(12).Value.ToString()
                    frmPurchaseReturn.txtDisc.Text = dr.Cells(13).Value.ToString()
                    frmPurchaseReturn.txtVatPer.Text = dr.Cells(14).Value.ToString()
                    frmPurchaseReturn.txtVATAmt.Text = dr.Cells(15).Value.ToString()
                    frmPurchaseReturn.txtTaxType.Text = dr.Cells(25).Value.ToString()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "SELECT distinct Purchase_Join.ProductID,RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Purchase_Join.Barcode),RTRIM(Purchase_Join.Warehouse_Store), Purchase_Join.Qty - ISNULL(SUM(PurchaseReturn_Join.ReturnQty), 0), Purchase_Join.Price,Purchase_Join.TotalAmount, Purchase_Join.SalesCost,RTRIM(Purchase_Join.ManufacturingDate), RTRIM(Purchase_Join.ExpiryDate),RTRIM(Purchase_Join.StorageType) from Purchase Left JOIN Purchase_Join ON Purchase.ST_ID = Purchase_Join.PurchaseID Left JOIN Product ON Purchase_Join.ProductID = Product.PID Left JOIN PurchaseReturn ON Purchase.ST_ID = PurchaseReturn.PurchaseID Left JOIN PurchaseReturn_Join ON Product.PID = PurchaseReturn_Join.ProductID AND PurchaseReturn.PR_ID = PurchaseReturn_Join.PurchaseReturnID where ST_ID=" & dr.Cells(0).Value & " group by Purchase_Join.ProductID,RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Purchase_Join.Barcode),RTRIM(Purchase_Join.Warehouse_Store),Purchase_Join.Qty,Purchase_Join. Price,Purchase_Join.TotalAmount, Purchase_Join.SalesCost,RTRIM(Purchase_Join.ManufacturingDate), RTRIM(Purchase_Join.ExpiryDate),RTRIM(Purchase_Join.StorageType) having (Purchase_Join.Qty - ISNULL(SUM(PurchaseReturn_Join.ReturnQty), 0)) > 0 order by 3"
                    cmd = New SqlCommand(sql, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmPurchaseReturn.DataGridView2.Rows.Clear()
                    While (rdr.Read() = True)
                        frmPurchaseReturn.DataGridView2.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11))
                    End While
                    con.Close()
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
        txtSupplierName.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        Getdata()
    End Sub



    Private Sub txtSupplierName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSupplierName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ST_ID, RTRIM(InvoiceNo), Date,RTRIM(ReferenceNo1),RTRIM(ReferenceNo2),RTRIM(PurchaseType),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate, SubTotal, DiscountPer, Discount,VATPer,VAT, FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Purchase.Remarks),RTRIM(TaxType) from Supplier,Purchase where Supplier.ID=Purchase.Supplier_ID  and [Name] like '%" & txtSupplierName.Text & "%' order by [Date]", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17), rdr(18), rdr(19), rdr(20), rdr(21), rdr(22), rdr(23), rdr(24), rdr(25))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ST_ID, RTRIM(InvoiceNo), Date,RTRIM(ReferenceNo1),RTRIM(ReferenceNo2),RTRIM(PurchaseType),Supplier.ID, RTRIM(Supplier.SupplierID),RTRIM(Name),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate, SubTotal, DiscountPer, Discount,VATPer,VAT, FreightCharges, OtherCharges,PreviousDue, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, RTRIM(Purchase.Remarks),RTRIM(TaxType) from Supplier,Purchase where Supplier.ID=Purchase.Supplier_ID  and [Date] between @d1 and @d2 order by [Date]", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17), rdr(18), rdr(19), rdr(20), rdr(21), rdr(22), rdr(23), rdr(24), rdr(25))
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
