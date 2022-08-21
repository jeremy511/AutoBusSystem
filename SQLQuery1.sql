create database Autobus_DB
use Autobus_DB

--------------------------------------------------------
-- Creacion de tablas
--------------------------------------------------------

create table Empleado(	
	id int identity(0,1) primary key not null,
	Nombre nvarchar(35),
	Apellido nvarchar(35),
	Fecha_nacimiento date,
	Cedula nvarchar(13) unique,
	idBus int foreign key references Autobus(idBus),
	idRuta int foreign key references Ruta(idRuta)
)




create table Autobus(
	idBus int identity(0,1) primary key not null,
	Marca nvarchar(25),
	Modelo nvarchar(30),
	Placa nvarchar(6),
	Color nvarchar(25),
	Año varchar(4)
)

create table Ruta (
	idRuta int identity(0,1) primary key not null,
	Ruta varchar(50)

)



---------------------------------------------
--INSERTAR
--------------------------------------------


insert into Empleado values('Victor','Tejada','2001-2-2','402-34532-4',0,0)
insert into Autobus values ('Sin bus', 'Vacio', 'Vacio', 'Vacio', 'Null')
insert into Ruta values ('Sin Ruta')





----------------------------------------------------------------------
--Union de tablas (Joins y vista)
----------------------------------------------------------------------
create view Viaje
as
	select id,Nombre,Apellido,Cedula,Marca,Modelo,Placa,Ruta,emp.idBus,emp.idRuta from Empleado emp 
	inner join Autobus bus
	on emp.idBus = bus.idBus
	inner join Ruta rt 
	on emp.idRuta = rt.idRuta


drop view Viaje
-----------------------------------------------------------------------
--PROCS
-----------------------------------------------------------------------

create proc SP_Consultar
@buscar varchar(25)
as
select * from Viaje where Nombre like @buscar + '%' or Cedula like @buscar + '%' or Placa like @buscar + '%'

create proc SP_ConsultarEmp
@buscar varchar(25)
as
select * from Empleado where Nombre like @buscar  + '%' or Cedula like @buscar  + '%'




create proc SP_ConsultarBus
@buscar varchar(25)
as
select * from Autobus where Marca like @buscar  + '%' or Placa like @buscar  + '%'

create proc SP_ConsultarRuta
@buscar varchar(25)
as
select * from Ruta where Ruta like @buscar + '%'

-----------------------------------------------------------------------
create proc SP_InsertarEmpleado
@Nombre nvarchar(35),
@Apellido nvarchar(35),
@Fecha_nacimiento date,
@Cedula nvarchar(13),
@IdBus int,
@IdRuta int
as
insert into Empleado values (@Nombre,@Apellido,@Fecha_nacimiento,@Cedula,@IdBus,@IdRuta)

create proc SP_InsertarBus
@Marca nvarchar(25),
@Modelo nvarchar(30),
@Placa nvarchar(6),
@Color nvarchar(25),
@Año varchar(4)
as
insert into Autobus values (@Marca,@Modelo,@Placa,@Color,@Año)

create proc SP_InsertarRuta
@ruta nvarchar(50)
as
insert into Ruta values (@ruta)
------------------------------------------

create proc SP_EditarEmpleado
@id int,
@Nombre nvarchar(35),
@Apellido nvarchar(35),
@Fecha_nacimiento date,
@Cedula nvarchar(13)
as
update Empleado set Nombre = @Nombre, Apellido = @Apellido, Fecha_nacimiento = @Fecha_nacimiento, Cedula =  @Cedula
where id =  @id


create proc SP_EditarBus
@id int,
@Marca nvarchar(25),
@Modelo nvarchar(30),
@Placa nvarchar(6),
@Color nvarchar(25),
@Año varchar(4)
as
update Autobus set Marca = @Marca, Modelo =  @Modelo, Placa = @Placa, Color = @Color, Año = @Año
where idBus = @id

create proc SP_EditarRuta
@id int,
@ruta nvarchar(50)
as
update Ruta set Ruta =  @ruta
where idRuta = @id

create proc SP_EditarTrip
@id int,
@IdBus int,
@IdRuta int
as
update Empleado set  idBus =  @IdBus, idRuta =  @IdRuta
where id =  @id


-----------------------------------
create proc SP_EliminarEmpleado
@id int
as
delete from Empleado where id = @id

create proc SP_EliminarBus
@id int
as
delete from Autobus where idBus = @id

create proc SP_EliminarRuta
@id int
as
delete from Ruta where idRuta = @id


------------------------------------------
--combo box
-----------------------------------------

create proc sp_comboxEmpleado
as
select id,Nombre from Empleado

create proc sp_comboxAuto
as
select idBus,Marca from autobus

create proc sp_comboxRuta
as
select idRuta,Ruta from Ruta


