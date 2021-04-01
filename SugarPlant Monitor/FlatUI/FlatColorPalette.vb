Imports System.ComponentModel

Namespace FlatUI
    Class FlatColorPalette : Inherits Control

#Region " Variables"

        Private W, H As Integer

#End Region

#Region " Properties"

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            Width = 180
            Height = 80
        End Sub

#Region " Colors"

        <Category("Colors")> _
        Public Property Red As Color
            Get
                Return _Red
            End Get
            Set(value As Color)
                _Red = value
            End Set
        End Property

        <Category("Colors")> _
        Public Property Cyan As Color
            Get
                Return _Cyan
            End Get
            Set(value As Color)
                _Cyan = value
            End Set
        End Property

        <Category("Colors")> _
        Public Property Blue As Color
            Get
                Return _Blue
            End Get
            Set(value As Color)
                _Blue = value
            End Set
        End Property

        <Category("Colors")> _
        Public Property LimeGreen As Color
            Get
                Return _LimeGreen
            End Get
            Set(value As Color)
                _LimeGreen = value
            End Set
        End Property

        <Category("Colors")> _
        Public Property Orange As Color
            Get
                Return _Orange
            End Get
            Set(value As Color)
                _Orange = value
            End Set
        End Property

        <Category("Colors")> _
        Public Property Purple As Color
            Get
                Return _Purple
            End Get
            Set(value As Color)
                _Purple = value
            End Set
        End Property

        <Category("Colors")> _
        Public Property Black As Color
            Get
                Return _Black
            End Get
            Set(value As Color)
                _Black = value
            End Set
        End Property

        <Category("Colors")> _
        Public Property Gray As Color
            Get
                Return _Gray
            End Get
            Set(value As Color)
                _Gray = value
            End Set
        End Property

        <Category("Colors")> _
        Public Property White As Color
            Get
                Return _White
            End Get
            Set(value As Color)
                _White = value
            End Set
        End Property

#End Region

#End Region

#Region " Colors"

        Private _Red As Color = Color.FromArgb(220, 85, 96)
        Private _Cyan As Color = Color.FromArgb(10, 154, 157)
        Private _Blue As Color = Color.FromArgb(0, 128, 255)
        Private _LimeGreen As Color = Color.FromArgb(35, 168, 109)
        Private _Orange As Color = Color.FromArgb(253, 181, 63)
        Private _Purple As Color = Color.FromArgb(155, 88, 181)
        Private _Black As Color = Color.FromArgb(45, 47, 49)
        Private _Gray As Color = Color.FromArgb(63, 70, 73)
        Private _White As Color = Color.FromArgb(243, 243, 243)

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                     ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
            DoubleBuffered = True
            BackColor = Color.FromArgb(60, 70, 73)
            Size = New Size(160, 80)
            Font = New Font("Segoe UI", 12)
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
            W = Width - 1 : H = Height - 1

            With G
                .SmoothingMode = 2
                .PixelOffsetMode = 2
                .TextRenderingHint = 5
                .Clear(BackColor)

                '-- Colors 
                .FillRectangle(New SolidBrush(_Red), New Rectangle(0, 0, 20, 40))
                .FillRectangle(New SolidBrush(_Cyan), New Rectangle(20, 0, 20, 40))
                .FillRectangle(New SolidBrush(_Blue), New Rectangle(40, 0, 20, 40))
                .FillRectangle(New SolidBrush(_LimeGreen), New Rectangle(60, 0, 20, 40))
                .FillRectangle(New SolidBrush(_Orange), New Rectangle(80, 0, 20, 40))
                .FillRectangle(New SolidBrush(_Purple), New Rectangle(100, 0, 20, 40))
                .FillRectangle(New SolidBrush(_Black), New Rectangle(120, 0, 20, 40))
                .FillRectangle(New SolidBrush(_Gray), New Rectangle(140, 0, 20, 40))
                .FillRectangle(New SolidBrush(_White), New Rectangle(160, 0, 20, 40))

                '-- Text
                .DrawString("Color Palette", Font, New SolidBrush(_White), New Rectangle(0, 22, W, H), CenterSF)
            End With

            MyBase.OnPaint(e)
            G.Dispose()
            e.Graphics.InterpolationMode = 7
            e.Graphics.DrawImageUnscaled(B, 0, 0)
            B.Dispose()
        End Sub
    End Class
End NameSpace