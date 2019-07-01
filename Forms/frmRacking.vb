Imports System.Data.SqlClient
Public Class frmRacking
    Dim st1 As String
    Sub Reset()
        txtNoOfShelves.Text = ""
        chkActive.Checked = True
        txtSearchByRackNo.Text = ""
        txtRackNo.Text = ""
        txtRackNo.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub
 
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtRackNo.Text)) = 0 Then
            MessageBox.Show("Please enter rack no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRackNo.Focus()
            Exit Sub
        End If
        If Len(Trim(txtNoOfShelves.Text)) = 0 Then
            MessageBox.Show("Please enter no. of shelves", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNoOfShelves.Focus()
            Exit Sub
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select RackNo from Racking where RackNo=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtRackNo.Text)
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                MessageBox.Show("Rack No. Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRackNo.Text = ""
                txtRackNo.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If
            If chkActive.Checked = True Then
                st1 = "Yes"
            Else
                st1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Racking(RackNo,NoOfShelves,Active) VALUES (@d1,@d2,@d3)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtRackNo.Text)
            cmd.Parameters.AddWithValue("@d2", Val(txtNoOfShelves.Text))
            cmd.Parameters.AddWithValue("@d3", st1)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "added the new Rack having Rack No. '" & txtRackNo.Text & "'"
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
            Dim cl2 As String = "select Racking.RackNo from Racking,ProductLocation where Racking.RackNo=ProductLocation.RackNo and Racking.RackNo=@d1"
            cmd = New SqlCommand(cl2)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtRackNo.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Products Location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Racking where RackNo=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtRackNo.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the Rack having Rack No. '" & txtRackNo.Text & "'"
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
        If Len(Trim(txtRackNo.Text)) = 0 Then
            MessageBox.Show("Please enter rack no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRackNo.Focus()
            Exit Sub
        End If
        If Len(Trim(txtNoOfShelves.Text)) = 0 Then
            MessageBox.Show("Please enter no. of shelves", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNoOfShelves.Focus()
            Exit Sub
        End If
        Try
            If chkActive.Checked = True Then
                st1 = "Yes"
            Else
                st1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update Racking set RackNo=@d1,NoOfShelves=@d2,Active=@d3 where RackNo=@d4"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtRackNo.Text)
            cmd.Parameters.AddWithValue("@d2", Val(txtNoOfShelves.Text))
            cmd.Parameters.AddWithValue("@d3", st1)
            cmd.Parameters.AddWithValue("@d4", txtRNo.Text)
            cmd.ExecuteReader()
            con.Close()
            Dim st As String = "Updated the Rack having Rack No. '" & txtRackNo.Text & "'"
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
            cmd = New SqlCommand("SELECT RTRIM(RackNo),NoOfShelves,RTRIM(Active) from Racking order by RackNo", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2))
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
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtRackNo.Text = dr.Cells(0).Value.ToString()
                txtRNo.Text = dr.Cells(0).Value.ToString()
                txtNoOfShelves.Text = dr.Cells(1).Value.ToString()
                If dr.Cells(2).Value.ToString() = "Yes" Then
                    chkActive.Checked = True
                Else
                    chkActive.Checked = False
                End If
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtSearchByRackNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearchByRackNo.TextChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(RackNo),NoOfShelves,RTRIM(Active) from Racking where RackNo like '%" & txtSearchByRackNo.Text & "%'  order by RackNo", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtNoOfShelves_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoOfShelves.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class
