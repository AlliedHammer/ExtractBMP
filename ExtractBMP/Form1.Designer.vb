<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExtractBMP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExtractBMP))
        Me.InputTextBox = New System.Windows.Forms.TextBox()
        Me.OutputTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.InputButton = New System.Windows.Forms.Button()
        Me.OutputButton = New System.Windows.Forms.Button()
        Me.ConvertButton = New System.Windows.Forms.Button()
        Me.InfoBox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'InputTextBox
        '
        Me.InputTextBox.Location = New System.Drawing.Point(96, 39)
        Me.InputTextBox.Name = "InputTextBox"
        Me.InputTextBox.Size = New System.Drawing.Size(563, 20)
        Me.InputTextBox.TabIndex = 0
        '
        'OutputTextBox
        '
        Me.OutputTextBox.Location = New System.Drawing.Point(96, 88)
        Me.OutputTextBox.Name = "OutputTextBox"
        Me.OutputTextBox.Size = New System.Drawing.Size(563, 20)
        Me.OutputTextBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = ".DAT File"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = ".BMP Directory"
        '
        'InputButton
        '
        Me.InputButton.Location = New System.Drawing.Point(665, 37)
        Me.InputButton.Name = "InputButton"
        Me.InputButton.Size = New System.Drawing.Size(75, 23)
        Me.InputButton.TabIndex = 4
        Me.InputButton.Text = "Browse"
        Me.InputButton.UseVisualStyleBackColor = True
        '
        'OutputButton
        '
        Me.OutputButton.Location = New System.Drawing.Point(665, 86)
        Me.OutputButton.Name = "OutputButton"
        Me.OutputButton.Size = New System.Drawing.Size(75, 23)
        Me.OutputButton.TabIndex = 5
        Me.OutputButton.Text = "Browse"
        Me.OutputButton.UseVisualStyleBackColor = True
        '
        'ConvertButton
        '
        Me.ConvertButton.Location = New System.Drawing.Point(339, 120)
        Me.ConvertButton.Name = "ConvertButton"
        Me.ConvertButton.Size = New System.Drawing.Size(75, 23)
        Me.ConvertButton.TabIndex = 6
        Me.ConvertButton.Text = "Extract"
        Me.ConvertButton.UseVisualStyleBackColor = True
        '
        'InfoBox
        '
        Me.InfoBox.Location = New System.Drawing.Point(12, 189)
        Me.InfoBox.Multiline = True
        Me.InfoBox.Name = "InfoBox"
        Me.InfoBox.ReadOnly = True
        Me.InfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.InfoBox.Size = New System.Drawing.Size(720, 475)
        Me.InfoBox.TabIndex = 7
        '
        'ExtractBMP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 676)
        Me.Controls.Add(Me.InfoBox)
        Me.Controls.Add(Me.ConvertButton)
        Me.Controls.Add(Me.OutputButton)
        Me.Controls.Add(Me.InputButton)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.OutputTextBox)
        Me.Controls.Add(Me.InputTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ExtractBMP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ExtractBMP v0.1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

End Sub
    Friend WithEvents InputTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OutputTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents InputButton As System.Windows.Forms.Button
    Friend WithEvents OutputButton As System.Windows.Forms.Button
    Friend WithEvents ConvertButton As System.Windows.Forms.Button
    Friend WithEvents InfoBox As System.Windows.Forms.TextBox

End Class
