Module WindowHandler
    'An ID consists of the machine's name and the object SID
    Private EditUserWnd As New Dictionary(Of EditUser, String)
    Private EditGroupWnd As New Dictionary(Of EditGroup, String)
    Private AddUserWnd As New Dictionary(Of AddUser, String)
    Private AddGroupWnd As New Dictionary(Of AddGroup, String)

    ''' <summary>
    ''' Returns whether at least one property is still open
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function isAnyOpen() As Boolean
        Return (EditUserWnd.Count + EditGroupWnd.Count + AddUserWnd.Count + AddGroupWnd.Count) <> 0
    End Function

    ''' <summary>
    ''' Registers a new properties window if the same window is not open.
    ''' Returns false if the window is already open.
    ''' </summary>
    ''' <param name="window"></param>
    ''' <param name="SID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function RegisterWindow(window As EditUser, SID As String) As Boolean
        'Check whether the required properties window is already open
        For Each element In EditUserWnd
            If element.Value = SID Then
                If element.Key.WindowState = FormWindowState.Minimized Then element.Key.WindowState = FormWindowState.Normal
                element.Key.BringToFront()
                Return False
            End If
        Next

        EditUserWnd.Add(window, SID)
        AddHandler window.FormClosed, AddressOf EditUserClosed
        Return True
    End Function

    ''' <summary>
    ''' Registers a new property window if a window for the same object is not open.
    ''' Returns false if the window is already open.
    ''' Instead of the SID, the machine SID and the group SID is passed in, since the predefined group SIDs remain the same across all systems
    ''' </summary>
    ''' <param name="window"></param>
    ''' <param name="ID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function RegisterWindow(window As EditGroup, ID As String) As Boolean
        'Check whether the required properties window is already open
        For Each element In EditGroupWnd
            If element.Value = ID Then
                If element.Key.WindowState = FormWindowState.Minimized Then element.Key.WindowState = FormWindowState.Normal
                element.Key.BringToFront()
                Return False
            End If
        Next

        EditGroupWnd.Add(window, ID)
        AddHandler window.FormClosed, AddressOf EditGroupClosed
        Return True
    End Function

    ''' <summary>
    ''' Opens a new user creation window, if there is no window open for the current AD.
    ''' </summary>
    ''' <param name="pAD"></param>
    ''' <remarks></remarks>
    Sub OpenAddUser(pAD As ActiveDirectory)
        'Check whether the required properties window is already open
        For Each element In AddUserWnd
            If element.Value = pAD.GetID() Then
                If element.Key.WindowState = FormWindowState.Minimized Then element.Key.WindowState = FormWindowState.Normal
                element.Key.BringToFront()
                Return
            End If
        Next

        Dim newWnd As New AddUser()
        newWnd.Show(pAD)
        AddUserWnd.Add(newWnd, pAD.GetID())
        AddHandler newWnd.FormClosed, AddressOf AddUserClosed
    End Sub

    ''' <summary>
    ''' Opens a new group creation window, if there is no window open for the current AD.
    ''' </summary>
    ''' <param name="pAD"></param>
    ''' <remarks></remarks>
    Sub OpenAddGroup(pAD As ActiveDirectory)
        'Check whether the required properties window is already open
        For Each element In AddGroupWnd
            If element.Value = pAD.GetID() Then
                If element.Key.WindowState = FormWindowState.Minimized Then element.Key.WindowState = FormWindowState.Normal
                element.Key.BringToFront()
                Return
            End If
        Next

        Dim newWnd As New AddGroup()
        newWnd.Show(pAD)
        AddGroupWnd.Add(newWnd, pAD.GetID())
        AddHandler newWnd.FormClosed, AddressOf AddGroupClosed
    End Sub

    Private Sub EditUserClosed(sender As Object, e As FormClosedEventArgs)
        EditUserWnd.Remove(sender)
    End Sub

    Private Sub EditGroupClosed(sender As Object, e As FormClosedEventArgs)
        EditGroupWnd.Remove(sender)
    End Sub

    Private Sub AddUserClosed(sender As Object, e As FormClosedEventArgs)
        AddUserWnd.Remove(sender)
    End Sub

    Private Sub AddGroupClosed(sender As Object, e As FormClosedEventArgs)
        AddGroupWnd.Remove(sender)
    End Sub
End Module
