Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports CrystalDecisions.Shared

Public Class frmPOSReport_CRViewer
    Dim b1, b2 As Double
    Private Sub btnSendMail_Click(sender As System.Object, e As System.EventArgs) Handles btnSendMail.Click
        Try
            If txtEmailID.Text = "" Then
                MessageBox.Show("Please enter Email ID", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtEmailID.Focus()
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "select count(*) from EmailSetting Having count(*) <=0"
            cmd = New SqlCommand(sql)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read() Then
                frmCustomDialog15.ShowDialog()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            con.Close()
            If CheckForInternetConnection() = True Then
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim ctn As String = "select RTRIM(Username),RTRIM(Password),RTRIM(SMTPAddress),(Port) from EmailSetting where IsDefault='Yes' and IsActive='Yes'"
                cmd = New SqlCommand(ctn)
                cmd.Connection = con
                Dim rdr1 As SqlDataReader
                rdr1 = cmd.ExecuteReader()
                If rdr1.Read() Then

                    If (Not System.IO.Directory.Exists(Application.StartupPath & "\PDF Reports")) Then
                        System.IO.Directory.CreateDirectory(Application.StartupPath & "\PDF Reports")
                    End If
                    Dim pdfFile As String = Application.StartupPath & "\PDF Reports\POSReport " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") + ".Pdf"
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
                    rpt.ExportToDisk(ExportFormatType.PortableDocFormat, pdfFile)
                    SendMail1(rdr1.GetValue(0), txtEmailID.Text, "Please find the attachment below", pdfFile, "POS Report", rdr1.GetValue(2), rdr1.GetValue(3), rdr1.GetValue(0), Decrypt(rdr1.GetValue(1)))
                    If (rdr1 IsNot Nothing) Then
                        rdr1.Close()
                    End If
                    rpt.Close()
                    rpt.Dispose()
                    MessageBox.Show("Successfully send", "Mail", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtEmailID_Validating(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles txtEmailID.Validating
        Dim pattern As String = "^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"
        Dim match As System.Text.RegularExpressions.Match = Regex.Match(txtEmailID.Text.Trim(), pattern, RegexOptions.IgnoreCase)
        If (match.Success) Then
        Else
            MessageBox.Show("Please enter a valid email id", "Checking", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtEmailID.Clear()
        End If
    End Sub

    Private Sub txtEmailID_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmailID.KeyPress
        Dim ac As String = "@"
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Asc(e.KeyChar) < 97 Or Asc(e.KeyChar) > 122 Then
                If Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 95 Then
                    If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                        If ac.IndexOf(e.KeyChar) = -1 Then
                            e.Handled = True

                        Else

                            If txtEmailID.Text.Contains("@") And e.KeyChar = "@" Then
                                e.Handled = True
                            End If

                        End If


                    End If
                End If
            End If

        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub
End Class