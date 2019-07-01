<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.btnTaxType = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnEmailSetting = New System.Windows.Forms.Button()
        Me.btnSMSSetting = New System.Windows.Forms.Button()
        Me.btnTaxSetting = New System.Windows.Forms.Button()
        Me.btnPrinterSetting = New System.Windows.Forms.Button()
        Me.btnTaxMaster = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnTaxType
        '
        Me.btnTaxType.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTaxType.AutoSize = True
        Me.btnTaxType.BackColor = System.Drawing.Color.Firebrick
        Me.btnTaxType.FlatAppearance.BorderSize = 0
        Me.btnTaxType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTaxType.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTaxType.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnTaxType.Image = CType(resources.GetObject("btnTaxType.Image"), System.Drawing.Image)
        Me.btnTaxType.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTaxType.Location = New System.Drawing.Point(12, 172)
        Me.btnTaxType.Name = "btnTaxType"
        Me.btnTaxType.Size = New System.Drawing.Size(217, 65)
        Me.btnTaxType.TabIndex = 323
        Me.btnTaxType.Text = "Tax Type"
        Me.btnTaxType.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTaxType.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Transparent
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(428, -5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(37, 36)
        Me.btnClose.TabIndex = 322
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnEmailSetting
        '
        Me.btnEmailSetting.AutoSize = True
        Me.btnEmailSetting.BackColor = System.Drawing.Color.Firebrick
        Me.btnEmailSetting.FlatAppearance.BorderSize = 0
        Me.btnEmailSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEmailSetting.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmailSetting.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnEmailSetting.Image = CType(resources.GetObject("btnEmailSetting.Image"), System.Drawing.Image)
        Me.btnEmailSetting.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEmailSetting.Location = New System.Drawing.Point(235, 103)
        Me.btnEmailSetting.Name = "btnEmailSetting"
        Me.btnEmailSetting.Size = New System.Drawing.Size(217, 65)
        Me.btnEmailSetting.TabIndex = 52
        Me.btnEmailSetting.Text = "Email Setting"
        Me.btnEmailSetting.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEmailSetting.UseVisualStyleBackColor = False
        '
        'btnSMSSetting
        '
        Me.btnSMSSetting.AutoSize = True
        Me.btnSMSSetting.BackColor = System.Drawing.Color.Firebrick
        Me.btnSMSSetting.FlatAppearance.BorderSize = 0
        Me.btnSMSSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSMSSetting.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSMSSetting.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnSMSSetting.Image = CType(resources.GetObject("btnSMSSetting.Image"), System.Drawing.Image)
        Me.btnSMSSetting.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSMSSetting.Location = New System.Drawing.Point(12, 103)
        Me.btnSMSSetting.Name = "btnSMSSetting"
        Me.btnSMSSetting.Size = New System.Drawing.Size(217, 65)
        Me.btnSMSSetting.TabIndex = 51
        Me.btnSMSSetting.Text = "SMS Setting"
        Me.btnSMSSetting.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSMSSetting.UseVisualStyleBackColor = False
        '
        'btnTaxSetting
        '
        Me.btnTaxSetting.AutoSize = True
        Me.btnTaxSetting.BackColor = System.Drawing.Color.Firebrick
        Me.btnTaxSetting.FlatAppearance.BorderSize = 0
        Me.btnTaxSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTaxSetting.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTaxSetting.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnTaxSetting.Image = CType(resources.GetObject("btnTaxSetting.Image"), System.Drawing.Image)
        Me.btnTaxSetting.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTaxSetting.Location = New System.Drawing.Point(235, 32)
        Me.btnTaxSetting.Name = "btnTaxSetting"
        Me.btnTaxSetting.Size = New System.Drawing.Size(217, 65)
        Me.btnTaxSetting.TabIndex = 29
        Me.btnTaxSetting.Text = "Tax Setting"
        Me.btnTaxSetting.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTaxSetting.UseVisualStyleBackColor = False
        '
        'btnPrinterSetting
        '
        Me.btnPrinterSetting.AutoSize = True
        Me.btnPrinterSetting.BackColor = System.Drawing.Color.Firebrick
        Me.btnPrinterSetting.FlatAppearance.BorderSize = 0
        Me.btnPrinterSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrinterSetting.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrinterSetting.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPrinterSetting.Image = CType(resources.GetObject("btnPrinterSetting.Image"), System.Drawing.Image)
        Me.btnPrinterSetting.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrinterSetting.Location = New System.Drawing.Point(12, 32)
        Me.btnPrinterSetting.Name = "btnPrinterSetting"
        Me.btnPrinterSetting.Size = New System.Drawing.Size(217, 65)
        Me.btnPrinterSetting.TabIndex = 28
        Me.btnPrinterSetting.Text = "Terminal Setting"
        Me.btnPrinterSetting.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrinterSetting.UseVisualStyleBackColor = False
        '
        'btnTaxMaster
        '
        Me.btnTaxMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTaxMaster.AutoSize = True
        Me.btnTaxMaster.BackColor = System.Drawing.Color.Firebrick
        Me.btnTaxMaster.FlatAppearance.BorderSize = 0
        Me.btnTaxMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTaxMaster.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTaxMaster.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnTaxMaster.Image = CType(resources.GetObject("btnTaxMaster.Image"), System.Drawing.Image)
        Me.btnTaxMaster.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTaxMaster.Location = New System.Drawing.Point(235, 172)
        Me.btnTaxMaster.Name = "btnTaxMaster"
        Me.btnTaxMaster.Size = New System.Drawing.Size(217, 65)
        Me.btnTaxMaster.TabIndex = 324
        Me.btnTaxMaster.Text = "Tax Master"
        Me.btnTaxMaster.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTaxMaster.UseVisualStyleBackColor = False
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(462, 249)
        Me.Controls.Add(Me.btnTaxMaster)
        Me.Controls.Add(Me.btnTaxType)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnEmailSetting)
        Me.Controls.Add(Me.btnSMSSetting)
        Me.Controls.Add(Me.btnTaxSetting)
        Me.Controls.Add(Me.btnPrinterSetting)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSettings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrinterSetting As System.Windows.Forms.Button
    Friend WithEvents btnTaxSetting As System.Windows.Forms.Button
    Friend WithEvents btnSMSSetting As System.Windows.Forms.Button
    Friend WithEvents btnEmailSetting As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnTaxType As System.Windows.Forms.Button
    Friend WithEvents btnTaxMaster As System.Windows.Forms.Button
End Class
