Imports System.Data.SqlClient
Public Class frmFindItem

    Private Sub DataGridView1_RowHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.RowHeaderMouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                Me.Hide()
                frmPOS.Show()
                frmPOS.txtProductID.Text = dr.Cells(0).Value.ToString()
                frmPOS.txtProductCode.Text = dr.Cells(1).Value.ToString()
                frmPOS.txtProductName.Text = dr.Cells(2).Value.ToString()
                frmPOS.txtBarcode.Text = dr.Cells(3).Value.ToString()
                frmPOS.txtSalesRate.Text = dr.Cells(4).Value.ToString()
                frmPOS.txtVAT.Text = dr.Cells(5).Value.ToString()
                frmPOS.lblUnit.Text = dr.Cells(6).Value.ToString()
                frmPOS.txtMfgDate.Text = dr.Cells(7).Value.ToString()
                frmPOS.txtExpiryDate.Text = dr.Cells(8).Value.ToString()
                frmPOS.txtPurchaseRate.Text = dr.Cells(10).Value.ToString()
                frmPOS.txtQty.Text = 1
                frmPOS.Compute()
                frmPOS.AddDataToGrid()
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
    Sub Reset()
        cmbFilterBy.SelectedIndex = 0
        txtKeyword.Text = ""
        DataGridView1.Rows.Clear()
        txtKeyword.Focus()

    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub
    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Try
            If cmbFilterBy.SelectedIndex = 0 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "SELECT (PID),RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock_Company.Barcode),Temp_Stock_Company.SalesRate,TaxMaster.Percentage,RTRIM(Product.SalesUnit),RTRIM(Temp_Stock_Company.ManufacturingDate),RTRIM(Temp_Stock_Company.ExpiryDate),Temp_Stock_Company.Qty,Temp_Stock_Company.PurchaseRate from Product,Temp_Stock_Company,TaxMaster where Product.PID=Temp_Stock_Company.ProductID and TaxMaster.TaxName=Product.VATCommodity  and Product.ProductName like '" & txtKeyword.Text & "%' order by ProductName"
                cmd = New SqlCommand(sql, con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
                End While
                con.Close()
            End If
            If cmbFilterBy.SelectedIndex = 1 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "SELECT (PID),RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock_Company.Barcode),Temp_Stock_Company.SalesRate,TaxMaster.Percentage,RTRIM(Product.SalesUnit),RTRIM(Temp_Stock_Company.ManufacturingDate),RTRIM(Temp_Stock_Company.ExpiryDate),Temp_Stock_Company.Qty,Temp_Stock_Company.PurchaseRate from Product,Temp_Stock_Company,TaxMaster where Product.PID=Temp_Stock_Company.ProductID and TaxMaster.TaxName=Product.VATCommodity  and Product.Category like '" & txtKeyword.Text & "%' order by ProductName"
                cmd = New SqlCommand(sql, con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
                End While
                con.Close()
            End If
            If cmbFilterBy.SelectedIndex = 2 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "SELECT (PID),RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock_Company.Barcode),Temp_Stock_Company.SalesRate,TaxMaster.Percentage,RTRIM(Product.SalesUnit),RTRIM(Temp_Stock_Company.ManufacturingDate),RTRIM(Temp_Stock_Company.ExpiryDate),Temp_Stock_Company.Qty,Temp_Stock_Company.PurchaseRate from Product,Temp_Stock_Company,TaxMaster where Product.PID=Temp_Stock_Company.ProductID and TaxMaster.TaxName=Product.VATCommodity  and Product.PID like '" & txtKeyword.Text & "%' order by ProductName"
                cmd = New SqlCommand(sql, con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
                End While
                con.Close()
            End If
            If cmbFilterBy.SelectedIndex = 3 Then
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "SELECT (PID),RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock_Company.Barcode),Temp_Stock_Company.SalesRate,TaxMaster.Percentage,RTRIM(Product.SalesUnit),RTRIM(Temp_Stock_Company.ManufacturingDate),RTRIM(Temp_Stock_Company.ExpiryDate),Temp_Stock_Company.Qty,Temp_Stock_Company.PurchaseRate from Product,Temp_Stock_Company,TaxMaster where Product.PID=Temp_Stock_Company.ProductID and TaxMaster.TaxName=Product.VATCommodity  and Temp_Stock_Company.Barcode like '" & txtKeyword.Text & "%' order by ProductName"
                cmd = New SqlCommand(sql, con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtKeyword_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtKeyword.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If cmbFilterBy.SelectedIndex = 0 Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "SELECT (PID),RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock_Company.Barcode),Temp_Stock_Company.SalesRate,TaxMaster.Percentage,RTRIM(Product.SalesUnit),RTRIM(Temp_Stock_Company.ManufacturingDate),RTRIM(Temp_Stock_Company.ExpiryDate),Temp_Stock_Company.Qty,Temp_Stock_Company.PurchaseRate from Product,Temp_Stock_Company,TaxMaster where Product.PID=Temp_Stock_Company.ProductID and TaxMaster.TaxName=Product.VATCommodity  and Product.ProductName like '" & txtKeyword.Text & "%' order by ProductName"
                    cmd = New SqlCommand(sql, con)
                    cmd.CommandTimeout = 0
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    DataGridView1.Rows.Clear()
                    While (rdr.Read() = True)
                        DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
                    End While
                    con.Close()
                End If
            End If
            If e.KeyCode = Keys.Enter Then
                If cmbFilterBy.SelectedIndex = 1 Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "SELECT (PID),RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock_Company.Barcode),Temp_Stock_Company.SalesRate,TaxMaster.Percentage,RTRIM(Product.SalesUnit),RTRIM(Temp_Stock_Company.ManufacturingDate),RTRIM(Temp_Stock_Company.ExpiryDate),Temp_Stock_Company.Qty,Temp_Stock_Company.PurchaseRate from Product,Temp_Stock_Company,TaxMaster where Product.PID=Temp_Stock_Company.ProductID and TaxMaster.TaxName=Product.VATCommodity  and Product.Category like '" & txtKeyword.Text & "%' order by ProductName"
                    cmd = New SqlCommand(sql, con)
                    cmd.CommandTimeout = 0
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    DataGridView1.Rows.Clear()
                    While (rdr.Read() = True)
                        DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
                    End While
                    con.Close()
                End If
            End If
            If e.KeyCode = Keys.Enter Then
                If cmbFilterBy.SelectedIndex = 2 Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "SELECT (PID),RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock_Company.Barcode),Temp_Stock_Company.SalesRate,TaxMaster.Percentage,RTRIM(Product.SalesUnit),RTRIM(Temp_Stock_Company.ManufacturingDate),RTRIM(Temp_Stock_Company.ExpiryDate),Temp_Stock_Company.Qty,Temp_Stock_Company.PurchaseRate from Product,Temp_Stock_Company,TaxMaster where Product.PID=Temp_Stock_Company.ProductID and TaxMaster.TaxName=Product.VATCommodity  and Product.PID like '" & txtKeyword.Text & "%' order by ProductName"
                    cmd = New SqlCommand(sql, con)
                    cmd.CommandTimeout = 0
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    DataGridView1.Rows.Clear()
                    While (rdr.Read() = True)
                        DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
                    End While
                    con.Close()
                End If
            End If
            If e.KeyCode = Keys.Enter Then
                If cmbFilterBy.SelectedIndex = 3 Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "SELECT (PID),RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock_Company.Barcode),Temp_Stock_Company.SalesRate,TaxMaster.Percentage,RTRIM(Product.SalesUnit),RTRIM(Temp_Stock_Company.ManufacturingDate),RTRIM(Temp_Stock_Company.ExpiryDate),Temp_Stock_Company.Qty,Temp_Stock_Company.PurchaseRate from Product,Temp_Stock_Company,TaxMaster where Product.PID=Temp_Stock_Company.ProductID and TaxMaster.TaxName=Product.VATCommodity  and Temp_Stock_Company.Barcode like '" & txtKeyword.Text & "%' order by ProductName"
                    cmd = New SqlCommand(sql, con)
                    cmd.CommandTimeout = 0
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    DataGridView1.Rows.Clear()
                    While (rdr.Read() = True)
                        DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
                    End While
                    con.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class