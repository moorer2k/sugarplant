Imports System.ComponentModel

Namespace FlatUI
    Class FlatMax : Inherits Control

#Region " Variables"

        Private State As MouseState = MouseState.None
        Private x As Integer

#End Region

#Region " Properties"

#Region " Mouse States"

        Protected Overrides Sub OnMouseEnter(e As EventArgs)
            MyBase.OnMouseEnter(e)
            State = MouseState.Over : Invalidate()
        End Sub
        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)
            State = MouseState.Down : Invalidate()
        End Sub
        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            MyBase.OnMouseLeave(e)
            State = MouseState.None : Invalidate()
        End Sub
        Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
            MyBase.OnMouseUp(e)
            State = MouseState.Over : Invalidate()
        End Sub
        Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
            MyBase.OnMouseMove(e)
            x = e.X : Invalidate()
        End Sub

        Protected Overrides Sub OnClick(e As EventArgs)
            MyBase.OnClick(e)
            Select Case FindForm.WindowState
                Case FormWindowState.Maximized
                    FindForm.WindowState = FormWindowState.Normal
                Case FormWindowState.Normal
                    FindForm.WindowState = FormWindowState.Maximized
            End Select
        End Sub

#End Region

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

#End Region

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            Size = New Size(18, 18)
        End Sub

#End Region

#Region " Colors"

        Private _BaseColor As Color = Color.FromArgb(45, 47, 49)
        Private _TextColor As Color = Color.FromArgb(243, 243, 243)

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                     ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
            DoubleBuffered = True
            BackColor = Color.White
            Size = New Size(18, 18)
            Anchor = AnchorStyles.Top Or AnchorStyles.Right
            Font = New Font("Marlett", 12)
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim B As New Bitmap(Width, Height)
            Dim G As Graphics = Graphics.FromImage(B)

            Dim Base As New Rectangle(0, 0, Width, Height)

            With G
                .SmoothingMode = 2
                .PixelOffsetMode = 2
                .TextRenderingHint = 5
                .Clear(BackColor)

                '-- Base
                .FillRectangle(New SolidBrush(_BaseColor), Base)

                '-- Maximize
                If FindForm.WindowState = FormWindowState.Maximized Then
                    .DrawString("1", Font, New SolidBrush(TextColor), New Rectangle(1, 1, Width, Height), CenterSF)
                ElseIf FindForm.WindowState = FormWindowState.Normal Then
                    .DrawString("2", Font, New SolidBrush(TextColor), New Rectangle(1, 1, Width, Height), CenterSF)
                End If

                '-- Hover/down
                Select Case State
                    Case MouseState.Over
                        .FillRectangle(New SolidBrush(Color.FromArgb(30, Color.White)), Base)
                    Case MouseState.Down
                        .FillRectangle(New SolidBrush(Color.FromArgb(30, Color.Black)), Base)
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