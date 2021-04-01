Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Namespace FlatUI
    <DefaultEvent("Scroll")> Class FlatTrackBar : Inherits Control

#Region " Variables"

        Private W, H As Integer
        Private Val As Integer
        Private Bool As Boolean
        Private Track As Rectangle
        Private Knob As Rectangle
        Private Style_ As _Style

#End Region

#Region " Properties"

#Region " Mouse States"

        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            If e.Button = Windows.Forms.MouseButtons.Left Then
                Val = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 11))
                Track = New Rectangle(Val, 0, 10, 20)

                Bool = Track.Contains(e.Location)
            End If
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            MyBase.OnMouseMove(e)
            If Bool AndAlso e.X > -1 AndAlso e.X < (Width + 1) Then
                Value = _Minimum + CInt((_Maximum - _Minimum) * (e.X / Width))
            End If
        End Sub

        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            MyBase.OnMouseUp(e) : Bool = False
        End Sub

#End Region

#Region " Styles"

        <Flags> _
        Enum _Style
            Slider
            Knob
        End Enum

        Public Property Style As _Style
            Get
                Return Style_
            End Get
            Set(value As _Style)
                Style_ = value
            End Set
        End Property

#End Region

#Region " Colors"

        <Category("Colors")> _
        Public Property TrackColor As Color
            Get
                Return _TrackColor
            End Get
            Set(value As Color)
                _TrackColor = value
            End Set
        End Property

        <Category("Colors")> _
        Public Property HatchColor As Color
            Get
                Return _HatchColor
            End Get
            Set(value As Color)
                _HatchColor = value
            End Set
        End Property

#End Region

        Event Scroll(ByVal sender As Object)
        Private _Minimum As Integer
        Public Property Minimum As Integer
            Get
                Return Minimum
            End Get
            Set(value As Integer)
                If value < 0 Then
                End If

                _Minimum = value

                If value > _Value Then _Value = value
                If value > _Maximum Then _Maximum = value
                Invalidate()
            End Set
        End Property
        Private _Maximum As Integer = 10
        Public Property Maximum As Integer
            Get
                Return _Maximum
            End Get
            Set(value As Integer)
                If value < 0 Then
                End If

                _Maximum = value
                If value < _Value Then _Value = value
                If value < _Minimum Then _Minimum = value
                Invalidate()
            End Set
        End Property
        Private _Value As Integer
        Public Property Value As Integer
            Get
                Return _Value
            End Get
            Set(value As Integer)
                If value = _Value Then Return

                If value > _Maximum OrElse value < _Minimum Then
                End If

                _Value = value
                Invalidate()
                RaiseEvent Scroll(Me)
            End Set
        End Property
        Private _ShowValue As Boolean = False
        Public Property ShowValue As Boolean
            Get
                Return _ShowValue
            End Get
            Set(value As Boolean)
                _ShowValue = value
            End Set
        End Property

        Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
            MyBase.OnKeyDown(e)
            If e.KeyCode = Keys.Subtract Then
                If Value = 0 Then Exit Sub
                Value -= 1
            ElseIf e.KeyCode = Keys.Add Then
                If Value = _Maximum Then Exit Sub
                Value += 1
            End If
        End Sub

        Protected Overrides Sub OnTextChanged(e As EventArgs)
            MyBase.OnTextChanged(e) : Invalidate()
        End Sub

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            Height = 23
        End Sub

#End Region

#Region " Colors"

        Private BaseColor As Color = Color.FromArgb(45, 47, 49)
        Private _TrackColor As Color = _FlatColor
        Private SliderColor As Color = Color.FromArgb(25, 27, 29)
        Private _HatchColor As Color = Color.FromArgb(23, 148, 92)

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                     ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
            DoubleBuffered = True
            Height = 18

            BackColor = Color.FromArgb(60, 70, 73)
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
            W = Width - 1 : H = Height - 1

            Dim Base As New Rectangle(1, 6, W - 2, 8)
            Dim GP, GP2 As New GraphicsPath

            With G
                .SmoothingMode = 2
                .PixelOffsetMode = 2
                .TextRenderingHint = 5
                .Clear(BackColor)

                '-- Value
                Val = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (W - 10))
                Track = New Rectangle(Val, 0, 10, 20)
                Knob = New Rectangle(Val, 4, 11, 14)

                '-- Base
                GP.AddRectangle(Base)
                .SetClip(GP)
                .FillRectangle(New SolidBrush(BaseColor), New Rectangle(0, 7, W, 8))
                .FillRectangle(New SolidBrush(_TrackColor), New Rectangle(0, 7, Track.X + Track.Width, 8))
                .ResetClip()

                '-- Hatch Brush
                Dim HB As New HatchBrush(HatchStyle.Plaid, HatchColor, _TrackColor)
                .FillRectangle(HB, New Rectangle(-10, 7, Track.X + Track.Width, 8))

                '-- Slider/Knob
                Select Case Style
                    Case _Style.Slider
                        GP2.AddRectangle(Track)
                        .FillPath(New SolidBrush(SliderColor), GP2)
                    Case _Style.Knob
                        GP2.AddEllipse(Knob)
                        .FillPath(New SolidBrush(SliderColor), GP2)
                End Select

                '-- Show the value 
                If ShowValue Then
                    .DrawString(Value, New Font("Segoe UI", 8), Brushes.White, New Rectangle(1, 6, W, H), New StringFormat() _
                                   With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Far})
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