Imports System.ComponentModel

Namespace FlatUI
    Class FlatStatusBar : Inherits Control

#Region " Variables"

        Private W, H As Integer
        Private _ShowTimeDate As Boolean = False

#End Region

#Region " Properties"

        Protected Overrides Sub CreateHandle()
            MyBase.CreateHandle()
            Dock = DockStyle.Bottom
        End Sub

        Protected Overrides Sub OnTextChanged(e As EventArgs)
            MyBase.OnTextChanged(e) : Invalidate()
        End Sub

#Region " Colors"

        <Category("Colors")> _
        Public Property BaseColor As Color
            Get
                Return _BaseColor
            End Get
            Set(value As Color)
                _BaseColor = value
            End Set
        End Property

        <Category("Colors")> _
        Public Property TextColor As Color
            Get
                Return _TextColor
            End Get
            Set(value As Color)
                _TextColor = value
            End Set
        End Property

        <Category("Colors")> _
        Public Property RectColor As Color
            Get
                Return _RectColor
            End Get
            Set(value As Color)
                _RectColor = value
            End Set
        End Property

#End Region

        Public Property ShowTimeDate As Boolean
            Get
                Return _ShowTimeDate
            End Get
            Set(value As Boolean)
                _ShowTimeDate = value
            End Set
        End Property

        Function GetTimeDate() As String
            Return DateTime.Now.Date & " " & DateTime.Now.Hour & ":" & DateTime.Now.Minute
        End Function

#End Region

#Region " Colors"

        Private _BaseColor As Color = Color.FromArgb(45, 47, 49)
        Private _TextColor As Color = Color.White
        Private _RectColor As Color = _FlatColor

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                     ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
            DoubleBuffered = True
            Font = New Font("Segoe UI", 8)
            ForeColor = Color.White
            Size = New Size(Width, 20)
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
            W = Width : H = Height

            Dim Base As New Rectangle(0, 0, W, H)

            With G
                .SmoothingMode = 2
                .PixelOffsetMode = 2
                .TextRenderingHint = 5
                .Clear(BaseColor)

                '-- Base
                .FillRectangle(New SolidBrush(BaseColor), Base)

                '-- Text
                .DrawString(Text, Font, Brushes.White, New Rectangle(10, 4, W, H), NearSF)

                '-- Rectangle
                .FillRectangle(New SolidBrush(_RectColor), New Rectangle(4, 4, 4, 14))

                '-- TimeDate
                If ShowTimeDate Then
                    .DrawString(GetTimeDate, Font, New SolidBrush(_TextColor), New Rectangle(-4, 2, W, H), New StringFormat() _
                                   With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
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