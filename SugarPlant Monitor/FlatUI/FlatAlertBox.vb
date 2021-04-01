Imports System.ComponentModel

Namespace FlatUI
    Class FlatAlertBox : Inherits Control

        ''' <summary>
        ''' How to use: FlatAlertBox.ShowControl(Kind, String, Interval)
        ''' </summary>
        ''' <remarks></remarks>

#Region " Variables"

        Private W, H As Integer
        Private K As _Kind
        Private _Text As String
        Private State As MouseState = MouseState.None
        Private X As Integer
        Private WithEvents T As Timer

#End Region

#Region " Properties"

        <Flags()>
        Enum _Kind
            [Success]
            [Error]
            [Info]
        End Enum

#Region " Options"

        <Category("Options")>
        Public Property Kind As _Kind
            Get
                Return K
            End Get
            Set(value As _Kind)
                K = value
            End Set
        End Property

        <Category("Options")>
        Overrides Property Text As String
            Get
                Return MyBase.Text
            End Get
            Set(ByVal value As String)
                MyBase.Text = value
                If _Text IsNot Nothing Then
                    _Text = value
                End If
            End Set
        End Property

        <Category("Options")>
        Shadows Property Visible As Boolean
            Get
                Return MyBase.Visible = False
            End Get
            Set(value As Boolean)
                MyBase.Visible = value
            End Set
        End Property

#End Region

        Protected Overrides Sub OnTextChanged(e As EventArgs)
            MyBase.OnTextChanged(e) : Invalidate()
        End Sub

        Protected Overrides Sub OnResize(e As EventArgs)
            MyBase.OnResize(e)
            Height = 42
        End Sub

        Public Sub ShowControl(Kind As _Kind, Str As String, Interval As Integer)
            K = Kind
            Text = Str
            Me.Visible = True
            T = New Timer With {
                .Interval = Interval,
                .Enabled = True
            }
        End Sub

        Private Sub T_Tick(sender As Object, e As EventArgs) Handles T.Tick
            Me.Visible = False
            T.Enabled = False
            T.Dispose()
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

        Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
            MyBase.OnMouseMove(e)
            X = e.X : Invalidate()
        End Sub

        Protected Overrides Sub OnClick(e As EventArgs)
            MyBase.OnClick(e)
            Me.Visible = False
        End Sub

#End Region

#End Region

#Region " Colors"

        Private SuccessColor As Color = Color.FromArgb(60, 85, 79)
        Private SuccessText As Color = Color.FromArgb(35, 169, 110)
        Private ErrorColor As Color = Color.FromArgb(87, 71, 71)
        Private ErrorText As Color = Color.FromArgb(254, 142, 122)
        Private InfoColor As Color = Color.FromArgb(70, 91, 94)
        Private InfoText As Color = Color.FromArgb(97, 185, 186)

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
                     ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
            DoubleBuffered = True
            BackColor = Color.FromArgb(60, 70, 73)
            Size = New Size(576, 42)
            Location = New Point(10, 61)
            Font = New Font("Segoe UI", 10)
            Cursor = Cursors.Hand
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
            W = Width - 1 : H = Height - 1

            Dim Base As New Rectangle(0, 0, W, H)

            With G
                .SmoothingMode = 2
                .TextRenderingHint = 5
                .Clear(BackColor)

                Select Case K
                    Case _Kind.Success
                        '-- Base
                        .FillRectangle(New SolidBrush(SuccessColor), Base)

                        '-- Ellipse
                        .FillEllipse(New SolidBrush(SuccessText), New Rectangle(8, 9, 24, 24))
                        .FillEllipse(New SolidBrush(SuccessColor), New Rectangle(10, 11, 20, 20))

                        '-- Checked Sign
                        .DrawString("ü", New Font("Wingdings", 22), New SolidBrush(SuccessText), New Rectangle(7, 7, W, H), NearSF)
                        .DrawString(Text, Font, New SolidBrush(SuccessText), New Rectangle(48, 12, W, H), NearSF)

                        '-- X button
                        .FillEllipse(New SolidBrush(Color.FromArgb(35, Color.Black)), New Rectangle(W - 30, H - 29, 17, 17))
                        .DrawString("r", New Font("Marlett", 8), New SolidBrush(SuccessColor), New Rectangle(W - 28, 16, W, H), NearSF)

                        Select Case State ' -- Mouse Over
                            Case MouseState.Over
                                .DrawString("r", New Font("Marlett", 8), New SolidBrush(Color.FromArgb(25, Color.White)), New Rectangle(W - 28, 16, W, H), NearSF)
                        End Select

                    Case _Kind.Error
                        '-- Base
                        .FillRectangle(New SolidBrush(ErrorColor), Base)

                        '-- Ellipse
                        .FillEllipse(New SolidBrush(ErrorText), New Rectangle(8, 9, 24, 24))
                        .FillEllipse(New SolidBrush(ErrorColor), New Rectangle(10, 11, 20, 20))

                        '-- X Sign
                        .DrawString("r", New Font("Marlett", 16), New SolidBrush(ErrorText), New Rectangle(6, 11, W, H), NearSF)
                        .DrawString(Text, Font, New SolidBrush(ErrorText), New Rectangle(48, 12, W, H), NearSF)

                        '-- X button
                        .FillEllipse(New SolidBrush(Color.FromArgb(35, Color.Black)), New Rectangle(W - 32, H - 29, 17, 17))
                        .DrawString("r", New Font("Marlett", 8), New SolidBrush(ErrorColor), New Rectangle(W - 30, 17, W, H), NearSF)

                        Select Case State
                            Case MouseState.Over ' -- Mouse Over
                                .DrawString("r", New Font("Marlett", 8), New SolidBrush(Color.FromArgb(25, Color.White)), New Rectangle(W - 30, 15, W, H), NearSF)
                        End Select

                    Case _Kind.Info
                        '-- Base
                        .FillRectangle(New SolidBrush(InfoColor), Base)

                        '-- Ellipse
                        .FillEllipse(New SolidBrush(InfoText), New Rectangle(8, 9, 24, 24))
                        .FillEllipse(New SolidBrush(InfoColor), New Rectangle(10, 11, 20, 20))

                        '-- Info Sign
                        .DrawString("¡", New Font("Segoe UI", 20, FontStyle.Bold), New SolidBrush(InfoText), New Rectangle(12, -4, W, H), NearSF)
                        .DrawString(Text, Font, New SolidBrush(InfoText), New Rectangle(48, 12, W, H), NearSF)

                        '-- X button
                        .FillEllipse(New SolidBrush(Color.FromArgb(35, Color.Black)), New Rectangle(W - 32, H - 29, 17, 17))
                        .DrawString("r", New Font("Marlett", 8), New SolidBrush(InfoColor), New Rectangle(W - 30, 17, W, H), NearSF)

                        Select Case State
                            Case MouseState.Over ' -- Mouse Over
                                .DrawString("r", New Font("Marlett", 8), New SolidBrush(Color.FromArgb(25, Color.White)), New Rectangle(W - 30, 17, W, H), NearSF)
                        End Select
                End Select

            End With

            MyBase.OnPaint(e)
            G.Dispose()
            e.Graphics.InterpolationMode = 7
            e.Graphics.DrawImageUnscaled(B, 0, 0)
            B.Dispose()
        End Sub

    End Class
End Namespace