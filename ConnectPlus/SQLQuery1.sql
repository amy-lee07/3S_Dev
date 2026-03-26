create database ConnectPlus;

create table TipoContato (
	IdTipoContato uniqueidentifier primary key default((newid())),
	Titulo varchar (100) not null
);
create table Contato (
	IdContato uniqueidentifier primary key default((newid())),
    nome varchar(150) not null,
    formaContato varchar(100) not null, 
    imagem varchar(255),
    IdTipoContato uniqueidentifier not null,
    foreign key (IdTipoContato) references TipoContato(IdTipoContato)
);

SELECT * FROM TipoContato



