drop database dbTransforme;
create database dbTransforme;

use dbTransforme;

create table tbFuncionarios(
codFunc int not null auto_increment,
nome varchar(100),
email varchar(100),
cpf char(14) not null unique,
dataNasc date,
telCel char(10),
sexo char(1),
logradouro varchar(100),
cep char(9),
numero char(10),
complemento varchar(100),
bairro varchar(100),
cidade varchar(100),
uf char(2),
primary key (codFunc)
);

create table tbUsuarios(
codUsu int not null auto_increment,
nome varchar(30) unique,
senha varchar(12),
codFunc int not null,
primary key(codUsu),
foreign key(codFunc) references tbFuncionarios(codFunc)
);

-- cadastrando funcionario
--insert into tbFuncionarios(nome, email, cpf, dataNasc, telCel, sexo, logradouro, cep, numero, complemento, bairro, cidade, uf) values (@nome, @email, @cpf, @dataNasc, @telCel, @sexo, @logradouro, @cep, @numero, @complemento, @bairro, @cidade, @uf);
--buscar funcionario
--select nome from tbFuncionarios where codFunc = 1;
--buscar por nome
--select nome from tbFuncionarios where nome like '%a%';
--alterar ragistros
--update tbFuncionarios set nome = nome, email = email, cpf = cpf, dataNasc = dataNasc, telCel = telCel, sexo = sexo, logradouro = logradouro, cep = cep, numero = numero, complemento = complemento, bairro = bairro, cidade = cidade, uf = uf where codFunc = codFunc;
--deletar
--delete from tbFuncionarios where codFunc = codFunc;