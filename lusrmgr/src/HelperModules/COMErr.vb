Imports System.Runtime.InteropServices
Module COMErr
    Enum COMErrorCodes
        USER_ALREADY_EXISTS = -2147022672
        GROUP_ALREADY_EXISTS = -2147023517
        PW_POLICY = -2147022651
        GROUP_NOT_FOUND = -2147022676
        USER_NOT_FOUND = -2147022675
        USER_NOT_FOUND_GROUP = &H80005004
        GROUP_NOT_FOUND_USER = &H80070560
        ADMIN_DEACTIVATION = &H8007052A
        ILLEGAL_USERNAME = &H8007089A
        BLOCKED_BUILTIN = &H8007055B
        GROUPADD_KNOWNACCOUNT = &H8007056C
        ERROR_INCORRECT_ACCOUNT_TYPE = &H800721C6
        USER_ALREADY_IN_GROUP = &H80070562
        USER_NOT_IN_GROUP = &H80070561
        ACCOUNT_INEXISTENT = &H8007056B
        RPC_CONNECTION_UNAVAILALBE = &H800706BA
    End Enum

    Enum COMErrResult
        _FALSE = 0
        REFRESH = 1
        LOOP_CONTINUE = 2
        UNKOWN_ERR = 3
    End Enum

    Sub ShowPermissionDeniedErr(parentWnd As IntPtr)
        TaskDialog(parentWnd, "Local users and groups", "Access denied", "You are not allowed to perform this operation." & vbCrLf & "Please contact your system administrator or run this program with enough privileges.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
    End Sub

    Sub ShowUnknownErr(parentWnd As IntPtr, exMsg As String, Optional additional As String = "")

        Dim body As String = ""

        If additional = "" Then
            body = exMsg.Replace(vbCrLf, "") & vbCrLf & "Please report this issue to the developer."
        Else
            body = exMsg.Replace(vbCrLf, "") & vbCrLf & additional & vbCrLf & "Please report this issue to the developer."
        End If

        TaskDialog(parentWnd, "Local users and groups", "An unkown error occurred", body, TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TD_ERROR_ICON, Nothing)
    End Sub

    Sub ShowUnknownCOMErr(errCode As Int32, parentWnd As IntPtr, exMsg As String)

        Dim result As Integer

        Dim tdc As New TASKDIALOGCONFIG
        tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)

        Dim buttons As TASKDIALOG_BUTTON() = {
            New TASKDIALOG_BUTTON(IDYES, "Copy to clipboard"),
            New TASKDIALOG_BUTTON(IDCANCEL, "OK")}

        tdc.cButtons = buttons.Length
        tdc.pButtons = arrPtr(buttons, TASKDIALOG_BUTTON.SIZE * tdc.cButtons)

        tdc.hwndParent = parentWnd
        tdc.pszMainIcon = TASKDIALOG_ICONS.TD_ERROR_ICON
        tdc.nDefaultButton = TASKDIALOG_RESULT.IDCANCEL

        tdc.pszWindowTitle = "Local users and groups"
        tdc.pszMainInstruction = "An unkown error occurred"
        tdc.pszContent = exMsg.Replace(vbCrLf, "") & vbCrLf & vbCrLf & "Error code: 0x" & Hex(errCode) & vbCrLf & "Please report this issue to the developer."

        TaskDialogIndirect(tdc, result, 0, 0)

        For i As Integer = 0 To buttons.Length - 1
            buttons(i).freem()
        Next
        Marshal.FreeHGlobal(tdc.pButtons)

        If result = IDYES Then
            Clipboard.SetText(exMsg.Replace(vbCrLf, "") & " (0x" & Hex(errCode) & ")")
        End If
    End Sub

    Function ShowCOMErr(errCode As Int32, parentWnd As IntPtr, exMsg As String, Optional w As String = "") As COMErrResult

        If errCode = COMErrorCodes.USER_NOT_FOUND_GROUP Then errCode = COMErrorCodes.USER_NOT_FOUND
        If errCode = COMErrorCodes.GROUP_NOT_FOUND_USER Then errCode = COMErrorCodes.GROUP_NOT_FOUND

        Select Case errCode
            Case COMErrorCodes.USER_ALREADY_EXISTS
                TaskDialog(parentWnd, "Local users and groups", "Account already exists", "There is already an account with the same name. Please choose a different name.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                Return False
            Case COMErrorCodes.GROUP_ALREADY_EXISTS
                TaskDialog(parentWnd, "Local users and groups", "Group already exists", "There is already a group associated with that name. Please choose a different name.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                Return False
            Case COMErrorCodes.PW_POLICY
                TaskDialog(parentWnd, "Account password", "Password could not be changed", "The password you entered does not meet the password policy requirements. Check the minimum password length, password complexity and password history requirements.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                Return False
            Case COMErrorCodes.ADMIN_DEACTIVATION
                TaskDialog(parentWnd, "Local users and groups", "Operation disallowed", exMsg.Replace(vbCrLf, ""), TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                Return False
            Case COMErrorCodes.ILLEGAL_USERNAME
                TaskDialog(parentWnd, "Local users and groups", "Username could not be changed", "The specified username is invalid. Please use a different name.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                Return False
            Case COMErrorCodes.BLOCKED_BUILTIN
                TaskDialog(parentWnd, "Local users and groups", "Operation cannot be performed", "Cannot perform this operation on built-in accounts.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                Return False
            Case COMErrorCodes.USER_ALREADY_IN_GROUP
                TaskDialog(parentWnd, "Local users and groups", "User is already member of group", "The user is already member of the target group and therefore cannot be added.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                Return COMErrResult.LOOP_CONTINUE
            Case COMErrorCodes.USER_NOT_IN_GROUP
                TaskDialog(parentWnd, "Local users and groups", "User is not a member of group", "The user is not a member of the target group and therefore cannot be removed.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                Return COMErrResult.LOOP_CONTINUE
            Case COMErrorCodes.RPC_CONNECTION_UNAVAILALBE
                TaskDialog(parentWnd, "Local users and groups", "Connection unavailable", "The remote procedure call failed. Please check your connection and try again.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TD_ERROR_ICON, 0)
                Return False
            Case COMErrorCodes.ACCOUNT_INEXISTENT
                Dim result As Integer

                Dim tdc As New TASKDIALOGCONFIG
                tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)

                Dim buttons As TASKDIALOG_BUTTON() = {New TASKDIALOG_BUTTON(IDOK, "Refresh")}
                tdc.cButtons = buttons.Length
                tdc.pButtons = arrPtr(buttons, TASKDIALOG_BUTTON.SIZE * tdc.cButtons)

                tdc.hwndParent = parentWnd
                tdc.pszMainIcon = TASKDIALOG_ICONS.TD_WARNING_ICON

                tdc.pszWindowTitle = "Local users and groups"
                tdc.pszMainInstruction = "Object could not be found"

                tdc.pszContent = "The object """ & w & """ was not found in the account database."

                tdc.pszCollapsedControlText = "Why does this occurr?"
                tdc.pszExpandedControlText = "Why does this occurr?"
                tdc.pszExpandedInformation = "This issue can occurr if e.g. changes were made by another program or other remotely connected computers which are not applied here. A refresh will be performed in order to update the cache with the new changes."

                TaskDialogIndirect(tdc, result, 0, 0)

                For i As Integer = 0 To buttons.Length - 1
                    buttons(i).freem()
                Next
                Marshal.FreeHGlobal(tdc.pButtons)

                Return COMErrResult.REFRESH
            Case COMErrorCodes.GROUP_NOT_FOUND

                Dim result As Integer

                Dim tdc As New TASKDIALOGCONFIG
                tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)

                Dim buttons As TASKDIALOG_BUTTON() = {New TASKDIALOG_BUTTON(IDOK, "Refresh")}
                tdc.cButtons = buttons.Length
                tdc.pButtons = arrPtr(buttons, TASKDIALOG_BUTTON.SIZE * tdc.cButtons)

                tdc.hwndParent = parentWnd
                tdc.pszMainIcon = TASKDIALOG_ICONS.TD_WARNING_ICON

                tdc.pszWindowTitle = "Local users and groups"
                tdc.pszMainInstruction = "Group could not be found"
                tdc.pszContent = "The group """ & w & """ was not found in the account database."

                tdc.pszCollapsedControlText = "Why does this occurr?"
                tdc.pszExpandedControlText = "Why does this occurr?"
                tdc.pszExpandedInformation = "This issue can occurr if e.g. changes were made by another program or other remotely connected computers which are not applied here. A refresh will be performed in order to update the cache with the new changes."

                TaskDialogIndirect(tdc, result, 0, 0)

                For i As Integer = 0 To buttons.Length - 1
                    buttons(i).freem()
                Next
                Marshal.FreeHGlobal(tdc.pButtons)

                Return COMErrResult.REFRESH

            Case COMErrorCodes.USER_NOT_FOUND

                Dim result As Integer

                Dim tdc As New TASKDIALOGCONFIG
                tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)

                Dim buttons As TASKDIALOG_BUTTON() = {New TASKDIALOG_BUTTON(IDOK, "Refresh")}
                tdc.cButtons = buttons.Length
                tdc.pButtons = arrPtr(buttons, TASKDIALOG_BUTTON.SIZE * tdc.cButtons)

                tdc.hwndParent = parentWnd
                tdc.pszMainIcon = TASKDIALOG_ICONS.TD_WARNING_ICON

                tdc.pszWindowTitle = "Local users and groups"
                tdc.pszMainInstruction = "User could not be found"

                tdc.pszContent = "The user """ & w & """ was not found in the account database."

                tdc.pszCollapsedControlText = "Why does this occurr?"
                tdc.pszExpandedControlText = "Why does this occurr?"
                tdc.pszExpandedInformation = "This issue can occurr if e.g. changes were made by another program or other remotely connected computers which are not applied here. A refresh will be performed in order to update the cache with the new changes."

                TaskDialogIndirect(tdc, result, 0, 0)

                For i As Integer = 0 To buttons.Length - 1
                    buttons(i).freem()
                Next
                Marshal.FreeHGlobal(tdc.pButtons)

                Return COMErrResult.REFRESH

            Case COMErrorCodes.GROUPADD_KNOWNACCOUNT
                TaskDialog(parentWnd, "Local users and groups", "Operation cannot be performed on built-in accounts", "System-defined groups cannot be members of predefined security principals.", TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_OK_BUTTON, TASKDIALOG_ICONS.TD_ERROR_ICON, 0)
                Return False
            Case COMErrorCodes.ERROR_INCORRECT_ACCOUNT_TYPE

                Dim result As Integer

                Dim tdc As New TASKDIALOGCONFIG
                tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)

                Dim buttons As TASKDIALOG_BUTTON() = {New TASKDIALOG_BUTTON(IDOK, "OK"), New TASKDIALOG_BUTTON(100, "Copy error code")}
                tdc.cButtons = buttons.Length
                tdc.pButtons = arrPtr(buttons, TASKDIALOG_BUTTON.SIZE * tdc.cButtons)

                tdc.hwndParent = parentWnd
                tdc.pszMainIcon = TASKDIALOG_ICONS.TD_ERROR_ICON
                tdc.dwFlags = TASKDIALOG_FLAGS.TDF_ALLOW_DIALOG_CANCELLATION

                tdc.pszWindowTitle = "Cannot make changes to account"
                tdc.pszMainInstruction = "System is not authoritative for the account"

                tdc.pszContent = "The system is not authoritative for the specified account and therefore cannot complete the operation. Please retry the operation using the provider associated with this account. If this is an online provider please use the provider's online site." &
                    vbCrLf & vbCrLf & "Error code: 0x" & Hex(errCode)

                tdc.pszCollapsedControlText = "Why does this occurr?"
                tdc.pszExpandedControlText = "Why does this occurr?"
                tdc.pszExpandedInformation = "This issue can occurr whilst trying to make changes to a Microsoft account linked to your computer, not to a local account." &
                                                " To make changes to Microsoft accounts, use the Windows settings or visit your account page online."

                TaskDialogIndirect(tdc, result, 0, 0)

                For i As Integer = 0 To buttons.Length - 1
                    buttons(i).freem()
                Next
                Marshal.FreeHGlobal(tdc.pButtons)

                If result = 100 Then
                    Clipboard.SetText("0x" & Hex(errCode))
                End If

                Return False

            Case Else
                ShowUnknownCOMErr(errCode, parentWnd, exMsg)
                Return COMErrResult.UNKOWN_ERR
        End Select
    End Function
End Module