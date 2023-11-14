	/*Cosas de prueba NO EJECUTAR*/

	/*¨Procedimientos almacenados para la base de datos de asp.net*/
-- Crear el procedimiento almacenado
--DROP PROCEDURE ObtenerUsuarioPorCorreoYPassword
--DROP DATABASE DarwinGod
--DROP PROCEDURE ObtenerBeneficioVeterano
--DROP PROCEDURE ObtenerDonativosPorCorreo

Use master
/*Ejemplos de ejecucion de los procedimientos almacenados*/
USE DarwinGod
EXEC ObtenerDonativosPorCorreoTodosLosBeneficios 'usuario2@example.com' 

-- Ejecutar el procedimiento almacenado con valores concretos
EXEC ObtenerUsuarioPorCorreoYPassword 'usuario1@example.com', 'password123'
/*todos los select solamente para comprobar procedimientos
SELECT * FROM Roles_Usuario
SELECT * FROM Usuarios
*/


/*Prueba de ingresar usuario*/
EXEC IngresarUsuario
    'nuevo_usuario@example.com',
    'Nuevo',
    'Usuario',
    'password123',
    '123 Calle Principal',
    0; -- 0 para falso, 1 para verdadero

	--DELETE FROM Usuarios Where correo ='nuevo_usuario@example.com'

/*Prueba de consultar los usuarios con donativos TODOS SOLO ADMINS*/
EXEC ConsultarUsuariosConDonativos;


USE DarwinGod
-- Ejemplo de ejecución del eliminacion en cascada
EXEC EliminarUsuarioYDonativos 'usuario3@example.com';


/*Donativo mas reciente de*/

EXEC ObtenerDonativosPorCorreoTodosLosBeneficiosFechaMasReciente 'usuario2@example.com'
--Verificar expresiones regulares para nombres y apellidos
DECLARE @cadena NVARCHAR(MAX) = '1Hola, Mundo. ñ o'

IF @cadena LIKE '%[A-Za-z .,]%'
    PRINT 'La cadena cumple con el patrón (letras mayúsculas, minúsculas, espacios y puntos)'
ELSE
    PRINT 'La cadena no cumple con el patrón'


	--Verificar expresion regular para correos.
	
--Verificar expresion regular para correos.
DECLARE @cadena NVARCHAR(MAX) = 'p¿@hotmail.com'

IF @cadena LIKE '^[(A-Za-z0-9._-]+@[A-Za-z0-9.-]+.[A-Za-z]{2,5})$'
    PRINT 'Cumple con el patrón'
ELSE
    PRINT 'La cadena no cumple con el patrón'
