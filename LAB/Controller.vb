Public Class Controller

    Public Function registro(pUser As String, pPass As String, pNombre As String, pApellidos As String, pTipo As String) As Integer
        Dim objDataAccess = New DataAccess.DataAccess
        registro = objDataAccess.registro(pUser, pPass, pNombre, pApellidos, pTipo)
    End Function

    Public Function login(pUser As String, pPass As String) As Integer
        Dim objDataAccess = New DataAccess.DataAccess
        login = objDataAccess.login(pUser, pPass)
    End Function

    Public Function verificarCuenta(pUser As String, pCodigo As String) As Integer
        Dim objDataAccess = New DataAccess.DataAccess
        verificarCuenta = objDataAccess.verificarCuenta(pUser, pCodigo)
    End Function

    Public Function cambiarPassword(pUser As String, pOldPassword As String, pNewPassword As String) As Integer
        Dim objDataAccess = New DataAccess.DataAccess
        cambiarPassword = objDataAccess.cambiarPassword(pUser, pOldPassword, pNewPassword)
    End Function

    Public Function recuperarPassword(pEmail As String) As Integer
        Dim objDataAccess = New DataAccess.DataAccess
        recuperarPassword = objDataAccess.recuperarPassword(pEmail)
    End Function

    Public Function cuentaVerificada(pEmail As String) As Integer
        Dim objDataAccess = New DataAccess.DataAccess
        cuentaVerificada = objDataAccess.cuentaVerificada(pEmail)
    End Function

End Class