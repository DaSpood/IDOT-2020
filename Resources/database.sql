CREATE TABLE Users
(
    ID BIGINT(16)    UNIQUE NOT NULL AUTO_INCREMENT,
    Name VARCHAR(40) UNIQUE NOT NULL,
    Password VARCHAR(32)    NOT NULL,
    Admin BIT DEFAULT FALSE NOT NULL,
    PRIMARY KEY(ID)
);

CREATE TABLE Articles
(
    ID BIGINT(16)     UNIQUE NOT NULL AUTO_INCREMENT,
    Title VARCHAR(40) UNIQUE         ,
    Author VARCHAR(40)       NOT NULL,
    `Date` DATE              NOT NULL,
    Image LONGBLOB           NOT NULL,
    Text TEXT                NOT NULL,
    Viewcount BIGINT         NOT NULL,
    PRIMARY KEY(ID),
    FOREIGN KEY (Author) REFERENCES Users(Name)
);
