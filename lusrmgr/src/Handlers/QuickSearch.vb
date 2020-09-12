Class QuickSearch_C
    Private mainF As MainForm
    Private qsDisabled As Boolean

    Public Sub New(mainForm As MainForm)
        mainF = mainForm
    End Sub

    Private hiddenItems As New List(Of ListViewItem)

    Public Sub ClearQuickSearch(Optional DisposeHiddenItems As Boolean = False)
        qsDisabled = True
        If Not DisposeHiddenItems Then
            mainF.list.Items.AddRange(hiddenItems.ToArray())
        End If
        hiddenItems.Clear()
        mainF.QSMenu.Clear()
        mainF.QSearch.Clear()
        mainF.ViewHandler.RefreshItemCount()
        qsDisabled = False
    End Sub

    Public Sub QuickSearchInitiated(searchTerm As String)
        If qsDisabled Then Return

        mainF.list.Items.AddRange(hiddenItems.ToArray())
        hiddenItems.Clear()

        If searchTerm.Length = 0 Then

            If Not mainF.ViewHandler.GetView() = ViewHandler_C.View.MachineRoot Then
                'Only a refreshItemCount() is needed here, since the sorting is handled automatically for the user and group views
                mainF.ViewHandler.RefreshItemCount()
            Else
                If Not mainF.ADHandler.currentAD().IsLoading() Then
                    mainF.list.Items.Clear()
                    mainF.list.Items.Add("Users", 0)
                    mainF.list.Items.Add("Groups", 1)
                    If mainF.ADHandler.currentAD().BuiltInPrincipals.Count > 0 Then
                        mainF.list.Items.Add("Built-in security principals", 5)
                    End If
                End If
            End If

            Return
        End If

        If mainF.ViewHandler.GetView() = ViewHandler_C.View.BuiltInPrincipals Then
            For Each item As ListViewItem In mainF.list.Items
                If Not item.Text.ToLower().Contains(mainF.QSMenu.Text.ToLower()) AndAlso Not item.SubItems(1).Text.ToLower().Contains(mainF.QSMenu.Text.ToLower()) Then
                    hiddenItems.Add(item)
                    item.Remove()
                End If
            Next
        Else
            For Each item As ListViewItem In mainF.list.Items
                If Not item.Text.ToLower().Contains(mainF.QSMenu.Text.ToLower()) Then
                    hiddenItems.Add(item)
                    item.Remove()
                End If
            Next
        End If

        If Not mainF.ViewHandler.GetView() = ViewHandler_C.View.MachineRoot Then
            mainF.status.Text = "Showing " & mainF.list.Items.Count & " out of " & mainF.list.Items.Count + hiddenItems.Count & " elements"
        End If
    End Sub
End Class
