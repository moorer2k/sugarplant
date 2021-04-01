Imports System.ComponentModel

Namespace FlatUI
    <DefaultEvent("TextChanged")> Class FlatTextBox : Inherits Control

#Region " Variables"

        Private W, H As Integer
        Private State As MouseState = MouseState.None
        Private WithEvents TB As Windows.Forms.TextBox

#End Region

#Region " Properties"

#Region " TextBox Properties"

        Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
        <Category("Options")>
        Property TextAlign() As HorizontalAlignment
            Get
                Return _TextAlign
            End Get
            Set(ByVal value As HorizontalAlignment)
                _TextAlign = value
                If TB IsNot Nothing Then
                    TB.TextAlign = value
                End If
            End Set
        End Property
        Private _MaxLength As Integer = 32767
        <Category("Options")>
        Property MaxLength() As Integer
            Get
                Return _MaxLength
            End Get
            Set(ByVal value As Integer)
                _MaxLength = value
                If TB IsNot Nothing Then
                    TB.MaxLength = value
                End If
            End Set
        End Property
        Private _ReadOnly As Boolean
        <Category("Options")>
        Property [ReadOnly]() As Boolean
            Get
                Return _ReadOnly
            End Get
            Set(ByVal value As Boolean)
                _ReadOnly = value
                If TB IsNot Nothing Then
                    TB.ReadOnly = value
                End If
            End Set
        End Property
        Private _UseSystemPasswordChar As Boolean
        <Category("Options")>
        Property UseSystemPasswordChar() As Boolean
            Get
                Return _UseSystemPasswordChar
            End Get
            Set(ByVal value As Boolean)
                _UseSystemPasswordChar = value
                If TB IsNot Nothing Then
                    TB.UseSystemPasswordChar = value
                End If
            End Set
        End Property
        Private _Multiline As Boolean
        <Category("Options")>
        Property Multiline() As Boolean
            Get
                Return _Multiline
            End Get
            Set(ByVal value As Boolean)
                _Multiline = value
                If TB IsNot Nothing Then
                    TB.Multiline = value

                    If value Then
                        TB.Height = Height - 11
                    Else
                        Height = TB.Height + 11
                    End If

                End If
            End Set
        End Property
        <Category("Options")>
        Overrides Property Text As String
            Get
                Return MyBase.Text
            End Get
            Set(ByVal value As String)
                MyBase.Text = value
                If TB IsNot Nothing Then
                    TB.Text = value
                End If
            End Set
        End Property
        <Category("Options")>
        Overrides Property Font As Font
            Get
                Return MyBase.Font
            End Get
            Set(ByVal value As Font)
                MyBase.Font = value
                If TB IsNot Nothing Then
                    TB.Font = value
                    TB.Location = New Point(3, 5)
                    TB.Width = Width - 6

                    If Not _Multiline Then
                        Height = TB.Height + 11
                    End If
                End If
            End Set
        End Property

        Protected Overrides Sub OnCreateControl()
            MyBase.OnCreateControl()
            If Not Controls.Contains(TB) Then
                Controls.Add(TB)
            End If
        End Sub
        Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
            Text = TB.Text
        End Sub
        Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
            If e.Control AndAlso e.KeyCode = Keys.A Then
                TB.SelectAll()
                e.SuppressKeyPress = True
            End If
            If e.Control AndAlso e.KeyCode = Keys.C Then
                TB.Copy()
                e.SuppressKeyPress = True
            End If
        End Sub
        Protected Overrides Sub OnResize(ByVal e As EventArgs)
            TB.Location = New Point(5, 5)
            TB.Width = Width - 10

            If _Multiline Then
                TB.Height = Height - 11
            Else
                Height = TB.Height + 11
            End If

            MyBase.OnResize(e)
        End Sub

#End Region

#Region " Colors"

        <Category("Colors")>
        Public Property TextColor As Color
            Get
                Return _TextColor
            End Get
            Set(value As Color)
                _TextColor = value
            End Set
        End Property

        Public Overrides Property ForeColor() As Color
            Get
                Return _TextColor
            End Get
            Set(value As Color)
                _TextColor = value
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
            State = MouseState.Over : TB.Focus() : Invalidate()
        End Sub
        Protected Overrides Sub OnMouseEnter(e As EventArgs)
            MyBase.OnMouseEnter(e)
            State = MouseState.Over : TB.Focus() : Invalidate()
        End Sub
        Protected Overrides Sub OnMouseLeave(e As EventArgs)
            MyBase.OnMouseLeave(e)
            State = MouseState.None : Invalidate()
        End Sub

#End Region

#End Region

#Region " Colors"

        Private _BaseColor As Color = Color.FromArgb(45, 47, 49)
        Private _TextColor As Color = Color.FromArgb(192, 192, 192)
        Private _BorderColor As Color = _FlatColor

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or
                     ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or
                     ControlStyles.SupportsTransparentBackColor, True)
            DoubleBuffered = True

            BackColor = Color.Transparent

            TB = New Windows.Forms.TextBox With {
                .Font = New Font("Segoe UI", 10),
                .Text = Text,
                .BackColor = _BaseColor,
                .ForeColor = _TextColor,
                .MaxLength = _MaxLength,
                .Multiline = _Multiline,
                .ReadOnly = _ReadOnly,
                .UseSystemPasswordChar = _UseSystemPasswordChar,
                .BorderStyle = BorderStyle.None,
                .Location = New Point(5, 5),
                .Width = Width - 10,
                .Cursor = Cursors.IBeam
            }

            If _Multiline Then
                TB.Height = Height - 11
            Else
                Height = TB.Height + 11
            End If

            AddHandler TB.TextChanged, AddressOf OnBaseTextChanged
            AddHandler TB.KeyDown, AddressOf OnBaseKeyDown
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
            W = Width - 1 : H = Height - 1

            Dim Base As New Rectangle(0, 0, W, H)

            With G
                .SmoothingMode = 2
                .PixelOffsetMode = 2
                .TextRenderingHint = 5
                .Clear(BackColor)

                '-- Colors
                TB.BackColor = _BaseColor
                TB.ForeColor = _TextColor

                '-- Base
                .FillRectangle(New SolidBrush(_BaseColor), Base)
            End With

            MyBase.OnPaint(e)
            G.Dispose()
            e.Graphics.InterpolationMode = 7
            e.Graphics.DrawImageUnscaled(B, 0, 0)
            B.Dispose()
        End Sub

    End Class
End Namespace