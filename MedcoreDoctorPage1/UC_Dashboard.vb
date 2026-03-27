Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class UC_Dashboard
    Inherits UserControl

    ' Timer for live clock
    Private WithEvents timerClock As New Timer()

    ' UI Components
    Private greetingPanel As Panel
    Private statsPanel As FlowLayoutPanel
    Private graphPanel As Panel
    Private averageTimePanel As Panel

    ' Labels
    Private lblGreeting As Label
    Private lblDoctorName As Label
    Private lblLiveTime As Label
    Private lblLiveDate As Label

    ' Stat Cards
    Private cardTotal As Panel
    Private cardWaiting As Panel
    Private cardServing As Panel
    Private cardDone As Panel

    ' Graph Controls
    Private chartPanel As Panel
    Private lblGraphTitle As Label
    Private toothFillingBar As Panel
    Private teethCheckupBar As Panel
    Private othersBar As Panel
    Private lblToothFillingValue As Label
    Private lblTeethCheckupValue As Label
    Private lblOthersValue As Label

    ' Average Time Display
    Private lblAverageTitle As Label
    Private lblAverageValue As Label
    Private currentServiceIndex As Integer = 0
    Private WithEvents timerAverage As New Timer()

    ' Sample Data
    Private toothFillingCount As Integer = 156
    Private teethCheckupCount As Integer = 243
    Private othersCount As Integer = 89
    Private maxCount As Integer = 250

    ' Properties for Designer (Para madali mong i-adjust)
    Private _cardBackColor As Color = Color.White
    Private _cardBorderRadius As Integer = 8
    Private _primaryColor As Color = Color.FromArgb(26, 115, 232)
    Private _successColor As Color = Color.FromArgb(52, 168, 83)
    Private _warningColor As Color = Color.FromArgb(251, 188, 5)
    Private _dangerColor As Color = Color.FromArgb(234, 67, 53)

    ' Designer Properties
    <Category("Appearance")>
    Public Property CardBackColor As Color
        Get
            Return _cardBackColor
        End Get
        Set(value As Color)
            _cardBackColor = value
            RefreshStatsCards()
        End Set
    End Property

    <Category("Appearance")>
    Public Property CardBorderRadius As Integer
        Get
            Return _cardBorderRadius
        End Get
        Set(value As Integer)
            _cardBorderRadius = value
            RefreshStatsCards()
        End Set
    End Property

    <Category("Colors")>
    Public Property PrimaryColor As Color
        Get
            Return _primaryColor
        End Get
        Set(value As Color)
            _primaryColor = value
            ApplyColors()
        End Set
    End Property

    Public Sub New()

        SetupTimer()
        StartAverageTimer()
    End Sub

    Private Sub InitializeComponent()
        Me.BackColor = Color.FromArgb(248, 249, 250)
        Me.Dock = DockStyle.Fill
        Me.AutoScroll = True

        ' Main Layout
        Dim mainLayout As New TableLayoutPanel()
        mainLayout.Dock = DockStyle.Fill
        mainLayout.ColumnCount = 1
        mainLayout.RowCount = 4
        mainLayout.Padding = New Padding(15)

        mainLayout.RowStyles.Add(New RowStyle(SizeType.Absolute, 80))  ' Greeting Panel
        mainLayout.RowStyles.Add(New RowStyle(SizeType.Absolute, 130)) ' Stats Panel
        mainLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 60))   ' Graph Panel
        mainLayout.RowStyles.Add(New RowStyle(SizeType.Percent, 40))   ' Average Time Panel

        ' Create all sections
        CreateGreetingPanel()
        CreateStatsPanel()
        CreateGraphPanel()
        CreateAverageTimePanel()

        mainLayout.Controls.Add(greetingPanel, 0, 0)
        mainLayout.Controls.Add(statsPanel, 0, 1)
        mainLayout.Controls.Add(graphPanel, 0, 2)
        mainLayout.Controls.Add(averageTimePanel, 0, 3)

        Me.Controls.Add(mainLayout)
    End Sub

    Private Sub CreateGreetingPanel()
        greetingPanel = New Panel()
        greetingPanel.BackColor = Color.White
        greetingPanel.Dock = DockStyle.Fill
        greetingPanel.Margin = New Padding(0, 0, 0, 10)

        ' Left side - Greeting
        lblGreeting = New Label()
        lblGreeting.Text = "Good Morning,"
        lblGreeting.Font = New Font("Segoe UI", 14, FontStyle.Regular)
        lblGreeting.ForeColor = Color.FromArgb(64, 64, 64)
        lblGreeting.Location = New Point(20, 20)
        lblGreeting.AutoSize = True

        lblDoctorName = New Label()
        lblDoctorName.Text = "Dr. Maria Santos"
        lblDoctorName.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        lblDoctorName.ForeColor = Color.FromArgb(26, 115, 232)
        lblDoctorName.Location = New Point(20, 45)
        lblDoctorName.AutoSize = True

        ' Right side - Date and Time
        Dim timePanel As New Panel()
        timePanel.Dock = DockStyle.Right
        timePanel.Width = 250
        timePanel.BackColor = Color.Transparent

        lblLiveTime = New Label()
        lblLiveTime.Text = DateTime.Now.ToString("hh:mm:ss tt")
        lblLiveTime.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblLiveTime.ForeColor = Color.FromArgb(26, 115, 232)
        lblLiveTime.Location = New Point(20, 15)
        lblLiveTime.AutoSize = True

        lblLiveDate = New Label()
        lblLiveDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy")
        lblLiveDate.Font = New Font("Segoe UI", 9)
        lblLiveDate.ForeColor = Color.Gray
        lblLiveDate.Location = New Point(20, 50)
        lblLiveDate.AutoSize = True

        timePanel.Controls.Add(lblLiveDate)
        timePanel.Controls.Add(lblLiveTime)

        greetingPanel.Controls.Add(timePanel)
        greetingPanel.Controls.Add(lblDoctorName)
        greetingPanel.Controls.Add(lblGreeting)

        ' Update greeting based on time of day
        UpdateGreeting()
    End Sub

    Private Sub UpdateGreeting()
        Dim hour As Integer = DateTime.Now.Hour

        If hour < 12 Then
            lblGreeting.Text = "Good Morning,"
        ElseIf hour < 18 Then
            lblGreeting.Text = "Good Afternoon,"
        Else
            lblGreeting.Text = "Good Evening,"
        End If
    End Sub

    Private Sub CreateStatsPanel()
        statsPanel = New FlowLayoutPanel()
        statsPanel.Dock = DockStyle.Fill
        statsPanel.BackColor = Color.Transparent
        statsPanel.Padding = New Padding(0, 5, 0, 5)
        statsPanel.WrapContents = True

        ' Create Stat Cards
        cardTotal = CreateStatCard("Total Patients", "1,284", "👥", _primaryColor)
        cardWaiting = CreateStatCard("Waiting", "8", "⏳", _warningColor)
        cardServing = CreateStatCard("Serving", "3", "🦷", _successColor)
        cardDone = CreateStatCard("Done Today", "16", "✅", _dangerColor)

        statsPanel.Controls.AddRange({cardTotal, cardWaiting, cardServing, cardDone})
    End Sub

    Private Function CreateStatCard(title As String, value As String, icon As String, color As Color) As Panel
        Dim card As New Panel()
        card.Size = New Size(280, 100)
        card.BackColor = _cardBackColor
        card.Margin = New Padding(8)

        ' Add rounded corners using Region
        Dim path As New GraphicsPath()
        path.AddArc(0, 0, _cardBorderRadius, _cardBorderRadius, 180, 90)
        path.AddArc(card.Width - _cardBorderRadius, 0, _cardBorderRadius, _cardBorderRadius, 270, 90)
        path.AddArc(card.Width - _cardBorderRadius, card.Height - _cardBorderRadius, _cardBorderRadius, _cardBorderRadius, 0, 90)
        path.AddArc(0, card.Height - _cardBorderRadius, _cardBorderRadius, _cardBorderRadius, 90, 90)
        card.Region = New Region(path)

        Dim lblIcon As New Label()
        lblIcon.Text = icon
        lblIcon.Font = New Font("Segoe UI", 28)
        lblIcon.Location = New Point(15, 25)
        lblIcon.AutoSize = True

        Dim lblTitle As New Label()
        lblTitle.Text = title
        lblTitle.Font = New Font("Segoe UI", 10)
        lblTitle.ForeColor = Color.Gray
        lblTitle.Location = New Point(15, 60)
        lblTitle.AutoSize = True

        Dim lblValue As New Label()
        lblValue.Text = value
        lblValue.Font = New Font("Segoe UI", 22, FontStyle.Bold)
        lblValue.ForeColor = color
        lblValue.Location = New Point(15, 65)
        lblValue.AutoSize = True

        Dim border As New Panel()
        border.BackColor = color
        border.Size = New Size(4, 70)
        border.Location = New Point(0, 15)

        card.Controls.AddRange({border, lblIcon, lblTitle, lblValue})
        Return card
    End Function

    Private Sub CreateGraphPanel()
        graphPanel = New Panel()
        graphPanel.BackColor = Color.White
        graphPanel.Dock = DockStyle.Fill
        graphPanel.Margin = New Padding(0, 10, 0, 10)
        graphPanel.Padding = New Padding(15)

        ' Graph Title
        lblGraphTitle = New Label()
        lblGraphTitle.Text = "Services Rendered This Month"
        lblGraphTitle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblGraphTitle.ForeColor = _primaryColor
        lblGraphTitle.Dock = DockStyle.Top
        lblGraphTitle.Height = 30

        ' Chart Container
        chartPanel = New Panel()
        chartPanel.Dock = DockStyle.Fill
        chartPanel.BackColor = Color.White

        ' Calculate bar heights
        Dim toothHeight As Integer = CInt((toothFillingCount / maxCount) * 200)
        Dim checkupHeight As Integer = CInt((teethCheckupCount / maxCount) * 200)
        Dim othersHeight As Integer = CInt((othersCount / maxCount) * 200)

        ' Tooth Filling Bar
        toothFillingBar = CreateBar("Tooth Filling", toothFillingCount, _primaryColor, 50, toothHeight)
        teethCheckupBar = CreateBar("Teeth Checkup", teethCheckupCount, _successColor, 250, checkupHeight)
        othersBar = CreateBar("Others", othersCount, _warningColor, 450, othersHeight)

        chartPanel.Controls.AddRange({toothFillingBar, teethCheckupBar, othersBar})
        graphPanel.Controls.Add(chartPanel)
        graphPanel.Controls.Add(lblGraphTitle)
    End Sub

    Private Function CreateBar(label As String, count As Integer, color As Color, xPosition As Integer, barHeight As Integer) As Panel
        Dim barPanel As New Panel()
        barPanel.Size = New Size(150, 250)
        barPanel.Location = New Point(xPosition, 30)
        barPanel.BackColor = Color.Transparent

        ' Bar itself
        Dim bar As New Panel()
        bar.BackColor = color
        bar.Size = New Size(80, barHeight)
        bar.Location = New Point(35, 250 - barHeight)

        ' Value Label
        Dim lblValue As New Label()
        lblValue.Text = count.ToString()
        lblValue.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblValue.ForeColor = color
        lblValue.Location = New Point(60, 250 - barHeight - 25)
        lblValue.AutoSize = True

        ' Label
        Dim lblName As New Label()
        lblName.Text = label
        lblName.Font = New Font("Segoe UI", 9)
        lblName.ForeColor = Color.Gray
        lblName.Location = New Point(45, 255)
        lblName.AutoSize = True

        barPanel.Controls.AddRange({bar, lblValue, lblName})
        Return barPanel
    End Function

    Private Sub CreateAverageTimePanel()
        averageTimePanel = New Panel()
        averageTimePanel.BackColor = Color.White
        averageTimePanel.Dock = DockStyle.Fill
        averageTimePanel.Padding = New Padding(20)

        ' Title
        lblAverageTitle = New Label()
        lblAverageTitle.Text = "Average Service Time"
        lblAverageTitle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblAverageTitle.ForeColor = _primaryColor
        lblAverageTitle.Location = New Point(20, 20)
        lblAverageTitle.AutoSize = True

        ' Value Display
        lblAverageValue = New Label()
        lblAverageValue.Text = GetCurrentServiceTime()
        lblAverageValue.Font = New Font("Segoe UI", 28, FontStyle.Bold)
        lblAverageValue.ForeColor = _primaryColor
        lblAverageValue.Location = New Point(20, 55)
        lblAverageValue.AutoSize = True

        ' Description
        Dim lblDescription As New Label()
        lblDescription.Text = "Average time per patient"
        lblDescription.Font = New Font("Segoe UI", 10)
        lblDescription.ForeColor = Color.Gray
        lblDescription.Location = New Point(20, 100)
        lblDescription.AutoSize = True

        averageTimePanel.Controls.Add(lblDescription)
        averageTimePanel.Controls.Add(lblAverageValue)
        averageTimePanel.Controls.Add(lblAverageTitle)
    End Sub

    Private Function GetCurrentServiceTime() As String
        Dim services As String() = {"Tooth Filling", "Teeth Checkup", "Others"}
        Dim times As String() = {"35 mins", "25 mins", "45 mins"}

        currentServiceIndex = (currentServiceIndex + 1) Mod services.Length
        Return times(currentServiceIndex) & " - " & services(currentServiceIndex)
    End Function

    Private Sub SetupTimer()
        timerClock.Interval = 1000
        timerClock.Start()
        AddHandler timerClock.Tick, AddressOf UpdateClock
    End Sub

    Private Sub StartAverageTimer()
        timerAverage.Interval = 3000
        timerAverage.Start()
        AddHandler timerAverage.Tick, AddressOf UpdateAverageTime
    End Sub

    Private Sub UpdateClock(sender As Object, e As EventArgs)
        lblLiveTime.Text = DateTime.Now.ToString("hh:mm:ss tt")
        lblLiveDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy")

        ' Update greeting every hour
        If DateTime.Now.Minute = 0 And DateTime.Now.Second = 0 Then
            UpdateGreeting()
        End If
    End Sub

    Private Sub UpdateAverageTime(sender As Object, e As EventArgs)
        lblAverageValue.Text = GetCurrentServiceTime()
    End Sub

    Private Sub RefreshStatsCards()
        ' Refresh all stat cards when properties change
        If statsPanel IsNot Nothing Then
            statsPanel.Controls.Clear()
            cardTotal = CreateStatCard("Total Patients", "1,284", "👥", _primaryColor)
            cardWaiting = CreateStatCard("Waiting", "8", "⏳", _warningColor)
            cardServing = CreateStatCard("Serving", "3", "🦷", _successColor)
            cardDone = CreateStatCard("Done Today", "16", "✅", _dangerColor)
            statsPanel.Controls.AddRange({cardTotal, cardWaiting, cardServing, cardDone})
        End If
    End Sub

    Private Sub ApplyColors()
        lblGreeting.ForeColor = _primaryColor
        lblDoctorName.ForeColor = _primaryColor
        lblLiveTime.ForeColor = _primaryColor
        lblGraphTitle.ForeColor = _primaryColor
        lblAverageTitle.ForeColor = _primaryColor
        lblAverageValue.ForeColor = _primaryColor

        RefreshStatsCards()
    End Sub

    ' Public methods for updating data (for database integration later)
    Public Sub UpdateStats(total As String, waiting As String, serving As String, done As String)
        If cardTotal IsNot Nothing Then
            For Each ctrl As Control In cardTotal.Controls
                If TypeOf ctrl Is Label AndAlso ctrl.Font.Size = 22 Then
                    ctrl.Text = total
                End If
            Next
        End If
    End Sub

    Public Sub UpdateGraphData(toothFilling As Integer, teethCheckup As Integer, others As Integer)
        toothFillingCount = toothFilling
        teethCheckupCount = teethCheckup
        othersCount = others

        ' Refresh graph
        CreateGraphPanel()
    End Sub
End Class