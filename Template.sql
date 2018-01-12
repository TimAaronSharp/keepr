-- CREATE TABLE users (
--     id int NOT NULL AUTO_INCREMENT,
--     username VARCHAR(20) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     password VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),
--     UNIQUE KEY email (email)
-- );


-- CREATE TABLE vaults (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(20) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId int,
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );


-- CREATE TABLE keeps (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(20) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId int,
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );


-- INSERT INTO users (Username, Email, Password)
-- VALUES ("timmyboi", "timmy@boi.com", "test");
-- SELECT LAST_INSERT_ID();


-- INSERT INTO keeps (UserId, Name, Description, Views, Shares, VaultsAddedTo, ImageURL, DateCreated)
-- VALUES (4, "Keep Test 9", "This is a Keep Test 9", 0, 0, 0, "http://placehold.it/200x200", "2018-01-12 14:01:00")
-- YYYY-MM-DD HH:MM:SS

-- INSERT INTO vaults (UserId, Name, Description, Views, DateCreated)
-- VALUES (4, "Vault Test 4", "This is a Vault Test 4", 0, "2018-01-12 14:00:00")

-- INSERT INTO vaultkeeps (vaultId, keepId, userId)
-- VALUES(4,6,4)


-- CREATE TABLE vaultkeeps (
--     id int NOT NULL AUTO_INCREMENT,
--     vaultId int NOT NULL,
--     keepId int NOT NULL,
--     userId int NOT NULL,

--     PRIMARY KEY (id),
--     INDEX (vaultId, keepId),
--     INDEX (userId),

--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (vaultId)
--         REFERENCES vaults(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (keepId)
--         REFERENCES keeps(id)
--         ON DELETE CASCADE
-- )


-- -- USE THIS LINE FOR GET KEEPS BY VAULTID

-- SELECT * FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId
-- WHERE (vaultId = 3)


-- ALTER TABLE vaults
-- ADD views int;

-- DELETE FROM users WHERE id = 5
-- DELETE FROM vaults WHERE id = 2
-- DELETE FROM vaultkeeps WHERE id = 9

-- SELECT * FROM users
-- SELECT * FROM vaults
-- SELECT * FROM keeps
-- SELECT * FROM vaultkeeps