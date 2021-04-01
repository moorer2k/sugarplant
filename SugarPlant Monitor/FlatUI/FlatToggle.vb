Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Namespace FlatUI
    <DefaultEvent("CheckedChanged")> Class FlatToggle : Inherits Control

#Region " Variables"

        Private W, H As Integer
        Private O As _Options
        Private _Checked As Boolean = False
        Private State As MouseState = MouseState.None

#End Region

#Region " Properties"
        Public Event CheckedChanged(ByVal sender As Object)

        <Flags()> _
        Enum _Options
            Style1
            Style2
            Style3
            Style4 '-- TODO: New Style
            Style5 '-- TODO: New Style
        End Enum

#Region " Options"

        <Category("Options")> _
        Public Property Options As _Options
            Get
                Return O
            End Get
            Set(value As _Options)
                O = value
            End Set
        End Property

        <Category("Options")> _
        Public Property Checked As Boolean
            Get
                Return _Checked
            End Get
            Set(value As Boolean)
                _Checked = value
            End Set
        End Property

#End Region

        Protected Overrides Sub OnTextChanged(e As EventArgs)
            MyBase.OnTextChanged(e) : Invalidate()
        End Sub

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            Width = 76
            Height = 33
        End Sub

#Region " Mouse States"

        Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
            MyBase.OnMouseEnter(e)
            State = MouseState.Over : Invalidate()
        End Sub
        Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseDown(e)
            State = MouseState.Down : Invalidate()
        End Sub
        Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
            MyBase.OnMouseLeave(e)
            State = MouseState.None : Invalidate()
        End Sub
        Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
            MyBase.OnMouseUp(e)
            State = MouseState.Over : Invalidate()
        End Sub
        Protected Overrides Sub OnClick(e As EventArgs)
            MyBase.OnClick(e)
            _Checked = Not _Checked
            RaiseEvent CheckedChanged(Me)
        End Sub

#End Region

#End Region

#Region " Colors"

        Private BaseColor As Color = _FlatColor
        Private BaseColorRed As Color = Color.FromArgb(220, 85, 96)
        Private BGColor As Color = Color.FromArgb(84, 85, 86)
        Private ToggleColor As Color = Color.FromArgb(45, 47, 49)
        Private TextColor As Color = Color.FromArgb(243, 243, 243)

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                     ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                     ControlStyles.SupportsTransparentBackColor, True)
            DoubleBuffered = True
            BackColor = Color.Transparent
            Size = New Size(44, Height + 1)
            Cursor = Cursors.Hand
            Font = New Font("Segoe UI", 10)
            Size = New Size(76, 33)
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
            W = Width - 1 : H = Height - 1

            Dim GP, GP2 As New GraphicsPath
            Dim Base As New Rectangle(0, 0, W, H), Toggle As New Rectangle(CInt(W \ 2), 0, 38, H)

            With G
                .SmoothingMode = 2
                .PixelOffsetMode = 2
                .TextRenderingHint = 5
                .Clear(BackColor)

                Select Case O
                    Case _Options.Style1   '-- Style 1
                        '-- Base
                        GP = Helpers.RoundRec(Base, 6)
                        GP2 = Helpers.RoundRec(Toggle, 6)
                        .FillPath(New SolidBrush(BGColor), GP)
                        .FillPath(New SolidBrush(ToggleColor), GP2)

                        '-- Text
                        .DrawString("OFF", Font, New SolidBrush(BGColor), New Rectangle(19, 1, W, H), CenterSF)

                        If Checked Then
                            '-- Base
                            GP = Helpers.RoundRec(Base, 6)
                            GP2 = Helpers.RoundRec(New Rectangle(CInt(W \ 2), 0, 38, H), 6)
                            .FillPath(New SolidBrush(ToggleColor), GP)
                            .FillPath(New SolidBrush(BaseColor), GP2)

                            '-- Text
                            .DrawString("ON", Font, New SolidBrush(BaseColor), New Rectangle(8, 7, W, H), NearSF)
                        End If
                    Case _Options.Style2   '-- Style 2
                        '-- Base
                        GP = Helpers.RoundRec(Base, 6)
                        Toggle = New Rectangle(4, 4, 36, H - 8)
                        GP2 = Helpers.RoundRec(Toggle, 4)
                        .FillPath(New SolidBrush(BaseColorRed), GP)
                        .FillPath(New SolidBrush(ToggleColor), GP2)

                        '-- Lines
                        .DrawLine(New Pen(BGColor), 18, 20, 18, 12)
                        .DrawLine(New Pen(BGColor), 22, 20, 22, 12)
                        .DrawLine(New Pen(BGColor), 26, 20, 26, 12)

                        '-- Text
                        .DrawString("r", New Font("Marlett", 8), New SolidBrush(TextColor), New Rectangle(19, 2, Width, Height), CenterSF)

                        If Checked Then
                            GP = Helpers.RoundRec(Base, 6)
                            Toggle = New Rectangle(CInt(W \ 2) - 2, 4, 36, H - 8)
                            GP2 = Helpers.RoundRec(Toggle, 4)
                            .FillPath(New SolidBrush(BaseColor), GP)
                            .FillPath(New SolidBrush(ToggleColor), GP2)

                            '-- Lines
                            .DrawLine(New Pen(BGColor), CInt(W \ 2) + 12, 20, CInt(W \ 2) + 12, 12)
                            .DrawLine(New Pen(BGColor), CInt(W \ 2) + 16, 20, CInt(W \ 2) + 16, 12)
                            .DrawLine(New Pen(BGColor), CInt(W \ 2) + 20, 20, CInt(W \ 2) + 20, 12)

                            '-- Text
                            .DrawString("ü", New Font("Wingdings", 14), New SolidBrush(TextColor), New Rectangle(8, 7, Width, Height), NearSF)
                        End If
                    Case _Options.Style3   '-- Style 3
                        '-- Base
                        GP = Helpers.RoundRec(Base, 16)
                        Toggle = New Rectangle(W - 28, 4, 22, H - 8)
                        GP2.AddEllipse(Toggle)
                        .FillPath(New SolidBrush(ToggleColor), GP)
                        .FillPath(New SolidBrush(BaseColorRed), GP2)

                        '-- Text
                        .DrawString("OFF", Font, New SolidBrush(BaseColorRed), New Rectangle(-12, 2, W, H), CenterSF)

                        If Checked Then
                            '-- Base
                            GP = Helpers.RoundRec(Base, 16)
                            Toggle = New Rectangle(6, 4, 22, H - 8)
                            GP2.Reset()
                            GP2.AddEllipse(Toggle)
                            .FillPath(New SolidBrush(ToggleColor), GP)
                            .FillPath(New SolidBrush(BaseColor), GP2)

                            '-- Text
                            .DrawString("ON", Font, New SolidBrush(BaseColor), New Rectangle(12, 2, W, H), CenterSF)
                        End If
                    Case _Options.Style4
                        '-- TODO: New Styles
                        If Checked Then
                            '--
                        End If
                    Case _Options.Style5
                        '-- TODO: New Styles
                        If Checked Then
                            '--
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