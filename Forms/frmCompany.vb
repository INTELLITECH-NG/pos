Imports System.Data.SqlClient
Imports System.IO

Public Class frmCompany
    Dim s1 As String
    Sub Reset()
        txtAddressLine1.Text = ""
        txtAddressLine2.Text = ""
        txtCompanyName.Text = ""
        txtContactNo.Text = ""
        txtCIN.Text = ""
        txtEmail.Text = ""
        txtFax.Text = ""
        txtLicenseNo.Text = ""
        txtMailingName.Text = ""
        txtPinCode.Text = ""
        txtAddressLine3.Text = ""
        txtTIN.Text = ""
        txtWebsite.Text = ""
        cmbCountry.Text = ""
        txtPAN.Text = ""
        txtBillFooterNote.Text = "Thanks....Visit Again!"
        txtBaseCurrency.Text = ""
        txtCurrencyCode.Text = ""
        PictureBox1.Image = My.Resources.Company1
        txtCompanyName.Focus()
        btnSave.Enabled = True
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        chkShowLogo.Checked = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtCompanyName.Text = "" Then
            MessageBox.Show("Please enter company name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCompanyName.Focus()
            Return
        End If
        If cmbCountry.Text = "" Then
            MessageBox.Show("Please select country", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCountry.Focus()
            Return
        End If
        If txtAddressLine1.Text = "" Then
            MessageBox.Show("Please enter address line 1", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddressLine1.Focus()
            Return
        End If
        If txtAddressLine2.Text = "" Then
            MessageBox.Show("Please enter address line 2", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddressLine2.Focus()
            Return
        End If
        If txtContactNo.Text = "" Then
            MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Return
        End If

        If txtEmail.Text = "" Then
            MessageBox.Show("Please enter email", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If
        If txtBaseCurrency.Text = "" Then
            MessageBox.Show("Please enter base currency", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBaseCurrency.Focus()
            Return
        End If
        If txtCurrencyCode.Text = "" Then
            MessageBox.Show("Please enter currency code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCurrencyCode.Focus()
            Return
        End If
        If txtBillFooterNote.Text = "" Then
            MessageBox.Show("Please enter bill footer note", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBillFooterNote.Focus()
            Return
        End If
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim ct As String = "select count(*) from Company Having count(*) >= 1"
            cmd = New SqlCommand(ct)
            cmd.Connection = con
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Record Already Exists" & vbCrLf & "please update the company info", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            If chkShowLogo.Checked = True Then
                s1 = "Yes"
            Else
                s1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "insert into Company(CompanyName, MailingName, Country, Address, City, State, PinCode, ContactNo, Fax, Email, Website, TIN, LicenseNo, CST,PAN,ServiceTaxNo,Currency, CurrencyCode,Logo,ShowLogo) VALUES (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8,@d9,@d10,@d11,@d12,@d13,@d14,@d15,@d16,@d17,@d18,@d19,@d20)"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtCompanyName.Text)
            cmd.Parameters.AddWithValue("@d2", txtMailingName.Text)
            cmd.Parameters.AddWithValue("@d3", cmbCountry.Text)
            cmd.Parameters.AddWithValue("@d4", txtAddressLine1.Text)
            cmd.Parameters.AddWithValue("@d5", txtAddressLine2.Text)
            cmd.Parameters.AddWithValue("@d6", txtAddressLine3.Text)
            cmd.Parameters.AddWithValue("@d7", txtPinCode.Text)
            cmd.Parameters.AddWithValue("@d8", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d9", txtFax.Text)
            cmd.Parameters.AddWithValue("@d10", txtEmail.Text)
            cmd.Parameters.AddWithValue("@d11", txtWebsite.Text)
            cmd.Parameters.AddWithValue("@d12", txtTIN.Text)
            cmd.Parameters.AddWithValue("@d13", txtLicenseNo.Text)
            cmd.Parameters.AddWithValue("@d14", txtCIN.Text)
            cmd.Parameters.AddWithValue("@d15", txtPAN.Text)
            cmd.Parameters.AddWithValue("@d16", txtBillFooterNote.Text)
            cmd.Parameters.AddWithValue("@d17", txtBaseCurrency.Text)
            cmd.Parameters.AddWithValue("@d18", txtCurrencyCode.Text)
            cmd.Parameters.AddWithValue("@d20", s1)
            Dim ms As New MemoryStream()
            Dim bmpImage As New Bitmap(PictureBox1.Image)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@d19", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "added the comapany '" & txtCompanyName.Text & "' info"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully saved", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnSave.Enabled = False
            Getdata()
            Reset()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtCompanyName.Text = "" Then
            MessageBox.Show("Please enter company name", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCompanyName.Focus()
            Return
        End If
        If cmbCountry.Text = "" Then
            MessageBox.Show("Please select country", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCountry.Focus()
            Return
        End If
        If txtAddressLine1.Text = "" Then
            MessageBox.Show("Please enter address line 1", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddressLine1.Focus()
            Return
        End If
        If txtAddressLine2.Text = "" Then
            MessageBox.Show("Please enter address line 2", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddressLine2.Focus()
            Return
        End If
        If txtContactNo.Text = "" Then
            MessageBox.Show("Please enter contact no.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtContactNo.Focus()
            Return
        End If

        If txtEmail.Text = "" Then
            MessageBox.Show("Please enter email", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If
        If txtBaseCurrency.Text = "" Then
            MessageBox.Show("Please enter base currency", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBaseCurrency.Focus()
            Return
        End If
        If txtCurrencyCode.Text = "" Then
            MessageBox.Show("Please enter currency code", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCurrencyCode.Focus()
            Return
        End If
        Try
            If chkShowLogo.Checked = True Then
                s1 = "Yes"
            Else
                s1 = "No"
            End If
            con = New SqlConnection(cs)
            con.Open()
            Dim cb3 As String = "update InvoiceInfo set CurrencyCode=@d1 where CurrencyCode=@d2"
            cmd = New SqlCommand(cb3)
            cmd.Parameters.AddWithValue("@d1", txtCurrencyCode.Text)
            cmd.Parameters.AddWithValue("@d2", txtCcode.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb1 As String = "update Product_OpeningStock set Warehouse_Store=@d1 where Warehouse_Store=@d2"
            cmd = New SqlCommand(cb1)
            cmd.Parameters.AddWithValue("@d1", txtCompanyName.Text)
            cmd.Parameters.AddWithValue("@d2", txtCName.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb2 As String = "update Purchase_Join set Warehouse_Store=@d1 where Warehouse_Store=@d2"
            cmd = New SqlCommand(cb2)
            cmd.Parameters.AddWithValue("@d1", txtCompanyName.Text)
            cmd.Parameters.AddWithValue("@d2", txtCName.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb4 As String = "update PurchaseReturn_Join set Warehouse_Store=@d1 where Warehouse_Store=@d2"
            cmd = New SqlCommand(cb4)
            cmd.Parameters.AddWithValue("@d1", txtCompanyName.Text)
            cmd.Parameters.AddWithValue("@d2", txtCName.Text)
            cmd.Connection = con
            cmd.ExecuteNonQuery()
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "Update Company set CompanyName=@d1, MailingName=@d2, Country=@d3, Address=@d4, City=@d5, State=@d6, PinCode=@d7, ContactNo=@d8, Fax=@d9, Email=@d10, Website=@d11, TIN=@d12, LicenseNo=@d13, CST=@d14,PAN=@d15,ServiceTaxNo=@d16,Currency=@d17, CurrencyCode=@d18,Logo=@d19,ShowLogo=@d20 where ID=" & txtID.Text & ""
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtCompanyName.Text)
            cmd.Parameters.AddWithValue("@d2", txtMailingName.Text)
            cmd.Parameters.AddWithValue("@d3", cmbCountry.Text)
            cmd.Parameters.AddWithValue("@d4", txtAddressLine1.Text)
            cmd.Parameters.AddWithValue("@d5", txtAddressLine2.Text)
            cmd.Parameters.AddWithValue("@d6", txtAddressLine3.Text)
            cmd.Parameters.AddWithValue("@d7", txtPinCode.Text)
            cmd.Parameters.AddWithValue("@d8", txtContactNo.Text)
            cmd.Parameters.AddWithValue("@d9", txtFax.Text)
            cmd.Parameters.AddWithValue("@d10", txtEmail.Text)
            cmd.Parameters.AddWithValue("@d11", txtWebsite.Text)
            cmd.Parameters.AddWithValue("@d12", txtTIN.Text)
            cmd.Parameters.AddWithValue("@d13", txtLicenseNo.Text)
            cmd.Parameters.AddWithValue("@d14", txtCIN.Text)
            cmd.Parameters.AddWithValue("@d15", txtPAN.Text)
            cmd.Parameters.AddWithValue("@d16", txtBillFooterNote.Text)
            cmd.Parameters.AddWithValue("@d17", txtBaseCurrency.Text)
            cmd.Parameters.AddWithValue("@d18", txtCurrencyCode.Text)
            cmd.Parameters.AddWithValue("@d20", s1)
            Dim ms As New MemoryStream()
            Dim bmpImage As New Bitmap(PictureBox1.Image)
            bmpImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            Dim data As Byte() = ms.GetBuffer()
            Dim p As New SqlParameter("@d19", SqlDbType.Image)
            p.Value = data
            cmd.Parameters.Add(p)
            cmd.ExecuteNonQuery()
            con.Close()
            Dim st As String = "updated the comapany '" & txtCompanyName.Text & "' info"
            LogFunc(lblUser.Text, st)
            MessageBox.Show("Successfully updated", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            cmd = New SqlCommand("SELECT (ID), RTRIM(CompanyName), RTRIM(MailingName), RTRIM(Country), RTRIM(Address), RTRIM(City), RTRIM(State), RTRIM(PinCode), RTRIM(ContactNo), RTRIM(Fax), RTRIM(Email), RTRIM(Website), RTRIM(TIN), RTRIM(LicenseNo), RTRIM(CST),RTRIM(PAN),RTRIM(ServiceTaxNo),RTRIM(Currency), RTRIM(CurrencyCode),Logo,RTRIM(ShowLogo) from Company", con)
            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            While (rdr.Read() = True)
                dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8), rdr(9), rdr(10), rdr(11), rdr(12), rdr(13), rdr(14), rdr(15), rdr(16), rdr(17), rdr(18), rdr(19), rdr(20))
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

    Private Sub frmRegistration_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Getdata()
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try
            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                txtID.Text = dr.Cells(0).Value.ToString()
                txtCompanyName.Text = dr.Cells(1).Value.ToString()
                txtCName.Text = dr.Cells(1).Value.ToString()
                txtMailingName.Text = dr.Cells(2).Value.ToString()
                cmbCountry.Text = dr.Cells(3).Value.ToString()
                txtAddressLine1.Text = dr.Cells(4).Value.ToString()
                txtAddressLine2.Text = dr.Cells(5).Value.ToString()
                txtAddressLine3.Text = dr.Cells(6).Value.ToString()
                txtPinCode.Text = dr.Cells(7).Value.ToString()
                txtContactNo.Text = dr.Cells(8).Value.ToString()
                txtFax.Text = dr.Cells(9).Value.ToString()
                txtEmail.Text = dr.Cells(10).Value.ToString()
                txtWebsite.Text = dr.Cells(11).Value.ToString()
                txtTIN.Text = dr.Cells(12).Value.ToString()
                txtLicenseNo.Text = dr.Cells(13).Value.ToString()
                txtCIN.Text = dr.Cells(14).Value.ToString()
                txtPAN.Text = dr.Cells(15).Value.ToString()
                txtBillFooterNote.Text = dr.Cells(16).Value.ToString()
                txtBaseCurrency.Text = dr.Cells(17).Value.ToString()
                txtCurrencyCode.Text = dr.Cells(18).Value.ToString()
                txtCcode.Text = dr.Cells(18).Value.ToString()
                Dim data As Byte() = DirectCast(dr.Cells(19).Value, Byte())
                Dim ms As New MemoryStream(data)
                Me.PictureBox1.Image = Image.FromStream(ms)
                If dr.Cells(20).Value.ToString() = "Yes" Then
                    chkShowLogo.Checked = True
                Else
                    chkShowLogo.Checked = False
                End If
                btnUpdate.Enabled = True
                btnSave.Enabled = False
                btnDelete.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try
            With OpenFileDialog1
                .Filter = ("Images |*.png; *.bmp; *.jpg;*.jpeg; *.gif;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""
            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
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
            Dim cl2 As String = "select Warehouse_Store from Product_OpeningStock,Company where Product_OpeningStock.Warehouse_Store=Company.CompanyName and Warehouse_Store=@d1"
            cmd = New SqlCommand(cl2)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", txtCName.Text)
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Product Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cl As String = "select ID from Company,StockTransfer where Company.ID=StockTransfer.CompanyID and ID=@d1"
            cmd = New SqlCommand(cl)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            rdr = cmd.ExecuteReader()
            If rdr.Read Then
                MessageBox.Show("Unable to delete..Already in use in Stock Transfer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                If Not rdr Is Nothing Then
                    rdr.Close()
                End If
                Exit Sub
            End If
            con.Close()
            con = New SqlConnection(cs)
            con.Open()
            Dim cq As String = "delete from Company where ID=@d1"
            cmd = New SqlCommand(cq)
            cmd.Connection = con
            cmd.Parameters.AddWithValue("@d1", Val(txtID.Text))
            RowsAffected = cmd.ExecuteNonQuery()
            If RowsAffected > 0 Then
                Dim st As String = "deleted the Company '" & txtCompanyName.Text & "' info"
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

    Private Sub txtCurrencyCode_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCurrencyCode.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

End Class
