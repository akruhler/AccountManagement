Imports DsEntry = System.DirectoryServices.DirectoryEntry
Public Class Search
    Dim cADc, allC As UInteger
    Dim onlyLocal As Boolean
    Dim mForma As Form1

    Overloads Function Show(mainForm As Form1) As DialogResult
        mForma = mainForm
        If mainForm.connectedADs.Count = 0 Then
            onlyLocal = True

            CheckBox3.Hide()
            CheckBox3.Checked = False

            ListView1.Columns.Remove(ColumnHeader2)
            ColumnHeader1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
        Else
            allC = mainForm.localAD.UserList.Count + mainForm.localAD.GroupList.Count
            For Each AD As ActiveDirectory In mainForm.connectedADs
                allC += AD.UserList.Count + AD.GroupList.Count
            Next
        End If

        cADc = mainForm.currentAD().UserList.Count + mainForm.currentAD().GroupList.Count

        Return ShowDialog()
    End Function

    Private Sub ListView1_SizeChanged(sender As Object, e As EventArgs) Handles ListView1.SizeChanged
        If onlyLocal Then
            ColumnHeader1.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
        End If
    End Sub

    Private Sub ListView1_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs) Handles ListView1.ColumnWidthChanging
        If onlyLocal Then
            e.NewWidth = ListView1.Columns(0).Width
            e.Cancel = True
        End If
    End Sub

    Private Function useInterval() As Boolean
        If CheckBox3.Checked Then
            If allC > 300 Then
                Return True
            Else
                Return False
            End If
        Else
            If cADc > 300 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged, CheckBox1.CheckedChanged, CheckBox2.CheckedChanged, CheckBox3.CheckedChanged
        ListView1.Items.Clear()
        If TextBox1.TextLength = 0 Then
            Timer1.Stop()
            PictureBox1.Hide()
            Label2.Hide()
            Label3.Hide()
            Return
        End If

        If useInterval() Then
            Timer1.Stop()
            Timer1.Start()
            PictureBox1.Show()
            Label2.Show()
            Return
        End If

        If CheckBox3.Checked Then
            SearchAll()
        Else
            Search(mForma.currentAD())
        End If

        If ListView1.Items.Count = 0 Then
            Label3.Show()
        Else
            Label3.Hide()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If Not CheckBox1.Checked AndAlso Not CheckBox2.Checked Then
            CheckBox2.Checked = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If Not CheckBox1.Checked AndAlso Not CheckBox2.Checked Then
            CheckBox1.Checked = True
        End If
    End Sub

    Private Sub ListView1_DoubleClick(sender As Object, e As EventArgs) Handles ListView1.DoubleClick, EDIT.Click
        If ListView1.SelectedIndices.Count < 1 Then Return

        If mForma.isRootNode() Then
            If Not mForma.tw.SelectedNode.Index = mForma.tw.Nodes(ListView1.SelectedItems(0).Tag).Index Then
                mForma.tw.SelectedNode = mForma.tw.Nodes(ListView1.SelectedItems(0).Tag)
            End If
        Else
            If Not mForma.tw.SelectedNode.Parent.Index = mForma.tw.Nodes(ListView1.SelectedItems(0).Tag).Index Then
                mForma.tw.SelectedNode = mForma.tw.Nodes(ListView1.SelectedItems(0).Tag)
            End If
        End If

        If ListView1.SelectedItems(0).ImageIndex = 0 Then
            If Not EditUser.Show(ListView1.SelectedItems(0).Text, mForma) Then
                TextBox1_TextChanged(Nothing, Nothing)
            End If
        Else
            If Not EditGroup.Show(ListView1.SelectedItems(0).Text, mForma) Then
                TextBox1_TextChanged(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub ListView1_KeyDown(sender As Object, e As KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Return Then ListView1_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If ListView1.SelectedIndices.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub Search(sAD As ActiveDirectory, Optional all As Boolean = False)
        If CheckBox1.Checked Then

            For Each user As KeyValuePair(Of String, String) In sAD.UserList

                Dim FullName As String = user.Value

                If user.Key IsNot Nothing AndAlso user.Key.ToLower().Contains(TextBox1.Text.ToLower()) Then
                    'ListView1.Items.Add(user.Key, 0).Tag = mForma.getIAD(sAD)
                    ListView1.Items.Add(New ListViewItem(New String() {user.Key, sAD.displayName}, 0)).Tag = mForma.getIAD(sAD)
                    Continue For
                End If

                If FullName IsNot Nothing AndAlso FullName.ToLower().Contains(TextBox1.Text.ToLower()) Then
                    ListView1.Items.Add(New ListViewItem(New String() {user.Key, sAD.displayName}, 0)).Tag = mForma.getIAD(sAD)
                End If
            Next
        End If

        If CheckBox2.Checked Then
            For Each group As String In sAD.GroupList

                If group IsNot Nothing AndAlso group.ToLower().Contains(TextBox1.Text.ToLower()) Then
                    ListView1.Items.Add(New ListViewItem(New String() {group, sAD.displayName}, 1)).Tag = mForma.getIAD(sAD)
                End If
            Next
        End If

        If all Then Return
    End Sub

    Private Sub SearchAll()
        Search(mForma.localAD, True)

        For Each AD As ActiveDirectory In mForma.connectedADs
            Search(AD, True)
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()

        If CheckBox3.Checked Then
            SearchAll()
        Else
            Search(mForma.currentAD())
        End If

        If ListView1.Items.Count = 0 Then
            Label3.Show()
        Else
            Label3.Hide()
        End If

        PictureBox1.Hide()
        Label2.Hide()
    End Sub

    Private Sub GoToElementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoToElementToolStripMenuItem.Click
        Close()

        If ListView1.SelectedItems(0).ImageIndex = 0 Then
            mForma.tw.SelectedNode = mForma.tw.Nodes(ListView1.SelectedItems(0).Tag).Nodes(0)

        Else
            mForma.tw.SelectedNode = mForma.tw.Nodes(ListView1.SelectedItems(0).Tag).Nodes(1)
        End If

        mForma.QSMenu.Clear()
        mForma.QSearch.Clear()

        mForma.list.SelectedItems.Clear()
        mForma.list.Items(ListView1.SelectedItems(0).Text).Selected = True
        DialogResult = Windows.Forms.DialogResult.Retry
    End Sub
End Class