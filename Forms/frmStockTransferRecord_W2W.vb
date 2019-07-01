Imports System.Data.SqlClient

Public Class frmStockTransferRecord_W2W
    Sub fillTransferID()
        Try
            Dim CN As New SqlConnection(cs)
            CN.Open()
            adp = New SqlDataAdapter()
            adp.SelectCommand = New SqlCommand("SELECT distinct RTRIM(TransferID) FROM StockTransfer_W2W order by 1", CN)
            ds = New DataSet("ds")
            adp.Fill(ds)
            dtable = ds.Tables(0)
            cmbTransferID.Items.Clear()
            For Each drow As DataRow In dtable.Rows
                cmbTransferID.Items.Add(drow(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub GetData()
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select ST_ID,RTRIM(TransferID),Date,RTRIM(Warehouse) from StockTransfer_W2W,Warehouse where Warehouse.WarehouseName=StockTransfer_W2W.Warehouse order by Date"
            cmd = New SqlCommand(sql, con)
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
    Private Sub frmLogs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetData()
        fillTransferID()
    End Sub
    Sub Reset()
        cmbTransferID.Text = ""
        dtpDateFrom.Text = Today
        dtpDateTo.Text = Today
        GetData()
    End Sub
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Reset()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        ExportExcel(dgw)
    End Sub

    Private Sub dgw_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgw.MouseClick
        Try

            If dgw.Rows.Count > 0 Then
                Dim dr As DataGridViewRow = dgw.SelectedRows(0)
                Me.Hide()
                frmStockTransfer_W2W.Show()
                ' or simply use column name instead of index
                'dr.Cells["id"].Value.ToString();
                frmStockTransfer_W2W.txtID.Text = dr.Cells(0).Value.ToString()
                frmStockTransfer_W2W.txtTransferID.Text = dr.Cells(1).Value.ToString()
                frmStockTransfer_W2W.dtpDate.Value = dr.Cells(2).Value.ToString()
                frmStockTransfer_W2W.cmbWareHouse.Text = dr.Cells(3).Value.ToString()
                frmStockTransfer_W2W.btnSave.Enabled = False
                frmStockTransfer_W2W.btnDelete.Enabled = True
                frmStockTransfer_W2W.btnAdd.Enabled = False
                frmStockTransfer_W2W.lblSet.Text = "Not allowed"
                con = New SqlConnection(cs)
                con.Open()
                Dim sql As String = "Select RTRIM(StockTransfer_Join_W2W.Warehouse),(PID),RTRIM(ProductCode),RTRIM(ProductName),RTRIM(StockTransfer_Join_W2W.Barcode),SalesRate,RTRIM(ManufacturingDate),RTRIM(ExpiryDate),Qty from Product,StockTransfer_W2W,StockTransfer_Join_W2W where Product.PID=StockTransfer_Join_W2W.ProductID and StockTransfer_W2W.ST_ID=StockTransfer_Join_W2W.StockTransferID and ST_ID=" & dr.Cells(0).Value & " order by ProductName"
                cmd = New SqlCommand(sql, con)
                rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                frmStockTransfer_W2W.dgw.Rows.Clear()
                While (rdr.Read() = True)
                    frmStockTransfer_W2W.dgw.Rows.Add(rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7), rdr(8))
                End While
                con.Close()
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select ST_ID,RTRIM(TransferID),Date,RTRIM(Warehouse) from StockTransfer_W2W,Warehouse where Warehouse.WarehouseName=StockTransfer_W2W.Warehouse and Date between @d1 and @d2 order by Date"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.Add("@d1", SqlDbType.DateTime, 30, "Date").Value = dtpDateFrom.Value.Date
            cmd.Parameters.Add("@d2", SqlDbType.DateTime, 30, "Date").Value = dtpDateTo.Value.Date
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

    Private Sub cmbTicketNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTransferID.SelectedIndexChanged
        Try
            con = New SqlConnection(cs)
            con.Open()
            Dim sql As String = "Select ST_ID,RTRIM(TransferID),Date,RTRIM(Warehouse) from StockTransfer_W2W,Warehouse where Warehouse.WarehouseName=StockTransfer_W2W.Warehouse and TransferID=@d1 order by Date"
            cmd = New SqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@d1", cmbTransferID.Text)
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

    Private Sub cmbTicketNo_Format(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ListControlConvertEventArgs) Handles cmbTransferID.Format
        If (e.DesiredType Is GetType(String)) Then
            e.Value = e.Value.ToString.Trim
        End If
    End Sub

End Class

