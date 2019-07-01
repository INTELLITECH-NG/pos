Imports System.Data.SqlClient

Public Class frmAccountingReport
    Dim a As Decimal
    Dim d, b, c As String
    Sub Reset()
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
        DateTimePicker1.Value = Today
        DateTimePicker2.Value = Today
        DateTimePicker3.Value = Today
        cmbSupplierName.Text = ""
    End Sub
    Sub fillSupplier()
        Try
            con = New SqlConnection(cs)
            con.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT RTRIM(Name) FROM Supplier", con)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbSupplierName.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbSupplierName.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPurchaseDaybook.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ctx As String = "select * from Purchase where Date Between @d2 and @d3 and PurchaseType='Credit'"
            cmd = New SqlCommand(ctx)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ST_ID,Date,InvoiceNo,Name,SubTotal,Discount,FreightCharges,OtherCharges,PreviousDue,GrandTotal from Supplier,Purchase where Supplier.ID=Purchase.Supplier_ID and PurchaseType='Credit' order by [Date]", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("PurchaseDayBook.xml")
            Dim rpt As New rptPurchaseDayBook
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Dispose()
            rpt.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnGeneralLedger.Click
        frmGeneralLedger.Reset()
        frmGeneralLedger.ShowDialog()
    End Sub

    Private Sub btnSupplierLedger_Click(sender As System.Object, e As System.EventArgs) Handles btnSupplierLedger.Click
        Try
            If Len(Trim(cmbSupplierName.Text)) = 0 Then
                MessageBox.Show("Please Select Supplier Name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbSupplierName.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select PartyID from LedgerBook where PartyID=@d3 and Date >=@d1 and Date < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.AddWithValue("@d3", txtSupplierID.Text)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker3.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Date, Name, LedgerNo, Label, Credit, Debit from LedgerBook where Date >=@d1 and Date < @d2 and PartyID=@d3 order by Date,LedgerNo", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker3.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker2.Value.Date.AddDays(1)
            cmd.Parameters.AddWithValue("@d3", txtSupplierID.Text)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("SupplierLedger.xml")
            Dim rpt As New rptSupplierLedger
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", DateTimePicker3.Value.Date)
            rpt.SetParameterValue("p2", DateTimePicker2.Value.Date)
            rpt.SetParameterValue("p3", txtSupplierID.Text)
            rpt.SetParameterValue("p4", cmbSupplierName.Text)
            rpt.SetParameterValue("p5", d)
            rpt.SetParameterValue("p6", b)
            rpt.SetParameterValue("p7", c)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Dispose()
            rpt.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTrialBalance_Click(sender As System.Object, e As System.EventArgs) Handles btnTrialBalance.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from LedgerBook where Date >=@d1 and Date < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Name,CASE WHEN (Sum(Debit)-Sum(Credit))<= 0 THEN 0 ELSE (Sum(Debit)-Sum(Credit)) END AS Debit,CASE WHEN (Sum(Credit)-Sum(Debit))<= 0 THEN 0 ELSE (Sum(Credit)-Sum(debit)) END AS Credit from LedgerBook where Date >=@d1 and Date < @d2 Group By Name having (Sum(Credit)-Sum(Debit)) <> 0 order by Name", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("TrialBalanceAccounting.xml")
            Dim rpt As New rptTrialBalance
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Dispose()
            rpt.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPurchase_Click(sender As System.Object, e As System.EventArgs) Handles btnPurchase.Click
        frmPurchaseRecord.Reset()
        frmPurchaseRecord.ShowDialog()
    End Sub

    Private Sub btnPayment_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnVouchers_Click(sender As System.Object, e As System.EventArgs) Handles btnVouchers.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from Voucher where Date Between @d2 and @d3"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim rpt As New rptExpenses 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand As New SqlCommand()
            Dim myDA As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand.CommandText = "SELECT Voucher.ID, Voucher.VoucherNo, Voucher.Date, Voucher.Name, Voucher.Details, Voucher.GrandTotal, Voucher_OtherDetails.VD_ID, Voucher_OtherDetails.VoucherID,Voucher_OtherDetails.Particulars, Voucher_OtherDetails.Amount, Voucher_OtherDetails.Note FROM Voucher INNER JOIN Voucher_OtherDetails ON Voucher.ID = Voucher_OtherDetails.VoucherID  where date between @d1 and @d2 order by date"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            MyCommand.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA.Fill(myDS, "Voucher")
            myDA.Fill(myDS, "Voucher_OtherDetails")
            con = New SqlConnection(cs)
            con.Open()
            Dim ctx As String = "select ISNULL(sum(GrandTotal),0) from Voucher where Date between @d1 and @d2"
            cmd = New SqlCommand(ctx)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            While rdr.Read()
                a = rdr.GetValue(0)
            End While
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            rpt.SetParameterValue("p4", Today)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Dispose()
            rpt.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbSupplierName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbSupplierName.SelectedIndexChanged
        Try
            d = ""
            b = ""
            c = ""
            txtSupplierID.Text = ""
            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT RTRIM(SupplierID),RTRIM(Address),RTRIM(City),RTRIM(ContactNo) FROM Supplier WHERE Name=@d1"
            cmd.Parameters.AddWithValue("@d1", cmbSupplierName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtSupplierID.Text = rdr.GetValue(0)
                d = rdr.GetValue(1)
                b = rdr.GetValue(2)
                c = rdr.GetValue(3)
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

    Private Sub btnGeneralDaybook_Click(sender As System.Object, e As System.EventArgs) Handles btnGeneralDaybook.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from LedgerBook where Date between @d1 and @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Date, Name, LedgerNo, Label, Credit, Debit from LedgerBook where Date between @d1 and @d2 order by ID,LedgerNo", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = DateTimePicker1.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("GeneralDayBook.xml")
            Dim rpt As New rptGeneralDayBook
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", DateTimePicker1.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Dispose()
            rpt.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmAccountingReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        fillSupplier()
    End Sub
    Private Sub btnCreditors_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditors.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Supplier.SupplierID, Supplier.Name,Supplier.ContactNo,IsNull(Sum(Credit)-Sum(Debit),0) FROM Supplier,LedgerBook where Supplier.SupplierID=LedgerBook.PartyID group by Supplier.SupplierID, Supplier.Name,Supplier.ContactNo having (sum(Credit)- sum(Debit) > 0 ) ORDER BY Supplier.Name", con)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("Creditors.xml")
            Dim rpt As New rptCreditors
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", Today)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Dispose()
            rpt.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnStockIN_Click(sender As System.Object, e As System.EventArgs) Handles btnStockIN.Click
        frmStockIN_Warehouse.Reset()
        frmStockIN_Warehouse.ShowDialog()
    End Sub

    Private Sub btnStockOut_Click(sender As System.Object, e As System.EventArgs) Handles btnStockOut.Click
        frmStockOut_Warehouse.Reset()
        frmStockOut_Warehouse.ShowDialog()
    End Sub

    Private Sub btnLowStock_Click(sender As System.Object, e As System.EventArgs) Handles btnLowStock_Warehouse.Click
        frmLowStockRecord.Reset()
        frmLowStockRecord.ShowDialog()
    End Sub

    Private Sub btnExpiredProducts_Click(sender As System.Object, e As System.EventArgs) Handles btnExpiredProducts.Click
        frmExpiredProducts_Warehouse.Reset()
        frmExpiredProducts_Warehouse.ShowDialog()
    End Sub

 
    Private Sub btnStockIn_Store_Click(sender As System.Object, e As System.EventArgs) Handles btnStockIn_Store.Click
        frmStockIn_Store.Reset()
        frmStockIn_Store.ShowDialog()
    End Sub

    Private Sub btnStockOut_Store_Click(sender As System.Object, e As System.EventArgs) Handles btnStockOut_Store.Click
        frmStockOUT_Store.Reset()
        frmStockOUT_Store.ShowDialog()
    End Sub

    Private Sub btnExpiredProducts_Store_Click(sender As System.Object, e As System.EventArgs) Handles btnExpiredProducts_Store.Click
        frmExpiredProducts_Store.Reset()
        frmExpiredProducts_Store.ShowDialog()
    End Sub

    Private Sub btnTax_Click(sender As System.Object, e As System.EventArgs) Handles btnOutputTax.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim cmd, cmd1, cmd2 As SqlCommand
            Dim ds As DataSet
            Dim adp, adp1, adp2 As SqlDataAdapter
            Dim dtable, dtable1, dtable2 As DataTable
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, InvoiceInfo.GrandTotal, SUM(Invoice_Product.VAT) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN POS_OpeningCash ON InvoiceInfo.OpenID = POS_OpeningCash.OpenID where InvoiceDate > = @d1 and InvoiceDate < @d2 group by InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, InvoiceInfo.GrandTotal having sum(VAT) > 0 order by InvoiceDate"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, InvoiceInfo.GrandTotal, SUM(Invoice_Product.VAT),SUM(Invoice_Product.VATPer)/Count(IPo_ID) FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN POS_OpeningCash ON InvoiceInfo.OpenID = POS_OpeningCash.OpenID where InvoiceDate > = @d1 and InvoiceDate < @d2 group by InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, InvoiceInfo.GrandTotal having sum(VAT) > 0 order by InvoiceDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)

            cmd1 = New SqlCommand("SELECT SalesReturn.SRNo, SalesReturn.Date, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, SalesReturn.GrandTotal, SalesReturn.VAT,SUM(CGSTPer)/Count(SRJ_ID) FROM SalesReturn INNER JOIN SalesReturn_Join ON SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID INNER JOIN InvoiceInfo ON SalesReturn.SalesID = InvoiceInfo.Inv_ID INNER JOIN POS_OpeningCash ON InvoiceInfo.OpenID = POS_OpeningCash.OpenID INNER JOIN Product ON SalesReturn_Join.ProductID = Product.PID where SalesReturn.Date > = @d1 and SalesReturn.Date < @d2 group by SalesReturn.SRNo, SalesReturn.Date, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, SalesReturn.GrandTotal, SalesReturn.VAT having SalesReturn.VAT > 0 order by SalesReturn.Date", con)
            cmd1.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd1.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp1 = New SqlDataAdapter(cmd1)
            cmd2 = New SqlCommand("Select * from Company", con)
            adp2 = New SqlDataAdapter(cmd2)
            dtable = New DataTable()
            dtable1 = New DataTable()
            dtable2 = New DataTable()
            adp.Fill(dtable)
            adp1.Fill(dtable1)
            adp2.Fill(dtable2)
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.Tables.Add(dtable1)
            ds.Tables.Add(dtable2)
            ds.WriteXmlSchema("OutputTaxReport1.xml")
            Dim rpt As New rptOutputTax
            rpt.Subreports(0).SetDataSource(ds)
            rpt.Subreports(1).SetDataSource(ds)
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Dispose()
            rpt.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnStockTransfer_W2S_Click(sender As System.Object, e As System.EventArgs) Handles btnStockTransfer_W2S.Click
        frmStockTransferRecord_W2S.Reset()
        frmStockTransferRecord_W2S.ShowDialog()
    End Sub

    Private Sub btnStockTransfer_W2W_Click(sender As System.Object, e As System.EventArgs) Handles btnStockTransfer_W2W.Click
        frmStockTransferRecord_W2W.Reset()
        frmStockTransferRecord_W2W.ShowDialog()
    End Sub

    Private Sub btnSalesReturn_Click(sender As System.Object, e As System.EventArgs) Handles btnSalesReturn.Click
        frmSalesReturnRecord.Reset()
        frmSalesReturnRecord.ShowDialog()
    End Sub

    Private Sub btnPurchaseReturn_Click(sender As System.Object, e As System.EventArgs) Handles btnPurchaseReturn.Click
        frmPurchaseReturnRecord.Reset()
        frmPurchaseReturnRecord.ShowDialog()
    End Sub

    Private Sub btnStockAdjustment_Store_Click(sender As System.Object, e As System.EventArgs) Handles btnStockAdjustment_Store.Click
        frmStockAdjustment_Store_Record.Reset()
        frmStockAdjustment_Store_Record.ShowDialog()
    End Sub

    Private Sub btnStockAdjustment_Warehouse_Click(sender As System.Object, e As System.EventArgs) Handles btnStockAdjustment_Warehouse.Click
        frmStockAdjustment_Warehouse_Record.Reset()
        frmStockAdjustment_Warehouse_Record.ShowDialog()
    End Sub

    Private Sub btnInputTax_Click(sender As System.Object, e As System.EventArgs) Handles btnInputTax.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim cmd, cmd1, cmd2 As SqlCommand
            Dim ds As DataSet
            Dim adp, adp1, adp2 As SqlDataAdapter
            Dim dtable, dtable1, dtable2 As DataTable
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "SELECT * from Purchase where Date > = @d1 and Date < @d2 and (VAT) > 0"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT Purchase.InvoiceNo, Purchase.Date, Supplier.Name, Supplier.TIN, Purchase.VATPer, Purchase.VAT, Purchase.GrandTotal FROM Purchase INNER JOIN Supplier ON Purchase.Supplier_ID = Supplier.ID where (VAT) > 0 and Date > = @d1 and Date < @d2 order by Date", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)

            cmd1 = New SqlCommand("SELECT PurchaseReturn.PRNo, PurchaseReturn.Date, Purchase.InvoiceNo, Purchase.Date AS Expr1, Supplier.Name, PurchaseReturn.VATPer, PurchaseReturn.VATAmt FROM PurchaseReturn INNER JOIN Purchase ON PurchaseReturn.PurchaseID = Purchase.ST_ID INNER JOIN Supplier ON Purchase.Supplier_ID = Supplier.ID where PurchaseReturn.Date > = @d1 and PurchaseReturn.Date < @d2 and PurchaseReturn.VATAmt > 0 order by PurchaseReturn.Date", con)
            cmd1.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd1.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp1 = New SqlDataAdapter(cmd1)
            cmd2 = New SqlCommand("Select * from Company", con)
            adp2 = New SqlDataAdapter(cmd2)
            dtable = New DataTable()
            dtable1 = New DataTable()
            dtable2 = New DataTable()
            adp.Fill(dtable)
            adp1.Fill(dtable1)
            adp2.Fill(dtable2)
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.Tables.Add(dtable1)
            ds.Tables.Add(dtable2)
            ds.WriteXmlSchema("InputTaxReport1.xml")
            Dim rpt As New rptInputTax
            rpt.Subreports(0).SetDataSource(ds)
            rpt.Subreports(1).SetDataSource(ds)
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Dispose()
            rpt.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCashBook_Click(sender As System.Object, e As System.EventArgs) Handles btnCashBook.Click
        frmCashBook.Reset()
        frmCashBook.ShowDialog()
    End Sub

    Private Sub btnLowStock_Store_Click(sender As System.Object, e As System.EventArgs) Handles btnLowStock_Store.Click
        frmLowStockRecord_Store.Reset()
        frmLowStockRecord_Store.ShowDialog()
    End Sub

    Private Sub btnJournalEntry_Click(sender As System.Object, e As System.EventArgs) Handles btnJournalEntry.Click
        frmJournalEntries.Reset()
        frmJournalEntries.lblUser.Text = lblUser.Text
        frmJournalEntries.ShowDialog()
    End Sub

    Private Sub btnProfitandLoss_Click(sender As System.Object, e As System.EventArgs) Handles btnProfitandLoss.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "Select * FROM InvoiceInfo where InvoiceDate >=@d1 and InvoiceDate < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, InvoiceInfo.PaymentMode, SUM(Invoice_Product.Margin), InvoiceInfo.GrandTotal FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN POS_OpeningCash ON InvoiceInfo.OpenID = POS_OpeningCash.OpenID where InvoiceDate >=@d1 and InvoiceDate < @d2 group by InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, InvoiceInfo.PaymentMode, InvoiceInfo.GrandTotal having (sum(Margin) > 0) order by InvoiceDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("ProfitAndLossReport.xml")
            Dim rpt As New rptProfitAndLoss
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBalanceSheet_Click(sender As System.Object, e As System.EventArgs) Handles btnBalanceSheet.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "Select * FROM LedgerBook where Date >=@d1 and Date < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry...No record found", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT distinct Name, (Sum(Debit) - Sum(Credit)) as Debit from LedgerBook where Date >=@d1 and Date < @d2 group by Name having ((Sum(Debit) - Sum(Credit)) > 0) order by 1", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd1 = New SqlCommand("SELECT distinct Name as NameX, (Sum(Credit) - Sum(Debit)) as Credit from LedgerBook where Date >=@d1 and Date < @d2 group by Name having ((Sum(Credit) - Sum(Debit)) > 0) order by 1", con)
            cmd1.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd1.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)
            adp1 = New SqlDataAdapter(cmd1)
            dtable = New DataTable()
            adp.Fill(dtable)
            adp1.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("BalanceSheetTestX.xml")
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "Select IsNULL(Sum(PurchaseRate*Qty),0) FROM Temp_Stock"
            cmd = New SqlCommand(ct1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                a = rdr.GetValue(0)
            Else
                a = 0
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim ct2 As String = "Select IsNULL(Sum(PurchaseRate*Qty),0) FROM Temp_Stock_Company"
            cmd = New SqlCommand(ct2)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                b = rdr.GetValue(0)
            Else
                b = 0
            End If
            con.Close()
            Dim rpt As New rptBalanceSheet
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", a)
            rpt.SetParameterValue("p4", b)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSalesmanLedger_Click(sender As System.Object, e As System.EventArgs) Handles btnSalesmanLedger.Click
        frmSalesmanLedger.Reset()
        frmSalesmanLedger.ShowDialog()
    End Sub

    Private Sub btnSalesmanCommission_Click(sender As System.Object, e As System.EventArgs) Handles btnSalesmanCommission.Click
        frmSalesmanCommmissionReport.Reset()
        frmSalesmanCommmissionReport.ShowDialog()
    End Sub
End Class
