Imports System.Data.SqlClient
Public Class frmTax
    Sub fillCombo()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(Type) FROM TaxType", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            Dim dtable As DataTable = ds.Tables(0)
            cmbTaxType.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbTaxType.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Reset()
        cmbTaxType.SelectedIndex = -1
        txtAdditionalPercentage.Text = "0.00"
        txtPercentage.Text = "0.00"
        txtTaxName.Text = ""
        txtTaxName.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
    End Sub
  
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Len(Trim(txtTaxName.Text)) = 0 Then
            MessageBox.Show("Please enter tax name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTaxName.Focus()
            Exit Sub
        End If
        If Len(Trim(cmbTaxType.Text)) = 0 Then
            MessageBox.Show("Please select tax type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbTaxType.Focus()
            Exit Sub
        End If
        If Len(Trim(txtPercentage.Text)) = 0 Then
            MessageBox.Show("Please enter VAT %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPercentage.Focus()
            Exit Sub
        End If
        If txtAdditionalPercentage.Text = "" Then
            MessageBox.Show("Please enter Additional VAT %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAdditionalPercentage.Focus()
            Return
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select TaxName from TaxMaster where TaxName=@d1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtTaxName.Text)
            rdr = cmd.ExecuteReader()

            If rdr.Read() Then
                MessageBox.Show("Tax name Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtTaxName.Text = ""
                txtTaxName.Focus()
                If (rdr IsNot Nothing) Then
                    rdr.Close()
                End If
                Return
            End If

            con = New SqlConnection(cs)
            con.Open()

            Dim cb As String = "insert into TaxMaster(TaxName,taxtype,Percentage,AdditionalPercentage) VALUES (@d1,@d2," & txtPercentage.Text & "," & txtAdditionalPercentage.Text & ")"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtTaxName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbTaxType.Text)
            cmd.ExecuteReader()
            con.Close()
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
            Dim cl As String = "select TaxName from Product,TaxMaster where Product.VATCommodity=TaxMaster.TaxName and TaxName=@d1"
            cmd = New SqlCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtTaxName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Product Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from TaxMaster where TaxName=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtTaxName.Text)
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
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
        Try
            If Len(Trim(txtTaxName.Text)) = 0 Then
                MessageBox.Show("Please enter tax name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtTaxName.Focus()
                Exit Sub
            End If
            If Len(Trim(cmbTaxType.Text)) = 0 Then
                MessageBox.Show("Please select tax type", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbTaxType.Focus()
                Exit Sub
            End If
            If Len(Trim(txtPercentage.Text)) = 0 Then
                MessageBox.Show("Please enter VAT %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPercentage.Focus()
                Exit Sub
            End If
            If txtAdditionalPercentage.Text = "" Then
                MessageBox.Show("Please enter Additional VAT %", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAdditionalPercentage.Focus()
                Return
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "update TaxMaster set TaxName=@d1,taxtype=@d2,Percentage=" & txtPercentage.Text & ",AdditionalPercentage=" & txtAdditionalPercentage.Text & " where TaxName=@d3"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtTaxName.Text)
            cmd.Parameters.AddWithValue("@d2", cmbTaxType.Text)
            cmd.Parameters.AddWithValue("@d3", txtTax.Text)
            cmd.ExecuteReader()
            con.Close()
            MessageBox.Show("Successfully updated", "Tax Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnUpdate.Enabled = False
            btnDelete.Enabled = False
            Getdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Public Sub Getdata()
        Try
            con = New SqlConnection(cs)
            con.Open()
            cmd = New SqlCommand("SELECT RTRIM(TaxName),RTRIM(taxtype),Percentage,AdditionalPercentage from TaxMaster order by TaxName", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3))
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

    Private Sub frmTaxMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
        fillCombo()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtTaxName.Text = dr.Cells(0).Value.ToString()
                txtTax.Text = dr.Cells(0).Value.ToString()
                cmbTaxType.Text = dr.Cells(1).Value.ToString()
                txtPercentage.Text = dr.Cells(2).Value.ToString()
                txtAdditionalPercentage.Text = dr.Cells(3).Value.ToString()
                btnUpdate.Enabled = True
                btnDelete.Enabled = True
                btnSave.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtServiceTax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPercentage.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtPercentage.Text
            Dim selectionStart = Me.txtPercentage.SelectionStart
            Dim selectionLength = Me.txtPercentage.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub txtDiscount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAdditionalPercentage.KeyPress
        Dim keyChar = e.KeyChar

        If Char.IsControl(keyChar) Then
            'Allow all control characters.
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = Me.txtAdditionalPercentage.Text
            Dim selectionStart = Me.txtAdditionalPercentage.SelectionStart
            Dim selectionLength = Me.txtAdditionalPercentage.SelectionLength

            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            ElseIf Double.TryParse(text, New Double) AndAlso text.IndexOf("."c) < text.Length - 3 Then
                'Reject a real number with two many decimal places.
                e.Handled = False
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub
End Class
