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
        Me.components = New System.ComponentModel.Container()
        Me.txtStartFreq = New System.Windows.Forms.TextBox()
        Me.txtStopFreq = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSweep = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.chkContSweep = New System.Windows.Forms.CheckBox()
        Me.txtNumSteps = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblMinPointFreq = New System.Windows.Forms.Label()
        Me.lblF0 = New System.Windows.Forms.Label()
        Me.lblF1 = New System.Windows.Forms.Label()
        Me.lblF2 = New System.Windows.Forms.Label()
        Me.lblF3 = New System.Windows.Forms.Label()
        Me.lblF4 = New System.Windows.Forms.Label()
        Me.lblF5 = New System.Windows.Forms.Label()
        Me.lblF6 = New System.Windows.Forms.Label()
        Me.lblF7 = New System.Windows.Forms.Label()
        Me.lblF8 = New System.Windows.Forms.Label()
        Me.lblF9 = New System.Windows.Forms.Label()
        Me.lblF10 = New System.Windows.Forms.Label()
        Me.ComboBandSelect = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPort = New System.Windows.Forms.ComboBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.lblVSWR = New System.Windows.Forms.Label()
        Me.btnZoom = New System.Windows.Forms.Button()
        Me.txtMarkerFreq = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSerialPortScan = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.txtCWFreq = New System.Windows.Forms.TextBox()
        Me.btnCW = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtStartFreq
        '
        Me.txtStartFreq.Location = New System.Drawing.Point(591, 349)
        Me.txtStartFreq.Name = "txtStartFreq"
        Me.txtStartFreq.Size = New System.Drawing.Size(100, 20)
        Me.txtStartFreq.TabIndex = 1
        '
        'txtStopFreq
        '
        Me.txtStopFreq.Location = New System.Drawing.Point(591, 372)
        Me.txtStopFreq.Name = "txtStopFreq"
        Me.txtStopFreq.Size = New System.Drawing.Size(100, 20)
        Me.txtStopFreq.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(532, 349)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Start Freq"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(532, 372)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Stop Freq"
        '
        'btnSweep
        '
        Me.btnSweep.Location = New System.Drawing.Point(563, 440)
        Me.btnSweep.Name = "btnSweep"
        Me.btnSweep.Size = New System.Drawing.Size(75, 23)
        Me.btnSweep.TabIndex = 5
        Me.btnSweep.Text = "Sweep"
        Me.btnSweep.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        '
        'chkContSweep
        '
        Me.chkContSweep.AutoSize = True
        Me.chkContSweep.Location = New System.Drawing.Point(745, 446)
        Me.chkContSweep.Name = "chkContSweep"
        Me.chkContSweep.Size = New System.Drawing.Size(79, 17)
        Me.chkContSweep.TabIndex = 6
        Me.chkContSweep.Text = "Continuous"
        Me.chkContSweep.UseVisualStyleBackColor = True
        '
        'txtNumSteps
        '
        Me.txtNumSteps.Location = New System.Drawing.Point(591, 398)
        Me.txtNumSteps.Name = "txtNumSteps"
        Me.txtNumSteps.Size = New System.Drawing.Size(100, 20)
        Me.txtNumSteps.TabIndex = 9
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.PictureBox1.Location = New System.Drawing.Point(27, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(500, 500)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'lblMinPointFreq
        '
        Me.lblMinPointFreq.AutoSize = True
        Me.lblMinPointFreq.Font = New System.Drawing.Font("Lucida Sans", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMinPointFreq.Location = New System.Drawing.Point(529, 9)
        Me.lblMinPointFreq.Name = "lblMinPointFreq"
        Me.lblMinPointFreq.Size = New System.Drawing.Size(372, 109)
        Me.lblMinPointFreq.TabIndex = 11
        Me.lblMinPointFreq.Text = "Label3"
        '
        'lblF0
        '
        Me.lblF0.AutoSize = True
        Me.lblF0.Location = New System.Drawing.Point(24, 506)
        Me.lblF0.Name = "lblF0"
        Me.lblF0.Size = New System.Drawing.Size(22, 13)
        Me.lblF0.TabIndex = 13
        Me.lblF0.Text = "0.0"
        '
        'lblF1
        '
        Me.lblF1.AutoSize = True
        Me.lblF1.Location = New System.Drawing.Point(69, 506)
        Me.lblF1.Name = "lblF1"
        Me.lblF1.Size = New System.Drawing.Size(22, 13)
        Me.lblF1.TabIndex = 14
        Me.lblF1.Text = "0.0"
        '
        'lblF2
        '
        Me.lblF2.AutoSize = True
        Me.lblF2.Location = New System.Drawing.Point(122, 506)
        Me.lblF2.Name = "lblF2"
        Me.lblF2.Size = New System.Drawing.Size(22, 13)
        Me.lblF2.TabIndex = 15
        Me.lblF2.Text = "0.0"
        '
        'lblF3
        '
        Me.lblF3.AutoSize = True
        Me.lblF3.Location = New System.Drawing.Point(167, 506)
        Me.lblF3.Name = "lblF3"
        Me.lblF3.Size = New System.Drawing.Size(22, 13)
        Me.lblF3.TabIndex = 16
        Me.lblF3.Text = "0.0"
        '
        'lblF4
        '
        Me.lblF4.AutoSize = True
        Me.lblF4.Location = New System.Drawing.Point(212, 506)
        Me.lblF4.Name = "lblF4"
        Me.lblF4.Size = New System.Drawing.Size(22, 13)
        Me.lblF4.TabIndex = 17
        Me.lblF4.Text = "0.0"
        '
        'lblF5
        '
        Me.lblF5.AutoSize = True
        Me.lblF5.Location = New System.Drawing.Point(263, 507)
        Me.lblF5.Name = "lblF5"
        Me.lblF5.Size = New System.Drawing.Size(22, 13)
        Me.lblF5.TabIndex = 18
        Me.lblF5.Text = "0.0"
        '
        'lblF6
        '
        Me.lblF6.AutoSize = True
        Me.lblF6.Location = New System.Drawing.Point(314, 507)
        Me.lblF6.Name = "lblF6"
        Me.lblF6.Size = New System.Drawing.Size(22, 13)
        Me.lblF6.TabIndex = 19
        Me.lblF6.Text = "0.0"
        '
        'lblF7
        '
        Me.lblF7.AutoSize = True
        Me.lblF7.Location = New System.Drawing.Point(365, 507)
        Me.lblF7.Name = "lblF7"
        Me.lblF7.Size = New System.Drawing.Size(22, 13)
        Me.lblF7.TabIndex = 20
        Me.lblF7.Text = "0.0"
        '
        'lblF8
        '
        Me.lblF8.AutoSize = True
        Me.lblF8.Location = New System.Drawing.Point(421, 507)
        Me.lblF8.Name = "lblF8"
        Me.lblF8.Size = New System.Drawing.Size(22, 13)
        Me.lblF8.TabIndex = 21
        Me.lblF8.Text = "0.0"
        '
        'lblF9
        '
        Me.lblF9.AutoSize = True
        Me.lblF9.Location = New System.Drawing.Point(472, 507)
        Me.lblF9.Name = "lblF9"
        Me.lblF9.Size = New System.Drawing.Size(22, 13)
        Me.lblF9.TabIndex = 22
        Me.lblF9.Text = "0.0"
        '
        'lblF10
        '
        Me.lblF10.AutoSize = True
        Me.lblF10.Location = New System.Drawing.Point(517, 507)
        Me.lblF10.Name = "lblF10"
        Me.lblF10.Size = New System.Drawing.Size(22, 13)
        Me.lblF10.TabIndex = 23
        Me.lblF10.Text = "0.0"
        '
        'ComboBandSelect
        '
        Me.ComboBandSelect.FormattingEnabled = True
        Me.ComboBandSelect.Items.AddRange(New Object() {"160m", "80m", "60m", "40m", "30m", "20m", "17m", "15m", "12m", "10m", "Whole"})
        Me.ComboBandSelect.Location = New System.Drawing.Point(591, 322)
        Me.ComboBandSelect.Name = "ComboBandSelect"
        Me.ComboBandSelect.Size = New System.Drawing.Size(121, 21)
        Me.ComboBandSelect.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(551, 401)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Steps"
        '
        'cmbPort
        '
        Me.cmbPort.FormattingEnabled = True
        Me.cmbPort.Location = New System.Drawing.Point(548, 276)
        Me.cmbPort.Name = "cmbPort"
        Me.cmbPort.Size = New System.Drawing.Size(121, 21)
        Me.cmbPort.TabIndex = 32
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(675, 276)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(122, 22)
        Me.btnConnect.TabIndex = 33
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(-3, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "10:1"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 13)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "9:1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 194)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 13)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "7:1"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 142)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(22, 13)
        Me.Label10.TabIndex = 38
        Me.Label10.Text = "8:1"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 299)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(22, 13)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "5:1"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 245)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 13)
        Me.Label12.TabIndex = 40
        Me.Label12.Text = "6:1"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 400)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 13)
        Me.Label13.TabIndex = 43
        Me.Label13.Text = "3:1"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 350)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(22, 13)
        Me.Label14.TabIndex = 42
        Me.Label14.Text = "4:1"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 497)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(22, 13)
        Me.Label15.TabIndex = 45
        Me.Label15.Text = "1:1"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 450)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(22, 13)
        Me.Label16.TabIndex = 44
        Me.Label16.Text = "2:1"
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'lblVSWR
        '
        Me.lblVSWR.AutoSize = True
        Me.lblVSWR.Font = New System.Drawing.Font("Lucida Sans", 72.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVSWR.Location = New System.Drawing.Point(529, 129)
        Me.lblVSWR.Name = "lblVSWR"
        Me.lblVSWR.Size = New System.Drawing.Size(450, 109)
        Me.lblVSWR.TabIndex = 46
        Me.lblVSWR.Text = "lblVSWR"
        '
        'btnZoom
        '
        Me.btnZoom.Location = New System.Drawing.Point(653, 443)
        Me.btnZoom.Name = "btnZoom"
        Me.btnZoom.Size = New System.Drawing.Size(86, 20)
        Me.btnZoom.TabIndex = 47
        Me.btnZoom.Text = "Zoom In"
        Me.btnZoom.UseVisualStyleBackColor = True
        '
        'txtMarkerFreq
        '
        Me.txtMarkerFreq.Location = New System.Drawing.Point(745, 393)
        Me.txtMarkerFreq.Name = "txtMarkerFreq"
        Me.txtMarkerFreq.Size = New System.Drawing.Size(100, 20)
        Me.txtMarkerFreq.TabIndex = 48
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(747, 372)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Marker (MHz)"
        '
        'btnSerialPortScan
        '
        Me.btnSerialPortScan.Location = New System.Drawing.Point(680, 248)
        Me.btnSerialPortScan.Name = "btnSerialPortScan"
        Me.btnSerialPortScan.Size = New System.Drawing.Size(117, 22)
        Me.btnSerialPortScan.TabIndex = 50
        Me.btnSerialPortScan.Text = "Rescan"
        Me.btnSerialPortScan.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(553, 322)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 51
        Me.Label3.Text = "Band"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(551, 260)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Serial Port"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(931, 252)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(77, 70)
        Me.btnSave.TabIndex = 53
        Me.btnSave.Text = "Save CSV"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtCWFreq
        '
        Me.txtCWFreq.Location = New System.Drawing.Point(923, 368)
        Me.txtCWFreq.Name = "txtCWFreq"
        Me.txtCWFreq.Size = New System.Drawing.Size(85, 20)
        Me.txtCWFreq.TabIndex = 54
        '
        'btnCW
        '
        Me.btnCW.Location = New System.Drawing.Point(923, 390)
        Me.btnCW.Name = "btnCW"
        Me.btnCW.Size = New System.Drawing.Size(75, 23)
        Me.btnCW.TabIndex = 55
        Me.btnCW.Text = "Set CW"
        Me.btnCW.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(699, 351)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(29, 13)
        Me.Label17.TabIndex = 56
        Me.Label17.Text = "MHz"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(699, 375)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(29, 13)
        Me.Label18.TabIndex = 57
        Me.Label18.Text = "MHz"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(1014, 368)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(29, 13)
        Me.Label19.TabIndex = 58
        Me.Label19.Text = "MHz"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(920, 349)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(94, 13)
        Me.Label20.TabIndex = 59
        Me.Label20.Text = "CW Signal Source"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1091, 526)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btnCW)
        Me.Controls.Add(Me.txtCWFreq)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSerialPortScan)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtMarkerFreq)
        Me.Controls.Add(Me.btnZoom)
        Me.Controls.Add(Me.lblVSWR)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.cmbPort)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComboBandSelect)
        Me.Controls.Add(Me.lblF10)
        Me.Controls.Add(Me.lblF9)
        Me.Controls.Add(Me.lblF8)
        Me.Controls.Add(Me.lblF7)
        Me.Controls.Add(Me.lblF6)
        Me.Controls.Add(Me.lblF5)
        Me.Controls.Add(Me.lblF4)
        Me.Controls.Add(Me.lblF3)
        Me.Controls.Add(Me.lblF2)
        Me.Controls.Add(Me.lblF1)
        Me.Controls.Add(Me.lblF0)
        Me.Controls.Add(Me.lblMinPointFreq)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtNumSteps)
        Me.Controls.Add(Me.chkContSweep)
        Me.Controls.Add(Me.btnSweep)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtStopFreq)
        Me.Controls.Add(Me.txtStartFreq)
        Me.Name = "Form1"
        Me.Text = "K6BEZ Antenna Analyser"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtStartFreq As System.Windows.Forms.TextBox
    Friend WithEvents txtStopFreq As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSweep As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents chkContSweep As System.Windows.Forms.CheckBox
    Friend WithEvents txtNumSteps As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblMinPointFreq As System.Windows.Forms.Label
    Friend WithEvents lblF0 As System.Windows.Forms.Label
    Friend WithEvents lblF1 As System.Windows.Forms.Label
    Friend WithEvents lblF2 As System.Windows.Forms.Label
    Friend WithEvents lblF3 As System.Windows.Forms.Label
    Friend WithEvents lblF4 As System.Windows.Forms.Label
    Friend WithEvents lblF5 As System.Windows.Forms.Label
    Friend WithEvents lblF6 As System.Windows.Forms.Label
    Friend WithEvents lblF7 As System.Windows.Forms.Label
    Friend WithEvents lblF8 As System.Windows.Forms.Label
    Friend WithEvents lblF9 As System.Windows.Forms.Label
    Friend WithEvents lblF10 As System.Windows.Forms.Label
    Friend WithEvents ComboBandSelect As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbPort As System.Windows.Forms.ComboBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents lblVSWR As System.Windows.Forms.Label
    Friend WithEvents btnZoom As System.Windows.Forms.Button
    Friend WithEvents txtMarkerFreq As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSerialPortScan As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txtCWFreq As System.Windows.Forms.TextBox
    Friend WithEvents btnCW As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label

End Class
