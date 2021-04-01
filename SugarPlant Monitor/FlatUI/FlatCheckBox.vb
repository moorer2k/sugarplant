Imports System.ComponentModel

Namespace FlatUI
    <DefaultEvent("CheckedChanged")> Class FlatCheckBox : Inherits Control

#Region " Variables"

        Private W, H As Integer
        Private State As MouseState = MouseState.None
        Private O As _Options
        Private _Checked As Boolean

#End Region

#Region " Properties"
        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
            MyBase.OnTextChanged(e)
            Invalidate()
        End Sub

        Property Checked() As Boolean
            Get
                Return _Checked
            End Get
            Set(ByVal value As Boolean)
                _Checked = value
                Invalidate()
            End Set
        End Property

        Event CheckedChanged(ByVal sender As Object)
        Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
            _Checked = Not _Checked
            RaiseEvent CheckedChanged(Me)
            MyBase.OnClick(e)
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
        Public Property BorderColor As Color
            Get
                Return _BorderColor
            End Get
            Set(value As Color)
                _BorderColor = value
            End Set
        End Property

#End Region

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
            BackColor = Color.FromArgb(60, 70, 73)
            Cursor = Cursors.Hand
            Font = New Font("Segoe UI", 10)
            Size = New Size(112, 22)
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
            W = Width - 1 : H = Height - 1

            Dim Base As New Rectangle(0, 2, Height - 5, Height - 5)

            With G
                .SmoothingMode = 2
                .TextRenderingHint = 5
                .Clear(BackColor)
                Select Case O
                    Case _Options.Style1 '-- Style 1
                        '-- Base
                        .FillRectangle(New SolidBrush(_BaseColor), Base)

                        Select Case State
                            Case MouseState.Over
                                '-- Base
                                .DrawRectangle(New Pen(_BorderColor), Base)
                            Case MouseState.Down
                                '-- Base
                                .DrawRectangle(New Pen(_BorderColor), Base)
                        End Select

                        '-- If Checked
                        If Checked Then
                            .DrawString("ü", New Font("Wingdings", 18), New SolidBrush(_BorderColor), New Rectangle(5, 7, H - 9, H - 9), CenterSF)
                        End If

                        '-- If Enabled
                        If Me.Enabled = False Then
                            .FillRectangle(New SolidBrush(Color.FromArgb(54, 58, 61)), Base)
                            .DrawString(Text, Font, New SolidBrush(Color.FromArgb(140, 142, 143)), New Rectangle(20, 2, W, H), NearSF)
                        End If

                        '-- Text
                        .DrawString(Text, Font, New SolidBrush(_TextColor), New Rectangle(20, 2, W, H), NearSF)
                    Case _Options.Style2 '-- Style 2
                        '-- Base
                        .FillRectangle(New SolidBrush(_BaseColor), Base)

                        Select Case State
                            Case MouseState.Over
                                '-- Base
                                .DrawRectangle(New Pen(_BorderColor), Base)
                                .FillRectangle(New SolidBrush(Color.FromArgb(118, 213, 170)), Base)
                            Case MouseState.Down
                                '-- Base
                                .DrawRectangle(New Pen(_BorderColor), Base)
                                .FillRectangle(New SolidBrush(Color.FromArgb(118, 213, 170)), Base)
                        End Select

                        '-- If Checked
                        If Checked Then
                            .DrawString("ü", New Font("Wingdings", 18), New SolidBrush(_BorderColor), New Rectangle(5, 7, H - 9, H - 9), CenterSF)
                        End If

                        '-- If Enabled
                        If Me.Enabled = False Then
                            .FillRectangle(New SolidBrush(Color.FromArgb(54, 58, 61)), Base)
                            .DrawString(Text, Font, New SolidBrush(Color.FromArgb(48, 119, 91)), New Rectangle(20, 2, W, H), NearSF)
                        End If

                        '-- Text
                        .DrawString(Text, Font, New SolidBrush(_TextColor), New Rectangle(20, 2, W, H), NearSF)
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