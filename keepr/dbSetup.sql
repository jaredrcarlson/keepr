
CREATE DATABASE keepr
  DEFAULT CHARACTER SET = 'utf8mb4';

USE keepr;

DROP TABLE IF EXISTS accounts;
CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(2083) COMMENT 'User Picture',
  coverImg varchar(2083) COMMENT 'User Cover Image'
) default charset utf8 COMMENT '';

DROP TABLE IF EXISTS keeps;
CREATE TABLE IF NOT EXISTS keeps(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Created At Timestamp',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update Timestamp',
  name VARCHAR(255) NOT NULL,
  description VARCHAR(500) NOT NULL,
  img VARCHAR(2083) NOT NULL,
  views INT NOT NULL DEFAULT 0,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) DEFAULT CHARSET UTF8;

DROP TABLE IF EXISTS vaults;
CREATE TABLE IF NOT EXISTS vaults(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Created At Timestamp',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update Timestamp',
  name VARCHAR(255) NOT NULL,
  description VARCHAR(500) NOT NULL,
  img VARCHAR(2083) NOT NULL,
  isPrivate BOOLEAN DEFAULT false,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) DEFAULT CHARSET UTF8;

DROP TABLE IF EXISTS vaultkeeps;
CREATE TABLE IF NOT EXISTS vaultkeeps(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Created At Timestamp',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update Timestamp',
  creatorId VARCHAR(255) NOT NULL,
  vaultId INT NOT NULL,
  keepId INT NOT NULL,
  FOREIGN KEY(creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY(vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
  FOREIGN KEY(keepId) REFERENCES keeps(id) ON DELETE CASCADE,
  UNIQUE (vaultId, keepId)
) DEFAULT CHARSET UTF8;

DELETE FROM keeps;
DELETE FROM vaults;
DELETE FROM vaultkeeps;

SELECT
    k.*,
    COUNT(vk.id) AS kept,
    vk.id AS vaultKeepId,
    a.*
    FROM keeps k
    LEFT JOIN vaultkeeps vk ON vk.keepId = k.id
    JOIN accounts a ON a.id = k.creatorId
    WHERE vk.vaultId = 17
    GROUP BY k.id, vk.id
    ;