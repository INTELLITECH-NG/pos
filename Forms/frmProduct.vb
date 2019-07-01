Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Public Class frmProduct
    Dim st As String
    Public Sub Reset()
        txtManufacturer.Text = ""
        txtBarcode.Text = ""
        txtDescription.Text = ""
        txtDiscount.Text = "0.00"
        txtProductName.Text = ""
        txtReorderPoint.Text = ""
        cmbCategory.SelectedIndex = -1
        txtBCode.Text = ""
        cmbSalesUnit.SelectedIndex = -1
        cmbPurchaseUnit.SelectedIndex = -1
        cmbVAT.SelectedIndex = -1
        cmbWareHouse.SelectedIndex = -1
        txtPurchaseCost.Text = "0.00"
        txtSalesCost.Text = "0.00"
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnUpdate.Enabled = False
        btnRemoveFromGridOS.Enabled = False
        DataGridView1.Enabled = True
        btnAddOS.Enabled = True
        DataGridView1.Rows.Clear()
        auto()
        GenerateBarcode()
        txtProductName.Focus()
        Clear()
        lblSet.Text = ""
    End Sub
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 PID FROM Product ORDER BY PID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("PID")
            End If
            rdr.Close()
            ' Increase the ID by 1
            value += 1
            ' Because incrementing a string with an integer removes 0's
            ' we need to replace them. If necessary.
            If value <= 9 Then 'Value is between 0 and 10
                value = "000" & value
            ElseIf value <= 99 Then 'Value is between 9 and 100
                value = "00" & value
            ElseIf value <= 999 Then 'Value is between 999 and 1000
                value = "0" & value
            End If
        Catch ex As Exception
            ' If an error occurs, check the connection state and close it if necessary.
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            value = "0000"
        End Try
        Return value
    End Function
    Sub auto()
        Try
            txtID.Text = GenerateID()
            txtProductCode.Text = "P-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub GenerateBarcode()
        Try
            txtBarcode.Text = 10000000 + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(txtProductName.Text)) = 0 Then
                MessageBox.Show("Please enter Product name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductName.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbCategory.Text)) = 0 Then
                MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbCategory.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbVAT.Text)) = 0 Then
                MessageBox.Show("Please select Tax Commodity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbVAT.Focus()
                Exit Sub
            End If
            If Len(Trim(txtBarcode.Text)) = 0 Then
                MessageBox.Show("Please enter barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBarcode.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbSalesUnit.Text)) = 0 Then
                MessageBox.Show("Please select purchase unit", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbSalesUnit.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbPurchaseUnit.Text)) = 0 Then
                MessageBox.Show("Please select sales unit", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPurchaseUnit.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDiscount.Text)) = 0 Then
                MessageBox.Show("Please enter discount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDiscount.Focus()
                Exit Sub
            End If
            If Len(Trim(txtReorderPoint.Text)) = 0 Then
                MessageBox.Show("Please enter reorder point", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReorderPoint.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select ProductName from product where ProductName=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtProductName.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("Product Name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtProductName.Text = ""
                txtProductName.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "select barcode from product where barcode=@d1"
            cmd = New SqlCommand(ct1)
            cmd.Parameters.AddWithValue("@d1", txtBarcode.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtBarcode.Text = ""
                txtBarcode.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer3.Enabled = True
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Product(PID, ProductCode, ProductName, Alias, VATCommodity, Description, Category, SalesUnit, PurchaseUnit, Barcode, ReorderPoint,AddedDate,PurchaseCost,SalesCost) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d9,@d12,@d13,@d14,@d16,@d17,@d18,@d19)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtProductCode.Text)
            cmd.Parameters.AddWithValue("@d3", txtProductName.Text)
            cmd.Parameters.AddWithValue("@d4", txtManufacturer.Text)
            cmd.Parameters.AddWithValue("@d5", cmbVAT.Text)
            cmd.Parameters.AddWithValue("@d6", txtDescription.Text)
            cmd.Parameters.AddWithValue("@d9", cmbCategory.Text)
            cmd.Parameters.AddWithValue("@d12", cmbSalesUnit.Text)
            cmd.Parameters.AddWithValue("@d13", cmbPurchaseUnit.Text)
            cmd.Parameters.AddWithValue("@d14", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@d16", Val(txtReorderPoint.Text))
            cmd.Parameters.AddWithValue("@d17", System.DateTime.Now)
            cmd.Parameters.AddWithValue("@d18", Val(txtPurchaseCost.Text))
            cmd.Parameters.AddWithValue("@d19", Val(txtSalesCost.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into Product_OpeningStock(ProductID,StorageType,Warehouse_Store,Qty,ManufacturingDate,ExpiryDate) VALUES (" & txtID.Text & " ,@d1,@d2,@d3,@d4,@d5)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(2).Value))
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value.ToString())
                    cmd.Parameters.AddWithValue("@d5", row.Cells(4).Value.ToString())
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "insert into Temp_Stock(ProductID,Warehouse,Qty,ManufacturingDate,ExpiryDate,SalesRate,PurchaseRate,Barcode) VALUES (" & txtID.Text & " ,@d1,@d2,@d3,@d4,@d5,@d6,@d7)"
            cmd = New SqlCommand(cb2)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    If row.Cells(0).Value = "Warehouse" Then
                        cmd.Parameters.AddWithValue("@d1", row.Cells(1).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(2).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value.ToString())
                        cmd.Parameters.AddWithValue("@d4", row.Cells(4).Value.ToString())
                        cmd.Parameters.AddWithValue("@d5", Val(txtSalesCost.Text))
                        cmd.Parameters.AddWithValue("@d6", Val(txtPurchaseCost.Text))
                        cmd.Parameters.AddWithValue("@d7", txtBarcode.Text)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                End If
            Next
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb3 As String = "insert into Temp_Stock_Company(ProductID,Qty,ManufacturingDate,ExpiryDate,SalesRate,PurchaseRate,Barcode) VALUES (" & txtID.Text & " ,@d2,@d3,@d4,@d5,@d6,@d7)"
            cmd = New SqlCommand(cb3)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    If row.Cells(0).Value = "Store" Then
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(2).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(3).Value.ToString())
                        cmd.Parameters.AddWithValue("@d4", row.Cells(4).Value.ToString())
                        cmd.Parameters.AddWithValue("@d5", Val(txtSalesCost.Text))
                        cmd.Parameters.AddWithValue("@d6", Val(txtPurchaseCost.Text))
                        cmd.Parameters.AddWithValue("@d7", txtBarcode.Text)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                End If
            Next
            con.Close()
            Dim st As String = "added the new Product '" & txtProductName.Text & "' having Product code '" & txtProductCode.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillUnit()
        Try
            con = New SqlConnection(cs)
            con.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Unit) FROM UnitMaster order by 1", con)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbPurchaseUnit.Items.Clear()
            cmbSalesUnit.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbPurchaseUnit.Items.Add(drow(0).ToString())
                cmbSalesUnit.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillCategory()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(CategoryName) FROM Category order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbCategory.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbCategory.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillTax()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(TaxName) FROM TaxMaster order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbVAT.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbVAT.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillStore()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Companyname) FROM Company", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbWareHouse.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbWareHouse.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub FillWarehouse()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(WarehouseName) FROM Warehouse order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbWareHouse.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbWareHouse.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cl6 As String = "SELECT PID FROM Product INNER JOIN StockAdjustment_Store ON Product.PID = StockAdjustment_Store.ProductID where PID=@d1"
            cmd = New SqlCommand(cl6)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Stock Adjustment(S)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl7 As String = "SELECT PID FROM Product INNER JOIN StockAdjustment_Warehouse ON Product.PID = StockAdjustment_Warehouse.ProductID where PID=@d1"
            cmd = New SqlCommand(cl7)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Stock Adjustment(W)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl5 As String = "SELECT PID FROM Product INNER JOIN StockTransfer_Join_W2W ON Product.PID = StockTransfer_Join_W2W.ProductID where PID=@d1"
            cmd = New SqlCommand(cl5)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Stock Transfer(W2W) Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl4 As String = "SELECT PID FROM Product INNER JOIN ProductLocation ON Product.PID = ProductLocation.ProductID where PID=@d1"
            cmd = New SqlCommand(cl4)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Products Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl3 As String = "SELECT PID FROM Product INNER JOIN Invoice_Product ON Product.PID = Invoice_Product.ProductID where PID=@d1"
            cmd = New SqlCommand(cl3)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "select PID from Purchase_JOIN,Product where Product.PID=Purchase_Join.ProductID and PID=@d1"
            cmd = New SqlCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Purchase Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl2 As String = "select PID from PurchaseOrder_Join,Product where Product.PID=PurchaseOrder_Join.ProductID and PID=@d1"
            cmd = New SqlCommand(cl2)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Purchase order Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl1 As String = "SELECT PID FROM Product INNER JOIN StockTransfer_Join ON Product.PID = StockTransfer_Join.ProductID where PID=@d1"
            cmd = New SqlCommand(cl1)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Stock Transfer(W2S) Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq2 As String = "delete from Product_OpeningStock where ProductID=" & Val(txtID.Text) & ""
            cmd = New SqlCommand(cq2)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Product where PID=" & txtID.Text & ""
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.Cells(0).Value = "Warehouse" Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb1 As String = "Update Temp_Stock set Qty=Qty- " & row.Cells(2).Value & " where WareHouse=@d1 and Barcode=@d2"
                        cmd = New SqlCommand(cb1)
                        cmd.Connection = con
                        ' Prepare command for repeated execution
                        cmd.Parameters.AddWithValue("@d1", row.Cells(1).Value)
                        cmd.Parameters.AddWithValue("@d2", txtBarcode.Text)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.Cells(0).Value = "Store" Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb1 As String = "Update Temp_Stock_Company set Qty=Qty- " & row.Cells(2).Value & " where Barcode=@d1"
                        cmd = New SqlCommand(cb1)
                        cmd.Connection = con
                        ' Prepare command for repeated execution
                        cmd.Parameters.AddWithValue("@d1", txtBarcode.Text)
                        cmd.ExecuteNonQuery()
                        cmd.Parameters.Clear()
                    End If
                Next
                con.Close()
                Dim st As String = "deleted the Product having Product code '" & txtProductCode.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            Else
                MessageBox.Show("No record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Cursor = Cursors.Default
        Timer2.Enabled = False
    End Sub

    Private Sub btnRemoveFromGridOS_Click(sender As System.Object, e As System.EventArgs)
        Try
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            btnRemoveFromGridOS.Enabled = False
            Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtReorderPoint_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtReorderPoint.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        frmProductsRecord.lblSet.Text = "Product"
        frmProductsRecord.Reset()
        frmProductsRecord.ShowDialog()
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        Try
            If Len(Trim(txtProductName.Text)) = 0 Then
                MessageBox.Show("Please enter Product name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductName.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbCategory.Text)) = 0 Then
                MessageBox.Show("Please select category", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbCategory.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbVAT.Text)) = 0 Then
                MessageBox.Show("Please select Tax Commodity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbVAT.Focus()
                Exit Sub
            End If
            If Len(Trim(txtBarcode.Text)) = 0 Then
                MessageBox.Show("Please enter barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBarcode.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbSalesUnit.Text)) = 0 Then
                MessageBox.Show("Please select purchase unit", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbSalesUnit.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbPurchaseUnit.Text)) = 0 Then
                MessageBox.Show("Please select sales unit", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbPurchaseUnit.Focus()
                Exit Sub
            End If
            If Len(Trim(txtDiscount.Text)) = 0 Then
                MessageBox.Show("Please enter discount", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDiscount.Focus()
                Exit Sub
            End If
            If Len(Trim(txtReorderPoint.Text)) = 0 Then
                MessageBox.Show("Please enter reorder point", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReorderPoint.Focus()
                Exit Sub
            End If
            con.Close()
            Cursor = Cursors.WaitCursor
            Timer3.Enabled = True
            If txtBarcode.Text <> txtBCode.Text Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select barcode from product where barcode=@d1"
                cmd = New SqlCommand(ct)
                cmd.Parameters.AddWithValue("@d1", txtBarcode.Text)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    MessageBox.Show("Barcode Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    txtBarcode.Text = ""
                    txtBarcode.Focus()
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    Return
                End If
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql2 As String = "Update Temp_Stock_company set Barcode=@d2 where Barcode=@d3"
            cmd = New SqlCommand(sql2)
            cmd.Parameters.AddWithValue("@d2", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@d3", txtBCode.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql3 As String = "Update Temp_Stock set Barcode=@d2 where Barcode=@d3"
            cmd = New SqlCommand(sql3)
            cmd.Parameters.AddWithValue("@d2", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@d3", txtBCode.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql4 As String = "Update Purchase_Join set Barcode=@d2 where Barcode=@d3"
            cmd = New SqlCommand(sql4)
            cmd.Parameters.AddWithValue("@d2", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@d3", txtBCode.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql5 As String = "Update Invoice_Product set Barcode=@d2 where Barcode=@d3"
            cmd = New SqlCommand(sql5)
            cmd.Parameters.AddWithValue("@d2", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@d3", txtBCode.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql6 As String = "Update PurchaseReturn_Join set Barcode=@d2 where Barcode=@d3"
            cmd = New SqlCommand(sql6)
            cmd.Parameters.AddWithValue("@d2", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@d3", txtBCode.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql7 As String = "Update Salesreturn_Join set Barcode=@d2 where Barcode=@d3"
            cmd = New SqlCommand(sql7)
            cmd.Parameters.AddWithValue("@d2", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@d3", txtBCode.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql8 As String = "Update StockTransfer_Join_W2W set Barcode=@d2 where Barcode=@d3"
            cmd = New SqlCommand(sql8)
            cmd.Parameters.AddWithValue("@d2", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@d3", txtBCode.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql9 As String = "Update StockTransfer_Join set Barcode=@d2 where Barcode=@d3"
            cmd = New SqlCommand(sql9)
            cmd.Parameters.AddWithValue("@d2", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@d3", txtBCode.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Update Temp_Stock set SalesRate=@d3 where ProductID=@d1 and Barcode=@d2"
            cmd = New SqlCommand(sql)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@d3", Val(txtSalesCost.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql1 As String = "Update Temp_Stock_company set SalesRate=@d3 where ProductID=@d1 and Barcode=@d2"
            cmd = New SqlCommand(sql1)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@d3", Val(txtSalesCost.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim sql10 As String = "Update Temp_Stock_company set PurchaseRate=@d3 where ProductID=@d1 and Barcode=@d2"
            cmd = New SqlCommand(sql10)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@d3", Val(txtPurchaseCost.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
          
            con = New SqlConnection(cs)
            con.Open()
            Dim sql11 As String = "Update Temp_Stock set PurchaseRate=@d3 where ProductID=@d1 and Barcode=@d2"
            cmd = New SqlCommand(sql11)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@d3", Val(txtPurchaseCost.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
       
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update Product set ProductCode=@d2, ProductName=@d3, Alias=@d4, VATCommodity=@d5, Description=@d6, Category=@d9, SalesUnit=@d12, PurchaseUnit=@d13, Barcode=@d14, ReorderPoint=@d16,PurchaseCost=@d18,SalesCost=@d19 where PID=@d1"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtProductCode.Text)
            cmd.Parameters.AddWithValue("@d3", txtProductName.Text)
            cmd.Parameters.AddWithValue("@d4", txtManufacturer.Text)
            cmd.Parameters.AddWithValue("@d5", cmbVAT.Text)
            cmd.Parameters.AddWithValue("@d6", txtDescription.Text)
            cmd.Parameters.AddWithValue("@d9", cmbCategory.Text)
            cmd.Parameters.AddWithValue("@d12", cmbSalesUnit.Text)
            cmd.Parameters.AddWithValue("@d13", cmbPurchaseUnit.Text)
            cmd.Parameters.AddWithValue("@d14", txtBarcode.Text)
            cmd.Parameters.AddWithValue("@d16", Val(txtReorderPoint.Text))
            cmd.Parameters.AddWithValue("@d18", Val(txtPurchaseCost.Text))
            cmd.Parameters.AddWithValue("@d19", Val(txtSalesCost.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "updated the Product '" & txtProductName.Text & "' having Product code '" & txtProductCode.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        Cursor = Cursors.Default
        Timer3.Enabled = False
    End Sub

    Private Sub cmbPurchaseUnit_Format(sender As Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbSalesUnit.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

    Private Sub cmbSalesUnit_Format(sender As Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbPurchaseUnit.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

    Private Sub btnAddOS_Click(sender As System.Object, e As System.EventArgs) Handles btnAddOS.Click
        Try
            If cmbStorageType.Text = "" Then
                MessageBox.Show("Please select storage type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbStorageType.Focus()
                Exit Sub
            End If
            If cmbWareHouse.Text = "" Then
                MessageBox.Show("Please select warehouse/store", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbWareHouse.Focus()
                Exit Sub
            End If
            If txtQty.Text = "" Then
                MessageBox.Show("Please enter qty", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            For Each row As DataGridViewRow In DataGridView1.Rows
                If cmbWareHouse.Text = row.Cells(1).Value Then
                    MessageBox.Show("Record already added in grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Next
            DataGridView1.Rows.Add(cmbStorageType.Text, cmbWareHouse.Text, Val(txtQty.Text), txtManufacturingDate.Text, txtExpiryDate.Text)
                Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRemoveFromGridOS_Click_1(sender As System.Object, e As System.EventArgs) Handles btnRemoveFromGridOS.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                For Each row As DataGridViewRow In DataGridView1.SelectedRows
                    DataGridView1.Rows.Remove(row)
                Next
                btnRemoveFromGridOS.Enabled = False
                Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Clear()
        cmbWareHouse.SelectedIndex = -1
        txtQty.Text = 0
        dtpExpiryDate.Value = Today
        dtpManufacturingDate.Value = Today
        txtManufacturingDate.Text = ""
        txtExpiryDate.Text = ""
        btnRemoveFromGridOS.Enabled = False
        cmbStorageType.SelectedIndex = -1
        cmbWareHouse.Enabled = False
    End Sub

    Private Sub DataGridView1_MouseClick_1(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        If lblSet.Text = "Not allowed" Then
            btnRemoveFromGridOS.Enabled = False
        Else
            btnRemoveFromGridOS.Enabled = True
        End If
    End Sub
    Sub fill()
        FillCategory()
        FillTax()
        FillUnit()
    End Sub
    Private Sub frmProduct_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Fill()
    End Sub

    Private Sub dtpManufacturingDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpManufacturingDate.ValueChanged
        txtManufacturingDate.Text = dtpManufacturingDate.Text
    End Sub

    Private Sub dtpExpiryDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpExpiryDate.ValueChanged
        txtExpiryDate.Text = dtpExpiryDate.Text
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        txtManufacturingDate.Text = ""
        txtExpiryDate.Text = ""
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cmbStorageType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbStorageType.SelectedIndexChanged
        If cmbStorageType.SelectedIndex = 0 Then
            cmbWareHouse.Enabled = True
            FillStore()
        End If
        If cmbStorageType.SelectedIndex = 1 Then
            cmbWareHouse.Enabled = True
            FillWarehouse()
        End If
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        frmExportImportExcel_ProductsRecord.Reset()
        frmExportImportExcel_ProductsRecord.ShowDialog()
    End Sub

    Private Sub txtSalesCost_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSalesCost.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtSalesCost.Text
            Dim selectionStart = Me.txtSalesCost.SelectionStart
            Dim selectionLength = Me.txtSalesCost.SelectionLength

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

    Private Sub txtQty_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtQty.Text
            Dim selectionStart = Me.txtQty.SelectionStart
            Dim selectionLength = Me.txtQty.SelectionLength

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

    Private Sub txtPurchaseCost_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPurchaseCost.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtPurchaseCost.Text
            Dim selectionStart = Me.txtPurchaseCost.SelectionStart
            Dim selectionLength = Me.txtPurchaseCost.SelectionLength

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
End Class
