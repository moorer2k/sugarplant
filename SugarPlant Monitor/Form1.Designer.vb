<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.FormSkin1 = New SugarPlant_Monitor.FlatUI.FormSkin()
        Me.FlatStatusBar1 = New SugarPlant_Monitor.FlatUI.FlatStatusBar()
        Me.FlatTabControl1 = New SugarPlant_Monitor.FlatUI.FlatTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.LabelCurrBalance = New SugarPlant_Monitor.FlatUI.FlatLabel()
        Me.FlatLabel7 = New SugarPlant_Monitor.FlatUI.FlatLabel()
        Me.ButtonCheck = New SugarPlant_Monitor.FlatUI.FlatButton()
        Me.LabelPaid = New SugarPlant_Monitor.FlatUI.FlatLabel()
        Me.LabelWorkers = New SugarPlant_Monitor.FlatUI.FlatLabel()
        Me.LabelHashrate = New SugarPlant_Monitor.FlatUI.FlatLabel()
        Me.FlatLabel5 = New SugarPlant_Monitor.FlatUI.FlatLabel()
        Me.FlatLabel4 = New SugarPlant_Monitor.FlatUI.FlatLabel()
        Me.FlatLabel1 = New SugarPlant_Monitor.FlatUI.FlatLabel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TextPass = New SugarPlant_Monitor.FlatUI.FlatTextBox()
        Me.FlatLabel3 = New SugarPlant_Monitor.FlatUI.FlatLabel()
        Me.TextWallet = New SugarPlant_Monitor.FlatUI.FlatTextBox()
        Me.FlatLabel2 = New SugarPlant_Monitor.FlatUI.FlatLabel()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.FlatLabel9 = New SugarPlant_Monitor.FlatUI.FlatLabel()
        Me.FlatClose1 = New SugarPlant_Monitor.FlatUI.FlatClose()
        Me.FlatMini1 = New SugarPlant_Monitor.FlatUI.FlatMini()
        Me.FormSkin1.SuspendLayout()
        Me.FlatTabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormSkin1
        '
        Me.FormSkin1.BackColor = System.Drawing.Color.White
        Me.FormSkin1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.FormSkin1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.FormSkin1.Controls.Add(Me.FlatStatusBar1)
        Me.FormSkin1.Controls.Add(Me.FlatTabControl1)
        Me.FormSkin1.Controls.Add(Me.FlatClose1)
        Me.FormSkin1.Controls.Add(Me.FlatMini1)
        Me.FormSkin1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FormSkin1.FlatColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.FormSkin1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.FormSkin1.HeaderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.FormSkin1.HeaderMaximize = False
        Me.FormSkin1.Location = New System.Drawing.Point(0, 0)
        Me.FormSkin1.Name = "FormSkin1"
        Me.FormSkin1.Size = New System.Drawing.Size(386, 256)
        Me.FormSkin1.TabIndex = 0
        Me.FormSkin1.Text = "SugarPlant Monitor"
        '
        'FlatStatusBar1
        '
        Me.FlatStatusBar1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.FlatStatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FlatStatusBar1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatStatusBar1.ForeColor = System.Drawing.Color.White
        Me.FlatStatusBar1.Location = New System.Drawing.Point(0, 233)
        Me.FlatStatusBar1.Name = "FlatStatusBar1"
        Me.FlatStatusBar1.RectColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.FlatStatusBar1.ShowTimeDate = False
        Me.FlatStatusBar1.Size = New System.Drawing.Size(386, 23)
        Me.FlatStatusBar1.TabIndex = 3
        Me.FlatStatusBar1.Text = "Status: Idle..."
        Me.FlatStatusBar1.TextColor = System.Drawing.Color.White
        '
        'FlatTabControl1
        '
        Me.FlatTabControl1.ActiveColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.FlatTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatTabControl1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.FlatTabControl1.Controls.Add(Me.TabPage1)
        Me.FlatTabControl1.Controls.Add(Me.TabPage2)
        Me.FlatTabControl1.Controls.Add(Me.TabPage3)
        Me.FlatTabControl1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.FlatTabControl1.ItemSize = New System.Drawing.Size(120, 40)
        Me.FlatTabControl1.Location = New System.Drawing.Point(3, 56)
        Me.FlatTabControl1.Name = "FlatTabControl1"
        Me.FlatTabControl1.SelectedIndex = 0
        Me.FlatTabControl1.Size = New System.Drawing.Size(380, 171)
        Me.FlatTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.FlatTabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.TabPage1.Controls.Add(Me.LabelCurrBalance)
        Me.TabPage1.Controls.Add(Me.FlatLabel7)
        Me.TabPage1.Controls.Add(Me.ButtonCheck)
        Me.TabPage1.Controls.Add(Me.LabelPaid)
        Me.TabPage1.Controls.Add(Me.LabelWorkers)
        Me.TabPage1.Controls.Add(Me.LabelHashrate)
        Me.TabPage1.Controls.Add(Me.FlatLabel5)
        Me.TabPage1.Controls.Add(Me.FlatLabel4)
        Me.TabPage1.Controls.Add(Me.FlatLabel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 44)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(372, 123)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Statistics"
        '
        'LabelCurrBalance
        '
        Me.LabelCurrBalance.AutoSize = True
        Me.LabelCurrBalance.BackColor = System.Drawing.Color.Transparent
        Me.LabelCurrBalance.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.LabelCurrBalance.ForeColor = System.Drawing.Color.White
        Me.LabelCurrBalance.Location = New System.Drawing.Point(146, 70)
        Me.LabelCurrBalance.Name = "LabelCurrBalance"
        Me.LabelCurrBalance.Size = New System.Drawing.Size(13, 13)
        Me.LabelCurrBalance.TabIndex = 11
        Me.LabelCurrBalance.Text = "0"
        '
        'FlatLabel7
        '
        Me.FlatLabel7.AutoSize = True
        Me.FlatLabel7.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel7.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel7.ForeColor = System.Drawing.Color.White
        Me.FlatLabel7.Location = New System.Drawing.Point(6, 70)
        Me.FlatLabel7.Name = "FlatLabel7"
        Me.FlatLabel7.Size = New System.Drawing.Size(91, 13)
        Me.FlatLabel7.TabIndex = 10
        Me.FlatLabel7.Text = "Current Balance:"
        '
        'ButtonCheck
        '
        Me.ButtonCheck.BackColor = System.Drawing.Color.Transparent
        Me.ButtonCheck.BaseColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.ButtonCheck.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCheck.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.ButtonCheck.Location = New System.Drawing.Point(286, 80)
        Me.ButtonCheck.Name = "ButtonCheck"
        Me.ButtonCheck.Rounded = False
        Me.ButtonCheck.Size = New System.Drawing.Size(81, 37)
        Me.ButtonCheck.TabIndex = 9
        Me.ButtonCheck.Text = "Check"
        Me.ButtonCheck.TextColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        '
        'LabelPaid
        '
        Me.LabelPaid.AutoSize = True
        Me.LabelPaid.BackColor = System.Drawing.Color.Transparent
        Me.LabelPaid.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.LabelPaid.ForeColor = System.Drawing.Color.White
        Me.LabelPaid.Location = New System.Drawing.Point(146, 96)
        Me.LabelPaid.Name = "LabelPaid"
        Me.LabelPaid.Size = New System.Drawing.Size(13, 13)
        Me.LabelPaid.TabIndex = 8
        Me.LabelPaid.Text = "0"
        '
        'LabelWorkers
        '
        Me.LabelWorkers.AutoSize = True
        Me.LabelWorkers.BackColor = System.Drawing.Color.Transparent
        Me.LabelWorkers.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.LabelWorkers.ForeColor = System.Drawing.Color.White
        Me.LabelWorkers.Location = New System.Drawing.Point(146, 18)
        Me.LabelWorkers.Name = "LabelWorkers"
        Me.LabelWorkers.Size = New System.Drawing.Size(13, 13)
        Me.LabelWorkers.TabIndex = 7
        Me.LabelWorkers.Text = "0"
        '
        'LabelHashrate
        '
        Me.LabelHashrate.AutoSize = True
        Me.LabelHashrate.BackColor = System.Drawing.Color.Transparent
        Me.LabelHashrate.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.LabelHashrate.ForeColor = System.Drawing.Color.White
        Me.LabelHashrate.Location = New System.Drawing.Point(146, 44)
        Me.LabelHashrate.Name = "LabelHashrate"
        Me.LabelHashrate.Size = New System.Drawing.Size(13, 13)
        Me.LabelHashrate.TabIndex = 6
        Me.LabelHashrate.Text = "0"
        '
        'FlatLabel5
        '
        Me.FlatLabel5.AutoSize = True
        Me.FlatLabel5.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel5.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel5.ForeColor = System.Drawing.Color.White
        Me.FlatLabel5.Location = New System.Drawing.Point(6, 96)
        Me.FlatLabel5.Name = "FlatLabel5"
        Me.FlatLabel5.Size = New System.Drawing.Size(60, 13)
        Me.FlatLabel5.TabIndex = 5
        Me.FlatLabel5.Text = "Total Paid:"
        '
        'FlatLabel4
        '
        Me.FlatLabel4.AutoSize = True
        Me.FlatLabel4.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel4.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel4.ForeColor = System.Drawing.Color.White
        Me.FlatLabel4.Location = New System.Drawing.Point(6, 44)
        Me.FlatLabel4.Name = "FlatLabel4"
        Me.FlatLabel4.Size = New System.Drawing.Size(98, 13)
        Me.FlatLabel4.TabIndex = 4
        Me.FlatLabel4.Text = "Current Hashrate:"
        '
        'FlatLabel1
        '
        Me.FlatLabel1.AutoSize = True
        Me.FlatLabel1.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel1.ForeColor = System.Drawing.Color.White
        Me.FlatLabel1.Location = New System.Drawing.Point(6, 18)
        Me.FlatLabel1.Name = "FlatLabel1"
        Me.FlatLabel1.Size = New System.Drawing.Size(81, 13)
        Me.FlatLabel1.TabIndex = 3
        Me.FlatLabel1.Text = "Total Workers:"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.TextPass)
        Me.TabPage2.Controls.Add(Me.FlatLabel3)
        Me.TabPage2.Controls.Add(Me.TextWallet)
        Me.TabPage2.Controls.Add(Me.FlatLabel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 44)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(372, 123)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Settings"
        '
        'TextPass
        '
        Me.TextPass.BackColor = System.Drawing.Color.Transparent
        Me.TextPass.Location = New System.Drawing.Point(9, 80)
        Me.TextPass.MaxLength = 32767
        Me.TextPass.Multiline = False
        Me.TextPass.Name = "TextPass"
        Me.TextPass.ReadOnly = False
        Me.TextPass.Size = New System.Drawing.Size(357, 29)
        Me.TextPass.TabIndex = 5
        Me.TextPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TextPass.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextPass.UseSystemPasswordChar = True
        '
        'FlatLabel3
        '
        Me.FlatLabel3.AutoSize = True
        Me.FlatLabel3.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel3.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel3.ForeColor = System.Drawing.Color.White
        Me.FlatLabel3.Location = New System.Drawing.Point(6, 64)
        Me.FlatLabel3.Name = "FlatLabel3"
        Me.FlatLabel3.Size = New System.Drawing.Size(112, 13)
        Me.FlatLabel3.TabIndex = 4
        Me.FlatLabel3.Text = "Password (optional):"
        '
        'TextWallet
        '
        Me.TextWallet.BackColor = System.Drawing.Color.Transparent
        Me.TextWallet.Location = New System.Drawing.Point(9, 28)
        Me.TextWallet.MaxLength = 32767
        Me.TextWallet.Multiline = False
        Me.TextWallet.Name = "TextWallet"
        Me.TextWallet.ReadOnly = False
        Me.TextWallet.Size = New System.Drawing.Size(357, 29)
        Me.TextWallet.TabIndex = 3
        Me.TextWallet.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TextWallet.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TextWallet.UseSystemPasswordChar = False
        '
        'FlatLabel2
        '
        Me.FlatLabel2.AutoSize = True
        Me.FlatLabel2.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel2.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel2.ForeColor = System.Drawing.Color.White
        Me.FlatLabel2.Location = New System.Drawing.Point(6, 12)
        Me.FlatLabel2.Name = "FlatLabel2"
        Me.FlatLabel2.Size = New System.Drawing.Size(87, 13)
        Me.FlatLabel2.TabIndex = 2
        Me.FlatLabel2.Text = "Wallet Address:"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.FlatLabel9)
        Me.TabPage3.Location = New System.Drawing.Point(4, 44)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(372, 123)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "About"
        '
        'FlatLabel9
        '
        Me.FlatLabel9.AutoSize = True
        Me.FlatLabel9.BackColor = System.Drawing.Color.Transparent
        Me.FlatLabel9.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.FlatLabel9.ForeColor = System.Drawing.Color.White
        Me.FlatLabel9.Location = New System.Drawing.Point(107, 55)
        Me.FlatLabel9.Name = "FlatLabel9"
        Me.FlatLabel9.Size = New System.Drawing.Size(158, 13)
        Me.FlatLabel9.TabIndex = 0
        Me.FlatLabel9.Text = "Created by MooreR Software."
        '
        'FlatClose1
        '
        Me.FlatClose1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatClose1.BackColor = System.Drawing.Color.White
        Me.FlatClose1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(168, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.FlatClose1.Font = New System.Drawing.Font("Marlett", 10.0!)
        Me.FlatClose1.Location = New System.Drawing.Point(356, 12)
        Me.FlatClose1.Name = "FlatClose1"
        Me.FlatClose1.Size = New System.Drawing.Size(18, 18)
        Me.FlatClose1.TabIndex = 1
        Me.FlatClose1.Text = "FlatClose1"
        Me.FlatClose1.TextColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        '
        'FlatMini1
        '
        Me.FlatMini1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatMini1.BackColor = System.Drawing.Color.White
        Me.FlatMini1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.FlatMini1.Font = New System.Drawing.Font("Marlett", 12.0!)
        Me.FlatMini1.Location = New System.Drawing.Point(320, 12)
        Me.FlatMini1.Name = "FlatMini1"
        Me.FlatMini1.Size = New System.Drawing.Size(18, 18)
        Me.FlatMini1.TabIndex = 0
        Me.FlatMini1.Text = "FlatMini1"
        Me.FlatMini1.TextColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(243, Byte), Integer))
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 256)
        Me.Controls.Add(Me.FormSkin1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SugarPlant Monitor"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.FormSkin1.ResumeLayout(False)
        Me.FlatTabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FormSkin1 As FlatUI.FormSkin
    Friend WithEvents FlatMini1 As FlatUI.FlatMini
    Friend WithEvents FlatClose1 As FlatUI.FlatClose
    Friend WithEvents FlatTabControl1 As FlatUI.FlatTabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents FlatStatusBar1 As FlatUI.FlatStatusBar
    Friend WithEvents FlatLabel1 As FlatUI.FlatLabel
    Friend WithEvents TextPass As FlatUI.FlatTextBox
    Friend WithEvents FlatLabel3 As FlatUI.FlatLabel
    Friend WithEvents TextWallet As FlatUI.FlatTextBox
    Friend WithEvents FlatLabel2 As FlatUI.FlatLabel
    Friend WithEvents FlatLabel5 As FlatUI.FlatLabel
    Friend WithEvents FlatLabel4 As FlatUI.FlatLabel
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents LabelPaid As FlatUI.FlatLabel
    Friend WithEvents LabelWorkers As FlatUI.FlatLabel
    Friend WithEvents LabelHashrate As FlatUI.FlatLabel
    Friend WithEvents FlatLabel9 As FlatUI.FlatLabel
    Friend WithEvents ButtonCheck As FlatUI.FlatButton
    Friend WithEvents LabelCurrBalance As FlatUI.FlatLabel
    Friend WithEvents FlatLabel7 As FlatUI.FlatLabel
End Class
