CREATE Table cruises(
  id VARCHAR(255) NOT NULL PRIMARY KEY COMMENT "Primary Key",
  creatorId VARCHAR(255) NOT NULL,
  destination VARCHAR(255),
  price int,
  days int,
  capacity int,
  events VARCHAR(255)
) DEFAULT charset utf8 COMMENT '';