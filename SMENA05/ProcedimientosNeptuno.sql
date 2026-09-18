USE Neptuno;
GO

CREATE OR ALTER PROCEDURE USP_ListarProductos
AS
BEGIN
    SELECT 
        idproducto, 
        nombreProducto, 
        idProveedor, 
        idCategoria, 
        cantidadPorUnidad, 
        precioUnidad, 
        unidadesEnExistencia, 
        unidadesEnPedido, 
        nivelNuevoPedido, 
        suspendido, 
        categoriaProducto
    FROM productos;
END;
GO

CREATE OR ALTER PROCEDURE USP_ListarCategoriasSemana04
AS
BEGIN
    SELECT 
        idcategoria, 
        nombrecategoria, 
        descripcion, 
        Activo, 
        CodCategoria
    FROM categorias;
END;
GO

CREATE OR ALTER PROCEDURE USP_ListarProveedores
AS
BEGIN
    SELECT 
        idProveedor, 
        nombreCompañia, 
        nombrecontacto, 
        cargocontacto, 
        direccion, 
        ciudad, 
        region, 
        codPostal, 
        pais, 
        telefono, 
        fax
    FROM proveedores;
END;
GO

CREATE OR ALTER PROCEDURE USP_BuscarProveedores
    @nombreContacto VARCHAR(100) = '',
    @ciudad VARCHAR(100) = ''
AS
BEGIN
    SELECT 
        idProveedor, 
        nombreCompañia, 
        nombrecontacto, 
        cargocontacto, 
        direccion, 
        ciudad, 
        region, 
        codPostal, 
        pais, 
        telefono, 
        fax
    FROM proveedores
    WHERE (@nombreContacto IS NULL OR @nombreContacto = '' OR nombrecontacto LIKE '%' + @nombreContacto + '%')
      AND (@ciudad IS NULL OR @ciudad = '' OR ciudad LIKE '%' + @ciudad + '%');
END;
GO

CREATE OR ALTER PROCEDURE USP_DetallesPedidosPorFecha
    @fechaInicio DATE,
    @fechaFin DATE
AS
BEGIN
    SELECT 
        dp.idpedido, 
        dp.idproducto, 
        dp.preciounidad, 
        dp.cantidad, 
        dp.descuento, 
        p.FechaPedido, 
        p.IdCliente, 
        p.IdEmpleado
    FROM detallesdepedidos dp
    INNER JOIN Pedidos p ON dp.idpedido = p.IdPedido
    WHERE p.FechaPedido BETWEEN @fechaInicio AND @fechaFin;
END;
GO
