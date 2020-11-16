CREATE VIEW ObtenerMedicos
AS
SELECT 
p.ID as 'ID Persona',
p.CI as 'CI Persona',
p.NOMBRE as 'Nombre persona',
p.APELLIDO as 'Apellido persona',
p.CORREO as 'Correo persona',
l.ID as 'ID localidad',
l.NOMBRE as 'Nombre localidad',
d.ID as 'ID departamento',
d.NOMBRE as 'Nombre departamento',
f.HABILITADO as 'Habilitado funcionario'
from personas p
JOIN localidades l on l.ID=p.ID_LOCALIDAD
JOIN departamentos d on d.ID=l.ID_DEPARTAMENTO
JOIN funcionarios f on f.ID_PERSONA=p.ID
JOIN medicos m on m.ID_FUNCIONARIO=f.ID_PERSONA
WHERE p.TIPO='Funcionario' AND f.TIPO='Medico' AND f.HABILITADO=TRUE
ORDER BY p.ID;



CREATE VIEW ObtenerListadoMedicos
AS
SELECT
p.ID as 'ID medico',
p.CI as 'CI medico',
p.NOMBRE as 'Nombre medico',
p.APELLIDO as 'Apellido medico',
p.CORREO as 'Correo medico',
f.HABILITADO as 'Habilitado medico',
l.ID as 'ID localidad medico',
l.NOMBRE as 'Nombre localidad medico',
d.ID as 'ID departamento medico',
d.NOMBRE as 'Nombre departamento medico'
FROM medicos m JOIN funcionarios f ON f.ID_PERSONA=m.ID_FUNCIONARIO
JOIN personas p ON p.ID=f.ID_PERSONA
JOIN localidades l ON l.ID=p.ID_LOCALIDAD
JOIN departamentos d ON d.ID=l.ID_DEPARTAMENTO;


CREATE VIEW ObtenerMedicosPorEspecialidad
AS 
SELECT
p.ID AS 'ID medico',
p.CI AS 'CI medico',
p.NOMBRE AS 'Nombre medico',
p.APELLIDO AS 'Apellido medico',
p.CORREO AS 'Correo medico',
l.ID AS 'ID localidad medico',
l.NOMBRE AS 'Nombre localidad medico',
d.ID AS 'ID departamento medico',
d.NOMBRE AS 'Nombre departamento medico',
f.HABILITADO AS 'Habilitado funcionario medico',
e.ID_ESPECIALIDAD AS 'ID especialidad'
FROM personas p
JOIN localidades l ON l.ID=p.ID_LOCALIDAD
JOIN departamentos d ON d.ID=l.ID_DEPARTAMENTO
JOIN funcionarios f ON f.ID_PERSONA=p.ID
JOIN medicos m ON m.ID_FUNCIONARIO=f.ID_PERSONA
JOIN especialidades_medicos e ON e.ID_MEDICO=m.ID_FUNCIONARIO;


CREATE VIEW ObtenerPacientes
AS
SELECT 
p.ID AS 'ID Persona',
p.CI AS 'CI Persona',
p.NOMBRE AS 'Nombre persona',
p.APELLIDO AS 'Apellido persona',
p.CORREO AS 'Correo persona',
p1.TELEFONOMOVIL AS 'Telefonomovil paciente',
p1.TELEFONOFIJO AS 'Telefonofijo paciente',
p1.SEXO AS 'Sexo paciente',
p1.FECHANACIMIENTO AS 'Fecha nacimiento paciente',
p1.FECHADEFUNCION AS 'Fecha defuncion paciente',
p1.CALLE AS 'Calle paciente',
p1.NUMEROPUERTA AS 'Numero puerta paciente',
p1.APARTAMENTO AS 'Apartamento paciente',
l.ID AS 'ID localidad',
l.NOMBRE AS 'Nombre localidad',
d.ID AS 'ID departamento',
d.NOMBRE AS 'Nombre departamento'
FROM personas p
JOIN pacientes p1 ON p1.ID_PERSONA=p.ID
JOIN localidades l ON l.ID=p.ID_LOCALIDAD
JOIN departamentos d ON d.ID=l.ID_DEPARTAMENTO;


CREATE VIEW ObtenerAdministrativos
AS
SELECT 
p.ID AS 'ID Persona',
p.CI AS 'CI Persona',
p.NOMBRE AS 'Nombre persona',
p.APELLIDO AS 'Apellido persona',
p.CORREO AS 'Correo persona',
a.ES_ENCARGADO AS 'Encargado administrativo',
l.ID AS 'ID localidad',
l.NOMBRE AS 'Nombre localidad',
d.ID AS 'ID departamento',
d.NOMBRE AS 'Nombre departamento'
FROM personas p 
JOIN funcionarios f ON f.ID_PERSONA=p.ID
JOIN administrativos a ON a.ID_FUNCIONARIO=f.ID_PERSONA
JOIN localidades l ON l.ID=p.ID_LOCALIDAD
JOIN departamentos d ON d.ID=l.ID_DEPARTAMENTO
WHERE f.tipo='Administrativo' AND f.HABILITADO=TRUE;


CREATE VIEW ObtenerListadoAdministrativos
AS
SELECT
p.ID as 'ID administrativo',
p.CI as 'CI administrativo',
p.NOMBRE as 'Nombre administrativo',
p.APELLIDO as 'Apellido administrativo',
p.CORREO as 'Correo administrativo',
f.HABILITADO as 'Habilitado administrativo',
a.ES_ENCARGADO as 'Es encargado',
l.ID as 'ID localidad administrativo',
l.NOMBRE as 'Nombre localidad administrativo',
d.ID as 'ID departamento administrativo',
d.NOMBRE as 'Nombre departamento administrativo'
FROM administrativos a JOIN funcionarios f ON f.ID_PERSONA=a.ID_FUNCIONARIO
JOIN personas p ON p.ID=f.ID_PERSONA
JOIN localidades l ON l.ID=p.ID_LOCALIDAD
JOIN departamentos d ON d.ID=l.ID_DEPARTAMENTO;


CREATE VIEW ObtenerUsuario
AS
SELECT
u.ID AS 'ID usuario',
u.CONTRASENIA AS 'Contrasena usuario',
u.ID_PERSONA AS 'ID persona'
FROM usuarios u
WHERE u.HABILITADO=TRUE;


CREATE VIEW ObtenerDatosDiagnosticos
AS
SELECT
d1.ID AS 'ID diagnostico primario',
d1.FECHA_HORA AS 'Fecha hora diagnostico primario',
d1.TIPO AS 'Tipo diagnostico primario',
d2.COMENTARIOS_ADICIONALES AS 'Comentarios consulta',
p2.ID AS 'ID paciente',
p2.CI AS 'CI paciente',
p2.NOMBRE AS 'Nombre paciente',
p2.APELLIDO AS 'Apellido paciente',
p2.CORREO AS 'Correo paciente',
p1.TELEFONOMOVIL AS 'Telefonomovil paciente',
p1.TELEFONOFIJO AS 'Telefonofijo paciente',
p1.SEXO AS 'Sexo paciente',
p1.FECHANACIMIENTO AS 'Fecha nacimiento paciente',
p1.FECHADEFUNCION AS 'Fecha defuncion paciente',
p1.CALLE AS 'Calle paciente',
p1.NUMEROPUERTA AS 'Numero puerta paciente',
p1.APARTAMENTO AS 'Apartamento paciente',
l1.ID AS 'ID localidad paciente',
l1.NOMBRE AS 'Nombre localidad paciente',
d3.ID AS 'ID departamento paciente',
d3.NOMBRE AS 'Nombre departamento paciente',
p3.ID AS 'ID medico',
p3.CI AS 'CI medico',
p3.NOMBRE AS 'Nombre medico',
p3.APELLIDO AS 'Apellido medico',
p3.CORREO AS 'Correo medico',
f.HABILITADO AS 'Habilitado medico',
l2.ID AS 'ID localidad medico',
l2.NOMBRE AS 'Nombre localidad medico',
d4.ID AS 'ID departamento medico',
d4.NOMBRE AS 'Nombre departamento medico'
FROM diagnosticos_primarios d1
JOIN pacientes p1 ON p1.ID_PERSONA=d1.ID_PACIENTE
JOIN personas p2 ON p2.ID=p1.ID_PERSONA
JOIN localidades l1 ON l1.ID=p2.ID_LOCALIDAD
JOIN departamentos d3 ON d3.ID=l1.ID_DEPARTAMENTO
LEFT JOIN diagnosticos_primarios_con_consulta d2 ON d1.ID=d2.ID_DIAGNOSTICO_PRIMARIO
LEFT JOIN medicos m ON m.ID_FUNCIONARIO=d2.ID_MEDICO
LEFT JOIN funcionarios f ON f.ID_PERSONA=m.ID_FUNCIONARIO
LEFT JOIN personas p3 ON p3.ID=f.ID_PERSONA
LEFT JOIN localidades l2 ON l2.ID=p3.ID_LOCALIDAD
LEFT JOIN departamentos d4 ON d4.ID=l2.ID_DEPARTAMENTO;


CREATE VIEW ObtenerSintomasDeDiagnosticosPrimarios
AS
SELECT
d1.ID AS 'ID diagnostico primario',
s.ID AS 'ID Sintoma',
s.NOMBRE AS 'Nombre Sintoma',
s.DESCRIPCION AS 'Descripcion Sintoma',
s.RECOMENDACIONES AS 'Recomendaciones Sintoma',
s.URGENCIA AS 'Urgencia Sintoma',
s.HABILITADO AS 'Habilitado Sintoma'
FROM diagnosticos_primarios d1
JOIN sistema_evalua se ON se.ID_DIAGNOSTICO_PRIMARIO=d1.ID
JOIN sintomas s ON s.ID=se.ID_SINTOMA
ORDER BY d1.ID, s.ID;


CREATE VIEW ObtenerEnfermedadesDeDiagnosticosPrimarios
AS
SELECT
d1.ID AS 'ID diagnostico primario',
e.ID AS 'ID enfermedad',
e.NOMBRE AS 'Nombre enfermedad',
e.DESCRIPCION AS 'Descripcion enfermedad',
e.RECOMENDACIONES AS 'Recomendaciones enfermedad',
e.GRAVEDAD AS 'Gravedad enfermedad',
e.HABILITADO AS 'Habilitado enfermedad',
sd.PROBABILIDAD AS 'Probabilidad enfermedad',
e1.ID AS 'ID especialidad',
e1.NOMBRE AS 'Nombre especialidad',
e1.HABILITADO AS 'Habilitado especialidad'
FROM diagnosticos_primarios d1
JOIN sistema_diagnostica sd ON sd.ID_DIAGNOSTICO_PRIMARIO=d1.ID
JOIN enfermedades e ON e.ID=sd.ID_ENFERMEDAD
JOIN especialidades e1 ON e1.ID=e.ID_ESPECIALIDAD
ORDER BY d1.ID, e.ID;


CREATE VIEW ObtenerDatosConsultas
AS
SELECT
d1.ID_MEDICO AS 'ID medico',
d1.COMENTARIOS_ADICIONALES AS 'Comentarios adicionales diagnostico primario con consulta',
d2.ID AS 'ID diagnostico primario',
d2.FECHA_HORA AS 'Fecha hora diagnostico primario',
p2.ID AS 'ID paciente',
p2.CI AS 'CI paciente',
p2.NOMBRE AS 'Nombre paciente',
p2.APELLIDO AS 'Apellido paciente',
p2.CORREO AS 'Correo paciente',
p1.TELEFONOMOVIL AS 'Telefonomovil paciente',
p1.TELEFONOFIJO AS 'Telefonofijo paciente',
p1.SEXO AS 'Sexo paciente',
p1.FECHANACIMIENTO AS 'Fecha nacimiento paciente',
p1.FECHADEFUNCION AS 'Fecha defuncion paciente',
p1.CALLE AS 'Calle paciente',
p1.NUMEROPUERTA AS 'Numero puerta paciente',
p1.APARTAMENTO AS 'Apartamento paciente',
l.ID AS 'ID localidad paciente',
l.NOMBRE AS 'Nombre localidad paciente',
d3.ID AS 'ID departamento paciente',
d3.NOMBRE AS 'Nombre departamento paciente'
FROM diagnosticos_primarios_con_consulta d1
JOIN diagnosticos_primarios d2 ON d1.ID_DIAGNOSTICO_PRIMARIO=d2.ID
JOIN pacientes p1 ON d2.ID_PACIENTE=p1.ID_PERSONA
JOIN personas p2 ON p2.ID=p1.ID_PERSONA
JOIN localidades l ON l.ID=p2.ID_LOCALIDAD
JOIN departamentos d3 ON d3.ID=l.ID_DEPARTAMENTO;


CREATE VIEW ObtenerUltimosMensajesConsulta
AS
SELECT 
ID as 'ID mensaje',
FECHAHORA as 'Fecha hora mensaje',
FORMATO as 'Formato mensaje',
NOMBRE_ARCHIVO as 'Nombre archivo',
CONTENIDO as 'Contenido mensaje',
REMITENTE as 'Remitente mensaje',
ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA AS 'ID diagnostico'
FROM mensajes
ORDER BY FECHAHORA DESC;


CREATE VIEW ObtenerDiagnosticosDiferencialesPorConsulta
AS
SELECT 
d1.ID as 'ID diagnostico diferencial',
d1.CONDUCTA_A_SEGUIR as 'Conducta a seguir diagnostico diferencial',
d1.FECHAHORA as 'Fecha hora diagnostico diferencial',
d2.ID_DIAGNOSTICO_PRIMARIO as 'ID diagnostico primario',
e1.ID as 'ID enfermedad',
e1.NOMBRE as 'Nombre enfermedad',
e1.DESCRIPCION as 'Descripcion enfermedad',
e1.RECOMENDACIONES as 'Recomendaciones enfermedad',
e1.GRAVEDAD as 'Gravedad enfermedad',
e1.HABILITADO as 'Habilitado enfermedad',
e2.ID as 'ID especialidad',
e2.NOMBRE as 'Nombre especialidad',
e2.HABILITADO as 'Habilitado especialidad'
FROM diagnosticos_diferenciales d1
JOIN diagnosticos_primarios_con_consulta d2 on d2.ID_DIAGNOSTICO_PRIMARIO=d1.ID_DIAGNOSTICO_PRIMARIO_CON_CONSULTA
JOIN enfermedades e1 on e1.ID=d1.ID_ENFERMEDAD
JOIN especialidades e2 on e2.ID=e1.ID_ESPECIALIDAD
ORDER BY d1.fechahora DESC;


CREATE VIEW ObtenerSintomasAsociados
AS
SELECT
s.ID as 'ID Sintoma',
s.NOMBRE as 'Nombre Sintoma',
s.DESCRIPCION as 'Descripcion Sintoma',
s.RECOMENDACIONES as 'Recomendaciones Sintoma',
s.URGENCIA as 'Urgencia Sintoma',
s.HABILITADO as 'Habilitado Sintoma',
c.FRECUENCIA as 'Frecuencia cuadro sintomatico',
c.ID_ENFERMEDAD as 'ID enfermedad'
FROM sintomas s JOIN cuadro_sintomatico c ON s.ID=c.ID_SINTOMA
WHERE s.HABILITADO=TRUE;


CREATE VIEW ObtenerEnfermedadesAsociadas
AS
SELECT
e1.ID as 'ID enfermedad',
e1.NOMBRE as 'Nombre enfermedad',
e1.DESCRIPCION as 'Descripcion enfermedad',
e1.RECOMENDACIONES as 'Recomendaciones enfermedad',
e1.GRAVEDAD as 'Gravedad enfermedad',
e1.HABILITADO as 'Habilitado enfermedad',
e2.ID as 'ID especialidad',
e2.NOMBRE as 'Nombre especialidad',
e2.HABILITADO as 'Habilitado especialidad',
c.ID_SINTOMA as 'ID sintoma asociado',
c.FRECUENCIA as 'Frecuencia sintoma asociado'
FROM enfermedades e1 JOIN especialidades e2 ON e2.ID=e1.ID_ESPECIALIDAD
JOIN cuadro_sintomatico c ON c.ID_ENFERMEDAD=e1.ID
WHERE e1.HABILITADO=TRUE;


CREATE VIEW ObtenerListadoEnfermedades
AS
SELECT
e1.ID as 'ID enfermedad',
e1.NOMBRE as 'Nombre enfermedad',
e1.DESCRIPCION as 'Descripcion enfermedad',
e1.RECOMENDACIONES as 'Recomendaciones enfermedad',
e1.GRAVEDAD as 'Gravedad enfermedad',
e1.HABILITADO as 'Habilitado enfermedad',
e2.ID as 'ID especialidad',
e2.NOMBRE as 'Nombre especialidad',
e2.HABILITADO as 'Habilitado especialidad'
FROM enfermedades e1 JOIN especialidades e2 ON e2.ID=e1.ID_ESPECIALIDAD;


CREATE VIEW ObtenerEspecialidadesPorMedico
AS
SELECT
e1.ID AS 'ID especialidad',
e1.NOMBRE AS 'Nombre especialidad',
e2.ID_MEDICO AS 'ID medico'
FROM especialidades e1
JOIN especialidades_medicos e2 ON e2.ID_ESPECIALIDAD=e1.ID
WHERE e1.HABILITADO=TRUE;
