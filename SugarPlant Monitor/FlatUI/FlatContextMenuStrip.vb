Imports System.ComponentModel

Namespace FlatUI
    Class FlatContextMenuStrip : Inherits ContextMenuStrip

        Protected Overrides Sub OnTextChanged(e As EventArgs)
            MyBase.OnTextChanged(e) : Invalidate()
        End Sub

        Sub New()
            MyBase.New()
            Renderer = New ToolStripProfessionalRenderer(New TColorTable())
            ShowImageMargin = False
            ForeColor = Color.White
            Font = New Font("Segoe UI", 8)
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            e.Graphics.TextRenderingHint = 5
        End Sub

        Class TColorTable : Inherits ProfessionalColorTable

#Region " Properties"

#Region " Colors"

            <Category("Colors")> _
            Public Property _BackColor As Color
                Get
                    Return BackColor
                End Get
                Set(value As Color)
                    BackColor = value
                End Set
            End Property

            <Category("Colors")> _
            Public Property _CheckedColor As Color
                Get
                    Return CheckedColor
                End Get
                Set(value As Color)
                    CheckedColor = value
                End Set
            End Property

            <Category("Colors")> _
            Public Property _BorderColor As Color
                Get
                    Return BorderColor
                End Get
                Set(value As Color)
                    BorderColor = value
                End Set
            End Property

#End Region

#End Region

#Region " Colors"

            Private BackColor As Color = Color.FromArgb(45, 47, 49)
            Private CheckedColor As Color = _FlatColor
            Private BorderColor As Color = Color.FromArgb(53, 58, 60)

#End Region

#Region " Overrides"

            Public Overrides ReadOnly Property ButtonSelectedBorder As Color
                Get
                    Return BackColor
                End Get
            End Property
            Public Overrides ReadOnly Property CheckBackground() As Color
                Get
                    Return CheckedColor
                End Get
            End Property
            Public Overrides ReadOnly Property CheckPressedBackground() As Color
                Get
                    Return CheckedColor
                End Get
            End Property
            Public Overrides ReadOnly Property CheckSelectedBackground() As Color
                Get
                    Return CheckedColor
                End Get
            End Property
            Public Overrides ReadOnly Property ImageMarginGradientBegin() As Color
                Get
                    Return CheckedColor
                End Get
            End Property
            Public Overrides ReadOnly Property ImageMarginGradientEnd() As Color
                Get
                    Return CheckedColor
                End Get
            End Property
            Public Overrides ReadOnly Property ImageMarginGradientMiddle() As Color
                Get
                    Return CheckedColor
                End Get
            End Property
            Public Overrides ReadOnly Property MenuBorder() As Color
                Get
                    Return BorderColor
                End Get
            End Property
            Public Overrides ReadOnly Property MenuItemBorder() As Color
                Get
                    Return BorderColor
                End Get
            End Property
            Public Overrides ReadOnly Property MenuItemSelected() As Color
                Get
                    Return CheckedColor
                End Get
            End Property
            Public Overrides ReadOnly Property SeparatorDark() As Color
                Get
                    Return BorderColor
                End Get
            End Property
            Public Overrides ReadOnly Property ToolStripDropDownBackground() As Color
                Get
                    Return BackColor
                End Get
            End Property

#End Region

        End Class

    End Class
End NameSpace