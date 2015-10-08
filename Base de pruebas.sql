DROP DATABASE Pruebas
CREATE DATABASE Pruebas

Use Pruebas

create Table Ciudades(
Id int identity(1,1) primary key,
Descripcion varchar(70) not null unique)
go
create Table Fabricantes(
Id int identity(1,1) primary key,
Descripcion varchar(70) not null unique)
go
create Table Tipos_Servicio(
Id int identity(1,1) primary key,
Descripcion varchar (70) not null unique,
Porcentaje float not null)
go
create Table Funcionalidades(
Id int identity(1,1) primary key,
Descripcion varchar(70) not null unique)
go
create Table Roles(
Id int identity(1,1) primary key,
Descripcion varchar(70) not null unique,
Funcionalidad int)
go

Alter table Roles 
add constraint FK_Funcionalidad FOREIGN KEY (Funcionalidad) references Funcionalidades(Id) 
go

create Table Usuarios(
Id int identity(1,1) primary key,
Username varchar(50) not null unique,
Password varchar(256) not null,
Rol int)
go
Alter table Usuarios
add constraint FK_Rol FOREIGN KEY (Rol) references Roles(Id)
go

create Table Intentos_Fallidos(
Id_User int,
cantidad int)
go
Alter table Intentos_fallidos
add constraint FK_User FOREIGN KEY (Id_User) references Usuarios(Id) 
go
create Table Inhabilitados(
Id_User int)
go
Alter table Inhabilitados
add constraint FK_User_Inahilitado FOREIGN KEY (Id_User) references Usuarios(Id)
go
Create Table Clientes(
Id int identity(1,1) primary key,
DNI numeric(20) unique not null,
Nombre varchar(40) not null,
Apellido varchar(40) not null,
Direccion varchar(60) not null,
Telefono numeric(30) not null,
Mail varchar(50) unique not null,
Fecha_Nacimiento smalldatetime not null,
Usuario int)
go
Alter table Clientes
add constraint FK_User_Cliente FOREIGN KEY (Usuario) references Usuarios(Id)
go
Create Table Rutas_Aereas(
Id int identity(1,1) primary key,
Ciudad_Destino int,
Ciudad_Origen int,
Tipo_Servicio int,
Precio_Base float not null,
Precio_Kg float not null)
go
Alter Table Rutas_Aereas
add constraint FK_Ciudad_Origen FOREIGN KEY (Ciudad_Origen) references Ciudades(Id)
go
Alter Table Rutas_Aereas
add constraint FK_Ciudad_Destino FOREIGN KEY (Ciudad_Destino) references Ciudades(Id)
go
Alter Table Rutas_Aereas
add constraint FK_Tipo_Servicio FOREIGN KEY (Tipo_Servicio) references Tipos_Servicio(Id)
go
alter table Usuarios
add Pregunta_Secreta varchar(50) not null
go
alter table Usuarios
add Respuesta varchar(50) not null
go
create table Aeronaves(
matricula varchar(10) primary key,
Fecha_alta smalldatetime not null,
Modelo varchar(30) not null,
Fabricante int,
Tipo_Servicio int,
Baja_Fuera_Servicio varchar(2),
Baja_Vida_Util varchar(2),
Fecha_Fuera_Servicio smalldatetime,
Fecha_Reinicio_Servicio smalldatetime,
Fecha_Baja_Definitiva smalldatetime,
Cantidad_Butacas int not null,
Cantidad_Kg int not null)
go
alter table Aeronaves
add constraint Fabricante foreign key (Fabricante) references Fabricantes(Id)  
go
alter table Aeronaves
add constraint Tipo_Servicio foreign key (Tipo_Servicio) references Tipos_Servicio(Id)
go
create table Butacas(
Matricula varchar(10) not null,
Numero int not null,
Tipo varchar(20) not null,
Piso int not null)
go
alter table Butacas
add constraint Matricula foreign key (Matricula) references Aeronaves(Matricula)
go
Create table Viajes(
Id int identity(1,1) ,
Matricula varchar(10),
Ruta int)
go
alter table Viajes
add constraint Id primary key (Id)
go
alter table Viajes
add constraint Matricula_Avion foreign key (Matricula) references Aeronaves(Matricula)
go
alter table Viajes
add constraint Ruta foreign key (Ruta) references Rutas_Aereas(Id)
go
alter table Rutas_Aereas
add Fecha_Salida datetime not null
go
alter table Rutas_Aereas
add Fecha_Estimada datetime not null
go
alter table Rutas_Aereas
add Fecha_llegada datetime not null
go
create table Paquetes(
Id int identity(1,1) primary key,
Viaje int,
Kg int not null,
Fecha_Compra smalldatetime,
Cliente int)
go
alter table Paquetes
add constraint Viaje2 foreign key (Viaje) references Viajes(Id)
go
alter table Paquetes
add constraint Cliente_Paquete foreign key (Cliente) references Clientes(Id)
go
Create table Pasajes(
Id int identity(1,1) primary key,
Viaje int,
Numero_Butaca int not null,
Fecha_Compra smalldatetime,
Cliente int)
go
alter table Pasajes
add constraint Viaje3 foreign key (Viaje) references Viajes(Id)
go
alter table Pasajes
add constraint Cliente_Pasaje foreign key (Cliente) references Clientes(Id)
go
create table Millas(
Id int identity(1,1),
Cliente int,
Millas int not null)
go
alter table Millas
add constraint Cliente_Millero foreign key (Cliente) references Clientes(Id)
go
alter table Millas
add constraint PK primary key (Id)
go
alter table Millas
add Fecha smalldatetime not null default getdate()
go
create table Productos_Milla(
Id int identity(1,1) primary key,
Descripcion varchar not null,
Cantidad int not null,
Millas_Necesarias int not null)
go
create table Cambios_Millas(
Id int identity(1,1) primary key,
Cliente int,
Producto int,
Cantidad int not null,
Fecha_Canje smalldatetime default getdate() )
go
alter table Cambios_Millas
add constraint Cliente_Cambiador foreign key (Cliente) references Clientes(Id)
go
alter table Cambios_Millas
add constraint Producto foreign key (Producto) references Productos_Milla(Id)
go
create table Cancelaciones(
Id int identity(1,1) primary key,
Codigo_Pasaje int,
Codigo_Encomienda int,
Fecha smalldatetime not null,
Motivo varchar(200))
go
alter table Cancelaciones
add constraint Pasaje foreign key (Codigo_Pasaje) references Pasajes(Id)
go
alter table Cancelaciones
add constraint Encomienda foreign key (Codigo_Encomienda) references Paquetes(Id)
go
create table Tarjetas_Credito(
Id int identity(1,1) primary key,
Cliente int,
Numero_Tarjeta numeric(20) not null,
Codigo_Seguridad numeric(10) not null,
Fecha_Vencimiento smalldatetime not null,
Tipo_Tarjeta varchar(30) not null)
go
alter table Tarjetas_Credito
add constraint Cliente_Tarjetero foreign key(Cliente) references Clientes(Id)
go


insert into funcionalidades
values ('Ser un dios')

insert into Roles
values ('Administrador',1)

insert into usuarios
values ('martinnb','62c66a7a5dd70c3146618063c344e531e6d4b59e379808443ce962b3abd63c5a',1,'Sos dios','no')

-- 62c66a7a5dd70c3146618063c344e531e6d4b59e379808443ce962b3abd63c5a es la m encriptada

go

Create view RolesPorUsuario as
Select f.Descripcion from usuarios u	join roles r on (u.rol=r.id)
						join funcionalidades f on (r.Funcionalidad=f.Id)
go


