<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGetCash
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGetCash))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCash = New System.Windows.Forms.TextBox()
        Me.btnOkay = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnTAx = New System.Windows.Forms.Button()
        Me.btnTA0 = New System.Windows.Forms.Button()
        Me.btnTAComma = New System.Windows.Forms.Button()
        Me.btnTA9 = New System.Windows.Forms.Button()
        Me.btnTA8 = New System.Windows.Forms.Button()
        Me.btnTA4 = New System.Windows.Forms.Button()
        Me.btnTA6 = New System.Windows.Forms.Button()
        Me.btnTA5 = New System.Windows.Forms.Button()
        Me.btnTA7 = New System.Windows.Forms.Button()
        Me.btnTA3 = New System.Windows.Forms.Button()
        Me.btnTA1 = New System.Windows.Forms.Button()
        Me.btnTA2 = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Firebrick
        Me.Label1.Location = New System.Drawing.Point(-1, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 30)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter the Cash :"
        '
        'txtCash
        '
        Me.txtCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCash.Location = New System.Drawing.Point(4, 37)
        Me.txtCash.Name = "txtCash"
        Me.txtCash.Size = New System.Drawing.Size(217, 35)
        Me.txtCash.TabIndex = 0
        Me.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnOkay
        '
        Me.btnOkay.BackColor = System.Drawing.Color.Firebrick
        Me.btnOkay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOkay.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOkay.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnOkay.Location = New System.Drawing.Point(227, 37)
        Me.btnOkay.Name = "btnOkay"
        Me.btnOkay.Size = New System.Drawing.Size(106, 35)
        Me.btnOkay.TabIndex = 1
        Me.btnOkay.Text = "&Okay"
        Me.btnOkay.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Button2, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Button3, 3, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Button4, 3, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Button1, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTAx, 2, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA0, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTAComma, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA9, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA8, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA4, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA6, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA5, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA7, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA3, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnTA2, 1, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(4, 77)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 4
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(391, 242)
        Me.TableLayoutPanel3.TabIndex = 384
        '
        'Button2
        '
        Me.Button2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.Firebrick
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(294, 63)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(94, 54)
        Me.Button2.TabIndex = 387
        Me.Button2.Text = "50"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Firebrick
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(294, 123)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(94, 54)
        Me.Button3.TabIndex = 388
        Me.Button3.Text = "100"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.Color.Firebrick
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(294, 183)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(94, 56)
        Me.Button4.TabIndex = 389
        Me.Button4.Text = "500"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.Firebrick
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(294, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(94, 54)
        Me.Button1.TabIndex = 386
        Me.Button1.Text = "10"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnTAx
        '
        Me.btnTAx.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTAx.BackColor = System.Drawing.Color.Firebrick
        Me.btnTAx.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTAx.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTAx.ForeColor = System.Drawing.Color.White
        Me.btnTAx.Location = New System.Drawing.Point(197, 183)
        Me.btnTAx.Name = "btnTAx"
        Me.btnTAx.Size = New System.Drawing.Size(91, 56)
        Me.btnTAx.TabIndex = 18
        Me.btnTAx.Text = "x"
        Me.btnTAx.UseVisualStyleBackColor = False
        '
        'btnTA0
        '
        Me.btnTA0.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA0.BackColor = System.Drawing.Color.Firebrick
        Me.btnTA0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA0.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA0.ForeColor = System.Drawing.Color.White
        Me.btnTA0.Location = New System.Drawing.Point(100, 183)
        Me.btnTA0.Name = "btnTA0"
        Me.btnTA0.Size = New System.Drawing.Size(91, 56)
        Me.btnTA0.TabIndex = 17
        Me.btnTA0.Text = "0"
        Me.btnTA0.UseVisualStyleBackColor = False
        '
        'btnTAComma
        '
        Me.btnTAComma.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTAComma.BackColor = System.Drawing.Color.Firebrick
        Me.btnTAComma.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTAComma.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTAComma.ForeColor = System.Drawing.Color.White
        Me.btnTAComma.Location = New System.Drawing.Point(3, 183)
        Me.btnTAComma.Name = "btnTAComma"
        Me.btnTAComma.Size = New System.Drawing.Size(91, 56)
        Me.btnTAComma.TabIndex = 16
        Me.btnTAComma.Text = "."
        Me.btnTAComma.UseVisualStyleBackColor = False
        '
        'btnTA9
        '
        Me.btnTA9.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA9.BackColor = System.Drawing.Color.Firebrick
        Me.btnTA9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA9.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA9.ForeColor = System.Drawing.Color.White
        Me.btnTA9.Location = New System.Drawing.Point(197, 123)
        Me.btnTA9.Name = "btnTA9"
        Me.btnTA9.Size = New System.Drawing.Size(91, 54)
        Me.btnTA9.TabIndex = 15
        Me.btnTA9.Text = "9"
        Me.btnTA9.UseVisualStyleBackColor = False
        '
        'btnTA8
        '
        Me.btnTA8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA8.BackColor = System.Drawing.Color.Firebrick
        Me.btnTA8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA8.ForeColor = System.Drawing.Color.White
        Me.btnTA8.Location = New System.Drawing.Point(100, 123)
        Me.btnTA8.Name = "btnTA8"
        Me.btnTA8.Size = New System.Drawing.Size(91, 54)
        Me.btnTA8.TabIndex = 14
        Me.btnTA8.Text = "8"
        Me.btnTA8.UseVisualStyleBackColor = False
        '
        'btnTA4
        '
        Me.btnTA4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA4.BackColor = System.Drawing.Color.Firebrick
        Me.btnTA4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA4.ForeColor = System.Drawing.Color.White
        Me.btnTA4.Location = New System.Drawing.Point(3, 63)
        Me.btnTA4.Name = "btnTA4"
        Me.btnTA4.Size = New System.Drawing.Size(91, 54)
        Me.btnTA4.TabIndex = 30
        Me.btnTA4.Text = "4"
        Me.btnTA4.UseVisualStyleBackColor = False
        '
        'btnTA6
        '
        Me.btnTA6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA6.BackColor = System.Drawing.Color.Firebrick
        Me.btnTA6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA6.ForeColor = System.Drawing.Color.White
        Me.btnTA6.Location = New System.Drawing.Point(197, 63)
        Me.btnTA6.Name = "btnTA6"
        Me.btnTA6.Size = New System.Drawing.Size(91, 54)
        Me.btnTA6.TabIndex = 12
        Me.btnTA6.Text = "6"
        Me.btnTA6.UseVisualStyleBackColor = False
        '
        'btnTA5
        '
        Me.btnTA5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA5.BackColor = System.Drawing.Color.Firebrick
        Me.btnTA5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA5.ForeColor = System.Drawing.Color.White
        Me.btnTA5.Location = New System.Drawing.Point(100, 63)
        Me.btnTA5.Name = "btnTA5"
        Me.btnTA5.Size = New System.Drawing.Size(91, 54)
        Me.btnTA5.TabIndex = 11
        Me.btnTA5.Text = "5"
        Me.btnTA5.UseVisualStyleBackColor = False
        '
        'btnTA7
        '
        Me.btnTA7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA7.BackColor = System.Drawing.Color.Firebrick
        Me.btnTA7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA7.ForeColor = System.Drawing.Color.White
        Me.btnTA7.Location = New System.Drawing.Point(3, 123)
        Me.btnTA7.Name = "btnTA7"
        Me.btnTA7.Size = New System.Drawing.Size(91, 54)
        Me.btnTA7.TabIndex = 13
        Me.btnTA7.Text = "7"
        Me.btnTA7.UseVisualStyleBackColor = False
        '
        'btnTA3
        '
        Me.btnTA3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA3.BackColor = System.Drawing.Color.Firebrick
        Me.btnTA3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA3.ForeColor = System.Drawing.Color.White
        Me.btnTA3.Location = New System.Drawing.Point(197, 3)
        Me.btnTA3.Name = "btnTA3"
        Me.btnTA3.Size = New System.Drawing.Size(91, 54)
        Me.btnTA3.TabIndex = 9
        Me.btnTA3.Text = "3"
        Me.btnTA3.UseVisualStyleBackColor = False
        '
        'btnTA1
        '
        Me.btnTA1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA1.BackColor = System.Drawing.Color.Firebrick
        Me.btnTA1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA1.ForeColor = System.Drawing.Color.White
        Me.btnTA1.Location = New System.Drawing.Point(3, 3)
        Me.btnTA1.Name = "btnTA1"
        Me.btnTA1.Size = New System.Drawing.Size(91, 54)
        Me.btnTA1.TabIndex = 7
        Me.btnTA1.Text = "1"
        Me.btnTA1.UseVisualStyleBackColor = False
        '
        'btnTA2
        '
        Me.btnTA2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTA2.BackColor = System.Drawing.Color.Firebrick
        Me.btnTA2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTA2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTA2.ForeColor = System.Drawing.Color.White
        Me.btnTA2.Location = New System.Drawing.Point(100, 3)
        Me.btnTA2.Name = "btnTA2"
        Me.btnTA2.Size = New System.Drawing.Size(91, 54)
        Me.btnTA2.TabIndex = 8
        Me.btnTA2.Text = "2"
        Me.btnTA2.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Firebrick
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(337, 37)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(55, 35)
        Me.btnClear.TabIndex = 385
        Me.btnClear.Text = "C"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(1, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(346, 46)
        Me.Panel2.TabIndex = 387
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(126, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 32)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Get Cash"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.txtCash)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel1.Controls.Add(Me.btnClear)
        Me.Panel1.Controls.Add(Me.btnOkay)
        Me.Panel1.Location = New System.Drawing.Point(6, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(399, 325)
        Me.Panel1.TabIndex = 388
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
        Me.btnCancel.Location = New System.Drawing.Point(358, -1)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(52, 49)
        Me.btnCancel.TabIndex = 389
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frmGetCash
        '
        Me.AcceptButton = Me.btnOkay
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Firebrick
        Me.ClientSize = New System.Drawing.Size(411, 379)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGetCash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Get Cash"
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCash As System.Windows.Forms.TextBox
    Friend WithEvents btnOkay As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnTAx As System.Windows.Forms.Button
    Friend WithEvents btnTA0 As System.Windows.Forms.Button
    Friend WithEvents btnTAComma As System.Windows.Forms.Button
    Friend WithEvents btnTA9 As System.Windows.Forms.Button
    Friend WithEvents btnTA8 As System.Windows.Forms.Button
    Friend WithEvents btnTA4 As System.Windows.Forms.Button
    Friend WithEvents btnTA6 As System.Windows.Forms.Button
    Friend WithEvents btnTA5 As System.Windows.Forms.Button
    Friend WithEvents btnTA7 As System.Windows.Forms.Button
    Friend WithEvents btnTA3 As System.Windows.Forms.Button
    Friend WithEvents btnTA1 As System.Windows.Forms.Button
    Friend WithEvents btnTA2 As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
