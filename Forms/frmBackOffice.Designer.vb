<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackOffice
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBackOffice))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCompanyInfo = New System.Windows.Forms.Button()
        Me.btnDBBackup = New System.Windows.Forms.Button()
        Me.btnSetting = New System.Windows.Forms.Button()
        Me.btnDBRestore = New System.Windows.Forms.Button()
        Me.btnRegistration = New System.Windows.Forms.Button()
        Me.btnLogs = New System.Windows.Forms.Button()
        Me.btnWallet = New System.Windows.Forms.Button()
        Me.btnRacking = New System.Windows.Forms.Button()
        Me.btnProductsLocation = New System.Windows.Forms.Button()
        Me.btnPayment = New System.Windows.Forms.Button()
        Me.btnExpenseType = New System.Windows.Forms.Button()
        Me.btnExpense = New System.Windows.Forms.Button()
        Me.BtnVoucher = New System.Windows.Forms.Button()
        Me.btnBarcodeLabelPrinting = New System.Windows.Forms.Button()
        Me.btnWorkPeriod = New System.Windows.Forms.Button()
        Me.btnPOSRecord = New System.Windows.Forms.Button()
        Me.btnAccountingReports = New System.Windows.Forms.Button()
        Me.btnPOSReport = New System.Windows.Forms.Button()
        Me.btnWarehouse = New System.Windows.Forms.Button()
        Me.btnProductMaster = New System.Windows.Forms.Button()
        Me.btnSupplier = New System.Windows.Forms.Button()
        Me.btnCreditCustomer = New System.Windows.Forms.Button()
        Me.btnPurchaseOrder = New System.Windows.Forms.Button()
        Me.btnPurchase = New System.Windows.Forms.Button()
        Me.btnPurchaseReturn = New System.Windows.Forms.Button()
        Me.btnSalesReturn = New System.Windows.Forms.Button()
        Me.btnStockTransfer_Issue = New System.Windows.Forms.Button()
        Me.btnStockAdjustment = New System.Windows.Forms.Button()
        Me.btnUnit = New System.Windows.Forms.Button()
        Me.btnWarehouseType = New System.Windows.Forms.Button()
        Me.btnSalesmanMaster = New System.Windows.Forms.Button()
        Me.btnCategories = New System.Windows.Forms.Button()
        Me.btnKeyboard = New System.Windows.Forms.Button()
        Me.btnMinimize = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Firebrick
        Me.Panel1.Controls.Add(Me.Label30)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblUser)
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(748, 49)
        Me.Panel1.TabIndex = 3
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.PaleGoldenrod
        Me.Label30.Location = New System.Drawing.Point(339, 5)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(178, 37)
        Me.Label30.TabIndex = 321
        Me.Label30.Text = "Operator ID :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.NavajoWhite
        Me.Label1.Location = New System.Drawing.Point(3, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Back Office"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.PaleGoldenrod
        Me.lblUser.Location = New System.Drawing.Point(512, 5)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(102, 37)
        Me.lblUser.TabIndex = 320
        Me.lblUser.Text = "lblUser"
        '
        'lblDateTime
        '
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI Semibold", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.Color.Firebrick
        Me.lblDateTime.Location = New System.Drawing.Point(5, 53)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(134, 37)
        Me.lblDateTime.TabIndex = 3
        Me.lblDateTime.Text = "DateTime"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Timer3
        '
        '
        'Timer4
        '
        Me.Timer4.Enabled = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnCompanyInfo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnDBBackup, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSetting, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnDBRestore, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnRegistration, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnLogs, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnWallet, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnRacking, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnProductsLocation, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPayment, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExpenseType, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.btnExpense, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.BtnVoucher, 2, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.btnBarcodeLabelPrinting, 3, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.btnWorkPeriod, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPOSRecord, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAccountingReports, 3, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPOSReport, 2, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnWarehouse, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnProductMaster, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSupplier, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCreditCustomer, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPurchaseOrder, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPurchase, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnPurchaseReturn, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSalesReturn, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnStockTransfer_Issue, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnStockAdjustment, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnUnit, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnWarehouseType, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSalesmanMaster, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnCategories, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 93)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 8
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(892, 574)
        Me.TableLayoutPanel1.TabIndex = 56
        '
        'btnCompanyInfo
        '
        Me.btnCompanyInfo.AutoSize = True
        Me.btnCompanyInfo.BackColor = System.Drawing.Color.Firebrick
        Me.btnCompanyInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCompanyInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCompanyInfo.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCompanyInfo.ForeColor = System.Drawing.Color.White
        Me.btnCompanyInfo.Image = CType(resources.GetObject("btnCompanyInfo.Image"), System.Drawing.Image)
        Me.btnCompanyInfo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCompanyInfo.Location = New System.Drawing.Point(3, 3)
        Me.btnCompanyInfo.Name = "btnCompanyInfo"
        Me.btnCompanyInfo.Size = New System.Drawing.Size(217, 65)
        Me.btnCompanyInfo.TabIndex = 30
        Me.btnCompanyInfo.Text = "Company Master"
        Me.btnCompanyInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCompanyInfo.UseVisualStyleBackColor = False
        '
        'btnDBBackup
        '
        Me.btnDBBackup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDBBackup.AutoSize = True
        Me.btnDBBackup.BackColor = System.Drawing.Color.Firebrick
        Me.btnDBBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDBBackup.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDBBackup.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDBBackup.Image = CType(resources.GetObject("btnDBBackup.Image"), System.Drawing.Image)
        Me.btnDBBackup.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDBBackup.Location = New System.Drawing.Point(672, 3)
        Me.btnDBBackup.Name = "btnDBBackup"
        Me.btnDBBackup.Size = New System.Drawing.Size(217, 65)
        Me.btnDBBackup.TabIndex = 31
        Me.btnDBBackup.Text = "DB Backup"
        Me.btnDBBackup.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDBBackup.UseVisualStyleBackColor = False
        '
        'btnSetting
        '
        Me.btnSetting.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSetting.AutoSize = True
        Me.btnSetting.BackColor = System.Drawing.Color.Firebrick
        Me.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetting.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSetting.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSetting.Image = CType(resources.GetObject("btnSetting.Image"), System.Drawing.Image)
        Me.btnSetting.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSetting.Location = New System.Drawing.Point(226, 3)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(217, 65)
        Me.btnSetting.TabIndex = 39
        Me.btnSetting.Text = "Settings"
        Me.btnSetting.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSetting.UseVisualStyleBackColor = False
        '
        'btnDBRestore
        '
        Me.btnDBRestore.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDBRestore.AutoSize = True
        Me.btnDBRestore.BackColor = System.Drawing.Color.Firebrick
        Me.btnDBRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDBRestore.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDBRestore.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnDBRestore.Image = CType(resources.GetObject("btnDBRestore.Image"), System.Drawing.Image)
        Me.btnDBRestore.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDBRestore.Location = New System.Drawing.Point(449, 3)
        Me.btnDBRestore.Name = "btnDBRestore"
        Me.btnDBRestore.Size = New System.Drawing.Size(217, 65)
        Me.btnDBRestore.TabIndex = 32
        Me.btnDBRestore.Text = "DB Restore"
        Me.btnDBRestore.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDBRestore.UseVisualStyleBackColor = False
        '
        'btnRegistration
        '
        Me.btnRegistration.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRegistration.AutoSize = True
        Me.btnRegistration.BackColor = System.Drawing.Color.Firebrick
        Me.btnRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRegistration.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistration.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRegistration.Image = CType(resources.GetObject("btnRegistration.Image"), System.Drawing.Image)
        Me.btnRegistration.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRegistration.Location = New System.Drawing.Point(3, 74)
        Me.btnRegistration.Name = "btnRegistration"
        Me.btnRegistration.Size = New System.Drawing.Size(217, 65)
        Me.btnRegistration.TabIndex = 25
        Me.btnRegistration.Text = "Registration"
        Me.btnRegistration.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRegistration.UseVisualStyleBackColor = False
        '
        'btnLogs
        '
        Me.btnLogs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogs.AutoSize = True
        Me.btnLogs.BackColor = System.Drawing.Color.Firebrick
        Me.btnLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogs.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogs.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnLogs.Image = CType(resources.GetObject("btnLogs.Image"), System.Drawing.Image)
        Me.btnLogs.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLogs.Location = New System.Drawing.Point(226, 74)
        Me.btnLogs.Name = "btnLogs"
        Me.btnLogs.Size = New System.Drawing.Size(217, 65)
        Me.btnLogs.TabIndex = 26
        Me.btnLogs.Text = "Logs"
        Me.btnLogs.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLogs.UseVisualStyleBackColor = False
        '
        'btnWallet
        '
        Me.btnWallet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWallet.AutoSize = True
        Me.btnWallet.BackColor = System.Drawing.Color.Firebrick
        Me.btnWallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWallet.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWallet.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnWallet.Image = CType(resources.GetObject("btnWallet.Image"), System.Drawing.Image)
        Me.btnWallet.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWallet.Location = New System.Drawing.Point(449, 74)
        Me.btnWallet.Name = "btnWallet"
        Me.btnWallet.Size = New System.Drawing.Size(217, 65)
        Me.btnWallet.TabIndex = 66
        Me.btnWallet.Text = "Wallet"
        Me.btnWallet.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWallet.UseVisualStyleBackColor = False
        '
        'btnRacking
        '
        Me.btnRacking.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRacking.AutoSize = True
        Me.btnRacking.BackColor = System.Drawing.Color.Firebrick
        Me.btnRacking.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRacking.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRacking.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnRacking.Image = CType(resources.GetObject("btnRacking.Image"), System.Drawing.Image)
        Me.btnRacking.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRacking.Location = New System.Drawing.Point(226, 358)
        Me.btnRacking.Name = "btnRacking"
        Me.btnRacking.Size = New System.Drawing.Size(217, 65)
        Me.btnRacking.TabIndex = 62
        Me.btnRacking.Text = "Racking"
        Me.btnRacking.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRacking.UseVisualStyleBackColor = False
        '
        'btnProductsLocation
        '
        Me.btnProductsLocation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProductsLocation.AutoSize = True
        Me.btnProductsLocation.BackColor = System.Drawing.Color.Firebrick
        Me.btnProductsLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProductsLocation.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProductsLocation.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnProductsLocation.Image = CType(resources.GetObject("btnProductsLocation.Image"), System.Drawing.Image)
        Me.btnProductsLocation.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProductsLocation.Location = New System.Drawing.Point(449, 358)
        Me.btnProductsLocation.Name = "btnProductsLocation"
        Me.btnProductsLocation.Size = New System.Drawing.Size(217, 65)
        Me.btnProductsLocation.TabIndex = 63
        Me.btnProductsLocation.Text = "Products Location"
        Me.btnProductsLocation.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProductsLocation.UseVisualStyleBackColor = False
        '
        'btnPayment
        '
        Me.btnPayment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPayment.AutoSize = True
        Me.btnPayment.BackColor = System.Drawing.Color.Firebrick
        Me.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPayment.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPayment.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPayment.Image = CType(resources.GetObject("btnPayment.Image"), System.Drawing.Image)
        Me.btnPayment.Location = New System.Drawing.Point(672, 358)
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.Size = New System.Drawing.Size(217, 65)
        Me.btnPayment.TabIndex = 42
        Me.btnPayment.Text = "Payment"
        Me.btnPayment.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPayment.UseVisualStyleBackColor = False
        '
        'btnExpenseType
        '
        Me.btnExpenseType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExpenseType.AutoSize = True
        Me.btnExpenseType.BackColor = System.Drawing.Color.Firebrick
        Me.btnExpenseType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExpenseType.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpenseType.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExpenseType.Image = CType(resources.GetObject("btnExpenseType.Image"), System.Drawing.Image)
        Me.btnExpenseType.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExpenseType.Location = New System.Drawing.Point(3, 429)
        Me.btnExpenseType.Name = "btnExpenseType"
        Me.btnExpenseType.Size = New System.Drawing.Size(217, 65)
        Me.btnExpenseType.TabIndex = 44
        Me.btnExpenseType.Text = "Expense Type Master"
        Me.btnExpenseType.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExpenseType.UseVisualStyleBackColor = False
        '
        'btnExpense
        '
        Me.btnExpense.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExpense.AutoSize = True
        Me.btnExpense.BackColor = System.Drawing.Color.Firebrick
        Me.btnExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExpense.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpense.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnExpense.Image = CType(resources.GetObject("btnExpense.Image"), System.Drawing.Image)
        Me.btnExpense.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExpense.Location = New System.Drawing.Point(226, 429)
        Me.btnExpense.Name = "btnExpense"
        Me.btnExpense.Size = New System.Drawing.Size(217, 65)
        Me.btnExpense.TabIndex = 45
        Me.btnExpense.Text = "Expense Master"
        Me.btnExpense.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExpense.UseVisualStyleBackColor = False
        '
        'BtnVoucher
        '
        Me.BtnVoucher.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnVoucher.AutoSize = True
        Me.BtnVoucher.BackColor = System.Drawing.Color.Firebrick
        Me.BtnVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnVoucher.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVoucher.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BtnVoucher.Image = CType(resources.GetObject("BtnVoucher.Image"), System.Drawing.Image)
        Me.BtnVoucher.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnVoucher.Location = New System.Drawing.Point(449, 429)
        Me.BtnVoucher.Name = "BtnVoucher"
        Me.BtnVoucher.Size = New System.Drawing.Size(217, 65)
        Me.BtnVoucher.TabIndex = 46
        Me.BtnVoucher.Text = "Voucher"
        Me.BtnVoucher.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnVoucher.UseVisualStyleBackColor = False
        '
        'btnBarcodeLabelPrinting
        '
        Me.btnBarcodeLabelPrinting.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBarcodeLabelPrinting.AutoSize = True
        Me.btnBarcodeLabelPrinting.BackColor = System.Drawing.Color.Firebrick
        Me.btnBarcodeLabelPrinting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBarcodeLabelPrinting.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBarcodeLabelPrinting.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnBarcodeLabelPrinting.Image = CType(resources.GetObject("btnBarcodeLabelPrinting.Image"), System.Drawing.Image)
        Me.btnBarcodeLabelPrinting.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBarcodeLabelPrinting.Location = New System.Drawing.Point(672, 429)
        Me.btnBarcodeLabelPrinting.Name = "btnBarcodeLabelPrinting"
        Me.btnBarcodeLabelPrinting.Size = New System.Drawing.Size(217, 65)
        Me.btnBarcodeLabelPrinting.TabIndex = 59
        Me.btnBarcodeLabelPrinting.Text = "Barcode Label Printing"
        Me.btnBarcodeLabelPrinting.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBarcodeLabelPrinting.UseVisualStyleBackColor = False
        '
        'btnWorkPeriod
        '
        Me.btnWorkPeriod.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWorkPeriod.AutoSize = True
        Me.btnWorkPeriod.BackColor = System.Drawing.Color.Firebrick
        Me.btnWorkPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWorkPeriod.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWorkPeriod.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnWorkPeriod.Image = CType(resources.GetObject("btnWorkPeriod.Image"), System.Drawing.Image)
        Me.btnWorkPeriod.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWorkPeriod.Location = New System.Drawing.Point(3, 500)
        Me.btnWorkPeriod.Name = "btnWorkPeriod"
        Me.btnWorkPeriod.Size = New System.Drawing.Size(217, 71)
        Me.btnWorkPeriod.TabIndex = 38
        Me.btnWorkPeriod.Text = "POS Work Period"
        Me.btnWorkPeriod.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWorkPeriod.UseVisualStyleBackColor = False
        '
        'btnPOSRecord
        '
        Me.btnPOSRecord.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPOSRecord.BackColor = System.Drawing.Color.Firebrick
        Me.btnPOSRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPOSRecord.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPOSRecord.ForeColor = System.Drawing.Color.White
        Me.btnPOSRecord.Image = CType(resources.GetObject("btnPOSRecord.Image"), System.Drawing.Image)
        Me.btnPOSRecord.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPOSRecord.Location = New System.Drawing.Point(226, 500)
        Me.btnPOSRecord.Name = "btnPOSRecord"
        Me.btnPOSRecord.Size = New System.Drawing.Size(217, 71)
        Me.btnPOSRecord.TabIndex = 57
        Me.btnPOSRecord.Text = "POS Record"
        Me.btnPOSRecord.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPOSRecord.UseVisualStyleBackColor = False
        '
        'btnAccountingReports
        '
        Me.btnAccountingReports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAccountingReports.AutoSize = True
        Me.btnAccountingReports.BackColor = System.Drawing.Color.Firebrick
        Me.btnAccountingReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccountingReports.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAccountingReports.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnAccountingReports.Image = CType(resources.GetObject("btnAccountingReports.Image"), System.Drawing.Image)
        Me.btnAccountingReports.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAccountingReports.Location = New System.Drawing.Point(672, 500)
        Me.btnAccountingReports.Name = "btnAccountingReports"
        Me.btnAccountingReports.Size = New System.Drawing.Size(217, 71)
        Me.btnAccountingReports.TabIndex = 43
        Me.btnAccountingReports.Text = "Accounting Reports"
        Me.btnAccountingReports.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAccountingReports.UseVisualStyleBackColor = False
        '
        'btnPOSReport
        '
        Me.btnPOSReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPOSReport.AutoSize = True
        Me.btnPOSReport.BackColor = System.Drawing.Color.Firebrick
        Me.btnPOSReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPOSReport.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPOSReport.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPOSReport.Image = CType(resources.GetObject("btnPOSReport.Image"), System.Drawing.Image)
        Me.btnPOSReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPOSReport.Location = New System.Drawing.Point(449, 500)
        Me.btnPOSReport.Name = "btnPOSReport"
        Me.btnPOSReport.Size = New System.Drawing.Size(217, 71)
        Me.btnPOSReport.TabIndex = 33
        Me.btnPOSReport.Text = "POS Report"
        Me.btnPOSReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPOSReport.UseVisualStyleBackColor = False
        '
        'btnWarehouse
        '
        Me.btnWarehouse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWarehouse.AutoSize = True
        Me.btnWarehouse.BackColor = System.Drawing.Color.Firebrick
        Me.btnWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWarehouse.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWarehouse.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnWarehouse.Image = CType(resources.GetObject("btnWarehouse.Image"), System.Drawing.Image)
        Me.btnWarehouse.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWarehouse.Location = New System.Drawing.Point(672, 145)
        Me.btnWarehouse.Name = "btnWarehouse"
        Me.btnWarehouse.Size = New System.Drawing.Size(217, 65)
        Me.btnWarehouse.TabIndex = 52
        Me.btnWarehouse.Text = "Warehouse"
        Me.btnWarehouse.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWarehouse.UseVisualStyleBackColor = False
        '
        'btnProductMaster
        '
        Me.btnProductMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnProductMaster.AutoSize = True
        Me.btnProductMaster.BackColor = System.Drawing.Color.Firebrick
        Me.btnProductMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProductMaster.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProductMaster.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnProductMaster.Image = CType(resources.GetObject("btnProductMaster.Image"), System.Drawing.Image)
        Me.btnProductMaster.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnProductMaster.Location = New System.Drawing.Point(3, 216)
        Me.btnProductMaster.Name = "btnProductMaster"
        Me.btnProductMaster.Size = New System.Drawing.Size(217, 65)
        Me.btnProductMaster.TabIndex = 34
        Me.btnProductMaster.Text = "Product Master"
        Me.btnProductMaster.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnProductMaster.UseVisualStyleBackColor = False
        '
        'btnSupplier
        '
        Me.btnSupplier.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSupplier.AutoSize = True
        Me.btnSupplier.BackColor = System.Drawing.Color.Firebrick
        Me.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSupplier.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupplier.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSupplier.Image = CType(resources.GetObject("btnSupplier.Image"), System.Drawing.Image)
        Me.btnSupplier.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSupplier.Location = New System.Drawing.Point(226, 216)
        Me.btnSupplier.Name = "btnSupplier"
        Me.btnSupplier.Size = New System.Drawing.Size(217, 65)
        Me.btnSupplier.TabIndex = 40
        Me.btnSupplier.Text = "Supplier"
        Me.btnSupplier.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSupplier.UseVisualStyleBackColor = False
        '
        'btnCreditCustomer
        '
        Me.btnCreditCustomer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreditCustomer.AutoSize = True
        Me.btnCreditCustomer.BackColor = System.Drawing.Color.Firebrick
        Me.btnCreditCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreditCustomer.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreditCustomer.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCreditCustomer.Image = CType(resources.GetObject("btnCreditCustomer.Image"), System.Drawing.Image)
        Me.btnCreditCustomer.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCreditCustomer.Location = New System.Drawing.Point(449, 216)
        Me.btnCreditCustomer.Name = "btnCreditCustomer"
        Me.btnCreditCustomer.Size = New System.Drawing.Size(217, 65)
        Me.btnCreditCustomer.TabIndex = 60
        Me.btnCreditCustomer.Text = "Credit Customer"
        Me.btnCreditCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCreditCustomer.UseVisualStyleBackColor = False
        '
        'btnPurchaseOrder
        '
        Me.btnPurchaseOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPurchaseOrder.AutoSize = True
        Me.btnPurchaseOrder.BackColor = System.Drawing.Color.Firebrick
        Me.btnPurchaseOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPurchaseOrder.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPurchaseOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPurchaseOrder.Image = CType(resources.GetObject("btnPurchaseOrder.Image"), System.Drawing.Image)
        Me.btnPurchaseOrder.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPurchaseOrder.Location = New System.Drawing.Point(672, 216)
        Me.btnPurchaseOrder.Name = "btnPurchaseOrder"
        Me.btnPurchaseOrder.Size = New System.Drawing.Size(217, 65)
        Me.btnPurchaseOrder.TabIndex = 50
        Me.btnPurchaseOrder.Text = "Purchase Order"
        Me.btnPurchaseOrder.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPurchaseOrder.UseVisualStyleBackColor = False
        '
        'btnPurchase
        '
        Me.btnPurchase.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPurchase.AutoSize = True
        Me.btnPurchase.BackColor = System.Drawing.Color.Firebrick
        Me.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPurchase.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPurchase.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPurchase.Image = CType(resources.GetObject("btnPurchase.Image"), System.Drawing.Image)
        Me.btnPurchase.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPurchase.Location = New System.Drawing.Point(3, 287)
        Me.btnPurchase.Name = "btnPurchase"
        Me.btnPurchase.Size = New System.Drawing.Size(217, 65)
        Me.btnPurchase.TabIndex = 41
        Me.btnPurchase.Text = "Purchase"
        Me.btnPurchase.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPurchase.UseVisualStyleBackColor = False
        '
        'btnPurchaseReturn
        '
        Me.btnPurchaseReturn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPurchaseReturn.AutoSize = True
        Me.btnPurchaseReturn.BackColor = System.Drawing.Color.Firebrick
        Me.btnPurchaseReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPurchaseReturn.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPurchaseReturn.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPurchaseReturn.Image = CType(resources.GetObject("btnPurchaseReturn.Image"), System.Drawing.Image)
        Me.btnPurchaseReturn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPurchaseReturn.Location = New System.Drawing.Point(226, 287)
        Me.btnPurchaseReturn.Name = "btnPurchaseReturn"
        Me.btnPurchaseReturn.Size = New System.Drawing.Size(217, 65)
        Me.btnPurchaseReturn.TabIndex = 36
        Me.btnPurchaseReturn.Text = "Purchase Return"
        Me.btnPurchaseReturn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPurchaseReturn.UseVisualStyleBackColor = False
        '
        'btnSalesReturn
        '
        Me.btnSalesReturn.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalesReturn.BackColor = System.Drawing.Color.Firebrick
        Me.btnSalesReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalesReturn.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalesReturn.ForeColor = System.Drawing.Color.White
        Me.btnSalesReturn.Image = CType(resources.GetObject("btnSalesReturn.Image"), System.Drawing.Image)
        Me.btnSalesReturn.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalesReturn.Location = New System.Drawing.Point(449, 287)
        Me.btnSalesReturn.Name = "btnSalesReturn"
        Me.btnSalesReturn.Size = New System.Drawing.Size(217, 65)
        Me.btnSalesReturn.TabIndex = 61
        Me.btnSalesReturn.Text = "Sales Return"
        Me.btnSalesReturn.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalesReturn.UseVisualStyleBackColor = False
        '
        'btnStockTransfer_Issue
        '
        Me.btnStockTransfer_Issue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStockTransfer_Issue.AutoSize = True
        Me.btnStockTransfer_Issue.BackColor = System.Drawing.Color.Firebrick
        Me.btnStockTransfer_Issue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStockTransfer_Issue.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockTransfer_Issue.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnStockTransfer_Issue.Image = CType(resources.GetObject("btnStockTransfer_Issue.Image"), System.Drawing.Image)
        Me.btnStockTransfer_Issue.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnStockTransfer_Issue.Location = New System.Drawing.Point(672, 287)
        Me.btnStockTransfer_Issue.Name = "btnStockTransfer_Issue"
        Me.btnStockTransfer_Issue.Size = New System.Drawing.Size(217, 65)
        Me.btnStockTransfer_Issue.TabIndex = 55
        Me.btnStockTransfer_Issue.Text = "Stock Transfer/Issue"
        Me.btnStockTransfer_Issue.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnStockTransfer_Issue.UseVisualStyleBackColor = False
        '
        'btnStockAdjustment
        '
        Me.btnStockAdjustment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStockAdjustment.BackColor = System.Drawing.Color.Firebrick
        Me.btnStockAdjustment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStockAdjustment.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockAdjustment.ForeColor = System.Drawing.Color.White
        Me.btnStockAdjustment.Image = CType(resources.GetObject("btnStockAdjustment.Image"), System.Drawing.Image)
        Me.btnStockAdjustment.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnStockAdjustment.Location = New System.Drawing.Point(3, 358)
        Me.btnStockAdjustment.Name = "btnStockAdjustment"
        Me.btnStockAdjustment.Size = New System.Drawing.Size(217, 65)
        Me.btnStockAdjustment.TabIndex = 67
        Me.btnStockAdjustment.Text = "Stock Adjustment"
        Me.btnStockAdjustment.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnStockAdjustment.UseVisualStyleBackColor = False
        '
        'btnUnit
        '
        Me.btnUnit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnUnit.AutoSize = True
        Me.btnUnit.BackColor = System.Drawing.Color.Firebrick
        Me.btnUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUnit.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnit.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnUnit.Image = CType(resources.GetObject("btnUnit.Image"), System.Drawing.Image)
        Me.btnUnit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUnit.Location = New System.Drawing.Point(672, 74)
        Me.btnUnit.Name = "btnUnit"
        Me.btnUnit.Size = New System.Drawing.Size(217, 65)
        Me.btnUnit.TabIndex = 65
        Me.btnUnit.Text = "Unit Master"
        Me.btnUnit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUnit.UseVisualStyleBackColor = False
        '
        'btnWarehouseType
        '
        Me.btnWarehouseType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWarehouseType.AutoSize = True
        Me.btnWarehouseType.BackColor = System.Drawing.Color.Firebrick
        Me.btnWarehouseType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnWarehouseType.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWarehouseType.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnWarehouseType.Image = CType(resources.GetObject("btnWarehouseType.Image"), System.Drawing.Image)
        Me.btnWarehouseType.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnWarehouseType.Location = New System.Drawing.Point(449, 145)
        Me.btnWarehouseType.Name = "btnWarehouseType"
        Me.btnWarehouseType.Size = New System.Drawing.Size(217, 65)
        Me.btnWarehouseType.TabIndex = 53
        Me.btnWarehouseType.Text = "Warehouse Type"
        Me.btnWarehouseType.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnWarehouseType.UseVisualStyleBackColor = False
        '
        'btnSalesmanMaster
        '
        Me.btnSalesmanMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalesmanMaster.AutoSize = True
        Me.btnSalesmanMaster.BackColor = System.Drawing.Color.Firebrick
        Me.btnSalesmanMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalesmanMaster.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalesmanMaster.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSalesmanMaster.Image = CType(resources.GetObject("btnSalesmanMaster.Image"), System.Drawing.Image)
        Me.btnSalesmanMaster.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalesmanMaster.Location = New System.Drawing.Point(226, 145)
        Me.btnSalesmanMaster.Name = "btnSalesmanMaster"
        Me.btnSalesmanMaster.Size = New System.Drawing.Size(217, 65)
        Me.btnSalesmanMaster.TabIndex = 48
        Me.btnSalesmanMaster.Text = "Salesman Master"
        Me.btnSalesmanMaster.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalesmanMaster.UseVisualStyleBackColor = False
        '
        'btnCategories
        '
        Me.btnCategories.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCategories.AutoSize = True
        Me.btnCategories.BackColor = System.Drawing.Color.Firebrick
        Me.btnCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCategories.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCategories.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCategories.Image = CType(resources.GetObject("btnCategories.Image"), System.Drawing.Image)
        Me.btnCategories.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCategories.Location = New System.Drawing.Point(3, 145)
        Me.btnCategories.Name = "btnCategories"
        Me.btnCategories.Size = New System.Drawing.Size(217, 65)
        Me.btnCategories.TabIndex = 22
        Me.btnCategories.Text = "Categories"
        Me.btnCategories.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCategories.UseVisualStyleBackColor = False
        '
        'btnKeyboard
        '
        Me.btnKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnKeyboard.BackColor = System.Drawing.Color.Transparent
        Me.btnKeyboard.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnKeyboard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnKeyboard.FlatAppearance.BorderSize = 0
        Me.btnKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnKeyboard.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnKeyboard.Image = CType(resources.GetObject("btnKeyboard.Image"), System.Drawing.Image)
        Me.btnKeyboard.Location = New System.Drawing.Point(751, 1)
        Me.btnKeyboard.Name = "btnKeyboard"
        Me.btnKeyboard.Size = New System.Drawing.Size(58, 49)
        Me.btnKeyboard.TabIndex = 58
        Me.btnKeyboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeyboard.UseVisualStyleBackColor = False
        '
        'btnMinimize
        '
        Me.btnMinimize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinimize.BackColor = System.Drawing.Color.Transparent
        Me.btnMinimize.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnMinimize.FlatAppearance.BorderSize = 0
        Me.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimize.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMinimize.Image = CType(resources.GetObject("btnMinimize.Image"), System.Drawing.Image)
        Me.btnMinimize.Location = New System.Drawing.Point(808, 1)
        Me.btnMinimize.Name = "btnMinimize"
        Me.btnMinimize.Size = New System.Drawing.Size(52, 49)
        Me.btnMinimize.TabIndex = 35
        Me.btnMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnMinimize.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.Location = New System.Drawing.Point(863, 1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(52, 49)
        Me.btnCancel.TabIndex = 29
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frmBackOffice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(916, 678)
        Me.Controls.Add(Me.btnKeyboard)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btnMinimize)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lblDateTime)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBackOffice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblDateTime As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents btnMinimize As System.Windows.Forms.Button
    Friend WithEvents btnKeyboard As System.Windows.Forms.Button
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents Timer4 As System.Windows.Forms.Timer
    Friend WithEvents btnAccountingReports As System.Windows.Forms.Button
    Friend WithEvents btnProductMaster As System.Windows.Forms.Button
    Friend WithEvents btnPOSReport As System.Windows.Forms.Button
    Friend WithEvents btnPOSRecord As System.Windows.Forms.Button
    Friend WithEvents btnWorkPeriod As System.Windows.Forms.Button
    Friend WithEvents btnBarcodeLabelPrinting As System.Windows.Forms.Button
    Friend WithEvents btnStockTransfer_Issue As System.Windows.Forms.Button
    Friend WithEvents BtnVoucher As System.Windows.Forms.Button
    Friend WithEvents btnExpense As System.Windows.Forms.Button
    Friend WithEvents btnExpenseType As System.Windows.Forms.Button
    Friend WithEvents btnPurchaseReturn As System.Windows.Forms.Button
    Friend WithEvents btnPurchase As System.Windows.Forms.Button
    Friend WithEvents btnPurchaseOrder As System.Windows.Forms.Button
    Friend WithEvents btnSupplier As System.Windows.Forms.Button
    Friend WithEvents btnWarehouse As System.Windows.Forms.Button
    Friend WithEvents btnWarehouseType As System.Windows.Forms.Button
    Friend WithEvents btnCategories As System.Windows.Forms.Button
    Friend WithEvents btnSalesmanMaster As System.Windows.Forms.Button
    Friend WithEvents btnLogs As System.Windows.Forms.Button
    Friend WithEvents btnRegistration As System.Windows.Forms.Button
    Friend WithEvents btnDBRestore As System.Windows.Forms.Button
    Friend WithEvents btnDBBackup As System.Windows.Forms.Button
    Friend WithEvents btnSetting As System.Windows.Forms.Button
    Friend WithEvents btnPayment As System.Windows.Forms.Button
    Friend WithEvents btnCompanyInfo As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCreditCustomer As System.Windows.Forms.Button
    Friend WithEvents btnSalesReturn As System.Windows.Forms.Button
    Friend WithEvents btnRacking As System.Windows.Forms.Button
    Friend WithEvents btnProductsLocation As System.Windows.Forms.Button
    Friend WithEvents btnUnit As System.Windows.Forms.Button
    Friend WithEvents btnWallet As System.Windows.Forms.Button
    Friend WithEvents btnStockAdjustment As System.Windows.Forms.Button
End Class
