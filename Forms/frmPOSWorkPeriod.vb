Imports System.Data.SqlClient
Public Class frmPOSWorkPeriod

    Private Sub DeleteRecord()

        Try
            Dim RowsAffected As Integer = 0
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "select POS_OpeningCash.OpenID from InvoiceInfo,POS_OpeningCash where InvoiceInfo.OpenID=POS_OpeningCash.OpenID and POS_OpeningCash.OpenID=@d1"
            cmd = New SqlCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in POS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from POS_OpeningCash where OpenID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            cmd.Connection = con
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the pos work period having open id '" & txtID.Text & "'"
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
                txtID.Text = dr.Cells(0).Value.ToString()
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
            cmd = New SqlCommand("SELECT POS_OpeningCash.OpenID,OpeningDate,RTRIM(UserID), RTRIM(POS_OpeningCash.TillDetails),POS_OpeningCash.OpeningCash,POS_ClosingCash.ClosingID, POS_ClosingCash.ClosingDate, POS_ClosingCash.ClosingBalance FROM POS_OpeningCash LEFT JOIN POS_ClosingCash ON POS_OpeningCash.OpenID = POS_ClosingCash.OpenID where (DATEDIFF(d,OpeningDate,GetDate())= 0) Order by OpeningDate", con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
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
            cmd = New SqlCommand("SELECT POS_OpeningCash.OpenID,OpeningDate,RTRIM(UserID), RTRIM(POS_OpeningCash.TillDetails),POS_OpeningCash.OpeningCash,POS_ClosingCash.ClosingID, POS_ClosingCash.ClosingDate, POS_ClosingCash.ClosingBalance FROM POS_OpeningCash LEFT JOIN POS_ClosingCash ON POS_OpeningCash.OpenID = POS_ClosingCash.OpenID Order by OpeningDate", con)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
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
            cmd = New SqlCommand("SELECT POS_OpeningCash.OpenID,OpeningDate,RTRIM(UserID), RTRIM(POS_OpeningCash.TillDetails),POS_OpeningCash.OpeningCash,POS_ClosingCash.ClosingID, POS_ClosingCash.ClosingDate, POS_ClosingCash.ClosingBalance FROM POS_OpeningCash LEFT JOIN POS_ClosingCash ON POS_OpeningCash.OpenID = POS_ClosingCash.OpenID where OpeningDate >=@d1 and OpeningDate < @d2 Order by OpeningDate", con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date.AddDays(1)
            cmd.CommandTimeout = 0
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
            End While
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
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
                cmd = New SqlCommand("SELECT POS_OpeningCash.OpenID,OpeningDate,RTRIM(UserID), RTRIM(POS_OpeningCash.TillDetails),POS_OpeningCash.OpeningCash,POS_ClosingCash.ClosingID, POS_ClosingCash.ClosingDate, POS_ClosingCash.ClosingBalance FROM POS_OpeningCash LEFT JOIN POS_ClosingCash ON POS_OpeningCash.OpenID = POS_ClosingCash.OpenID where UserID like '" & txtUserID.Text & "%' Order by OpeningDate", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
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
                cmd = New SqlCommand("SELECT POS_OpeningCash.OpenID,OpeningDate,RTRIM(UserID), RTRIM(POS_OpeningCash.TillDetails),POS_OpeningCash.OpeningCash,POS_ClosingCash.ClosingID, POS_ClosingCash.ClosingDate, POS_ClosingCash.ClosingBalance FROM POS_OpeningCash LEFT JOIN POS_ClosingCash ON POS_OpeningCash.OpenID = POS_ClosingCash.OpenID where TillDetails like '" & txtTillID.Text & "%' Order by OpeningDate", con)
                cmd.CommandTimeout = 0
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dgw.Rows.Clear()
                While (rdr.Read() = True)
                    dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7))
                End While
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
