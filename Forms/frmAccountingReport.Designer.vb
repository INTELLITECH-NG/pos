<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountingReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountingReport))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnSalesmanCommission = New System.Windows.Forms.Button()
        Me.btnSalesmanLedger = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnLowStock_Store = New System.Windows.Forms.Button()
        Me.btnExpiredProducts_Store = New System.Windows.Forms.Button()
        Me.btnStockOut_Store = New System.Windows.Forms.Button()
        Me.btnStockIn_Store = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnExpiredProducts = New System.Windows.Forms.Button()
        Me.btnStockIN = New System.Windows.Forms.Button()
        Me.btnLowStock_Warehouse = New System.Windows.Forms.Button()
        Me.btnStockOut = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnCreditors = New System.Windows.Forms.Button()
        Me.btnCashBook = New System.Windows.Forms.Button()
        Me.btnGeneralLedger = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnGeneralDaybook = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnProfitandLoss = New System.Windows.Forms.Button()
        Me.btnJournalEntry = New System.Windows.Forms.Button()
        Me.btnBalanceSheet = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnInputTax = New System.Windows.Forms.Button()
        Me.btnStockTransfer_W2W = New System.Windows.Forms.Button()
        Me.btnOutputTax = New System.Windows.Forms.Button()
        Me.btnPurchaseReturn = New System.Windows.Forms.Button()
        Me.btnStockAdjustment_Store = New System.Windows.Forms.Button()
        Me.btnStockAdjustment_Warehouse = New System.Windows.Forms.Button()
        Me.btnVouchers = New System.Windows.Forms.Button()
        Me.btnSalesReturn = New System.Windows.Forms.Button()
        Me.btnStockTransfer_W2S = New System.Windows.Forms.Button()
        Me.btnPurchase = New System.Windows.Forms.Button()
        Me.btnTrialBalance = New System.Windows.Forms.Button()
        Me.btnPurchaseDaybook = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbSupplierName = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSupplierLedger = New System.Windows.Forms.Button()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtSupplierID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.GroupBox7)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Location = New System.Drawing.Point(5, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(811, 654)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnSalesmanCommission)
        Me.GroupBox6.Controls.Add(Me.btnSalesmanLedger)
        Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox6.Location = New System.Drawing.Point(646, 498)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(153, 148)
        Me.GroupBox6.TabIndex = 117
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Salesman"
        '
        'btnSalesmanCommission
        '
        Me.btnSalesmanCommission.BackColor = System.Drawing.Color.Firebrick
        Me.btnSalesmanCommission.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalesmanCommission.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalesmanCommission.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalesmanCommission.ForeColor = System.Drawing.Color.White
        Me.btnSalesmanCommission.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalesmanCommission.Location = New System.Drawing.Point(7, 82)
        Me.btnSalesmanCommission.Name = "btnSalesmanCommission"
        Me.btnSalesmanCommission.Size = New System.Drawing.Size(139, 50)
        Me.btnSalesmanCommission.TabIndex = 115
        Me.btnSalesmanCommission.Text = "Commission"
        Me.btnSalesmanCommission.UseVisualStyleBackColor = False
        '
        'btnSalesmanLedger
        '
        Me.btnSalesmanLedger.BackColor = System.Drawing.Color.Firebrick
        Me.btnSalesmanLedger.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalesmanLedger.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalesmanLedger.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalesmanLedger.ForeColor = System.Drawing.Color.White
        Me.btnSalesmanLedger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalesmanLedger.Location = New System.Drawing.Point(6, 26)
        Me.btnSalesmanLedger.Name = "btnSalesmanLedger"
        Me.btnSalesmanLedger.Size = New System.Drawing.Size(139, 50)
        Me.btnSalesmanLedger.TabIndex = 114
        Me.btnSalesmanLedger.Text = "Ledger"
        Me.btnSalesmanLedger.UseVisualStyleBackColor = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnLowStock_Store)
        Me.GroupBox7.Controls.Add(Me.btnExpiredProducts_Store)
        Me.GroupBox7.Controls.Add(Me.btnStockOut_Store)
        Me.GroupBox7.Controls.Add(Me.btnStockIn_Store)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.Location = New System.Drawing.Point(316, 497)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(324, 152)
        Me.GroupBox7.TabIndex = 116
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Store Inventory"
        '
        'btnLowStock_Store
        '
        Me.btnLowStock_Store.BackColor = System.Drawing.Color.Firebrick
        Me.btnLowStock_Store.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLowStock_Store.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLowStock_Store.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLowStock_Store.ForeColor = System.Drawing.Color.White
        Me.btnLowStock_Store.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLowStock_Store.Location = New System.Drawing.Point(20, 87)
        Me.btnLowStock_Store.Name = "btnLowStock_Store"
        Me.btnLowStock_Store.Size = New System.Drawing.Size(139, 50)
        Me.btnLowStock_Store.TabIndex = 117
        Me.btnLowStock_Store.Text = "Low Stock"
        Me.btnLowStock_Store.UseVisualStyleBackColor = False
        '
        'btnExpiredProducts_Store
        '
        Me.btnExpiredProducts_Store.BackColor = System.Drawing.Color.Firebrick
        Me.btnExpiredProducts_Store.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExpiredProducts_Store.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExpiredProducts_Store.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpiredProducts_Store.ForeColor = System.Drawing.Color.White
        Me.btnExpiredProducts_Store.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExpiredProducts_Store.Location = New System.Drawing.Point(167, 87)
        Me.btnExpiredProducts_Store.Name = "btnExpiredProducts_Store"
        Me.btnExpiredProducts_Store.Size = New System.Drawing.Size(139, 50)
        Me.btnExpiredProducts_Store.TabIndex = 116
        Me.btnExpiredProducts_Store.Text = "Expired Products"
        Me.btnExpiredProducts_Store.UseVisualStyleBackColor = False
        '
        'btnStockOut_Store
        '
        Me.btnStockOut_Store.BackColor = System.Drawing.Color.Firebrick
        Me.btnStockOut_Store.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockOut_Store.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnStockOut_Store.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockOut_Store.ForeColor = System.Drawing.Color.White
        Me.btnStockOut_Store.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockOut_Store.Location = New System.Drawing.Point(167, 31)
        Me.btnStockOut_Store.Name = "btnStockOut_Store"
        Me.btnStockOut_Store.Size = New System.Drawing.Size(139, 50)
        Me.btnStockOut_Store.TabIndex = 113
        Me.btnStockOut_Store.Text = "Stock OUT"
        Me.btnStockOut_Store.UseVisualStyleBackColor = False
        '
        'btnStockIn_Store
        '
        Me.btnStockIn_Store.BackColor = System.Drawing.Color.Firebrick
        Me.btnStockIn_Store.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockIn_Store.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnStockIn_Store.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockIn_Store.ForeColor = System.Drawing.Color.White
        Me.btnStockIn_Store.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockIn_Store.Location = New System.Drawing.Point(20, 31)
        Me.btnStockIn_Store.Name = "btnStockIn_Store"
        Me.btnStockIn_Store.Size = New System.Drawing.Size(139, 50)
        Me.btnStockIn_Store.TabIndex = 112
        Me.btnStockIn_Store.Text = "Stock IN"
        Me.btnStockIn_Store.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnExpiredProducts)
        Me.GroupBox5.Controls.Add(Me.btnStockIN)
        Me.GroupBox5.Controls.Add(Me.btnLowStock_Warehouse)
        Me.GroupBox5.Controls.Add(Me.btnStockOut)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(6, 497)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(304, 152)
        Me.GroupBox5.TabIndex = 114
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Warehouse Inventory"
        '
        'btnExpiredProducts
        '
        Me.btnExpiredProducts.BackColor = System.Drawing.Color.Firebrick
        Me.btnExpiredProducts.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExpiredProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExpiredProducts.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExpiredProducts.ForeColor = System.Drawing.Color.White
        Me.btnExpiredProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExpiredProducts.Location = New System.Drawing.Point(151, 87)
        Me.btnExpiredProducts.Name = "btnExpiredProducts"
        Me.btnExpiredProducts.Size = New System.Drawing.Size(139, 50)
        Me.btnExpiredProducts.TabIndex = 114
        Me.btnExpiredProducts.Text = "Expired Products"
        Me.btnExpiredProducts.UseVisualStyleBackColor = False
        '
        'btnStockIN
        '
        Me.btnStockIN.BackColor = System.Drawing.Color.Firebrick
        Me.btnStockIN.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockIN.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnStockIN.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockIN.ForeColor = System.Drawing.Color.White
        Me.btnStockIN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockIN.Location = New System.Drawing.Point(6, 31)
        Me.btnStockIN.Name = "btnStockIN"
        Me.btnStockIN.Size = New System.Drawing.Size(139, 50)
        Me.btnStockIN.TabIndex = 111
        Me.btnStockIN.Text = "Stock IN"
        Me.btnStockIN.UseVisualStyleBackColor = False
        '
        'btnLowStock_Warehouse
        '
        Me.btnLowStock_Warehouse.BackColor = System.Drawing.Color.Firebrick
        Me.btnLowStock_Warehouse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLowStock_Warehouse.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLowStock_Warehouse.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLowStock_Warehouse.ForeColor = System.Drawing.Color.White
        Me.btnLowStock_Warehouse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLowStock_Warehouse.Location = New System.Drawing.Point(6, 87)
        Me.btnLowStock_Warehouse.Name = "btnLowStock_Warehouse"
        Me.btnLowStock_Warehouse.Size = New System.Drawing.Size(139, 50)
        Me.btnLowStock_Warehouse.TabIndex = 113
        Me.btnLowStock_Warehouse.Text = "Low Stock"
        Me.btnLowStock_Warehouse.UseVisualStyleBackColor = False
        '
        'btnStockOut
        '
        Me.btnStockOut.BackColor = System.Drawing.Color.Firebrick
        Me.btnStockOut.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnStockOut.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockOut.ForeColor = System.Drawing.Color.White
        Me.btnStockOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockOut.Location = New System.Drawing.Point(151, 31)
        Me.btnStockOut.Name = "btnStockOut"
        Me.btnStockOut.Size = New System.Drawing.Size(139, 50)
        Me.btnStockOut.TabIndex = 112
        Me.btnStockOut.Text = "Stock OUT"
        Me.btnStockOut.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnCreditors)
        Me.Panel3.Controls.Add(Me.btnCashBook)
        Me.Panel3.Controls.Add(Me.btnGeneralLedger)
        Me.Panel3.Location = New System.Drawing.Point(344, 406)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(428, 83)
        Me.Panel3.TabIndex = 113
        '
        'btnCreditors
        '
        Me.btnCreditors.BackColor = System.Drawing.Color.Firebrick
        Me.btnCreditors.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCreditors.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCreditors.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreditors.ForeColor = System.Drawing.Color.White
        Me.btnCreditors.Location = New System.Drawing.Point(274, 17)
        Me.btnCreditors.Name = "btnCreditors"
        Me.btnCreditors.Size = New System.Drawing.Size(139, 50)
        Me.btnCreditors.TabIndex = 110
        Me.btnCreditors.Text = "Creditors List"
        Me.btnCreditors.UseVisualStyleBackColor = False
        '
        'btnCashBook
        '
        Me.btnCashBook.BackColor = System.Drawing.Color.Firebrick
        Me.btnCashBook.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCashBook.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCashBook.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCashBook.ForeColor = System.Drawing.Color.White
        Me.btnCashBook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCashBook.Location = New System.Drawing.Point(144, 17)
        Me.btnCashBook.Name = "btnCashBook"
        Me.btnCashBook.Size = New System.Drawing.Size(124, 50)
        Me.btnCashBook.TabIndex = 7
        Me.btnCashBook.Text = "Cash Book"
        Me.btnCashBook.UseVisualStyleBackColor = False
        '
        'btnGeneralLedger
        '
        Me.btnGeneralLedger.BackColor = System.Drawing.Color.Firebrick
        Me.btnGeneralLedger.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGeneralLedger.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGeneralLedger.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGeneralLedger.ForeColor = System.Drawing.Color.White
        Me.btnGeneralLedger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGeneralLedger.Location = New System.Drawing.Point(14, 17)
        Me.btnGeneralLedger.Name = "btnGeneralLedger"
        Me.btnGeneralLedger.Size = New System.Drawing.Size(124, 50)
        Me.btnGeneralLedger.TabIndex = 6
        Me.btnGeneralLedger.Text = "General Ledger"
        Me.btnGeneralLedger.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnGeneralDaybook)
        Me.GroupBox4.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(6, 396)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(332, 95)
        Me.GroupBox4.TabIndex = 112
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Search By Date"
        '
        'btnGeneralDaybook
        '
        Me.btnGeneralDaybook.BackColor = System.Drawing.Color.Firebrick
        Me.btnGeneralDaybook.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGeneralDaybook.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGeneralDaybook.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGeneralDaybook.ForeColor = System.Drawing.Color.White
        Me.btnGeneralDaybook.Location = New System.Drawing.Point(185, 30)
        Me.btnGeneralDaybook.Name = "btnGeneralDaybook"
        Me.btnGeneralDaybook.Size = New System.Drawing.Size(139, 50)
        Me.btnGeneralDaybook.TabIndex = 108
        Me.btnGeneralDaybook.Text = "General Daybook"
        Me.btnGeneralDaybook.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(27, 41)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(152, 29)
        Me.DateTimePicker1.TabIndex = 107
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.Panel5)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(799, 266)
        Me.GroupBox3.TabIndex = 111
        Me.GroupBox3.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnProfitandLoss)
        Me.GroupBox1.Controls.Add(Me.btnJournalEntry)
        Me.GroupBox1.Controls.Add(Me.btnBalanceSheet)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpDateTo)
        Me.GroupBox1.Controls.Add(Me.lblUser)
        Me.GroupBox1.Controls.Add(Me.dtpDateFrom)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(355, 210)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search By Date :"
        '
        'btnProfitandLoss
        '
        Me.btnProfitandLoss.BackColor = System.Drawing.Color.Firebrick
        Me.btnProfitandLoss.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnProfitandLoss.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnProfitandLoss.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProfitandLoss.ForeColor = System.Drawing.Color.White
        Me.btnProfitandLoss.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProfitandLoss.Location = New System.Drawing.Point(167, 95)
        Me.btnProfitandLoss.Name = "btnProfitandLoss"
        Me.btnProfitandLoss.Size = New System.Drawing.Size(139, 50)
        Me.btnProfitandLoss.TabIndex = 119
        Me.btnProfitandLoss.Text = "Profit and Loss"
        Me.btnProfitandLoss.UseVisualStyleBackColor = False
        '
        'btnJournalEntry
        '
        Me.btnJournalEntry.BackColor = System.Drawing.Color.Firebrick
        Me.btnJournalEntry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnJournalEntry.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnJournalEntry.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJournalEntry.ForeColor = System.Drawing.Color.White
        Me.btnJournalEntry.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnJournalEntry.Location = New System.Drawing.Point(21, 95)
        Me.btnJournalEntry.Name = "btnJournalEntry"
        Me.btnJournalEntry.Size = New System.Drawing.Size(139, 50)
        Me.btnJournalEntry.TabIndex = 117
        Me.btnJournalEntry.Text = "Journal Entry"
        Me.btnJournalEntry.UseVisualStyleBackColor = False
        '
        'btnBalanceSheet
        '
        Me.btnBalanceSheet.BackColor = System.Drawing.Color.Firebrick
        Me.btnBalanceSheet.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBalanceSheet.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBalanceSheet.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBalanceSheet.ForeColor = System.Drawing.Color.White
        Me.btnBalanceSheet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBalanceSheet.Location = New System.Drawing.Point(22, 151)
        Me.btnBalanceSheet.Name = "btnBalanceSheet"
        Me.btnBalanceSheet.Size = New System.Drawing.Size(139, 50)
        Me.btnBalanceSheet.TabIndex = 118
        Me.btnBalanceSheet.Text = "Balance Sheet"
        Me.btnBalanceSheet.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(185, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 25)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "To :"
        '
        'dtpDateTo
        '
        Me.dtpDateTo.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateTo.Location = New System.Drawing.Point(189, 60)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(156, 29)
        Me.dtpDateTo.TabIndex = 107
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(278, 32)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(50, 25)
        Me.lblUser.TabIndex = 400
        Me.lblUser.Text = "User"
        Me.lblUser.Visible = False
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.dtpDateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFrom.Location = New System.Drawing.Point(22, 60)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(152, 29)
        Me.dtpDateFrom.TabIndex = 106
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 25)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "From :"
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.btnInputTax)
        Me.Panel5.Controls.Add(Me.btnStockTransfer_W2W)
        Me.Panel5.Controls.Add(Me.btnOutputTax)
        Me.Panel5.Controls.Add(Me.btnPurchaseReturn)
        Me.Panel5.Controls.Add(Me.btnStockAdjustment_Store)
        Me.Panel5.Controls.Add(Me.btnStockAdjustment_Warehouse)
        Me.Panel5.Controls.Add(Me.btnVouchers)
        Me.Panel5.Controls.Add(Me.btnSalesReturn)
        Me.Panel5.Controls.Add(Me.btnStockTransfer_W2S)
        Me.Panel5.Controls.Add(Me.btnPurchase)
        Me.Panel5.Controls.Add(Me.btnTrialBalance)
        Me.Panel5.Controls.Add(Me.btnPurchaseDaybook)
        Me.Panel5.Location = New System.Drawing.Point(367, 19)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(426, 239)
        Me.Panel5.TabIndex = 42
        '
        'btnInputTax
        '
        Me.btnInputTax.BackColor = System.Drawing.Color.Firebrick
        Me.btnInputTax.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInputTax.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnInputTax.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInputTax.ForeColor = System.Drawing.Color.White
        Me.btnInputTax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInputTax.Location = New System.Drawing.Point(149, 180)
        Me.btnInputTax.Name = "btnInputTax"
        Me.btnInputTax.Size = New System.Drawing.Size(124, 50)
        Me.btnInputTax.TabIndex = 43
        Me.btnInputTax.Text = "Input Tax"
        Me.btnInputTax.UseVisualStyleBackColor = False
        '
        'btnStockTransfer_W2W
        '
        Me.btnStockTransfer_W2W.BackColor = System.Drawing.Color.Firebrick
        Me.btnStockTransfer_W2W.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockTransfer_W2W.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnStockTransfer_W2W.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockTransfer_W2W.ForeColor = System.Drawing.Color.White
        Me.btnStockTransfer_W2W.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockTransfer_W2W.Location = New System.Drawing.Point(150, 68)
        Me.btnStockTransfer_W2W.Name = "btnStockTransfer_W2W"
        Me.btnStockTransfer_W2W.Size = New System.Drawing.Size(123, 50)
        Me.btnStockTransfer_W2W.TabIndex = 18
        Me.btnStockTransfer_W2W.Text = "Stock Transfer(W2W)"
        Me.btnStockTransfer_W2W.UseVisualStyleBackColor = False
        '
        'btnOutputTax
        '
        Me.btnOutputTax.BackColor = System.Drawing.Color.Firebrick
        Me.btnOutputTax.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOutputTax.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOutputTax.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOutputTax.ForeColor = System.Drawing.Color.White
        Me.btnOutputTax.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOutputTax.Location = New System.Drawing.Point(279, 180)
        Me.btnOutputTax.Name = "btnOutputTax"
        Me.btnOutputTax.Size = New System.Drawing.Size(135, 50)
        Me.btnOutputTax.TabIndex = 15
        Me.btnOutputTax.Text = "Output Tax"
        Me.btnOutputTax.UseVisualStyleBackColor = False
        '
        'btnPurchaseReturn
        '
        Me.btnPurchaseReturn.BackColor = System.Drawing.Color.Firebrick
        Me.btnPurchaseReturn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPurchaseReturn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPurchaseReturn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPurchaseReturn.ForeColor = System.Drawing.Color.White
        Me.btnPurchaseReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPurchaseReturn.Location = New System.Drawing.Point(7, 124)
        Me.btnPurchaseReturn.Name = "btnPurchaseReturn"
        Me.btnPurchaseReturn.Size = New System.Drawing.Size(139, 50)
        Me.btnPurchaseReturn.TabIndex = 17
        Me.btnPurchaseReturn.Text = "Purchase Return"
        Me.btnPurchaseReturn.UseVisualStyleBackColor = False
        '
        'btnStockAdjustment_Store
        '
        Me.btnStockAdjustment_Store.BackColor = System.Drawing.Color.Firebrick
        Me.btnStockAdjustment_Store.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockAdjustment_Store.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnStockAdjustment_Store.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockAdjustment_Store.ForeColor = System.Drawing.Color.White
        Me.btnStockAdjustment_Store.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockAdjustment_Store.Location = New System.Drawing.Point(7, 180)
        Me.btnStockAdjustment_Store.Name = "btnStockAdjustment_Store"
        Me.btnStockAdjustment_Store.Size = New System.Drawing.Size(139, 50)
        Me.btnStockAdjustment_Store.TabIndex = 16
        Me.btnStockAdjustment_Store.Text = "Stock Adjustment(S)"
        Me.btnStockAdjustment_Store.UseVisualStyleBackColor = False
        '
        'btnStockAdjustment_Warehouse
        '
        Me.btnStockAdjustment_Warehouse.BackColor = System.Drawing.Color.Firebrick
        Me.btnStockAdjustment_Warehouse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockAdjustment_Warehouse.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnStockAdjustment_Warehouse.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockAdjustment_Warehouse.ForeColor = System.Drawing.Color.White
        Me.btnStockAdjustment_Warehouse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockAdjustment_Warehouse.Location = New System.Drawing.Point(279, 124)
        Me.btnStockAdjustment_Warehouse.Name = "btnStockAdjustment_Warehouse"
        Me.btnStockAdjustment_Warehouse.Size = New System.Drawing.Size(135, 50)
        Me.btnStockAdjustment_Warehouse.TabIndex = 13
        Me.btnStockAdjustment_Warehouse.Text = "Stock Adjustment(W)"
        Me.btnStockAdjustment_Warehouse.UseVisualStyleBackColor = False
        '
        'btnVouchers
        '
        Me.btnVouchers.BackColor = System.Drawing.Color.Firebrick
        Me.btnVouchers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVouchers.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVouchers.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVouchers.ForeColor = System.Drawing.Color.White
        Me.btnVouchers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnVouchers.Location = New System.Drawing.Point(150, 124)
        Me.btnVouchers.Name = "btnVouchers"
        Me.btnVouchers.Size = New System.Drawing.Size(123, 50)
        Me.btnVouchers.TabIndex = 11
        Me.btnVouchers.Text = "Vouchers"
        Me.btnVouchers.UseVisualStyleBackColor = False
        '
        'btnSalesReturn
        '
        Me.btnSalesReturn.BackColor = System.Drawing.Color.Firebrick
        Me.btnSalesReturn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalesReturn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSalesReturn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalesReturn.ForeColor = System.Drawing.Color.White
        Me.btnSalesReturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalesReturn.Location = New System.Drawing.Point(279, 68)
        Me.btnSalesReturn.Name = "btnSalesReturn"
        Me.btnSalesReturn.Size = New System.Drawing.Size(135, 50)
        Me.btnSalesReturn.TabIndex = 14
        Me.btnSalesReturn.Text = "Sales Return"
        Me.btnSalesReturn.UseVisualStyleBackColor = False
        '
        'btnStockTransfer_W2S
        '
        Me.btnStockTransfer_W2S.BackColor = System.Drawing.Color.Firebrick
        Me.btnStockTransfer_W2S.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStockTransfer_W2S.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnStockTransfer_W2S.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStockTransfer_W2S.ForeColor = System.Drawing.Color.White
        Me.btnStockTransfer_W2S.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStockTransfer_W2S.Location = New System.Drawing.Point(7, 68)
        Me.btnStockTransfer_W2S.Name = "btnStockTransfer_W2S"
        Me.btnStockTransfer_W2S.Size = New System.Drawing.Size(139, 50)
        Me.btnStockTransfer_W2S.TabIndex = 12
        Me.btnStockTransfer_W2S.Text = "Stock Transfer(W2S)"
        Me.btnStockTransfer_W2S.UseVisualStyleBackColor = False
        '
        'btnPurchase
        '
        Me.btnPurchase.BackColor = System.Drawing.Color.Firebrick
        Me.btnPurchase.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPurchase.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPurchase.ForeColor = System.Drawing.Color.White
        Me.btnPurchase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPurchase.Location = New System.Drawing.Point(279, 13)
        Me.btnPurchase.Name = "btnPurchase"
        Me.btnPurchase.Size = New System.Drawing.Size(135, 50)
        Me.btnPurchase.TabIndex = 9
        Me.btnPurchase.Text = "Purchases"
        Me.btnPurchase.UseVisualStyleBackColor = False
        '
        'btnTrialBalance
        '
        Me.btnTrialBalance.BackColor = System.Drawing.Color.Firebrick
        Me.btnTrialBalance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTrialBalance.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTrialBalance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTrialBalance.ForeColor = System.Drawing.Color.White
        Me.btnTrialBalance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTrialBalance.Location = New System.Drawing.Point(150, 13)
        Me.btnTrialBalance.Name = "btnTrialBalance"
        Me.btnTrialBalance.Size = New System.Drawing.Size(123, 50)
        Me.btnTrialBalance.TabIndex = 8
        Me.btnTrialBalance.Text = "Trial Balance"
        Me.btnTrialBalance.UseVisualStyleBackColor = False
        '
        'btnPurchaseDaybook
        '
        Me.btnPurchaseDaybook.BackColor = System.Drawing.Color.Firebrick
        Me.btnPurchaseDaybook.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPurchaseDaybook.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPurchaseDaybook.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPurchaseDaybook.ForeColor = System.Drawing.Color.White
        Me.btnPurchaseDaybook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPurchaseDaybook.Location = New System.Drawing.Point(7, 13)
        Me.btnPurchaseDaybook.Name = "btnPurchaseDaybook"
        Me.btnPurchaseDaybook.Size = New System.Drawing.Size(139, 50)
        Me.btnPurchaseDaybook.TabIndex = 5
        Me.btnPurchaseDaybook.Text = "Purchase Daybook"
        Me.btnPurchaseDaybook.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbSupplierName)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.btnSupplierLedger)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker3)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 274)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(758, 116)
        Me.GroupBox2.TabIndex = 110
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search by Supplier Name and Date"
        '
        'cmbSupplierName
        '
        Me.cmbSupplierName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbSupplierName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSupplierName.FormattingEnabled = True
        Me.cmbSupplierName.Location = New System.Drawing.Point(20, 65)
        Me.cmbSupplierName.Name = "cmbSupplierName"
        Me.cmbSupplierName.Size = New System.Drawing.Size(234, 32)
        Me.cmbSupplierName.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 24)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Supplier Name :"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(449, 64)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(170, 29)
        Me.DateTimePicker2.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(445, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 24)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "To :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(262, 38)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 24)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "From :"
        '
        'btnSupplierLedger
        '
        Me.btnSupplierLedger.BackColor = System.Drawing.Color.Firebrick
        Me.btnSupplierLedger.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSupplierLedger.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSupplierLedger.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSupplierLedger.ForeColor = System.Drawing.Color.White
        Me.btnSupplierLedger.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSupplierLedger.Location = New System.Drawing.Point(625, 54)
        Me.btnSupplierLedger.Name = "btnSupplierLedger"
        Me.btnSupplierLedger.Size = New System.Drawing.Size(124, 50)
        Me.btnSupplierLedger.TabIndex = 7
        Me.btnSupplierLedger.Text = "Supplier Ledger"
        Me.btnSupplierLedger.UseVisualStyleBackColor = False
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.CustomFormat = "dd/MM/yyyy"
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker3.Location = New System.Drawing.Point(260, 64)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(183, 29)
        Me.DateTimePicker3.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Firebrick
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.txtSupplierID)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(1, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(667, 41)
        Me.Panel2.TabIndex = 0
        '
        'txtSupplierID
        '
        Me.txtSupplierID.Location = New System.Drawing.Point(47, 12)
        Me.txtSupplierID.Name = "txtSupplierID"
        Me.txtSupplierID.Size = New System.Drawing.Size(16, 20)
        Me.txtSupplierID.TabIndex = 2
        Me.txtSupplierID.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(267, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(203, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Accounting Reports"
        '
        'Timer1
        '
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.White
        Me.btnReset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.ForeColor = System.Drawing.Color.Black
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReset.Location = New System.Drawing.Point(698, 2)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(80, 41)
        Me.btnReset.TabIndex = 0
        Me.btnReset.Text = "Reset"
        Me.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(781, 1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 41)
        Me.btnClose.TabIndex = 4
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'frmAccountingReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Firebrick
        Me.ClientSize = New System.Drawing.Size(822, 702)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAccountingReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnPurchaseDaybook As System.Windows.Forms.Button
    Friend WithEvents dtpDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGeneralLedger As System.Windows.Forms.Button
    Friend WithEvents btnSupplierLedger As System.Windows.Forms.Button
    Friend WithEvents btnPurchase As System.Windows.Forms.Button
    Friend WithEvents btnTrialBalance As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnGeneralDaybook As System.Windows.Forms.Button
    Friend WithEvents btnVouchers As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSupplierName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSupplierID As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnCreditors As System.Windows.Forms.Button
    Friend WithEvents btnStockTransfer_W2S As System.Windows.Forms.Button
    Friend WithEvents btnStockIN As System.Windows.Forms.Button
    Friend WithEvents btnStockOut As System.Windows.Forms.Button
    Friend WithEvents btnLowStock_Warehouse As System.Windows.Forms.Button
    Friend WithEvents btnExpiredProducts As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStockOut_Store As System.Windows.Forms.Button
    Friend WithEvents btnStockIn_Store As System.Windows.Forms.Button
    Friend WithEvents btnExpiredProducts_Store As System.Windows.Forms.Button
    Friend WithEvents btnPurchaseReturn As System.Windows.Forms.Button
    Friend WithEvents btnStockAdjustment_Store As System.Windows.Forms.Button
    Friend WithEvents btnOutputTax As System.Windows.Forms.Button
    Friend WithEvents btnSalesReturn As System.Windows.Forms.Button
    Friend WithEvents btnStockAdjustment_Warehouse As System.Windows.Forms.Button
    Friend WithEvents btnStockTransfer_W2W As System.Windows.Forms.Button
    Friend WithEvents btnInputTax As System.Windows.Forms.Button
    Friend WithEvents btnCashBook As System.Windows.Forms.Button
    Friend WithEvents btnLowStock_Store As System.Windows.Forms.Button
    Friend WithEvents btnJournalEntry As System.Windows.Forms.Button
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents btnProfitandLoss As System.Windows.Forms.Button
    Friend WithEvents btnBalanceSheet As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSalesmanCommission As System.Windows.Forms.Button
    Friend WithEvents btnSalesmanLedger As System.Windows.Forms.Button

End Class
