Imports System.Security.Principal
Imports System.Runtime.InteropServices
Module Main
    'This callback adds a shield icon to the "run as admin" command link
    Private Function TDCallback(<[In]> ByVal hWnd As IntPtr,
                              <[In]> ByVal msg As IntPtr,
                              <[In]> ByVal wParam As IntPtr,
                              <[In]> ByVal lParam As IntPtr,
                              <[In]> ByVal refData As IntPtr) As IntPtr

        If msg = TASKDIALOG_NOTIFICATIONS.TDN_CREATED Then
            SendMessage(hWnd, TASKDIALOG_MESSAGES.TDM_SET_BUTTON_ELEVATION_REQUIRED_STATE, IDYES, True)
        End If

    End Function

    Sub Main()
        Dim result As Integer = 0, verifChecked As Boolean = False

        'This code (entire try/catch block) ensures the application can be launched as a normal user
        Try
            'First, check whether we are running as administrator
            Dim Principal As New WindowsPrincipal(WindowsIdentity.GetCurrent())

            If Not Principal.IsInRole(WindowsBuiltInRole.Administrator) Then

                'If not, prompt
                Select Case cfgIntMain("UACPrompt")
                    Case UACBehaviour.PromptUAC
                        result = IDABORT 'See below why this is necessary

                        Dim elevateProc As New ProcessStartInfo(Application.ExecutablePath)
                        elevateProc.Verb = "runas"
                        elevateProc.WorkingDirectory = Environment.CurrentDirectory

                        Process.Start(elevateProc)

                        closeConfigKey()
                        Return
                    Case UACBehaviour.LaunchWithoutPrivileges
                        Exit Try
                End Select

                Dim tdc As New TASKDIALOGCONFIG
                tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)

                Dim buttons As TASKDIALOG_BUTTON() = {
                    New TASKDIALOG_BUTTON(IDYES, "Run application as administrator"),
                    New TASKDIALOG_BUTTON(IDNO, "Continue without elevation")}

                tdc.pfCallback = New TaskDialogCallbackProc(AddressOf TDCallback)
                tdc.cButtons = buttons.Length
                tdc.pButtons = arrPtr(buttons, TASKDIALOG_BUTTON.SIZE * tdc.cButtons)

                tdc.pszMainIcon = TASKDIALOG_ICONS.TD_SHIELD
                tdc.dwFlags = TASKDIALOG_FLAGS.TDF_USE_COMMAND_LINKS
                tdc.pszVerificationText = "Remember my decision"
                tdc.dwCommonButtons = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_CANCEL_BUTTON

                tdc.pszWindowTitle = "Elevation prompt - Local users and groups"
                tdc.pszMainInstruction = "Administrative privileges might be required"
                tdc.pszContent = "This application is not running with administrative privileges. Therefore, you might not be able to perform administrative tasks on this local machine, such as creating and editing users and groups. In order to obtain full functionality, you might need to authenticate as an administrator."
                TaskDialogIndirect(tdc, result, 0, verifChecked)

                For i As Integer = 0 To buttons.Length - 1
                    buttons(i).freem()
                Next
                Marshal.FreeHGlobal(tdc.pButtons)

                If result = IDYES Then

                    If verifChecked Then
                        Config.SetVal("UACPrompt", Convert.ToInt32(UACBehaviour.PromptUAC), IntPtr.Zero)
                    End If

                    Dim elevateProc As New ProcessStartInfo(Application.ExecutablePath)
                    elevateProc.Verb = "runas"
                    elevateProc.WorkingDirectory = Environment.CurrentDirectory

                    Process.Start(elevateProc)

                    closeConfigKey()
                    Return
                ElseIf result = IDNO Then
                    If verifChecked Then
                        Config.SetVal("UACPrompt", Convert.ToInt32(UACBehaviour.LaunchWithoutPrivileges), IntPtr.Zero)
                    End If
                ElseIf result = IDCANCEL Then
                    closeConfigKey()
                    Return
                End If

            End If
        Catch ex As System.ComponentModel.Win32Exception
            If result = IDABORT Then
                'Elevation aborted while it is set as standard by the user
                'Since the user won't be able to change the setting without using the registry editor
                '   and therefore unable to run the program without elevation, prompt again

                Dim tdc As New TASKDIALOGCONFIG
                tdc.cbSize = Runtime.InteropServices.Marshal.SizeOf(tdc)

                Dim buttons As TASKDIALOG_BUTTON() = {
                    New TASKDIALOG_BUTTON(IDYES, "Run application as administrator"),
                    New TASKDIALOG_BUTTON(IDNO, "Continue without elevation")}

                tdc.pfCallback = New TaskDialogCallbackProc(AddressOf TDCallback)
                tdc.cButtons = buttons.Length
                tdc.pButtons = arrPtr(buttons, TASKDIALOG_BUTTON.SIZE * tdc.cButtons)

                tdc.pszMainIcon = TASKDIALOG_ICONS.TD_SHIELD
                tdc.dwFlags = TASKDIALOG_FLAGS.TDF_USE_COMMAND_LINKS
                tdc.pszVerificationText = "Remember my decision"
                tdc.dwCommonButtons = TASKDIALOG_COMMON_BUTTON_FLAGS.TDCBF_CANCEL_BUTTON

                tdc.pszWindowTitle = "Elevation prompt - Local users and groups"
                tdc.pszMainInstruction = "User Account Control prompt declined"
                tdc.pszContent = "This application is configured to prompt for elevation when executed as a standard user account." & vbCrLf & "Do you wish to launch this application without administrative privileges?"
                TaskDialogIndirect(tdc, result, 0, verifChecked)

                For i As Integer = 0 To buttons.Length - 1
                    buttons(i).freem()
                Next
                Marshal.FreeHGlobal(tdc.pButtons)

                If result = IDYES Then

                    If verifChecked Then
                        Config.SetVal("UACPrompt", Convert.ToInt32(UACBehaviour.PromptUAC), IntPtr.Zero)
                    End If

                    Dim elevateProc As New ProcessStartInfo(Application.ExecutablePath)
                    elevateProc.Verb = "runas"
                    elevateProc.WorkingDirectory = Environment.CurrentDirectory

                    Try
                        Process.Start(elevateProc)
                    Catch ex_ As Exception
                    End Try

                    closeConfigKey()
                    Return

                ElseIf result = IDNO Then
                    If verifChecked Then
                        Config.SetVal("UACPrompt", Convert.ToInt32(UACBehaviour.LaunchWithoutPrivileges), IntPtr.Zero)
                    End If
                ElseIf result = IDCANCEL Then
                    closeConfigKey()
                    Return
                End If

            ElseIf result = IDYES Then
                'If this is executed, the user probably requested elevation, but then cancelled by clicking "no".
                closeConfigKey()
                Return
            Else
                ShowUnknownCOMErr(ex.ErrorCode, IntPtr.Zero, ex.Message)
            End If
        Catch ex As Exception
            ShowUnknownErr(IntPtr.Zero, ex.Message, "Issue occurred at: Main.vb/UACPrompt")
        End Try

        Config.initStaticFields()

        Application.SetCompatibleTextRenderingDefault(False)
        Application.EnableVisualStyles()
        Application.Run(New MainForm())

        closeConfigKey()
    End Sub
End Module
