Imports System.Data.SqlClient
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class frmExportImportExcel_ProductsRecord
    Public Sub Getdata()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select PID, RTRIM(ProductCode), RTRIM(ProductName), RTRIM(Alias),RTRIM(Category), RTRIM(Description),RTRIM(VATCommodity),RTRIM(Product.Barcode), RTRIM(PurchaseUnit),RTRIM(SalesUnit),PurchaseCost,SalesCost, ReorderPoint,RTRIM(StorageType),RTRIM(Warehouse_Store),Qty,RTRIM(ExpiryDate),RTRIM(ManufacturingDate) from Product left Join Product_OpeningStock ON Product.PID=Product_OpeningStock.ProductID order by PID", con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        txtProductName.Text = ""
        txtCategory.Text = ""
        dgw.Rows.Clear()
        DataGridView1.DataSource = Nothing
        DataGridView1.Visible = False
    End Sub

    Private Sub dgw_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgw.CellPainting
        If ((e.ColumnIndex = 3) _
           AndAlso (e.RowIndex >= 0)) Then
            e.PaintBackground(e.CellBounds, True)
            TextRenderer.DrawText(e.Graphics, e.FormattedValue.ToString, e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor, (TextFormatFlags.RightToLeft Or TextFormatFlags.Right))
            e.Handled = True
        End If
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


    Private Sub txtGuestName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtProductName.TextChanged

    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
        frmProduct.Reset()
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub btnImportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnImportExcel.Click
        Try
            Dim OpenFileDialog As New OpenFileDialog
            OpenFileDialog.Filter = "Excel Files | *.xlsx; *.xls;| All Files (*.*)| *.*"
            If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK AndAlso OpenFileDialog.FileName <> "" Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                Dim Pathname As String = OpenFileDialog.FileName
                Dim MyConnection As System.Data.OleDb.OleDbConnection
                Dim DtSet As System.Data.DataSet
                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
                MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Pathname + ";Extended Properties=Excel 8.0;")
                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
                MyConnection.Open()
                DtSet = New System.Data.DataSet
                MyCommand.Fill(DtSet)
                DataGridView1.Visible = True
                DataGridView1.DataSource = DtSet.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
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

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If DataGridView1.RowCount = Nothing Then
                MessageBox.Show("Sorry nothing to save.." & vbCrLf & "Please retrieve data in datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                For j As Integer = i + 1 To Me.DataGridView1.RowCount - 1
                    If DataGridView1.Rows(i).Cells(7).Value.ToString() = DataGridView1.Rows(j).Cells(7).Value.ToString() Then
                        MessageBox.Show("duplicate Barcode value " & DataGridView1.Rows(i).Cells(7).Value, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                Next
            Next

            For Each row As DataGridViewRow In DataGridView1.Rows
                SqlConnection.ClearAllPools()
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select barcode from Product Where Barcode=@d1"
                cmd = New SqlCommand(ct)
                cmd.Parameters.AddWithValue("@d1", row.Cells(7).Value.ToString())
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    MessageBox.Show("Barcode '" & row.Cells(7).Value & "' Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    con.Close()
                    Return
                End If
            Next
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    SqlConnection.ClearAllPools()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select RTRIM(Categoryname) from Category Where CategoryName=@d1"
                    cmd = New SqlCommand(ct)
                    cmd.Parameters.AddWithValue("@d1", row.Cells(4).Value.ToString())
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    If Not rdr.Read() Then
                        Cursor = Cursors.WaitCursor
                        Timer1.Enabled = True
                        SqlConnection.ClearAllPools()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "Insert Into Category(Categoryname) Values(@d1)"
                        cmd = New SqlCommand(cb)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(4).Value.ToString())
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                End If
            Next
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    SqlConnection.ClearAllPools()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select PID from Product Where PID=@d1"
                    cmd = New SqlCommand(ct)
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value.ToString()))
                    cmd.Connection = con
                    rdr = cmd.ExecuteReader()
                    If Not rdr.Read() Then
                        Cursor = Cursors.WaitCursor
                        Timer1.Enabled = True
                        SqlConnection.ClearAllPools()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb As String = "Insert Into Product(PID,ProductCode,ProductName,Alias,Category,Description,VATCommodity,Barcode,PurchaseUnit,SalesUnit,PurchaseCost,SalesCost, ReorderPoint,AddedDate) Values(@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14)"
                        cmd = New SqlCommand(cb)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value.ToString()))
                        cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value.ToString())
                        cmd.Parameters.AddWithValue("@d3", row.Cells(2).Value.ToString())
                        cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value.ToString())
                        cmd.Parameters.AddWithValue("@d5", row.Cells(4).Value.ToString())
                        cmd.Parameters.AddWithValue("@d6", row.Cells(5).Value.ToString())
                        cmd.Parameters.AddWithValue("@d7", row.Cells(6).Value.ToString())
                        cmd.Parameters.AddWithValue("@d8", row.Cells(7).Value.ToString())
                        cmd.Parameters.AddWithValue("@d9", row.Cells(8).Value.ToString())
                        cmd.Parameters.AddWithValue("@d10", row.Cells(9).Value.ToString())
                        cmd.Parameters.AddWithValue("@d11", Val(row.Cells(10).Value.ToString()))
                        cmd.Parameters.AddWithValue("@d12", Val(row.Cells(11).Value.ToString()))
                        cmd.Parameters.AddWithValue("@d13", Val(row.Cells(12).Value.ToString()))
                        cmd.Parameters.AddWithValue("@d14", System.DateTime.Now)
                        cmd.ExecuteReader()
                        con.Close()
                        SqlConnection.ClearAllPools()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb1 As String = "insert into Product_OpeningStock(ProductID,StorageType,Warehouse_Store,Qty,ManufacturingDate,ExpiryDate) VALUES (@d1,@d2,@d3,@d4,@d5,@d6)"
                        cmd = New SqlCommand(cb1)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value.ToString()))
                        cmd.Parameters.AddWithValue("@d2", row.Cells(13).Value.ToString())
                        cmd.Parameters.AddWithValue("@d3", row.Cells(14).Value.ToString())
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(15).Value.ToString()))
                        cmd.Parameters.AddWithValue("@d5", row.Cells(16).Value.ToString())
                        cmd.Parameters.AddWithValue("@d6", row.Cells(17).Value.ToString())
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                End If
            Next
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    If row.Cells(13).Value = "Warehouse" Or row.Cells(13).Value = "warehouse" Then
                        SqlConnection.ClearAllPools()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "insert into Temp_Stock(ProductID,Warehouse,Qty,ManufacturingDate,ExpiryDate,Barcode,PurchaseRate,SalesRate) VALUES (@d1,@d3,@d4,@d5,@d6,@d7,@d8,@d9)"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value.ToString()))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(14).Value.ToString())
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(15).Value.ToString()))
                        cmd.Parameters.AddWithValue("@d5", row.Cells(16).Value.ToString())
                        cmd.Parameters.AddWithValue("@d6", row.Cells(17).Value.ToString())
                        cmd.Parameters.AddWithValue("@d7", row.Cells(7).Value.ToString())
                        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(10).Value.ToString()))
                        cmd.Parameters.AddWithValue("@d9", Val(row.Cells(11).Value.ToString()))
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                    If row.Cells(13).Value = "Store" Or row.Cells(13).Value = "store" Then
                        SqlConnection.ClearAllPools()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb3 As String = "insert into Temp_Stock_Company(ProductID,Qty,ManufacturingDate,ExpiryDate,Barcode,PurchaseRate,SalesRate) VALUES (@d1,@d4,@d5,@d6,@d7,@d8,@d9)"
                        cmd = New SqlCommand(cb3)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value.ToString()))
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(15).Value.ToString()))
                        cmd.Parameters.AddWithValue("@d5", row.Cells(16).Value.ToString())
                        cmd.Parameters.AddWithValue("@d6", row.Cells(17).Value.ToString())
                        cmd.Parameters.AddWithValue("@d7", row.Cells(7).Value.ToString())
                        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(10).Value.ToString()))
                        cmd.Parameters.AddWithValue("@d9", Val(row.Cells(11).Value.ToString()))
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                End If
            Next
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DataGridView1.DataSource = Nothing
            Reset()
        Catch ex As SqlException
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtCategory_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCategory.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select PID, RTRIM(ProductCode), RTRIM(ProductName), RTRIM(Alias),RTRIM(Category), RTRIM(Description),RTRIM(VATCommodity),RTRIM(Product.Barcode), RTRIM(PurchaseUnit),RTRIM(SalesUnit),PurchaseCost,SalesCost, ReorderPoint,RTRIM(StorageType),RTRIM(Warehouse_Store),Qty,RTRIM(ExpiryDate),RTRIM(ManufacturingDate) from Product left Join Product_OpeningStock ON Product.PID=Product_OpeningStock.ProductID where Category like '" & txtCategory.Text & "%' order by PID", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtProductName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtProductName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select PID, RTRIM(ProductCode), RTRIM(ProductName), RTRIM(Alias),RTRIM(Category), RTRIM(Description),RTRIM(VATCommodity),RTRIM(Product.Barcode), RTRIM(PurchaseUnit),RTRIM(SalesUnit),PurchaseCost,SalesCost, ReorderPoint,RTRIM(StorageType),RTRIM(Warehouse_Store),Qty,RTRIM(ExpiryDate),RTRIM(ManufacturingDate) from Product left Join Product_OpeningStock ON Product.PID=Product_OpeningStock.ProductID where ProductName like '" & txtProductName.Text & "%' order by PID", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnShowAll_Click(sender As System.Object, e As System.EventArgs) Handles btnShowAll.Click
        If MessageBox.Show("Do you really want to load all the records?" & vbCrLf & "It will take time to load the records based on no. of records in database.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            Getdata()
        End If
    End Sub
End Class
