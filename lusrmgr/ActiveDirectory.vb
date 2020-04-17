Imports ActiveDs
Imports System.Security.Principal
Imports System.DirectoryServices
Imports DsEntry = System.DirectoryServices.DirectoryEntry
Imports strSID = System.String
Public Class ActiveDirectory
    Private main As DirectoryEntry
    Private mForm As Form1
    Private isLoad As Boolean = True
    Private cancelToken As New Threading.CancellationTokenSource()

    Public conErr As Boolean
    Public displayName As String

    Public BuiltInSecurityPrincipals As SortedDictionary(Of strSID, String) = New SortedDictionary(Of String, String)()
    Public GroupList As SortedSet(Of String) = New SortedSet(Of String)
    Public UserList As SortedDictionary(Of String, String) = New SortedDictionary(Of String, String)

    Public UserGroup As DsEntry
    Public NoUserGroup As Boolean

    Public Shadows Function Equals(obj As ActiveDirectory) As Boolean
        If obj.main.Path = Me.main.Path Then
            Return True
        Else
            Return False
        End If
    End Function

    'Private Function GetDsEntryBySID(SID As SecurityIdentifier) As DsEntry
    '    Return New DsEntry("LDAP://<SID=" & SID.Value & ">")
    'End Function

    Private Sub RefreshBuiltInSecurityPrincipals()
        Dim tSID As SecurityIdentifier

        For Each SID As WellKnownSidType In [Enum].GetValues(GetType(WellKnownSidType))
            Try
                tSID = New SecurityIdentifier(SID, Nothing)
                BuiltInSecurityPrincipals.Add(tSID.Value, tSID.Translate(GetType(NTAccount)).Value)
            Catch ex As Exception
                Continue For
            End Try
        Next
    End Sub

    Public Sub changeDisplayName(newName As String)
        If newName = "" Then
            displayName = main.Name
        Else
            displayName = newName
        End If
    End Sub

    Public Function Name() As String
        Return main.Name
    End Function

    Public Sub Disconnect()
        If isLoading() Then
            cancelToken.Cancel()
        End If

        main.Close()
    End Sub

    Public Function UserExists(Name As String) As Boolean
        Dim usr As DsEntry = FindUser(Name, mForm.Handle)
        If usr IsNot Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GroupExists(Name As String) As Boolean
        Dim usr As DsEntry = FindGroup(Name, mForm.Handle)
        If usr IsNot Nothing Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub DeleteUser(name As String)
        Dim usr As DsEntry = FindUser(name, mForm.Handle)
        If usr IsNot Nothing Then
            main.Children.Remove(usr)
        End If
    End Sub

    Public Sub DeleteGroup(name As String)
        Dim usr As DsEntry = FindGroup(name, mForm.Handle)
        If usr IsNot Nothing Then
            main.Children.Remove(usr)
        End If
    End Sub

    Public Sub isNoLongerLoad()
        isLoad = False
    End Sub

    Public Function testConnection() As Boolean
        Try
            Dim o As Object = main.NativeObject

            If GroupList.Count + UserList.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function isLoading() As Boolean
        Return isLoad
    End Function

    Public Async Sub init()
        Try
            RefreshBuiltInSecurityPrincipals()

            Await Task.Run(AddressOf RefreshDS, cancelToken.Token)
        Catch ex As Exception
            If Not cancelToken.IsCancellationRequested Then
                conErr = True
            End If
        End Try
    End Sub

    Public Sub New(mainForm As Form1, Optional name As String = "")
        mForm = mainForm

        If name = "" Then
            displayName = Environment.MachineName
        Else
            displayName = name
        End If

        main = New DirectoryEntry("WinNT://" & Environment.MachineName)
        init()
    End Sub

    Public Sub New(addr As String, mainForm As Form1, Optional name As String = "")
        mForm = mainForm

        If name = "" Then
            displayName = addr
        Else
            displayName = name
        End If

        main = New DirectoryEntry("WinNT://" & addr)
        init()
    End Sub

    Public Sub New(addr As String, user As String, pass As String, mainForm As Form1, Optional name As String = "")
        mForm = mainForm

        If name = "" Then
            displayName = addr
        Else
            displayName = name
        End If

        main = New DirectoryEntry("WinNT://" & addr, user, pass)
        init()
    End Sub

    Public Function FindUser(Name As String, HWND As IntPtr) As DsEntry
        Try
            Return main.Children.Find(Name, "User")
        Catch ex As Runtime.InteropServices.COMException
            If ShowCOMErr(ex.ErrorCode, HWND, ex.Message, Name) Then
                RefreshDS()
                mForm.refreshItemCount()
            End If
            Return Nothing
        Catch ex As Exception
            ShowUnknownErr(HWND, ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function FindGroup(Name As String, HWND As IntPtr) As DsEntry
        Try
            Return main.Children.Find(Name, "Group")
        Catch ex As Runtime.InteropServices.COMException
            If ShowCOMErr(ex.ErrorCode, HWND, ex.Message, Name) Then
                RefreshDS()
                mForm.refreshItemCount()
            End If
            Return Nothing
        Catch ex As Exception
            ShowUnknownErr(HWND, ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function FindObject(Name As String, HWND As IntPtr) As DsEntry

        For Each Principal In BuiltInSecurityPrincipals
            If Principal.Value = Name Then
                Return New DsEntry("WinNT://" & Principal.Key)
            End If
        Next

        Try
            Return main.Children.Find(Name)
        Catch ex As Runtime.InteropServices.COMException
            If ShowCOMErr(ex.ErrorCode, HWND, ex.Message, Name) Then
                RefreshDS()
                mForm.refreshItemCount()
            End If
            Return Nothing
        Catch ex As Exception
            ShowUnknownErr(HWND, ex.Message)
            Return Nothing
        End Try
    End Function

    Public Sub RefreshDS()
        GroupList.Clear()
        UserList.Clear()

        Dim userGroupFound As Boolean = False

        For Each o As DsEntry In main.Children
            If o.SchemaClassName = "Group" Then
                GroupList.Add(o.Name)
                If Not userGroupFound AndAlso DsEntryEx.PtrToSID(o.Properties("objectSid").Value) = "S-1-5-32-545" Then
                    UserGroup = o
                    userGroupFound = True
                End If
            ElseIf o.SchemaClassName = "User" Then
                UserList.Add(o.Name, o.Properties("FullName").Value.ToString())
            End If
        Next

        If UserGroup Is Nothing Then NoUserGroup = True

        If isLoad Then
            isLoad = False
            Return
        End If

        If Not mForm.isRootNode() Then

            If mForm.tw.SelectedNode.Index = 0 AndAlso mForm.currentAD().Equals(Me) Then 'Is the current AD's User's tab selected?
                mForm.list.Items.Clear()

                For Each u As String In UserList.Keys
                    mForm.list.Items.Add(u, 0)
                Next

            ElseIf mForm.tw.SelectedNode.Index = 1 AndAlso mForm.currentAD().Equals(Me) Then 'Is the current AD's Group's tab selected?

                mForm.list.Items.Clear()

                For Each u As String In GroupList
                    mForm.list.Items.Add(u, 1)
                Next
            End If
        End If

        'If mForm.QSBar.Visible Then mForm.QuickSearch(Nothing, Nothing)
        'If mForm.QSMenu.Visible Then mForm.QuickSearch_Menu(Nothing, Nothing)

        If Not mForm.isRootNode() Then
            mForm.hiddenItems.Clear()
            mForm.QSMenu.Clear()
            mForm.QSearch.Clear()
            mForm.refreshItemCount()
        End If
    End Sub

    Public Function CreateUser(Username As String, Password As String, Fullname As String, Comment As String, Disabled As Boolean,
                                      MustChgPasswdAtNextLogon As Boolean, CannotChgPasswd As Boolean, PasswdNeverexp As Boolean,
                                      AllowReversiblePWEncryption As Boolean, PasswordNotRequired As Boolean, ForceSmartCard As Boolean,
                                      HomeDir As String, HomeDrv As String, AccountExp As Date?, AccountNeverExp As Boolean, ScriptPath As String, Times As Byte()) As DsEntry

        Dim dsNewUsr As DsEntry = main.Children.Add(Username, "User")
        Dim newUsr As IADsUser = dsNewUsr.IADsU()

        dsNewUsr.CommitChanges()

        newUsr.SetPassword(Password)

        newUsr.FullName = Fullname
        newUsr.Description = Comment

        newUsr.AccountDisabled = Disabled

        If MustChgPasswdAtNextLogon Then
            dsNewUsr.ExpirePasswd()
        Else
            dsNewUsr.RefreshExpiredPasswd()
        End If

        dsNewUsr.SetUserFlag(ADS_USER_FLAG.ADS_UF_PASSWD_NOTREQD, PasswordNotRequired)
        dsNewUsr.SetUserFlag(ADS_USER_FLAG.ADS_UF_SMARTCARD_REQUIRED, ForceSmartCard)
        dsNewUsr.SetUserFlag(ADS_USER_FLAG.ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED, AllowReversiblePWEncryption)
        dsNewUsr.SetUserFlag(ADS_USER_FLAG.ADS_UF_PASSWD_CANT_CHANGE, CannotChgPasswd)
        dsNewUsr.SetUserFlag(ADS_USER_FLAG.ADS_UF_DONT_EXPIRE_PASSWD, PasswdNeverexp)

        newUsr.HomeDirectory = HomeDir
        dsNewUsr.Properties("HomeDirDrive").Value = HomeDrv
        newUsr.LoginScript = ScriptPath
        newUsr.LoginHours = Times

        If Not AccountNeverExp Then
            newUsr.AccountExpirationDate = AccountExp
        End If

        dsNewUsr.CommitChanges()

        Return dsNewUsr
    End Function

    Public Function CreateGroup(Name As String, Comment As String) As DsEntry
        Dim newGroup As DsEntry = main.Children.Add(Name, "Group")
        newGroup.Properties("Description").Value = Comment

        Try
            newGroup.CommitChanges()
        Catch ex As Exception
            Throw
        End Try

        Return newGroup
    End Function
End Class