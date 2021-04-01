Imports System.Drawing.Drawing2D

Namespace FlatUI
    ''' <summary>
    ''' Flat UI Theme
    ''' Creator: iSynthesis (HF)
    ''' Version: 1.0.4
    ''' Date Created: 17/06/2013
    ''' Date Changed: 26/06/2013
    ''' UID: 374648
    ''' For any bugs / errors, PM me.
    ''' </summary>
    ''' <remarks></remarks>

        Module Helpers

#Region " Variables"
        Friend G As Graphics, B As Bitmap
        Friend _FlatColor As Color = Color.FromArgb(35, 168, 109)
        Friend NearSF As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}
        Friend CenterSF As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
#End Region

#Region " Functions"

        Public Function RoundRec(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
            Dim P As GraphicsPath = New GraphicsPath()
            Dim ArcRectangleWidth As Integer = Curve * 2
            P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
            P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
            P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
            P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
            P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
            Return P
        End Function

        Public Function RoundRect(x!, y!, w!, h!, Optional r! = 0.3, Optional TL As Boolean = True, Optional TR As Boolean = True, Optional BR As Boolean = True, Optional BL As Boolean = True) As GraphicsPath
            Dim d! = Math.Min(w, h) * r, xw = x + w, yh = y + h
            RoundRect = New GraphicsPath

            With RoundRect
                If TL Then .AddArc(x, y, d, d, 180, 90) Else .AddLine(x, y, x, y)
                If TR Then .AddArc(xw - d, y, d, d, 270, 90) Else .AddLine(xw, y, xw, y)
                If BR Then .AddArc(xw - d, yh - d, d, d, 0, 90) Else .AddLine(xw, yh, xw, yh)
                If BL Then .AddArc(x, yh - d, d, d, 90, 90) Else .AddLine(x, yh, x, yh)

                .CloseFigure()
            End With
        End Function

        '-- Credit: AeonHack
        Public Function DrawArrow(x As Integer, y As Integer, flip As Boolean) As GraphicsPath
            Dim GP As New GraphicsPath()

            Dim W As Integer = 12
            Dim H As Integer = 6

            If flip Then
                GP.AddLine(x + 1, y, x + W + 1, y)
                GP.AddLine(x + W, y, x + H, y + H - 1)
            Else
                GP.AddLine(x, y + H, x + W, y + H)
                GP.AddLine(x + W, y + H, x + H, y)
            End If

            GP.CloseFigure()
            Return GP
        End Function

#End Region

    End Module
End NameSpace