Imports Microsoft.Win32
Module Main
    Sub Main()

        If Registry.CurrentUser.OpenSubKey("SOFTWARE\lusrmgr", True) Is Nothing Then
            Registry.CurrentUser.CreateSubKey("SOFTWARE\lusrmgr", True)
        End If

        Application.SetCompatibleTextRenderingDefault(False)
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub
End Module
