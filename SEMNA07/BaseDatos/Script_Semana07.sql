USE Neptuno;
GO

IF OBJECT_ID('dbo.Personas', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Personas
    (
        IdPersona  INT IDENTITY(1,1) PRIMARY KEY,
        Nombres    VARCHAR(50)  NOT NULL,
        Apellidos  VARCHAR(50)  NOT NULL,
        Dni        CHAR(8)      NOT NULL,
        Telefono   VARCHAR(15)  NULL,
        Email      VARCHAR(100) NULL,
        Eliminado  BIT NOT NULL DEFAULT 0
    );

    INSERT INTO dbo.Personas (Nombres, Apellidos, Dni, Telefono, Email) VALUES
    ('Juan',  'Pérez Gómez',   '12345678', '987654321', 'juan@gmail.com'),
    ('María', 'López Torres',  '87654321', '912345678', 'maria@gmail.com'),
    ('Carlos','Ramírez Díaz',  '45678912', '934567812', 'carlos@gmail.com');
END
GO

IF COL_LENGTH('dbo.productos', 'Eliminado') IS NULL
    ALTER TABLE dbo.productos ADD Eliminado BIT NOT NULL DEFAULT 0;
GO

CREATE OR ALTER PROCEDURE USP_Persona_Listar
AS
BEGIN
    SELECT IdPersona, Nombres, Apellidos, Dni, Telefono, Email, Eliminado
    FROM dbo.Personas
    WHERE Eliminado = 0
    ORDER BY IdPersona;
END
GO

CREATE OR ALTER PROCEDURE USP_Persona_Buscar
    @Texto VARCHAR(100)
AS
BEGIN
    SELECT IdPersona, Nombres, Apellidos, Dni, Telefono, Email, Eliminado
    FROM dbo.Personas
    WHERE Eliminado = 0
      AND (Nombres LIKE '%' + @Texto + '%'
        OR Apellidos LIKE '%' + @Texto + '%'
        OR Dni LIKE '%' + @Texto + '%')
    ORDER BY IdPersona;
END
GO

CREATE OR ALTER PROCEDURE USP_Persona_Insertar
    @Nombres   VARCHAR(50),
    @Apellidos VARCHAR(50),
    @Dni       CHAR(8),
    @Telefono  VARCHAR(15),
    @Email     VARCHAR(100)
AS
BEGIN
    INSERT INTO dbo.Personas (Nombres, Apellidos, Dni, Telefono, Email)
    VALUES (@Nombres, @Apellidos, @Dni, @Telefono, @Email);
END
GO

CREATE OR ALTER PROCEDURE USP_Persona_Actualizar
    @IdPersona INT,
    @Nombres   VARCHAR(50),
    @Apellidos VARCHAR(50),
    @Dni       CHAR(8),
    @Telefono  VARCHAR(15),
    @Email     VARCHAR(100)
AS
BEGIN
    UPDATE dbo.Personas
    SET Nombres = @Nombres,
        Apellidos = @Apellidos,
        Dni = @Dni,
        Telefono = @Telefono,
        Email = @Email
    WHERE IdPersona = @IdPersona;
END
GO

CREATE OR ALTER PROCEDURE USP_Persona_EliminarLogico
    @IdPersona INT
AS
BEGIN
    UPDATE dbo.Personas SET Eliminado = 1 WHERE IdPersona = @IdPersona;
END
GO

CREATE OR ALTER PROCEDURE USP_Producto_Listar
AS
BEGIN
    SELECT idproducto, nombreProducto, cantidadPorUnidad, precioUnidad, unidadesEnExistencia, Eliminado
    FROM dbo.productos
    WHERE Eliminado = 0
    ORDER BY idproducto;
END
GO

CREATE OR ALTER PROCEDURE USP_Producto_Buscar
    @Texto VARCHAR(100)
AS
BEGIN
    SELECT idproducto, nombreProducto, cantidadPorUnidad, precioUnidad, unidadesEnExistencia, Eliminado
    FROM dbo.productos
    WHERE Eliminado = 0
      AND nombreProducto LIKE '%' + @Texto + '%'
    ORDER BY idproducto;
END
GO

CREATE OR ALTER PROCEDURE USP_Producto_Insertar
    @NombreProducto       VARCHAR(40),
    @CantidadPorUnidad    VARCHAR(20),
    @PrecioUnidad         DECIMAL(18,2),
    @UnidadesEnExistencia SMALLINT
AS
BEGIN
    DECLARE @Id INT = (SELECT ISNULL(MAX(idproducto), 0) + 1 FROM dbo.productos);

    INSERT INTO dbo.productos (idproducto, nombreProducto, cantidadPorUnidad, precioUnidad, unidadesEnExistencia)
    VALUES (@Id, @NombreProducto, @CantidadPorUnidad, @PrecioUnidad, @UnidadesEnExistencia);
END
GO

CREATE OR ALTER PROCEDURE USP_Producto_Actualizar
    @IdProducto           INT,
    @NombreProducto       VARCHAR(40),
    @CantidadPorUnidad    VARCHAR(20),
    @PrecioUnidad         DECIMAL(18,2),
    @UnidadesEnExistencia SMALLINT
AS
BEGIN
    UPDATE dbo.productos
    SET nombreProducto = @NombreProducto,
        cantidadPorUnidad = @CantidadPorUnidad,
        precioUnidad = @PrecioUnidad,
        unidadesEnExistencia = @UnidadesEnExistencia
    WHERE idproducto = @IdProducto;
END
GO

CREATE OR ALTER PROCEDURE USP_Producto_EliminarLogico
    @IdProducto INT
AS
BEGIN
    UPDATE dbo.productos SET Eliminado = 1 WHERE idproducto = @IdProducto;
END
GO
