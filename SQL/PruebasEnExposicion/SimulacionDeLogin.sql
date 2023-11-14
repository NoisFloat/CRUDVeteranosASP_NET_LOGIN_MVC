USE DarwinGod

--Simula el LOGIN
SELECT correo, RolUsuario_fk FROM Usuarios 
where correo = 'aB' AND Usuarios.password_usuario = 'a';

--Usuarios VETERANOS COMUNES
INSERT INTO Usuarios(correo,nombres,apellidos,password_usuario,direccion_residencia,estado_extranjero,RolUsuario_fk)
VALUES ('a', 'duglas','de novia de adrian' ,'a','apopense',0,2)

--Adminisitradores (SOLO SE PUEDE DESDE LA BASE DE DATOS)
INSERT INTO Usuarios(correo,nombres,apellidos,password_usuario,direccion_residencia,estado_extranjero,RolUsuario_fk)
VALUES ('aB', 'duglas','de novia de adrian' ,'a','apopense',0,1)

SELECT * FROM Roles_Usuario