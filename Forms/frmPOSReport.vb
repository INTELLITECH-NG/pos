Imports System.Data.SqlClient
Public Class frmPOSReport
    Dim b1, b2 As Double
    Sub Reset()
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnViewReport1_Click(sender As System.Object, e As System.EventArgs) Handles btnViewReport2.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from InvoiceInfo where InvoiceDate >=@d1 and InvoiceDate < @d2"
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
            Dim rpt As New rptSales 'The report you created.
            Dim myConnection As SqlConnection
            Dim MyCommand, MyCommand1 As New SqlCommand()
            Dim myDA, myDA1 As New SqlDataAdapter()
            Dim myDS As New DataSet 'The DataSet you created.
            myConnection = New SqlConnection(cs)
            MyCommand.Connection = myConnection
            MyCommand1.Connection = myConnection
            MyCommand.CommandText = "SELECT TaxType, InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.OpenID, InvoiceInfo.PaymentMode, InvoiceInfo.CurrencyCode, InvoiceInfo.ExchangeRate, InvoiceInfo.GrandTotal, InvoiceInfo.Cash,InvoiceInfo.Change, POS_OpeningCash.OpenID AS Expr1, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, POS_OpeningCash.OpeningDate, POS_OpeningCash.OpeningCash,POS_OpeningCash.Closed FROM InvoiceInfo INNER JOIN POS_OpeningCash ON InvoiceInfo.OpenID = POS_OpeningCash.OpenID where InvoiceDate >=@d1 and InvoiceDate < @d2 order by InvoiceDate"
            MyCommand.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            MyCommand.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            MyCommand1.CommandText = "SELECT * from Company"
            MyCommand.CommandType = CommandType.Text
            MyCommand1.CommandType = CommandType.Text
            myDA.SelectCommand = MyCommand
            myDA1.SelectCommand = MyCommand1
            myDA.Fill(myDS, "InvoiceInfo")
            myDA.Fill(myDS, "POS_OpeningCash")
            myDA1.Fill(myDS, "Company")
            rpt.SetDataSource(myDS)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub btnViewReport2_Click(sender As System.Object, e As System.EventArgs) Handles btnViewReport3.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from InvoiceInfo where InvoiceDate >=@d1 and InvoiceDate < @d2"
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
            cmd = New SqlCommand("SELECT InvoiceInfo.Inv_ID, InvoiceInfo.InvoiceNo, InvoiceInfo.InvoiceDate, InvoiceInfo.OpenID, InvoiceInfo.PaymentMode, InvoiceInfo.CurrencyCode, InvoiceInfo.ExchangeRate, InvoiceInfo.DiscPer, InvoiceInfo.DiscAmt,InvoiceInfo.GrandTotal, InvoiceInfo.Cash, InvoiceInfo.Change, InvoiceInfo.TaxType, InvoiceInfo.Member_ID, Invoice_Product.IPo_ID, Invoice_Product.InvoiceID, Invoice_Product.ProductID, Invoice_Product.Barcode,Invoice_Product.MfgDate, Invoice_Product.ExpiryDate, Invoice_Product.SalesRate, Invoice_Product.DiscountPer, Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.Qty,Invoice_Product.TotalAmount, Invoice_Product.PurchaseRate, Invoice_Product.Margin, POS_OpeningCash.OpenID AS Expr1, POS_OpeningCash.TillDetails, POS_OpeningCash.UserID, POS_OpeningCash.OpeningDate, POS_OpeningCash.OpeningCash, POS_OpeningCash.Closed, Product.PID, Product.ProductCode, Product.ProductName, Product.Alias, Product.VATCommodity, Product.Description, Product.Barcode AS Expr2, Product.Category,Product.PurchaseUnit, Product.SalesUnit, Product.PurchaseCost, Product.SalesCost, Product.ReorderPoint, Product.AddedDate FROM InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN POS_OpeningCash ON InvoiceInfo.OpenID = POS_OpeningCash.OpenID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID where InvoiceDate >=@d1 and InvoiceDate < @d2 order by InvoiceDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
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
            ds.WriteXmlSchema("Sales_XML1.xml")
            Dim rpt As New rptSales1
            rpt.SetDataSource(ds)
            con = New SqlConnection(cs)
            con.Open()
            Dim ct1 As String = "select Sum(Margin) from InvoiceInfo,Invoice_Product where InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID and InvoiceDate >=@d1 and InvoiceDate < @d2"
            cmd = New SqlCommand(ct1)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                txtMargin.Text = rdr.GetValue(0)
            End If
            con.Close()
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", Val(txtMargin.Text))
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnViewReport1_Click_1(sender As System.Object, e As System.EventArgs) Handles btnViewReport1.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            Dim cmd, cmd1, cmd2, cmd3, cmd4, cmd5, cmd6, cmd7 As SqlCommand
            Dim ds As DataSet
            Dim adp, adp1, adp2, adp3, adp4, adp5, adp6 As SqlDataAdapter
            Dim dtable, dtable1, dtable2, dtable3, dtable4, dtable5, dtable6 As DataTable
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select * from InvoiceInfo where InvoiceDate >=@d1 and InvoiceDate < @d2"
            cmd5 = New SqlCommand(ct)
            cmd5.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd5.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd5.Connection = con
            rdr = cmd5.ExecuteReader()
            If Not rdr.Read() Then
                MessageBox.Show("Sorry..No record found between selected dates", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT * from Company", con)
            adp = New SqlDataAdapter(cmd)
            cmd1 = New SqlCommand("SELECT Registration.UserID,Sum(GrandTotal) as [GrandTotal] from Registration,POS_OpeningCash,InvoiceInfo where Registration.UserID=POS_OpeningCash.UserID and InvoiceInfo.OpenID=POS_OpeningCash.OpenID and InvoiceDate >=@d1 and InvoiceDate < @d2 group by Registration.UserID order by 1", con)
            cmd1.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd1.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            adp1 = New SqlDataAdapter(cmd1)
            cmd2 = New SqlCommand("SELECT Category,Sum(TotalAmount) as Total from InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Category ON Product.Category = Category.CategoryName where InvoiceDate >=@d3 and InvoiceDate < @d4 group by Category order by 1", con)
            cmd2.Parameters.Add("@d3", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd2.Parameters.Add("@d4", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            adp2 = New SqlDataAdapter(cmd2)
            cmd3 = New SqlCommand("SELECT Category,Sum(Qty) as TotalQuantity from InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID INNER JOIN Category ON Product.Category = Category.CategoryName where InvoiceDate >=@d5 and InvoiceDate < @d6 group by Category order by 1", con)
            cmd3.Parameters.Add("@d5", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd3.Parameters.Add("@d6", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            adp3 = New SqlDataAdapter(cmd3)
            cmd4 = New SqlCommand("SELECT ProductName,Sum(Qty) as [Quantity],Sum(TotalAmount) as [Amount] from InvoiceInfo INNER JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID INNER JOIN Product ON Invoice_Product.ProductID = Product.PID where InvoiceDate >=@d7 and InvoiceDate < @d8 group by ProductName order by 1", con)
            cmd4.Parameters.Add("@d7", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd4.Parameters.Add("@d8", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            adp4 = New SqlDataAdapter(cmd4)
            cmd6 = New SqlCommand("SELECT PaymentMode,Sum(GrandTotal) as [GrandTotal] from InvoiceInfo where InvoiceDate >=@d11 and InvoiceDate < @d12 group by PaymentMode order by 1", con)
            cmd6.Parameters.Add("@d11", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd6.Parameters.Add("@d12", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            adp5 = New SqlDataAdapter(cmd6)
            cmd7 = New SqlCommand("SELECT TillDetails,Sum(GrandTotal) as [GrandTotal] from POS_OpeningCash,InvoiceInfo where InvoiceInfo.OpenID=POS_OpeningCash.OpenID and InvoiceDate >=@d9 and InvoiceDate < @d10 group by TillDetails order by 1", con)
            cmd7.Parameters.Add("@d9", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd7.Parameters.Add("@d10", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            adp6 = New SqlDataAdapter(cmd7)

            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT IsNULL(Sum(GrandTotal),0) from InvoiceInfo where InvoiceDate >=@d1 and InvoiceDate < @d2 and PaymentMode='Cash'"
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                b1 = rdr.GetValue(0)
            Else
                b1 = 0
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If

            con = New SqlConnection(cs)
            con.Open()
            cmd = con.CreateCommand()
            cmd.CommandText = "SELECT IsNULL(Sum(GrandTotal),0) from SalesReturn where Date >=@d3 and Date < @d4"
            cmd.Parameters.Add("@d3", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d4", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                b2 = rdr.GetValue(0)
            Else
                b2 = 0
            End If
            If (rdr IsNot Nothing) Then
                rdr.Close()
            End If
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            dtable = New DataTable()
            dtable1 = New DataTable()
            dtable2 = New DataTable()
            dtable3 = New DataTable()
            dtable4 = New DataTable()
            dtable5 = New DataTable()
            dtable6 = New DataTable()
            adp.Fill(dtable)
            adp1.Fill(dtable1)
            adp2.Fill(dtable2)
            adp3.Fill(dtable3)
            adp4.Fill(dtable4)
            adp5.Fill(dtable5)
            adp6.Fill(dtable6)
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.Tables.Add(dtable1)
            ds.Tables.Add(dtable2)
            ds.Tables.Add(dtable3)
            ds.Tables.Add(dtable4)
            ds.Tables.Add(dtable5)
            ds.Tables.Add(dtable6)
            ds.WriteXmlSchema("POSReport.xml")
            Dim rpt As New rptRPOS
            rpt.Subreports(0).SetDataSource(ds)
            rpt.Subreports(1).SetDataSource(ds)
            rpt.Subreports(2).SetDataSource(ds)
            rpt.Subreports(3).SetDataSource(ds)
            rpt.Subreports(4).SetDataSource(ds)
            rpt.Subreports(5).SetDataSource(ds)
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            rpt.SetParameterValue("p3", b1)
            rpt.SetParameterValue("p4", b2)
            frmPOSReport_CRViewer.dtpDateFrom.Value = dtpDateFrom.Value
            frmPOSReport_CRViewer.dtpDateTo.Value = dtpDateTo.Value
            frmPOSReport_CRViewer.txtEmailID.Text = ""
            frmPOSReport_CRViewer.CrystalReportViewer1.ReportSource = rpt
            frmPOSReport_CRViewer.ShowDialog()
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
