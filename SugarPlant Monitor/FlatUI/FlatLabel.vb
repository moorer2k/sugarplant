Namespace FlatUI
    Class FlatLabel : Inherits Label

        Protected Overrides Sub OnTextChanged(e As EventArgs)
            MyBase.OnTextChanged(e) : Invalidate()
        End Sub

        Sub New()
            SetStyle(ControlStyles.SupportsTransparentBackColor, True)
            Font = New Font("Segoe UI", 8)
            ForeColor = Color.White
            BackColor = Color.Transparent
            Text = Text
        End Sub

    End Class
End NameSpace