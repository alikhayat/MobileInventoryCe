
Imports System
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Reflection
Imports System.IO


' Summary description for SplashForm.
Public Class SplashForm
    Inherits System.Windows.Forms.Form

    ' A hack constant specifying how many cells the animation has
    Private Const kNumAnimationCells As Integer = 8

    ' Splash screen background bitmap
    Private bmpSplash As Bitmap = Nothing

    ' Splash screen animation bitmap
    Private bmpAnim As Bitmap = Nothing

    ' Current screen position of the animation
    Private animPos As New Rectangle(0, 0, 0, 0)

    ' Graphics object used to render splash screen.
    ' Cached for performance.
    Private g As Graphics = Nothing

    ' The region of the screen filled by the background.
    ' Cached for performance.
    Private splashRegion As New Rectangle(0, 0, 0, 0)

    ' The source region of the background draw.
    ' Cached for performance.
    Private splashSrc As New Rectangle(0, 0, 0, 0)

    ' Image attributes specifying transperancy color.
    ' Cached for performance.
    Private attr As New ImageAttributes

    ' Timer used to update the screen at regular intervals.
    Private splashTimer As System.Threading.Timer = Nothing

    ' Source region for redrawing the background.
    ' Cached for performance.
    Private redrawSrc As New Rectangle(0, 0, 0, 0)

    ' Current cell being displayed in the animation.
    Private curAnimCell As Integer = 0

    ' The number of updates that the splash screen timer triggered.
    Private numUpdates As Integer = 0

    ' Time between screen updates (ms)
    Private timerInterval_ms As Integer = 0

    Public Sub New(ByVal timerInterval As Integer)

        timerInterval_ms = timerInterval

        Dim asm As [Assembly] = [Assembly].GetExecutingAssembly()
        bmpSplash = New Bitmap(Path.GetDirectoryName(Assembly.GetExecutingAssembly.GetName.CodeBase) + "\Logo's\S01.png")
        'bmpAnim = New Bitmap(asm.GetManifestResourceStream((asm.GetName().Name + ".animation.bmp")))

        InitializeComponent()
    End Sub 'New

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'SplashForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Name = "SplashForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Function GetUpMilliseconds() As Integer
        Return numUpdates * timerInterval_ms
    End Function

    Private Sub SplashForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Make this form full screen
        Me.Text = ""
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ControlBox = False
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        Me.Menu = Nothing

        ' Center the splash screen background
        splashRegion.X = (Screen.PrimaryScreen.Bounds.Width - bmpSplash.Width) / 2
        splashRegion.Y = (Screen.PrimaryScreen.Bounds.Height - bmpSplash.Height) / 2
        splashRegion.Width = bmpSplash.Width
        splashRegion.Height = bmpSplash.Height

        ' Set up the rectangle from which the background will be drawn
        splashSrc.X = 0
        splashSrc.Y = 0
        splashSrc.Width = bmpSplash.Width
        splashSrc.Height = bmpSplash.Height

        'Set up the destination region of the animatino draw 
        'animPos.X = splashRegion.X - bmpAnim.Width / kNumAnimationCells
        'animPos.Y = splashRegion.Y + splashRegion.Height - bmpAnim.Height
        'animPos.Width = bmpAnim.Width / kNumAnimationCells
        'animPos.Height = bmpAnim.Height

        '' Initialize the draw region used to optimize animation updates
        'redrawSrc.Width = bmpAnim.Width / kNumAnimationCells
        'redrawSrc.Height = bmpAnim.Height

        '' Cache the transparent color
        'attr.SetColorKey(bmpAnim.GetPixel(0, 0), bmpAnim.GetPixel(0, 0))

        ' Create the graphics object and set its clipping region
        g = CreateGraphics()
        g.Clip = New [Region](splashRegion)

        Draw(True, False)

        Dim splashDelegate As New System.Threading.TimerCallback(AddressOf Me.Draw)
        Me.splashTimer = New System.Threading.Timer(splashDelegate, Nothing, timerInterval_ms, timerInterval_ms)

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Draw(True, False)
    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As PaintEventArgs)
    End Sub

    Public Sub KillMe(ByVal o As Object, ByVal e As EventArgs)

        splashTimer.Dispose()

        Me.Close()

    End Sub

    Protected Overloads Sub Draw(ByVal state As Object)

        numUpdates += 1

        Draw(False, True)

    End Sub

    Protected Overloads Sub Draw(ByVal bFullImage As Boolean, ByVal bUpdateAnim As Boolean)

        If g Is Nothing Then
            Return
        End If

        SyncLock Me
            If bFullImage Then

                g.DrawImage(bmpSplash, splashRegion, splashSrc, GraphicsUnit.Pixel)

            ElseIf bUpdateAnim Then
                redrawSrc.X = animPos.X - splashRegion.X
                redrawSrc.Y = animPos.Y - splashRegion.Y
                g.DrawImage(bmpSplash, animPos, redrawSrc, GraphicsUnit.Pixel)

            End If

            If bUpdateAnim Then
                curAnimCell += 1
                If curAnimCell >= kNumAnimationCells Then
                    curAnimCell = 0
                End If

                '    animPos.X += 5
                '    If animPos.X > splashRegion.X + splashRegion.Width Then
                '        animPos.X = splashRegion.X - bmpAnim.Width / kNumAnimationCells
                '    End If

            End If

            'g.DrawImage(bmpAnim, animPos, curAnimCell * bmpAnim.Width / kNumAnimationCells, 0, bmpAnim.Width / kNumAnimationCells, bmpAnim.Height, GraphicsUnit.Pixel, attr)

        End SyncLock
    End Sub
End Class