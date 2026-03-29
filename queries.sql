-- Habilitar el uso de claves foráneas
PRAGMA foreign_keys = ON;

-- Crear tablas
CREATE TABLE IF NOT EXISTS book (
    id INTEGER PRIMARY KEY,
    title TEXT NOT NULL,
    year TEXT NOT NULL,
    isbn TEXT NOT NULL
);

CREATE TABLE IF NOT EXISTS author (
    id_author INTEGER PRIMARY KEY,
    fname TEXT NOT NULL,
    lname TEXT NOT NULL,
    email TEXT NULL UNIQUE
);

CREATE Table IF NOT EXISTS book_author (
    book_id INTEGER NOT NULL,
    author_id INTEGER NOT NULL,
    FOREIGN KEY (book_id) REFERENCES book (id_book),
    FOREIGN KEY (author_id) REFERENCES author (id_author),
    -- Clave primaria compuesta -> asegura que un autor no se relacione dos veces en el mismo libro.
    PRIMARY KEY (book_id, author_id)
);

-- Insertar libros
INSERT INTO
    book (title, year, isbn)
VALUES (
        'Un mundo feliz',
        '1932',
        'abc-001'
    ),
    (
        'El diario de Ana Frank',
        '1947',
        'abc-002'
    ),
    (
        'El mundo de Sofía',
        '1991',
        'abc-003'
    ),
    (
        'Las puertas de las percepción',
        '1954',
        'abc-004'
    );

-- Insertar autores
INSERT INTO
    author (fname, lname)
VALUES ('Aldous', 'Huxley'),
    ('Ana', 'Frank'),
    ('Jostein', 'Jostein Gaarder');

INSERT INTO
    book_author (book_id, author_id)
VALUES (1, 1),
    (2, 2),
    (3, 3),
    (4, 1);

-- Consulta con tablas relacionadas
SELECT fname, lname, title
FROM
    book_author
    INNER JOIN author ON book_author.author_id = author.id_author
    INNER JOIN book ON book_author.book_id = book.id_book;