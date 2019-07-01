﻿Imports System.Data.SqlClient

Imports System.IO

Public Class frmPurchaseReturnRecord

    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT PR_ID, RTRIM(PRNo),PurchaseReturn.Date,RTRIM(PurchaseID),RTRIM(InvoiceNo),Purchase.Date, RTRIM(Supplier.SupplierID),RTRIM(Name),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate,RTRIM(PurchaseReturn.SubTotal),RTRIM(PurchaseReturn.DiscPer),RTRIM(PurchaseReturn.Discount),RTRIM(PurchaseReturn.VATPer),RTRIM(PurchaseReturn.VATAmt),PurchaseReturn.FreightCharges,PurchaseReturn.OtherCharges,RTRIM(PurchaseReturn.Total),RTRIM(PurchaseReturn.RoundOff),RTRIM(PurchaseReturn.GrandTotal),RTRIM(TaxType) FROM Purchase,PurchaseReturn,Supplier where Purchase.ST_ID=PurchaseReturn.PurchaseID and Supplier.ID=Purchase.Supplier_ID order by PurchaseReturn.Date", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17), rdr(18), rdr(19), rdr(20))
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

                If lblSet.Text = "PR" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    ' frmPurchaseReturn.Reset()
                    frmPurchaseReturn.Show()
                    Me.Hide()
                    frmPurchaseReturn.txtPRID.Text = dr.Cells(0).Value.ToString()
                    frmPurchaseReturn.txtPRNO.Text = dr.Cells(1).Value.ToString()
                    frmPurchaseReturn.dtpPRDate.Text = dr.Cells(2).Value.ToString()
                    frmPurchaseReturn.txtPurchaseID.Text = dr.Cells(3).Value.ToString()
                    frmPurchaseReturn.txtPurchaseInvoiceNo.Text = dr.Cells(4).Value.ToString()
                    frmPurchaseReturn.txtPurchaseDate.Text = dr.Cells(5).Value.ToString()
                    frmPurchaseReturn.txtSupplierID.Text = dr.Cells(6).Value.ToString()
                    frmPurchaseReturn.txtSupplierName.Text = dr.Cells(7).Value.ToString()
                    frmPurchaseReturn.txtSubTotal.Text = dr.Cells(10).Value.ToString()
                    frmPurchaseReturn.txtDiscPer.Text = dr.Cells(11).Value.ToString()
                    frmPurchaseReturn.txtDisc.Text = dr.Cells(12).Value.ToString()
                    frmPurchaseReturn.txtVatPer.Text = dr.Cells(13).Value.ToString()
                    frmPurchaseReturn.txtVATAmt.Text = dr.Cells(14).Value.ToString()
                    frmPurchaseReturn.txtFreightCharges.Text = dr.Cells(15).Value.ToString()
                    frmPurchaseReturn.txtOtherCharges.Text = dr.Cells(16).Value.ToString()
                    frmPurchaseReturn.txtTotal.Text = dr.Cells(17).Value.ToString()
                    frmPurchaseReturn.txtRoundOff.Text = dr.Cells(18).Value.ToString()
                    frmPurchaseReturn.txtGrandTotal.Text = dr.Cells(19).Value.ToString()
                    frmPurchaseReturn.txtTaxType.Text = dr.Cells(20).Value.ToString()
                    frmPurchaseReturn.btnSave.Enabled = False
                    frmPurchaseReturn.DataGridView1.Enabled = True
                    frmPurchaseReturn.btnAdd.Enabled = False
                    frmPurchaseReturn.btnRemove.Enabled = False
                    frmPurchaseReturn.lblSet.Text = "Not Allowed"
                    frmPurchaseReturn.pnlCalc.Enabled = False
                    frmPurchaseReturn.btnDelete.Enabled = True
                    frmPurchaseReturn.btnSelection.Enabled = False
                    frmPurchaseReturn.txtPRNO.ReadOnly = True
                    frmPurchaseReturn.txtPRNO.BackColor = System.Drawing.SystemColors.Control
                    frmPurchaseReturn.btnDebitNote.Enabled = True
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "SELECT Rtrim(PurchaseReturn_Join.ProductID),Rtrim(Product.ProductCode),Rtrim(Product.ProductName),Rtrim(PurchaseReturn_Join.Barcode),Rtrim(PurchaseReturn_Join.Warehouse_Store),Rtrim(PurchaseReturn_Join.Qty),Rtrim(PurchaseReturn_Join.Price),Rtrim(PurchaseReturn_Join.TotalAmount),(PurchaseReturn_Join.SalesCost),RTRIM(PurchaseReturn_Join.ManufacturingDate),RTRIM(PurchaseReturn_Join.ExpiryDate),(PurchaseReturn_Join.ReturnQty),RTRIM(StorageType) FROM PurchaseReturn_Join INNER JOIN PurchaseReturn ON PurchaseReturn_Join.PurchaseReturnID = PurchaseReturn.PR_ID INNER JOIN Product ON Product.PID = PurchaseReturn_Join.ProductID and PR_ID=" & dr.Cells(0).Value & ""
                    cmd = New SqlCommand(sql, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmPurchaseReturn.DataGridView1.Rows.Clear()
                    While (rdr.Read() = True)
                        frmPurchaseReturn.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12))
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
            cmd = New SqlCommand("SELECT PR_ID, RTRIM(PRNo),PurchaseReturn.Date,RTRIM(PurchaseID),RTRIM(InvoiceNo),Purchase.Date, RTRIM(Supplier.SupplierID),RTRIM(Name),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate,RTRIM(PurchaseReturn.SubTotal),RTRIM(PurchaseReturn.DiscPer),RTRIM(PurchaseReturn.Discount),RTRIM(PurchaseReturn.VATPer),RTRIM(PurchaseReturn.VATAmt),PurchaseReturn.FreightCharges,PurchaseReturn.OtherCharges,RTRIM(PurchaseReturn.Total),RTRIM(PurchaseReturn.RoundOff),RTRIM(PurchaseReturn.GrandTotal),RTRIM(TaxType) FROM Purchase,PurchaseReturn,Supplier where Purchase.ST_ID=PurchaseReturn.PurchaseID and Supplier.ID=Purchase.Supplier_ID  and [Name] like '%" & txtSupplierName.Text & "%' order by PurchaseReturn.Date", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17), rdr(18), rdr(19), rdr(20))
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
            cmd = New SqlCommand("SELECT PR_ID, RTRIM(PRNo),PurchaseReturn.Date,RTRIM(PurchaseID),RTRIM(InvoiceNo),Purchase.Date, RTRIM(Supplier.SupplierID),RTRIM(Name),RTRIM(SupplierInvoiceNo),SupplierInvoiceDate,RTRIM(PurchaseReturn.SubTotal),RTRIM(PurchaseReturn.DiscPer),RTRIM(PurchaseReturn.Discount),RTRIM(PurchaseReturn.VATPer),RTRIM(PurchaseReturn.VATAmt),PurchaseReturn.FreightCharges,PurchaseReturn.OtherCharges,RTRIM(PurchaseReturn.Total),RTRIM(PurchaseReturn.RoundOff),RTRIM(PurchaseReturn.GrandTotal),RTRIM(TaxType) FROM Purchase,PurchaseReturn,Supplier where Purchase.ST_ID=PurchaseReturn.PurchaseID and Supplier.ID=Purchase.Supplier_ID and PurchaseReturn.Date between @d1 and @d2 order by PurchaseReturn.Date", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17), rdr(18), rdr(19), rdr(20))
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
