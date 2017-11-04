# SistemasWeb

# Base de Dados PostgresSQL

Nome DB SistemaDeVoluntarios

### Criação de Tabbelas
---------------

```C#
CREATE TABLE Usuarios
(
    Id integer NOT NULL DEFAULT nextval('"Usuarios_Id_seq"'::regclass),
    CodUsuario character varying COLLATE pg_catalog."default" NOT NULL,
    TipoUsuario numeric,
    TipoPessoa numeric,
    Nome character varying(100) COLLATE pg_catalog."default",
    Email character varying(100) COLLATE pg_catalog."default",
    Senha character varying(100) COLLATE pg_catalog."default",
    DataNacimento date,
    cpfCnpj character varying(14) COLLATE pg_catalog."default",
    Telefone character varying(11) COLLATE pg_catalog."default",
    Celular character varying(11) COLLATE pg_catalog."default",
    Rua character varying(100) COLLATE pg_catalog."default",
    Numero character varying(10) COLLATE pg_catalog."default",
    Bairro character varying(100) COLLATE pg_catalog."default",
    Cidade character varying(100) COLLATE pg_catalog."default",
    Cep numeric,
    Estado character varying(100) COLLATE pg_catalog."default",
    CONSTRAINT Usuarios_pkey PRIMARY KEY (Id, CodUsuario)
)
```
