# SistemasWeb

# Base de Dados PostgresSQL

Nome DB SistemaDeVoluntarios

### Criação de Tabbelas
---------------

```C#
CREATE TABLE public.usuarios
(
    id integer NOT NULL DEFAULT nextval('"Usuarios_Id_seq"'::regclass),
    codusuario character varying COLLATE pg_catalog."default" NOT NULL,
    tipousuario numeric,
    tipopessoa numeric,
    nome character varying(100) COLLATE pg_catalog."default",
    email character varying(100) COLLATE pg_catalog."default",
    senha character varying(100) COLLATE pg_catalog."default",
    datanacimento date,
    cpfcnpj character varying(14) COLLATE pg_catalog."default",
    telefone character varying(11) COLLATE pg_catalog."default",
    celular character varying(11) COLLATE pg_catalog."default",
    rua character varying(100) COLLATE pg_catalog."default",
    numero character varying(10) COLLATE pg_catalog."default",
    bairro character varying(100) COLLATE pg_catalog."default",
    cidade character varying(100) COLLATE pg_catalog."default",
    cep numeric,
    estado character varying(100) COLLATE pg_catalog."default",
    status numeric,
    CONSTRAINT usuarios_pkey PRIMARY KEY (id, codusuario)
)
```

### Tabela Ações
```C#
CREATE TABLE public.acoes
(
    id integer NOT NULL DEFAULT nextval('"Acoes_Id_seq"'::regclass),
    codAcao character varying COLLATE pg_catalog."default" NOT NULL,
    assunto character varying(100) COLLATE pg_catalog."default",
    tipoAcao character varying(100) COLLATE pg_catalog."default",
    datInicio date,
    datFim date,
	status character varying(1) COLLATE pg_catalog."default",
    CONSTRAINT acoes_pkey PRIMARY KEY (id, codAcao)
)
```

### Tabela Tipo Ação
```C#
CREATE TABLE public.tipo_acao
(
    id integer NOT NULL DEFAULT nextval('"Tipo_Acao_Id_seq"'::regclass),
    codTipoAcao character varying COLLATE pg_catalog."default" NOT NULL,
    Nome character varying(100) COLLATE pg_catalog."default",
    CONSTRAINT tipo_acao_pkey PRIMARY KEY (id, codTipoAcao)
)
```

