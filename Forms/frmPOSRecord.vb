Imports System.Data.SqlClient
Public Class frmPOSRecord


    Private Sub DeleteRecord()

        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "select SalesID from InvoiceInfo,SalesReturn where InvoiceInfo.Inv_ID=SalesReturn.SalesID and SalesID=@d1"
            cmd = New SqlCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtInv_ID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Sales Return", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from InvoiceInfo where Inv_ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", Val(txtInv_ID.Text))
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                For Each row As DataGridViewRow In DataGridView1.Rows
                    If Not row.IsNewRow Then
                        con = New SqlConnection(cs)
                        con.Open()
                        Dim cb4 As String = "update Temp_stock_Company set qty = qty + (" & row.Cells(2).Value & ") where ProductID=@d1 and Barcode=@d2"
                        cmd = New SqlCommand(cb4)
                        cmd.Connection = con
                        cmd.Parameters.AddWithValue("@d1", Val(row.Cells(0).Value))
                        cmd.Parameters.AddWithValue("@d2", row.Cells(1).Value)
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                Next
                LedgerDelete(txtInvoiceNo.Text, "POS")
                LedgerDelete(txtInvoiceNo.Text, "Sales Invoice")
                Dim st As String = "deleted the sales invoice having invoice no. '" & txtInvoiceNo.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                FillDataGridview()
                btnDelete.Enabled = False
                Reset()
            Else
                MessageBox.Show("No Record found", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If con.State = ConnectionState.Open Then
                con.Close()

            End If
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

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtInv_ID.Text = dr.Cells(0).Value.ToString()
                txtInvoiceNo.Text = dr.Cells(1).Value.ToString()
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "SELECT ProductID,RTRIM(Barcode),Qty from InvoiceInfo,Invoice_Product where InvoiceInfo.Inv_ID=Invoice_Product.InvoiceID and INV_ID=" & dr.Cells(0).Value & ""
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                Me.DataGridView1.Rows.Clear()
                While (rdr.Read() = True)
                    Me.DataGridView1.Rows.Add(rdr(0), rdr(1), rdr(2))
                End While
                con.Close()
                btnDelete.Enabled = True
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
            cmd = New SqlCommand("Select Inv_ID,RTRIM(InvoiceNo),InvoiceDate,Pos_OpeningCash.OpenID,RTRIM(UserID),RTRIM(TillDetails),RTRIM(PaymentMode),RTRIM(CurrencyCode),ExchangeRate,RTRIM(CreditCustomerID),RTRIM(Name),GrandTotal,Cash,Change from InvoiceInfo LEFT OUTER JOIN POS_OpeningCash ON InvoiceInfo.OpenID=POS_OpeningCash.OpenID LEFT OUTER JOIN CreditCustomer ON InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID where (DATEDIFF(d,InvoiceDate,GetDate())= 0) Order by InvoiceDate", con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
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
            cmd = New SqlCommand("Select Inv_ID,RTRIM(InvoiceNo),InvoiceDate,Pos_OpeningCash.OpenID,RTRIM(UserID),RTRIM(TillDetails),RTRIM(PaymentMode),RTRIM(CurrencyCode),ExchangeRate,RTRIM(CreditCustomerID),RTRIM(Name),GrandTotal,Cash,Change from InvoiceInfo LEFT OUTER JOIN POS_OpeningCash ON InvoiceInfo.OpenID=POS_OpeningCash.OpenID LEFT OUTER JOIN CreditCustomer ON InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID Order by InvoiceDate", con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
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
        txtInv_ID.Text = ""
        txtInvoiceNo.Text = ""
        txtTillID.Text = ""
        txtPaymentMode.Text = ""
        btnDelete.Enabled = False
        FillDataGridview()
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub frmPOSWorkPeriod_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillDataGridview()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select Inv_ID,RTRIM(InvoiceNo),InvoiceDate,Pos_OpeningCash.OpenID,RTRIM(UserID),RTRIM(TillDetails),RTRIM(PaymentMode),RTRIM(CurrencyCode),ExchangeRate,RTRIM(CreditCustomerID),RTRIM(Name),GrandTotal,Cash,Change from InvoiceInfo LEFT OUTER JOIN POS_OpeningCash ON InvoiceInfo.OpenID=POS_OpeningCash.OpenID LEFT OUTER JOIN CreditCustomer ON InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID where OpeningDate >=@d1 and OpeningDate < @d2 Order by InvoiceDate", con)
            cmd.CommandTimeout = 0
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
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
                cmd = New SqlCommand("Select Inv_ID,RTRIM(InvoiceNo),InvoiceDate,Pos_OpeningCash.OpenID,RTRIM(UserID),RTRIM(TillDetails),RTRIM(PaymentMode),RTRIM(CurrencyCode),ExchangeRate,RTRIM(CreditCustomerID),RTRIM(Name),GrandTotal,Cash,Change from InvoiceInfo LEFT OUTER JOIN POS_OpeningCash ON InvoiceInfo.OpenID=POS_OpeningCash.OpenID LEFT OUTER JOIN CreditCustomer ON InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID where UserID like '" & txtUserID.Text & "%' Order by InvoiceDate", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
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
                cmd = New SqlCommand("Select Inv_ID,RTRIM(InvoiceNo),InvoiceDate,Pos_OpeningCash.OpenID,RTRIM(UserID),RTRIM(TillDetails),RTRIM(PaymentMode),RTRIM(CurrencyCode),ExchangeRate,RTRIM(CreditCustomerID),RTRIM(Name),GrandTotal,Cash,Change from InvoiceInfo LEFT OUTER JOIN POS_OpeningCash ON InvoiceInfo.OpenID=POS_OpeningCash.OpenID LEFT OUTER JOIN CreditCustomer ON InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID where TillDetails like '" & txtTillID.Text & "%' Order by InvoiceDate", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
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
                cmd = New SqlCommand("Select Inv_ID,RTRIM(InvoiceNo),InvoiceDate,Pos_OpeningCash.OpenID,RTRIM(UserID),RTRIM(TillDetails),RTRIM(PaymentMode),RTRIM(CurrencyCode),ExchangeRate,RTRIM(CreditCustomerID),RTRIM(Name),GrandTotal,Cash,Change from InvoiceInfo LEFT OUTER JOIN POS_OpeningCash ON InvoiceInfo.OpenID=POS_OpeningCash.OpenID LEFT OUTER JOIN CreditCustomer ON InvoiceInfo.Member_ID=CreditCustomer.CreditCustomerID where PaymentMode like '" & txtPaymentMode.Text & "%' Order by InvoiceDate", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
