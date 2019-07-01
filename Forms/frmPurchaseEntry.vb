Imports System.Data.SqlClient
Imports System.IO

Public Class frmPurchaseEntry
    Dim str As String
    Dim st As String
    Dim OBType As String
    Dim num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11 As Decimal
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 ST_ID FROM Purchase ORDER BY ST_ID DESC", con)
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
            txtST_ID.Text = GenerateID()
            txtInvoiceNo.Text = "ST-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Sub Reset()
        txtAddressLine1.Text = ""
        txtBalance.Text = ""
        txtAddressLine2.Text = ""
        txtContactNo.Text = ""
        txtDiscPer.Text = "0.00"
        txtDisc.Text = "0.00"
        txtVAT.Text = "0.00"
        txtVATAmt.Text = "0.00"
        txtSubTotal.Text = ""
        txtTotal.Text = ""
        txtSupplierID.Text = ""
        txtSupplierName.Text = ""
        txtSup_ID.Text = ""
        txtFreightCharges.Text = "0.00"
        txtGrandTotal.Text = ""
        txtInvoiceNo.Text = ""
        txtOtherCharges.Text = "0.00"
        txtPreviousDue.Text = "0.00"
        txtRemarks.Text = ""
        txtRoundOff.Text = "0.00"
        txtTotalPaid.Text = "0.00"
        cmbPurchaseType.SelectedIndex = 0
        dtpDate.Value = Today
        btnSave.Enabled = True
        btnDelete.Enabled = False
        DataGridView1.Enabled = True
        btnAdd.Enabled = True
        pnlCalc.Enabled = True
        btnRemove.Enabled = False
        lblBalance.Text = "0.00"
        txtReferenceNo1.Text = ""
        txtReferenceNo2.Text = ""
        dtpSupplierInvoiceDate.Value = Today
        txtSupplierInvoiceNo.Text = ""
        txtTotalPaid.ReadOnly = True
        txtTotalPaid.Enabled = False
        DataGridView1.Rows.Clear()
        btnSelection.Enabled = True
        cmbTaxType.Enabled = True
        txtInvoiceNo.ReadOnly = False
        txtInvoiceNo.BackColor = Color.White
        lblSet.Text = ""
        txtBarcode.Focus()
        Clear()
        auto()
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
            CN.Close()
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
            CN.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Clear()
        cmbProductName.Text = ""
        cmbWarehouse.SelectedIndex = -1
        lblUnit.Visible = False
        txtBarcode.Text = ""
        txtManufacturingDate.Text = ""
        txtExpiryDate.Text = ""
        dtpManufacturingDate.Value = Today
        dtpExpiryDate.Value = Today
        txtSalesRate.Text = ""
        txtProductCode.Text = ""
        txtQty.Text = ""
        txtPricePerQty.Text = ""
        txtTotalAmount.Text = ""
        dtpExpiryDate.Value = Today
        cmbStorageType.SelectedIndex = -1
        cmbWarehouse.Enabled = False
        txtBarcode.Focus()
    End Sub

    Sub Compute()
        If cmbTaxType.Text = "Inclusive" Then
            num6 = (Val(txtSubTotal.Text) * Val(txtDiscPer.Text)) / 100
            num6 = Math.Round(num6, 2)
            txtDisc.Text = num6
            num7 = Val(txtSubTotal.Text) - num6
            num8 = num7 - (num7 / (1 + (Val(txtVAT.Text) / 100)))
            num8 = Math.Round(num8, 2)
            txtVATAmt.Text = num8
            num1 = num7 + Val(txtFreightCharges.Text) + Val(txtOtherCharges.Text) + Val(txtPreviousDue.Text)
            num1 = Math.Round(num1, 2)
            txtTotal.Text = num1
            num2 = Math.Round(num1, 1)
            num3 = num2 - num1
            num3 = Math.Round(num3, 2)
            txtRoundOff.Text = num3
            num4 = Val(txtTotal.Text) + Val(txtRoundOff.Text)
            num4 = Math.Round(num4, 2)
            txtGrandTotal.Text = num4
            num5 = Val(txtGrandTotal.Text) - Val(txtTotalPaid.Text)
            num5 = Math.Round(num5, 2)
            txtBalance.Text = num5
        Else
            num6 = (Val(txtSubTotal.Text) * Val(txtDiscPer.Text)) / 100
            num6 = Math.Round(num6, 2)
            txtDisc.Text = num6
            num7 = Val(txtSubTotal.Text) - num6
            num8 = (num7 * Val(txtVAT.Text)) / 100
            num8 = Math.Round(num8, 2)
            txtVATAmt.Text = num8
            num1 = num7 + Val(txtFreightCharges.Text) + Val(txtOtherCharges.Text) + Val(txtPreviousDue.Text) + Val(txtVATAmt.Text)
            num1 = Math.Round(num1, 2)
            txtTotal.Text = num1
            num2 = Math.Round(num1, 1)
            num3 = num2 - num1
            num3 = Math.Round(num3, 2)
            txtRoundOff.Text = num3
            num4 = Val(txtTotal.Text) + Val(txtRoundOff.Text)
            num4 = Math.Round(num4, 2)
            txtGrandTotal.Text = num4
            num5 = Val(txtGrandTotal.Text) - Val(txtTotalPaid.Text)
            num5 = Math.Round(num5, 2)
            txtBalance.Text = num5
        End If
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

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub
    Sub GetPurchaseTaxType()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(PurchaseTax) from Setting"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                cmbTaxType.Text = rdr.GetValue(0)
            Else
                cmbTaxType.SelectedIndex = 1
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub frmPurchase_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillWarehouse()
        GetPurchaseTaxType()
    End Sub

    Private Sub txtPricePerQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPricePerQty.TextChanged
        Calc()
    End Sub
    Sub Calc()
        Dim i As Double = 0
        i = CDbl(Val(txtQty.Text) * Val(txtPricePerQty.Text))
        i = Math.Round(i, 2)
        txtTotalAmount.Text = i
    End Sub

    Private Sub txtQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQty.TextChanged
        Calc()
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

    Private Sub txtPricePerQty_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPricePerQty.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtPricePerQty.Text
            Dim selectionStart = Me.txtPricePerQty.SelectionStart
            Dim selectionLength = Me.txtPricePerQty.SelectionLength

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

    Private Sub txtTotalPayment_TextChanged(sender As System.Object, e As System.EventArgs)
        Compute()
    End Sub

    Private Sub txtTotalPayment_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs)
        If Val(txtTotalPaid.Text) > Val(txtGrandTotal.Text) Then
            MessageBox.Show("Total paid can not be more than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Exit Sub
    End Sub


    Sub GetSupplierBalance()
        Try
            Try
                num1 = 0
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from LedgerBook where PartyID=@d1 group By PartyID"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@d1", txtSupplierID.Text)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If (rdr.Read() = True) Then
                    num1 = rdr.GetValue(0)
                End If
                con.Close()
                lblBalance.Text = num1
                If Val(lblBalance.Text) >= 0 Then
                    str = "CR"
                ElseIf Val(lblBalance.Text < 0) Then
                    str = "DR"
                End If
                txtPreviousDue.Text = num1
                lblBalance.Text = Math.Abs(Val(lblBalance.Text))
                lblBalance.Text = (lblBalance.Text & " " & str).ToString()
                Compute()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub GetSupplierInfo()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "SELECT SupplierID,Name,Address,City,ContactNo from Supplier Where ID=@d1"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", Val(txtSup_ID.Text))
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If (rdr.Read() = True) Then
                txtSupplierID.Text = rdr.GetValue(0)
                txtSupplierName.Text = rdr.GetValue(1)
                txtAddressLine1.Text = rdr.GetValue(2)
                txtAddressLine2.Text = rdr.GetValue(3)
                txtContactNo.Text = rdr.GetValue(4)
            End If
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub GetSupplierBalance1()
        Try
            Try
                num1 = 0
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "SELECT isNULL(Sum(Credit),0)-IsNull(Sum(Debit),0) from LedgerBook where PartyID=@d1 group By PartyID"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@d1", txtSupplierID.Text)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If (rdr.Read() = True) Then
                    num1 = rdr.GetValue(0)
                End If
                con.Close()
                lblBalance.Text = num1
                If Val(lblBalance.Text) >= 0 Then
                    str = "CR"
                ElseIf Val(lblBalance.Text < 0) Then
                    str = "DR"
                End If
                lblBalance.Text = Math.Abs(Val(lblBalance.Text))
                lblBalance.Text = (lblBalance.Text & " " & str).ToString()
                Compute()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub DeleteRecord()
        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "select ST_ID from Purchase,PurchaseReturn where PurchaseReturn.PurchaseID=Purchase.ST_ID and ST_ID=@d1"
            cmd = New SqlCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtST_ID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Purchase Return", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Purchase where ST_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", Val(txtST_ID.Text))
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If row.Cells(11).Value = "Warehouse" Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim ctX As String = "select WareHouse,ProductID,Barcode from temp_Stock where Warehouse=@d1 and ProductID=@d2 and Barcode=@d4"
                        cmd = New SqlCommand(ctX)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(4).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                        rdr = cmd.ExecuteReader()
                        If (rdr.Read()) Then
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cb2 As String = "Update Temp_Stock set Qty=Qty - " & Val(row.Cells(5).Value) & ",SalesRate=" & Val(row.Cells(8).Value) & ",PurchaseRate=" & Val(row.Cells(6).Value) & " where Warehouse=@d1 and ProductID=@d2 and Barcode=@d4"
                            cmd = New SqlCommand(cb2)
                            cmd.Connection = con
                            cmd.Parameters.AddWithValue("@d1", row.Cells(4).Value)
                            cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                            cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value.ToString())
                            cmd.ExecuteReader()
                            con.Close()
                        End If
                    End If
                    If row.Cells(11).Value = "Store" Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim ctX As String = "select ProductID,Barcode from temp_Stock_company where ProductID=@d2 and Barcode=@d4"
                        cmd = New SqlCommand(ctX)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value.ToString())
                        rdr = cmd.ExecuteReader()
                        If (rdr.Read()) Then
                            con = New SqlConnection(cs)
                            con.Open()
                            Dim cb2 As String = "Update Temp_Stock_Company set Qty=Qty - " & Val(row.Cells(5).Value) & ",SalesRate=" & Val(row.Cells(8).Value) & ",PurchaseRate=" & Val(row.Cells(6).Value) & " where ProductID=@d2 and Barcode=@d4"
                            cmd = New SqlCommand(cb2)
                            cmd.Connection = con
                            cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                            cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value.ToString())
                            cmd.ExecuteReader()
                            con.Close()
                        End If
                    End If
                Next
                LedgerDelete(txtInvoiceNo.Text, "Purchase Invoice")
                LogFunc(lblUser.Text, "deleted the purchase record having Invoice No. '" & txtInvoiceNo.Text & "'")
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

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles btnSelection.Click
        frmSupplierRecord.lblSet.Text = "Purchase"
        frmSupplierRecord.Reset()
        frmSupplierRecord.ShowDialog()
    End Sub

    Private Sub txtDiscPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDiscPer.TextChanged
        Compute()
    End Sub

    Private Sub txtSubTotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSubTotal.TextChanged
        Compute()
    End Sub

    Private Sub txtFreightCharges_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFreightCharges.TextChanged
        Compute()
    End Sub

    Private Sub txtOtherCharges_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOtherCharges.TextChanged
        Compute()
    End Sub

    Private Sub txtPreviousDue_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPreviousDue.TextChanged
        Compute()
    End Sub

    Private Sub txtRoundOff_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRoundOff.TextChanged
        Compute()
    End Sub

    Private Sub txtTotalPaid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotalPaid.TextChanged
        Compute()
    End Sub

    'Private Sub cmbPurchaseType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbPurchaseType.SelectedIndexChanged
    '    If cmbPurchaseType.SelectedIndex = 1 Then
    '        txtTotalPaid.Text = "0.00"
    '        txtTotalPaid.ReadOnly = True
    '        txtTotalPaid.Enabled = False
    '    Else
    '        txtTotalPaid.Text = "0.00"
    '        txtTotalPaid.ReadOnly = False
    '        txtTotalPaid.Enabled = True
    '    End If
    'End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnNew_Click(sender As System.Object, e As System.EventArgs) Handles btnNew.Click
        Reset()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtSupplierID.Text)) = 0 Then
            MessageBox.Show("Please retrieve supplier id", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSupplierID.Focus()
            Exit Sub
        End If
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("Sorry no product info added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If Len(Trim(txtDiscPer.Text)) = 0 Then
            MessageBox.Show("Please enter discount %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDiscPer.Focus()
            Exit Sub
        End If
        If Len(Trim(txtFreightCharges.Text)) = 0 Then
            MessageBox.Show("Please enter freight charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFreightCharges.Focus()
            Exit Sub
        End If
        If Len(Trim(txtOtherCharges.Text)) = 0 Then
            MessageBox.Show("Please enter other charges", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOtherCharges.Focus()
            Exit Sub
        End If
        If Len(Trim(txtRoundOff.Text)) = 0 Then
            MessageBox.Show("Please enter round off", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRoundOff.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select InvoiceNo from Purchase where InvoiceNo=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("Invoice No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtInvoiceNo.Text = ""
                txtInvoiceNo.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con.Close()

            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Purchase(ST_ID, InvoiceNo, Date, PurchaseType, Supplier_ID, SubTotal, DiscountPer, Discount, PreviousDue,FreightCharges, OtherCharges, Total, RoundOff, GrandTotal, TotalPayment, PaymentDue, Remarks, VATPer,VAT, SupplierInvoiceNo, SupplierInvoiceDate, ReferenceNo1, ReferenceNo2,TaxType) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d22,@d23,@d24,@d25,@d26)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtST_ID.Text))
            cmd.Parameters.AddWithValue("@d2", txtInvoiceNo.Text)
            cmd.Parameters.AddWithValue("@d3", dtpDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", cmbPurchaseType.Text)
            cmd.Parameters.AddWithValue("@d5", Val(txtSup_ID.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtSubTotal.Text))
            cmd.Parameters.AddWithValue("@d7", Val(txtDiscPer.Text))
            cmd.Parameters.AddWithValue("@d8", Val(txtDisc.Text))
            cmd.Parameters.AddWithValue("@d9", Val(txtPreviousDue.Text))
            cmd.Parameters.AddWithValue("@d10", Val(txtFreightCharges.Text))
            cmd.Parameters.AddWithValue("@d11", Val(txtOtherCharges.Text))
            cmd.Parameters.AddWithValue("@d12", Val(txtTotal.Text))
            cmd.Parameters.AddWithValue("@d13", Val(txtRoundOff.Text))
            cmd.Parameters.AddWithValue("@d14", Val(txtGrandTotal.Text))
            cmd.Parameters.AddWithValue("@d15", Val(txtTotalPaid.Text))
            cmd.Parameters.AddWithValue("@d16", Val(txtBalance.Text))
            cmd.Parameters.AddWithValue("@d17", txtRemarks.Text)
            cmd.Parameters.AddWithValue("@d18", Val(txtVAT.Text))
            cmd.Parameters.AddWithValue("@d19", Val(txtVATAmt.Text))
            cmd.Parameters.AddWithValue("@d22", txtSupplierInvoiceNo.Text)
            cmd.Parameters.AddWithValue("@d23", dtpSupplierInvoiceDate.Value.Date)
            cmd.Parameters.AddWithValue("@d24", txtReferenceNo1.Text)
            cmd.Parameters.AddWithValue("@d25", txtReferenceNo2.Text)
            cmd.Parameters.AddWithValue("@d26", cmbTaxType.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into Purchase_Join( PurchaseID,ProductID,Barcode,Warehouse_store, Qty, Price, TotalAmount, SalesCost, ManufacturingDate,ExpiryDate,StorageType)VALUES (" & txtST_ID.Text & ",@d1,@d2,@d4,@d5,@d6,@d7,@d8,@d10,@d11,@d12)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d2", row.Cells(3).Value)
                    cmd.Parameters.AddWithValue("@d4", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(5).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d10", row.Cells(9).Value)
                    cmd.Parameters.AddWithValue("@d11", row.Cells(10).Value)
                    cmd.Parameters.AddWithValue("@d12", row.Cells(11).Value)
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells(11).Value = "Warehouse" Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ctX As String = "select Warehouse,ProductID,Barcode from temp_Stock where Warehouse=@d1 and ProductID=@d2 and Barcode=@d4"
                    cmd = New SqlCommand(ctX)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock set Qty=Qty + " & Val(row.Cells(5).Value) & ",SalesRate=" & Val(row.Cells(8).Value) & ",PurchaseRate=" & Val(row.Cells(6).Value) & " where Warehouse=@d1 and ProductID=@d2 and Barcode=@d4"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", row.Cells(4).Value)
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()

                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb4 As String = "Update Product set SalesCost=" & Val(row.Cells(8).Value) & ",PurchaseCost=" & Val(row.Cells(6).Value) & " where PID=@d2 and Barcode=@d4"
                        cmd = New SqlCommand(cb4)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    Else
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb3 As String = "Insert Into Temp_Stock(ProductID,Barcode,Warehouse,Qty,SalesRate,ManufacturingDate,ExpiryDate,PurchaseRate) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)"
                        cmd = New SqlCommand(cb3)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d2", row.Cells(3).Value)
                        cmd.Parameters.AddWithValue("@d3", row.Cells(4).Value)
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(5).Value))
                        cmd.Parameters.AddWithValue("@d5", Val(row.Cells(8).Value))
                        cmd.Parameters.AddWithValue("@d6", row.Cells(9).Value)
                        cmd.Parameters.AddWithValue("@d7", row.Cells(10).Value)
                        cmd.Parameters.AddWithValue("@d8", Val(row.Cells(6).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                End If
            Next
            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.Cells(11).Value = "Store" Then
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim ctX As String = "select ProductID,Barcode from temp_Stock_company where ProductID=@d2 and Barcode=@d4"
                    cmd = New SqlCommand(ctX)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                    rdr = cmd.ExecuteReader()
                    If (rdr.Read()) Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb2 As String = "Update Temp_Stock_Company set Qty=Qty + " & Val(row.Cells(5).Value) & ",SalesRate=" & Val(row.Cells(8).Value) & ",PurchaseRate=" & Val(row.Cells(6).Value) & " where ProductID=@d2 and Barcode=@d4"
                        cmd = New SqlCommand(cb2)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb4 As String = "Update Product set SalesCost=" & Val(row.Cells(8).Value) & ",PurchaseCost=" & Val(row.Cells(6).Value) & " where PID=@d2 and Barcode=@d4"
                        cmd = New SqlCommand(cb4)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                        cmd.ExecuteReader()
                        con.Close()
                    Else
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb3 As String = "Insert Into Temp_Stock_Company(ProductID,Barcode,Qty,SalesRate,ManufacturingDate,ExpiryDate,PurchaseRate) values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)"
                        cmd = New SqlCommand(cb3)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d2", row.Cells(3).Value)
                        cmd.Parameters.AddWithValue("@d3", Val(row.Cells(5).Value))
                        cmd.Parameters.AddWithValue("@d4", Val(row.Cells(8).Value))
                        cmd.Parameters.AddWithValue("@d5", row.Cells(9).Value)
                        cmd.Parameters.AddWithValue("@d6", row.Cells(10).Value)
                        cmd.Parameters.AddWithValue("@d7", Val(row.Cells(6).Value))
                        cmd.ExecuteReader()
                        con.Close()
                    End If
                End If
            Next
                LedgerSave(dtpDate.Value.Date, txtSupplierName.Text, txtInvoiceNo.Text, "Purchase Invoice", 0, Val(txtGrandTotal.Text) - Val(txtPreviousDue.Text), txtSupplierID.Text, "Purchase A/c")
                LedgerSave(dtpDate.Value.Date, "Purchase A/c", txtInvoiceNo.Text, "Purchase Invoice", Val(txtGrandTotal.Text) - Val(txtPreviousDue.Text), 0, "", txtSupplierName.Text)
            LogFunc(lblUser.Text, "added the new Purchase having Invoice No. '" & txtInvoiceNo.Text & "'")
            MessageBox.Show("Successfully saved", "Purchase", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillCombo()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            Dim ctn1 As String = "SELECT ProductName FROM Product order by 1"
            cmd = New SqlCommand(ctn1)
            cmd.Connection = con
            cmd.CommandTimeout = 0
            cmbProductName.Items.Clear()
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                cmbProductName.Items.Add(rdr(0).ToString())
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub btnGetData_Click(sender As System.Object, e As System.EventArgs) Handles btnGetData.Click
        Me.Reset()
        frmPurchaseRecord.lblSet.Text = "Purchase"
        frmPurchaseRecord.Reset()
        frmPurchaseRecord.ShowDialog()
    End Sub

    Private Sub cmbProductName_Format(sender As System.Object, e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbProductName.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

    Private Sub cmbProductName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbProductName.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctn1 As String = "select * from Company"
            cmd = New SqlCommand(ctn1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT PID,RTRIM(PurchaseUnit),PurchaseCost,RTRIM(ProductCode),RTRIM(Barcode),SalesCost from Product where ProductName=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbProductName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                lblUnit.Visible = True
                txtProductID.Text = rdr.GetValue(0)
                lblUnit.Text = rdr.GetValue(1).ToString()
                txtPricePerQty.Text = rdr.GetValue(2)
                txtProductCode.Text = rdr.GetValue(3).ToString()
                txtBarcode.Text = rdr.GetValue(4).ToString()
                txtSalesRate.Text = rdr.GetValue(5)
                cmbStorageType.SelectedIndex = 0
                cmbWarehouse.SelectedIndex = 0
                txtQty.Focus()
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbProductName.Text = "" Then
                MessageBox.Show("Please select product name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbProductName.Focus()
                Exit Sub
            End If
            If txtBarcode.Text = "" Then
                MessageBox.Show("Please Enter Barcode", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtBarcode.Focus()
                Exit Sub
            End If
            If cmbStorageType.Text = "" Then
                MessageBox.Show("Please select storage type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbStorageType.Focus()
                Exit Sub
            End If
            If cmbWarehouse.Text = "" Then
                MessageBox.Show("Please select warehouse/store", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbWarehouse.Focus()
                Exit Sub
            End If

            If txtQty.Text = "" Then
                MessageBox.Show("Please enter quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If Val(txtQty.Text = 0) Then
                MessageBox.Show("Quantity can not be zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
                Exit Sub
            End If
            If txtPricePerQty.Text = "" Then
                MessageBox.Show("Please enter price per unit", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPricePerQty.Focus()
                Exit Sub
            End If
            If txtSalesRate.Text = "" Then
                MessageBox.Show("Please enter sales rate", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSalesRate.Focus()
                Exit Sub
            End If
            If DataGridView1.Rows.Count = 0 Then
                DataGridView1.Rows.Add(Val(txtProductID.Text), txtProductCode.Text, cmbProductName.Text, txtBarcode.Text, cmbWarehouse.Text, Val(txtQty.Text), Val(txtPricePerQty.Text), Val(txtTotalAmount.Text), Val(txtSalesRate.Text), txtManufacturingDate.Text, txtExpiryDate.Text, cmbStorageType.Text)
                Dim k As Double = 0
                k = SubTotal()
                k = Math.Round(k, 2)
                txtSubTotal.Text = k
                Clear()
                Exit Sub
            End If
            If cmbStorageType.Text = "Warehouse" Then
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If cmbWarehouse.Text = row.Cells(4).Value And txtBarcode.Text = row.Cells(3).Value And txtProductID.Text = row.Cells(0).Value Then
                        MessageBox.Show("Record already added in grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtBarcode.Focus()
                        Exit Sub
                    End If
                Next
            End If
            If cmbStorageType.Text = "Store" Then
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If txtBarcode.Text = row.Cells(3).Value And txtProductID.Text = row.Cells(0).Value Then
                        MessageBox.Show("Record already added in grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtBarcode.Focus()
                        Exit Sub
                    End If
                Next
            End If
            DataGridView1.Rows.Add(Val(txtProductID.Text), txtProductCode.Text, cmbProductName.Text, txtBarcode.Text, cmbWarehouse.Text, Val(txtQty.Text), Val(txtPricePerQty.Text), Val(txtTotalAmount.Text), Val(txtSalesRate.Text), txtManufacturingDate.Text, txtExpiryDate.Text, cmbStorageType.Text)
            Dim k1 As Double = 0
            k1 = SubTotal()
            k1 = Math.Round(k1, 2)
            txtSubTotal.Text = k1
            Clear()
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

    Private Sub txtDiscPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscPer.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtDiscPer.Text
            Dim selectionStart = Me.txtDiscPer.SelectionStart
            Dim selectionLength = Me.txtDiscPer.SelectionLength

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

    Private Sub txtTotalPaid_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotalPaid.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtTotalPaid.Text
            Dim selectionStart = Me.txtTotalPaid.SelectionStart
            Dim selectionLength = Me.txtTotalPaid.SelectionLength

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

    Private Sub dtpManufacturingDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpManufacturingDate.ValueChanged
        txtManufacturingDate.Text = dtpManufacturingDate.Text
    End Sub

    Private Sub dtpExpiryDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpExpiryDate.ValueChanged
        txtExpiryDate.Text = dtpExpiryDate.Text
    End Sub

    Private Sub txtVatPer_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtVAT.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtVAT.Text
            Dim selectionStart = Me.txtVAT.SelectionStart
            Dim selectionLength = Me.txtVAT.SelectionLength

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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        txtManufacturingDate.Text = ""
        txtExpiryDate.Text = ""
    End Sub

    Private Sub txtVatPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVAT.TextChanged
        Compute()
    End Sub

    Private Sub txtAddVatPer_TextChanged(sender As System.Object, e As System.EventArgs)
        Compute()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub cmbTaxType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbTaxType.SelectedIndexChanged
        Calc()
        Compute()
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

    Private Sub txtBarcode_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                Dim ctn1 As String = "select * from Company"
                cmd = New SqlCommand(ctn1)
                cmd.Connection = con
                rdr = cmd.ExecuteReader()
                If Not rdr.Read() Then
                    MessageBox.Show("Add company profile first in master entry", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    Return
                End If
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT PID,RTRIM(PurchaseUnit),PurchaseCost,RTRIM(ProductCode),RTRIM(ProductName),SalesCost from Product where Barcode=@d1"
                cmd.Parameters.AddWithValue("@d1", txtBarcode.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    lblUnit.Visible = True
                    txtProductID.Text = rdr.GetValue(0)
                    lblUnit.Text = rdr.GetValue(1).ToString()
                    txtPricePerQty.Text = rdr.GetValue(2)
                    txtProductCode.Text = rdr.GetValue(3).ToString()
                    cmbProductName.Text = rdr.GetValue(4).ToString()
                    txtSalesRate.Text = rdr.GetValue(5)
                    cmbStorageType.SelectedIndex = 0
                    cmbWarehouse.SelectedIndex = 0
                    txtQty.Focus()
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnScanBarcode_Click(sender As System.Object, e As System.EventArgs) Handles btnScanBarcode.Click
        txtBarcode.Focus()
    End Sub

    Private Sub btnClear_Click(sender As System.Object, e As System.EventArgs) Handles btnClear.Click
        Clear()
    End Sub

    Private Sub btnLoadProducts_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadProducts.Click
        If MessageBox.Show("Do you really want to load all the products?" & vbCrLf & "It will take time to load the records based on no. of records in database.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            fillCombo()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub
End Class
