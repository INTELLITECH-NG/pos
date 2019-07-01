Imports System.Data.SqlClient
Imports System.IO

Public Class frmSalesReturn
    Dim str As String
    Dim st As String
    Dim num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11, a As Decimal
    Sub Calc()
        If txtTaxType.Text = "Inclusive" Then
            num1 = CDbl(Val(txtReturnQty.Text) * Val(txtSalesRate.Text))
            num1 = Math.Round(num1, 2)
            num2 = (num1 * Val(txtDiscountPer.Text)) / 100
            num2 = Math.Round(num2, 2)
            txtDiscountAmount.Text = num2
            num3 = Val(num1) - Val(txtDiscountAmount.Text)
            num4 = num3 - (num3 / (1 + (Val(txtVATPer.Text) / 100)))
            num4 = Math.Round(num4, 2)
            txtVATAmt.Text = num4
            num6 = CDbl(Val(num1) - Val(txtDiscountAmount.Text))
            num6 = Math.Round(num6, 2)
            txtTotalAmount.Text = num6
            GridCalc()
        Else
            num1 = CDbl(Val(txtReturnQty.Text) * Val(txtSalesRate.Text))
            num1 = Math.Round(num1, 2)
            num2 = CDbl((Val(num1) * Val(txtDiscountPer.Text)) / 100)
            num2 = Math.Round(num2, 2)
            txtDiscountAmount.Text = num2
            num3 = Val(num1) - Val(txtDiscountAmount.Text)
            num4 = CDbl((Val(txtVATPer.Text) * Val(num3)) / 100)
            num4 = Math.Round(num4, 2)
            txtVATAmt.Text = num4
            num6 = CDbl(Val(num1) + Val(txtVATAmt.Text) - Val(txtDiscountAmount.Text))
            num6 = Math.Round(num6, 2)
            txtTotalAmount.Text = num6
            GridCalc()
        End If
    End Sub
    Sub Compute()
        If txtTaxType.Text = "Inclusive" Then
            txtGrandTotal.Text = txtSubTotal.Text
        Else
            txtGrandTotal.Text = Val(txtSubTotal.Text) + Val(txtVAT.Text)
        End If
    End Sub
    Sub GridCalc()
        Dim VAT As Decimal = 0
        For Each r As DataGridViewRow In Me.DataGridView2.Rows
            VAT = VAT + r.Cells(12).Value
        Next
        VAT = Math.Round(VAT, 2)
        txtVAT.Text = VAT
    End Sub

    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 SR_ID FROM SalesReturn ORDER BY SR_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("SR_ID")
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
        txtSRNO.Text = ""
        txtSRID.Text = ""
        dtpSRDate.Value = Today
        txtSalesDate.Value = Today
        txtSalesID.Text = ""
        txtSalesInvoiceNo.Text = ""
        txtSubTotal.Text = ""
        txtSup_ID.Text = ""
        txtGrandTotal.Text = ""
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
        lblSet.Text = ""
        Clear()
        auto()
        txtSRNO.ReadOnly = False
        txtSRNO.BackColor = Color.White
        btnCreditNote.Enabled = False
        txtVAT.Text = "0.00"
        txtPaymentMode.Text = ""
        txtTaxType.Text = ""
        lblCustomer.Visible = False
        lblCustomerName.Visible = False
        txtCC_ID.Text = ""
        txtSalesInvoiceNo.Focus()
    End Sub

    Sub auto()
        Try
            txtSRID.Text = GenerateID()
            txtSRNO.Text = "SR-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnSelection_Click(sender As System.Object, e As System.EventArgs) Handles btnSelection.Click
        frmPOSRecord1.lblSet.Text = "SR"
        frmPOSRecord1.Reset()
        frmPOSRecord1.ShowDialog()
    End Sub
    Public Function SubTotal() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                sum = sum + (Val(r.Cells(8).Value) * Val(r.Cells(13).Value)) - Val(r.Cells(10).Value)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Sub Clear()
        txtProductName.Text = ""
        lblUnit.Visible = False
        txtBarcode.Text = ""
        txtManufacturingDate.Text = ""
        txtExpiryDate.Text = ""
        txtManufacturingDate.Text = ""
        txtExpiryDate.Text = ""
        txtSalesRate.Text = ""
        txtProductCode.Text = ""
        txtQty.Text = ""
        txtDiscountPer.Text = "0.00"
        txtDiscountAmount.Text = "0.00"
        txtVATPer.Text = "0.00"
        txtVATAmt.Text = "0.00"
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
            If txtQty.Text = "" Then
                MessageBox.Show("Please retrieve quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtQty.Focus()
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
                MessageBox.Show("Return Quantity can not be greater than Sales quantity", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtReturnQty.Text = ""
                txtReturnQty.Focus()
                Exit Sub
            End If
            For Each row As DataGridViewRow In DataGridView2.Rows
                If txtBarcode.Text = row.Cells(3).Value Then
                    MessageBox.Show("Same barcode already added in grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtBarcode.Focus()
                    Exit Sub
                End If
                If txtBarcode.Text = row.Cells(3).Value And txtProductID.Text = row.Cells(0).Value Then
                    MessageBox.Show("Record already added in grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtBarcode.Focus()
                    Exit Sub
                End If
            Next
            DataGridView2.Rows.Add(Val(txtProductID.Text), txtProductCode.Text, txtProductName.Text, txtBarcode.Text, txtManufacturingDate.Text, txtExpiryDate.Text, Val(txtQty.Text), lblUnit.Text, Val(txtSalesRate.Text), Val(txtDiscountPer.Text), Val(txtDiscountAmount.Text), Val(txtVATPer.Text), Val(txtVATAmt.Text), Val(txtReturnQty.Text), Val(txtTotalAmount.Text))
            Dim k1 As Double = 0
            k1 = SubTotal()
            k1 = Math.Round(k1, 2)
            txtSubTotal.Text = k1
            Clear()
            Calc()
            Compute()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRemove_Click(sender As System.Object, e As System.EventArgs) Handles btnRemove.Click
        Try
            For Each row As DataGridViewRow In DataGridView2.SelectedRows
                DataGridView2.Rows.Remove(row)
            Next
            Dim k As Double = 0
            k = SubTotal()
            k = Math.Round(k, 2)
            txtSubTotal.Text = k
            Calc()
            Compute()
            btnRemove.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtRetuenQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtReturnQty.TextChanged
        Calc()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If Len(Trim(txtSalesInvoiceNo.Text)) = 0 Then
                MessageBox.Show("Please retrieve Sales Info", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSalesInvoiceNo.Focus()
                Exit Sub
            End If
            If DataGridView2.Rows.Count = 0 Then
                MessageBox.Show("Sorry no returned product info added to grid", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "select SRNO from SalesReturn where SRNo=@d1"
            cmd = New SqlCommand(ct1)
            cmd.Parameters.AddWithValue("@d1", txtSRNO.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                MessageBox.Show("SR No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtSRNO.Text = ""
                txtSRNO.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con.Close()
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into  SalesReturn(SR_ID, SRNo, Date,SalesID, SubTotal,VAT, GrandTotal) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d8)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtSRID.Text))
            cmd.Parameters.AddWithValue("@d2", txtSRNO.Text)
            cmd.Parameters.AddWithValue("@d3", dtpSRDate.Value.Date)
            cmd.Parameters.AddWithValue("@d4", Val(txtSalesID.Text))
            cmd.Parameters.AddWithValue("@d5", Val(txtSubTotal.Text))
            cmd.Parameters.AddWithValue("@d6", Val(txtVAT.Text))
            cmd.Parameters.AddWithValue("@d8", Val(txtGrandTotal.Text))
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into SalesReturn_Join(SalesReturnID, ProductID, Barcode, ManufacturingDate, ExpiryDate, Qty, SalesCost, DiscPer, DiscAmt, CGSTPer, CGSTAmt, ReturnQty, TotalAmount)VALUES (" & txtSRID.Text & ",@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView2.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d2", row.Cells(3).Value)
                    cmd.Parameters.AddWithValue("@d3", row.Cells(4).Value)
                    cmd.Parameters.AddWithValue("@d4", row.Cells(5).Value)
                    cmd.Parameters.AddWithValue("@d5", Val(row.Cells(6).Value))
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(10).Value))
                    cmd.Parameters.AddWithValue("@d9", row.Cells(11).Value)
                    cmd.Parameters.AddWithValue("@d10", row.Cells(12).Value)
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(13).Value))
                    cmd.Parameters.AddWithValue("@d12", Val(row.Cells(14).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            For Each row As DataGridViewRow In DataGridView2.Rows
                con = New SqlConnection(cs)
                con.Open()
                Dim cb2 As String = "Update Temp_Stock_Company set Qty=Qty + " & Val(row.Cells(13).Value) & " where ProductID=@d1 and Barcode=@d2"
                cmd = New SqlCommand(cb2)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                cmd.Parameters.AddWithValue("@d2", row.Cells(3).Value)
                cmd.ExecuteReader()
                con.Close()
            Next
            If txtPaymentMode.Text = "Credit Customer" Then
                LedgerSave(dtpSRDate.Value.Date, "Sales Return A/c", txtSRNO.Text, "Credit Note", Val(txtGrandTotal.Text), 0, "", lblCustomerName.Text)
                LedgerSave(dtpSRDate.Value.Date, lblCustomerName.Text, txtSRNO.Text, "Credit Note", 0, Val(txtGrandTotal.Text), txtCreditCustomerID.Text, "Sales Return A/c")
            Else
                LedgerSave(dtpSRDate.Value.Date, "Cash", txtSRNO.Text, "Credit Note", 0, Val(txtGrandTotal.Text), "", "Sales Return A/c")
                LedgerSave(dtpSRDate.Value.Date, "Sales Return A/c", txtSRNO.Text, "Credit Note", Val(txtGrandTotal.Text), 0, "", "Cash")
            End If
            LogFunc(lblUser.Text, "added the new Sales return record having SR No. '" & txtSRNO.Text & "'")
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            btnCreditNote.Enabled = True
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
            Dim cq As String = "delete from SalesReturn where SR_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtSRID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                For Each row As DataGridViewRow In DataGridView2.Rows
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb2 As String = "Update Temp_Stock_Company set Qty=Qty - " & Val(row.Cells(13).Value) & " where ProductID=@d2 and Barcode=@d4"
                    cmd = New SqlCommand(cb2)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d2", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d4", row.Cells(3).Value)
                    cmd.ExecuteReader()
                    con.Close()
                Next
                LedgerDelete(txtSRNO.Text, "Credit Note")
                Dim st As String = "deleted the Sales Return record having SR No. '" & txtSRNO.Text & "'"
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
        frmSalesReturnRecord.lblSet.Text = "SR"
        frmSalesReturnRecord.Reset()
        frmSalesReturnRecord.ShowDialog()
    End Sub

    Private Sub DataGridView1_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs)
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

    Private Sub DataGridView1_RowPostPaint(sender As Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles DataGridView1.RowPostPaint
        Dim strRowNumber As String = (e.RowIndex + 1).ToString()
        Dim size As SizeF = e.Graphics.MeasureString(strRowNumber, Me.Font)
        If DataGridView1.RowHeadersWidth < Convert.ToInt32((size.Width + 20)) Then
            DataGridView1.RowHeadersWidth = Convert.ToInt32((size.Width + 20))
        End If
        Dim b As Brush = SystemBrushes.ControlText
        e.Graphics.DrawString(strRowNumber, Me.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2))

    End Sub

    Private Sub DataGridView2_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView2.MouseClick
        If DataGridView2.Rows.Count > 0 Then
            If lblSet.Text = "Not allowed" Then
                btnRemove.Enabled = False
            Else
                btnRemove.Enabled = True
            End If
        End If
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

    Private Sub DataGridView1_MouseClick_1(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        Try
            If DataGridView1.Rows.Count > 0 Then
                Clear()
                Dim dr As DataGridViewRow = DataGridView1.SelectedRows(0)
                txtProductID.Text = dr.Cells(0).Value.ToString()
                txtProductCode.Text = dr.Cells(1).Value.ToString()
                txtProductName.Text = dr.Cells(2).Value.ToString()
                txtBarcode.Text = dr.Cells(3).Value.ToString()
                txtManufacturingDate.Text = dr.Cells(4).Value.ToString()
                txtExpiryDate.Text = dr.Cells(5).Value.ToString()
                txtQty.Text = dr.Cells(6).Value.ToString()
                lblUnit.Text = dr.Cells(7).Value.ToString()
                txtSalesRate.Text = dr.Cells(8).Value.ToString()
                txtDiscountPer.Text = dr.Cells(9).Value.ToString()
                txtDiscountAmount.Text = dr.Cells(10).Value.ToString()
                txtVATPer.Text = dr.Cells(11).Value.ToString()
                txtVATAmt.Text = dr.Cells(12).Value.ToString()
                txtReturnQty.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtDiscountPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDiscountPer.TextChanged
        Calc()
    End Sub

    Private Sub txtVATPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtVATPer.TextChanged
        Calc()
    End Sub

    Private Sub btnCreditNote_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditNote.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptCreditNote 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT SalesReturn.SR_ID, SalesReturn.SRNo, SalesReturn.Date, SalesReturn.SalesID, SalesReturn.SubTotal, SalesReturn.VAT, SalesReturn.GrandTotal, SalesReturn_Join.SRJ_ID,SalesReturn_Join.SalesReturnID, SalesReturn_Join.ProductID, SalesReturn_Join.Barcode, SalesReturn_Join.ManufacturingDate, SalesReturn_Join.ExpiryDate, SalesReturn_Join.Qty, SalesReturn_Join.SalesCost, SalesReturn_Join.DiscPer, SalesReturn_Join.DiscAmt, SalesReturn_Join.CGSTPer, SalesReturn_Join.CGSTAmt, SalesReturn_Join.ReturnQty, SalesReturn_Join.TotalAmount, InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.OpenID,InvoiceInfo.PaymentMode, InvoiceInfo.CurrencyCode, InvoiceInfo.ExchangeRate, InvoiceInfo.GrandTotal AS Expr1, InvoiceInfo.Cash, InvoiceInfo.Change, InvoiceInfo.TaxType, Product.PID, Product.ProductCode, Product.ProductName, Product.Alias, Product.VATCommodity, Product.Description,Product.SalesUnit From SalesReturn INNER JOIN SalesReturn_Join ON SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID INNER JOIN InvoiceInfo ON SalesReturn.SalesID = InvoiceInfo.Inv_ID INNER JOIN Product ON SalesReturn_Join.ProductID = Product.PID where SR_ID=" & Val(txtSRID.Text) & ""
            MyCommand1.CommandText = "SELECT * from Company"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "SalesReturn")
            myDA.Fill(myDS, "SalesReturn_Join")
            myDA.Fill(myDS, "InvoiceInfo")
            myDA.Fill(myDS, "Product")
            myDA1.Fill(myDS, "Company")
            rpt.SetDataSource(myDS)
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT Sum(ReturnQty*SalesCost) from SalesReturn_Join where SalesReturnID=" & Val(txtSRID.Text) & ""
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                a = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            rpt.SetParameterValue("P1", a)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub txtSalesInvoiceNo_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtSalesInvoiceNo.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select Inv_ID,RTRIM(InvoiceNo),InvoiceDate,Pos_OpeningCash.OpenID,RTRIM(UserID),RTRIM(TillDetails),RTRIM(PaymentMode),RTRIM(CurrencyCode),ExchangeRate,RTRIM(CreditCustomerID),RTRIM(Name),GrandTotal,Cash,Change,RTRIM(TaxType),CC_ID from InvoiceInfo LEFT OUTER JOIN POS_OpeningCash ON InvoiceInfo.OpenID=POS_OpeningCash.OpenID LEFT OUTER JOIN CreditCustomer ON InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID where (DATEDIFF(d,InvoiceDate,GetDate())= 0) Order by InvoiceDate", con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                If rdr.Read Then
                    txtSalesID.Text = rdr.GetValue(0).ToString()
                    txtSalesDate.Text = rdr.GetValue(2).ToString()
                    txtPaymentMode.Text = rdr.GetValue(6).ToString()
                    txtTaxType.Text = rdr.GetValue(14).ToString()
                    If rdr.GetValue(6).ToString() = "Credit Customer" Then
                        lblCustomer.Visible = True
                        lblCustomerName.Visible = True
                        txtCC_ID.Text = rdr.GetValue(15).ToString()
                        txtCreditCustomerID.Text = rdr.GetValue(9).ToString()
                        lblCustomerName.Text = rdr.GetValue(10).ToString()
                    Else
                        lblCustomer.Visible = False
                        lblCustomerName.Visible = False
                        txtCC_ID.Text = ""
                        txtCreditCustomerID.Text = ""
                        lblCustomerName.Text = ""
                    End If
                    txtTaxType.Text = rdr.GetValue(14).ToString()
                End If
                con.Close()
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "SELECT Product.PID, RTRIM(Product.ProductCode), RTRIM(Product.ProductName), RTRIM(Invoice_Product.Barcode), RTRIM(Invoice_Product.MfgDate), RTRIM(Invoice_Product.ExpiryDate), Invoice_Product.Qty,RTRIM(Product.SalesUnit),Invoice_Product.SalesRate, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.TotalAmount FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID and InvoiceNo=@d1"
                cmd = New SqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@d1", txtSalesInvoiceNo.Text)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnScanInvoiceNo_Click(sender As System.Object, e As System.EventArgs) Handles btnScanInvoiceNo.Click
        txtSalesInvoiceNo.Focus()
    End Sub
End Class
