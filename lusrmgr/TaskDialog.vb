Imports System
Imports System.Runtime.InteropServices
Imports HWND = System.IntPtr
Imports HINSTANCE = System.IntPtr
Imports PCWSTR = System.String
Imports LPCWSTR = System.IntPtr
Imports int = System.Int32
Imports auto = System.Object

Module TASKDIALOG
    <DllImport("comctl32.dll", ExactSpelling:=True, CharSet:=CharSet.Unicode)>
    Function TaskDialogIndirect(
    <[In]> ByRef pTaskConfig As TASKDIALOGCONFIG, <Out> ByRef pnButton As int, <Out> ByRef pnRadioButton As int, <Out>
    <MarshalAs(UnmanagedType.Bool)> ByRef pfverificationFlagChecked As Boolean) As UInteger
    End Function

    Sub TaskDialog(ByVal hWnd As HWND, ByVal hInstance As HINSTANCE, ByVal pszWindowTitle As PCWSTR, ByVal pszMainInstruction As PCWSTR, ByVal pszContent As PCWSTR, ByVal dwCommonButtons As TASKDIALOG_COMMON_BUTTON_FLAGS, ByVal pszIcon As IntPtr, <Out> ByRef pnButton As Integer)
        Dim tdc As TASKDIALOGCONFIG = New TASKDIALOGCONFIG()
        tdc.hwndParent = hWnd
        tdc.hInstance = hInstance
        tdc.pszWindowTitle = pszWindowTitle
        tdc.pszMainInstruction = pszMainInstruction
        tdc.pszContent = pszContent
        tdc.dwCommonButtons = dwCommonButtons
        tdc.pszMainIcon = pszIcon
        tdc.cbSize = CUInt(Marshal.SizeOf(GetType(TASKDIALOGCONFIG)))
        Dim a As Integer
        Dim b As Boolean
        TaskDialogIndirect(tdc, pnButton, a, b)
    End Sub

    Function sizeof(a As auto) As int
        Return Marshal.SizeOf(a)
    End Function

    Sub free(a As HINSTANCE)
        Marshal.FreeHGlobal(a)
    End Sub

    Function arrPtr(a As auto, size As int) As HINSTANCE

        Dim ptr As IntPtr = Marshal.AllocHGlobal(size)
        Dim arrlength As int = size / Marshal.SizeOf(a(0).GetType())

        Dim l As Long = ptr.ToInt64()

        For i As int = 0 To arrlength - 1
            Dim tmp As New IntPtr(l)

            Marshal.StructureToPtr(a(i), tmp, False)

            l += Marshal.SizeOf(GetType(TASKDIALOG_BUTTON))
        Next

        Return ptr
    End Function

    Public nullptr As HINSTANCE = HINSTANCE.Zero
End Module

Module TASKDIALOG_ICONS
    Public TD_ERROR_ICON As HINSTANCE = New HINSTANCE(UInt16.MaxValue - 1), TD_WARNING_ICON As HINSTANCE = New HINSTANCE(UInt16.MaxValue), TD_INFORMATION_ICON As HINSTANCE = New HINSTANCE(UInt16.MaxValue - 2), TD_SHIELD_ICON As HINSTANCE = New HINSTANCE(UInt16.MaxValue - 3), TD_ERROR As HINSTANCE = New HINSTANCE(UInt16.MaxValue - 6), TD_WARNING As HINSTANCE = New HINSTANCE(UInt16.MaxValue - 5), TD_SUCCESS As HINSTANCE = New HINSTANCE(UInt16.MaxValue - 7), TD_SHIELD As HINSTANCE = New HINSTANCE(UInt16.MaxValue - 4), TD_GRAY_SHIELD As HINSTANCE = New HINSTANCE(UInt16.MaxValue - 8)
End Module

Structure TASKDIALOG_BUTTON
    Public nButtonID As int
    Public pszButtonText As LPCWSTR
    Public Shared ReadOnly SIZE As int = Marshal.SizeOf(GetType(TASKDIALOG_BUTTON))

    Sub New(id As int, text As PCWSTR)
        nButtonID = id
        pszButtonText = Marshal.StringToHGlobalUni(text)
    End Sub

    Sub freem()
        free(pszButtonText)
    End Sub
End Structure

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
    Public FAIL As int = 0,
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

<UnmanagedFunctionPointer(CallingConvention.Winapi)>
Public Delegate Function TaskDialogCallbackProc(
<[In]> ByVal hwnd As HWND,
<[In]> ByVal msg As HINSTANCE,
<[In]> ByVal wParam As HINSTANCE,
<[In]> ByVal lParam As HINSTANCE,
<[In]> ByVal refData As HINSTANCE) As HINSTANCE

<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
Public Structure TASKDIALOGCONFIG
    Public cbSize As UInteger
    Public hwndParent As IntPtr
    Public hInstance As IntPtr
    Public dwFlags As TASKDIALOG_FLAGS
    Public dwCommonButtons As TASKDIALOG_COMMON_BUTTON_FLAGS
    Public pszWindowTitle As String
    Public pszMainIcon As IntPtr
    Public pszMainInstruction As String
    Public pszContent As String
    Public cButtons As UInteger
    Public pButtons As IntPtr
    Public nDefaultButton As Integer
    Public cRadioButtons As UInteger
    Public pRadioButtons As IntPtr
    Public nDefaultRadioButton As Integer
    Public pszVerificationText As String
    Public pszExpandedInformation As String
    Public pszExpandedControlText As String
    Public pszCollapsedControlText As String
    Public hFooterIcon As IntPtr
    Public pszFooter As String
    Public pfCallback As TaskDialogCallbackProc
    Public lpCallbackData As IntPtr
    Public cxWidth As UInteger
End Structure