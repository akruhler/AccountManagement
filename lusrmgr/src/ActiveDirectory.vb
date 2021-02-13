Imports ActiveDs
Imports System.DirectoryServices
Imports DsEntry = System.DirectoryServices.DirectoryEntry

''' <summary>
''' An object that encapsulates information for displaying AD related warnings in the status bar.
''' </summary>
''' <remarks></remarks>
Public Class ADWarning
    Public Title, Description, Details As String

    Public Sub New(pTitle As String, pDescription As String, Optional pDetails As String = "")
        Title = pTitle
        Description = pDescription
        Details = pDetails
    End Sub
End Class

''' <summary>
''' Represents an object for interfering with users and groups using the WinNT provider.
''' </summary>
''' <remarks></remarks>
Public Class ActiveDirectory
    Private main As DirectoryEntry
    Private mainF As MainForm
    Private isLoading_ As Boolean = True
    Private conErr As Boolean
    Private loadingCancelled As Boolean
    Private NoUserGroup As Boolean
    Private displayName As String
    Private sysSID, rID As String

    ''' <summary>
    ''' A list of the users on the machine, the username (map key) maps to its full name property (map value) to shorten search time.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly UserList As New SortedDictionary(Of String, String)
    Public ReadOnly GroupList As New SortedSet(Of String)
    Public ReadOnly BuiltInPrincipals As List(Of BuiltInPrincipal)
    ''' <summary>
    ''' A list of warnings that is displayed in the bottom status bar. The user can view the specified details if necessary.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Warnings As New List(Of ADWarning)
    Public UserGroup As DsEntry

    ''' <summary>
    ''' Refreshes the list on the MainForm if the currently selected AD corresponds to this instance and reinits search if visible.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateLists()
        If Not mainF.ViewHandler.GetView() = ViewHandler_C.View.MachineRoot AndAlso mainF.ADHandler.currentAD Is Me Then
            mainF.ViewHandler.RefreshMainList()
        End If
        mainF.ViewHandler.RefreshSearch()
    End Sub

    ''' <summary>
    ''' Closes the DirectoryEntry object.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Disconnect()
        RaiseEvent OnDisconnect()

        If isLoading_ Then
            loadingCancelled = True
        Else
            If main.Name <> "localhost" Then
                WNetClose(main.Name, mainF.Handle)
            End If
        End If

        main.Close()
    End Sub

#Region "Constructors"

    Public Sub New(mainForm As MainForm)
        Me.New("localhost", mainForm, Environment.MachineName)
    End Sub

    Public Sub New(addr As String, mainForm As MainForm, Optional name As String = "")
        mainF = mainForm

        If name = "" Then
            displayName = addr
        Else
            displayName = name
        End If

        main = New DirectoryEntry("WinNT://" & addr)

        Dim PolicyHandle As IntPtr = IntPtr.Zero
        Try
            PolicyHandle = GetPolicyHandle(addr, mainForm.Handle)
            BuiltInPrincipals = LookupWellKnownSids(PolicyHandle, mainForm.Handle, [Enum].GetValues(GetType(WellKnownSID)))
        Catch ex As System.ComponentModel.Win32Exception
            BuiltInPrincipals = New List(Of BuiltInPrincipal)(0)
            Warnings.Add(New ADWarning("Could not retrieve built-in principals", "An error occurred whilst retrieving the built-in principals on the target system.", ex.Message & vbCrLf & "Error code: " & ex.NativeErrorCode & vbCrLf & "Function: " & ex.TargetSite.Name))
        Finally
            If PolicyHandle <> IntPtr.Zero Then
                ClosePolicyHandle(PolicyHandle, mainF.Handle)
            End If
        End Try

        init()
    End Sub

    Private Async Sub init()
        Try
            Await Task.Run(Sub()
                               main.Children.SchemaFilter.Add("User")
                               main.Children.SchemaFilter.Add("Group")
                               RefreshDS()
                           End Sub)
        Catch ex As Exception
            If loadingCancelled = False Then
                'Set the connection error flag
                conErr = True
            End If
        End Try
    End Sub
#End Region

#Region "Events"

    Public Event OnDisconnect()
    Public Event OnDisplayNameChange(newName As String)
    Public Event OnDeleteUser(Name As String)
    Public Event OnDeleteGroup(Name As String)
    Public Event OnRenameUser(Name As String, newName As String)
    Public Event OnRenameGroup(Name As String, newName As String)
#End Region

#Region "Getters and setters"

    Public Function IsLoading() As Boolean
        Return isLoading_
    End Function

    Public Function IsRemoteAD() As Boolean
        Return mainF.ADHandler.localAD IsNot Me
    End Function

    Public Function ConnectionErrorOccurred() As Boolean
        Return conErr
    End Function

    Public Function GetDisplayName() As String
        Return displayName
    End Function

    Public Function GetName() As String
        Return main.Name
    End Function

    Public Function UserGroupUnavailable() As Boolean
        Return NoUserGroup
    End Function

    ''' <summary>
    ''' Retrieves an unique identifier for this particular AD object.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetID() As String
        If sysSID IsNot Nothing AndAlso rID IsNot Nothing Then
            Return sysSID & rID
        Else
            sysSID = "$RND" & (New Random).Next().ToString()
            Warnings.Add(New ADWarning("Unable to retrieve system SID", "A randomly generated value will be used as a replacement.", "The GetID() function was called without the system SID being available."))
            rID = "$RND" & (New Random).Next().ToString()
            Return sysSID & rID
        End If
    End Function

    ''' <summary>
    ''' Returns the machine's SID.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetSystemSID() As String
        If sysSID IsNot Nothing Then
            Return sysSID
        Else
            sysSID = "$RND" & (New Random).Next().ToString()
            Warnings.Add(New ADWarning("Unable to retrieve system SID", "A randomly generated value will be used as a replacement.", "The GetSystemSID() function was called without the system SID being available."))
            Return sysSID
        End If
    End Function

    Public Sub ChangeDisplayName(newName As String)
        If newName = "" Then
            displayName = main.Name
        Else
            displayName = newName
        End If
        RaiseEvent OnDisplayNameChange(newName)
    End Sub
#End Region

#Region "Methods for locating objects"

    ''' <summary>
    ''' Returns whether a user exists. If the user cannot be found, an error message is displayed to the user and the method returns false.
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="parentWnd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function UserExists(Name As String, parentWnd As IntPtr) As Boolean
        Return FindUser(Name, parentWnd) IsNot Nothing
    End Function

    ''' <summary>
    ''' Returns whether a group exists. If the group cannot be found, an error message is displayed to the user and the method returns false.
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="parentWnd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GroupExists(Name As String, parentWnd As IntPtr) As Boolean
        Return FindGroup(Name, parentWnd) IsNot Nothing
    End Function

    Public Function BuiltInPrincipalOrUserExists(Name As String, parentWnd As IntPtr) As Boolean
        If GetPrincipalByName(Name).isInvalid = False Then
            Return True
        End If

        Return UserExists(Name, parentWnd)
    End Function

    Public Function GetPrincipalBySID(SID As String) As BuiltInPrincipal
        For i As Integer = 0 To BuiltInPrincipals.Count - 1
            If BuiltInPrincipals(i).SID = SID Then
                Return BuiltInPrincipals(i)
            End If
        Next

        Return BuiltInPrincipal.INVALID
    End Function

    Public Function GetPrincipalByName(Name As String) As BuiltInPrincipal
        For i As Integer = 0 To BuiltInPrincipals.Count - 1
            If BuiltInPrincipals(i).Name = Name Then
                Return BuiltInPrincipals(i)
            End If
        Next

        Return BuiltInPrincipal.INVALID
    End Function

    ''' <summary>
    ''' Finds a user in the account database. If the object cannot be found, an error message is displayed to the user and the method returns null.
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="parentWnd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindUser(Name As String, parentWnd As IntPtr) As DsEntry
        Try
            Return main.Children.Find(Name, "User")
        Catch ex As Runtime.InteropServices.COMException
            If ShowCOMErr(ex.ErrorCode, parentWnd, ex.Message, Name) = COMErrResult.REFRESH Then
                RefreshDS()
                mainF.ViewHandler.RefreshItemCount()
            End If
            Return Nothing
        Catch ex As Exception
            If ex.HResult = &H80070035 Then 'Network path not found error
                TaskDialog(parentWnd, "Local users and groups", "Could not access computer", "The network path could not be found.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TD_ERROR_ICON, 0, True)
            Else
                ShowUnknownErr(parentWnd, ex.Message)
            End If
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Finds a group in the account database. If the object cannot be found, an error message is displayed to the user and the method returns null.
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="parentWnd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FindGroup(Name As String, parentWnd As IntPtr) As DsEntry
        Try
            Return main.Children.Find(Name, "Group")
        Catch ex As Runtime.InteropServices.COMException
            If ShowCOMErr(ex.ErrorCode, parentWnd, ex.Message, Name) = COMErrResult.REFRESH Then
                RefreshDS()
                mainF.ViewHandler.RefreshItemCount()
            End If
            Return Nothing
        Catch ex As Exception
            If ex.HResult = &H80070035 Then 'Network path not found error
                TaskDialog(parentWnd, "Local users and groups", "Could not access computer", "The network path could not be found.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TD_ERROR_ICON, 0, True)
            Else
                ShowUnknownErr(parentWnd, ex.Message)
            End If
            Return Nothing
        End Try
    End Function

    Public Function GetPath(Name As String, IncludeBuiltInSecurityPrincipals As Boolean) As String

        If IncludeBuiltInSecurityPrincipals Then
            Dim Principal As BuiltInPrincipal = GetPrincipalByName(Name)

            If Principal.isInvalid = False Then
                Return "WinNT://" & Principal.SID
            End If
        End If

        Return "WinNT://" & Name
    End Function
#End Region

    ''' <summary>
    ''' Refreshes the user and group database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshDS(Optional DoNotUpdateLists As Boolean = False)
        GroupList.Clear()
        UserList.Clear()

        Dim userGroupFound As Boolean = False

        For Each o As DsEntry In main.Children
            If isLoading_ AndAlso loadingCancelled Then
                Return
            End If

            If o.SchemaClassName = "Group" Then
                GroupList.Add(o.Name)
                'Find the user group using its SID as it should be the default for new user accounts
                If Not userGroupFound AndAlso PtrToSID(o.Properties("objectSid").Value) = "S-1-5-32-545" Then
                    UserGroup = o
                    userGroupFound = True
                End If

            ElseIf o.SchemaClassName = "User" Then
                UserList.Add(o.Name, o.Properties("FullName").Value.ToString())

                'Get the system SID by parsing it from the built-in Administrator account
                If sysSID Is Nothing Then
                    Dim SID As String = PtrToSID(o.Properties("objectSid").Value)
                    If SID.EndsWith("-500") AndAlso SID.StartsWith("S-1-5-21-") Then
                        sysSID = SID.Substring(0, SID.Length - 4)
                    End If
                End If

            End If
        Next

        If isLoading_ AndAlso loadingCancelled Then
            Return
        End If

        If UserGroup Is Nothing Then
            NoUserGroup = True
            Warnings.Add(New ADWarning("Unable to retrieve default user group", "The default user group (SID: S-1-5-32-545) could not be found on the target system. New users will not be assigned to any group."))
        End If

        'This code is only executed the first time refreshed (i.e. on init only)
        If isLoading_ Then
            If sysSID Is Nothing Then
                sysSID = "$RND" & (New Random).Next().ToString()
                Warnings.Add(New ADWarning("Unable to retrieve system SID", "The built-in administrator account, which is used to parse the system SID, was not found on the target system. As a result, a randomly generated value will be used instead."))
            End If
            rID = "$RND" & (New Random).Next().ToString()
            isLoading_ = False
            Return
        End If

        If Not DoNotUpdateLists Then UpdateLists()
    End Sub

#Region "Rename handlers"

    ''' <summary>
    ''' Trigger a full name change in order to update the main list.
    ''' </summary>
    ''' <param name="User"></param>
    ''' <param name="newFullName"></param>
    ''' <remarks></remarks>
    Public Sub UserFullNameChanged(User As String, newFullName As String)
        UserList(User) = newFullName
        UpdateLists()
    End Sub

    Public Function RenameUser(Name As String, newName As String, parentWnd As IntPtr) As Boolean
        Dim dsuserp As DsEntry = FindUser(Name, parentWnd)
        If dsuserp IsNot Nothing AndAlso newName <> dsuserp.Name Then
            Try
                'On the local machine, WMI is used for renaming because of the better performance it provides.
                If Not IsRemoteAD() Then
                    Dim result As Integer = 0
                    Try
                        'For better performance, the WMI Win32_UserAccount class is used to invoke the rename method locally.
                        Dim wmi = GetObject("winmgmts:{impersonationLevel=impersonate}!\\localhost\root\cimv2")
                        Dim accounts = wmi.ExecQuery("Select * from Win32_UserAccount Where Name = '" & Name & "'")
                        result = accounts.ItemIndex(0).Rename(newName)
                    Catch ex As Exception
                        Dim a = ex.GetType()
                        'Fallback to DirectoryServices
                        If Not Warnings.Exists(Function(w As ADWarning) As Boolean
                                                   Return w.Title = "WMI initialization failed"
                                               End Function) Then
                            'Add a warning message if not previously done
                            Warnings.Add(New ADWarning("WMI initialization failed", "Failed to invoke WMI initialization during rename.", ex.Message))
                            mainF.ViewHandler.RefreshWarnings()
                        End If
                        dsuserp.Rename(newName)
                        dsuserp.CommitChanges()
                    End Try

                    If result <> SystemErrorCodes.SUCCESS Then
                        'Fallback to DirectoryServices to recieve further information about the error
                        dsuserp.Rename(newName)
                        dsuserp.CommitChanges()
                    End If
                Else
                    dsuserp.Rename(newName)
                    dsuserp.CommitChanges()
                End If

                Dim fullName As String = UserList(Name)
                UserList.Remove(Name)
                UserList.Add(newName, fullName)
                UpdateLists()

                RefreshDS()
                RaiseEvent OnRenameUser(Name, newName)
                Return True
            Catch ex As UnauthorizedAccessException
                ShowPermissionDeniedErr(mainF.Handle, IsRemoteAD())
                Return False
            Catch ex As Runtime.InteropServices.COMException
                If ex.ErrorCode = COMErrorCodes.GROUP_NOT_FOUND_USER Then
                    'Special case for this error; the error code does not match GROUP_ALREADY_EXISTS.
                    TaskDialog(parentWnd, "Local users and groups", "Group already exists", "There is already a group associated with that name. Please choose a different name.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                    Return False
                End If
                If ShowCOMErr(ex.ErrorCode, parentWnd, ex.Message, Name) = COMErrResult.REFRESH Then
                    RefreshDS()
                End If
                Return False
            Catch ex As Exception
                ShowUnknownErr(parentWnd, ex.Message, "Issue occurred at: RenameUser")
                Return False
            End Try
        End If
        Return False
    End Function

    Public Function RenameGroup(Name As String, newName As String, parentWnd As IntPtr) As Boolean
        Dim dsgrp As DsEntry = FindGroup(Name, parentWnd)
        If dsgrp IsNot Nothing AndAlso newName <> dsgrp.Name Then
            Try
                'On the local machine, WMI is used for renaming because of the better performance it provides.
                If Not IsRemoteAD() Then
                    Dim result As Integer = 0
                    Try
                        'For better performance, the WMI Win32_Group class is used to invoke the rename method locally.
                        Dim wmi = GetObject("winmgmts:{impersonationLevel=impersonate}!\\localhost\root\cimv2")
                        Dim groups = wmi.ExecQuery("Select * from Win32_Group Where Name = '" & Name & "'")
                        result = groups.ItemIndex(0).Rename(newName)
                    Catch ex As Exception
                        'Fallback to DirectoryServices
                        If Not Warnings.Exists(Function(w As ADWarning) As Boolean
                                                   Return w.Title = "WMI initialization failed"
                                               End Function) Then
                            'Add a warning message if not previously done
                            Warnings.Add(New ADWarning("WMI initialization failed", "Failed to invoke WMI initialization during rename.", ex.Message))
                            mainF.ViewHandler.RefreshWarnings()
                        End If
                        dsgrp.Rename(newName)
                        dsgrp.CommitChanges()
                    End Try

                    If result <> SystemErrorCodes.SUCCESS Then
                        'Fallback to DirectoryServices to recieve further information about the error
                        dsgrp.Rename(newName)
                        dsgrp.CommitChanges()
                    End If
                Else
                    dsgrp.Rename(newName)
                    dsgrp.CommitChanges()
                End If

                GroupList.Remove(Name)
                GroupList.Add(newName)
                UpdateLists()

                RefreshDS()
                RaiseEvent OnRenameGroup(Name, newName)
                Return True
            Catch ex As UnauthorizedAccessException
                ShowPermissionDeniedErr(parentWnd, IsRemoteAD())
                Return False
            Catch ex As Runtime.InteropServices.COMException
                If ShowCOMErr(ex.ErrorCode, parentWnd, ex.Message, Name) = COMErrResult.REFRESH Then
                    RefreshDS()
                End If
                Return False
            Catch ex As Exception
                ShowUnknownErr(parentWnd, ex.Message, "Issue occurred at: RenameGroup")
                Return False
            End Try
        End If
        Return False
    End Function
#End Region

#Region "Methods for creating and deleting objects"

    Public Function CreateUser(Username As String, Fullname As String) As DsEntry
        Dim newUser As DsEntry = main.Children.Add(Username, "User")
        newUser.Properties("FullName").Value = Fullname
        newUser.CommitChanges()

        UserList.Add(Username, Fullname)
        UpdateLists()
        Return newUser
    End Function

    Public Function CreateGroup(Name As String, Comment As String) As DsEntry
        Dim newGroup As DsEntry = main.Children.Add(Name, "Group")
        newGroup.Properties("Description").Value = Comment
        newGroup.CommitChanges()

        GroupList.Add(Name)
        UpdateLists()
        Return newGroup
    End Function

    Public Sub DeleteUser(Name As String, parentWnd As IntPtr, Optional pUpdateLists As Boolean = True)
        Dim user As DsEntry = FindUser(Name, parentWnd)
        If user IsNot Nothing Then
            main.Children.Remove(user)
            UserList.Remove(Name)
            If pUpdateLists Then UpdateLists()
            RaiseEvent OnDeleteUser(Name)
        End If
    End Sub

    Public Sub DeleteGroup(Name As String, parentWnd As IntPtr, Optional pUpdateLists As Boolean = True)
        Dim group As DsEntry = FindGroup(Name, parentWnd)
        If group IsNot Nothing Then
            main.Children.Remove(group)
            GroupList.Remove(Name)
            If pUpdateLists Then UpdateLists()
            RaiseEvent OnDeleteGroup(Name)
        End If
    End Sub
#End Region
End Class