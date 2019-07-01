Public Class frmStockTransfer
    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnStockTransfer_W2S_Click(sender As System.Object, e As System.EventArgs) Handles btnStockTransfer_W2S.Click
        frmStockTransfer_W2S.lblUser.Text = lblUser.Text
        frmStockTransfer_W2S.Reset()
        frmStockTransfer_W2S.ShowDialog()
    End Sub

    Private Sub btnStockTransfer_W2W_Click(sender As System.Object, e As System.EventArgs) Handles btnStockTransfer_W2W.Click
        frmStockTransfer_W2W.lblUser.Text = lblUser.Text
        frmStockTransfer_W2W.Reset()
        frmStockTransfer_W2W.ShowDialog()
    End Sub
End Class