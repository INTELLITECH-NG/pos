Imports System.Data.SqlClient


Public Class frmSalesmanCommmissionReport

   
    Sub Reset()
        dtpDateFrom.Value = Today
        dtpDateTo.Value = Today
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub


    Private Sub btnClose_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "Select * FROM InvoiceInfo INNER JOIN SalesMan ON InvoiceInfo.SalesmanID = SalesMan.SM_ID INNER JOIN Salesman_Commission ON InvoiceInfo.Inv_ID = Salesman_Commission.InvoiceID where InvoiceDate >=@d1 and InvoiceDate < @d2"
            cmd = New SqlCommand(ct)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
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
            cmd = New SqlCommand("Select Salesman_ID,Name,City,ContactNo,Sum(Commission) FROM InvoiceInfo INNER JOIN SalesMan ON InvoiceInfo.SalesmanID = SalesMan.SM_ID INNER JOIN Salesman_Commission ON InvoiceInfo.Inv_ID = Salesman_Commission.InvoiceID where InvoiceDate >=@d1 and InvoiceDate < @d2 group by Salesman_ID,Name,City,ContactNo order by Name", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "DateIN").Value = dtpDateTo.Value.Date.AddDays(1)
            adp = New SqlDataAdapter(cmd)
            dtable = New DataTable()
            adp.Fill(dtable)
            con.Close()
            ds = New DataSet()
            ds.Tables.Add(dtable)
            ds.WriteXmlSchema("SalesmanCommissionReport.xml")
            Dim rpt As New rptSalesmanCommission
            rpt.SetDataSource(ds)
            rpt.SetParameterValue("p1", dtpDateFrom.Value.Date)
            rpt.SetParameterValue("p2", dtpDateTo.Value.Date)
            frmReport.CrystalReportViewer1.ReportSource = rpt
            frmReport.ShowDialog()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
