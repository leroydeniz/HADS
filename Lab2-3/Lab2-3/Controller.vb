Public Class Controller

    Public Function registro(pUser As String, pPass As String, pNombre As String, pApellidos As String, pTipo As String) As Integer
        Dim objDataAccess As New Lab2_3.Controller
        registro = objDataAccess.registro(pUser, pPass, pNombre, pApellidos, pTipo)
    End Function

    Public Function login(pUser As String, pPass As String) As Integer
        Dim objDataAccess As New Lab2_3.Controller
        login = objDataAccess.login(pUser, pPass)
    End Function

    Public Function verificarCuenta(pUser As String, pCodigo As String) As Integer
        Dim objDataAccess As New Lab2_3.Controller
        verificarCuenta = objDataAccess.verificarCuenta(pUser, pCodigo)
    End Function

    Public Function cambiarPassword(pUser As String, pOldPassword As String, pNewPassword As String) As Integer
        Dim objDataAccess As New Lab2_3.Controller
        cambiarPassword = objDataAccess.cambiarPassword(pUser, pOldPassword, pNewPassword)
    End Function

End Class