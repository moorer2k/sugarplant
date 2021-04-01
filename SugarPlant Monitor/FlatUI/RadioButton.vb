Imports System.ComponentModel

Namespace FlatUI
    <DefaultEvent("CheckedChanged")> Class RadioButton : Inherits Control

#Region " Variables"

        Private State As MouseState = MouseState.None
        Private W, H As Integer
        Private O As _Options
        Private _Checked As Boolean

#End Region

#Region " Properties"
        Property Checked() As Boolean
            Get
                Return _Checked
            End Get
            Set(value As Boolean)
                _Checked = value
                InvalidateControls()
                RaiseEvent CheckedChanged(Me)
                Invalidate()
            End Set
        End Property
        Event CheckedChanged(ByVal sender As Object)
        Protected Overrides Sub OnClick(e As EventArgs)
            If Not _Checked Then Checked = True
            MyBase.OnClick(e)
        End Sub
        Private Sub InvalidateControls()
            If Not IsHandleCreated OrElse Not _Checked Then Return
            For Each C As Control In Parent.Controls
                If C IsNot Me AndAlso TypeOf C Is RadioButton Then
                    DirectCast(C, RadioButton).Checked = False
                    Invalidate()
                End If
            Next
        End Sub
        Protected Overrides Sub OnCreateControl()
            MyBase.OnCreateControl()
            InvalidateControls()
        End Sub

        <Flags> _
        Enum _Options
            Style1
            Style2
        End Enum

        <Category("Options")> _
        Public Property Options As _Options
            Get
                Return O
            End Get
            Set(value As _Options)
                O = value
            End Set
        End Property

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            Height = 22
        End Sub

#Region " Mouse States"

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            State = MouseState.Down : Invalidate()
        End Sub
        Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
            MyBase.OnMouseUp(e)
            State = MouseState.Over : Invalidate()
        End Sub
        Protected Overrides Sub OnMouseEnter(e As EventArgs)
            MyBase.OnMouseEnter(e)
            State = MouseState.Over : Invalidate()
        End Sub
        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            MyBase.OnMouseLeave(e)
            State = MouseState.None : Invalidate()
        End Sub

#End Region
#End Region

#Region " Colors"

        Private _BaseColor As Color = Color.FromArgb(45, 47, 49)
        Private _BorderColor As Color = _FlatColor
        Private _TextColor As Color = Color.FromArgb(243, 243, 243)

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                     ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
            DoubleBuffered = True
            Cursor = Cursors.Hand
            Size = New Size(100, 22)
            BackColor = Color.FromArgb(60, 70, 73)
            Font = New Font("Segoe UI", 10)
        End Sub
        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
            W = Width - 1 : H = Height - 1

            Dim Base As New Rectangle(0, 2, Height - 5, Height - 5), Dot As New Rectangle(4, 6, H - 12, H - 12)

            With G
                .SmoothingMode = 2
                .TextRenderingHint = 5
                .Clear(BackColor)

                Select Case O
                    Case _Options.Style1
                        '-- Base
                        .FillEllipse(New SolidBrush(_BaseColor), Base)

                        Select Case State
                            Case MouseState.Over
                                .DrawEllipse(New Pen(_BorderColor), Base)
                            Case MouseState.Down
                                .DrawEllipse(New Pen(_BorderColor), Base)
                        End Select

                        '-- If Checked 
                        If Checked Then
                            .FillEllipse(New SolidBrush(_BorderColor), Dot)
                        End If
                    Case _Options.Style2
                        '-- Base
                        .FillEllipse(New SolidBrush(_BaseColor), Base)

                        Select Case State
                            Case MouseState.Over
                                '-- Base
                                .DrawEllipse(New Pen(_BorderColor), Base)
                                .FillEllipse(New SolidBrush(Color.FromArgb(118, 213, 170)), Base)
                            Case MouseState.Down
                                '-- Base
                                .DrawEllipse(New Pen(_BorderColor), Base)
                                .FillEllipse(New SolidBrush(Color.FromArgb(118, 213, 170)), Base)
                        End Select

                        '-- If Checked
                        If Checked Then
                            '-- Base
                            .FillEllipse(New SolidBrush(_BorderColor), Dot)
                        End If
                End Select

                .DrawString(Text, Font, New SolidBrush(_TextColor), New Rectangle(20, 2, W, H), NearSF)
            End With

            MyBase.OnPaint(e)
            G.Dispose()
            e.Graphics.InterpolationMode = 7
            e.Graphics.DrawImageUnscaled(B, 0, 0)
            B.Dispose()
        End Sub
    End Class
End NameSpace