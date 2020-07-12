Imports System.Security.Principal
Imports System.Runtime.InteropServices
Public Module BuiltIn
    Structure BuiltInPrincipal
        Public SID As String, Name As String, Description As String

        Public Sub New(pSID As String, pName As String, pDescription As String)
            SID = pSID
            Name = pName
            Description = pDescription
        End Sub

        Public ReadOnly isInvalid As Boolean
        Public Shared INVALID As New BuiltInPrincipal(True)

        Private Sub New(pInvalid As Boolean)
            isInvalid = pInvalid
        End Sub
    End Structure

    Enum WellKnownSID
        WinNullSid = 0
        WinWorldSid = 1
        WinLocalSid = 2
        WinCreatorOwnerSid = 3
        WinCreatorGroupSid = 4
        WinCreatorOwnerServerSid = 5
        WinCreatorGroupServerSid = 6
        WinNtAuthoritySid = 7
        WinDialupSid = 8
        WinNetworkSid = 9
        WinBatchSid = 10
        WinInteractiveSid = 11
        WinServiceSid = 12
        WinAnonymousSid = 13
        WinProxySid = 14
        WinEnterpriseControllersSid = 15
        WinSelfSid = 16
        WinAuthenticatedUserSid = 17
        WinRestrictedCodeSid = 18
        WinTerminalServerSid = 19
        WinRemoteLogonIdSid = 20
        WinLogonIdsSid = 21
        WinLocalSystemSid = 22
        WinLocalServiceSid = 23
        WinNetworkServiceSid = 24
        WinBuiltinDomainSid = 25
        WinBuiltinAdministratorsSid = 26
        WinBuiltinUsersSid = 27
        WinBuiltinGuestsSid = 28
        WinBuiltinPowerUsersSid = 29
        WinBuiltinAccountOperatorsSid = 30
        WinBuiltinSystemOperatorsSid = 31
        WinBuiltinPrintOperatorsSid = 32
        WinBuiltinBackupOperatorsSid = 33
        WinBuiltinReplicatorSid = 34
        WinBuiltinPreWindows2000CompatibleAccessSid = 35
        WinBuiltinRemoteDesktopUsersSid = 36
        WinBuiltinNetworkConfigurationOperatorsSid = 37
        WinAccountAdministratorSid = 38
        WinAccountGuestSid = 39
        WinAccountKrbtgtSid = 40
        WinAccountDomainAdminsSid = 41
        WinAccountDomainUsersSid = 42
        WinAccountDomainGuestsSid = 43
        WinAccountComputersSid = 44
        WinAccountControllersSid = 45
        WinAccountCertAdminsSid = 46
        WinAccountSchemaAdminsSid = 47
        WinAccountEnterpriseAdminsSid = 48
        WinAccountPolicyAdminsSid = 49
        WinAccountRasAndIasServersSid = 50
        WinNTLMAuthenticationSid = 51
        WinDigestAuthenticationSid = 52
        WinSChannelAuthenticationSid = 53
        WinThisOrganizationSid = 54
        WinOtherOrganizationSid = 55
        WinBuiltinIncomingForestTrustBuildersSid = 56
        WinBuiltinPerfMonitoringUsersSid = 57
        WinBuiltinPerfLoggingUsersSid = 58
        WinBuiltinAuthorizationAccessSid = 59
        WinBuiltinTerminalServerLicenseServersSid = 60
        WinBuiltinDCOMUsersSid = 61
        WinBuiltinIUsersSid = 62
        WinIUserSid = 63
        WinBuiltinCryptoOperatorsSid = 64
        WinUntrustedLabelSid = 65
        WinLowLabelSid = 66
        WinMediumLabelSid = 67
        WinHighLabelSid = 68
        WinSystemLabelSid = 69
        WinWriteRestrictedCodeSid = 70
        WinCreatorOwnerRightsSid = 71
        WinCacheablePrincipalsGroupSid = 72
        WinNonCacheablePrincipalsGroupSid = 73
        WinEnterpriseReadonlyControllersSid = 74
        WinAccountReadonlyControllersSid = 75
        WinBuiltinEventLogReadersGroup = 76
        WinNewEnterpriseReadonlyControllersSid = 77
        WinBuiltinCertSvcDComAccessGroup = 78
        WinMediumPlusLabelSid = 79
        WinLocalLogonSid = 80
        WinConsoleLogonSid = 81
        WinThisOrganizationCertificateSid = 82
        WinApplicationPackageAuthoritySid = 83
        WinBuiltinAnyPackageSid = 84
        WinCapabilityInternetClientSid = 85
        WinCapabilityInternetClientServerSid = 86
        WinCapabilityPrivateNetworkClientServerSid = 87
        WinCapabilityPicturesLibrarySid = 88
        WinCapabilityVideosLibrarySid = 89
        WinCapabilityMusicLibrarySid = 90
        WinCapabilityDocumentsLibrarySid = 91
        WinCapabilitySharedUserCertificatesSid = 92
        WinCapabilityEnterpriseAuthenticationSid = 93
        WinCapabilityRemovableStorageSid = 94
        WinBuiltinRDSRemoteAccessServersSid = 95
        WinBuiltinRDSEndpointServersSid = 96
        WinBuiltinRDSManagementServersSid = 97
        WinUserModeDriversSid = 98
        WinBuiltinHyperVAdminsSid = 99
        WinAccountCloneableControllersSid = 100
        WinBuiltinAccessControlAssistanceOperatorsSid = 101
        WinBuiltinRemoteManagementUsersSid = 102
        WinAuthenticationAuthorityAssertedSid = 103
        WinAuthenticationServiceAssertedSid = 104
        WinLocalAccountSid = 105
        WinLocalAccountAndAdministratorSid = 106
        WinAccountProtectedUsersSid = 107
        WinCapabilityAppointmentsSid = 108
        WinCapabilityContactsSid = 109
        WinAccountDefaultSystemManagedSid = 110
        WinBuiltinDefaultSystemManagedGroupSid = 111
        WinBuiltinStorageReplicaAdminsSid = 112
        WinAccountKeyAdminsSid = 113
        WinAccountEnterpriseKeyAdminsSid = 114
        WinAuthenticationKeyTrustSid = 115
        WinAuthenticationKeyPropertyMFASid = 116
        WinAuthenticationKeyPropertyAttestationSid = 117
        WinAuthenticationFreshKeyAuthSid = 118
        WinBuiltinDeviceOwnersSid = 119
    End Enum
End Module