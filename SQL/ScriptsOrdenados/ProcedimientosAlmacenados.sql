USE DarwinGod
GO
CREATE PROCEDURE ObtenerUsuarioPorCorreoYPassword
    @correo VARCHAR(100),
    @password VARCHAR(50)
AS
BEGIN
    -- Declarar variables para almacenar el resultado
    DECLARE @resultado_correo VARCHAR(100)
    DECLARE @resultado_rol INT

    -- Inicializa las variables en NULL
    SET @resultado_correo = NULL
    SET @resultado_rol = NULL

    -- Buscar el usuario en la tabla Usuarios
    SELECT TOP 1 @resultado_correo = correo, @resultado_rol = RolUsuario_fk
    FROM Usuarios
    WHERE correo = @correo AND password_usuario = @password

    -- Devolver el resultado
    IF @@ROWCOUNT > 0
    BEGIN
        SELECT @resultado_correo AS Correo, @resultado_rol AS RolUsuario
    END
    ELSE
    BEGIN
        -- Si no se encuentra un usuario, devuelve NULL para ambas columnas
        SELECT NULL AS Correo, NULL AS RolUsuario
    END
END

GO



/*Procedimiento almacenado para tener la tabla de los beneficios de un veterano*/


CREATE PROCEDURE ObtenerDonativosPorCorreoTodosLosBeneficios
    @correoUsuario VARCHAR(100)
AS
BEGIN
    -- Obtener datos de donativos de dinero con información de usuarios
    BEGIN
        SELECT
            U.correo AS UsuarioCorreo,
            'DonativoDinero' AS TipoDonativo,
            CONVERT(VARCHAR(20), DD.Donativo) + ' $' AS Donativo,
            U.nombres AS UsuarioNombres,
            U.apellidos AS UsuarioApellidos,
            DD.fecha_donativo AS FechaDonativo
        FROM
            DonativosDinero DD
        INNER JOIN
            Usuarios U ON DD.correocomo_fk = U.correo
        WHERE
            U.correo = @correoUsuario

        UNION ALL

        -- Obtener datos de donativos de alimentación con información de usuarios
        SELECT
            U.correo AS UsuarioCorreo,
            'DonativoAlimento' AS TipoDonativo,
            DA.Donativo AS Donativo,
            U.nombres AS UsuarioNombres,
            U.apellidos AS UsuarioApellidos,
            DA.fecha_donativo AS FechaDonativo
        FROM
            DonativosAlimentacion DA
        INNER JOIN
            Usuarios U ON DA.correocomo_fk = U.correo
        WHERE
            U.correo = @correoUsuario

        UNION ALL

        -- Obtener datos de donativos de productos personales con información de usuarios
        SELECT
            U.correo AS UsuarioCorreo,
            'DonativoProductoPersonal' AS TipoDonativo,
            DPP.Donativo AS Donativo,
            U.nombres AS UsuarioNombres,
            U.apellidos AS UsuarioApellidos,
            DPP.fecha_donativo AS FechaDonativo
        FROM
            DonativosProductosPersonales DPP
        INNER JOIN
            Usuarios U ON DPP.correocomo_fk = U.correo
        WHERE
            U.correo = @correoUsuario;
    END
END;


GO
/*Consultar Usuario Por donativo*/
CREATE PROCEDURE ConsultarUsuariosConDonativos
AS
BEGIN
    SELECT U.*, DP.Donativo AS DonativoProductosPersonales, DD.Donativo AS DonativoDinero, DA.Donativo AS DonativoAlimentacion
    FROM Usuarios U
    LEFT JOIN DonativosProductosPersonales DP ON U.correo = DP.correocomo_fk
    LEFT JOIN DonativosDinero DD ON U.correo = DD.correocomo_fk
    LEFT JOIN DonativosAlimentacion DA ON U.correo = DA.correocomo_fk;
END;
GO



/*Consultar la informacion de un usuario*/
CREATE PROCEDURE ConsultarInformacioUsuario
    @correo VARCHAR(100)
AS
BEGIN
    SELECT *
    FROM Usuarios
    WHERE correo = @correo;
END;


GO
/*Procedimiento almacenado para realizar donativo de alimentos*/





/*Eliminar Usuarios y donativos*/
CREATE PROCEDURE EliminarUsuarioYDonativos
    @correoUsuario VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Usuarios WHERE correo = @correoUsuario;
END;

GO



 CREATE PROCEDURE ObtenerDonativosPorCorreoTodosLosBeneficiosFechaMasReciente
    @correoUsuario VARCHAR(100)
AS
BEGIN
    -- Variables para almacenar los resultados temporales
    DECLARE @TablaTemporal TABLE (
        UsuarioCorreo VARCHAR(100),
        TipoDonativo VARCHAR(50),
        Donativo VARCHAR(50),
        UsuarioNombres VARCHAR(100),
        UsuarioApellidos VARCHAR(100),
        FechaDonativo DATETIME
    )

    -- Obtener datos de donativos de dinero con información de usuarios
    INSERT INTO @TablaTemporal
    SELECT TOP 1
        U.correo AS UsuarioCorreo,
        'DonativoDinero' AS TipoDonativo,
        CONVERT(VARCHAR(20), DD.Donativo) + ' $' AS Donativo,
        U.nombres AS UsuarioNombres,
        U.apellidos AS UsuarioApellidos,
        DD.fecha_donativo AS FechaDonativo
    FROM
        DonativosDinero DD
    INNER JOIN
        Usuarios U ON DD.correocomo_fk = U.correo
    WHERE
        U.correo = @correoUsuario
    ORDER BY
        DD.fecha_donativo DESC

    -- Obtener datos de donativos de alimentación con información de usuarios
    INSERT INTO @TablaTemporal
    SELECT TOP 1
        U.correo AS UsuarioCorreo,
        'DonativoAlimento' AS TipoDonativo,
        DA.Donativo AS Donativo,
        U.nombres AS UsuarioNombres,
        U.apellidos AS UsuarioApellidos,
        DA.fecha_donativo AS FechaDonativo
    FROM
        DonativosAlimentacion DA
    INNER JOIN
        Usuarios U ON DA.correocomo_fk = U.correo
    WHERE
        U.correo = @correoUsuario
    ORDER BY
        DA.fecha_donativo DESC

    -- Obtener datos de donativos de productos personales con información de usuarios
    INSERT INTO @TablaTemporal
    SELECT TOP 1
        U.correo AS UsuarioCorreo,
        'DonativoProductoPersonal' AS TipoDonativo,
        DPP.Donativo AS Donativo,
        U.nombres AS UsuarioNombres,
        U.apellidos AS UsuarioApellidos,
        DPP.fecha_donativo AS FechaDonativo
    FROM
        DonativosProductosPersonales DPP
    INNER JOIN
        Usuarios U ON DPP.correocomo_fk = U.correo
    WHERE
        U.correo = @correoUsuario
    ORDER BY
        DPP.fecha_donativo DESC

    -- Seleccionar el resultado con la fecha más reciente
    SELECT TOP 1
        UsuarioCorreo,
        TipoDonativo,
        Donativo,
        UsuarioNombres,
        UsuarioApellidos,
        FechaDonativo
    FROM
        @TablaTemporal
    ORDER BY
        FechaDonativo DESC
END


GO
CREATE PROCEDURE sp_ActualizarUsuario (
    @correo VARCHAR(100),
    @nombres VARCHAR(50),
    @apellidos VARCHAR(50),
    @password_usuario VARCHAR(50),
    @direccion_residencia VARCHAR(200),
    @estado_extranjero BIT
)
AS
BEGIN
    UPDATE Usuarios
    SET
        nombres = @nombres,
        apellidos = @apellidos,
        password_usuario = @password_usuario,
        direccion_residencia = @direccion_residencia,
        estado_extranjero = @estado_extranjero,
        RolUsuario_fk = 2 -- Establecer rol por defecto a 2
    WHERE
        correo = @correo;
END;
