Public Class clsMenuRenderer
    Inherits System.Windows.Forms.ToolStripRenderer

    '// Make sure the textcolor is black
    Protected Overrides Sub InitializeItem(ByVal item As System.Windows.Forms.ToolStripItem)
        MyBase.InitializeItem(item)
        item.ForeColor = Color.Black
    End Sub
    Protected Overrides Sub Initialize(ByVal toolStrip As System.Windows.Forms.ToolStrip)
        MyBase.Initialize(toolStrip)
        toolStrip.ForeColor = Color.Black
    End Sub

    '// Render horizontal bakcground gradient
    Protected Overrides Sub OnRenderToolStripBackground(ByVal e As ToolStripRenderEventArgs)
        MyBase.OnRenderToolStripBackground(e)

        Dim b As New Drawing2D.LinearGradientBrush(e.AffectedBounds, clrHorBG_GrayBlue, clrHorBG_White, _
            Drawing2D.LinearGradientMode.Horizontal)
        e.Graphics.FillRectangle(b, e.AffectedBounds)
    End Sub

    '// Render Image Margin and gray itembackground
    Protected Overrides Sub OnRenderImageMargin(ByVal e As System.Windows.Forms.ToolStripRenderEventArgs)
        MyBase.OnRenderImageMargin(e)

        '// Draw ImageMargin background gradient
        Dim b As New Drawing2D.LinearGradientBrush(e.AffectedBounds, clrImageMarginWhite, clrImageMarginBlue, _
            Drawing2D.LinearGradientMode.Horizontal)

        '// Shadow at the right of image margin
        Dim DarkLine As New Drawing.SolidBrush(clrImageMarginLine)
        Dim WhiteLine As New Drawing.SolidBrush(Color.White)
        Dim rect As New Rectangle(e.AffectedBounds.Width, 2, 1, e.AffectedBounds.Height)
        Dim rect2 As New Rectangle(e.AffectedBounds.Width + 1, 2, 1, e.AffectedBounds.Height)

        '// Gray background
        Dim SubmenuBGbrush As New Drawing.SolidBrush(clrSubmenuBG)
        Dim rect3 As New Rectangle(0, 0, e.ToolStrip.Width, e.ToolStrip.Height)

        '// Border
        Dim borderPen As New Pen(clrMenuBorder)
        Dim rect4 As New Rectangle(0, 1, e.ToolStrip.Width - 1, e.ToolStrip.Height - 2)

        e.Graphics.FillRectangle(SubmenuBGbrush, rect3)
        e.Graphics.FillRectangle(b, e.AffectedBounds)
        e.Graphics.FillRectangle(DarkLine, rect)
        e.Graphics.FillRectangle(WhiteLine, rect2)
        e.Graphics.DrawRectangle(borderPen, rect4)
    End Sub

    '// Render Checkmark 
    Protected Overrides Sub OnRenderItemCheck(ByVal e As System.Windows.Forms.ToolStripItemImageRenderEventArgs)
        MyBase.OnRenderItemCheck(e)
        If e.Item.Selected Then
            Dim rect As New Rectangle(3, 1, 20, 20)
            Dim rect2 As New Rectangle(4, 2, 18, 18)
            Dim b As New Drawing.SolidBrush(clrToolstripBtn_Border)
            Dim b2 As New Drawing.SolidBrush(clrCheckBG)

            e.Graphics.FillRectangle(b, rect)
            e.Graphics.FillRectangle(b2, rect2)
            e.Graphics.DrawImage(e.Image, New Point(5, 3))
        Else
            Dim rect As New Rectangle(3, 1, 20, 20)
            Dim rect2 As New Rectangle(4, 2, 18, 18)
            Dim b As New Drawing.SolidBrush(clrSelectedBG_Drop_Border)
            Dim b2 As New Drawing.SolidBrush(clrCheckBG)

            e.Graphics.FillRectangle(b, rect)
            e.Graphics.FillRectangle(b2, rect2)
            e.Graphics.DrawImage(e.Image, New Point(5, 3))
        End If
    End Sub

    '// Render separator
    Protected Overrides Sub OnRenderSeparator(ByVal e As System.Windows.Forms.ToolStripSeparatorRenderEventArgs)
        MyBase.OnRenderSeparator(e)

        Dim DarkLine As New Drawing.SolidBrush(clrImageMarginLine)
        Dim WhiteLine As New Drawing.SolidBrush(Color.White)
        Dim rect As New Rectangle(32, 3, e.Item.Width - 32, 1)
        Dim rect2 As New Rectangle(32, 4, e.Item.Width - 32, 1)
        e.Graphics.FillRectangle(DarkLine, rect)
        e.Graphics.FillRectangle(WhiteLine, rect2)
    End Sub

    '// Render arrow
    Protected Overrides Sub OnRenderArrow(ByVal e As System.Windows.Forms.ToolStripArrowRenderEventArgs)
        e.ArrowColor = Color.Black
        MyBase.OnRenderArrow(e)
    End Sub

    '// Render Menuitem background: lightblue if selected, darkblue if dropped down
    Protected Overrides Sub OnRenderMenuItemBackground(ByVal e As System.Windows.Forms.ToolStripItemRenderEventArgs)
        MyBase.OnRenderMenuItemBackground(e)

        If e.Item.Enabled Then
            If e.Item.IsOnDropDown = False AndAlso e.Item.Selected Then
                '// If item is MenuHeader and selected: draw darkblue border

                Dim rect As New Rectangle(3, 2, e.Item.Width - 6, e.Item.Height - 4)
                Dim b As New Drawing2D.LinearGradientBrush(rect, clrSelectedBG_White, clrSelectedBG_Header_Blue, Drawing2D.LinearGradientMode.Vertical)
                Dim b2 As New Drawing.SolidBrush(clrToolstripBtn_Border)

                e.Graphics.FillRectangle(b, rect)
                clsColors.DrawRoundedRectangle(e.Graphics, rect.Left - 1, rect.Top - 1, rect.Width, rect.Height + 1, 4, clrToolstripBtn_Border)
                clsColors.DrawRoundedRectangle(e.Graphics, rect.Left - 2, rect.Top - 2, rect.Width + 2, rect.Height + 3, 4, Color.White)
                e.Item.ForeColor = Color.Black

            ElseIf e.Item.IsOnDropDown AndAlso e.Item.Selected Then
                '// If item is NOT menuheader (but subitem) and selected: draw lightblue border

                Dim rect As New Rectangle(4, 2, e.Item.Width - 6, e.Item.Height - 4)
                Dim b As New Drawing2D.LinearGradientBrush(rect, clrSelectedBG_White, clrSelectedBG_Blue, Drawing2D.LinearGradientMode.Vertical)
                Dim b2 As New Drawing.SolidBrush(clrSelectedBG_Border)

                e.Graphics.FillRectangle(b, rect)
                clsColors.DrawRoundedRectangle(e.Graphics, rect.Left - 1, rect.Top - 1, rect.Width, rect.Height + 1, 6, clrSelectedBG_Border)
                e.Item.ForeColor = Color.Black

            End If

            '// If item is MenuHeader and menu is dropped down: selection rectangle is now darker
            If CType(e.Item, ToolStripMenuItem).DropDown.Visible AndAlso e.Item.IsOnDropDown = False Then 'CType(e.Item, ToolStripMenuItem).OwnerItem Is Nothing Then
                Dim rect As New Rectangle(3, 2, e.Item.Width - 6, e.Item.Height - 4)
                Dim b As New Drawing2D.LinearGradientBrush(rect, Color.White, clrSelectedBG_Drop_Blue, Drawing2D.LinearGradientMode.Vertical)
                Dim b2 As New Drawing.SolidBrush(clrSelectedBG_Drop_Border)

                e.Graphics.FillRectangle(b, rect)
                clsColors.DrawRoundedRectangle(e.Graphics, rect.Left - 1, rect.Top - 1, rect.Width, rect.Height + 1, 4, clrSelectedBG_Drop_Border)
                clsColors.DrawRoundedRectangle(e.Graphics, rect.Left - 2, rect.Top - 2, rect.Width + 2, rect.Height + 3, 4, Color.White)
                e.Item.ForeColor = Color.Black
            End If
        End If
    End Sub

End Class