DROP TABLE IF EXISTS "Categoria";
DROP TABLE IF EXISTS "Grupo";
DROP TABLE IF EXISTS "Laboratorio";
DROP TABLE IF EXISTS "Marca";
DROP TABLE IF EXISTS "Modelo";
DROP TABLE IF EXISTS "Plantel";
DROP TABLE IF EXISTS "Semestre";
DROP TABLE IF EXISTS "Tipo";
DROP TABLE IF EXISTS "Usuario";
DROP TABLE IF EXISTS "Docente";
DROP TABLE IF EXISTS "Estudiante";
DROP TABLE IF EXISTS "Mantenimiento";
DROP TABLE IF EXISTS "Material";
DROP TABLE IF EXISTS "Pedido";
DROP TABLE IF EXISTS "Desc_Pedido";

CREATE TABLE "Categoria" (
	"CategoriaId" INTEGER PRIMARY KEY,
	"Nombre" nvarchar (50) NOT NULL ,
	"Descripcion" nvarchar(50) NOT NULL
);

-----------------------------------------------------

CREATE TABLE "Grupo" (
  "GrupoId" INTEGER PRIMARY KEY,
  "Nombre" nvarchar(50) NOT NULL
);

-----------------------------------------------------

CREATE TABLE "Laboratorio" (
  "LaboratorioId" INTEGER PRIMARY KEY,
  "Nombre" nvarchar(50) NOT NULL,
  "Descripcion" nvarchar(100) NOT NULL
);

-----------------------------------------------------

CREATE TABLE "Marca" (
  "MarcaId" INTEGER PRIMARY KEY,
  "Nombre" varchar(50) NOT NULL,
  "Descripcion" varchar(100) NOT NULL
);

-----------------------------------------------------

CREATE TABLE "Modelo" (
  "ModeloId" INTEGER PRIMARY KEY,
  "Nombre" varchar(50) NOT NULL,
  "Descripcion" varchar(100) NOT NULL
);

-----------------------------------------------------

CREATE TABLE "Plantel" (
  "PlantelId" INTEGER PRIMARY KEY,
  "Nombre" varchar(50) NOT NULL,
  "Direccion" varchar(100) NOT NULL,
  "Telefono" INTEGER NOT NULL
);

-----------------------------------------------------

CREATE TABLE "Semestre" (
  "SemestreId" INTEGER PRIMARY KEY,
  "Numero" INTEGER NOT NULL
);

-----------------------------------------------------

CREATE TABLE "Tipo" (
  "TipoId" INTEGER PRIMARY KEY,
  "Nombre" varchar(50) NOT NULL,
  "Descripcion" varchar(100) NOT NULL
);

-----------------------------------------------------

CREATE TABLE "Usuario" (
  "UsuarioId" INTEGER PRIMARY KEY,
  "Usuario" varchar(50) NOT NULL,
  "Password" varchar(50) NOT NULL
);

-----------------------------------------------------

CREATE TABLE "Docente" (
  "DocenteId" INTEGER PRIMARY KEY,
  "Nombre" varchar(50) NOT NULL,
  "ApellidoPaterno" varchar(50) NOT NULL,
  "ApellidoMaterno" varchar(50) NOT NULL,
  "Correo" varchar(100) NOT NULL,
  "PlantelId" INTEGER NOT NULL,
  "UsuarioId" INTEGER NOT NULL,

  CONSTRAINT "FK_Docente_Plantel" FOREIGN KEY 
	(
		"PlantelId"
	) REFERENCES "Plantel" (
		"PlantelId"
    ),

  CONSTRAINT "FK_Docente_Usuario" FOREIGN KEY 
	(
		"UsuarioId"
	) REFERENCES "Usuario" (
		"UsuarioId"
    )

);

-----------------------------------------------------

CREATE TABLE "Almacenista" (
  "AlmacenistaId" INTEGER PRIMARY KEY,
  "Nombre" varchar(50) NOT NULL,
  "ApellidoPaterno" varchar(50) NOT NULL,
  "ApellidoMaterno" varchar(50) NOT NULL,
  "Correo" varchar(100) NOT NULL,
  "PlantelId" INTEGER NOT NULL,
  "UsuarioId" INTEGER NOT NULL,

  CONSTRAINT "FK_Almacenista_Plantel" FOREIGN KEY 
	(
		"PlantelId"
	) REFERENCES "Plantel" (
		"PlantelId"
    ),

  CONSTRAINT "FK_Almacenista_Usuario" FOREIGN KEY 
	(
		"UsuarioId"
	) REFERENCES "Usuario" (
		"UsuarioId"
    )

);

-----------------------------------------------------

CREATE TABLE "Coordinador" (
  "CoordinadorId" INTEGER PRIMARY KEY,
  "Nombre" varchar(50) NOT NULL,
  "ApellidoPaterno" varchar(50) NOT NULL,
  "ApellidoMaterno" varchar(50) NOT NULL,
  "Correo" varchar(100) NOT NULL,
  "PlantelId" INTEGER NOT NULL,
  "UsuarioId" INTEGER NOT NULL,

  CONSTRAINT "FK_Coordinador_Plantel" FOREIGN KEY 
	(
		"PlantelId"
	) REFERENCES "Plantel" (
		"PlantelId"
    ),

  CONSTRAINT "FK_Coordinador_Usuario" FOREIGN KEY 
	(
		"UsuarioId"
	) REFERENCES "Usuario" (
		"UsuarioId"
    )

);

-----------------------------------------------------

CREATE TABLE "Estudiante" (
  "EstudianteId" INTEGER PRIMARY KEY,
  "Nombre" varchar(50) NOT NULL,
  "ApellidoPaterno" varchar(50) NOT NULL,
  "ApellidoMaterno" varchar(50) NOT NULL,
  "SemestreId" INTEGER NOT NULL,
  "GrupoId" INTEGER NOT NULL,
  "Adeudo" decimal(10,2) NOT NULL,
  "Correo" varchar(100) NOT NULL,
  "PlantelId" INTEGER NOT NULL,
  "UsuarioId" INTEGER NOT NULL,

  CONSTRAINT "FK_Estudiante_Semestre" FOREIGN KEY 
	(
		"SemestreId"
	) REFERENCES "Semestre" (
		"SemestreId"
    ),

  CONSTRAINT "FK_Estudiante_Plantel" FOREIGN KEY 
	(
		"PlantelId"
	) REFERENCES "Plantel" (
		"PlantelId"
    ),

  CONSTRAINT "FK_Estudiante_Grupo" FOREIGN KEY 
	(
		"GrupoId"
	) REFERENCES "Grupo" (
		"GrupoId"
    ),

  CONSTRAINT "FK_Estudiante_Usuario" FOREIGN KEY 
	(
		"UsuarioId"
	) REFERENCES "Usuario" (
		"UsuarioId"
    )

);

-----------------------------------------------------

CREATE TABLE "Mantenimiento" (
  "MantenimientoId" INTEGER PRIMARY KEY,
  "Fecha" date NOT NULL,
  "TipoId" INTEGER NOT NULL,
  "MaterialId" INTEGER NOT NULL,

  CONSTRAINT "FK_Mantenimiento_Tipo" FOREIGN KEY 
	(
		"TipoId"
	) REFERENCES "Tipo" (
		"TipoId"
    ),

  CONSTRAINT "FK_Mantenimiento_Material" FOREIGN KEY 
	(
		"MaterialId"
	) REFERENCES "Material" (
		"MaterialId"
    )

);

-----------------------------------------------------

CREATE TABLE "Material" (
  "MaterialId" INTEGER PRIMARY KEY,
  "ModeloId" INTEGER NOT NULL,
  "Descripcion" varchar(255) NOT NULL,
  "YearEntrada" INTEGER NOT NULL,
  "MarcaId" INTEGER NOT NULL,
  "CategoriaId" INTEGER NOT NULL,
  "Serie" varchar(255) NOT NULL,
  "ValorHistorico" decimal(18,2) NOT NULL,

  CONSTRAINT "FK_Material_Modelo" FOREIGN KEY 
	(
		"ModeloId"
	) REFERENCES "Modelo" (
		"ModeloId"
    ),

  CONSTRAINT "FK_Material_Marca" FOREIGN KEY 
	(
		"MarcaId"
	) REFERENCES "Marca" (
		"MarcaId"
    ),

  CONSTRAINT "FK_Material_Categoria" FOREIGN KEY 
	(
		"CategoriaId"
	) REFERENCES "Categoria" (
		"CategoriaId"
    )
);

-----------------------------------------------------

CREATE TABLE "Pedido" (
  "PedidoId" INTEGER PRIMARY KEY,
  "Fecha" date NOT NULL,
  "LaboratorioId" INTEGER NOT NULL,
  "HoraEntrega" time NOT NULL,
  "HoraDevolucion" time NOT NULL,
  "EstudianteId" INTEGER NOT NULL,
  "DocenteId" INTEGER NOT NULL,

  CONSTRAINT "FK_Pedido_Laboratorio" FOREIGN KEY 
	(
		"LaboratorioId"
	) REFERENCES "Laboratorio" (
		"LaboratorioId"
    ),

  CONSTRAINT "FK_Pedido_Estudiante" FOREIGN KEY 
	(
		"EstudianteId"
	) REFERENCES "Estudiante" (
		"EstudianteId"
    ),

  CONSTRAINT "FK_Material_Docente" FOREIGN KEY 
	(
		"DocenteId"
	) REFERENCES "Docente" (
		"DocenteId"
    )

);

-----------------------------------------------------

CREATE TABLE "Desc_Pedido" (
    "Desc_PedidoId" INTEGER PRIMARY KEY,
    "Cantidad" INTEGER NOT NULL,
    "PedidoId" INTEGER NOT  NULL,
    "MaterialId" INTEGER NOT NULL,

  CONSTRAINT "FK_DescPedido_Pedido" FOREIGN KEY 
	(
		"PedidoId"
	) REFERENCES "Pedido" (
		"PedidoId"
    ),

    CONSTRAINT "FK_DescPedido_Material" FOREIGN KEY 
	(
		"MaterialId"
	) REFERENCES "Material" (
		"MaterialId"
    )
);

