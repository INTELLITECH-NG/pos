Imports System.Data.SqlClient
Public Class frmBarcodeLabelPrinting
    Dim st As String
    Sub FillCompany()
        con = New SqlConnection(cs)
        con.Open()
        Dim sql1 As String = "Select RTRIM(CompanyName),RTRIM(CurrencyCode) from Company"
        cmd = New SqlCommand(sql1, con)
        rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        If (rdr.Read() = True) Then
            txtCompany.Text = rdr.GetValue(0).ToString()
            txtCurrencyCode.Text = rdr.GetValue(1).ToString()
        End If
        con.Close()
    End Sub
    Sub GetData()
        Try
            Cursor = Cursors.WaitCursor
            Timer1.Enabled = True
            SqlConnection.ClearAllPools()
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock_Company.Barcode),SalesRate,Qty from Product,Temp_Stock_Company where Temp_Stock_Company.ProductID=Product.PID  order by Productname", con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader()
            listView1.Items.Clear()
            While rdr.Read()
                Dim item = New ListViewItem()
                item.Text = rdr(0).ToString().Trim()
                item.SubItems.Add(rdr(1).ToString().Trim())
                item.SubItems.Add(rdr(2).ToString().Trim())
                item.SubItems.Add(rdr(3).ToString().Trim())
                item.SubItems.Add(rdr(4).ToString().Trim())
                item.SubItems.Add(rdr(5).ToString().Trim())
                listView1.Items.Add(item)
            End While
            For i = 0 To listView1.Items.Count - 1
                listView1.Items(i).Checked = True
            Next
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnGenerateBarcode_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerateBarcode.Click

        If listView1.Items.Count = 0 Then
            MessageBox.Show("There is no product in listview to generate barcode ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If txtNoOfCopies.Text = "" Then
            MessageBox.Show("Please enter no. of copies", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNoOfCopies.Focus()
            Exit Sub
        End If
        If Val(txtNoOfCopies.Text) = 0 Then
            MessageBox.Show("No. of copies must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNoOfCopies.Focus()
            Exit Sub
        End If
        Try
            If listView1.CheckedItems.Count > 0 Then
                Dim Condition As String = ""
                Dim Condition1 As String = ""
                For I = 0 To listView1.CheckedItems.Count - 1
                    Condition += String.Format("'{0}',", listView1.CheckedItems(I).Text)
                    Condition1 += String.Format("'{0}',", listView1.CheckedItems(I).SubItems(3).Text)
                Next
                Condition = Condition.Substring(0, Condition.Length - 1)
                Condition1 = Condition1.Substring(0, Condition1.Length - 1)
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim st As String = "Select Temp_Stock_Company.Barcode,Product.Productname,SalesRate from Product,Temp_Stock_Company where Temp_Stock_Company.ProductID=Product.PID and ProductCode in (" & Condition & ") and Temp_Stock_Company.Barcode in (" & Condition1 & ") "
                For j As Integer = 1 To Int32.Parse(Val(txtNoOfCopies.Text)) - 1
                    st = st & "Union all Select Temp_Stock_Company.Barcode,Product.Productname,SalesRate from Product,Temp_Stock_Company where Temp_Stock_Company.ProductID=Product.PID and ProductCode in (" & Condition & ") and Temp_Stock_Company.Barcode in (" & Condition1 & ")"
                Next
                cmd = New SqlCommand(st, con)
                adp = New SqlDataAdapter(cmd)
                dtable = New DataTable()
                adp.Fill(dtable)
                con.Close()
                ds = New DataSet()
                ds.Tables.Add(dtable)
                ds.WriteXmlSchema("BarcodeLabelPrinting1.xml")
                Dim rpt As New rptBarcodeLabelPrinting
                rpt.SetDataSource(ds)
                rpt.SetParameterValue("p1", txtCompany.Text)
                rpt.SetParameterValue("p2", txtCurrencyCode.Text)
                frmReport.CrystalReportViewer1.ReportSource = rpt
                frmReport.ShowDialog()
                rpt.Close()
                rpt.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Sub Reset()
        txtCategory.Text = ""
        txtProductName.Text = ""
        txtBarcode.Text = ""
        txtNoOfCopies.Text = 1
        listView1.Items.Clear()
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub frmBarcodeLabelPrinting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FillCompany()
    End Sub

    Private Sub txtProductName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtProductName.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock_Company.Barcode),SalesRate,Qty from Product,Temp_Stock_Company where Temp_Stock_Company.ProductID=Product.PID  and ProductName like '" & txtProductName.Text & "%' order by Productname", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader()
                listView1.Items.Clear()
                While rdr.Read()
                    Dim item = New ListViewItem()
                    item.Text = rdr(0).ToString().Trim()
                    item.SubItems.Add(rdr(1).ToString().Trim())
                    item.SubItems.Add(rdr(2).ToString().Trim())
                    item.SubItems.Add(rdr(3).ToString().Trim())
                    item.SubItems.Add(rdr(4).ToString().Trim())
                    item.SubItems.Add(rdr(5).ToString().Trim())

                    listView1.Items.Add(item)
                End While
                For i = 0 To listView1.Items.Count - 1
                    listView1.Items(i).Checked = True
                Next
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtCategory_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCategory.KeyDown

        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock_Company.Barcode),SalesRate,Qty from Product,Temp_Stock_Company where Temp_Stock_Company.ProductID=Product.PID  and Category like '" & txtCategory.Text & "%' order by Productname", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader()
                listView1.Items.Clear()
                While rdr.Read()
                    Dim item = New ListViewItem()
                    item.Text = rdr(0).ToString().Trim()
                    item.SubItems.Add(rdr(1).ToString().Trim())
                    item.SubItems.Add(rdr(2).ToString().Trim())
                    item.SubItems.Add(rdr(3).ToString().Trim())
                    item.SubItems.Add(rdr(4).ToString().Trim())
                    item.SubItems.Add(rdr(5).ToString().Trim())

                    listView1.Items.Add(item)
                End While
                For i = 0 To listView1.Items.Count - 1
                    listView1.Items(i).Checked = True
                Next
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub txtNoOfCopies_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoOfCopies.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Cursor = Cursors.Default
        Timer1.Enabled = False
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If listView1.Items.Count = 0 Then
            MessageBox.Show("There is no product in listview to generate barcode ", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        If txtNoOfCopies.Text = "" Then
            MessageBox.Show("Please enter no. of copies", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNoOfCopies.Focus()
            Exit Sub
        End If
        If Val(txtNoOfCopies.Text) = 0 Then
            MessageBox.Show("No. of copies must be greater than zero", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNoOfCopies.Focus()
            Exit Sub
        End If
        Try
            If listView1.CheckedItems.Count > 0 Then
                Dim Condition As String = ""
                Dim Condition1 As String = ""
                For I = 0 To listView1.CheckedItems.Count - 1
                    Condition += String.Format("'{0}',", listView1.CheckedItems(I).Text)
                    Condition1 += String.Format("'{0}',", listView1.CheckedItems(I).SubItems(3).Text)
                Next
                Condition = Condition.Substring(0, Condition.Length - 1)
                Condition1 = Condition1.Substring(0, Condition1.Length - 1)
                Cursor = Cursors.WaitCursor
                Timer1.Enabled = True
                con = New SqlConnection(cs)
                con.Open()
                Dim st As String = "Select Temp_Stock_Company.Barcode,Product.Productname,SalesRate from Product,Temp_Stock_Company where Temp_Stock_Company.ProductID=Product.PID and ProductCode in (" & Condition & ") and Temp_Stock_Company.Barcode in (" & Condition1 & ") "
                For j As Integer = 1 To Int32.Parse(Val(txtNoOfCopies.Text)) - 1
                    st = st & "Union all Select Temp_Stock_Company.Barcode,Product.Productname,SalesRate from Product,Temp_Stock_Company where Temp_Stock_Company.ProductID=Product.PID and ProductCode in (" & Condition & ") and Temp_Stock_Company.Barcode in (" & Condition1 & ")"
                Next
                cmd = New SqlCommand(st, con)
                adp = New SqlDataAdapter(cmd)
                dtable = New DataTable()
                adp.Fill(dtable)
                con.Close()
                ds = New DataSet()
                ds.Tables.Add(dtable)
                ds.WriteXmlSchema("BarcodeLabelPrinting1.xml")
                Dim rpt As New rptBarcodeLabelPrinting1
                rpt.SetDataSource(ds)
                rpt.SetParameterValue("p1", txtCompany.Text)
                rpt.SetParameterValue("p2", txtCurrencyCode.Text)
                frmReport.CrystalReportViewer1.ReportSource = rpt
                frmReport.ShowDialog()
                rpt.Close()
                rpt.Dispose()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnShowAll_Click(sender As System.Object, e As System.EventArgs) Handles btnShowAll.Click
        If MessageBox.Show("Do you really want to load all the records?" & vbCrLf & "It will take time to load the records based on no. of records in database.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
            GetData()
        End If
    End Sub

    Private Sub txtBarcode_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                con = New SqlConnection(cs)
                con.Open()
                cmd = New SqlCommand("Select RTRIM(ProductCode),RTRIM(ProductName),RTRIM(Category),RTRIM(Temp_Stock_Company.Barcode),SalesRate,Qty from Product,Temp_Stock_Company where Temp_Stock_Company.ProductID=Product.PID and Temp_Stock_Company.Barcode like '" & txtBarcode.Text & "%' order by Productname", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader()
                listView1.Items.Clear()
                While rdr.Read()
                    Dim item = New ListViewItem()
                    item.Text = rdr(0).ToString().Trim()
                    item.SubItems.Add(rdr(1).ToString().Trim())
                    item.SubItems.Add(rdr(2).ToString().Trim())
                    item.SubItems.Add(rdr(3).ToString().Trim())
                    item.SubItems.Add(rdr(4).ToString().Trim())
                    item.SubItems.Add(rdr(5).ToString().Trim())

                    listView1.Items.Add(item)
                End While
                For i = 0 To listView1.Items.Count - 1
                    listView1.Items(i).Checked = True
                Next
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class