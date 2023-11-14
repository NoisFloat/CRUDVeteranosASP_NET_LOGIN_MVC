-- Solo DDL
USE master;
GO

CREATE DATABASE DarwinGod;
GO
USE DarwinGod;
GO

-- Crear la tabla Roles_Usuario
CREATE TABLE Roles_Usuario (
    id INT IDENTITY(1,1) PRIMARY KEY,
    nombre_rol VARCHAR(50) NOT NULL
);

-- Crear la tabla Usuarios
CREATE TABLE Usuarios (
    correo VARCHAR(100) PRIMARY KEY,
    nombres VARCHAR(50) NOT NULL,
    apellidos VARCHAR(50) NOT NULL,
    password_usuario VARCHAR(50) NOT NULL,
    direccion_residencia VARCHAR(200) NOT NULL,
    estado_extranjero BIT NOT NULL, -- Si el estado es 0 es nacional si es 1, es extranjero.
    RolUsuario_fk INT NOT NULL,
	FOREIGN KEY (RolUsuario_fk) REFERENCES Roles_Usuario(id) ON DELETE CASCADE ON UPDATE CASCADE,


);

-- Crear la tabla DonativosDinero
CREATE TABLE DonativosDinero (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Donativo DECIMAL(10, 2) NOT NULL, -- Cambiado a DECIMAL, ajusta la precisión según tus necesidades
    correocomo_fk VARCHAR(100),
    fecha_donativo DATE NOT NULL,
	CONSTRAINT Donativo CHECK ( Donativo > 0),
    FOREIGN KEY (correocomo_fk) REFERENCES Usuarios(correo) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Crear la tabla DonativosAlimentacion
CREATE TABLE DonativosAlimentacion (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Donativo VARCHAR(50) NOT NULL,
    correocomo_fk VARCHAR(100) NOT NULL,
    fecha_donativo DATE NOT NULL,
    FOREIGN KEY (correocomo_fk) REFERENCES Usuarios(correo) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Crear la tabla DonativosProductosPersonales
CREATE TABLE DonativosProductosPersonales (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Donativo VARCHAR(50) NOT NULL,
    correocomo_fk VARCHAR(100) NOT NULL,
    fecha_donativo DATE NOT NULL,
    FOREIGN KEY (correocomo_fk) REFERENCES Usuarios(correo) ON DELETE CASCADE ON UPDATE CASCADE
);

GO
