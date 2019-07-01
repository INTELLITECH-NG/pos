Imports System.Data.SqlClient
Imports System.IO
Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO.Ports
Imports System.Windows.Forms
Public Class frmPOS
    Dim sign_Indicator As Integer = 0
    Dim variable1 As Double
    Dim variable2 As Double
    Dim fl As Boolean = False
    Dim s, x As String
    Dim st2 As String
    Private TextBoxOrder As New Dictionary(Of TextBox, TextBox)()
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Dim s4 As String
    Public literal, literal1 As String
    Public subt, subt1 As String
    Public Shared Function GetUniqueKey(ByVal maxSize As Integer) As String
        Dim chars As Char() = New Char(61) {}
        chars = "123456789".ToCharArray()
        Dim data As Byte() = New Byte(0) {}
        Dim crypto As New RNGCryptoServiceProvider()
        crypto.GetNonZeroBytes(data)
        data = New Byte(maxSize - 1) {}
        crypto.GetNonZeroBytes(data)
        Dim result As New StringBuilder(maxSize)
        For Each b As Byte In data
            result.Append(chars(b Mod (chars.Length)))
        Next
        Return result.ToString()
    End Function
    Private Sub GenerateHoldID()
        txtHoldID.Text = "H-" & GetUniqueKey(8)
    End Sub
    Dim st As String
    Public Function ReadCS() As String
        Using sr As StreamReader = New StreamReader(Application.StartupPath & "\PaperSize.txt")
            st = sr.ReadLine()
        End Using
        Return st
    End Function

    Sub Reset()
        dtpInvoiceDate.Value = Now
        dtpInvoiceDate1.Value = Now
        txtPaymentMode.Text = "Cash"
        txtGrandTotal.Text = "0.00"
        txtHoldID.Text = ""
        cmbDiscountType.SelectedIndex = 0
        txtDiscPer.Text = "0.00"
        txtDiscAmt.Text = "0.00"
        txtDiscAmt.ReadOnly = True
        txtCash.Text = "0.00"
        txtChange.Text = "0.00"
        txtExchangeRate.Text = 1
        DataGridView1.Rows.Clear()
        btnDeleteRow.Enabled = False
        Clear()
        auto()
        GetBaseCurrency()
        GridCalc()
        GetCustomerDisplayPort()
        CustomerDisplayOpeningMessage()
        GetCompnayName()
        GetSalesTaxType()
        lblCustomer.Visible = False
        lblDateTime.Visible = True
        lblCustomerName.Visible = False
        txtMemberID.Text = ""
        txtCC_ID.Text = ""
        lblBalance.Visible = False
        lblBalanceVal.Visible = False
        TableLayoutPanel1.Enabled = True
        TableLayoutPanel2.Enabled = True
        Me.btnCash.Enabled = True
        Me.btnCreditCard.Enabled = True
        Me.btnDebitCard.Enabled = True
        Me.btnWallet.Enabled = True
        btnBillDiscount.Enabled = True
        dtpInvoiceDate1.Visible = False
        txtCash.Enabled = True
        txtSM_ID.Text = ""
        txtSalesmanID.Text = ""
        txtSalesman.Text = ""
        txtPaperSize.Text = ReadCS()
    End Sub
    Private Function GenerateID() As String
        con = New SqlConnection(cs)
        Dim value As String = "0000"
        Try
            ' Fetch the latest ID from the database
            con.Open()
            cmd = New SqlCommand("SELECT TOP 1 Inv_ID FROM InvoiceInfo ORDER BY Inv_ID DESC", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If rdr.HasRows Then
                rdr.Read()
                value = rdr.Item("Inv_ID")
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
            txtInvID.Text = GenerateID()
            txtInvoiceNo.Text = "INV-" + GenerateID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Sub Compute()
        If txtTaxType.Text = "Inclusive" Then
            Dim num1, num2, num3, num4, num6 As Double
            num1 = CDbl(Val(txtQty.Text) * Val(txtSalesRate.Text))
            num1 = Math.Round(num1, 2)
            txtAmount.Text = num1
            num2 = CDbl((Val(txtAmount.Text) * Val(txtDiscountPer.Text)) / 100)
            num2 = Math.Round(num2, 2)
            txtDiscountAmount.Text = num2
            num3 = Val(txtAmount.Text) - Val(txtDiscountAmount.Text)
            num4 = num3 - (num3 / (1 + (Val(txtVAT.Text) / 100)))
            num4 = Math.Round(num4, 2)
            txtVATAmount.Text = num4
            num6 = num3
            num6 = Math.Round(num6, 2)
            txtTotalAmount.Text = num6
            txtMargin.Text = (((Val(txtSalesRate.Text) - Val(txtPurchaseRate.Text)) * Val(txtQty.Text)) - Val(txtDiscountAmount.Text))
            GridCalc()
        Else
            Dim num1, num2, num3, num4, num6 As Double
            num1 = CDbl(Val(txtQty.Text) * Val(txtSalesRate.Text))
            num1 = Math.Round(num1, 2)
            txtAmount.Text = num1
            num2 = CDbl((Val(txtAmount.Text) * Val(txtDiscountPer.Text)) / 100)
            num2 = Math.Round(num2, 2)
            txtDiscountAmount.Text = num2
            num3 = Val(txtAmount.Text) - Val(txtDiscountAmount.Text)
            num4 = CDbl((Val(txtVAT.Text) * Val(num3)) / 100)
            num4 = Math.Round(num4, 2)
            txtVATAmount.Text = num4
            num6 = CDbl(Val(txtAmount.Text) + Val(txtVATAmount.Text) - Val(txtDiscountAmount.Text))
            num6 = Math.Round(num6, 2)
            txtTotalAmount.Text = num6
            txtMargin.Text = ((Val(txtSalesRate.Text) - Val(txtPurchaseRate.Text)) * Val(txtQty.Text))
            GridCalc()
        End If
    End Sub
    Sub GridCalc()
        Dim TotalQty As Decimal = 0
        For Each r As DataGridViewRow In Me.DataGridView1.Rows
            TotalQty = TotalQty + r.Cells(4).Value
        Next
        txtNoOfQty.Text = TotalQty
        txtNoOfItems.Text = DataGridView1.Rows.Count
    End Sub
    Sub GetSalesTaxType()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(SalesTax) from Setting"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtTaxType.Text = rdr.GetValue(0)
            Else
                txtTaxType.Text = "Exclusive"
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
    Sub GetBaseCurrency()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(CurrencyCode) from Company"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtCurrencyCode.Text = rdr.GetValue(0)
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
    Private Sub txtQty_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtQty.TextChanged
        Compute()
    End Sub
    Public Function GrandTotal() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + r.Cells(13).Value
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Sub Clear()
        txtBarcode.Text = ""
        txtProductCode.Text = ""
        txtProductName.Text = ""
        txtMfgDate.Text = ""
        txtSalesRate.Text = ""
        txtExpiryDate.Text = ""
        txtAmount.Text = ""
        txtDiscountPer.Text = "0.00"
        txtDiscountAmount.Text = "0.00"
        txtVAT.Text = "0.00"
        txtVATAmount.Text = "0.00"
        txtQty.Text = 1
        btnAdd.Enabled = True
        txtBarcode.Focus()
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Try
            If DataGridView1.Rows.Count > 0 Then
                If txtTaxType.Text = "Inclusive" Then
                    Dim num1, num2, num3, num4, num6, num7 As Double
                    num1 = Val(DataGridView1.Rows(e.RowIndex).Cells("Qty").Value) * Val(DataGridView1.Rows(e.RowIndex).Cells("SalesRate").Value)
                    num1 = Math.Round(num1, 2)
                    txtAmount.Text = num1
                    num2 = (Val(txtAmount.Text) * Val(DataGridView1.Rows(e.RowIndex).Cells("DiscountPer").Value)) / 100
                    num2 = Math.Round(num2, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("Discount").Value = num2
                    num3 = Val(txtAmount.Text) - Val(DataGridView1.Rows(e.RowIndex).Cells("Discount").Value)
                    num4 = num3 - (num3 / (1 + (Val(DataGridView1.Rows(e.RowIndex).Cells("VATPer").Value) / 100)))
                    num4 = Math.Round(num4, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("VATAmt").Value = num4
                    num6 = CDbl(Val(txtAmount.Text) - Val(DataGridView1.Rows(e.RowIndex).Cells("Discount").Value))
                    num6 = Math.Round(num6, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("TotalAmount").Value = num6
                    num7 = ((Val(DataGridView1.Rows(e.RowIndex).Cells("SalesRate").Value) - Val(DataGridView1.Rows(e.RowIndex).Cells("PurchaseRate").Value)) * Val(DataGridView1.Rows(e.RowIndex).Cells("Qty").Value)) - Val(DataGridView1.Rows(e.RowIndex).Cells("Discount").Value)
                    num7 = Math.Round(num7, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("clMargin").Value = num7
                    Dim i As Double = 0
                    i = GrandTotal()
                    i = Math.Round(i, 2)
                    txtGrandTotal.Text = i
                    Calc()
                    DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(1)
                    txtBarcode.Focus()
                    ItemDataSubString(DataGridView1.Rows(e.RowIndex).Cells("PName").Value)
                    CustomerDisplay(subt, Val(DataGridView1.Rows(e.RowIndex).Cells("TotalAmount").Value))
                Else

                    Dim num1, num2, num3, num4, num6, num7 As Double
                    num1 = Val(DataGridView1.Rows(e.RowIndex).Cells("Qty").Value) * Val(DataGridView1.Rows(e.RowIndex).Cells("SalesRate").Value)
                    num1 = Math.Round(num1, 2)
                    txtAmount.Text = num1
                    num2 = (Val(txtAmount.Text) * Val(DataGridView1.Rows(e.RowIndex).Cells("DiscountPer").Value)) / 100
                    num2 = Math.Round(num2, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("Discount").Value = num2
                    num3 = Val(txtAmount.Text) - Val(DataGridView1.Rows(e.RowIndex).Cells("Discount").Value)
                    num4 = (Val(DataGridView1.Rows(e.RowIndex).Cells("VATPer").Value) * Val(num3)) / 100
                    num4 = Math.Round(num4, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("VATAmt").Value = num4
                    num6 = CDbl(Val(txtAmount.Text) + Val(DataGridView1.Rows(e.RowIndex).Cells("VATAmt").Value) - Val(DataGridView1.Rows(e.RowIndex).Cells("Discount").Value))
                    num6 = Math.Round(num6, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("TotalAmount").Value = num6
                    num7 = ((Val(DataGridView1.Rows(e.RowIndex).Cells("SalesRate").Value) - Val(DataGridView1.Rows(e.RowIndex).Cells("PurchaseRate").Value)) * Val(DataGridView1.Rows(e.RowIndex).Cells("Qty").Value)) - Val(DataGridView1.Rows(e.RowIndex).Cells("Discount").Value)
                    num7 = Math.Round(num7, 2)
                    DataGridView1.Rows(e.RowIndex).Cells("clMargin").Value = num7
                    Dim i As Double = 0
                    i = GrandTotal()
                    i = Math.Round(i, 2)
                    txtGrandTotal.Text = i
                    Calc()
                    DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(1)
                    txtBarcode.Focus()
                    ItemDataSubString(DataGridView1.Rows(e.RowIndex).Cells("PName").Value)
                    CustomerDisplay(subt, Val(DataGridView1.Rows(e.RowIndex).Cells("TotalAmount").Value))
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseClick
        If DataGridView1.Rows.Count > 0 Then
            btnDeleteRow.Enabled = True
        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        If txtInvoiceNo.Text = "" Then
            MessageBox.Show("Please enter invoice no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtInvoiceNo.Focus()
            Exit Sub
        End If
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If txtCash.Text = "" Then
            MessageBox.Show("Please enter amount tendered", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCash.Focus()
            Exit Sub
        End If
        If Val(txtGrandTotal.Text) < 0 Then
            MessageBox.Show("Grand total must be greater than or equal to zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If txtPaymentMode.Text <> "Credit Customer" Then
            If Val(txtCash.Text) < Val(txtGrandTotal.Text) Then
                MessageBox.Show("cash can not be less than grand total", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
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
            'For Each row As DataGridViewRow In DataGridView1.Rows
            '    Dim con As New SqlConnection(cs)
            '    con.Open()
            '    Dim cmd As New SqlCommand("SELECT Qty from Temp_Stock_Company where ProductID=@d1 and Barcode=@d2", con)
            '    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
            '    cmd.Parameters.AddWithValue("@d2", row.Cells(3).Value)
            '    Dim da As New SqlDataAdapter(cmd)
            '    Dim ds As DataSet = New DataSet()
            '    da.Fill(ds)
            '    If ds.Tables(0).Rows.Count > 0 Then
            '        txtTotalQty.Text = ds.Tables(0).Rows(0)("Qty")
            '        If CInt(Val(row.Cells(4).Value)) > Val(txtTotalQty.Text) Then
            '            MessageBox.Show("added qty. to cart are more than" & vbCrLf & "available qty. of product code '" & row.Cells(1).Value.ToString() & "' and Product Name='" & row.Cells(2).Value & "' having barcode='" & row.Cells(3).Value & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '            Exit Sub
            '        End If
            '    End If
            '    con.Close()
            'Next
            auto()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into InvoiceInfo(Inv_ID, InvoiceNo, InvoiceDate, OpenID, PaymentMode, CurrencyCode, ExchangeRate, GrandTotal, Cash, Change,TaxType,Member_ID,DiscPer,DiscAmt,SalesmanID) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14," & Val(txtSM_ID.Text) & ")"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtInvID.Text))
            cmd.Parameters.AddWithValue("@d2", txtInvoiceNo.Text)
            cmd.Parameters.AddWithValue("@d3", dtpInvoiceDate1.Value)
            cmd.Parameters.AddWithValue("@d4", Val(txtOpenID.Text))
            cmd.Parameters.AddWithValue("@d5", txtPaymentMode.Text)
            cmd.Parameters.AddWithValue("@d6", txtCurrencyCode.Text)
            cmd.Parameters.AddWithValue("@d7", Val(txtExchangeRate.Text))
            cmd.Parameters.AddWithValue("@d8", Val(txtGrandTotal.Text))
            cmd.Parameters.AddWithValue("@d9", Val(txtCash.Text))
            cmd.Parameters.AddWithValue("@d10", Val(txtChange.Text))
            cmd.Parameters.AddWithValue("@d11", txtTaxType.Text)
            cmd.Parameters.AddWithValue("@d12", txtMemberID.Text)
            cmd.Parameters.AddWithValue("@d13", Val(txtDiscPer.Text))
            cmd.Parameters.AddWithValue("@d14", Val(txtDiscAmt.Text))
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            If Val(txtSM_ID.Text) <> 0 Then
                Dim sum As Decimal = 0
                For Each r As DataGridViewRow In Me.DataGridView1.Rows
                    sum = sum + (Val(r.Cells(4).Value) * Val(r.Cells(7).Value))
                Next
                txtCommission.Text = Val((sum * Val(txtCommissionPer.Text)) / 100)
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sqlZ As String = "insert into Salesman_Commission(InvoiceID,CommissionPer,Commission) Values (" & Val(txtInvID.Text) & "," & Val(txtCommissionPer.Text) & "," & Val(txtCommission.Text) & ")"
            cmd = New SqlCommand(sqlZ)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into Invoice_Product( InvoiceID, ProductID, Barcode,Qty, MfgDate, ExpiryDate, SalesRate, DiscountPer, Discount, VATPer, VAT, TotalAmount,PurchaseRate,Margin) VALUES (" & txtInvID.Text & " ,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d2", row.Cells(3).Value)
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d4", row.Cells(5).Value.ToString())
                    cmd.Parameters.AddWithValue("@d5", row.Cells(6).Value.ToString())
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(10).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(11).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(13).Value))
                    cmd.Parameters.AddWithValue("@d12", Val(row.Cells(14).Value))
                    cmd.Parameters.AddWithValue("@d13", Val(row.Cells(15).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next

            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    SqlConnection.ClearAllPools()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim cb4 As String = "update Temp_stock_Company set qty = qty - (" & row.Cells(4).Value & ") where ProductID=@d1 and Barcode=@d2"
                    cmd = New SqlCommand(cb4)
                    cmd.Connection = con
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d2", row.Cells(3).Value)
                    cmd.ExecuteNonQuery()
                    con.Close()
                End If
            Next
            If txtHoldID.Text <> "" Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cb5 As String = "Delete from POS_HoldBill where Hold_ID=@d1"
                cmd = New SqlCommand(cb5)
                cmd.Parameters.AddWithValue("@d1", txtHoldID.Text)
                cmd.Connection = con
                cmd.ExecuteNonQuery()
                con.Close()
            End If
            con.Close()
            Dim st As String = "added the new sales invoice having invoice no. '" & txtInvoiceNo.Text & "'"
            LogFunc(txtUID.Text, st)
            If txtPaymentMode.Text = "Credit Customer" Then
                LedgerSave(dtpInvoiceDate1.Value.Date, "Sales A/c", txtInvoiceNo.Text, "Sales Invoice", 0, Val(txtGrandTotal.Text) * Val(txtExchangeRate.Text), "", lblCustomerName.Text)
                LedgerSave(dtpInvoiceDate1.Value.Date, lblCustomerName.Text, txtInvoiceNo.Text, "POS", Val(txtGrandTotal.Text) * Val(txtExchangeRate.Text), 0, txtMemberID.Text, "Sales A/c")
            Else
                LedgerSave(dtpInvoiceDate1.Value.Date, "Cash", txtInvoiceNo.Text, "POS", Val(txtGrandTotal.Text) * Val(txtExchangeRate.Text), 0, "", "Sales A/c")
                LedgerSave(dtpInvoiceDate1.Value.Date, "Sales A/c", txtInvoiceNo.Text, "Sales Invoice", 0, Val(txtGrandTotal.Text) * Val(txtExchangeRate.Text), "", "Cash")
            End If
            CustomerDisplayClosing(Val(txtCash.Text), Val(txtChange.Text))
            If txtPaymentMode.Text = "Cash" Then
                'Modify DrawerCode to your receipt printer open drawer code
                Dim DrawerCode As String = Chr(27) & Chr(112) & Chr(48) & Chr(64) & Chr(64)
                'Modify PrinterName to your receipt printer name
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes' and CashDrawer='Enabled'"
                cmd.Parameters.AddWithValue("@d1", txtTillCode.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    s4 = rdr.GetValue(0)
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
                Dim PrinterName As String = s4
                RawPrinter.PrintRaw(PrinterName, DrawerCode)
            End If
            If MessageBox.Show("Do you want to print bill?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                Print()
            End If
            con.Close()
            Reset()
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub

    Private Sub btnMinimize_Click(sender As System.Object, e As System.EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnKeyboard_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyboard.Click
        OSKeyboard()
    End Sub
    Sub OSKeyboard()
        Dim old As Long
        If Environment.Is64BitOperatingSystem Then
            If Wow64DisableWow64FsRedirection(old) Then
                Process.Start("osk.exe")
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            Process.Start("osk.exe")
        End If
    End Sub

    Private Sub txtBarcode_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtBarcode.Text Like "2000*" Then
                    literal1 = txtBarcode.Text
                    If literal1.Length >= 7 Then
                        txtSubB1.Text = literal1.Substring(0, 7)
                        txtSubB2.Text = literal1.Substring(7, 5)
                    End If
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT (PID),RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Barcode),SalesCost,TaxMaster.Percentage,RTRIM(Product.SalesUnit),PurchaseCost from Product,TaxMaster where TaxMaster.TaxName=Product.VATCommodity and Barcode like '" & txtSubB1.Text & "%'"
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        Me.txtProductID.Text = rdr.GetValue(0).ToString()
                        Me.txtProductCode.Text = rdr.GetValue(1).ToString()
                        Me.txtProductName.Text = rdr.GetValue(2).ToString()
                        Me.txtSalesRate.Text = rdr.GetValue(4).ToString()
                        Me.txtVAT.Text = rdr.GetValue(5).ToString()
                        Me.lblUnit.Text = rdr.GetValue(6).ToString()
                        Me.txtMfgDate.Text = ""
                        Me.txtExpiryDate.Text = ""
                        Me.txtPurchaseRate.Text = rdr.GetValue(7).ToString()
                        txtSalesRatePerKG.Text = Val(txtSubB2.Text) / 100
                        Dim num1 As Double
                        num1 = Val(txtSalesRatePerKG.Text) / Val(txtSalesRate.Text)
                        num1 = Math.Round(num1, 2)
                        txtQty.Text = num1
                        Compute()
                        AddDataToGridX()
                    Else
                        txtBarcode.Text = ""
                        txtBarcode.Focus()
                    End If
                Else
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT (PID),RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Temp_Stock_Company.Barcode),Temp_Stock_Company.SalesRate,TaxMaster.Percentage,Product.SalesUnit,RTRIM(Temp_Stock_Company.ManufacturingDate),RTRIM(Temp_Stock_Company.ExpiryDate),Temp_Stock_Company.Qty,temp_Stock_Company.PurchaseRate from Product,Temp_Stock_Company,TaxMaster where Product.PID=Temp_Stock_Company.ProductID and TaxMaster.TaxName=Product.VATCommodity and Temp_Stock_Company.Barcode=@d1"
                    cmd.Parameters.AddWithValue("@d1", txtBarcode.Text)
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        Me.txtProductID.Text = rdr.GetValue(0).ToString()
                        Me.txtProductCode.Text = rdr.GetValue(1).ToString()
                        Me.txtProductName.Text = rdr.GetValue(2).ToString()
                        Me.txtSalesRate.Text = rdr.GetValue(4).ToString()
                        Me.txtVAT.Text = rdr.GetValue(5).ToString()
                        Me.lblUnit.Text = rdr.GetValue(6).ToString()
                        Me.txtMfgDate.Text = rdr.GetValue(7).ToString()
                        Me.txtExpiryDate.Text = rdr.GetValue(8).ToString()
                        Me.txtPurchaseRate.Text = rdr.GetValue(10).ToString()
                        txtQty.Text = 1
                        Compute()
                        AddDataToGrid()
                    Else
                        txtBarcode.Text = ""
                        txtBarcode.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub frmPOS_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            e.Handled = True
            btnSave.PerformClick()
        End If
        If e.KeyCode = Keys.F6 Then
            e.Handled = True
            btnScanItems.PerformClick()
        End If
        If e.KeyCode = Keys.F7 And btnDeleteRow.Enabled = True Then
            e.Handled = True
            btnDeleteRow.PerformClick()
        End If
        If e.KeyCode = Keys.F3 Then
            e.Handled = True
            btnItemDiscount.PerformClick()
        End If
        If e.KeyCode = Keys.F5 Then
            e.Handled = True
            btnCloseTally.PerformClick()
        End If
        If e.KeyCode = Keys.F4 Then
            e.Handled = True
            btnLock.PerformClick()
        End If
        If e.KeyCode = Keys.F1 Then
            e.Handled = True
            btnNewBill.PerformClick()
        End If
        If e.KeyCode = Keys.F11 Then
            e.Handled = True
            btnChangeRate.PerformClick()
        End If
        If e.KeyCode = Keys.F8 Then
            e.Handled = True
            btnBillDiscount.PerformClick()
        End If
        If e.KeyCode = Keys.F10 Then
            e.Handled = True
            btnFindItem.PerformClick()
        End If
        If e.KeyCode = Keys.F9 Then
            e.Handled = True
            btnChangeQty.PerformClick()
        End If
        If e.KeyCode = Keys.F12 Then
            e.Handled = True
            btnHold.PerformClick()
        End If
        If e.KeyCode = Keys.L AndAlso e.Control = True Then
            e.Handled = True
            btnHoldRecord.PerformClick()
        End If
        If e.KeyCode = Keys.B AndAlso e.Control = True Then
            e.Handled = True
            btnPrint.PerformClick()
        End If
        If e.KeyCode = Keys.C AndAlso e.Control = True Then
            e.Handled = True
            txtBarcode.Text = ""
            txtCash.Focus()
        End If
    End Sub
    Sub Remove()
        Try

            For Each row As DataGridViewRow In DataGridView1.SelectedRows
                DataGridView1.Rows.Remove(row)
            Next
            Dim i As Double = 0
            i = GrandTotal()
            i = Math.Round(i, 2)
            txtGrandTotal.Text = i
            Compute()
            Calc()
            Calc1()
            btnDeleteRow.Enabled = False
            If DataGridView1.Rows.Count = 0 Then
                txtDiscAmt.Text = "0.00"
                txtDiscPer.Text = "0.00"
            End If
            txtBarcode.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnScanItems_Click(sender As System.Object, e As System.EventArgs) Handles btnScanItems.Click
        txtBarcode.Text = ""
        txtBarcode.Focus()
    End Sub

    Private Sub btnDeleteRow_Click(sender As System.Object, e As System.EventArgs) Handles btnDeleteRow.Click
        Remove()
    End Sub

    Private Sub btnCloseTally_Click(sender As System.Object, e As System.EventArgs) Handles btnCloseTally.Click
        frmPOSClosing.txtUID.Text = txtUID.Text
        frmPOSClosing.txtOpenID.Text = txtOpenID.Text
        frmPOSClosing.txtTillDetails.Text = txtTillCode.Text
        frmPOSClosing.txtClosingAmount.Focus()
        frmPOSClosing.ShowDialog()
    End Sub

    Private Sub btnLock_Click(sender As System.Object, e As System.EventArgs) Handles btnLock.Click
        frmLock.Password.Text = "ENTER PIN"
        frmLock.txtUserID.Text = txtUID.Text
        frmLock.ShowDialog()
    End Sub

    Private Sub btnCash_Click(sender As System.Object, e As System.EventArgs) Handles btnCash.Click
        txtPaymentMode.Text = btnCash.Text
    End Sub

    Private Sub btnCreditCard_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditCard.Click
        txtPaymentMode.Text = btnCreditCard.Text
        txtCash.Text = txtGrandTotal.Text
        txtChange.Text = "0.00"
    End Sub

    Private Sub btnDebitCard_Click(sender As System.Object, e As System.EventArgs) Handles btnDebitCard.Click
        txtPaymentMode.Text = btnDebitCard.Text
        txtCash.Text = txtGrandTotal.Text
        txtChange.Text = "0.00"
    End Sub

    Private Sub txtCash_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtCash.Text
            Dim selectionStart = Me.txtCash.SelectionStart
            Dim selectionLength = Me.txtCash.SelectionLength

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

    Private Sub txtCash_TextChanged(sender As System.Object, e As System.EventArgs)
        Calc()
    End Sub
    Sub Calc()

        If DataGridView1.Rows.Count > 0 Then
            Dim num As Double

            txtGrandTotal.Text = GrandTotal()
            num = Val(txtCash.Text) - Val(txtGrandTotal.Text)
            num = Math.Round(num, 2)
            If num < 0 Then
                txtChange.Text = ""
            Else
                txtChange.Text = num
            End If
        End If
    End Sub

    Sub OpenCashDrawer()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(CashDrawer) from POSPrinterSetting where CashDrawer='Enabled'"
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                frmCustomDialog11.ShowDialog()
                Exit Sub
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            'Modify DrawerCode to your receipt printer open drawer code
            Dim DrawerCode As String = Chr(27) & Chr(112) & Chr(48) & Chr(64) & Chr(64)
            'Modify PrinterName to your receipt printer name
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
            cmd.Parameters.AddWithValue("@d1", txtTillCode.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                s4 = rdr.GetValue(0)
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Dim PrinterName As String = s4
            RawPrinter.PrintRaw(PrinterName, DrawerCode)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnNewBill_Click(sender As System.Object, e As System.EventArgs) Handles btnNewBill.Click
        Reset()
        Reset()
    End Sub

    Private Sub frmPOS_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Reset()
    End Sub

    Private Sub btnGetCash_Click(sender As System.Object, e As System.EventArgs) Handles btnBillDiscount.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            If DataGridView1.Rows.Count > 0 Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT RTRIM(UserID) from Registration where UserID=@d1 and UserType='admin'"
                cmd.Parameters.AddWithValue("@d1", txtUID.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    frmSetBillDiscount.txtDiscount.Text = ""
                    frmSetBillDiscount.txtDiscount.Focus()
                    frmSetBillDiscount.ShowDialog()
                Else
                    frmConfirmAdmin.Password.PasswordChar = ""
                    frmConfirmAdmin.Password.Text = "ENTER PIN"
                    frmConfirmAdmin.lblSet.Text = "Bill Discount"
                    frmConfirmAdmin.ShowDialog()
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
        
    End Sub

    Private Sub btnFindItem_Click(sender As System.Object, e As System.EventArgs) Handles btnFindItem.Click
        frmFindItem.Reset()
        frmFindItem.ShowDialog()
    End Sub
    Sub AddDataToGridX()
        For Each r As DataGridViewRow In DataGridView1.Rows
            If r.Cells(0).Value = txtProductID.Text And r.Cells(3).Value = txtBarcode.Text Then
                r.Cells(0).Value = Val(txtProductID.Text)
                r.Cells(1).Value = txtProductCode.Text
                r.Cells(2).Value = txtProductName.Text
                r.Cells(3).Value = txtBarcode.Text
                r.Cells(4).Value = Val(r.Cells(4).Value) + Val(txtQty.Text)
                r.Cells(5).Value = txtMfgDate.Text
                r.Cells(6).Value = txtExpiryDate.Text
                r.Cells(7).Value = Val(txtSalesRate.Text)
                r.Cells(8).Value = Val(txtDiscountPer.Text)
                r.Cells(9).Value = Val(r.Cells(9).Value) + Val(txtDiscountAmount.Text)
                r.Cells(10).Value = Val(txtVAT.Text)
                r.Cells(11).Value = Val(r.Cells(11).Value) + Val(txtVATAmount.Text)
                r.Cells(12).Value = lblUnit.Text
                r.Cells(13).Value = Val(r.Cells(13).Value) + Val(txtTotalAmount.Text)
                r.Cells(14).Value = Val(txtPurchaseRate.Text)
                Compute()
                Dim i As Double = 0
                i = GrandTotal()
                i = Math.Round(i, 2)
                txtGrandTotal.Text = i
                Calc()
                Calc1()
                DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(1)
                ItemDataSubString(r.Cells(2).Value)
                CustomerDisplay(subt, Val(r.Cells(13).Value))
                Clear()

                Exit Sub
            End If
        Next
        DataGridView1.Rows.Add(Val(txtProductID.Text), txtProductCode.Text, txtProductName.Text, txtBarcode.Text, Val(txtQty.Text), txtMfgDate.Text, txtExpiryDate.Text, Val(txtSalesRate.Text), Val(txtDiscountPer.Text), Val(txtDiscountAmount.Text), Val(txtVAT.Text), Val(txtVATAmount.Text), lblUnit.Text, Val(txtTotalAmount.Text), Val(txtPurchaseRate.Text), Val(txtMargin.Text))
        Compute()
        Dim j As Double = 0
        j = GrandTotal()
        j = Math.Round(j, 2)
        txtGrandTotal.Text = j
        Calc()
        Calc1()
        DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(1)
        ItemDataSubString(txtProductName.Text)
        CustomerDisplay(subt, Val(txtTotalAmount.Text))
        Clear()
    End Sub
    Sub AddDataToGrid()
        For Each r As DataGridViewRow In DataGridView1.Rows
            If r.Cells(0).Value = txtProductID.Text And r.Cells(3).Value = txtBarcode.Text Then
                r.Cells(0).Value = Val(txtProductID.Text)
                r.Cells(1).Value = txtProductCode.Text
                r.Cells(2).Value = txtProductName.Text
                r.Cells(3).Value = txtBarcode.Text
                r.Cells(4).Value = Val(r.Cells(4).Value) + 1
                r.Cells(5).Value = txtMfgDate.Text
                r.Cells(6).Value = txtExpiryDate.Text
                r.Cells(7).Value = Val(txtSalesRate.Text)
                r.Cells(8).Value = Val(txtDiscountPer.Text)
                r.Cells(9).Value = Val(r.Cells(9).Value) + Val(txtDiscountAmount.Text)
                r.Cells(10).Value = Val(txtVAT.Text)
                r.Cells(11).Value = Val(r.Cells(11).Value) + Val(txtVATAmount.Text)
                r.Cells(12).Value = lblUnit.Text
                r.Cells(13).Value = Val(r.Cells(13).Value) + Val(txtTotalAmount.Text)
                r.Cells(14).Value = Val(txtPurchaseRate.Text)
                Compute()
                Dim i As Double = 0
                i = GrandTotal()
                i = Math.Round(i, 2)
                txtGrandTotal.Text = i
                Calc()
                Calc1()
                DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(1)
                ItemDataSubString(r.Cells(2).Value)
                CustomerDisplay(subt, Val(r.Cells(13).Value))
                Clear()

                Exit Sub
            End If
        Next
        DataGridView1.Rows.Add(Val(txtProductID.Text), txtProductCode.Text, txtProductName.Text, txtBarcode.Text, Val(txtQty.Text), txtMfgDate.Text, txtExpiryDate.Text, Val(txtSalesRate.Text), Val(txtDiscountPer.Text), Val(txtDiscountAmount.Text), Val(txtVAT.Text), Val(txtVATAmount.Text), lblUnit.Text, Val(txtTotalAmount.Text), Val(txtPurchaseRate.Text), Val(txtMargin.Text))
        Compute()
        Dim j As Double = 0
        j = GrandTotal()
        j = Math.Round(j, 2)
        txtGrandTotal.Text = j
        Calc()
        Calc1()
        DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells(1)
        ItemDataSubString(txtProductName.Text)
        CustomerDisplay(subt, Val(txtTotalAmount.Text))
        Clear()
    End Sub
    Private Sub btnEditQty_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeQty.Click
        If DataGridView1.Rows.Count > 0 Then
            frmChangeQty.txtQty.Text = ""
            frmChangeQty.txtQty.Focus()
            frmChangeQty.ShowDialog()
        End If
    End Sub
    Sub ItemDataSubString(ByVal st As String)
        literal = st
        If literal.Length > 12 Then
            subt = literal.Substring(0, 12)
        Else
            subt = literal
        End If
    End Sub
    Sub Print()
        Try
            If txtPaperSize.Text = "A4" Or txtPaperSize.Text = "a4" Then
                Try
                    If txtPaymentMode.Text = "Credit Customer" Then
                        Cursor = Cursors.WaitCursor
                        Timer1.Enabled = True
                        Dim rpt As New rptInvoice1A4 'The report you created.
                        Dim myConnection As SqlConnection
                        Dim MyCommand, MyCommand1 As New SqlCommand()
                        Dim myDA, myDA1 As New SqlDataAdapter()
                        Dim myDS As New DataSet 'The DataSet you created.
                        myConnection = New SqlConnection(cs)
                        MyCommand.Connection = myConnection
                        MyCommand1.Connection = myConnection
                        MyCommand.CommandText = "SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.OpenID, InvoiceInfo.PaymentMode, InvoiceInfo.CurrencyCode, InvoiceInfo.ExchangeRate, InvoiceInfo.DiscPer, InvoiceInfo.DiscAmt,InvoiceInfo.GrandTotal, InvoiceInfo.Cash, InvoiceInfo.Change, InvoiceInfo.TaxType, InvoiceInfo.Member_ID, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.Barcode,Invoice_Product.MfgDate, Invoice_Product.ExpiryDate, Invoice_Product.SalesRate, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.Qty,Invoice_Product.TotalAmount, Invoice_Product.PurchaseRate, Invoice_Product.Margin, POS_OpeningCash.OpenID AS Expr1, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, POS_OpeningCash.OpeningDate, POS_OpeningCash.OpeningCash, POS_OpeningCash.Closed, Product.PID, Product.ProductCode, Product.ProductName, Product.Alias, Product.VATCommodity, Product.Description, Product.Barcode AS Expr2, Product.Category,Product.PurchaseUnit, Product.SalesUnit, Product.PurchaseCost, Product.SalesCost, Product.ReorderPoint, Product.AddedDate FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN POS_OpeningCash ON InvoiceInfo.OpenID = POS_OpeningCash.OpenID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID  where Inv_ID=" & Val(txtInvID.Text) & ""
                        MyCommand1.CommandText = "SELECT * from Company"
                        MyCommand.CommandType = CommandType.Text
                        MyCommand1.CommandType = CommandType.Text
                        myDA.SelectCommand = MyCommand
                        myDA1.SelectCommand = MyCommand1
                        myDA.Fill(myDS, "InvoiceInfo")
                        myDA.Fill(myDS, "Invoice_Product")
                        myDA.Fill(myDS, "Product")
                        myDA.Fill(myDS, "POS_OpeningCash")
                        myDA1.Fill(myDS, "Company")
                        rpt.SetDataSource(myDS)
                        rpt.SetParameterValue("p1", txtMemberID.Text)
                        rpt.SetParameterValue("p2", lblCustomerName.Text)
                        frmReport.CrystalReportViewer1.ReportSource = rpt
                        frmReport.ShowDialog()
                        'con = New SqlConnection(cs)
                        'con.Open()
                        'cmd = con.CreateCommand()
                        'cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
                        'cmd.Parameters.AddWithValue("@d1", txtTillCode.Text)
                        'rdr = cmd.ExecuteReader()
                        'If rdr.Read() Then
                        '    s4 = rdr.GetValue(0)
                        '    rpt.PrintOptions.PrinterName = s4
                        '    rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
                        '    rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
                        '    rpt.PrintToPrinter(1, False, 0, 0)
                        'End If
                        'If (rdr IsNot Nothing) Then
                        '    rdr.Close()
                        'End If
                        'If con.State = ConnectionState.Open Then
                        '    con.Close()
                        'End If
                        rpt.Close()
                        rpt.Dispose()
                    Else
                        Cursor = Cursors.WaitCursor
                        Timer1.Enabled = True
                        Dim rpt As New rptInvoiceA4 'The report you created.
                        Dim myConnection As SqlConnection
                        Dim MyCommand, MyCommand1 As New SqlCommand()
                        Dim myDA, myDA1 As New SqlDataAdapter()
                        Dim myDS As New DataSet 'The DataSet you created.
                        myConnection = New SqlConnection(cs)
                        MyCommand.Connection = myConnection
                        MyCommand1.Connection = myConnection
                        MyCommand.CommandText = "SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.OpenID, InvoiceInfo.PaymentMode, InvoiceInfo.CurrencyCode, InvoiceInfo.ExchangeRate, InvoiceInfo.DiscPer, InvoiceInfo.DiscAmt,InvoiceInfo.GrandTotal, InvoiceInfo.Cash, InvoiceInfo.Change, InvoiceInfo.TaxType, InvoiceInfo.Member_ID, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.Barcode,Invoice_Product.MfgDate, Invoice_Product.ExpiryDate, Invoice_Product.SalesRate, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.Qty,Invoice_Product.TotalAmount, Invoice_Product.PurchaseRate, Invoice_Product.Margin, POS_OpeningCash.OpenID AS Expr1, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, POS_OpeningCash.OpeningDate, POS_OpeningCash.OpeningCash, POS_OpeningCash.Closed, Product.PID, Product.ProductCode, Product.ProductName, Product.Alias, Product.VATCommodity, Product.Description, Product.Barcode AS Expr2, Product.Category,Product.PurchaseUnit, Product.SalesUnit, Product.PurchaseCost, Product.SalesCost, Product.ReorderPoint, Product.AddedDate FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN POS_OpeningCash ON InvoiceInfo.OpenID = POS_OpeningCash.OpenID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID  where Inv_ID=" & Val(txtInvID.Text) & ""
                        MyCommand1.CommandText = "SELECT * from Company"
                        MyCommand.CommandType = CommandType.Text
                        MyCommand1.CommandType = CommandType.Text
                        myDA.SelectCommand = MyCommand
                        myDA1.SelectCommand = MyCommand1
                        myDA.Fill(myDS, "InvoiceInfo")
                        myDA.Fill(myDS, "Invoice_Product")
                        myDA.Fill(myDS, "Product")
                        myDA.Fill(myDS, "POS_OpeningCash")
                        myDA1.Fill(myDS, "Company")
                        rpt.SetDataSource(myDS)
                        frmReport.CrystalReportViewer1.ReportSource = rpt
                        frmReport.ShowDialog()
                        'con = New SqlConnection(cs)
                        'con.Open()
                        'cmd = con.CreateCommand()
                        'cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
                        'cmd.Parameters.AddWithValue("@d1", txtTillCode.Text)
                        'rdr = cmd.ExecuteReader()
                        'If rdr.Read() Then
                        '    s4 = rdr.GetValue(0)
                        '    rpt.PrintOptions.PrinterName = s4
                        '    rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
                        '    rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
                        '    rpt.PrintToPrinter(1, False, 0, 0)
                        'End If
                        'If (rdr IsNot Nothing) Then
                        '    rdr.Close()
                        'End If
                        'If con.State = ConnectionState.Open Then
                        '    con.Close()
                        'End If
                        rpt.Close()
                        rpt.Dispose()
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                If txtPaymentMode.Text = "Credit Customer" Then
                    Cursor = Cursors.WaitCursor
                    Timer1.Enabled = True
                    Dim rpt As New rptInvoice1 'The report you created.
                    Dim myConnection As SqlConnection
                    Dim MyCommand, MyCommand1 As New SqlCommand()
                    Dim myDA, myDA1 As New SqlDataAdapter()
                    Dim myDS As New DataSet 'The DataSet you created.
                    myConnection = New SqlConnection(cs)
                    MyCommand.Connection = myConnection
                    MyCommand1.Connection = myConnection
                    MyCommand.CommandText = "SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.OpenID, InvoiceInfo.PaymentMode, InvoiceInfo.CurrencyCode, InvoiceInfo.ExchangeRate, InvoiceInfo.DiscPer, InvoiceInfo.DiscAmt,InvoiceInfo.GrandTotal, InvoiceInfo.Cash, InvoiceInfo.Change, InvoiceInfo.TaxType, InvoiceInfo.Member_ID, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.Barcode,Invoice_Product.MfgDate, Invoice_Product.ExpiryDate, Invoice_Product.SalesRate, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.Qty,Invoice_Product.TotalAmount, Invoice_Product.PurchaseRate, Invoice_Product.Margin, POS_OpeningCash.OpenID AS Expr1, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, POS_OpeningCash.OpeningDate, POS_OpeningCash.OpeningCash, POS_OpeningCash.Closed, Product.PID, Product.ProductCode, Product.ProductName, Product.Alias, Product.VATCommodity, Product.Description, Product.Barcode AS Expr2, Product.Category,Product.PurchaseUnit, Product.SalesUnit, Product.PurchaseCost, Product.SalesCost, Product.ReorderPoint, Product.AddedDate FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN POS_OpeningCash ON InvoiceInfo.OpenID = POS_OpeningCash.OpenID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID  where Inv_ID=" & Val(txtInvID.Text) & ""
                    MyCommand1.CommandText = "SELECT * from Company"
                    MyCommand.CommandType = CommandType.Text
                    MyCommand1.CommandType = CommandType.Text
                    myDA.SelectCommand = MyCommand
                    myDA1.SelectCommand = MyCommand1
                    myDA.Fill(myDS, "InvoiceInfo")
                    myDA.Fill(myDS, "Invoice_Product")
                    myDA.Fill(myDS, "Product")
                    myDA.Fill(myDS, "POS_OpeningCash")
                    myDA1.Fill(myDS, "Company")
                    rpt.SetDataSource(myDS)
                    rpt.SetParameterValue("p1", txtMemberID.Text)
                    rpt.SetParameterValue("p2", lblCustomerName.Text)
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
                    cmd.Parameters.AddWithValue("@d1", txtTillCode.Text)
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        s4 = rdr.GetValue(0)
                        rpt.PrintOptions.PrinterName = s4
                        rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
                        rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
                        rpt.PrintToPrinter(1, False, 0, 0)
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    rpt.Close()
                    rpt.Dispose()
                Else
                    Cursor = Cursors.WaitCursor
                    Timer1.Enabled = True
                    Dim rpt As New rptInvoice 'The report you created.
                    Dim myConnection As SqlConnection
                    Dim MyCommand, MyCommand1 As New SqlCommand()
                    Dim myDA, myDA1 As New SqlDataAdapter()
                    Dim myDS As New DataSet 'The DataSet you created.
                    myConnection = New SqlConnection(cs)
                    MyCommand.Connection = myConnection
                    MyCommand1.Connection = myConnection
                    MyCommand.CommandText = "SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.OpenID, InvoiceInfo.PaymentMode, InvoiceInfo.CurrencyCode, InvoiceInfo.ExchangeRate, InvoiceInfo.DiscPer, InvoiceInfo.DiscAmt,InvoiceInfo.GrandTotal, InvoiceInfo.Cash, InvoiceInfo.Change, InvoiceInfo.TaxType, InvoiceInfo.Member_ID, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.Barcode,Invoice_Product.MfgDate, Invoice_Product.ExpiryDate, Invoice_Product.SalesRate, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.Qty,Invoice_Product.TotalAmount, Invoice_Product.PurchaseRate, Invoice_Product.Margin, POS_OpeningCash.OpenID AS Expr1, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, POS_OpeningCash.OpeningDate, POS_OpeningCash.OpeningCash, POS_OpeningCash.Closed, Product.PID, Product.ProductCode, Product.ProductName, Product.Alias, Product.VATCommodity, Product.Description, Product.Barcode AS Expr2, Product.Category,Product.PurchaseUnit, Product.SalesUnit, Product.PurchaseCost, Product.SalesCost, Product.ReorderPoint, Product.AddedDate FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN POS_OpeningCash ON InvoiceInfo.OpenID = POS_OpeningCash.OpenID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID  where Inv_ID=" & Val(txtInvID.Text) & ""
                    MyCommand1.CommandText = "SELECT * from Company"
                    MyCommand.CommandType = CommandType.Text
                    MyCommand1.CommandType = CommandType.Text
                    myDA.SelectCommand = MyCommand
                    myDA1.SelectCommand = MyCommand1
                    myDA.Fill(myDS, "InvoiceInfo")
                    myDA.Fill(myDS, "Invoice_Product")
                    myDA.Fill(myDS, "Product")
                    myDA.Fill(myDS, "POS_OpeningCash")
                    myDA1.Fill(myDS, "Company")
                    rpt.SetDataSource(myDS)
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
                    cmd.Parameters.AddWithValue("@d1", txtTillCode.Text)
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        s4 = rdr.GetValue(0)
                        rpt.PrintOptions.PrinterName = s4
                        rpt.PrintOptions.DissociatePageSizeAndPrinterPaperSize = True
                        rpt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
                        rpt.PrintToPrinter(1, False, 0, 0)
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    rpt.Close()
                    rpt.Dispose()
                End If
            End If
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub GetCustomerDisplayPort()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(CDPort) from POSPrinterSetting where TillID=@d1"
            cmd.Parameters.AddWithValue("@d1", txtTillCode.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtDisplayPort.Text = rdr.GetValue(0)
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
    Sub GetCompnayName()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(CompanyName) from Company"
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtCompanyName.Text = rdr.GetValue(0)
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
    Sub CustomerDisplay(ByVal ItemName As String, ByVal TotalAmount As Decimal)
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT * from POSPrinterSetting where TillID=@d1 and CustomerDisplay='Yes'"
            cmd.Parameters.AddWithValue("@d1", txtTillCode.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                Dim sp As New SerialPort(txtDisplayPort.Text, 9600, Parity.None, 8, StopBits.One)
                sp.Open()
                ' to clear the display
                sp.Write(CChar(ChrW(12)))
                ' first line goes here
                sp.WriteLine(ItemName & " " & TotalAmount)
                ' second line goes here
                sp.Write(CChar(ChrW(13)))
                sp.WriteLine("TOTAL : " & Val(txtGrandTotal.Text))
                sp.Close()
                sp.Dispose()
                sp = Nothing
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
    Sub CustomerDisplayClosing(ByVal Cash As Decimal, ByVal Change As Decimal)
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT * from POSPrinterSetting where TillID=@d1 and CustomerDisplay='Yes'"
            cmd.Parameters.AddWithValue("@d1", txtTillCode.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                Dim sp As New SerialPort(txtDisplayPort.Text, 9600, Parity.None, 8, StopBits.One)
                sp.Open()
                ' to clear the display
                sp.Write(CChar(ChrW(12)))
                ' first line goes here
                sp.WriteLine("Cash/Card :" & Cash)
                ' second line goes here
                sp.Write(CChar(ChrW(13)))
                sp.WriteLine("Change :" & Change)
                sp.Close()
                sp.Dispose()
                sp = Nothing
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
    Sub CustomerDisplayOpeningMessage()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT * from POSPrinterSetting where TillID=@d1 and CustomerDisplay='Yes'"
            cmd.Parameters.AddWithValue("@d1", txtTillCode.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                Dim sp As New SerialPort(txtDisplayPort.Text, 9600, Parity.None, 8, StopBits.One)
                sp.Open()
                ' to clear the display
                sp.Write(CChar(ChrW(12)))
                sp.WriteLine(txtCompanyName.Text)
                sp.Close()
                sp.Dispose()
                sp = Nothing
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
    Private Sub btnHold_Click(sender As System.Object, e As System.EventArgs) Handles btnHold.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("sorry no product added to cart", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Try
            GenerateHoldID()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into POS_HoldBill(Hold_ID,OpenID,Date,DiscPer,DiscAmt) Values ('" & txtHoldID.Text & "',@d1,@d2,@d3,@d4)"
            cmd = New SqlCommand(cb)
            cmd.Parameters.AddWithValue("@d1", Val(txtOpenID.Text))
            cmd.Parameters.AddWithValue("@d2", dtpInvoiceDate1.Value)
            cmd.Parameters.AddWithValue("@d3", Val(txtDiscPer.Text))
            cmd.Parameters.AddWithValue("@d4", Val(txtDiscAmt.Text))
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "insert into POS_HoldBillItems(HoldID, ProductID, Barcode,Qty, MfgDate, ExpiryDate, SalesRate, DiscountPer, Discount, VATPer, VAT, TotalAmount,PurchaseRate,Margin) VALUES ('" & txtHoldID.Text & "' ,@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13)"
            cmd = New SqlCommand(cb1)
            cmd.Connection = con
            ' Prepare command for repeated execution
            cmd.Prepare()
            ' Data to be inserted
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow Then
                    cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                    cmd.Parameters.AddWithValue("@d2", row.Cells(3).Value)
                    cmd.Parameters.AddWithValue("@d3", Val(row.Cells(4).Value))
                    cmd.Parameters.AddWithValue("@d4", row.Cells(5).Value.ToString())
                    cmd.Parameters.AddWithValue("@d5", row.Cells(6).Value.ToString())
                    cmd.Parameters.AddWithValue("@d6", Val(row.Cells(7).Value))
                    cmd.Parameters.AddWithValue("@d7", Val(row.Cells(8).Value))
                    cmd.Parameters.AddWithValue("@d8", Val(row.Cells(9).Value))
                    cmd.Parameters.AddWithValue("@d9", Val(row.Cells(10).Value))
                    cmd.Parameters.AddWithValue("@d10", Val(row.Cells(11).Value))
                    cmd.Parameters.AddWithValue("@d11", Val(row.Cells(13).Value))
                    cmd.Parameters.AddWithValue("@d12", Val(row.Cells(14).Value))
                    cmd.Parameters.AddWithValue("@d13", Val(row.Cells(15).Value))
                    cmd.ExecuteNonQuery()
                    cmd.Parameters.Clear()
                End If
            Next
            con.Close()
            MessageBox.Show("Successfully Hold", "Bill", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Reset()
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnHoldRecord_Click(sender As System.Object, e As System.EventArgs) Handles btnHoldRecord.Click
        frmHoldBill.GetData(Val(txtOpenID.Text))
        frmHoldBill.ShowDialog()
    End Sub

    Private Sub txtSalesRate_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSalesRate.TextChanged
        Compute()
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Try
            If txtInvoiceNo.Text = "" Then
                MessageBox.Show("Please enter invoice no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtInvoiceNo.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select InvoiceNo from InvoiceInfo where InvoiceNo=@d1"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()

            If Not rdr.Read() Then
                MessageBox.Show("Invoice no. does not exists", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con.Close()
            If txtPaperSize.Text = "A4" Or txtPaperSize.Text = "a4" Then
                con = New SqlConnection(cs)
                con.Open()
                Dim cl3 As String = "SELECT RTRIM(Member_ID),RTRIM(Name) FROM InvoiceInfo,CreditCustomer where InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID and InvoiceNo=@d1 and member_ID <> '' and member_id is not null"
                cmd = New SqlCommand(cl3)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then

                    Cursor = Cursors.WaitCursor
                    Timer1.Enabled = True
                    Dim rpt As New rptInvoice1A4 'The report you created.
                    Dim myConnection As SqlConnection
                    Dim MyCommand, MyCommand1 As New SqlCommand()
                    Dim myDA, myDA1 As New SqlDataAdapter()
                    Dim myDS As New DataSet 'The DataSet you created.
                    myConnection = New SqlConnection(cs)
                    MyCommand.Connection = myConnection
                    MyCommand1.Connection = myConnection
                    MyCommand.CommandText = "SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.OpenID, InvoiceInfo.PaymentMode, InvoiceInfo.CurrencyCode, InvoiceInfo.ExchangeRate, InvoiceInfo.DiscPer, InvoiceInfo.DiscAmt,InvoiceInfo.GrandTotal, InvoiceInfo.Cash, InvoiceInfo.Change, InvoiceInfo.TaxType, InvoiceInfo.Member_ID, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.Barcode,Invoice_Product.MfgDate, Invoice_Product.ExpiryDate, Invoice_Product.SalesRate, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.Qty,Invoice_Product.TotalAmount, Invoice_Product.PurchaseRate, Invoice_Product.Margin, POS_OpeningCash.OpenID AS Expr1, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, POS_OpeningCash.OpeningDate, POS_OpeningCash.OpeningCash, POS_OpeningCash.Closed, Product.PID, Product.ProductCode, Product.ProductName, Product.Alias, Product.VATCommodity, Product.Description, Product.Barcode AS Expr2, Product.Category,Product.PurchaseUnit, Product.SalesUnit, Product.PurchaseCost, Product.SalesCost, Product.ReorderPoint, Product.AddedDate FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN POS_OpeningCash ON InvoiceInfo.OpenID = POS_OpeningCash.OpenID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID  where InvoiceNo=@d1"
                    MyCommand.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
                    MyCommand1.CommandText = "SELECT * from Company"
                    MyCommand.CommandType = CommandType.Text
                    MyCommand1.CommandType = CommandType.Text
                    myDA.SelectCommand = MyCommand
                    myDA1.SelectCommand = MyCommand1
                    myDA.Fill(myDS, "InvoiceInfo")
                    myDA.Fill(myDS, "Invoice_Product")
                    myDA.Fill(myDS, "Product")
                    myDA.Fill(myDS, "POS_OpeningCash")
                    myDA1.Fill(myDS, "Company")
                    rpt.SetDataSource(myDS)
                    rpt.SetParameterValue("p1", rdr.GetValue(0).ToString())
                    rpt.SetParameterValue("p2", rdr.GetValue(1).ToString())
                    frmReport.CrystalReportViewer1.ReportSource = rpt
                    frmReport.ShowDialog()
                    'con = New SqlConnection(cs)
                    'con.Open()
                    'cmd = con.CreateCommand()
                    'cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
                    'cmd.Parameters.AddWithValue("@d1", txtTillCode.Text)
                    'rdr = cmd.ExecuteReader()
                    'If rdr.Read() Then
                    '    s4 = rdr.GetValue(0)
                    '    rpt.PrintOptions.PrinterName = s4

                    '    rpt.PrintToPrinter(1, False, 0, 0)
                    'End If
                    'If (rdr IsNot Nothing) Then
                    '    rdr.Close()
                    'End If
                    'If con.State = ConnectionState.Open Then
                    '    con.Close()
                    'End If
                    rpt.Close()
                    rpt.Dispose()
                Else
                    Cursor = Cursors.WaitCursor
                    Timer1.Enabled = True
                    Dim rpt As New rptInvoiceA4 'The report you created.
                    Dim myConnection As SqlConnection
                    Dim MyCommand, MyCommand1 As New SqlCommand()
                    Dim myDA, myDA1 As New SqlDataAdapter()
                    Dim myDS As New DataSet 'The DataSet you created.
                    myConnection = New SqlConnection(cs)
                    MyCommand.Connection = myConnection
                    MyCommand1.Connection = myConnection
                    MyCommand.CommandText = "SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.OpenID, InvoiceInfo.PaymentMode, InvoiceInfo.CurrencyCode, InvoiceInfo.ExchangeRate, InvoiceInfo.DiscPer, InvoiceInfo.DiscAmt,InvoiceInfo.GrandTotal, InvoiceInfo.Cash, InvoiceInfo.Change, InvoiceInfo.TaxType, InvoiceInfo.Member_ID, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.Barcode,Invoice_Product.MfgDate, Invoice_Product.ExpiryDate, Invoice_Product.SalesRate, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.Qty,Invoice_Product.TotalAmount, Invoice_Product.PurchaseRate, Invoice_Product.Margin, POS_OpeningCash.OpenID AS Expr1, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, POS_OpeningCash.OpeningDate, POS_OpeningCash.OpeningCash, POS_OpeningCash.Closed, Product.PID, Product.ProductCode, Product.ProductName, Product.Alias, Product.VATCommodity, Product.Description, Product.Barcode AS Expr2, Product.Category,Product.PurchaseUnit, Product.SalesUnit, Product.PurchaseCost, Product.SalesCost, Product.ReorderPoint, Product.AddedDate FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN POS_OpeningCash ON InvoiceInfo.OpenID = POS_OpeningCash.OpenID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID where InvoiceNo=@d1"
                    MyCommand.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
                    MyCommand1.CommandText = "SELECT * from Company"
                    MyCommand.CommandType = CommandType.Text
                    MyCommand1.CommandType = CommandType.Text
                    myDA.SelectCommand = MyCommand
                    myDA1.SelectCommand = MyCommand1
                    myDA.Fill(myDS, "InvoiceInfo")
                    myDA.Fill(myDS, "Invoice_Product")
                    myDA.Fill(myDS, "Product")
                    myDA.Fill(myDS, "POS_OpeningCash")
                    myDA1.Fill(myDS, "Company")
                    rpt.SetDataSource(myDS)
                    frmReport.CrystalReportViewer1.ReportSource = rpt
                    frmReport.ShowDialog()
                    'con = New SqlConnection(cs)
                    'con.Open()
                    'cmd = con.CreateCommand()
                    'cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
                    'cmd.Parameters.AddWithValue("@d1", txtTillCode.Text)
                    'rdr = cmd.ExecuteReader()
                    'If rdr.Read() Then
                    '    s4 = rdr.GetValue(0)
                    '    rpt.PrintOptions.PrinterName = s4

                    '    rpt.PrintToPrinter(1, False, 0, 0)
                    'End If
                    'If (rdr IsNot Nothing) Then
                    '    rdr.Close()
                    'End If
                    'If con.State = ConnectionState.Open Then
                    '    con.Close()
                    'End If
                    rpt.Close()
                    rpt.Dispose()
                End If
            Else
                con = New SqlConnection(cs)
                con.Open()
                Dim cl4 As String = "SELECT RTRIM(Member_ID),RTRIM(Name) FROM InvoiceInfo,CreditCustomer where InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID and InvoiceNo=@d1 and member_ID <> '' and member_id is not null"
                cmd = New SqlCommand(cl4)
                cmd.Connection = con
                cmd.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then

                    Cursor = Cursors.WaitCursor
                    Timer1.Enabled = True
                    Dim rpt As New rptInvoice1 'The report you created.
                    Dim myConnection As SqlConnection
                    Dim MyCommand, MyCommand1 As New SqlCommand()
                    Dim myDA, myDA1 As New SqlDataAdapter()
                    Dim myDS As New DataSet 'The DataSet you created.
                    myConnection = New SqlConnection(cs)
                    MyCommand.Connection = myConnection
                    MyCommand1.Connection = myConnection
                    MyCommand.CommandText = "SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.OpenID, InvoiceInfo.PaymentMode, InvoiceInfo.CurrencyCode, InvoiceInfo.ExchangeRate, InvoiceInfo.DiscPer, InvoiceInfo.DiscAmt,InvoiceInfo.GrandTotal, InvoiceInfo.Cash, InvoiceInfo.Change, InvoiceInfo.TaxType, InvoiceInfo.Member_ID, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.Barcode,Invoice_Product.MfgDate, Invoice_Product.ExpiryDate, Invoice_Product.SalesRate, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.Qty,Invoice_Product.TotalAmount, Invoice_Product.PurchaseRate, Invoice_Product.Margin, POS_OpeningCash.OpenID AS Expr1, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, POS_OpeningCash.OpeningDate, POS_OpeningCash.OpeningCash, POS_OpeningCash.Closed, Product.PID, Product.ProductCode, Product.ProductName, Product.Alias, Product.VATCommodity, Product.Description, Product.Barcode AS Expr2, Product.Category,Product.PurchaseUnit, Product.SalesUnit, Product.PurchaseCost, Product.SalesCost, Product.ReorderPoint, Product.AddedDate FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN POS_OpeningCash ON InvoiceInfo.OpenID = POS_OpeningCash.OpenID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID  where InvoiceNo=@d1"
                    MyCommand.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
                    MyCommand1.CommandText = "SELECT * from Company"
                    MyCommand.CommandType = CommandType.Text
                    MyCommand1.CommandType = CommandType.Text
                    myDA.SelectCommand = MyCommand
                    myDA1.SelectCommand = MyCommand1
                    myDA.Fill(myDS, "InvoiceInfo")
                    myDA.Fill(myDS, "Invoice_Product")
                    myDA.Fill(myDS, "Product")
                    myDA.Fill(myDS, "POS_OpeningCash")
                    myDA1.Fill(myDS, "Company")
                    rpt.SetDataSource(myDS)
                    rpt.SetParameterValue("p1", rdr.GetValue(0).ToString())
                    rpt.SetParameterValue("p2", rdr.GetValue(1).ToString())
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
                    cmd.Parameters.AddWithValue("@d1", txtTillCode.Text)
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        s4 = rdr.GetValue(0)
                        rpt.PrintOptions.PrinterName = s4

                        rpt.PrintToPrinter(1, False, 0, 0)
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    rpt.Close()
                    rpt.Dispose()
                Else
                    Cursor = Cursors.WaitCursor
                    Timer1.Enabled = True
                    Dim rpt As New rptInvoice 'The report you created.
                    Dim myConnection As SqlConnection
                    Dim MyCommand, MyCommand1 As New SqlCommand()
                    Dim myDA, myDA1 As New SqlDataAdapter()
                    Dim myDS As New DataSet 'The DataSet you created.
                    myConnection = New SqlConnection(cs)
                    MyCommand.Connection = myConnection
                    MyCommand1.Connection = myConnection
                    MyCommand.CommandText = "SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.OpenID, InvoiceInfo.PaymentMode, InvoiceInfo.CurrencyCode, InvoiceInfo.ExchangeRate, InvoiceInfo.DiscPer, InvoiceInfo.DiscAmt,InvoiceInfo.GrandTotal, InvoiceInfo.Cash, InvoiceInfo.Change, InvoiceInfo.TaxType, InvoiceInfo.Member_ID, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.Barcode,Invoice_Product.MfgDate, Invoice_Product.ExpiryDate, Invoice_Product.SalesRate, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.Qty,Invoice_Product.TotalAmount, Invoice_Product.PurchaseRate, Invoice_Product.Margin, POS_OpeningCash.OpenID AS Expr1, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, POS_OpeningCash.OpeningDate, POS_OpeningCash.OpeningCash, POS_OpeningCash.Closed, Product.PID, Product.ProductCode, Product.ProductName, Product.Alias, Product.VATCommodity, Product.Description, Product.Barcode AS Expr2, Product.Category,Product.PurchaseUnit, Product.SalesUnit, Product.PurchaseCost, Product.SalesCost, Product.ReorderPoint, Product.AddedDate FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN POS_OpeningCash ON InvoiceInfo.OpenID = POS_OpeningCash.OpenID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID where InvoiceNo=@d1"
                    MyCommand.Parameters.AddWithValue("@d1", txtInvoiceNo.Text)
                    MyCommand1.CommandText = "SELECT * from Company"
                    MyCommand.CommandType = CommandType.Text
                    MyCommand1.CommandType = CommandType.Text
                    myDA.SelectCommand = MyCommand
                    myDA1.SelectCommand = MyCommand1
                    myDA.Fill(myDS, "InvoiceInfo")
                    myDA.Fill(myDS, "Invoice_Product")
                    myDA.Fill(myDS, "Product")
                    myDA.Fill(myDS, "POS_OpeningCash")
                    myDA1.Fill(myDS, "Company")
                    rpt.SetDataSource(myDS)
                    con = New SqlConnection(cs)
                    con.Open()
                    cmd = con.CreateCommand()
                    cmd.CommandText = "SELECT RTRIM(PrinterName) from POSPrinterSetting where TillID=@d1 and IsEnabled='Yes'"
                    cmd.Parameters.AddWithValue("@d1", txtTillCode.Text)
                    rdr = cmd.ExecuteReader()
                    If rdr.Read() Then
                        s4 = rdr.GetValue(0)
                        rpt.PrintOptions.PrinterName = s4

                        rpt.PrintToPrinter(1, False, 0, 0)
                    End If
                    If (rdr IsNot Nothing) Then
                        rdr.Close()
                    End If
                    If con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                    rpt.Close()
                    rpt.Dispose()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTA1_Click(sender As System.Object, e As System.EventArgs) Handles btnTA1.Click
        If Val(txtCash.Text = 0) Then
            txtCash.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(1)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(1)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA2_Click(sender As System.Object, e As System.EventArgs) Handles btnTA2.Click
        If Val(txtCash.Text = 0) Then
            txtCash.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(2)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(2)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA3_Click(sender As System.Object, e As System.EventArgs) Handles btnTA3.Click
        If Val(txtCash.Text = 0) Then
            txtCash.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(3)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(3)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA4_Click(sender As System.Object, e As System.EventArgs) Handles btnTA4.Click
        If Val(txtCash.Text = 0) Then
            txtCash.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(4)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(4)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA5_Click(sender As System.Object, e As System.EventArgs) Handles btnTA5.Click
        If Val(txtCash.Text = 0) Then
            txtCash.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(5)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(5)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA6_Click(sender As System.Object, e As System.EventArgs) Handles btnTA6.Click
        If Val(txtCash.Text = 0) Then
            txtCash.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(6)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(6)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA7_Click(sender As System.Object, e As System.EventArgs) Handles btnTA7.Click
        If Val(txtCash.Text = 0) Then
            txtCash.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(7)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(7)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA8_Click(sender As System.Object, e As System.EventArgs) Handles btnTA8.Click
        If Val(txtCash.Text = 0) Then
            txtCash.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(8)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(8)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTA9_Click(sender As System.Object, e As System.EventArgs) Handles btnTA9.Click
        If Val(txtCash.Text = 0) Then
            txtCash.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(9)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(9)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTAComma_Click(sender As System.Object, e As System.EventArgs) Handles btnTAComma.Click
        If Val(txtCash.Text = 0) Then
            txtCash.Text = ""
        End If
        Dim i As Integer = 0
        Dim chr As Char = ControlChars.NullChar
        Dim decimal_Indicator As Integer = 0
        Dim l As Integer = txtCash.Text.Length - 1
        If sign_Indicator <> 1 Then
            For i = 0 To l
                chr = txtCash.Text(i)
                If chr = "."c Then
                    decimal_Indicator = 1
                End If
            Next

            If decimal_Indicator <> 1 Then
                txtCash.Text = txtCash.Text + Convert.ToString(".")
            End If
        End If
    End Sub

    Private Sub btnTA0_Click(sender As System.Object, e As System.EventArgs) Handles btnTA0.Click
        If Val(txtCash.Text = 0) Then
            txtCash.Text = ""
        End If
        If sign_Indicator = 0 Then
            txtCash.Text = txtCash.Text + Convert.ToString(0)
        ElseIf sign_Indicator = 1 Then
            txtCash.Text = Convert.ToString(0)
            sign_Indicator = 0
        End If
        fl = True
    End Sub

    Private Sub btnTAx_Click(sender As System.Object, e As System.EventArgs) Handles btnTAx.Click
        If txtCash.Text = "" Then
            txtCash.Text = "0.00"
        End If
        s = txtCash.Text
        Dim l As Integer = s.Length
        For i As Integer = 0 To l - 2
            x += s(i)
        Next
        txtCash.Text = x
        x = ""
        If txtCash.Text = "" Then
            txtCash.Text = "0.00"
        End If
    End Sub

    Private Sub btnWallet_Click(sender As System.Object, e As System.EventArgs) Handles btnWallet.Click
        frmWalletList.ShowDialog()
    End Sub

    Private Sub btnCreditCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditCustomer.Click
        If DataGridView1.Rows.Count = 0 Then
            MessageBox.Show("sorry no item added to datagridview", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        frmCreditCustomerBalance.Reset()
        frmCreditCustomerBalance.ShowDialog()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnSalesReturn.Click
        frmSalesReturn.lblUser.Text = txtUID.Text
        frmSalesReturn.Reset()
        frmSalesReturn.btnGetData.Enabled = False
        frmSalesReturn.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        OpenCashDrawer()
    End Sub

    Private Sub btnChangeRate_Click(sender As System.Object, e As System.EventArgs) Handles btnChangeRate.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT RTRIM(UserID) from Registration where UserID=@d1 and UserType='admin'"
                cmd.Parameters.AddWithValue("@d1", txtUID.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    frmChangeRate.txtRate.Text = ""
                    frmChangeRate.txtRate.Focus()
                    frmChangeRate.ShowDialog()
                Else
                    frmConfirmAdmin.Password.PasswordChar = ""
                    frmConfirmAdmin.Password.Text = "ENTER PIN"
                    frmConfirmAdmin.lblSet.Text = "Change Rate"
                    frmConfirmAdmin.ShowDialog()
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub txtDiscPer_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDiscPer.TextChanged
        Calc()
        Calc1()
    End Sub

    Private Sub txtDiscAmt_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDiscAmt.TextChanged
        Calc()
        Calc1()
    End Sub
    Sub Calc1()
        If cmbDiscountType.SelectedIndex = 0 Then
            If DataGridView1.Rows.Count > 0 Then
                For Each row As DataGridViewRow In DataGridView1.Rows
                    row.Cells(8).Value = txtDiscPer.Text
                Next
                CalcDiscount()
            End If
        End If
        If cmbDiscountType.SelectedIndex = 1 Then
            If DataGridView1.Rows.Count > 0 Then
                Dim num1 As Double
                CalcSubTotal()
                num1 = (Val(txtDiscAmt.Text) * 100) / Val(txtSubTotal.Text)
                num1 = Math.Round(num1, 4)
                txtDiscPer.Text = num1
            End If
        End If
        If DataGridView1.Rows.Count > 0 Then
            For Each row As DataGridViewRow In DataGridView1.Rows
                row.Cells(8).Value = txtDiscPer.Text
            Next
        End If
    End Sub
    Public Function CalcDiscount() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + Val(r.Cells(9).Value)
            Next
            sum = Math.Round(sum, 2)
            txtDiscAmt.Text = sum
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Public Function CalcSubTotal() As Double
        Dim sum As Double = 0
        Try
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                sum = sum + (Val(r.Cells(4).Value) * Val(r.Cells(7).Value))
            Next
            sum = Math.Round(sum, 2)
            txtSubTotal.Text = sum
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return sum
    End Function
    Private Sub cmbDiscountType_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbDiscountType.SelectedIndexChanged
        Calc1()
    End Sub

    Private Sub txtCash_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles txtCash.TextChanged
        Calc()
    End Sub

    Private Sub btnItemDiscount_Click(sender As System.Object, e As System.EventArgs) Handles btnItemDiscount.Click
        Try
            If DataGridView1.Rows.Count > 0 Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = con.CreateCommand()
                cmd.CommandText = "SELECT RTRIM(UserID) from Registration where UserID=@d1 and UserType='admin'"
                cmd.Parameters.AddWithValue("@d1", txtUID.Text)
                rdr = cmd.ExecuteReader()
                If rdr.Read() Then
                    frmSetItemDiscount.txtDiscount.Text = ""
                    frmSetItemDiscount.txtDiscount.Focus()
                    frmSetItemDiscount.ShowDialog()
                Else
                    frmConfirmAdmin.Password.PasswordChar = ""
                    frmConfirmAdmin.Password.Text = "ENTER PIN"
                    frmConfirmAdmin.lblSet.Text = "Item Discount"
                    frmConfirmAdmin.ShowDialog()
                End If
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                If con.State = ConnectionState.Open Then
                    con.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnSalesman_Click(sender As System.Object, e As System.EventArgs) Handles btnSalesman.Click
        frmSalesmanRecord.lblSet.Text = "POS"
        frmSalesmanRecord.Reset()
        frmSalesmanRecord.ShowDialog()
    End Sub

    Private Sub btnLogout_Click(sender As System.Object, e As System.EventArgs) Handles btnLogout.Click
        frmCustomDialog18.lblUser.Text = txtUID.Text
        frmCustomDialog18.ShowDialog()
    End Sub

    Private Sub txtCash_KeyPress_1(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCash.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtCash.Text
            Dim selectionStart = Me.txtCash.SelectionStart
            Dim selectionLength = Me.txtCash.SelectionLength

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
