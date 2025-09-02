CREATE TABLE "user" (
    Id SERIAL PRIMARY KEY,
    FirstName INT NOT NULL,
    LastName DECIMAL NOT NULL,
    UserName TEXT NOT NULL,
    Password TEXT NOT NULL
);