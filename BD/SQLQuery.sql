create database consultorio;

use consultorio;

--médico e paciente

-- médico => codigo, nome, crm, datanascimento ---idade, especialidades---
--> PK vai atuar sobre o CODIGO
--> codigo: identificador único interno (PK). 
------------ valor: (auto-incremento) iniciar com um valor e definir o incremento para os demais valores de forma automática
--> nome: qual tipo de dado? string => char / varchar / nchar / nvarchar ?? R. varchar(200)
-------- char => conjunto de caracteres com tamanho fixo => char(10) => 10 caracteres
-----------------ex.: nome char(10) => Ze (2 caracteres) => Ze________ (8 espaços em branco)
-------- varchar => conjunto de caracteres com tamanho variável => varchar(10) => no máximo 10 caracteres
-----------------ex.: nome varchar(10) => Ze (2 caracteres) => Ze (ocupam 2 caracteres)
--> crm (6 digitos + '/' + 2 caracteres estado) Ex.: 123456/SP (suposição) char(9)
--> datanascimento => date

create table medico (
	codigo int not null identity (1,1),
	nome varchar(200) not null,
	datanascimento date,
	crm char(9) not null,
	constraint pk_medico primary key (codigo)
);

create table paciente (
	codigo int not null,
	nome varchar(200) not null,
	email varchar(100),
	constraint pk_paciente primary key (codigo)
);

drop table paciente;

sp_help paciente;

create table consulta (
	codigom int not null,
	codigop int not null,
	[data] date not null,
	constraint fk_consulta_medico foreign key (codigom) references medico (codigo),
	constraint fk_consulta_paciente foreign key (codigop) references paciente (codigo),
	constraint pk_consulta primary key (codigom, codigop, [data]) 
);