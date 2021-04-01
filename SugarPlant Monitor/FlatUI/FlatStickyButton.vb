Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Namespace FlatUI
    Class FlatStickyButton : Inherits Control

#Region " Variables"

        Private W, H As Integer
        Private State As MouseState = MouseState.None
        Private _Rounded As Boolean = False

#End Region

#Region " Properties"

#Region " MouseStates"

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

#Region " Function"

        Private Function GetConnectedSides() As Boolean()
            Dim Bool = New Boolean(3) {False, False, False, False}

            For Each B As Control In Parent.Controls
                If TypeOf B Is FlatStickyButton Then
                    If B Is Me Or Not Rect.IntersectsWith(Rect) Then Continue For
                    Dim A = Math.Atan2(Left() - B.Left, Top - B.Top) * 2 / Math.PI
                    If A \ 1 = A Then Bool(A + 1) = True
                End If
            Next

            Return Bool
        End Function

        Private ReadOnly Property Rect() As Rectangle
            Get
                Return New Rectangle(Left, Top, Width, Height)
            End Get
        End Property

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

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            'Height = 32
        End Sub

        Protected Overrides Sub OnCreateControl()
            MyBase.OnCreateControl()
            'Size = New Size(112, 32)
        End Sub

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
            W = Width : H = Height

            Dim GP As New GraphicsPath

            Dim GCS = GetConnectedSides()
            Dim RoundedBase = Helpers.RoundRect(0, 0, W, H, , Not (GCS(2) Or GCS(1)), Not (GCS(1) Or GCS(0)), Not (GCS(3) Or GCS(0)), Not (GCS(3) Or GCS(2)))
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
                            GP = RoundedBase
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
                            GP = RoundedBase
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
                            GP = RoundedBase
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