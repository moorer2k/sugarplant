Imports System.ComponentModel

Namespace FlatUI
    Class FlatTabControl : Inherits TabControl

#Region " Variables"

        Private W, H As Integer

#End Region

#Region " Properties"

        Protected Overrides Sub CreateHandle()
            MyBase.CreateHandle()
            Alignment = TabAlignment.Top
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
        Public Property ActiveColor As Color
            Get
                Return _ActiveColor
            End Get
            Set(value As Color)
                _ActiveColor = value
            End Set
        End Property

#End Region

#End Region

#Region " Colors"

        Private BGColor As Color = Color.FromArgb(60, 70, 73)
        Private _BaseColor As Color = Color.FromArgb(45, 47, 49)
        Private _ActiveColor As Color = _FlatColor

#End Region

        Sub New()
            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                     ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
            DoubleBuffered = True
            BackColor = Color.FromArgb(60, 70, 73)

            Font = New Font("Segoe UI", 10)
            SizeMode = TabSizeMode.Fixed
            ItemSize = New Size(120, 40)
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)


            B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
            W = Width - 1 : H = Height - 1

            With G
                .SmoothingMode = 2
                .PixelOffsetMode = 2
                .TextRenderingHint = 5
                .Clear(_BaseColor)

                Try : SelectedTab.BackColor = BGColor : Catch : End Try

                For i = 0 To TabCount - 1
                    Dim Base As New Rectangle(New Point(GetTabRect(i).Location.X + 2, GetTabRect(i).Location.Y), New Size(GetTabRect(i).Width, GetTabRect(i).Height))
                    Dim BaseSize As New Rectangle(Base.Location, New Size(Base.Width, Base.Height))

                    If i = SelectedIndex Then
                        '-- Base
                        .FillRectangle(New SolidBrush(_BaseColor), BaseSize)

                        '-- Gradiant
                        '.fill
                        .FillRectangle(New SolidBrush(_ActiveColor), BaseSize)

                        '-- ImageList
                        If ImageList IsNot Nothing Then
                            Try
                                If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
                                    '-- Image
                                    .DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6))
                                    '-- Text
                                    .DrawString("      " & TabPages(i).Text, Font, Brushes.White, BaseSize, CenterSF)
                                Else
                                    '-- Text
                                    .DrawString(TabPages(i).Text, Font, Brushes.White, BaseSize, CenterSF)
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        Else
                            '-- Text
                            .DrawString(TabPages(i).Text, Font, Brushes.White, BaseSize, CenterSF)
                        End If
                    Else
                        '-- Base
                        .FillRectangle(New SolidBrush(_BaseColor), BaseSize)

                        '-- ImageList
                        If ImageList IsNot Nothing Then
                            Try
                                If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
                                    '-- Image
                                    .DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6))
                                    '-- Text
                                    .DrawString("      " & TabPages(i).Text, Font, New SolidBrush(Color.White), BaseSize, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                                Else
                                    '-- Text
                                    .DrawString(TabPages(i).Text, Font, New SolidBrush(Color.White), BaseSize, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                                End If
                            Catch ex As Exception
                                Throw New Exception(ex.Message)
                            End Try
                        Else
                            '-- Text
                            .DrawString(TabPages(i).Text, Font, New SolidBrush(Color.White), BaseSize, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                        End If
                    End If
                Next
            End With

            MyBase.OnPaint(e)
            G.Dispose()
            e.Graphics.InterpolationMode = 7
            e.Graphics.DrawImageUnscaled(B, 0, 0)
            B.Dispose()
        End Sub
    End Class
End NameSpace