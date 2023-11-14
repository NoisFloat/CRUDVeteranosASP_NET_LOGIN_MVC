/*Insercion de datos*/
USE DarwinGod
-- Insertar datos en la tabla Roles_Usuario
-- Insert data into Roles_Usuario table
INSERT INTO Roles_Usuario (nombre_rol) VALUES ('Admin'), ('Voluntario'), ('Donante');

-- Insert data into Usuarios table
INSERT INTO Usuarios (correo, nombres, apellidos, password_usuario, direccion_residencia, estado_extranjero, RolUsuario_fk)
VALUES 
('usuario1@example.com', 'John', 'Doe', 'password123', '123 Main St', 0, 1),
('usuario2@example.com', 'Jane', 'Smith', 'pass456', '456 Oak St', 1, 2);
-- Insert data into DonativosDinero table
INSERT INTO DonativosDinero (Donativo, correocomo_fk, fecha_donativo)
VALUES 
(100.50, 'usuario1@example.com', '2023-11-01'),
(50.25, 'usuario2@example.com', '2023-11-02');
-- Insert data into DonativosAlimentacion table
INSERT INTO DonativosAlimentacion (Donativo, correocomo_fk, fecha_donativo)
VALUES 
('Comida enlatada', 'usuario1@example.com', '2023-11-01'),
('Arroz y legumbres', 'usuario2@example.com', '2023-11-02');
-- Insert data into DonativosProductosPersonales table
INSERT INTO DonativosProductosPersonales (Donativo, correocomo_fk, fecha_donativo)
VALUES 
('Artículos de higiene', 'usuario1@example.com', '2023-11-01'),
('Ropa y calzado', 'usuario2@example.com', '2023-11-02');

--FIN DE INSERSION DE DATOS