Imports System.Net.Mail
Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class DataAccess

    Private Shared conexion As New SqlConnection 'variable de conexión global'
    Private Shared excepcion As String = "" 'variable de excepción global'
    Private Shared comando As New SqlCommand
    Private Shared HashedPass As String = ""
    Private Shared OldHashedPass As String = ""





    '*************' FUNCIONES DE ACCESO *************'

    Public Function registro(ByVal pUser As String, ByVal pPass As String, ByVal pNombre As String, ByVal pApellidos As String, ByVal pTipo As String) As Integer
        If openConnection() Then

            'Verifico que el usuario no existe previamente en la bd'
            Dim st As String = "select count(*) from Usuarios where email='" & pUser & "';"
            Dim comando = New SqlCommand(st, conexion)
            Dim count As Integer = comando.ExecuteScalar()

            Console.WriteLine(st)

            '0 - Usuario ya existe'
            '1 - Error de conexión a la base de datos
            '2 - Error de inserción en la base de datos'
            '3 - Registro correcto'
            '3 - Fallo en envío de mail'

            If count = 1 Then
                'MsgBox("DEBUG: DataAccess >> usuario ya existe (primer if).")'
                closeConnection()
                Return 0
            Else
                'Encripto la contraseña'
                Using SHA1hash As SHA1 = SHA1.Create()
                    HashedPass = System.Convert.ToBase64String(SHA1hash.ComputeHash(System.Text.Encoding.ASCII.GetBytes(pPass)))
                End Using

                Randomize()
                Dim randomNumber As Integer = CInt(Int((3000 * Rnd()) + 1))

                'Definir y ejecutar la consulta'
                st = "insert into Usuarios(email, nombre, apellidos, numconfir, confirmado, tipo, pass) values('" & pUser & "', '" & pNombre & "', '" & pApellidos & "', '" & randomNumber & "', 0, '" & pTipo & "', '" & HashedPass & "');"
                comando = New SqlCommand(st, conexion)
                Try
                    count = comando.ExecuteNonQuery()
                    closeConnection()

                    Dim mailEnviado As Boolean = enviarEmail(pUser, pNombre, randomNumber)

                    If mailEnviado Then
                        'Todo correcto'
                        closeConnection()
                        Return 3
                    Else
                        'Email no enviado'
                        closeConnection()
                        Return 4
                    End If

                Catch ex As Exception
                    'MsgBox("DEBUG: DataAccess >> error de inserción (segundo if). " + ex.Message)'
                    closeConnection()
                    Return 2
                End Try
            End If

        Else
            'BD no conectada'
            'MsgBox("*** Error de conexión al servidor de BD: " + excepcion + "***")'
            closeConnection()
            Return 1
        End If
    End Function




    Public Function login(ByVal pUser As String, ByVal pPass As String) As Integer

        If openConnection() Then

            Using SHA1hash As SHA1 = SHA1.Create()
                HashedPass = System.Convert.ToBase64String(SHA1hash.ComputeHash(System.Text.Encoding.ASCII.GetBytes(pPass)))
            End Using

            '0 - Error de conexión a la base de datos'
            '1 - Usuario registrado y verificado'
            '2 - Usuario registrado sin verificar'
            '3 - Usuario no existe'

            'Definir y ejecutar la consulta'
            Dim st As String = "select count(*) from Usuarios where email='" & pUser & "' and pass='" & HashedPass & "' and confirmado='True';"
            comando = New SqlCommand(st, conexion)
            Dim count As Integer = comando.ExecuteScalar()

            If count = 1 Then
                closeConnection()
                Return 1
            Else
                'Verificar que el usuario existe pero no está confirmado'
                st = "select count(*) from Usuarios where email='" & pUser & "' and pass='" & HashedPass & "' and confirmado='False';"
                comando = New SqlCommand(st, conexion)
                count = comando.ExecuteScalar()

                closeConnection()
                If count = 1 Then
                    closeConnection()
                    Return 2
                Else
                    closeConnection()
                    Return 3
                End If
            End If
        Else
            'BD no conectada'
            MsgBox(" Error de conexión al servidor de BD: " + excepcion + "")
            closeConnection()
            Return 0
        End If
    End Function



    Public Function verificarCuenta(pUser As String, pCodigo As String) As Integer

        If openConnection() Then

            '0 - Error de conexión a la base de datos'
            '1 - Usuario ya confirmado'
            '2 - Usuario no existe en db'
            '3 - Usuario confirmado correctamente'
            '4 - Error de actualización de db'
            '5 - Código incorrecto'

            'Confirmo que el usuario existe'
            Dim st As String = "select count(*) from Usuarios where email='" & pUser & "' and confirmado='True';"
            comando = New SqlCommand(st, conexion)
            Dim count As Integer = comando.ExecuteScalar()

            If count = 1 Then
                closeConnection()
                Return 1
            Else
                'Verificar que el usuario existe pero no está confirmado'
                st = "select count(*) from Usuarios where email='" & pUser & "' and confirmado='False';"
                comando = New SqlCommand(st, conexion)
                count = comando.ExecuteScalar()

                If count = 1 Then

                    'Verificar que el usuario existe pero no está confirmado'
                    st = "select numconfir from Usuarios where email='" & pUser & "';"
                    comando = New SqlCommand(st, conexion)
                    count = comando.ExecuteScalar()

                    'Verificar el código de confirmación'
                    If count = pCodigo Then
                        Try
                            st = "UPDATE Usuarios SET confirmado='True' WHERE email='" & pUser & "';"
                            comando = New SqlCommand(st, conexion)
                            comando.ExecuteNonQuery()
                            closeConnection()
                            Return 3
                        Catch ex As Exception
                            closeConnection()
                            Return 4
                        End Try
                    Else
                        closeConnection()
                        Return 5
                    End If
                Else
                    'Usuario no existe'
                    closeConnection()
                    Return 2
                End If

            End If

        Else
            'BD no conectada'
            'MsgBox(" Error de conexión al servidor de BD: " + excepcion + "")'
            closeConnection()
            Return 0
        End If


    End Function



    Public Function cambiarPassword(pUser As String, pOldPassword As String, pNewPassword As String) As Integer

        If openConnection() Then


            Using SHA1hash As SHA1 = SHA1.Create()
                HashedPass = System.Convert.ToBase64String(SHA1hash.ComputeHash(System.Text.Encoding.ASCII.GetBytes(pNewPassword)))
            End Using

            Using SHA1hash As SHA1 = SHA1.Create()
                OldHashedPass = System.Convert.ToBase64String(SHA1hash.ComputeHash(System.Text.Encoding.ASCII.GetBytes(pOldPassword)))
            End Using

            '0 - Error de conexión a la base de datos'
            '1 - Usuario o contraseña incorrectos'
            '2 - Error de actualización de contraseña'
            '3 - Contraseña cambiada exitosamente'

            'Confirmo que el usuario existe'
            Dim st As String = "select count(*) from Usuarios where email='" & pUser & "' and pass='" & OldHashedPass & "';"
            comando = New SqlCommand(st, conexion)
            Dim count As Integer = comando.ExecuteScalar()

            If count = 0 Then
                closeConnection()
                Return 1
            Else
                'Verificar que el usuario existe pero no está confirmado'
                st = "select count(*) from Usuarios where email='" & pUser & "' and confirmado='False';"
                comando = New SqlCommand(st, conexion)
                count = comando.ExecuteScalar()

                Try
                    st = "UPDATE Usuarios SET pass='" & HashedPass & "' WHERE email='" & pUser & "';"
                    comando = New SqlCommand(st, conexion)
                    comando.ExecuteNonQuery()
                    closeConnection()
                    Return 3
                Catch ex As Exception
                    closeConnection()
                    Return 2
                End Try
            End If

        Else
            'BD no conectada'
            MsgBox(" Error de conexión al servidor de BD: " + excepcion + "")
            closeConnection()
            Return 0
        End If


    End Function


    Public Function recuperarPassword(pUser As String) As Integer

        If openConnection() Then

            Randomize()
            Dim randomNumber As Integer = CInt(Int((3000 * Rnd()) + 100000))

            Using SHA1hash As SHA1 = SHA1.Create()
                HashedPass = System.Convert.ToBase64String(SHA1hash.ComputeHash(System.Text.Encoding.ASCII.GetBytes(randomNumber)))
            End Using

            '0 - Error de conexión a la base de datos'
            '1 - Usuario no existe en la base de datos'
            '2 - Error de actualización de contraseña'
            '3 - Contraseña cambiada y mail enviado'
            '4 - Contraseña cambiada pero mail no enviado'

            'Confirmo que el usuario existe'
            Dim st As String = "select count(*) from Usuarios where email='" & pUser & "';"
            comando = New SqlCommand(st, conexion)
            Dim count As Integer = comando.ExecuteScalar()

            If count = 0 Then
                closeConnection()
                Return 1
            Else
                st = "select nombre from Usuarios where email='" & pUser & "';"
                comando = New SqlCommand(st, conexion)
                Dim nombreDB = comando.ExecuteNonQuery()

                Try
                    st = "UPDATE Usuarios SET pass='" & HashedPass & "' WHERE email='" & pUser & "';"
                    comando = New SqlCommand(st, conexion)
                    comando.ExecuteNonQuery()
                    closeConnection()

                    Dim mailEnviado As Boolean = enviarEmail(pUser, nombreDB, randomNumber)

                    If mailEnviado Then
                        'Todo correcto'
                        closeConnection()
                        Return 3
                    Else
                        'Email no enviado'
                        closeConnection()
                        Return 4
                    End If

                Catch ex As Exception
                    closeConnection()
                    Return 2
                End Try
            End If

        Else
            'BD no conectada'
            MsgBox(" Error de conexión al servidor de BD: " + excepcion + "")
            closeConnection()
            Return 0
        End If

    End Function




    Public Function cuentaVerificada(pUser As String) As Integer

        If openConnection() Then

            'Confirmo que el usuario existe'
            Dim st As String = "select count(*) from Usuarios where email='" & pUser & "' and confirmado='True';"
            comando = New SqlCommand(st, conexion)
            Dim count As Integer = comando.ExecuteScalar()

            closeConnection()

            Return count

        Else
            'BD no conectada'
            MsgBox(" Error de conexión al servidor de BD: " + excepcion + "")
            closeConnection()
            Return 2
        End If


    End Function




    Public Function enviarEmail(pReceiver As String, pNombre As String, pCodigo As String) As Boolean
        Try
            'Direccion de origen
            Dim from_address As New Net.Mail.MailAddress("ldeniz001@ikasle.ehu.eus", "Leroy Deniz")
            'Direccion de destino
            Dim to_address As New Net.Mail.MailAddress(pReceiver)
            'Password de la cuenta
            Dim from_pass As String = "BewareTheJabberwock//11"
            'Objeto para el cliente smtp
            Dim smtp As New SmtpClient
            'Host en este caso el servidor de gmail
            smtp.Host = "smtp.ehu.eus"
            'Puerto
            smtp.Port = 587
            'SSL activado para que se manden correos de manera segura
            smtp.EnableSsl = True
            'No usar los credenciales por defecto ya que si no no funciona
            smtp.UseDefaultCredentials = False
            'Credenciales
            smtp.Credentials = New System.Net.NetworkCredential(from_address.Address, from_pass)
            'Creamos el mensaje con los parametros de origen y destino
            Dim message As New MailMessage(from_address, to_address)
            'Añadimos el asunto
            message.Subject = "Código de verificación"
            'Concatenamos el cuerpo del mensaje a la plantilla
            message.Body = "<html><head></head><body>Hola " + pNombre + ", el código de verificación es " + pCodigo + "</body></html>"
            'Definimos el cuerpo como html para poder escojer mejor como lo mandamos
            message.IsBodyHtml = True
            'Se envia el correo
            smtp.Send(message)
        Catch e As Exception
            Return False
        End Try
        Return True
    End Function




    '*************' FUNCIONES DE CONEXIÓN *************'

    Public Shared Function openConnection() As Boolean
        Try
            conexion.ConnectionString = "Server=tcp:has-server.database.windows.net,1433;Initial Catalog=has21-13;Persist Security Info=False;User ID=leroydeniz@icloud.com@has-server;Password=Depresion12/;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
            conexion.Open()
        Catch ex As Exception
            excepcion = ex.Message
            Return False
        End Try
        Return True
    End Function

    Public Shared Sub closeConnection()
        comando.Dispose()
        conexion.Close()
    End Sub



End Class
