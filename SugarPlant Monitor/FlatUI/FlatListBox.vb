Imports System.ComponentModel

Namespace FlatUI
    Class FlatListBox : Inherits Control

#Region " Variables"

        Private WithEvents ListBx As New ListBox
        Private _items As String() = {""}

#End Region

#Region " Poperties"

        <Category("Options")> _
        Public Property items As String()
            Get
                Return _items
            End Get
            Set(value As String())
                _items = value
                ListBx.Items.Clear()
                ListBx.Items.AddRange(value)
                Invalidate()
            End Set
        End Property

        <Category("Colors")> _
        Public Property SelectedColor As Color
            Get
                Return _SelectedColor
            End Get
            Set(value As Color)
                _SelectedColor = value
            End Set
        End Property

        Public ReadOnly Property SelectedItem() As String
            Get
                Return ListBx.SelectedItem
            End Get
        End Property

        Public ReadOnly Property SelectedIndex() As Integer
            Get
                Return ListBx.SelectedIndex
                If ListBx.SelectedIndex < 0 Then Exit Property
            End Get
        End Property

        Public Sub Clear()
            ListBx.Items.Clear()
        End Sub

        Public Sub ClearSelected()
            For i As Integer = (ListBx.SelectedItems.Count - 1) To 0 Step -1
                ListBx.Items.Remove(ListBx.SelectedItems(i))
            Next
        End Sub

        Sub Drawitem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles ListBx.DrawItem
            If e.Index < 0 Then Exit Sub
            e.DrawBackground()
            e.DrawFocusRectangle()

            e.Graphics.SmoothingMode = 2
            e.Graphics.PixelOffsetMode = 2
            e.Graphics.InterpolationMode = 7
            e.Graphics.TextRenderingHint = 5

            If InStr(e.State.ToString, "Selected,") > 0 Then '-- if selected
                '-- Base
                e.Graphics.FillRectangle(New SolidBrush(_SelectedColor), New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))

                '-- Text
                e.Graphics.DrawString(" " & ListBx.Items(e.Index).ToString(), New Font("Segoe UI", 8), Brushes.White, e.Bounds.X, e.Bounds.Y + 2)
            Else
                '-- Base
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(51, 53, 55)), New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))

                '-- Text 
                e.Graphics.DrawString(" " & ListBx.Items(e.Index).ToString(), New Font("Segoe UI", 8), Brushes.White, e.Bounds.X, e.Bounds.Y + 2)
            End If

            e.Graphics.Dispose()
        End Sub

        Protected Overrides Sub OnCreateControl()
            MyBase.OnCreateControl()
            If Not Controls.Contains(ListBx) Then
                Controls.Add(ListBx)
            End If
        End Sub

        Sub AddRange(ByVal items As Object())
            ListBx.Items.Remove("")
            ListBx.Items.AddRange(items)
        End Sub

        Sub AddItem(ByVal item As Object)
            ListBx.Items.Remove("")
            ListBx.Items.Add(item)
        End Sub

#End Region

#Region " Colors"

        Private BaseColor As Color = Color.FromArgb(45, 47, 49)
        Private _SelectedColor As Color = _FlatColor

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                     ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
            DoubleBuffered = True

            ListBx.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
            ListBx.ScrollAlwaysVisible = False
            ListBx.HorizontalScrollbar = False
            ListBx.BorderStyle = BorderStyle.None
            ListBx.BackColor = BaseColor
            ListBx.ForeColor = Color.White
            ListBx.Location = New Point(3, 3)
            ListBx.Font = New Font("Segoe UI", 8)
            ListBx.ItemHeight = 20
            ListBx.Items.Clear()
            ListBx.IntegralHeight = False

            Size = New Size(131, 101)
            BackColor = BaseColor
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)

            Dim Base As New Rectangle(0, 0, Width, Height)

            With G
                .SmoothingMode = 2
                .PixelOffsetMode = 2
                .TextRenderingHint = 5
                .Clear(BackColor)

                '-- Size
                ListBx.Size = New Size(Width - 6, Height - 2)

                '-- Base
                .FillRectangle(New SolidBrush(BaseColor), Base)
            End With

            MyBase.OnPaint(e)
            G.Dispose()
            e.Graphics.InterpolationMode = 7
            e.Graphics.DrawImageUnscaled(B, 0, 0)
            B.Dispose()
        End Sub

    End Class
End NameSpace