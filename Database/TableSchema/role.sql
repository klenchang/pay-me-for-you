CREATE TABLE IF NOT EXISTS `paymeforyou`.`role` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `role_name` VARCHAR(30) NOT NULL,
  `description` VARCHAR(30) NULL,
  `permissions` TEXT NULL,
  `created_by` VARCHAR(30) NOT NULL,
  `created_time` TIMESTAMP(6) NOT NULL,
  `updated_by` varchar(30),
  `updated_time` timestamp(6),
  PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = 'role info';