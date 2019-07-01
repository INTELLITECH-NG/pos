Imports System.Data.SqlClient
Public Class frmProductLocation
    Sub fillCombo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(RackNo) FROM Racking where Active='Yes' Order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbRackNo.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbRackNo.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        cmbRackNo.SelectedIndex = -1
        txtProductName.Text = ""
        txtProductCode.Text = ""
        txtSearchByProductName.Text = ""
        txtSearchByRackNo.Text = ""
        txtPosition.Text = ""
        cmbRackNo.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub
  
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(cmbRackNo.Text)) = 0 Then
            MessageBox.Show("Please select Rack No.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRackNo.Focus()
            Exit Sub
        End If
        If Len(Trim(txtProductName.Text)) = 0 Then
            MessageBox.Show("Please retrieve Product name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPosition.Text)) = 0 Then
            MessageBox.Show("Please enter Shelf Position", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPosition.Focus()
            Exit Sub
        End If

        
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into ProductLocation(RackNo,productID,ShelfPosition) VALUES (@d1,@d2,@d3)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRackNo.Text)
            cmd.Parameters.AddWithValue("@d2", Val(txtPID.Text))
            cmd.Parameters.AddWithValue("@d3", txtPosition.Text)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the new Product Location in Rack for Product '" & txtProductName.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata()
            Reset()
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
    Private Sub DeleteRecord()

        Try

            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from ProductLocation where ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "Deleted the Product Location in Rack for Product '" & txtProductName.Text & "'"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully deleted", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Getdata()
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

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Len(Trim(cmbRackNo.Text)) = 0 Then
            MessageBox.Show("Please select Rack No.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbRackNo.Focus()
            Exit Sub
        End If
        If Len(Trim(txtProductName.Text)) = 0 Then
            MessageBox.Show("Please retrieve Product name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProductName.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPosition.Text)) = 0 Then
            MessageBox.Show("Please enter Shelf Position", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPosition.Focus()
            Exit Sub
        End If


        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update ProductLocation set RackNo=@d1,productID=@d2,ShelfPosition=@d3 where ID=" & Val(txtID.Text) & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", cmbRackNo.Text)
            cmd.Parameters.AddWithValue("@d2", Val(txtPID.Text))
            cmd.Parameters.AddWithValue("@d3", txtPosition.Text)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "Updated the Product Location in Rack for Product '" & txtProductName.Text & "'"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ID, RTRIM(RackNo),PID,RTRIM(ProductCode),RTRIM(ProductName),RTRIM(ShelfPosition) from Product,ProductLocation where Product.PID=ProductLocation.ProductID order by ProductName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Reset()
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

    Private Sub frmWarehouse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
        fillCombo()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtPosition.Text = dr.Cells(5).Value.ToString()
                txtID.Text = dr.Cells(0).Value.ToString()
                cmbRackNo.Text = dr.Cells(1).Value.ToString()
                txtPID.Text = dr.Cells(2).Value.ToString()
                txtProductCode.Text = dr.Cells(3).Value.ToString()
                txtProductName.Text = dr.Cells(4).Value.ToString()
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearchByProductName_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByProductName.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ID, RTRIM(RackNo),PID,RTRIM(ProductCode),RTRIM(ProductName),RTRIM(ShelfPosition) from Product,ProductLocation where Product.PID=ProductLocation.ProductID and ProductName like '%" & txtSearchByProductName.Text & "%' order by ProductName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearchByRackNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByRackNo.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT ID, RTRIM(RackNo),PID,RTRIM(ProductCode),RTRIM(ProductName),RTRIM(ShelfPosition) from Product,ProductLocation where Product.PID=ProductLocation.ProductID and RackNo like '%" & txtSearchByRackNo.Text & "%' order by ProductName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSelection_Click(sender As System.Object, e As System.EventArgs) Handles btnSelection.Click
        frmProductsRecord.lblSet.Text = "Product Location"
        frmProductsRecord.Reset()
        frmProductsRecord.ShowDialog()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class
