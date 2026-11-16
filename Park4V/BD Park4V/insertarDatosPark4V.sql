USE Park4V;
GO

-- Borrar los datos respetando las claves foráneas 
DELETE FROM .Estacionamientos;
DELETE FROM .Zonas;
DELETE FROM .Clientes;
DELETE FROM .Ciudades;
GO

-- CIUDADES
INSERT INTO .Ciudades (Id, Nombre)
VALUES
    (1, N'Pamplona'),
    (2, N'Avila'),
    (3, N'Salamanca'),
    (4, N'Donosti'),
    (5, N'Tudela'),
    (6, N'Bilbao'),
    (7, N'Vitoria'),
    (8, N'Madrid'),
    (9, N'Barcelona');

-- CLIENTES
INSERT INTO .Clientes (Email, Saldo)
VALUES
    (N'maria_goyena@cuatrovientos.org', 150),
    (N'miguel_martin@cuatrovientos.org', 240),
    (N'claudiu_andueza@miempresa.com', 230),
    (N'anne_arance@tuempresa.com', 50),
    (N'kirian_gonzalez@hotmail.com',1200),
    (N'mario_gaytan@gmail.com',150),
    (N'luca_itxaso@gmail.com',200),
    (N'lander_lejona@miempresa.com',22),
    (N'unax_meneses@gmail.com',200);

-- ZONAS
INSERT INTO .Zonas
    (IdCiudad, Zona, PrecioMinuto, MinMaximos)
VALUES
    (1, N'Azul', 0.1000, 120),
    (1, N'Naranja', 0.1000, 720),
    (1, N'Zona Hospitalaria', 0.1500, 180),
    (2, N'Azul', 0.0800, 120),
    (3, N'Azul', 0.1000, 120),
    (4, N'Azul', 0.0800, 120),
    (4, N'Roja', 0.1000, 1440);

-- ESTACIONAMIENTOS
INSERT INTO .Estacionamientos
    (Email, NumMovimiento, Matricula,
     FechaHoraInicio, FechaHoraFin, IdCiudad, Zona)
VALUES
    (N'maria_goyena@cuatrovientos.org', 1, N'2555CCC',
     CONVERT(DATETIME, '2026-06-16 21:03:32.067', 121),
     CONVERT(DATETIME, '2026-06-16 21:13:32.067', 121),
     1, N'Azul'),

    (N'miguel_martin@cuatrovientos.org', 2, N'1234LML',
     CONVERT(DATETIME, '2026-06-20 21:08:14.837', 121),
     CONVERT(DATETIME, '2026-06-20 22:18:14.837', 121),
     4, N'Roja'),

    (N'maria_goyena@cuatrovientos.org', 3, N'2555CCC',
     CONVERT(DATETIME, '2026-06-20 21:06:08.337', 121),
     CONVERT(DATETIME, '2026-06-20 21:16:08.337', 121),
     1, N'Zona Hospitalaria'),

    (N'anne_arance@tuempresa.com', 1, N'2525MMM',
     CONVERT(DATETIME, '2026-06-16 12:03:32.067', 121),
     CONVERT(DATETIME, '2026-06-16 13:13:32.067', 121),
     1, N'Azul'),

    (N'kirian_gonzalez@hotmail.com', 1, N'9988KKL',
     CONVERT(DATETIME, '2026-07-10 09:15:00.000', 121),
     CONVERT(DATETIME, '2026-07-10 11:15:00.000', 121),
     1, N'Naranja'),

    (N'kirian_gonzalez@hotmail.com', 2, N'9988KKL',
     CONVERT(DATETIME, '2026-08-05 16:30:00.000', 121),
     CONVERT(DATETIME, '2026-08-05 17:45:00.000', 121),
     3, N'Azul'),

    (N'mario_gaytan@gmail.com', 1, N'4411BBB',
     CONVERT(DATETIME, '2026-09-01 10:00:00.000', 121),
     CONVERT(DATETIME, '2026-09-01 11:30:00.000', 121),
     2, N'Azul'),

    (N'mario_gaytan@gmail.com', 2, N'4411BBB',
     CONVERT(DATETIME, '2026-10-12 18:20:00.000', 121),
     CONVERT(DATETIME, '2026-10-12 19:10:00.000', 121),
     1, N'Azul'),

    (N'luca_itxaso@gmail.com', 1, N'7712XYZ',
     CONVERT(DATETIME, '2026-10-05 14:00:00.000', 121),
     CONVERT(DATETIME, '2026-10-05 15:30:00.000', 121),
     4, N'Azul'),

    (N'lander_lejona@miempresa.com', 1, N'3344HKL',
     CONVERT(DATETIME, '2026-08-20 08:30:00.000', 121),
     CONVERT(DATETIME, '2026-08-20 11:00:00.000', 121),
     1, N'Zona Hospitalaria'),

    (N'unax_meneses@gmail.com', 1, N'5566GTR',
     CONVERT(DATETIME, '2026-09-14 11:10:00.000', 121),
     CONVERT(DATETIME, '2026-09-14 13:00:00.000', 121),
     4, N'Roja'),

    (N'unax_meneses@gmail.com', 2, N'5566GTR',
     CONVERT(DATETIME, '2026-10-28 17:00:00.000', 121),
     CONVERT(DATETIME, '2026-10-28 18:30:00.000', 121),
     4, N'Azul'),

    (N'claudiu_andueza@miempresa.com', 1, N'1122DEF',
     CONVERT(DATETIME, '2026-07-04 12:00:00.000', 121),
     CONVERT(DATETIME, '2026-07-04 13:15:00.000', 121),
     1, N'Azul'),

    (N'miguel_martin@cuatrovientos.org', 1, N'1234LML',
     CONVERT(DATETIME, '2026-05-10 10:00:00.000', 121),
     CONVERT(DATETIME, '2026-05-10 11:30:00.000', 121),
     1, N'Naranja'),

    (N'anne_arance@tuempresa.com', 2, N'2525MMM',
     CONVERT(DATETIME, '2026-10-15 09:00:00.000', 121),
     CONVERT(DATETIME, '2026-10-15 10:45:00.000', 121),
     3, N'Azul');
GO