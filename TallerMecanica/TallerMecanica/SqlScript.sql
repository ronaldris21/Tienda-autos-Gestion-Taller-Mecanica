DROP TABLE MateriaPrima_ProductoPreEnsamblado;
DROP TABLE MateriaPrima_ProductoComprado;
DROP TABLE MateriaPrima;
DROP TABLE Categoria;
DROP TABLE ProductoComprado;
DROP TABLE Cliente;
DROP TABLE ProductoPreEnsamblado;


CREATE TABLE Cliente
(
	idCliente int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nombreCompleto nChar(70) NOT NULL,
	profilePic nChar(200) not null,
	email nChar(50) NOT NULL,
	telefono1 nChar(25) NOT NULL,
	telefono2 nChar(25) NULL,
	contrasena nChar(20) NOT NULL,
	isAdmin bit NOT NULL default 0,
);

CREATE TABLE Categoria
(
	idCategoria int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nombreCategoria nChar(30) NOT NULL,
	cantidadCocheCompleto int not null
);

CREATE TABLE MateriaPrima
(
	idMateriaPrima int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	nombre nChar(30) NOT NULL,
	marca nChar(30) not null DEFAULT 'Reacondicionado',
	precioCompra float not null,
	precioVenta float not null,
	cantidadStock int not null default 0,
	idCategoria int not null
);

CREATE TABLE ProductoComprado
(
	idProductoComprado int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	descripcion nChar(500) NULL,
	fechaCompra Date not null default getdate(),
	fechaEntregaPrevista Date null,
	costoEnsamblado float not null default 0,	--Por defecto mientras el admin calcula el costo del ensamblado
	requiereEnsamblado bit not null default 1,	--Si el cliente crea el pedido, requiere ensamblado
	pedidoConfirmado bit not null default 0,	--Lo tiene que confirmar el admin
	idCliente int not null
);

CREATE TABLE ProductoPreEnsamblado
(
	idProductoPreEnsamblado int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	descripcion nChar(500) NULL,
	costoEnsamblado float not null
);

CREATE TABLE MateriaPrima_ProductoPreEnsamblado
(
	idMateriaPrima_ProductoPreEnsamblado int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	cantidad int not null,
	idMateriaPrima int not null,
	idProductoPreEnsamblado int not null
);

CREATE TABLE MateriaPrima_ProductoComprado
(
	idMateriaPrima_ProductoComprado int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	cantidad int not null,
	idMateriaPrima int not null,
	idProductoComprado int not null
);

--MateriaPrima_ProductoComprado
ALTER TABLE MateriaPrima_ProductoComprado
	ADD CONSTRAINT MateriaPrima_ProductoComprado_fk_MateriaPrima FOREIGN KEY (idMateriaPrima) REFERENCES MateriaPrima(idMateriaPrima);
ALTER TABLE MateriaPrima_ProductoComprado
	ADD CONSTRAINT MateriaPrima_ProductoComprado_fk_ProductoComprado FOREIGN KEY (idProductoComprado) REFERENCES ProductoComprado(idProductoComprado);

--MateriaPrima_ProductoPreEnsamblado
ALTER TABLE MateriaPrima_ProductoPreEnsamblado
	ADD CONSTRAINT MateriaPrima_ProductoPreEnsamblado_fk_MateriaPrima FOREIGN KEY (idMateriaPrima) REFERENCES MateriaPrima(idMateriaPrima);
ALTER TABLE MateriaPrima_ProductoPreEnsamblado
	ADD CONSTRAINT MateriaPrima_ProductoPreEnsamblado_fk_ProductoPreEnsamblado FOREIGN KEY (idProductoPreEnsamblado) REFERENCES ProductoPreEnsamblado(idProductoPreEnsamblado);

--MateriaPrima
ALTER TABLE MateriaPrima
	ADD CONSTRAINT MateriaPrima_fk_Categoria FOREIGN KEY (idCategoria) REFERENCES Categoria(idCategoria);

--ProductoComprado
ALTER TABLE ProductoComprado
	ADD CONSTRAINT ProductoComprado_fk_Cliente FOREIGN KEY (idCliente) REFERENCES Cliente(IdCliente);

INSERT INTO CATEGORIA VALUES('Ruedas y Llantas',4);
INSERT INTO CATEGORIA VALUES('Motor',1);
INSERT INTO CATEGORIA VALUES('Batería',1);
INSERT INTO CATEGORIA VALUES('Caja de cambios',1);
INSERT INTO CATEGORIA VALUES('Chasis',1);
INSERT INTO CATEGORIA VALUES('Fusibles',2);
INSERT INTO CATEGORIA VALUES('Alternador',1);
INSERT INTO CATEGORIA VALUES('Radiador',1);
INSERT INTO CATEGORIA VALUES('Dirección',1);
INSERT INTO CATEGORIA VALUES('Suspensión',1);
INSERT INTO CATEGORIA VALUES('Frenos',2);
INSERT INTO CATEGORIA VALUES('Válvula de escape',1);