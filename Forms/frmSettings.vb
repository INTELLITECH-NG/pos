Public Class frmSettings

    Private Sub btnPrinterSetting_Click(sender As System.Object, e As System.EventArgs) Handles btnPrinterSetting.Click
        frmTerminalSetting.Reset()
        frmTerminalSetting.ShowDialog()
    End Sub

    Private Sub btnTaxSetting_Click(sender As System.Object, e As System.EventArgs) Handles btnTaxSetting.Click
        frmTaxSetting.Reset()
        frmTaxSetting.ShowDialog()
    End Sub

    Private Sub btnEmailSetting_Click(sender As System.Object, e As System.EventArgs) Handles btnEmailSetting.Click
        frmEmailSetting.Reset()
        frmEmailSetting.ShowDialog()
    End Sub

    Private Sub btnSMSSetting_Click(sender As System.Object, e As System.EventArgs) Handles btnSMSSetting.Click
        frmSMSSetting.Reset()
        frmSMSSetting.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnTaxType_Click(sender As System.Object, e As System.EventArgs) Handles btnTaxType.Click
        frmTaxType.Reset()
        frmTaxType.ShowDialog()
    End Sub

    Private Sub btnTaxMaster_Click(sender As System.Object, e As System.EventArgs) Handles btnTaxMaster.Click
        frmTax.Reset()
        frmTax.ShowDialog()
    End Sub
End Class