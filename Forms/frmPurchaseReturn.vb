Imports System.Data.SqlClient
Imports System.IO

Public Class frmPurchaseReturn
    Dim str As String
    Dim st As String
    Dim num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11 As Decimal
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 PR_ID FROM PurchaseReturn ORDER BY PR_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("PR_ID")
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
    Sub Reset()
        txtPRNO.Text = ""
        txtPRID.Text = ""
        dtpPRDate.Value = Today
        txtPurchaseDate.Value = Today
        txtPurchaseID.Text = ""
        txtPurchaseInvoiceNo.Text = ""
        txtDiscPer.Text = "0.00"
        txtDisc.Text = "0.00"
        txtVatPer.Text = "0.00"
        txtVATAmt.Text = "0.00"
        txtSubTotal.Text = ""
        txtTotal.Text = ""
        txtSupplierID.Text = ""
        txtSupplierName.Text = ""
        txtSup_ID.Text = ""
        txtGrandTotal.Text = ""
        txtRoundOff.Text = "0.00"
        btnSave.Enabled = True
        btnDelete.Enabled = False
        DataGridView1.Enabled = True
        btnAdd.Enabled = True
        pnlCalc.Enabled = True
        btnRemove.Enabled = False
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
        Clear()
        btnSelection.Enabled = True
        txtPRNO.ReadOnly = False
        txtPRNO.BackColor = Color.White
        lblSet.Text = ""
        Clear()
        auto()
        btnDebitNote.Enabled = False
        txtTaxType.Text = ""
        cmbPurchaseType.Text = ""
    End Sub
    Sub Compute()
        If txtTaxType.Text = "Inclusive" Then
            num6 = (Val(txtSubTotal.Text) * Val(txtDiscPer.Text)) / 100
            num6 = Math.Round(num6, 2)
            txtDisc.Text = num6
            num7 = Val(txtSubTotal.Text) - num6
            num8 = num7 - (num7 / (1 + (Val(txtVatPer.Text) / 100)))
            num8 = Math.Round(num8, 2)
            txtVATAmt.Text = num8
            num1 = num7 + Val(txtFreightCharges.Text) + Val(txtOtherCharges.Text)
            num1 = Math.Round(num1, 2)
            txtTotal.Text = num1
            num2 = Math.Round(num1, 1)
            num3 = num2 - num1
            num3 = Math.Round(num3, 2)
            txtRoundOff.Text = num3
            num4 = Val(txtTotal.Text) + Val(txtRoundOff.Text)
            num4 = Math.Round(num4, 2)
            txtGrandTotal.Text = num4
        Else
            num6 = (Val(txtSubTotal.Text) * Val(txtDiscPer.Text)) / 100
            num6 = Math.Round(num6, 2)
            txtDisc.Text = num6
            num7 = Val(txtSubTotal.Text) - num6
            num8 = (num7 * Val(txtVatPer.Text)) / 100
            num8 = Math.Round(num8, 2)
            txtVATAmt.Text = num8
            num1 = num7 + Val(txtVATAmt.Text) + Val(txtFreightCharges.Text) + Val(txtOtherCharges.Text)
            num1 = Math.Round(num1, 2)
            txtTotal.Text = num1

            num2 = Math.Round(num1, 1)
            num3 = num2 - num1
            num3 = Math.Round(num3, 2)
            txtRoundOff.Text = num3
            num4 = Val(txtTotal.Text) + Val(txtRoundOff.Text)
            num4 = Math.Round(num4, 2)
            txtGrandTotal.Text = num4
        End If
    End Sub

    Sub auto()
        Try
            txtPRID.Text = GenerateID()
            txtPRNO.Text = "PR-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnSelection_Click(sender As System.Object, e As System.EventArgs) Handles btnSelection.Click
        frmPurchaseRecord.lblSet.Text = "PR"
        frmPurchaseRecord.Reset()
        frmPurchaseRecord.ShowDialog()
    End Sub
    Private Sub DataGridView2_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        Try
            If DataGridView2.Rows.Count > 0 Then
                Clear()
                Dim dr As DataGridViewRow = DataGridView2.SelectedRows(0)
                txtProductID.Text = dr.Cells(0).Value.ToString()
                txtProductCode.Text = dr.Cells(1).Value.ToString()
                txtProductName.Text = dr.Cells(2).Value.ToString()
                txtBarcode.Text = dr.Cells(3).Value.ToString()
                txtwareHouse.Text = dr.Cells(4).Value.ToString()
                txtQty.Text = dr.Cells(5).Value.ToString()
                txtPricePerQty.Text = dr.Cells(6).Value.ToString()
                txtSalesRate.Text = dr.Cells(8).Value.ToString()
                txtManufacturingDate.Text = dr.Cells(9).Value.ToString()
                txtExpiryDate.Text = dr.Cells(10).Value.ToString()
                txtStorageType.Text = dr.Cells(11).Value.ToString()
                txtReturnQty.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Function SubTotal() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(7).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Sub Clear()
        txtProductName.Text = ""
        txtwareHouse.Text = ""
        lblUnit.Visible = False
        txtBarcode.Text = ""
        txtManufacturingDate.Text = ""
        txtExpiryDate.Text = ""
        txtManufacturingDate.Text = ""
        txtExpiryDate.Text = ""
        txtSalesRate.Text = ""
        txtProductCode.Text = ""
        txtQty.Text = ""
        txtPricePerQty.Text = ""
        txtTotalAmount.Text = ""
        txtReturnQty.Text = ""
    End Sub
    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Try
            If txtProductName.Text = "" Then
                MessageBox.Show("Please retrieve product name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtProductName.Focus()
                Exit Sub
            End If
            If txtBarcode.Text = "" Then
                MessageBox.Show("Please retrieve Barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBarcode.Focus()
                Exit Sub
            End If
            If txtwareHouse.Text = "" Then
                MessageBox.Show("Please retrieve warehouse", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtwareHouse.Focus()
                Exit Sub
            End If
            If txtQty.Text = "" Then
                MessageBox.Show("Please retrieve quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If txtPricePerQty.Text = "" Then
                MessageBox.Show("Please retrieve price per unit", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPricePerQty.Focus()
                Exit Sub
            End If
            If txtSalesRate.Text = "" Then
                MessageBox.Show("Please enter sales rate", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSalesRate.Focus()
                Exit Sub
            End If
            If txtReturnQty.Text = "" Then
                MessageBox.Show("Please Enter Return Quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReturnQty.Focus()
                Exit Sub
            End If
            If Val(txtReturnQty.Text) = 0 Then
                MessageBox.Show("Return quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReturnQty.Focus()
                Exit Sub
            End If
            If Val(txtReturnQty.Text) > Val(txtQty.Text) Then
                MessageBox.Show("Return Quantity can not be greater than purchased quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReturnQty.Text = ""
                txtReturnQty.Focus()
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 Then
                DataGridView1.Rows.Add(Val(txtProductID.Text), txtProductCode.Text, txtProductName.Text, txtBarcode.Text, txtwareHouse.Text, Val(txtQty.Text), Val(txtPricePerQty.Text), Val(txtTotalAmount.Text), Val(txtSalesRate.Text), txtManufacturingDate.Text, txtExpiryDate.Text, txtReturnQty.Text, txtStorageType.Text)
                Dim k As Double = 0
                k = SubTotal()
                k = Math.Round(k, 2)
                txtSubTotal.Text = k
                Clear()
                Exit Sub
            End If
            If txtStorageType.Text = "Store" Then
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If txtBarcode.Text = row.Cells(3).Value And txtProductID.Text = row.Cells(0).Value Then
                        MessageBox.Show("Record already added in grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtBarcode.Focus()
                        Exit Sub
                    End If
                Next
            End If
            If txtStorageType.Text = "Warehouse" Then
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If txtwareHouse.Text = row.Cells(4).Value And txtBarcode.Text = row.Cells(3).Value And txtProductID.Text = row.Cells(0).Value Then
                        MessageBox.Show("Record already added in grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtBarcode.Focus()
                        Exit Sub
                    End If
                Next
            End If
            DataGridView1.Rows.Add(Val(txtProductID.Text), txtProductCode.Text, txtProductName.Text, txtBarcode.Text, txtwareHouse.Text, Val(txtQty.Text), Val(txtPricePerQty.Text), Val(txtTotalAmount.Text), Val(txtSalesRate.Text), txtManufacturingDate.Text, txtExpiryDate.Text, txtReturnQty.Text, txtStorageType.Text)
            Dim k1 As Double = 0
            k1 = SubTotal()
            k1 = Math.Round(k1, 2)
            txtSubTotal.Text = k1
            Clear()
            Compute()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Try
            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = SubTotal()
            k = Math.Round(k, 2)
            txtSubTotal.Text = k
            Compute()
            btnRemove.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtAddVATAmt_TextChanged(sender As System.Object, e As System.EventArgs)
        Compute()
    End Sub

    Private Sub txtAddVatPer_TextChanged(sender As System.Object, e As System.EventArgs)
        Compute()
    End Sub

    Private Sub txtVATAmt_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVATAmt.TextChanged
        Compute()
    End Sub

    Private Sub txtVatPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVatPer.TextChanged
        Compute()
    End Sub

    Private Sub txtDisc_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDisc.TextChanged
        Compute()
    End Sub

    Private Sub txtDiscPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDiscPer.TextChanged
        Compute()
    End Sub

    Private Sub txtSubTotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubTotal.TextChanged
        Compute()
    End Sub

    Private Sub txtTotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotal.TextChanged
        Compute()
    End Sub

    Private Sub txtRoundOff_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRoundOff.TextChanged
        Compute()
    End Sub

    Private Sub txtRetuenQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtReturnQty.TextChanged
        Dim i As Double = 0
        i = CDbl(Val(txtReturnQty.Text) * Val(txtPricePerQty.Text))
        i = Math.Round(i, 2)
        txtTotalAmount.Text = i
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(txtPurchaseInvoiceNo.Text)) = 0 Then
                MessageBox.Show("Please retrieve Purchase Info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPurchaseInvoiceNo.Focus()
                Exit Sub
            End If
            If Len(Trim(txtSupplierID.Text)) = 0 Then
                MessageBox.Show("Please retrieve supplier id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSupplierID.Focus()
                Exit Sub
            End If

            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("Sorry no returned product info added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            If Len(Trim(txtDiscPer.Text)) = 0 Then
                MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDiscPer.Focus()
                Exit Sub
            End If
            If Len(Trim(txtRoundOff.Text)) = 0 Then
                MessageBox.Show("Please enter round off", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtRoundOff.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "select PRNO from PurchaseReturn where PRNo=@d1"
            cmd = New SqlCommand(ct1)
            cmd.Parameters.AddWithValue("@d1", txtPRNO.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("PR No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtPRNO.Text = ""
                txtPRNO.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con.Close()
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into  PurchaseReturn(PR_ID, PRNo, Date,PurchaseID, SubTotal, DiscPer, Discount, VATPer, VATAmt, Total, RoundOff, GrandTotal,FreightCharges,OtherCharges) VALUES (@d1,@d2,@d3,@d5,@d6,@d7,@d8,@d9,@d10,@d13,@d14,@d15,@d16,@d17)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtPRID.Text))
            cmd.Parameters.AddWithValue("@d2", txtPRNO.Text)
            cmd.Parameters.AddWithValue("@d3", dtpPRDate.Value.Date)
            cmd.Parameters.AddWithValue("@d5", Val(txtPurchaseID.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtSubTotal.Text))
            cmd.Parameters.AddWithValue("@d7", Val(txtDiscPer.Text))
            cmd.Parameters.AddWithValue("@d8", Val(txtDisc.Text))
            cmd.Parameters.AddWithValue("@d9", Val(txtVatPer.Text))
            cmd.Parameters.AddWithValue("@d10", Val(txtVATAmt.Text))
            cmd.Parameters.AddWithValue("@d13", Val(txtTotal.Text))
            cmd.Parameters.AddWithValue("@d14", Val(txtRoundOff.Text))
            cmd.Parameters.AddWithValue("@d15", Val(txtGrandTotal.Text))
            cmd.Parameters.AddWithValue("@d16", Val(txtFreightCharges.Text))
            cmd.Parameters.AddWithValue("@d17", Val(txtOtherCharges.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into PurchaseReturn_Join(PurchaseReturnID,ProductID,Barcode,Warehouse_Store, Qty, Price, TotalAmount, SalesCost, ExpiryDate, ManufacturingDate,ReturnQty,StorageType)VALUES (" & txtPRID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d2", row.Cells(3).Value)
                    cmd.Parameters.AddWithValue("@d3", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d4", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d8", row.Cells(9).Value)
                    cmd.Parameters.AddWithValue("@d9", row.Cells(10).Value)
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(11).Value))
                    cmd.Parameters.AddWithValue("@d11", row.Cells(12).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells(12).Value = "Warehouse" Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock set Qty=Qty - " & Val(row.Cells(11).Value) & " where Warehouse=@d1 and ProductID=@d2 and Barcode=@d4"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                    cmd.ExecuteReader()
                    con.Close()
                End If
                If row.Cells(12).Value = "Store" Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock_Company set Qty=Qty - " & Val(row.Cells(11).Value) & " where ProductID=@d2 and Barcode=@d4"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                    cmd.ExecuteReader()
                    con.Close()
                End If
            Next
                LedgerSave(dtpPRDate.Value.Date, txtSupplierName.Text, txtPRNO.Text, "Debit Note", Val(txtGrandTotal.Text), 0, txtSupplierID.Text, "Purchase Return A/c")
                LedgerSave(dtpPRDate.Value.Date, "Purchase Return A/c", txtPRNO.Text, "Debit Note", 0, Val(txtGrandTotal.Text), "", txtSupplierName.Text)
            LogFunc(lblUser.Text, "added the new Purchase return record having PR No. '" & txtPRNO.Text & "'")
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            btnDebitNote.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
    Private Sub DeleteRecord()

        Try
           
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from PurchaseReturn where PR_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtPRID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.Cells(12).Value = "Warehouse" Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty=Qty + " & Val(row.Cells(11).Value) & " where Warehouse=@d1 and ProductID=@d2 and Barcode=@d4"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(4).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                    If row.Cells(12).Value = "Store" Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock_Company set Qty=Qty + " & Val(row.Cells(11).Value) & " where ProductID=@d2 and Barcode=@d4"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                Next
                LedgerDelete(txtPRNO.Text, "Debit Note")
                Dim st As String = "deleted the Purchase Return record having PR No. '" & txtPRNO.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
    Private Sub txtReturnQty_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtReturnQty.KeyPress
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

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If MessageBox.Show("Do you really want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                DeleteRecord()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()

    End Sub

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Me.Reset()
        frmPurchaseReturnRecord.lblSet.Text = "PR"
        frmPurchaseReturnRecord.Reset()
        frmPurchaseReturnRecord.ShowDialog()
    End Sub

    Private Sub DataGridView1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        If DataGridView1.Rows.Count > 0 Then
            If lblSet.Text = "Not allowed" Then
                btnRemove.Enabled = False
            Else
                btnRemove.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub txtFreightCharges_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFreightCharges.TextChanged
        Compute()
    End Sub

    Private Sub txtOtherCharges_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOtherCharges.TextChanged
        Compute()
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

    Private Sub DataGridView2_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView2.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView2.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView2.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub txtFreightCharges_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtFreightCharges.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtFreightCharges.Text
            Dim selectionStart = Me.txtFreightCharges.SelectionStart
            Dim selectionLength = Me.txtFreightCharges.SelectionLength

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

    Private Sub txtOtherCharges_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtherCharges.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtOtherCharges.Text
            Dim selectionStart = Me.txtOtherCharges.SelectionStart
            Dim selectionLength = Me.txtOtherCharges.SelectionLength

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

    Private Sub btnDebitNote_Click(sender As System.Object, e As System.EventArgs) Handles btnDebitNote.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT PurchaseReturn.PR_ID, PurchaseReturn.PRNo, PurchaseReturn.Date, PurchaseReturn.PurchaseID, PurchaseReturn.SubTotal, PurchaseReturn.DiscPer, PurchaseReturn.Discount, PurchaseReturn.VATPer,PurchaseReturn.VATAmt, PurchaseReturn.FreightCharges, PurchaseReturn.OtherCharges, PurchaseReturn.Total, PurchaseReturn.RoundOff, PurchaseReturn.GrandTotal, PurchaseReturn_Join.PRJ_ID,PurchaseReturn_Join.PurchaseReturnID, PurchaseReturn_Join.ProductID, PurchaseReturn_Join.Qty, PurchaseReturn_Join.Price, PurchaseReturn_Join.TotalAmount, PurchaseReturn_Join.Warehouse_Store,PurchaseReturn_Join.SalesCost, PurchaseReturn_Join.Barcode, PurchaseReturn_Join.ExpiryDate, PurchaseReturn_Join.ManufacturingDate, PurchaseReturn_Join.ReturnQty, PurchaseReturn_Join.StorageType,Purchase.ST_ID, Purchase.InvoiceNo, Purchase.Date AS Expr1, Purchase.PurchaseType, Purchase.Supplier_ID, Purchase.SubTotal AS Expr2, Purchase.DiscountPer, Purchase.Discount AS Expr3, Purchase.PreviousDue,Purchase.FreightCharges AS Expr4, Purchase.OtherCharges AS Expr5, Purchase.Total AS Expr6, Purchase.RoundOff AS Expr7, Purchase.GrandTotal AS Expr8, Purchase.TotalPayment, Purchase.PaymentDue,Purchase.Remarks, Purchase.VATPer AS Expr9, Purchase.VAT, Purchase.ReferenceNo1, Purchase.ReferenceNo2, Purchase.SupplierInvoiceNo, Purchase.SupplierInvoiceDate, Purchase.TaxType, Product.PID,Product.ProductCode, Product.ProductName, Product.Alias, Product.VATCommodity, Product.Description, Product.Barcode AS Expr10, Product.Category, Product.PurchaseUnit, Product.SalesUnit, Product.PurchaseCost,Product.SalesCost AS Expr11, Product.ReorderPoint, Product.AddedDate, Supplier.ID, Supplier.SupplierID, Supplier.Name, Supplier.Address, Supplier.City, Supplier.State, Supplier.ZipCode, Supplier.ContactNo, Supplier.EmailID, Supplier.Remarks AS Expr12, Supplier.TIN, Supplier.STNo, Supplier.CST, Supplier.PAN, Supplier.AccountName, Supplier.AccountNumber, Supplier.Bank, Supplier.Branch, Supplier.IFSCCode, Supplier.OpeningBalance,Supplier.OpeningBalanceType FROM PurchaseReturn INNER JOIN PurchaseReturn_Join ON PurchaseReturn.PR_ID = PurchaseReturn_Join.PurchaseReturnID INNER JOIN Purchase ON PurchaseReturn.PurchaseID = Purchase.ST_ID INNER JOIN Product ON PurchaseReturn_Join.PurchaseReturnID = Product.PID INNER JOIN Supplier ON Purchase.Supplier_ID = Supplier.ID where PR_ID=@d1", con)
            cmd.Parameters.AddWithValue("@d1", Val(txtPRID.Text))
            adp = New SqlDataAdapter(cmd)
            cmd1 = New SqlCommand("SELECT * from Company", con)
            adp1 = New SqlDataAdapter(cmd1)
            dtable = New DataTable()
            dtable1 = New DataTable()
            adp.Fill(dtable)
            adp1.Fill(dtable1)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.Tables.Add(dtable1)
            ds.WriteXmlSchema("DebitNote.xml")
            Dim rpt As New rptDebitNote
            rpt.SetDataSource(ds)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
