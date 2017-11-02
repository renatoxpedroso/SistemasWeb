# SistemasWeb

### Base de Dados PostgresSQL

Nome DB SistemaDeVoluntarios

### Criação de Tabbelas

CREATE TABLE public."SDV_Usuarios"
(
    "Cod" numeric NOT NULL,
    "CodigoUsuario" numeric NOT NULL,
    "Nome" character varying(80) COLLATE pg_catalog."default",
    "TipoUsuario" numeric,
    "Telefone" character varying(15) COLLATE pg_catalog."default",
    "TipoPessoa" numeric,
    "Celular" character varying(15) COLLATE pg_catalog."default" NOT NULL,
    "Senha" character varying(20) COLLATE pg_catalog."default",
    "CPF" character varying(14) COLLATE pg_catalog."default",
    "DataNascimento" date,
    "Email" character varying(50) COLLATE pg_catalog."default",
    "Status" numeric,
    "CodEndereco" numeric,
    CONSTRAINT "SDV_Usuarios_pkey" PRIMARY KEY ("Cod", "CodigoUsuario")
)
