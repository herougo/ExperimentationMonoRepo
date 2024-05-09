CREATE TABLE Users (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  username TEXT NOT NULL UNIQUE,
  password TEXT NOT NULL
);

CREATE TABLE Epics (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    user_id INTEGER,
    title VARCHAR(255),
    description TEXT,
    FOREIGN KEY (user_id) references Users(id)
);

CREATE TABLE Tasks (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    epic_id INTEGER,
    title VARCHAR(255),
    description TEXT,
    status TINYINT,
    date_completed DATETIME,
    FOREIGN KEY (epic_id) references Epics(id)
);