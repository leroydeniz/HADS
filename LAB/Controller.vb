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

    Public Function getUserData(pEmail As String) As String()
        Dim objDataAccess = New DataAccess.DataAccess
        getUserData = objDataAccess.getUserData(pEmail)
    End Function

    Public Function recuperarPassword(pEmail As String) As Integer
        Dim objDataAccess = New DataAccess.DataAccess
        recuperarPassword = objDataAccess.recuperarPassword(pEmail)
    End Function

    Public Function cuentaVerificada(pEmail As String) As Integer
        Dim objDataAccess = New DataAccess.DataAccess
        cuentaVerificada = objDataAccess.cuentaVerificada(pEmail)
    End Function

    Public Function insertarTarea(codigo As String, descripcion As String, asignatura As String, horasEstimadas As String, tipoTarea As String) As Boolean
        Dim objDataAccess = New DataAccess.DataAccess
        insertarTarea = Nothing 'objDataAccess.insertarTarea(codigo, descripcion, asignatura, horasEstimadas, tipoTarea)
    End Function

    Public Function instanciarTarea(email As String, codTarea As String, horasEstimadas As String, horasReales As String) As Boolean
        Dim objDataAccess = New DataAccess.DataAccess
        instanciarTarea = objDataAccess.instanciarTarea(email, codTarea, horasEstimadas, horasReales)
    End Function

    Public Function getTablaTareas(codigo As String) As DataTable
        Dim objDataAccess = New DataAccess.DataAccess
        getTablaTareas = getTablaTareas(codigo)
    End Function
End Class