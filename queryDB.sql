USE prueba;

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name='USERS')
BEGIN
    CREATE TABLE USERS (
        id INT NOT NULL PRIMARY KEY,
        usuario NVARCHAR(30),
        primer_nombre NVARCHAR(30),
        segundo_nombre NVARCHAR(30),
        primer_apellido Nvarchar(30),
        segundo_apellido Nvarchar(30),
        id_departamento INT,
        id_cargo INT,
    );
END

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name='DEPARTAMENTOS')
BEGIN
    CREATE TABLE DEPARTAMENTOS (
        id int PRIMARY KEY NOT NULL,
        codigo NVARCHAR(30),
        nombre NVARCHAR(30),
        activo BIT,
        id_usuario_creacion INT,
    );
END

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name='CARGOS')
BEGIN
    CREATE TABLE CARGOS (
        id int PRIMARY KEY NOT NULL,
        codigo NVARCHAR(30),
        nombre NVARCHAR(30),
        activo BIT,
        id_usuario_creacion INT,
    );
END
