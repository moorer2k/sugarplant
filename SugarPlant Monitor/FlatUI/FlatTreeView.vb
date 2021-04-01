
Imports System.Windows.Forms

Namespace FlatUI

#Region " Mouse States"

#End Region

    Class FlatTreeView : Inherits TreeView

#Region " Variables"

        Private State As TreeNodeStates

#End Region

#Region " Properties"

        Protected Overrides Sub OnDrawNode(e As DrawTreeNodeEventArgs)
            Try
                Dim Bounds As New Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y, e.Bounds.Width, e.Bounds.Height)
                'e.Node.Nodes.Item.
                Select Case State
                    Case TreeNodeStates.Default
                        e.Graphics.FillRectangle(Brushes.Red, Bounds)
                        e.Graphics.DrawString(e.Node.Text, New Font("Segoe UI", 8), Brushes.LimeGreen, New Rectangle(Bounds.X + 2, Bounds.Y + 2, Bounds.Width, Bounds.Height), NearSF)
                        Invalidate()
                    Case TreeNodeStates.Checked
                        e.Graphics.FillRectangle(Brushes.Green, Bounds)
                        e.Graphics.DrawString(e.Node.Text, New Font("Segoe UI", 8), Brushes.Black, New Rectangle(Bounds.X + 2, Bounds.Y + 2, Bounds.Width, Bounds.Height), NearSF)
                        Invalidate()
                    Case TreeNodeStates.Selected
                        e.Graphics.FillRectangle(Brushes.Green, Bounds)
                        e.Graphics.DrawString(e.Node.Text, New Font("Segoe UI", 8), Brushes.Black, New Rectangle(Bounds.X + 2, Bounds.Y + 2, Bounds.Width, Bounds.Height), NearSF)
                        Invalidate()
                End Select

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            MyBase.OnDrawNode(e)
        End Sub

#End Region

#Region " Colors"

        Private _BaseColor As Color = Color.FromArgb(45, 47, 49)
        Private _LineColor As Color = Color.FromArgb(25, 27, 29)

#End Region
        Sub New()

            SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                     ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
            DoubleBuffered = True

            BackColor = _BaseColor
            ForeColor = Color.White
            LineColor = _LineColor
            DrawMode = TreeViewDrawMode.OwnerDrawAll
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)

            Dim Base As New Rectangle(0, 0, Width, Height)

            With G
                .SmoothingMode = 2
                .PixelOffsetMode = 2
                .TextRenderingHint = 5
                .Clear(BackColor)

                .FillRectangle(New SolidBrush(_BaseColor), Base)
                .DrawString(Text, New Font("Segoe UI", 8), Brushes.Black, New Rectangle(Bounds.X + 2, Bounds.Y + 2, Bounds.Width, Bounds.Height), NearSF)

            End With

            MyBase.OnPaint(e)
            G.Dispose()
            e.Graphics.InterpolationMode = 7
            e.Graphics.DrawImageUnscaled(B, 0, 0)
            B.Dispose()
        End Sub

    End Class
End Namespace