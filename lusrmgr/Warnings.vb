Public Class Warnings
    Overloads Sub Show(mainForm As Form1)

        CheckBox1.Checked = Not Convert.ToBoolean(cfgBool("HideWarningTime"))
        CheckBox2.Checked = Not Convert.ToBoolean(cfgBool("HideWarningCantchgpasswd"))
        CheckBox3.Checked = Not Convert.ToBoolean(cfgBool("HideDisabledFlagInfo"))
        CheckBox4.Checked = Not Convert.ToBoolean(cfgBool("HideUserWithNoGroupWarning"))

        ShowDialog()

        If DialogResult = Windows.Forms.DialogResult.OK Then
            If Config.SetVal("HideWarningTime", Convert.ToInt32(Not CheckBox1.Checked), Handle) = False Then Return
            If Config.SetVal("HideWarningCantchgpasswd", Convert.ToInt32(Not CheckBox2.Checked), Handle) = False Then Return
            If Config.SetVal("HideDisabledFlagInfo", Convert.ToInt32(Not CheckBox3.Checked), Handle) = False Then Return
            If Config.SetVal("HideUserWithNoGroupWarning", Convert.ToInt32(Not CheckBox4.Checked), Handle) = False Then Return
        End If
        Dispose()
    End Sub
End Class