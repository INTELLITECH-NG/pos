Imports System.Data.SqlClient
Public Class frmPOSRecord1

    Private Sub dgw_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                If lblSet.Text = "SR" Then
                    Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                    'frmSalesReturn.Reset()
                    frmSalesReturn.Show()
                    Me.Hide()
                    frmSalesReturn.txtSalesID.Text = dr.Cells(0).Value.ToString()
                    frmSalesReturn.txtSalesInvoiceNo.Text = dr.Cells(1).Value.ToString()
                    frmSalesReturn.txtSalesDate.Text = dr.Cells(2).Value.ToString()
                    frmSalesReturn.txtPaymentMode.Text = dr.Cells(6).Value.ToString()
                    frmSalesReturn.txtTaxType.Text = dr.Cells(14).Value.ToString()
                    If dr.Cells(6).Value = "Credit Customer" Then
                        frmSalesReturn.lblCustomer.Visible = True
                        frmSalesReturn.lblCustomerName.Visible = True
                        frmSalesReturn.txtCC_ID.Text = dr.Cells(15).Value.ToString()
                        frmSalesReturn.txtCreditCustomerID.Text = dr.Cells(9).Value.ToString()
                        frmSalesReturn.lblCustomerName.Text = dr.Cells(10).Value.ToString()
                    Else
                        frmSalesReturn.lblCustomer.Visible = False
                        frmSalesReturn.lblCustomerName.Visible = False
                        frmSalesReturn.txtCC_ID.Text = ""
                        frmSalesReturn.txtCreditCustomerID.Text = ""
                        frmSalesReturn.lblCustomerName.Text = ""
                    End If
                    frmSalesReturn.txtTaxType.Text = dr.Cells(14).Value.ToString()
                    con = New SqlConnection(cs)
                    con.Open()
                    Dim sql As String = "SELECT distinct Product.PID, RTRIM(Product.ProductCode), RTRIM(Product.ProductName), RTRIM(Invoice_Product.Barcode), RTRIM(Invoice_Product.MfgDate), RTRIM(Invoice_Product.ExpiryDate), Invoice_Product.Qty - ISNULL(SUM(SalesReturn_Join.ReturnQty), 0),RTRIM(Product.SalesUnit),Invoice_Product.SalesRate, Invoice_Product.DiscountPer,Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.TotalAmount FROM  InvoiceInfo Left JOIN Invoice_Product ON InvoiceInfo.Inv_ID = Invoice_Product.InvoiceID Left JOIN Product ON Invoice_Product.ProductID = Product.PID Left JOIN SalesReturn ON InvoiceInfo.Inv_ID = SalesReturn.SalesID Left JOIN SalesReturn_Join ON Product.PID = SalesReturn_Join.ProductID AND SalesReturn.SR_ID = SalesReturn_Join.SalesReturnID Where INV_ID=" & Val(dr.Cells(0).Value) & " group by Product.PID, RTRIM(Product.ProductCode), RTRIM(Product.ProductName), RTRIM(Invoice_Product.Barcode), RTRIM(Invoice_Product.MfgDate), RTRIM(Invoice_Product.ExpiryDate),Invoice_Product.Qty,RTRIM(Product.SalesUnit),Invoice_Product.SalesRate, Invoice_Product.DiscountPer,Invoice_Product.Discount, Invoice_Product.VATPer, Invoice_Product.VAT, Invoice_Product.TotalAmount having(Invoice_Product.Qty - ISNULL(SUM(SalesReturn_Join.ReturnQty), 0)) > 0 order by 3"
                    cmd = New SqlCommand(sql, con)
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                    frmSalesReturn.DataGridView1.Rows.Clear()
                    While (rdr.Read() = True)
                        frmSalesReturn.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
                    End While
                    con.Close()
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
    Sub FillDataGridview()
        Try

            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID,RTRIM(InvoiceNo),InvoiceDate,Pos_OpeningCash.OpenID,RTRIM(UserID),RTRIM(TillDetails),RTRIM(PaymentMode),RTRIM(CurrencyCode),ExchangeRate,RTRIM(CreditCustomerID),RTRIM(Name),GrandTotal,Cash,Change,RTRIM(TaxType),CC_ID from InvoiceInfo LEFT OUTER JOIN POS_OpeningCash ON InvoiceInfo.OpenID=POS_OpeningCash.OpenID LEFT OUTER JOIN CreditCustomer ON InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID where (DATEDIFF(d,InvoiceDate,GetDate())= 0) Order by InvoiceDate", con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub GetData()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID,RTRIM(InvoiceNo),InvoiceDate,Pos_OpeningCash.OpenID,RTRIM(UserID),RTRIM(TillDetails),RTRIM(PaymentMode),RTRIM(CurrencyCode),ExchangeRate,RTRIM(CreditCustomerID),RTRIM(Name),GrandTotal,Cash,Change,RTRIM(TaxType),CC_ID from InvoiceInfo LEFT OUTER JOIN POS_OpeningCash ON InvoiceInfo.OpenID=POS_OpeningCash.OpenID LEFT OUTER JOIN CreditCustomer ON InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID Order by InvoiceDate", con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
        txtUserID.Text = ""
        txtTillID.Text = ""
        txtPaymentMode.Text = ""
        FillDataGridview()
    End Sub

    Private Sub frmPOSWorkPeriod_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Reset()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID,RTRIM(InvoiceNo),InvoiceDate,Pos_OpeningCash.OpenID,RTRIM(UserID),RTRIM(TillDetails),RTRIM(PaymentMode),RTRIM(CurrencyCode),ExchangeRate,RTRIM(CreditCustomerID),RTRIM(Name),GrandTotal,Cash,Change,RTRIM(TaxType),CC_ID from InvoiceInfo LEFT OUTER JOIN POS_OpeningCash ON InvoiceInfo.OpenID=POS_OpeningCash.OpenID LEFT OUTER JOIN CreditCustomer ON InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID where OpeningDate >=@d1 and OpeningDate < @d2 Order by InvoiceDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnShowAll_Click(sender As System.Object, e As System.EventArgs) Handles btnShowAll.Click
        If MessageBox.Show("Do you really want to load all the records?" & vbCrLf & "It will take time to load the records based on no. of records in database.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            GetData()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub txtUserID_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtUserID.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select Inv_ID,RTRIM(InvoiceNo),InvoiceDate,Pos_OpeningCash.OpenID,RTRIM(UserID),RTRIM(TillDetails),RTRIM(PaymentMode),RTRIM(CurrencyCode),ExchangeRate,RTRIM(CreditCustomerID),RTRIM(Name),GrandTotal,Cash,Change,RTRIM(TaxType),CC_ID from InvoiceInfo LEFT OUTER JOIN POS_OpeningCash ON InvoiceInfo.OpenID=POS_OpeningCash.OpenID LEFT OUTER JOIN CreditCustomer ON InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID where UserID like '" & txtUserID.Text & "%' Order by InvoiceDate", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtTillID_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtTillID.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select Inv_ID,RTRIM(InvoiceNo),InvoiceDate,Pos_OpeningCash.OpenID,RTRIM(UserID),RTRIM(TillDetails),RTRIM(PaymentMode),RTRIM(CurrencyCode),ExchangeRate,RTRIM(CreditCustomerID),RTRIM(Name),GrandTotal,Cash,Change,RTRIM(TaxType),CC_ID from InvoiceInfo LEFT OUTER JOIN POS_OpeningCash ON InvoiceInfo.OpenID=POS_OpeningCash.OpenID LEFT OUTER JOIN CreditCustomer ON InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID where TillDetails like '" & txtTillID.Text & "%' Order by InvoiceDate", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtPaymentMode_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPaymentMode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select Inv_ID,RTRIM(InvoiceNo),InvoiceDate,Pos_OpeningCash.OpenID,RTRIM(UserID),RTRIM(TillDetails),RTRIM(PaymentMode),RTRIM(CurrencyCode),ExchangeRate,RTRIM(CreditCustomerID),RTRIM(Name),GrandTotal,Cash,Change,RTRIM(TaxType),CC_ID from InvoiceInfo LEFT OUTER JOIN POS_OpeningCash ON InvoiceInfo.OpenID=POS_OpeningCash.OpenID LEFT OUTER JOIN CreditCustomer ON InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID where PaymentMode like '" & txtPaymentMode.Text & "%' Order by InvoiceDate", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
