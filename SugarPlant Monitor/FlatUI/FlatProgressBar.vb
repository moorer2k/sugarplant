Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Namespace FlatUI
    Class FlatProgressBar : Inherits Control

#Region " Variables"

        Private W, H As Integer
        Private _Value As Integer = 0
        Private _Maximum As Integer = 100

#End Region

#Region " Properties"

#Region " Control"

        <Category("Control")>
        Public Property Maximum() As Integer
            Get
                Return _Maximum
            End Get
            Set(V As Integer)
                Select Case V
                    Case Is < _Value
                        _Value = V
                End Select
                _Maximum = V
                Invalidate()
            End Set
        End Property

        <Category("Control")>
        Public Property Value() As Integer
            Get
                Select Case _Value
                    Case 0
                        Return 0
                        Invalidate()
                    Case Else
                        Return _Value
                        Invalidate()
                End Select
            End Get
            Set(V As Integer)
                Select Case V
                    Case Is > _Maximum
                        V = _Maximum
                        Invalidate()
                End Select
                _Value = V
                Invalidate()
            End Set
        End Property

#End Region

#Region " Colors"

        <Category("Colors")>
        Public Property ProgressColor As Color
            Get
                Return _ProgressColor
            End Get
            Set(value As Color)
                _ProgressColor = value
            End Set
        End Property

        <Category("Colors")>
        Public Property DarkerProgress As Color
            Get
                Return _DarkerProgress
            End Get
            Set(value As Color)
                _DarkerProgress = value
            End Set
        End Property

#End Region

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            Height = 42
        End Sub

        Protected Overrides Sub CreateHandle()
            MyBase.CreateHandle()
            Height = 42
        End Sub

        Public Sub Increment(ByVal Amount As Integer)
            Value += Amount
        End Sub

#End Region

#Region " Colors"

        Private _BaseColor As Color = Color.FromArgb(45, 47, 49)
        Private _ProgressColor As Color = _FlatColor
        Private _DarkerProgress As Color = Color.FromArgb(23, 148, 92)

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                     ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
            DoubleBuffered = True
            BackColor = Color.FromArgb(60, 70, 73)
            Height = 42
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
            W = Width - 1 : H = Height - 1

            Dim Base As New Rectangle(0, 24, W, H)
            Dim GP, GP2, GP3 As New GraphicsPath

            With G
                .SmoothingMode = 2
                .PixelOffsetMode = 2
                .TextRenderingHint = 5
                .Clear(BackColor)

                '-- Progress Value
                Dim iValue As Integer = CInt(_Value / _Maximum * Width)

                Select Case Value
                    Case 0
                        '-- Base
                        .FillRectangle(New SolidBrush(_BaseColor), Base)
                        '--Progress
                        .FillRectangle(New SolidBrush(_ProgressColor), New Rectangle(0, 24, iValue - 1, H - 1))
                    Case 100
                        '-- Base
                        .FillRectangle(New SolidBrush(_BaseColor), Base)
                        '--Progress
                        .FillRectangle(New SolidBrush(_ProgressColor), New Rectangle(0, 24, iValue - 1, H - 1))
                    Case Else
                        '-- Base
                        .FillRectangle(New SolidBrush(_BaseColor), Base)

                        '--Progress
                        GP.AddRectangle(New Rectangle(0, 24, iValue - 1, H - 1))
                        .FillPath(New SolidBrush(_ProgressColor), GP)

                        '-- Hatch Brush
                        Dim HB As New HatchBrush(HatchStyle.Plaid, _DarkerProgress, _ProgressColor)
                        .FillRectangle(HB, New Rectangle(0, 24, iValue - 1, H - 1))

                        '-- Balloon
                        Dim Balloon As New Rectangle(iValue - 18, 0, 34, 16)
                        GP2 = Helpers.RoundRec(Balloon, 4)
                        '.FillPath(New SolidBrush(_BaseColor), GP2)

                        '-- Arrow
                        GP3 = Helpers.DrawArrow(iValue - 9, 16, True)
                        '.FillPath(New SolidBrush(_BaseColor), GP3)

                        '-- Value > You can add "%" > value & "%"

                        '.DrawString(Value, New Font("Segoe UI", 10), New SolidBrush(_ProgressColor), New Rectangle(iValue - 11, -2, W, H), NearSF)
                End Select
            End With

            MyBase.OnPaint(e)
            G.Dispose()
            e.Graphics.InterpolationMode = 7
            e.Graphics.DrawImageUnscaled(B, 0, 0)
            B.Dispose()
        End Sub

    End Class
End NameSpace