Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class frmProductsRecord
    Public Sub Getdata()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select PID, RTRIM(ProductCode), RTRIM(ProductName), RTRIM(Alias),RTRIM(Category), RTRIM(Description),RTRIM(VATCommodity),RTRIM(Barcode), RTRIM(PurchaseUnit),RTRIM(SalesUnit),PurchaseCost,SalesCost, ReorderPoint,AddedDate from Product order by ProductName", con)
            cmd.CommandTimeout = 0
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
    Sub Reset()
        txtProductName.Text = ""
        txtCategory.Text = ""
        txtBarcode.Text = ""
        dgw.Rows.Clear()
    End Sub

    Private Sub dgw_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgw.CellPainting
        If ((e.ColumnIndex = 3) _
           AndAlso (e.RowIndex >= 0)) Then
            e.PaintBackground(e.CellBounds, True)
            TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString, e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor, (TextFormatFlags.RightToLeft Or TextFormatFlags.Right))
            e.Handled = True
        End If
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "Product" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmProduct.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmProduct.txtID.Text = dr.Cells(0).Value.ToString()
                    frmProduct.txtProductCode.Text = dr.Cells(1).Value.ToString()
                    frmProduct.txtProductName.Text = dr.Cells(2).Value.ToString()
                    frmProduct.txtManufacturer.Text = dr.Cells(3).Value.ToString()
                    frmProduct.cmbCategory.Text = dr.Cells(4).Value.ToString()
                    frmProduct.txtDescription.Text = dr.Cells(5).Value.ToString()
                    frmProduct.cmbVAT.Text = dr.Cells(6).Value.ToString()
                    frmProduct.txtBarcode.Text = dr.Cells(7).Value.ToString()
                    frmProduct.txtBCode.Text = dr.Cells(7).Value.ToString()
                    frmProduct.cmbPurchaseUnit.Text = dr.Cells(8).Value.ToString()
                    frmProduct.cmbSalesUnit.Text = dr.Cells(9).Value.ToString()
                    frmProduct.txtPurchaseCost.Text = dr.Cells(10).Value.ToString()
                    frmProduct.txtSalesCost.Text = dr.Cells(11).Value.ToString()
                    frmProduct.txtReorderPoint.Text = dr.Cells(12).Value.ToString()
                    frmProduct.btnUpdate.Enabled = True
                    frmProduct.btnDelete.Enabled = True
                    frmProduct.btnSave.Enabled = False
                    frmProduct.btnAddOS.Enabled = False
                    frmProduct.btnRemoveFromGridOS.Enabled = False
                    frmProduct.txtProductName.Focus()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "SELECT RTRIM(StorageType),RTRIM(Warehouse_Store),Qty,RTRIM(ManufacturingDate),RTRIM(ExpiryDate) from Product,Product_OpeningStock where Product.PID=Product_OpeningStock.ProductID and Product.PID=@d1"
                    cmd = New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@d1", Val(dr.Cells(0).Value))
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmProduct.DataGridView1.Rows.Clear()
                    While (rdr.Read() = True)
                        frmProduct.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4))
                    End While
                    con.Close()
                    frmProduct.lblSet.Text = "Not allowed"
                    lblSet.Text = ""
                End If

                If lblSet.Text = "Product Location" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    Me.Hide()
                    frmProductLocation.Show()
                    ' or simply use column name instead of index
                    'dr.Cells["id"].Value.ToString();
                    frmProductLocation.txtPID.Text = dr.Cells(0).Value.ToString()
                    frmProductLocation.txtProductCode.Text = dr.Cells(1).Value.ToString()
                    frmProductLocation.txtProductName.Text = dr.Cells(2).Value.ToString()
                    lblSet.Text = ""
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

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnShowAll_Click(sender As System.Object, e As System.EventArgs) Handles btnShowAll.Click
        If MessageBox.Show("Do you really want to load all the records?" & vbCrLf & "It will take time to load the records based on no. of records in database.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            Getdata()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub txtProductName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtProductName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select PID, RTRIM(ProductCode), RTRIM(ProductName), RTRIM(Alias),RTRIM(Category), RTRIM(Description),RTRIM(VATCommodity),RTRIM(Barcode), RTRIM(PurchaseUnit),RTRIM(SalesUnit),PurchaseCost,SalesCost, ReorderPoint,AddedDate from Product where ProductName like '" & txtProductName.Text & "%' order by ProductName", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCategory_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCategory.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select PID, RTRIM(ProductCode), RTRIM(ProductName), RTRIM(Alias),RTRIM(Category), RTRIM(Description),RTRIM(VATCommodity),RTRIM(Barcode), RTRIM(PurchaseUnit),RTRIM(SalesUnit),PurchaseCost,SalesCost, ReorderPoint,AddedDate from Product where Category like '" & txtCategory.Text & "%' order by ProductName", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtBarcode_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select PID, RTRIM(ProductCode), RTRIM(ProductName), RTRIM(Alias),RTRIM(Category), RTRIM(Description),RTRIM(VATCommodity),RTRIM(Barcode), RTRIM(PurchaseUnit),RTRIM(SalesUnit),PurchaseCost,SalesCost, ReorderPoint,AddedDate from Product where Barcode like '" & txtBarcode.Text & "%' order by ProductName", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
