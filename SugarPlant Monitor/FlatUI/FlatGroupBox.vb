Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Namespace FlatUI
    Class FlatGroupBox : Inherits ContainerControl

#Region " Variables"

        Private W, H As Integer
        Private _ShowText As Boolean = True

#End Region

#Region " Properties"

        <Category("Colors")> _
        Public Property BaseColor As Color
            Get
                Return _BaseColor
            End Get
            Set(value As Color)
                _BaseColor = value
            End Set
        End Property

        Public Property ShowText As Boolean
            Get
                Return _ShowText
            End Get
            Set(value As Boolean)
                _ShowText = value
            End Set
        End Property

#End Region

#Region " Colors"

        Private _BaseColor As Color = Color.FromArgb(60, 70, 73)

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                     ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                     ControlStyles.SupportsTransparentBackColor, True)
            DoubleBuffered = True
            BackColor = Color.Transparent
            Size = New Size(240, 180)
            Font = New Font("Segoe ui", 10)
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
            W = Width - 1 : H = Height - 1

            Dim GP, GP2, GP3 As New GraphicsPath
            Dim Base As New Rectangle(8, 8, W - 16, H - 16)

            With G
                .SmoothingMode = 2
                .PixelOffsetMode = 2
                .TextRenderingHint = 5
                .Clear(BackColor)

                '-- Base
                GP = Helpers.RoundRec(Base, 8)
                .FillPath(New SolidBrush(_BaseColor), GP)

                '-- Arrows
                GP2 = Helpers.DrawArrow(28, 2, False)
                .FillPath(New SolidBrush(_BaseColor), GP2)
                GP3 = Helpers.DrawArrow(28, 8, True)
                .FillPath(New SolidBrush(Color.FromArgb(60, 70, 73)), GP3)

                '-- if ShowText
                If ShowText Then
                    .DrawString(Text, Font, New SolidBrush(_FlatColor), New Rectangle(16, 16, W, H), NearSF)
                End If
            End With

            MyBase.OnPaint(e)
            G.Dispose()
            e.Graphics.InterpolationMode = 7
            e.Graphics.DrawImageUnscaled(B, 0, 0)
            B.Dispose()
        End Sub
    End Class
End NameSpace