CREATE TABLE Users (
  id SERIAL PRIMARY KEY,
  username TEXT NOT NULL UNIQUE,
  password TEXT NOT NULL
);

CREATE TABLE Epics (
    id SERIAL PRIMARY KEY,
    user_id SERIAL,
    FOREIGN KEY (user_id) references Users(id)
);

CREATE TABLE Tasks (
    id SERIAL PRIMARY KEY,
    epic_id SERIAL,
    title VARCHAR(255),
    description TEXT,
    status TINYINT,
    date_completed DATETIME,
    FOREIGN KEY (epic_id) references Epics(id)
);