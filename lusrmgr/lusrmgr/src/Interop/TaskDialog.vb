Imports System.Runtime.InteropServices
Imports HWND = System.IntPtr
Imports HRESULT = System.IntPtr
Imports int = System.Int32

Module TASKDIALOG_

    <DllImport("user32.dll", CharSet:=CharSet.Unicode)>
    Public Function SendMessage(ByVal hWnd As HWND, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    <DllImport("comctl32.dll", ExactSpelling:=True, CharSet:=CharSet.Unicode)>
    Function TaskDialogIndirect(
    <[In]> ByRef pTaskConfig As TASKDIALOGCONFIG, <Out> ByRef pnButton As int, <Out> ByRef pnRadioButton As int, <Out>
    <MarshalAs(UnmanagedType.Bool)> ByRef pfverificationFlagChecked As Boolean) As UInteger
    End Function

    Sub TaskDialog(ByVal hWnd As HWND, ByVal pszWindowTitle As String, ByVal pszMainInstruction As String, ByVal pszContent As String, ByVal dwCommonButtons As TASKDIALOG_COMMON_BUTTON_FLAGS, ByVal pszIcon As IntPtr, <Out> ByRef pnButton As Integer, Optional allowCancellation As Boolean = False, Optional useCustomIcon As Boolean = False)
        Dim tdc As TASKDIALOGCONFIG = New TASKDIALOGCONFIG()
        tdc.hwndParent = hWnd
        tdc.pszWindowTitle = pszWindowTitle
        tdc.pszMainInstruction = pszMainInstruction
        tdc.pszContent = pszContent
        tdc.dwCommonButtons = dwCommonButtons

        tdc.pszMainIcon = pszIcon
        If useCustomIcon Then
            tdc.dwFlags = TASKDIALOG_FLAGS.TDF_USE_HICON_MAIN
        End If
        If allowCancellation Then
            tdc.dwFlags = tdc.dwFlags Or TASKDIALOG_FLAGS.TDF_ALLOW_DIALOG_CANCELLATION
        End If

        tdc.cbSize = Convert.ToUInt32(Marshal.SizeOf(GetType(TASKDIALOGCONFIG)))

        Dim a As Integer
        Dim b As Boolean

        Try
            TaskDialogIndirect(tdc, pnButton, a, b)
        Catch ex As Exception
            MessageBox.Show("An error occurred whilst trying to show a TaskDialog. Falling back to MessageBox function." & vbCrLf & ex.Message & vbCrLf & "HRESULT: " & ex.HResult & vbCrLf & "Please report this issue to the developer.", "Error on TaskDialog", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show(pszContent, pszMainInstruction, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function arrPtr(a As Object, size As int) As IntPtr

        Dim ptr As IntPtr = Marshal.AllocHGlobal(size)
        Dim arrlength As int = size / Marshal.SizeOf(a(0).GetType())

        Dim l As Long = ptr.ToInt64()

        For i As int = 0 To arrlength - 1
            Dim tmp As New IntPtr(l)

            Marshal.StructureToPtr(a(i), tmp, False)

            l += Marshal.SizeOf(a(0).GetType())
        Next

        Return ptr
    End Function

    '* NOTE: All Message Numbers below 0x0400 are RESERVED.
    '* Private Window Messages Start Here:
    Public Const WM_USER As int = &H400
End Module

Module TASKDIALOG_ICONS
    Public ReadOnly TD_ERROR_ICON As IntPtr = New IntPtr(UInt16.MaxValue - 1),
                    TD_WARNING_ICON As IntPtr = New IntPtr(UInt16.MaxValue),
                    TD_INFORMATION_ICON As IntPtr = New IntPtr(UInt16.MaxValue - 2),
                    TD_SHIELD_ICON As IntPtr = New IntPtr(UInt16.MaxValue - 3),
                    TD_ERROR As IntPtr = New IntPtr(UInt16.MaxValue - 6),
                    TD_WARNING As IntPtr = New IntPtr(UInt16.MaxValue - 5),
                    TD_SUCCESS As IntPtr = New IntPtr(UInt16.MaxValue - 7),
                    TD_SHIELD As IntPtr = New IntPtr(UInt16.MaxValue - 4),
                    TD_GRAY_SHIELD As IntPtr = New IntPtr(UInt16.MaxValue - 8),
                    TD_APPLICATION As IntPtr = New IntPtr(UInt16.MaxValue - 99)
End Module

<Flags>
Public Enum TASKDIALOG_COMMON_BUTTON_FLAGS
    TDCBF_OK_BUTTON = &H1
    TDCBF_YES_BUTTON = &H2
    TDCBF_NO_BUTTON = &H4
    TDCBF_CANCEL_BUTTON = &H8
    TDCBF_RETRY_BUTTON = &H10
    TDCBF_CLOSE_BUTTON = &H20
End Enum

Module TASKDIALOG_RESULT
    Public Const FAIL As int = 0,
                 IDOK As int = 1,
                 IDCANCEL As int = 2,
                 IDABORT As int = 3,
                 IDRETRY As int = 4,
                 IDYES As int = 6,
                 IDNO As int = 7,
                 IDCLOSE As int = 8
End Module

<Flags>
Public Enum TASKDIALOG_FLAGS
    TDF_ENABLE_HYPERLINKS = &H1
    TDF_USE_HICON_MAIN = &H2
    TDF_USE_HICON_FOOTER = &H4
    TDF_ALLOW_DIALOG_CANCELLATION = &H8
    TDF_USE_COMMAND_LINKS = &H10
    TDF_USE_COMMAND_LINKS_NO_ICON = &H20
    TDF_EXPAND_FOOTER_AREA = &H40
    TDF_EXPANDED_BY_DEFAULT = &H80
    TDF_VERIFICATION_FLAG_CHECKED = &H100
    TDF_SHOW_PROGRESS_BAR = &H200
    TDF_SHOW_MARQUEE_PROGRESS_BAR = &H400
    TDF_CALLBACK_TIMER = &H800
    TDF_POSITION_RELATIVE_TO_WINDOW = &H1000
    TDF_RTL_LAYOUT = &H2000
    TDF_NO_DEFAULT_RADIO_BUTTON = &H4000
    TDF_CAN_BE_MINIMIZED = &H8000
    TDF_NO_SET_FOREGROUND = &H10000
    TDF_SIZE_TO_CONTENT = &H1000000
End Enum

Public Enum TASKDIALOG_MESSAGES
    TDM_NAVIGATE_PAGE = WM_USER + 101
    TDM_CLICK_BUTTON = WM_USER + 102                        ' wParam = Button ID
    TDM_SET_MARQUEE_PROGRESS_BAR = WM_USER + 103            ' wParam = 0 (nonMarque) wParam != 0 (Marquee)
    TDM_SET_PROGRESS_BAR_STATE = WM_USER + 104              ' wParam = new progress state
    TDM_SET_PROGRESS_BAR_RANGE = WM_USER + 105              ' lParam = MAKELPARAM(nMinRange, nMaxRange)
    TDM_SET_PROGRESS_BAR_POS = WM_USER + 106                ' wParam = new position
    TDM_SET_PROGRESS_BAR_MARQUEE = WM_USER + 107            ' wParam = 0 (stop marquee), wParam != 0 (start marquee), lparam = speed (milliseconds between repaints)
    TDM_SET_ELEMENT_TEXT = WM_USER + 108                    ' wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
    TDM_CLICK_RADIO_BUTTON = WM_USER + 110                  ' wParam = Radio Button ID
    TDM_ENABLE_BUTTON = WM_USER + 111                       ' lParam = 0 (disable), lParam != 0 (enable), wParam = Button ID
    TDM_ENABLE_RADIO_BUTTON = WM_USER + 112                 ' lParam = 0 (disable), lParam != 0 (enable), wParam = Radio Button ID
    TDM_CLICK_VERIFICATION = WM_USER + 113                  ' wParam = 0 (unchecked), 1 (checked), lParam = 1 (set key focus)
    TDM_UPDATE_ELEMENT_TEXT = WM_USER + 114                 ' wParam = element (TASKDIALOG_ELEMENTS), lParam = new element text (LPCWSTR)
    TDM_SET_BUTTON_ELEVATION_REQUIRED_STATE = WM_USER + 115 ' wParam = Button ID, lParam = 0 (elevation not required), lParam != 0 (elevation required)
    TDM_UPDATE_ICON = WM_USER + 116                         ' wParam = icon element (TASKDIALOG_ICON_ELEMENTS), lParam = new icon (hIcon if TDF_USE_HICON_* was set, PCWSTR otherwise)
End Enum

Public Enum TASKDIALOG_NOTIFICATIONS
    TDN_CREATED = 0
    TDN_NAVIGATED = 1
    TDN_BUTTON_CLICKED = 2              'wParam = Button ID
    TDN_HYPERLINK_CLICKED = 3           'lParam = (LPCWSTR)pszHREF
    TDN_TIMER = 4                       'wParam = Milliseconds since dialog created or timer reset
    TDN_DESTROYED = 5
    TDN_RADIO_BUTTON_CLICKED = 6        'wParam = Radio Button ID
    TDN_DIALOG_CONSTRUCTED = 7
    TDN_VERIFICATION_CLICKED = 8        'wParam = 1 if checkbox checked, 0 if not, lParam is unused and always 0
    TDN_HELP = 9            '
    TDN_EXPANDO_BUTTON_CLICKED = 10     'wParam = 0 (dialog is now collapsed), wParam != 0 (dialog is now expanded)
End Enum

<UnmanagedFunctionPointer(CallingConvention.Winapi)>
Public Delegate Function TaskDialogCallbackProc(
<[In]> ByVal hWnd As HWND,
<[In]> ByVal msg As IntPtr,
<[In]> ByVal wParam As IntPtr,
<[In]> ByVal lParam As IntPtr,
<[In]> ByVal refData As IntPtr) As HRESULT

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode, Pack:=1)>
Structure TASKDIALOG_BUTTON
    Public nButtonID As int
    Public pszButtonText As IntPtr
    Public Shared ReadOnly SIZE As int = Marshal.SizeOf(GetType(TASKDIALOG_BUTTON))

    Sub New(id As int, text As String)
        nButtonID = id
        pszButtonText = Marshal.StringToHGlobalUni(text)
    End Sub

    Sub freem()
        Marshal.FreeHGlobal(pszButtonText)
    End Sub
End Structure

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode, Pack:=1)>
Public Structure TASKDIALOGCONFIG
    Public cbSize As UInteger
    Public hwndParent As IntPtr
    Public hInstance As IntPtr
    Public dwFlags As TASKDIALOG_FLAGS
    Public dwCommonButtons As TASKDIALOG_COMMON_BUTTON_FLAGS
    <MarshalAs(UnmanagedType.LPWStr)>
    Public pszWindowTitle As String
    Public pszMainIcon As IntPtr
    <MarshalAs(UnmanagedType.LPWStr)>
    Public pszMainInstruction As String
    <MarshalAs(UnmanagedType.LPWStr)>
    Public pszContent As String
    Public cButtons As UInteger
    Public pButtons As IntPtr
    Public nDefaultButton As Integer
    Public cRadioButtons As UInteger
    Public pRadioButtons As IntPtr
    Public nDefaultRadioButton As Integer
    <MarshalAs(UnmanagedType.LPWStr)>
    Public pszVerificationText As String
    <MarshalAs(UnmanagedType.LPWStr)>
    Public pszExpandedInformation As String
    <MarshalAs(UnmanagedType.LPWStr)>
    Public pszExpandedControlText As String
    <MarshalAs(UnmanagedType.LPWStr)>
    Public pszCollapsedControlText As String
    Public hFooterIcon As IntPtr
    <MarshalAs(UnmanagedType.LPWStr)>
    Public pszFooter As String
    Public pfCallback As TaskDialogCallbackProc
    Public lpCallbackData As IntPtr
    Public cxWidth As UInteger
End Structure