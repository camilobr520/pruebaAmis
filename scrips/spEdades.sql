CREATE PROCEDURE spEdades
AS
BEGIN
DECLARE @Edades TABLE( nombre VARCHAR(20), edad INT);

INSERT INTO @Edades VALUES('0 y 10 años',(select SUM(case when DATEDIFF(YEAR,dbo.estudiantes.fecha_nacimiento,GETDATE())BETWEEN 0 AND 10 THEN 1 ELSE 0 END) from estudiantes ));
INSERT INTO @Edades VALUES('11 y 20 años',(select SUM(case when DATEDIFF(YEAR,dbo.estudiantes.fecha_nacimiento,GETDATE())BETWEEN 11 AND 20 THEN 1 ELSE 0 END) from estudiantes ));
INSERT INTO @Edades VALUES('20 y 50 años',(select SUM(case when DATEDIFF(YEAR,dbo.estudiantes.fecha_nacimiento,GETDATE())BETWEEN 20 AND 50 THEN 1 ELSE 0 END) from estudiantes ));
INSERT INTO @Edades VALUES('mayores de 50 años',(select SUM(case when DATEDIFF(YEAR,dbo.estudiantes.fecha_nacimiento,GETDATE())>50 THEN 1 ELSE 0 END) from estudiantes ));
SELECT * FROM @Edades
END
GO

exec spEdades