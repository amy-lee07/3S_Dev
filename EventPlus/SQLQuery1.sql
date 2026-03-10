create database EventPlus;

use EventPlus;

create table TipoUsuario(
	IdTipoUsuario uniqueidentifier primary key default((newid())),
	Titulo varchar (100) not null
);
go

create table TipoEvento(
	IdTipoEvento uniqueidentifier primary key default((newid())),
	Titulo varchar (100) not null
);
go

create table Usuario(
	IdUsuario uniqueidentifier primary key default((newid())),
	Nome varchar (100),
	Email varchar (256) unique not null,
	Senha varchar (60) not null,
	IdTipoUsuario uniqueidentifier foreign key references TipoUsuario(IdTipoUsuario)
);
go

create table Instituicao (
	IdInstituicao uniqueidentifier primary key default((newid())),
	NomeFantasia varchar(100) not null,
	CNPJ varchar (14) unique not null,
	Endereco varchar (100) not null
);
go

create table Evento(
	IdEvento uniqueidentifier primary key default((newid())),
	Nome varchar(100) not null,
	DataEvento datetime not null,
	Descricao text not null,
	IdTipoEvento uniqueidentifier foreign key references TipoEvento(IdTipoEvento),
	IdInstituicao uniqueidentifier foreign key references Instituicao(IdInstituicao)
);
go

create table Presenca (
	IdPresenca uniqueidentifier primary key default((newid())),
	Situcao bit not null,
	IdUsuario uniqueidentifier foreign key references Usuario(IdUsuario),
	IdEvento uniqueidentifier foreign key references Evento(IdEvento)
);
go

create table ComentarioEvento(
	IdComentarioEvento uniqueidentifier primary key default((newid())),
	Descricao varchar (200) not null,
	Exibe Bit not null, 
	DataComentarioEvento datetime not null,
	IdUsuario uniqueidentifier foreign key references Usuario(IdUsuario),
	IdEvento uniqueidentifier foreign key references Evento(IdEvento)
);
go