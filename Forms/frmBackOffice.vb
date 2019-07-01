Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.SqlServer.Management.Smo
Public Class frmBackOffice
    Dim Filename As String
    Declare Function Wow64DisableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Declare Function Wow64EnableWow64FsRedirection Lib "kernel32" (ByRef oldvalue As Long) As Boolean
    Private Sub btnCategories_Click(sender As System.Object, e As System.EventArgs) Handles btnCategories.Click
        frmCategory.lblUser.Text = lblUser.Text
        frmCategory.lblSet.Text = ""
        frmCategory.Reset()
        frmCategory.ShowDialog()
    End Sub

    Private Sub btnRegistration_Click(sender As System.Object, e As System.EventArgs) Handles btnRegistration.Click
        frmRegistration.lblUser.Text = lblUser.Text
        frmRegistration.Reset()
        frmRegistration.ShowDialog()
    End Sub

    Private Sub btnLogs_Click(sender As System.Object, e As System.EventArgs) Handles btnLogs.Click
        frmLogs.Reset()
        frmLogs.lblUser.Text = lblUser.Text
        frmLogs.ShowDialog()
    End Sub

    Sub Backup()
        Try

            Dim destdir As String = "RetailPOS_DB " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") & ".bak"
            Dim objdlg As New SaveFileDialog
            objdlg.FileName = destdir
            objdlg.ShowDialog()
            Filename = objdlg.FileName
            Cursor = Cursors.WaitCursor
            Timer3.Enabled = True
            con = New SqlConnection(cs)
            con.Open()
            Dim cb As String = "backup database RetailPOS_DB to disk='" & Filename & "'with init,stats=10"
            cmd = New SqlCommand(cb)
            cmd.Connection = con
            cmd.ExecuteReader()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnDBBackup_Click(sender As System.Object, e As System.EventArgs) Handles btnDBBackup.Click
        Backup()
    End Sub

    Private Sub btnDBRestore_Click(sender As System.Object, e As System.EventArgs) Handles btnDBRestore.Click
        Try
            With OpenFileDialog1
                .Filter = ("DB Backup File|*.bak;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Cursor = Cursors.WaitCursor
                Timer3.Enabled = True
                SqlConnection.ClearAllPools()
                con = New SqlConnection(cs)
                con.Open()
                Dim cb As String = "USE Master ALTER DATABASE RetailPOS_DB SET Single_User WITH Rollback Immediate Restore database RetailPOS_DB FROM disk='" & OpenFileDialog1.FileName & "' WITH REPLACE ALTER DATABASE RetailPOS_DB SET Multi_User "
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.ExecuteReader()
                con.Close()
                Dim st As String = "Sucessfully performed the restore"
                LogFunc(lblUser.Text, st)
                MessageBox.Show("Successfully performed", "Database Restore", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub LogOut()
        Dim st As String = "Successfully logged out"
        LogFunc(lblUser.Text, st)
        Me.Hide()
        frmLogin.Show()
        frmLogin.UserID.Text = ""
        frmLogin.Password.Text = ""
        frmLogin.UserID.Focus()
    End Sub
    Private Sub Cancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        frmCustomDialog17.lblUser.Text = lblUser.Text
        frmCustomDialog17.ShowDialog()
    End Sub

    Private Sub btnMinimize_Click(sender As System.Object, e As System.EventArgs) Handles btnMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
   

    Private Sub btnSupplier_Click(sender As System.Object, e As System.EventArgs) Handles btnSupplier.Click
        frmSupplier.lblUser.Text = lblUser.Text
        frmSupplier.Reset()
        frmSupplier.ShowDialog()
    End Sub

    Private Sub btnPurchase_Click(sender As System.Object, e As System.EventArgs) Handles btnPurchase.Click
        frmPurchaseEntry.lblUser.Text = lblUser.Text
        frmPurchaseEntry.Reset()
        frmPurchaseEntry.ShowDialog()
    End Sub

    Private Sub btnPayment_Click(sender As System.Object, e As System.EventArgs) Handles btnPayment.Click
        frmPayment.lblUser.Text = lblUser.Text
        frmPayment.Reset()
        frmPayment.ShowDialog()
    End Sub

    Private Sub btnExpenseType_Click(sender As System.Object, e As System.EventArgs) Handles btnExpenseType.Click
        frmExpenseType.lblUser.Text = lblUser.Text
        frmExpenseType.Reset()
        frmExpenseType.ShowDialog()
    End Sub

    Private Sub btnExpense_Click(sender As System.Object, e As System.EventArgs) Handles btnExpense.Click
        frmExpense.lblUser.Text = lblUser.Text
        frmExpense.Reset()
        frmExpense.ShowDialog()
    End Sub

    Private Sub BtnVoucher_Click(sender As System.Object, e As System.EventArgs) Handles BtnVoucher.Click
        frmVoucher.lblUser.Text = lblUser.Text
        frmVoucher.Reset()
        frmVoucher.ShowDialog()
    End Sub

    Private Sub btnWarehouseType_Click(sender As System.Object, e As System.EventArgs) Handles btnWarehouseType.Click
        frmWarehouseType.lblUser.Text = lblUser.Text
        frmWarehouseType.Reset()
        frmWarehouseType.ShowDialog()
    End Sub

    Private Sub btnWarehouse_Click(sender As System.Object, e As System.EventArgs) Handles btnWarehouse.Click
        frmWarehouse.lblUser.Text = lblUser.Text
        frmWarehouse.Reset()
        frmWarehouse.ShowDialog()
    End Sub

    Private Sub btnStockTransfer_Issue_Click(sender As System.Object, e As System.EventArgs) Handles btnStockTransfer_Issue.Click
        frmStockTransfer.lblUser.Text = lblUser.Text
        frmStockTransfer.ShowDialog()
    End Sub


    Private Sub btnKeyboard_Click(sender As System.Object, e As System.EventArgs) Handles btnKeyboard.Click
        Dim old As Long
        If Environment.Is64BitOperatingSystem Then
            If Wow64DisableWow64FsRedirection(old) Then
                Process.Start("osk.exe")
                Wow64EnableWow64FsRedirection(old)
            End If
        Else
            Process.Start("osk.exe")
        End If
    End Sub

    Private Sub btnWorkPeriodReport_Click(sender As System.Object, e As System.EventArgs) Handles btnPOSRecord.Click
        frmPOSRecord.Reset()
        frmPOSRecord.lblUser.Text = lblUser.Text
        frmPOSRecord.ShowDialog()
    End Sub

    Private Sub btnCompanyInfo_Click(sender As System.Object, e As System.EventArgs) Handles btnCompanyInfo.Click
        frmCompany.lblUser.Text = lblUser.Text
        frmCompany.Reset()
        frmCompany.ShowDialog()
    End Sub

    Private Sub btnSetting_Click(sender As System.Object, e As System.EventArgs) Handles btnSetting.Click
        frmSettings.ShowDialog()
    End Sub

    Private Sub btnPurchaseReturn_Click(sender As System.Object, e As System.EventArgs) Handles btnPurchaseReturn.Click
        frmPurchaseReturn.lblUser.Text = lblUser.Text
        frmPurchaseReturn.Reset()
        frmPurchaseReturn.ShowDialog()
    End Sub

    Private Sub btnBarcodeLabelPrinting_Click(sender As System.Object, e As System.EventArgs) Handles btnBarcodeLabelPrinting.Click
        frmBarcodeLabelPrinting.Reset()
        frmBarcodeLabelPrinting.ShowDialog()
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        Cursor = Cursors.Default
        Timer3.Enabled = False
    End Sub

    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick
        lblDateTime.Text = Now.ToString("dddd, dd MMMM yyyy hh:mm:ss tt")
    End Sub

    Private Sub btnProductMaster_Click(sender As System.Object, e As System.EventArgs) Handles btnProductMaster.Click
        frmProduct.lblUser.Text = lblUser.Text
        frmProduct.Reset()
        frmProduct.ShowDialog()
    End Sub

    Private Sub btnPurchaseOrder_Click(sender As System.Object, e As System.EventArgs) Handles btnPurchaseOrder.Click
        frmPurchaseOrder.lblUser.Text = lblUser.Text
        frmPurchaseOrder.Reset()
        frmPurchaseOrder.ShowDialog()
    End Sub

    Private Sub btnWorkPeriod_Click(sender As System.Object, e As System.EventArgs) Handles btnWorkPeriod.Click
        frmPOSWorkPeriod.Reset()
        frmPOSWorkPeriod.lblUser.Text = lblUser.Text
        frmPOSWorkPeriod.ShowDialog()
    End Sub

    Private Sub btnRacking_Click(sender As System.Object, e As System.EventArgs) Handles btnRacking.Click
        frmRacking.Reset()
        frmRacking.lblUser.Text = lblUser.Text
        frmRacking.ShowDialog()
    End Sub

    Private Sub btnProductsLocation_Click(sender As System.Object, e As System.EventArgs) Handles btnProductsLocation.Click
        frmProductLocation.Reset()
        frmProductLocation.lblUser.Text = lblUser.Text
        frmProductLocation.ShowDialog()
    End Sub

    Private Sub btnAccountingReports_Click(sender As System.Object, e As System.EventArgs) Handles btnAccountingReports.Click
        frmAccountingReport.Reset()
        frmAccountingReport.lblUser.Text = lblUser.Text
        frmAccountingReport.ShowDialog()
    End Sub

    Private Sub btnUnit_Click(sender As System.Object, e As System.EventArgs) Handles btnUnit.Click
        frmUnit.lblUser.Text = lblUser.Text
        frmUnit.Reset()
        frmUnit.ShowDialog()
    End Sub

    Private Sub btnPOSReport_Click(sender As System.Object, e As System.EventArgs) Handles btnPOSReport.Click
        frmPOSReport.Reset()
        frmPOSReport.ShowDialog()
    End Sub

    Private Sub btnStockAdjustment_Click(sender As System.Object, e As System.EventArgs)
        frmStockAdjustment.lblUser.Text = lblUser.Text
        frmStockAdjustment.ShowDialog()
    End Sub

    Private Sub btnSalesReturn_Click(sender As System.Object, e As System.EventArgs) Handles btnSalesReturn.Click
        frmSalesReturn.lblUser.Text = lblUser.Text
        frmSalesReturn.Reset()
        frmSalesReturn.btnGetData.Enabled = True
        frmSalesReturn.ShowDialog()
    End Sub

    Private Sub btnWallet_Click(sender As System.Object, e As System.EventArgs) Handles btnWallet.Click
        frmWalletType.lblUser.Text = lblUser.Text
        frmWalletType.Reset()
        frmWalletType.ShowDialog()
    End Sub

    Private Sub btnCreditCustomer_Click(sender As System.Object, e As System.EventArgs) Handles btnCreditCustomer.Click
        frmCreditCustomer.lblUser.Text = lblUser.Text
        frmCreditCustomer.ShowDialog()
    End Sub

    Private Sub btnStockAdjustment_Click_1(sender As System.Object, e As System.EventArgs) Handles btnStockAdjustment.Click
        frmStockAdjustment.lblUser.Text = lblUser.Text
        frmStockAdjustment.ShowDialog()
    End Sub

    Private Sub btnSalesmanMaster_Click(sender As System.Object, e As System.EventArgs) Handles btnSalesmanMaster.Click
        frmSalesman.lblUser.Text = lblUser.Text
        frmSalesman.Reset()
        frmSalesman.ShowDialog()
    End Sub
End Class