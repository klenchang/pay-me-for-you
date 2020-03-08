CREATE TABLE IF NOT EXISTS `paymeforyou`.`affiliate` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `affiliate_name` VARCHAR(30) NOT NULL,
  `company_name` VARCHAR(30) NOT NULL,
  `fundin_commission_rate` DECIMAL(5,2) NOT NULL,
  `fundout_commission_rate` DECIMAL(5,2) NOT NULL,
  `currency` ENUM('Rupiah') NOT NULL,
  `balance` DECIMAL(30,2) NOT NULL,
  `status` TINYINT NOT NULL,
  `created_by` VARCHAR(30) NOT NULL,
  `created_time` TIMESTAMP(6) NOT NULL,
  `updated_by` varchar(30),
  `updated_time` timestamp(6),
  PRIMARY KEY (`id`))
ENGINE = InnoDB
COMMENT = 'affiliate info';