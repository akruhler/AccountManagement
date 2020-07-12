Imports System.Runtime.InteropServices
Module ConnectionInterop
    <Flags>
    Enum ResourceType
        RESOURCETYPE_ANY
        RESOURCETYPE_DISK
        RESOURCETYPE_PRINT
    End Enum

    <StructLayout(LayoutKind.Sequential)>
    Structure NETRESOURCE
        Public dwScope As Integer
        Public dwType As ResourceType
        Public dwDisplayType,
               dwUsage As Integer
        <MarshalAs(UnmanagedType.LPTStr)>
        Public lpLocalName,
               lpRemoteName,
               lpComment,
               lpProvider As String
    End Structure

    <Flags>
    Enum ConnectionFlags
        CONNECT_UPDATE_PROFILE = &H1
        CONNECT_UPDATE_RECENT = &H2
        CONNECT_TEMPORARY = &H4
        CONNECT_INTERACTIVE = &H8
        CONNECT_PROMPT = &H10
        CONNECT_NEED_DRIVE = &H20
        CONNECT_REFCOUNT = &H40
        CONNECT_REDIRECT = &H80
        CONNECT_LOCALDRIVE = &H100
        CONNECT_CURRENT_MEDIA = &H200
        CONNECT_DEFERRED = &H400
        CONNECT_RESERVED = &HFF000000
        CONNECT_COMMANDLINE = &H800
        CONNECT_CMD_SAVECRED = &H1000
        CONNECT_CRED_RESET = &H2000
    End Enum

    Enum SystemErrorCodes
        SUCCESS = 0
        ERROR_ACCESS_DENIED = 5
        ERROR_CANCELLED = 1223
        ERROR_SESSION_CREDENTIAL_CONFLICT = 1219
        ERROR_LOGON_FAILURE = 1326
        ERROR_NOT_CONNECTED = 2250
        ERROR_BAD_NETPATH = 53
        ERROR_BAD_NET_NAME = 67
        ERROR_NO_NETWORK = 1222
        ERROR_NO_NET_OR_BAD_PATH = 1203
        ERROR_ACCOUNT_LOCKED_OUT = 1909
    End Enum

    Declare Auto Function WNetAddConnection2 Lib "mpr.dll" (ByRef netResource As NETRESOURCE, <MarshalAs(UnmanagedType.LPTStr)> password As String, <MarshalAs(UnmanagedType.LPTStr)> username As String, flags As ConnectionFlags) As Integer
    Declare Auto Function WNetCancelConnection2 Lib "mpr.dll" (lpName As String, dwFlags As Integer, fForce As Integer) As Integer

    Async Function WNetConnectAsync(Address As String, Optional ForcePrompt As Boolean = False, Optional Username As String = Nothing, Optional Password As String = Nothing) As Task(Of SystemErrorCodes)
        Dim netr As New NETRESOURCE
        netr.dwType = ResourceType.RESOURCETYPE_ANY
        netr.lpRemoteName = "\\" & Address

        Dim flags As Integer = ConnectionFlags.CONNECT_INTERACTIVE
        If ForcePrompt Then flags = flags Or ConnectionFlags.CONNECT_PROMPT

        Return Await Task.Run(Function() As Integer
                                  Return WNetAddConnection2(netr, Password, Username, flags)
                              End Function)
    End Function

    Async Sub WNetClose(Address As String, parentWnd As IntPtr)

        Dim WNetCancelConnectionResult As SystemErrorCodes = Await Task.Run(Function() As Integer
                                                                                Return WNetCancelConnection2("\\" & Address, 0, False)
                                                                            End Function)
        If WNetCancelConnectionResult <> SystemErrorCodes.SUCCESS Then
            ShowConnectionError(WNetCancelConnectionResult, Address, parentWnd)
        End If
    End Sub

    Sub ShowConnectionError(errorCode As SystemErrorCodes, hostAddress As String, parentWnd As IntPtr)
        Dim mainInstruction As String = "",
            content As String = ""

        Select Case errorCode
            Case SystemErrorCodes.ERROR_CANCELLED, SystemErrorCodes.ERROR_NOT_CONNECTED
                Return
            Case SystemErrorCodes.ERROR_SESSION_CREDENTIAL_CONFLICT
                mainInstruction = "Multiple connections disallowed"
                content = "Multiple connections to a server or shared resource by the same user, using more than one user name, are not allowed. Disconnect all previous connections to the server or shared resource and try again."
            Case SystemErrorCodes.ERROR_LOGON_FAILURE
                mainInstruction = "Authentication failure"
                content = "The user name or password is incorrect."
            Case SystemErrorCodes.ERROR_ACCESS_DENIED
                mainInstruction = "Access denied"
                content = "The access to the system is denied. Please check your user name and password and make sure the account you are using has the desired access permissions."
            Case SystemErrorCodes.ERROR_BAD_NETPATH, SystemErrorCodes.ERROR_NO_NET_OR_BAD_PATH
                mainInstruction = "Host computer could not be reached"
                content = "The connection to """ & hostAddress & """ could not be established."
            Case SystemErrorCodes.ERROR_BAD_NET_NAME
                mainInstruction = "Host computer could not be reached"
                content = "The network name """ & hostAddress & """ cannot be found."
            Case SystemErrorCodes.ERROR_NO_NETWORK
                mainInstruction = "Network connetion unavailable"
                content = "There is no active network connection available. Please check your connection and try again."
            Case SystemErrorCodes.ERROR_ACCOUNT_LOCKED_OUT
                mainInstruction = "Account is locked out"
                content = "The account used to connect is currently locked out, as the logon attempt limit for this account has been exceeded. Please try again later or use a different account."
            Case Else
                mainInstruction = "An unknown error occurred"
                content = (New System.ComponentModel.Win32Exception(errorCode)).Message & vbCrLf & "Error code: " & errorCode & vbCrLf & "Please report this issue to the developer."
        End Select

        TaskDialog(parentWnd, "Connection error", mainInstruction, content, TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TD_ERROR_ICON, 0, True)
    End Sub
End Module
