<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchaseEntry
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
        Dim Label13 As System.Windows.Forms.Label
        Dim Label33 As System.Windows.Forms.Label
        Dim Label41 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPurchaseEntry))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dtpSupplierInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtSupplierInvoiceNo = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtRemarks = New System.Windows.Forms.RichTextBox()
        Me.gbPartyInfo = New System.Windows.Forms.GroupBox()
        Me.btnSelection = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSupplierID = New System.Windows.Forms.TextBox()
        Me.lblBalance = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtContactNo = New System.Windows.Forms.TextBox()
        Me.txtSupplierName = New System.Windows.Forms.TextBox()
        Me.txtAddressLine2 = New System.Windows.Forms.TextBox()
        Me.txtAddressLine1 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.pnlCalc = New System.Windows.Forms.Panel()
        Me.txtVATAmt = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtVAT = New System.Windows.Forms.TextBox()
        Me.txtDisc = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.txtDiscPer = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtPreviousDue = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtRoundOff = New System.Windows.Forms.TextBox()
        Me.txtGrandTotal = New System.Windows.Forms.TextBox()
        Me.txtOtherCharges = New System.Windows.Forms.TextBox()
        Me.txtFreightCharges = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtSubTotal = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnLoadProducts = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnScanBarcode = New System.Windows.Forms.Button()
        Me.cmbStorageType = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtpExpiryDate = New System.Windows.Forms.DateTimePicker()
        Me.txtExpiryDate = New System.Windows.Forms.TextBox()
        Me.txtManufacturingDate = New System.Windows.Forms.TextBox()
        Me.dtpManufacturingDate = New System.Windows.Forms.DateTimePicker()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtSalesRate = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtProductCode = New System.Windows.Forms.TextBox()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.lblUnit = New System.Windows.Forms.Label()
        Me.cmbWarehouse = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbProductName = New System.Windows.Forms.ComboBox()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.txtPricePerQty = New System.Windows.Forms.TextBox()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cmbTaxType = New System.Windows.Forms.ComboBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtReferenceNo2 = New System.Windows.Forms.TextBox()
        Me.txtReferenceNo1 = New System.Windows.Forms.TextBox()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalPaid = New System.Windows.Forms.TextBox()
        Me.txtBalance = New System.Windows.Forms.TextBox()
        Me.cmbPurchaseType = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtProductID = New System.Windows.Forms.TextBox()
        Me.lblUserType = New System.Windows.Forms.Label()
        Me.lblSet = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtSup_ID = New System.Windows.Forms.TextBox()
        Me.txtST_ID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button()
        Label13 = New System.Windows.Forms.Label()
        Label33 = New System.Windows.Forms.Label()
        Label41 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.gbPartyInfo.SuspendLayout()
        Me.pnlCalc.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label13
        '
        Label13.AutoSize = True
        Label13.ForeColor = System.Drawing.Color.Black
        Label13.Location = New System.Drawing.Point(15, 120)
        Label13.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label13.Name = "Label13"
        Label13.Size = New System.Drawing.Size(107, 13)
        Label13.TabIndex = 341
        Label13.Text = "Manufacturing Date :"
        '
        'Label33
        '
        Label33.AutoSize = True
        Label33.ForeColor = System.Drawing.Color.Black
        Label33.Location = New System.Drawing.Point(15, 146)
        Label33.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label33.Name = "Label33"
        Label33.Size = New System.Drawing.Size(67, 13)
        Label33.TabIndex = 340
        Label33.Text = "Expiry Date :"
        '
        'Label41
        '
        Label41.AutoSize = True
        Label41.ForeColor = System.Drawing.Color.Black
        Label41.Location = New System.Drawing.Point(535, 17)
        Label41.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Label41.Name = "Label41"
        Label41.Size = New System.Drawing.Size(77, 13)
        Label41.TabIndex = 343
        Label41.Text = "Storage Type :"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.txtRemarks)
        Me.Panel1.Controls.Add(Me.gbPartyInfo)
        Me.Panel1.Controls.Add(Me.pnlCalc)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.DataGridView1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.txtTotalPaid)
        Me.Panel1.Controls.Add(Me.txtBalance)
        Me.Panel1.Location = New System.Drawing.Point(9, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1004, 651)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dtpSupplierInvoiceDate)
        Me.GroupBox4.Controls.Add(Me.Label39)
        Me.GroupBox4.Controls.Add(Me.txtSupplierInvoiceNo)
        Me.GroupBox4.Controls.Add(Me.Label40)
        Me.GroupBox4.Location = New System.Drawing.Point(257, 200)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(248, 85)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Supplier's Invoice Info"
        '
        'dtpSupplierInvoiceDate
        '
        Me.dtpSupplierInvoiceDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpSupplierInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSupplierInvoiceDate.Location = New System.Drawing.Point(112, 51)
        Me.dtpSupplierInvoiceDate.Name = "dtpSupplierInvoiceDate"
        Me.dtpSupplierInvoiceDate.Size = New System.Drawing.Size(124, 20)
        Me.dtpSupplierInvoiceDate.TabIndex = 1
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(14, 25)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(68, 13)
        Me.Label39.TabIndex = 7
        Me.Label39.Text = "Invoice No. :"
        '
        'txtSupplierInvoiceNo
        '
        Me.txtSupplierInvoiceNo.BackColor = System.Drawing.Color.White
        Me.txtSupplierInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplierInvoiceNo.Location = New System.Drawing.Point(112, 25)
        Me.txtSupplierInvoiceNo.Name = "txtSupplierInvoiceNo"
        Me.txtSupplierInvoiceNo.Size = New System.Drawing.Size(124, 21)
        Me.txtSupplierInvoiceNo.TabIndex = 0
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(15, 51)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(74, 13)
        Me.Label40.TabIndex = 9
        Me.Label40.Text = "Invoice Date :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnNew)
        Me.GroupBox3.Controls.Add(Me.btnGetData)
        Me.GroupBox3.Controls.Add(Me.btnSave)
        Me.GroupBox3.Controls.Add(Me.btnDelete)
        Me.GroupBox3.Location = New System.Drawing.Point(688, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(112, 205)
        Me.GroupBox3.TabIndex = 314
        Me.GroupBox3.TabStop = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.Color.Firebrick
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNew.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.ForeColor = System.Drawing.Color.White
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNew.Location = New System.Drawing.Point(8, 14)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(92, 40)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'btnGetData
        '
        Me.btnGetData.BackColor = System.Drawing.Color.Firebrick
        Me.btnGetData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnGetData.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetData.ForeColor = System.Drawing.Color.White
        Me.btnGetData.Image = CType(resources.GetObject("btnGetData.Image"), System.Drawing.Image)
        Me.btnGetData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGetData.Location = New System.Drawing.Point(8, 151)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(92, 40)
        Me.btnGetData.TabIndex = 5
        Me.btnGetData.Text = "Get Data"
        Me.btnGetData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGetData.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Firebrick
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(8, 60)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(92, 40)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.Firebrick
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Enabled = False
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(8, 106)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(92, 40)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(67, 205)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(184, 80)
        Me.txtRemarks.TabIndex = 310
        Me.txtRemarks.Text = ""
        '
        'gbPartyInfo
        '
        Me.gbPartyInfo.Controls.Add(Me.btnSelection)
        Me.gbPartyInfo.Controls.Add(Me.Label10)
        Me.gbPartyInfo.Controls.Add(Me.txtSupplierID)
        Me.gbPartyInfo.Controls.Add(Me.lblBalance)
        Me.gbPartyInfo.Controls.Add(Me.Label11)
        Me.gbPartyInfo.Controls.Add(Me.txtContactNo)
        Me.gbPartyInfo.Controls.Add(Me.txtSupplierName)
        Me.gbPartyInfo.Controls.Add(Me.txtAddressLine2)
        Me.gbPartyInfo.Controls.Add(Me.txtAddressLine1)
        Me.gbPartyInfo.Controls.Add(Me.Label26)
        Me.gbPartyInfo.Controls.Add(Me.Label30)
        Me.gbPartyInfo.Controls.Add(Me.Label36)
        Me.gbPartyInfo.Location = New System.Drawing.Point(259, 4)
        Me.gbPartyInfo.Name = "gbPartyInfo"
        Me.gbPartyInfo.Size = New System.Drawing.Size(423, 196)
        Me.gbPartyInfo.TabIndex = 1
        Me.gbPartyInfo.TabStop = False
        Me.gbPartyInfo.Text = "Supplier Info"
        '
        'btnSelection
        '
        Me.btnSelection.Location = New System.Drawing.Point(199, 25)
        Me.btnSelection.Name = "btnSelection"
        Me.btnSelection.Size = New System.Drawing.Size(29, 21)
        Me.btnSelection.TabIndex = 6
        Me.btnSelection.Text = "..."
        Me.btnSelection.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 13)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Supplier Name :"
        '
        'txtSupplierID
        '
        Me.txtSupplierID.BackColor = System.Drawing.SystemColors.Control
        Me.txtSupplierID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplierID.Location = New System.Drawing.Point(95, 25)
        Me.txtSupplierID.Name = "txtSupplierID"
        Me.txtSupplierID.ReadOnly = True
        Me.txtSupplierID.Size = New System.Drawing.Size(98, 21)
        Me.txtSupplierID.TabIndex = 0
        '
        'lblBalance
        '
        Me.lblBalance.AutoSize = True
        Me.lblBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBalance.ForeColor = System.Drawing.Color.Maroon
        Me.lblBalance.Location = New System.Drawing.Point(91, 166)
        Me.lblBalance.Name = "lblBalance"
        Me.lblBalance.Size = New System.Drawing.Size(44, 20)
        Me.lblBalance.TabIndex = 5
        Me.lblBalance.Text = "0.00"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 166)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 20)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Balance :"
        '
        'txtContactNo
        '
        Me.txtContactNo.BackColor = System.Drawing.SystemColors.Control
        Me.txtContactNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContactNo.Location = New System.Drawing.Point(95, 133)
        Me.txtContactNo.Name = "txtContactNo"
        Me.txtContactNo.ReadOnly = True
        Me.txtContactNo.Size = New System.Drawing.Size(315, 21)
        Me.txtContactNo.TabIndex = 4
        '
        'txtSupplierName
        '
        Me.txtSupplierName.BackColor = System.Drawing.SystemColors.Control
        Me.txtSupplierName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplierName.Location = New System.Drawing.Point(95, 52)
        Me.txtSupplierName.Name = "txtSupplierName"
        Me.txtSupplierName.ReadOnly = True
        Me.txtSupplierName.Size = New System.Drawing.Size(315, 21)
        Me.txtSupplierName.TabIndex = 1
        '
        'txtAddressLine2
        '
        Me.txtAddressLine2.BackColor = System.Drawing.SystemColors.Control
        Me.txtAddressLine2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddressLine2.Location = New System.Drawing.Point(95, 106)
        Me.txtAddressLine2.Name = "txtAddressLine2"
        Me.txtAddressLine2.ReadOnly = True
        Me.txtAddressLine2.Size = New System.Drawing.Size(315, 21)
        Me.txtAddressLine2.TabIndex = 3
        '
        'txtAddressLine1
        '
        Me.txtAddressLine1.BackColor = System.Drawing.SystemColors.Control
        Me.txtAddressLine1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddressLine1.Location = New System.Drawing.Point(95, 79)
        Me.txtAddressLine1.Name = "txtAddressLine1"
        Me.txtAddressLine1.ReadOnly = True
        Me.txtAddressLine1.Size = New System.Drawing.Size(315, 21)
        Me.txtAddressLine1.TabIndex = 2
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(11, 133)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(70, 13)
        Me.Label26.TabIndex = 29
        Me.Label26.Text = "Contact No. :"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(11, 77)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(51, 13)
        Me.Label30.TabIndex = 26
        Me.Label30.Text = "Address :"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(11, 25)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(65, 13)
        Me.Label36.TabIndex = 23
        Me.Label36.Text = "Supplier ID :"
        '
        'pnlCalc
        '
        Me.pnlCalc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCalc.BackColor = System.Drawing.Color.Transparent
        Me.pnlCalc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCalc.Controls.Add(Me.txtVATAmt)
        Me.pnlCalc.Controls.Add(Me.Label14)
        Me.pnlCalc.Controls.Add(Me.Label21)
        Me.pnlCalc.Controls.Add(Me.txtVAT)
        Me.pnlCalc.Controls.Add(Me.txtDisc)
        Me.pnlCalc.Controls.Add(Me.Label45)
        Me.pnlCalc.Controls.Add(Me.Label46)
        Me.pnlCalc.Controls.Add(Me.txtDiscPer)
        Me.pnlCalc.Controls.Add(Me.Label32)
        Me.pnlCalc.Controls.Add(Me.txtTotal)
        Me.pnlCalc.Controls.Add(Me.Label24)
        Me.pnlCalc.Controls.Add(Me.txtPreviousDue)
        Me.pnlCalc.Controls.Add(Me.Label18)
        Me.pnlCalc.Controls.Add(Me.Label17)
        Me.pnlCalc.Controls.Add(Me.Label16)
        Me.pnlCalc.Controls.Add(Me.txtRoundOff)
        Me.pnlCalc.Controls.Add(Me.txtGrandTotal)
        Me.pnlCalc.Controls.Add(Me.txtOtherCharges)
        Me.pnlCalc.Controls.Add(Me.txtFreightCharges)
        Me.pnlCalc.Controls.Add(Me.Label15)
        Me.pnlCalc.Controls.Add(Me.txtSubTotal)
        Me.pnlCalc.Controls.Add(Me.Label31)
        Me.pnlCalc.Location = New System.Drawing.Point(796, 361)
        Me.pnlCalc.Name = "pnlCalc"
        Me.pnlCalc.Size = New System.Drawing.Size(202, 281)
        Me.pnlCalc.TabIndex = 4
        '
        'txtVATAmt
        '
        Me.txtVATAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVATAmt.Location = New System.Drawing.Point(103, 92)
        Me.txtVATAmt.Name = "txtVATAmt"
        Me.txtVATAmt.ReadOnly = True
        Me.txtVATAmt.Size = New System.Drawing.Size(88, 20)
        Me.txtVATAmt.TabIndex = 4
        Me.txtVATAmt.Text = "0.00"
        Me.txtVATAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(78, 94)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(20, 16)
        Me.Label14.TabIndex = 334
        Me.Label14.Text = "%"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(10, 76)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(34, 13)
        Me.Label21.TabIndex = 333
        Me.Label21.Text = "VAT :"
        '
        'txtVAT
        '
        Me.txtVAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVAT.Location = New System.Drawing.Point(10, 92)
        Me.txtVAT.Name = "txtVAT"
        Me.txtVAT.Size = New System.Drawing.Size(62, 20)
        Me.txtVAT.TabIndex = 3
        Me.txtVAT.Text = "0.00"
        Me.txtVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDisc
        '
        Me.txtDisc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDisc.Location = New System.Drawing.Point(103, 46)
        Me.txtDisc.Name = "txtDisc"
        Me.txtDisc.ReadOnly = True
        Me.txtDisc.Size = New System.Drawing.Size(88, 20)
        Me.txtDisc.TabIndex = 2
        Me.txtDisc.Text = "0.00"
        Me.txtDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(78, 48)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(20, 16)
        Me.Label45.TabIndex = 330
        Me.Label45.Text = "%"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(10, 30)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(55, 13)
        Me.Label46.TabIndex = 329
        Me.Label46.Text = "Discount :"
        '
        'txtDiscPer
        '
        Me.txtDiscPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiscPer.Location = New System.Drawing.Point(10, 46)
        Me.txtDiscPer.Name = "txtDiscPer"
        Me.txtDiscPer.Size = New System.Drawing.Size(62, 20)
        Me.txtDiscPer.TabIndex = 1
        Me.txtDiscPer.Text = "0.00"
        Me.txtDiscPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(10, 197)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(37, 13)
        Me.Label32.TabIndex = 112
        Me.Label32.Text = "Total :"
        '
        'txtTotal
        '
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(103, 197)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(88, 20)
        Me.txtTotal.TabIndex = 10
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(10, 171)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 13)
        Me.Label24.TabIndex = 104
        Me.Label24.Text = "Previous Due :"
        '
        'txtPreviousDue
        '
        Me.txtPreviousDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPreviousDue.Location = New System.Drawing.Point(103, 171)
        Me.txtPreviousDue.Name = "txtPreviousDue"
        Me.txtPreviousDue.ReadOnly = True
        Me.txtPreviousDue.Size = New System.Drawing.Size(88, 20)
        Me.txtPreviousDue.TabIndex = 9
        Me.txtPreviousDue.Text = "0.00"
        Me.txtPreviousDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(10, 146)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 13)
        Me.Label18.TabIndex = 95
        Me.Label18.Text = "Other Charges :"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(10, 224)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 13)
        Me.Label17.TabIndex = 94
        Me.Label17.Text = "Round Off :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(10, 250)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 13)
        Me.Label16.TabIndex = 93
        Me.Label16.Text = "Grand Total :"
        '
        'txtRoundOff
        '
        Me.txtRoundOff.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRoundOff.Location = New System.Drawing.Point(103, 224)
        Me.txtRoundOff.Name = "txtRoundOff"
        Me.txtRoundOff.Size = New System.Drawing.Size(62, 20)
        Me.txtRoundOff.TabIndex = 11
        Me.txtRoundOff.Text = "0.00"
        Me.txtRoundOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotal.Location = New System.Drawing.Point(103, 250)
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(88, 20)
        Me.txtGrandTotal.TabIndex = 12
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOtherCharges
        '
        Me.txtOtherCharges.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOtherCharges.Location = New System.Drawing.Point(103, 144)
        Me.txtOtherCharges.Name = "txtOtherCharges"
        Me.txtOtherCharges.Size = New System.Drawing.Size(88, 20)
        Me.txtOtherCharges.TabIndex = 8
        Me.txtOtherCharges.Text = "0.00"
        Me.txtOtherCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreightCharges
        '
        Me.txtFreightCharges.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFreightCharges.Location = New System.Drawing.Point(103, 118)
        Me.txtFreightCharges.Name = "txtFreightCharges"
        Me.txtFreightCharges.Size = New System.Drawing.Size(88, 20)
        Me.txtFreightCharges.TabIndex = 7
        Me.txtFreightCharges.Text = "0.00"
        Me.txtFreightCharges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(10, 120)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(87, 13)
        Me.Label15.TabIndex = 86
        Me.Label15.Text = "Freight Charges :"
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubTotal.Location = New System.Drawing.Point(103, 9)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.ReadOnly = True
        Me.txtSubTotal.Size = New System.Drawing.Size(88, 20)
        Me.txtSubTotal.TabIndex = 0
        Me.txtSubTotal.Text = "0.00"
        Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(10, 9)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(59, 13)
        Me.Label31.TabIndex = 84
        Me.Label31.Text = "Sub Total :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 13)
        Me.Label12.TabIndex = 309
        Me.Label12.Text = "Remarks :"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FloralWhite
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeight = 30
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column9, Me.Column3, Me.Column10, Me.Column2, Me.Column4, Me.Column5, Me.Column6, Me.Column8, Me.Column12, Me.Column13, Me.Column14})
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.GridColor = System.Drawing.Color.White
        Me.DataGridView1.Location = New System.Drawing.Point(3, 476)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Moccasin
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Moccasin
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(787, 168)
        Me.DataGridView1.TabIndex = 5
        '
        'Column1
        '
        Me.Column1.HeaderText = "PID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column9
        '
        Me.Column9.HeaderText = "Product Code"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Product Name"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 150
        '
        'Column10
        '
        Me.Column10.HeaderText = "Barcode"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Warehouse/Store"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column4.HeaderText = "Qty."
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 70
        '
        'Column5
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column5.HeaderText = "Price Per Unit"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column6.HeaderText = "Total Amount"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column8
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column8.HeaderText = "Sales Rate"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "Manufacturing Date"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Column13
        '
        Me.Column13.HeaderText = "Expiry Date"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        '
        'Column14
        '
        Me.Column14.HeaderText = "Storage Type"
        Me.Column14.Name = "Column14"
        Me.Column14.ReadOnly = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnLoadProducts)
        Me.GroupBox2.Controls.Add(Me.btnClear)
        Me.GroupBox2.Controls.Add(Me.btnScanBarcode)
        Me.GroupBox2.Controls.Add(Me.cmbStorageType)
        Me.GroupBox2.Controls.Add(Label41)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.dtpExpiryDate)
        Me.GroupBox2.Controls.Add(Label13)
        Me.GroupBox2.Controls.Add(Me.txtExpiryDate)
        Me.GroupBox2.Controls.Add(Me.txtManufacturingDate)
        Me.GroupBox2.Controls.Add(Me.dtpManufacturingDate)
        Me.GroupBox2.Controls.Add(Label33)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.txtSalesRate)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.btnRemove)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.txtProductCode)
        Me.GroupBox2.Controls.Add(Me.txtBarcode)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.lblUnit)
        Me.GroupBox2.Controls.Add(Me.cmbWarehouse)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cmbProductName)
        Me.GroupBox2.Controls.Add(Me.txtTotalAmount)
        Me.GroupBox2.Controls.Add(Me.txtPricePerQty)
        Me.GroupBox2.Controls.Add(Me.txtQty)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 288)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(779, 182)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Product Info"
        '
        'btnLoadProducts
        '
        Me.btnLoadProducts.BackColor = System.Drawing.Color.Firebrick
        Me.btnLoadProducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnLoadProducts.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadProducts.ForeColor = System.Drawing.Color.White
        Me.btnLoadProducts.Image = CType(resources.GetObject("btnLoadProducts.Image"), System.Drawing.Image)
        Me.btnLoadProducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoadProducts.Location = New System.Drawing.Point(429, 141)
        Me.btnLoadProducts.Name = "btnLoadProducts"
        Me.btnLoadProducts.Size = New System.Drawing.Size(121, 34)
        Me.btnLoadProducts.TabIndex = 13
        Me.btnLoadProducts.Text = "Load Products"
        Me.btnLoadProducts.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLoadProducts.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Firebrick
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClear.Location = New System.Drawing.Point(683, 65)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 34)
        Me.btnClear.TabIndex = 15
        Me.btnClear.Text = "&Clear"
        Me.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnScanBarcode
        '
        Me.btnScanBarcode.BackColor = System.Drawing.Color.Firebrick
        Me.btnScanBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnScanBarcode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScanBarcode.ForeColor = System.Drawing.Color.White
        Me.btnScanBarcode.Image = CType(resources.GetObject("btnScanBarcode.Image"), System.Drawing.Image)
        Me.btnScanBarcode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnScanBarcode.Location = New System.Drawing.Point(556, 141)
        Me.btnScanBarcode.Name = "btnScanBarcode"
        Me.btnScanBarcode.Size = New System.Drawing.Size(121, 34)
        Me.btnScanBarcode.TabIndex = 14
        Me.btnScanBarcode.Text = "Scan Barcode"
        Me.btnScanBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnScanBarcode.UseVisualStyleBackColor = False
        '
        'cmbStorageType
        '
        Me.cmbStorageType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cmbStorageType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbStorageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStorageType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStorageType.FormattingEnabled = True
        Me.cmbStorageType.Items.AddRange(New Object() {"Store", "Warehouse"})
        Me.cmbStorageType.Location = New System.Drawing.Point(538, 34)
        Me.cmbStorageType.Name = "cmbStorageType"
        Me.cmbStorageType.Size = New System.Drawing.Size(128, 23)
        Me.cmbStorageType.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(336, 119)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(47, 47)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "C"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dtpExpiryDate
        '
        Me.dtpExpiryDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExpiryDate.Location = New System.Drawing.Point(234, 146)
        Me.dtpExpiryDate.Name = "dtpExpiryDate"
        Me.dtpExpiryDate.Size = New System.Drawing.Size(98, 20)
        Me.dtpExpiryDate.TabIndex = 11
        '
        'txtExpiryDate
        '
        Me.txtExpiryDate.Location = New System.Drawing.Point(123, 146)
        Me.txtExpiryDate.Name = "txtExpiryDate"
        Me.txtExpiryDate.ReadOnly = True
        Me.txtExpiryDate.Size = New System.Drawing.Size(105, 20)
        Me.txtExpiryDate.TabIndex = 19
        '
        'txtManufacturingDate
        '
        Me.txtManufacturingDate.Location = New System.Drawing.Point(123, 120)
        Me.txtManufacturingDate.Name = "txtManufacturingDate"
        Me.txtManufacturingDate.ReadOnly = True
        Me.txtManufacturingDate.Size = New System.Drawing.Size(105, 20)
        Me.txtManufacturingDate.TabIndex = 18
        '
        'dtpManufacturingDate
        '
        Me.dtpManufacturingDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpManufacturingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpManufacturingDate.Location = New System.Drawing.Point(234, 120)
        Me.dtpManufacturingDate.Name = "dtpManufacturingDate"
        Me.dtpManufacturingDate.Size = New System.Drawing.Size(98, 20)
        Me.dtpManufacturingDate.TabIndex = 10
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(452, 70)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(65, 13)
        Me.Label35.TabIndex = 335
        Me.Label35.Text = "Sales Rate :"
        '
        'txtSalesRate
        '
        Me.txtSalesRate.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtSalesRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesRate.Location = New System.Drawing.Point(455, 88)
        Me.txtSalesRate.Name = "txtSalesRate"
        Me.txtSalesRate.Size = New System.Drawing.Size(105, 21)
        Me.txtSalesRate.TabIndex = 9
        Me.txtSalesRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(121, 19)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(81, 13)
        Me.Label34.TabIndex = 332
        Me.Label34.Text = "Product Name :"
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.Firebrick
        Me.btnRemove.Enabled = False
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRemove.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.Color.White
        Me.btnRemove.Image = CType(resources.GetObject("btnRemove.Image"), System.Drawing.Image)
        Me.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemove.Location = New System.Drawing.Point(683, 141)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(90, 34)
        Me.btnRemove.TabIndex = 17
        Me.btnRemove.Text = "&Remove"
        Me.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.Firebrick
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAdd.Location = New System.Drawing.Point(683, 103)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(90, 34)
        Me.btnAdd.TabIndex = 16
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'txtProductCode
        '
        Me.txtProductCode.Location = New System.Drawing.Point(18, 37)
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.ReadOnly = True
        Me.txtProductCode.Size = New System.Drawing.Size(100, 20)
        Me.txtProductCode.TabIndex = 0
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.Color.White
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(407, 37)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(124, 21)
        Me.txtBarcode.TabIndex = 2
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(404, 19)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(53, 13)
        Me.Label27.TabIndex = 326
        Me.Label27.Text = "Barcode :"
        '
        'lblUnit
        '
        Me.lblUnit.AutoSize = True
        Me.lblUnit.Location = New System.Drawing.Point(200, 92)
        Me.lblUnit.Name = "lblUnit"
        Me.lblUnit.Size = New System.Drawing.Size(26, 13)
        Me.lblUnit.TabIndex = 322
        Me.lblUnit.Text = "Unit"
        Me.lblUnit.Visible = False
        '
        'cmbWarehouse
        '
        Me.cmbWarehouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbWarehouse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWarehouse.Enabled = False
        Me.cmbWarehouse.FormattingEnabled = True
        Me.cmbWarehouse.Location = New System.Drawing.Point(17, 88)
        Me.cmbWarehouse.Name = "cmbWarehouse"
        Me.cmbWarehouse.Size = New System.Drawing.Size(101, 21)
        Me.cmbWarehouse.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 13)
        Me.Label7.TabIndex = 317
        Me.Label7.Text = "Warehouse/Store :"
        '
        'cmbProductName
        '
        Me.cmbProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbProductName.FormattingEnabled = True
        Me.cmbProductName.Location = New System.Drawing.Point(124, 37)
        Me.cmbProductName.Name = "cmbProductName"
        Me.cmbProductName.Size = New System.Drawing.Size(277, 21)
        Me.cmbProductName.TabIndex = 1
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmount.Location = New System.Drawing.Point(344, 88)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(105, 21)
        Me.txtTotalAmount.TabIndex = 8
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPricePerQty
        '
        Me.txtPricePerQty.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtPricePerQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPricePerQty.Location = New System.Drawing.Point(233, 88)
        Me.txtPricePerQty.Name = "txtPricePerQty"
        Me.txtPricePerQty.Size = New System.Drawing.Size(105, 21)
        Me.txtPricePerQty.TabIndex = 7
        Me.txtPricePerQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtQty
        '
        Me.txtQty.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(125, 88)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(70, 21)
        Me.txtQty.TabIndex = 6
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(341, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Total Amount :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(230, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Price Per Unit :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(122, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Quantity :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Product Code :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.cmbTaxType)
        Me.GroupBox1.Controls.Add(Me.Label38)
        Me.GroupBox1.Controls.Add(Me.Label37)
        Me.GroupBox1.Controls.Add(Me.txtReferenceNo2)
        Me.GroupBox1.Controls.Add(Me.txtReferenceNo1)
        Me.GroupBox1.Controls.Add(Me.dtpDate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtInvoiceNo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(242, 161)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Invoice Info"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(12, 130)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(58, 13)
        Me.Label29.TabIndex = 12
        Me.Label29.Text = "Tax Type :"
        '
        'cmbTaxType
        '
        Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTaxType.FormattingEnabled = True
        Me.cmbTaxType.Items.AddRange(New Object() {"Inclusive", "Exclusive"})
        Me.cmbTaxType.Location = New System.Drawing.Point(109, 130)
        Me.cmbTaxType.Name = "cmbTaxType"
        Me.cmbTaxType.Size = New System.Drawing.Size(127, 21)
        Me.cmbTaxType.TabIndex = 5
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(11, 104)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(92, 13)
        Me.Label38.TabIndex = 10
        Me.Label38.Text = "Reference No. 2 :"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(12, 77)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(92, 13)
        Me.Label37.TabIndex = 9
        Me.Label37.Text = "Reference No. 1 :"
        '
        'txtReferenceNo2
        '
        Me.txtReferenceNo2.BackColor = System.Drawing.Color.White
        Me.txtReferenceNo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferenceNo2.Location = New System.Drawing.Point(109, 104)
        Me.txtReferenceNo2.Name = "txtReferenceNo2"
        Me.txtReferenceNo2.Size = New System.Drawing.Size(124, 21)
        Me.txtReferenceNo2.TabIndex = 3
        '
        'txtReferenceNo1
        '
        Me.txtReferenceNo1.BackColor = System.Drawing.Color.White
        Me.txtReferenceNo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReferenceNo1.Location = New System.Drawing.Point(109, 77)
        Me.txtReferenceNo1.Name = "txtReferenceNo1"
        Me.txtReferenceNo1.Size = New System.Drawing.Size(124, 21)
        Me.txtReferenceNo1.TabIndex = 2
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(109, 52)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(124, 20)
        Me.dtpDate.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Invoice No. :"
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.BackColor = System.Drawing.Color.White
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceNo.Location = New System.Drawing.Point(109, 26)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(124, 21)
        Me.txtInvoiceNo.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Invoice Date :"
        '
        'txtTotalPaid
        '
        Me.txtTotalPaid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPaid.Location = New System.Drawing.Point(712, 215)
        Me.txtTotalPaid.Name = "txtTotalPaid"
        Me.txtTotalPaid.Size = New System.Drawing.Size(88, 20)
        Me.txtTotalPaid.TabIndex = 13
        Me.txtTotalPaid.Text = "0.00"
        Me.txtTotalPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTotalPaid.Visible = False
        '
        'txtBalance
        '
        Me.txtBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBalance.Location = New System.Drawing.Point(712, 241)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.ReadOnly = True
        Me.txtBalance.Size = New System.Drawing.Size(88, 20)
        Me.txtBalance.TabIndex = 14
        Me.txtBalance.Text = "0.00"
        Me.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBalance.Visible = False
        '
        'cmbPurchaseType
        '
        Me.cmbPurchaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPurchaseType.FormattingEnabled = True
        Me.cmbPurchaseType.Items.AddRange(New Object() {"Credit", "Cash"})
        Me.cmbPurchaseType.Location = New System.Drawing.Point(190, 3)
        Me.cmbPurchaseType.Name = "cmbPurchaseType"
        Me.cmbPurchaseType.Size = New System.Drawing.Size(124, 21)
        Me.cmbPurchaseType.TabIndex = 4
        Me.cmbPurchaseType.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Firebrick
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.txtProductID)
        Me.Panel2.Controls.Add(Me.lblUserType)
        Me.Panel2.Controls.Add(Me.lblSet)
        Me.Panel2.Controls.Add(Me.lblUser)
        Me.Panel2.Controls.Add(Me.txtSup_ID)
        Me.Panel2.Controls.Add(Me.txtST_ID)
        Me.Panel2.Controls.Add(Me.cmbPurchaseType)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(2, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(970, 50)
        Me.Panel2.TabIndex = 0
        '
        'txtProductID
        '
        Me.txtProductID.Location = New System.Drawing.Point(101, 6)
        Me.txtProductID.Name = "txtProductID"
        Me.txtProductID.Size = New System.Drawing.Size(35, 20)
        Me.txtProductID.TabIndex = 37
        Me.txtProductID.Visible = False
        '
        'lblUserType
        '
        Me.lblUserType.AutoSize = True
        Me.lblUserType.Location = New System.Drawing.Point(142, 16)
        Me.lblUserType.Name = "lblUserType"
        Me.lblUserType.Size = New System.Drawing.Size(56, 13)
        Me.lblUserType.TabIndex = 312
        Me.lblUserType.Text = "User Type"
        Me.lblUserType.Visible = False
        '
        'lblSet
        '
        Me.lblSet.AutoSize = True
        Me.lblSet.Location = New System.Drawing.Point(187, 30)
        Me.lblSet.Name = "lblSet"
        Me.lblSet.Size = New System.Drawing.Size(23, 13)
        Me.lblSet.TabIndex = 311
        Me.lblSet.Text = "Set"
        Me.lblSet.Visible = False
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(142, 29)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(29, 13)
        Me.lblUser.TabIndex = 6
        Me.lblUser.Text = "User"
        Me.lblUser.Visible = False
        '
        'txtSup_ID
        '
        Me.txtSup_ID.Location = New System.Drawing.Point(60, 6)
        Me.txtSup_ID.Name = "txtSup_ID"
        Me.txtSup_ID.Size = New System.Drawing.Size(35, 20)
        Me.txtSup_ID.TabIndex = 2
        Me.txtSup_ID.Visible = False
        '
        'txtST_ID
        '
        Me.txtST_ID.Location = New System.Drawing.Point(14, 6)
        Me.txtST_ID.Name = "txtST_ID"
        Me.txtST_ID.Size = New System.Drawing.Size(35, 20)
        Me.txtST_ID.TabIndex = 1
        Me.txtST_ID.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(958, 50)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Purchase Entry"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
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
        Me.btnCancel.Location = New System.Drawing.Point(966, 1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(52, 50)
        Me.btnCancel.TabIndex = 399
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frmPurchaseEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Firebrick
        Me.ClientSize = New System.Drawing.Size(1018, 708)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPurchaseEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.gbPartyInfo.ResumeLayout(False)
        Me.gbPartyInfo.PerformLayout()
        Me.pnlCalc.ResumeLayout(False)
        Me.pnlCalc.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents txtPricePerQty As System.Windows.Forms.TextBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRemarks As System.Windows.Forms.RichTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSup_ID As System.Windows.Forms.TextBox
    Friend WithEvents txtST_ID As System.Windows.Forms.TextBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblSet As System.Windows.Forms.Label
    Friend WithEvents lblUserType As System.Windows.Forms.Label
    Friend WithEvents gbPartyInfo As System.Windows.Forms.GroupBox
    Friend WithEvents btnSelection As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSupplierID As System.Windows.Forms.TextBox
    Friend WithEvents lblBalance As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtContactNo As System.Windows.Forms.TextBox
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents txtAddressLine2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddressLine1 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents pnlCalc As System.Windows.Forms.Panel
    Friend WithEvents txtDisc As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents txtDiscPer As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtPreviousDue As System.Windows.Forms.TextBox
    Friend WithEvents txtBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtRoundOff As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalPaid As System.Windows.Forms.TextBox
    Friend WithEvents txtGrandTotal As System.Windows.Forms.TextBox
    Friend WithEvents txtOtherCharges As System.Windows.Forms.TextBox
    Friend WithEvents txtFreightCharges As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents cmbPurchaseType As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnGetData As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents cmbProductName As System.Windows.Forms.ComboBox
    Friend WithEvents txtProductID As System.Windows.Forms.TextBox
    Public WithEvents btnRemove As System.Windows.Forms.Button
    Public WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents cmbWarehouse As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblUnit As System.Windows.Forms.Label
    Friend WithEvents txtVATAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtVAT As System.Windows.Forms.TextBox
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents txtSalesRate As System.Windows.Forms.TextBox
    Friend WithEvents dtpExpiryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtExpiryDate As System.Windows.Forms.TextBox
    Friend WithEvents txtManufacturingDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpManufacturingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpSupplierInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents txtSupplierInvoiceNo As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtReferenceNo2 As System.Windows.Forms.TextBox
    Friend WithEvents txtReferenceNo1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cmbTaxType As System.Windows.Forms.ComboBox
    Public WithEvents cmbStorageType As System.Windows.Forms.ComboBox
    Public WithEvents btnScanBarcode As System.Windows.Forms.Button
    Public WithEvents btnClear As System.Windows.Forms.Button
    Public WithEvents btnLoadProducts As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column14 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
