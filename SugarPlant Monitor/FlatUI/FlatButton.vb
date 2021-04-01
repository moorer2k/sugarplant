Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Namespace FlatUI
    Class FlatButton : Inherits Control

#Region " Variables"

        Private W, H As Integer
        Private _Rounded As Boolean = False
        Private State As MouseState = MouseState.None

#End Region

#Region " Properties"

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

        <Category("Options")> _
        Public Property Rounded As Boolean
            Get
                Return _Rounded
            End Get
            Set(value As Boolean)
                _Rounded = value
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

        Private _BaseColor As Color = _FlatColor
        Private _TextColor As Color = Color.FromArgb(243, 243, 243)

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                     ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                     ControlStyles.SupportsTransparentBackColor, True)
            DoubleBuffered = True
            Size = New Size(106, 32)
            BackColor = Color.Transparent
            Font = New Font("Segoe UI", 12)
            Cursor = Cursors.Hand
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
            W = Width - 1 : H = Height - 1

            Dim GP As New GraphicsPath
            Dim Base As New Rectangle(0, 0, W, H)

            With G
                .SmoothingMode = 2
                .PixelOffsetMode = 2
                .TextRenderingHint = 5
                .Clear(BackColor)

                Select Case State
                    Case MouseState.None
                        If Rounded Then
                            '-- Base
                            GP = Helpers.RoundRec(Base, 6)
                            .FillPath(New SolidBrush(_BaseColor), GP)

                            '-- Text
                            .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                        Else
                            '-- Base
                            .FillRectangle(New SolidBrush(_BaseColor), Base)

                            '-- Text
                            .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                        End If
                    Case MouseState.Over
                        If Rounded Then
                            '-- Base
                            GP = Helpers.RoundRec(Base, 6)
                            .FillPath(New SolidBrush(_BaseColor), GP)
                            .FillPath(New SolidBrush(Color.FromArgb(20, Color.White)), GP)

                            '-- Text
                            .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                        Else
                            '-- Base
                            .FillRectangle(New SolidBrush(_BaseColor), Base)
                            .FillRectangle(New SolidBrush(Color.FromArgb(20, Color.White)), Base)

                            '-- Text
                            .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                        End If
                    Case MouseState.Down
                        If Rounded Then
                            '-- Base
                            GP = Helpers.RoundRec(Base, 6)
                            .FillPath(New SolidBrush(_BaseColor), GP)
                            .FillPath(New SolidBrush(Color.FromArgb(20, Color.Black)), GP)

                            '-- Text
                            .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                        Else
                            '-- Base
                            .FillRectangle(New SolidBrush(_BaseColor), Base)
                            .FillRectangle(New SolidBrush(Color.FromArgb(20, Color.Black)), Base)

                            '-- Text
                            .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                        End If
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