Create PROCEDURE spGeneros
AS
BEGIN
select genero.nombre, count(*) as estudiantes 
from estudiantes
inner join genero
on estudiantes.idgenero=genero.id
group by genero.nombre
END
GO

exec spGeneros