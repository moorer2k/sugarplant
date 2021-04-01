Imports System.ComponentModel

Namespace FlatUI
    Class FormSkin : Inherits ContainerControl

#Region " Variables"

        Private W, H As Integer
        Private Cap As Boolean = False
        Private _HeaderMaximize As Boolean = False
        Private MousePoint As New Point(0, 0)
        Private MoveHeight = 50

#End Region

#Region " Properties"

#Region " Colors"

        <Category("Colors")> _
        Public Property HeaderColor() As Color
            Get
                Return _HeaderColor
            End Get
            Set(value As Color)
                _HeaderColor = value
            End Set
        End Property
        <Category("Colors")> _
        Public Property BaseColor() As Color
            Get
                Return _BaseColor
            End Get
            Set(value As Color)
                _BaseColor = value
            End Set
        End Property
        <Category("Colors")> _
        Public Property BorderColor() As Color
            Get
                Return _BorderColor
            End Get
            Set(value As Color)
                _BorderColor = value
            End Set
        End Property
        <Category("Colors")> _
        Public Property FlatColor() As Color
            Get
                Return _FlatColor
            End Get
            Set(value As Color)
                _FlatColor = value
            End Set
        End Property

#End Region

#Region " Options"

        <Category("Options")> _
        Public Property HeaderMaximize As Boolean
            Get
                Return _HeaderMaximize
            End Get
            Set(value As Boolean)
                _HeaderMaximize = value
            End Set
        End Property

#End Region

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            If e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(0, 0, Width, MoveHeight).Contains(e.Location) Then
                Cap = True
                MousePoint = e.Location
            End If
        End Sub

        Private Sub FormSkin_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick
            If HeaderMaximize Then
                If e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(0, 0, Width, MoveHeight).Contains(e.Location) Then
                    If FindForm.WindowState = FormWindowState.Normal Then
                        FindForm.WindowState = FormWindowState.Maximized : FindForm.Refresh()
                    ElseIf FindForm.WindowState = FormWindowState.Maximized Then
                        FindForm.WindowState = FormWindowState.Normal : FindForm.Refresh()
                    End If
                End If
            End If
        End Sub

        Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
            MyBase.OnMouseUp(e) : Cap = False
        End Sub

        Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
            MyBase.OnMouseMove(e)
            If Cap Then
                Parent.Location = MousePosition - MousePoint
            End If
        End Sub

        Protected Overrides Sub OnCreateControl()
            MyBase.OnCreateControl()
            ParentForm.FormBorderStyle = FormBorderStyle.None
            ParentForm.AllowTransparency = False
            ParentForm.TransparencyKey = Color.Fuchsia
            ParentForm.FindForm.StartPosition = FormStartPosition.CenterScreen
            Dock = DockStyle.Fill
            Invalidate()
        End Sub

#End Region

#Region " Colors"

#Region " Dark Colors"

        Private _HeaderColor As Color = Color.FromArgb(45, 47, 49)
        Private _BaseColor As Color = Color.FromArgb(60, 70, 73)
        Private _BorderColor As Color = Color.FromArgb(53, 58, 60)
        Private TextColor As Color = Color.FromArgb(234, 234, 234)

#End Region

#Region " Light Colors"

        Private _HeaderLight As Color = Color.FromArgb(171, 171, 172)
        Private _BaseLight As Color = Color.FromArgb(196, 199, 200)
        Public TextLight As Color = Color.FromArgb(45, 47, 49)

#End Region

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                     ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
            DoubleBuffered = True
            BackColor = Color.White
            Font = New Font("Segoe UI", 12)
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
            W = Width : H = Height

            Dim Base As New Rectangle(0, 0, W, H), Header As New Rectangle(0, 0, W, 50)

            With G
                .SmoothingMode = 2
                .PixelOffsetMode = 2
                .TextRenderingHint = 5
                .Clear(BackColor)

                '-- Base
                .FillRectangle(New SolidBrush(_BaseColor), Base)

                '-- Header
                .FillRectangle(New SolidBrush(_HeaderColor), Header)

                '-- Logo
                .FillRectangle(New SolidBrush(Color.FromArgb(243, 243, 243)), New Rectangle(8, 16, 4, 18))
                .FillRectangle(New SolidBrush(_FlatColor), 16, 16, 4, 18)
                .DrawString(Text, Font, New SolidBrush(TextColor), New Rectangle(26, 15, W, H), NearSF)

                '-- Border
                .DrawRectangle(New Pen(_BorderColor), Base)
            End With

            MyBase.OnPaint(e)
            G.Dispose()
            e.Graphics.InterpolationMode = 7
            e.Graphics.DrawImageUnscaled(B, 0, 0)
            B.Dispose()
        End Sub
    End Class
End NameSpace