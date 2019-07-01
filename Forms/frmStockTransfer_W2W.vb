Imports System.Data.SqlClient
Public Class frmStockTransfer_W2W
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
    Sub Reset()
        dtpDate.Value = Today
        txtSearchByProductName.Text = ""
        txtSearchByBarcode.Text = ""
        cmbWareHouse.SelectedIndex = -1
        dgw.Rows.Clear()
        btnSave.Enabled = True
        btnDelete.Enabled = False
        btnRemove.Enabled = False
        btnAdd.Enabled = True
        lblUnit.Visible = False
        lblQty.Text = ""
        lblSet.Text = ""
        DataGridView1.Rows.Clear()
        Clear()
        auto()
    End Sub

    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 ST_ID FROM StockTransfer_W2W ORDER BY ST_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("ST_ID")
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
            txtTransferID.Text = "ST-W2W-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            If cmbWareHouse.Text = "" Then
                MessageBox.Show("Please select warehouse", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbWareHouse.Focus()
                Exit Sub
            End If
            If dgw.Rows.Count = 0 Then
                MessageBox.Show("sorry no product added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            For Each row As DataGridViewRow In dgw.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim ct As String = "select WareHouse,ProductID,Barcode,ExpiryDate from temp_Stock where Warehouse=@d1 and ProductID=@d2 and Barcode=@d3 and ExpiryDate=@d4"
                cmd = New SqlCommand(ct)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                cmd.Parameters.AddWithValue("@d3", row.Cells(4).Value)
                cmd.Parameters.AddWithValue("@d4", row.Cells(7).Value)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock set Qty=Qty - " & Val(row.Cells(8).Value) & " where Warehouse=@d1 and ProductID=@d2 and Barcode=@d3 and ExpiryDate=@d4"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d4", row.Cells(7).Value)
                    cmd.ExecuteReader()
                    con.Close()
                End If
            Next
            For Each row As DataGridViewRow In dgw.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim ctX As String = "select Barcode,ProductID,ExpiryDate,Warehouse from temp_Stock where Barcode=@d1 and ProductID=@d2 and ExpiryDate=@d3 and Warehouse=@d4"
                cmd = New SqlCommand(ctX)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", row.Cells(4).Value)
                cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                cmd.Parameters.AddWithValue("@d3", row.Cells(7).Value)
                cmd.Parameters.AddWithValue("@d4", cmbWareHouse.Text)
                rdr = cmd.ExecuteReader()
                If (rdr.Read()) Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock set Qty=Qty + " & Val(row.Cells(8).Value) & " where Barcode=@d1 and ProductID=@d2 and ExpiryDate=@d3 and Warehouse=@d4"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(7).Value)
                    cmd.Parameters.AddWithValue("@d4", cmbWareHouse.Text)
                    cmd.ExecuteReader()
                    con.Close()
                Else
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb3 As String = "Insert Into Temp_Stock(ProductID,Barcode,SalesRate,ManufacturingDate,ExpiryDate,Qty,PurchaseRate,Warehouse) VALUES (@d2,@d3,@d6,@d7,@d8,@d9,@d10,@d11)"
                    cmd = New SqlCommand(cb3)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d7", row.Cells(6).Value)
                    cmd.Parameters.AddWithValue("@d8", row.Cells(7).Value)
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d11", cmbWareHouse.Text)
                    cmd.ExecuteReader()
                    con.Close()
                End If
            Next
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into StockTransfer_W2W(ST_ID,TransferID, Date,Warehouse) VALUES (@d1,@d2,@d3,@d4)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Parameters.AddWithValue("@d2", txtTransferID.Text)
            cmd.Parameters.AddWithValue("@d3", dtpDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", cmbWareHouse.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into StockTransfer_Join_W2W(StockTransferID,Warehouse,ProductID,Barcode,SalesRate,ManufacturingDate,ExpiryDate,Qty) VALUES (" & txtID.Text & ",@d1,@d2,@d3,@d6,@d7,@d8,@d9)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In dgw.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d7", row.Cells(6).Value)
                    cmd.Parameters.AddWithValue("@d8", row.Cells(7).Value)
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(8).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            LogFunc(lblUser.Text, "added the new Stock Transfer having Transfer ID '" & txtTransferID.Text & "'")
            MessageBox.Show("Successfully saved", "Stock Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            con.Close()
            Getdata()
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from StockTransfer_W2W where ST_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                For Each row As DataGridViewRow In dgw.Rows
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ct As String = "select WareHouse,ProductID,Barcode,ExpiryDate from temp_Stock where Warehouse=@d1 and ProductID=@d2 and Barcode=@d3 and ExpiryDate=@d4"
                    cmd = New SqlCommand(ct)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d4", row.Cells(7).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty=Qty + " & Val(row.Cells(8).Value) & " where Warehouse=@d1 and ProductID=@d2 and Barcode=@d3 and ExpiryDate=@d4"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(0).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(4).Value)
                        cmd.Parameters.AddWithValue("@d4", row.Cells(7).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                Next
                For Each row As DataGridViewRow In dgw.Rows
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ctX As String = "select Barcode,ProductID,ExpiryDate,Warehouse from temp_Stock where Barcode=@d1 and ProductID=@d2 and ExpiryDate=@d3 and Warehouse=@d4"
                    cmd = New SqlCommand(ctX)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                    cmd.Parameters.AddWithValue("@d3", row.Cells(7).Value)
                    cmd.Parameters.AddWithValue("@d4", cmbWareHouse.Text)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty=Qty - " & Val(row.Cells(8).Value) & " where Barcode=@d1 and ProductID=@d2 and ExpiryDate=@d3 and Warehouse=@d4"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(4).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(1).Value))
                        cmd.Parameters.AddWithValue("@d3", row.Cells(7).Value)
                        cmd.Parameters.AddWithValue("@d4", cmbWareHouse.Text)
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                Next
                LogFunc(lblUser.Text, "Deleted the Stock Transfer having Transfer ID '" & txtTransferID.Text & "'")
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Getdata()
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Reset()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(WareHouse),RTRIM(ProductID),RTRIM(ProductCode),RTRIM(ProductName),RTRIM(PurchaseUnit),RTRIM(Temp_Stock.Barcode),SalesRate,RTRIM(ManufacturingDate),RTRIM(ExpiryDate),Qty,PurchaseRate from Temp_Stock,Product where Temp_Stock.ProductID=Product.PID and Qty > 0 order by ProductName", con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            DataGridView1.Rows.Clear()
            While (rdr.Read() = True)
                DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub frmStore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillWarehouse()
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                txtWarehouse.Text = dr.Cells(0).Value.ToString()
                txtProductID.Text = dr.Cells(1).Value.ToString()
                txtProductCode.Text = dr.Cells(2).Value.ToString()
                txtProductName.Text = dr.Cells(3).Value.ToString()
                lblUnit.Visible = True
                lblUnit.Text = dr.Cells(4).Value.ToString()
                txtBarcode.Text = dr.Cells(5).Value.ToString()
                txtSalesRate.Text = dr.Cells(6).Value.ToString()
                txtManufacturingDate.Text = dr.Cells(7).Value.ToString()
                txtExpiryDate.Text = dr.Cells(8).Value.ToString()
                txtAvailableQty.Text = dr.Cells(9).Value.ToString()
                txtPurchaseRate.Text = dr.Cells(10).Value.ToString()
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
    Sub Clear()
        txtWarehouse.Text = ""
        txtProductName.Text = ""
        txtSalesRate.Text = ""
        txtExpiryDate.Text = ""
        txtProductCode.Text = ""
        txtBarcode.Text = ""
        txtManufacturingDate.Text = ""
        txtTransferQty.Text = ""
        txtAvailableQty.Text = ""
        btnRemove.Enabled = False
        lblUnit.Visible = False
    End Sub

    Private Sub btnRemoveFromGridOS_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Try
            If dgw.Rows.Count > 0 Then
                For Each row As DataGridViewRow In dgw.SelectedRows
                    dgw.Rows.Remove(row)
                Next
                btnRemove.Enabled = False
                Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddOS_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Try
            If txtWarehouse.Text = "" Then
                MessageBox.Show("Please retrieve warehouse", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtWarehouse.Focus()
                Exit Sub
            End If
            If txtTransferQty.Text = "" Then
                MessageBox.Show("Please enter qty", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTransferQty.Focus()
                Exit Sub
            End If
            If Val(txtTransferQty.Text) = 0 Then
                MessageBox.Show("Transferred quantity must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTransferQty.Focus()
                Exit Sub
            End If
            If Val(txtAvailableQty.Text) < Val(txtTransferQty.Text) Then
                MessageBox.Show("Transferred quantity must be less than or equal to available quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTransferQty.Focus()
                Exit Sub
            End If
            If dgw.Rows.Count = 0 Then
                dgw.Rows.Add(txtWarehouse.Text, Val(txtProductID.Text), txtProductCode.Text, txtProductName.Text, txtBarcode.Text, Val(txtSalesRate.Text), txtManufacturingDate.Text, txtExpiryDate.Text, Val(txtTransferQty.Text), Val(txtPurchaseRate.Text))
                Clear()
                Exit Sub
            End If
            For Each row As DataGridViewRow In dgw.Rows
                If txtBarcode.Text = row.Cells(5).Value Then
                    MessageBox.Show("Same barcode already added in grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtBarcode.Focus()
                    Exit Sub
                End If
                If txtWarehouse.Text = row.Cells(0).Value And txtBarcode.Text = row.Cells(4).Value And txtProductID.Text = row.Cells(1).Value Then
                    MessageBox.Show("Record already added in grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtBarcode.Focus()
                    Exit Sub
                End If
            Next
            dgw.Rows.Add(txtWarehouse.Text, Val(txtProductID.Text), txtProductCode.Text, txtProductName.Text, txtBarcode.Text, Val(txtSalesRate.Text), txtManufacturingDate.Text, txtExpiryDate.Text, Val(txtTransferQty.Text), Val(txtPurchaseRate.Text))
            Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtTransferQty_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTransferQty.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtTransferQty.Text
            Dim selectionStart = Me.txtTransferQty.SelectionStart
            Dim selectionLength = Me.txtTransferQty.SelectionLength

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

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        frmStockTransferRecord_W2W.Reset()
        frmStockTransferRecord_W2W.ShowDialog()
    End Sub

    Private Sub dgw_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
        If dgw.Rows.Count > 0 Then
            If lblSet.Text = "Not allowed" Then
                btnRemove.Enabled = False
            Else
                btnRemove.Enabled = True
            End If
        End If
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

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnShowAll_Click(sender As System.Object, e As System.EventArgs) Handles btnShowAll.Click
        If MessageBox.Show("Do you really want to load all the records?" & vbCrLf & "It will take time to load the records based on no. of records in database.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            Getdata()
        End If
    End Sub

    Private Sub txtSearchByProductName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSearchByProductName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT RTRIM(WareHouse),RTRIM(ProductID),RTRIM(ProductCode),RTRIM(ProductName),RTRIM(PurchaseUnit),RTRIM(Temp_Stock.Barcode),SalesRate,RTRIM(ManufacturingDate),RTRIM(ExpiryDate),Qty,PurchaseRate from Temp_Stock,Product where Temp_Stock.ProductID=Product.PID and Qty > 0 and ProductName like '" & txtSearchByProductName.Text & "%' order by ProductName", con)
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

    Private Sub txtSearchByBarcode_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSearchByBarcode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("SELECT RTRIM(WareHouse),RTRIM(ProductID),RTRIM(ProductCode),RTRIM(ProductName),RTRIM(PurchaseUnit),RTRIM(Temp_Stock.Barcode),SalesRate,RTRIM(ManufacturingDate),RTRIM(ExpiryDate),Qty,PurchaseRate from Temp_Stock,Product where Temp_Stock.ProductID=Product.PID and Qty > 0 and Temp_Stock.Barcode like '" & txtSearchByBarcode.Text & "%' order by ProductName", con)
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

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub
End Class
