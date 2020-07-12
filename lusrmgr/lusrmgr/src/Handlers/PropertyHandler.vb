Class PropertyHandler_C
    Private mainF As MainForm

    Public Sub New(mainForm As MainForm)
        mainF = mainForm
    End Sub

    ''' <summary>
    ''' Indicates whether new users and groups can be created.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CanCreateNew As Boolean
        Get
            Return mainF.CreateNewUserTS.Enabled
        End Get
        Set(value As Boolean)
            mainF.CreateNewUserTS.Enabled = value
            mainF.CreateNewGroupTS.Enabled = value
            mainF.tAdd.Enabled = value
        End Set
    End Property

    ''' <summary>
    ''' Indicates whether the edit and rename menu items showing in "users" should be enabled, as well as the tool strip buttons.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CanEditUsers As Boolean
        Get
            Return mainF.EditUserTS.Enabled
        End Get
        Set(value As Boolean)
            mainF.EditUserTS.Enabled = value
            mainF.RenameUserTS.Enabled = value

            mainF.tRename.Enabled = CanEditGroups Or value
            mainF.tEdit.Enabled = CanEditGroups Or value
        End Set
    End Property

    ''' <summary>
    ''' Indicates whether the edit and rename menu items showing in "groups" should be enabled, as well as the tool strip buttons.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CanEditGroups As Boolean
        Get
            Return mainF.EditGroupTS.Enabled
        End Get
        Set(value As Boolean)
            mainF.EditGroupTS.Enabled = value
            mainF.RenameGroupTS.Enabled = value

            mainF.tRename.Enabled = CanEditUsers Or value
            mainF.tEdit.Enabled = CanEditUsers Or value
        End Set
    End Property

    Public Property CanDeleteUsers As Boolean
        Get
            Return mainF.DeleteUserTS.Enabled
        End Get
        Set(value As Boolean)
            mainF.DeleteUserTS.Enabled = value
            mainF.tDelete.Enabled = CanDeleteGroups Or value
        End Set
    End Property

    Public Property CanDeleteGroups As Boolean
        Get
            Return mainF.DeleteGroupTS.Enabled
        End Get
        Set(value As Boolean)
            mainF.DeleteGroupTS.Enabled = value
            mainF.tDelete.Enabled = CanDeleteUsers Or value
        End Set
    End Property
End Class
